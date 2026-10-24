# ACE_MCP_BRIDGE protocol (editor side)

This document maps the **editor's** named-pipe bridge handler (recovered, partly
obfuscated) to the **server's** cleartext command vocabulary. The two halves of
the protocol were recovered from opposite ends:

* **Editor side** (this recovery): `ACE.Mcp.McpBridgeServer`,
  `ACE.Mcp.McpRequestHandler`, `ACE.Mcp.AceMcpRuntime` — Eazfuscator-obfuscated,
  so the command-name *string literals* are encrypted (`#=z…(int)` decryptor
  calls). Control flow, JSON envelope shapes and dispatch structure are fully
  readable.
* **Server side** (teammate `mcp-recoverer`, `rae_source/ace_decompiled/`): the
  .NET MCP server `ACE.McpServer` is **not** obfuscated, so every command string
  it sends over the pipe is in cleartext. That is the authoritative vocabulary
  below.

## Transport

| Property | Value | Source |
|---|---|---|
| Pipe name | `ACE_MCP_BRIDGE` (local, `\\.\pipe\ACE_MCP_BRIDGE`) | server `PipeName` const; editor `McpBridgeServer` (encrypted literal) |
| Direction | `PipeDirection.InOut`, `PipeTransmissionMode.Byte`, `PipeOptions.Asynchronous` | both ends |
| ACL (server stream) | `WorldSid: ReadWrite` + current-owner `FullControl` | editor `McpBridgeServer.cs:65-68` |
| Framing | one JSON object per line, `UTF8` (no BOM), `AutoFlush` writer | both ends |
| Connect timeout | 5000 ms (client) | server `EnsureConnectedAsync` |

The editor runs the pipe server on a background thread (`McpBridgeServer.Start`),
accepts each connection on its own worker thread, and for every non-blank line
calls `McpRequestHandler.HandleRequest(line)` and writes back the JSON result.

## Request / response envelope

`McpRequestHandler.HandleRequest` (editor) accepts two shapes:

**V2 (domain/action):** if the request JSON has a `module` **or** `domain` **or**
`action` key, it is routed to `AceMcpRuntime.DispatchV2(request)`:

```json
{ "module": "elements", "action": "get_item_by_id", "params": { ... } }
{ "domain": "tasks",    "action": "query_tasks",     "params": { ... } }
```

`DispatchV2` reads `domain`/`module` + `action` (+ optional `params`) and calls
`AceMcpRuntime.Dispatch(domain, action, params)`. Domains are looked up in a
handler registry (`IAceMcpDomainHandler` per domain). A special `script` domain
routes to the embedded script engine (`AceMcpScriptEngine`).

**Legacy (cmd/params):** otherwise it reads `cmd` + `params` and runs a giant
string switch (`McpRequestHandler` private dispatcher) over the command name.

**Response:** always `{"result": <obj>}` on success or
`{"error": {"code": -1, "message": "<exception message>"}}` on failure.
Exceptions are also reported to Sentry (`SentryHelper.CaptureException`).

## Domains

`elements`, `tasks`, `aipolicy`, `npcgen`, `common` (+ `script`). The editor's
`AceMcpRuntime.GetModuleStatus` reports load state per module by inspecting
`DataFiles.Elements`, `DataFiles.Tasks`, `DataFiles.AIPolicy`, and the npcgen
document. A `fingerprint` (content hash) is returned per domain so the server can
detect when the loaded module changed underneath it.

## Command vocabulary (authoritative, from server cleartext)

These are the exact strings the server sends; each maps to a case in the editor's
`McpRequestHandler` switch / a domain handler `Execute(action, …)`:

**Status / modules:** `get_status`, `get_loaded_file_info`, `get_loaded_modules`,
`load_module`, `reload_module`, `save_module`, `save_module_as`, `backup_module`,
`export_module_json`.

**Elements – lists:** `get_all_lists`, `get_list_groups`, `get_list_by_idx`,
`get_list_by_name`, `get_fields_by_list_idx`, `get_field_type_info`,
`read_fields`, `calculate_fields`.

**Elements – items:** `get_item_by_id`, `get_item_all_fields`, `get_items_by_list`,
`get_multiple_items`, `get_item_list_references`,
`get_value_by_field_name`, `get_value_by_field_by_name_by_item_id`,
`query_items`, `search_items_by_name`, `search_items_by_field_value`,
`add_item`, `clone_items`, `delete_items`, `rename_items`, `sort_items`,
`set_fields`.

**Tasks:** `get_task_by_id`, `query_tasks`, `add_task`, `clone_tasks`,
`delete_tasks`, `reparent_tasks`, `replace_task_ids`, `rewrite_references`,
`set_task_fields`.

**AIPolicy:** `get_controller`, `get_controllers`, `add_controller`,
`clone_controller`, `remove_controller`, `get_operation`, `add_operation`,
`clone_operation`, `remove_operation`, `set_operation_fields`,
`get_trigger`, `add_trigger`, `clone_trigger`, `remove_trigger`,
`rename_trigger`, `move_trigger`, `set_trigger_fields`.

**NpcGen / dynamic objects / resources:** `get_npcgen_overview`,
`add_existence`, `clone_existence`, `remove_existence`, `move_existence`,
`set_existence_fields`,
`add_resource`, `clone_resource`, `remove_resource`, `move_resource`,
`set_resource_fields`,
`add_dynamic_object`, `clone_dynamic_object`, `remove_dynamic_object`,
`move_dynamic_object`, `set_dynamic_object_fields`.

**Generic query / change-set / script:** `get_entry`, `query_entries`,
`apply_change_set`, `discard_change_set`, `preview`, `script`.

> The editor's switch keys these by `(string.Length, char[k])` (a compiler
> string-switch), then compares against the decrypted literal. Because the literal
> is encrypted in the editor dump, the table above (the server's outbound strings)
> is the reliable name source. Mapping a specific editor case to its name is done
> by matching the `case N:` length and the indexed char against this list.

## Change-set model (mutations)

Mutating commands are staged through a change-set abstraction so the server can
preview then apply/discard:

* `ACE.Mcp.AceMcpChangeSet` / `IAceMcpChangeSetStore` / `AceMcpChangeSetStore`
* `ACE.Mcp.IAceMcpChangeOperation` / `AceMcpDelegateChangeOperation`
* `ACE.Mcp.AceMcpMutationPlanner` (`IAceMcpMutationPlanner`) plans edits
* `AceMcpCommandResult` carries `PreferredDomain` + payload back to the caller
* `ACE.Mcp.AceMcpFileService` (`IAceMcpFileService`) does the file I/O
* `ACE.Mcp.AceMcpScriptEngine` (`IAceMcpScriptEngine`) runs the `script` domain
  (NCalc-style expression / batch engine; see `NCalc.dll` dependency)

`preview` returns the planned diff without writing; `apply_change_set` commits a
staged set; `discard_change_set` drops it.
