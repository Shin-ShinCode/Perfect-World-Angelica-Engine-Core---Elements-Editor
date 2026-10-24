# ACE.McpServer

Recovered source for the **Angelica Core Editor (ACE) MCP server** — the Model
Context Protocol front-end that lets an AI client read and mutate Angelica Engine
game data (PWI / Perfect World–style `elements.data`, tasks, AI policy and NPC
generation files) through the running editor.

This project was reconstructed from the ilspycmd decompile of the shipped
`ACE.McpServer.dll` (original source lost). The build is clean: **0 warnings,
0 errors, 0 stubs**. All MCP attributes (`[McpServerTool]`, `[McpServerResource]`,
`[Description]`) are preserved verbatim — they *are* the public API contract.

- Target framework: **.NET 10** (`net10.0`, win-x64)
- SDK: `Microsoft.NET.Sdk.Web` (ASP.NET Core, for the HTTP/SSE transport)
- Original version: **2026.6.1**

---

## What it is

The MCP server is a thin protocol adapter. It does **not** parse game files
itself. Instead it forwards every request, over a local **named pipe**, to the
Angelica Core Editor desktop process (a.k.a. *UniversalDataEditor*), which owns
the loaded data in memory and performs the actual reads and edits.

```
  AI / MCP client
        │  MCP (stdio or HTTP/SSE)
        ▼
  ACE.McpServer (this project)
        │  newline-delimited JSON over named pipe "ACE_MCP_BRIDGE"
        ▼
  Angelica Core Editor (UniversalDataEditor) — holds elements/tasks/aipolicy/npcgen in memory
```

If the editor is not running (or the relevant module is not loaded), tools return
a JSON error object rather than throwing — see *Error handling* below.

---

## The named-pipe bridge protocol

Implemented in [`Bridge/AceBridgeClient.cs`](Bridge/AceBridgeClient.cs).

- **Pipe name:** `ACE_MCP_BRIDGE` (local machine, `PipeDirection.InOut`,
  asynchronous). Connect timeout: 5000 ms.
- **Framing:** one UTF-8 JSON document per line (`\n`-delimited). No BOM.
- **Concurrency:** a single pipe is shared; calls are serialized with a
  `SemaphoreSlim(1, 1)`. On any transport error the pipe is torn down and
  transparently reconnected on the next call.

Two request shapes are sent:

### 1. Method request — `SendRequestAsync`
Used by the read-only tools (metadata, lists, items, fields, search, references)
and all resources.

```json
{ "method": "get_item_by_id", "params": { "id": 1234, "list_idx": -1 } }
```

### 2. Domain command — `SendCommandAsync`
Used by the mutation tool families (elements, tasks, aipolicy, npcgen, script,
common). Carries a protocol version and a domain/action pair.

```json
{ "protocol_version": 1, "domain": "elements", "action": "set_fields",
  "params": { "execution_mode": "preview", "list_idx": 5, "item_ids": [1,2], "fields_json": "{\"price\":100}" } }
```

### Response envelope
Each reply is a single JSON line. The client unwraps it:

- `{ "result": <value> }` → the `result` element is returned to the tool.
- `{ "error": { "message": "..." } }` → raised as an `InvalidOperationException`
  carrying `"ACE bridge error: <message>"`.
- Anything else → the whole root element is returned.

---

## Two-phase mutation model (preview → apply)

Every mutating operation is **non-destructive by default**. The pattern:

1. **Preview.** A `preview_*` tool sends its command with
   `execution_mode = "preview"`. The editor computes the change *without*
   applying it and returns a **`change_set_id`** plus a summary/diff and a
   source **fingerprint** of the affected module.
2. **Apply.** `CommonTools.apply_change_set(change_set_id)` re-checks that the
   module's fingerprint still matches what it was at preview time, and only then
   commits the change. If the underlying data changed in between, the apply is
   rejected — preventing stale/conflicting edits.
3. **Discard.** `CommonTools.discard_change_set(change_set_id)` drops a pending
   preview without applying it.

Persistence is separate from change sets: `save_module` / `save_module_as` /
`backup_module` / `export_module_json` write current editor state to disk.

> **Escape hatch:** `ScriptTools.run_ace_script_unsafe` /
> `run_ace_script_file_unsafe` bypass the preview/apply gate and mutate loaded
> state immediately (`execution_mode = "unsafe"`). Use with care.

Modules managed through `common`: **elements**, **tasks**, **aipolicy**, **npcgen**.

---

## Tool catalog (87 tools across 12 `[McpServerToolType]` classes)

| Class | Tools | Purpose |
|-------|------:|---------|
| **MetadataTools** | 2 | Connection/status, loaded-file info. Hosts the shared `SafeCall` / `SafeCommand` / `FormatJson` helpers. |
| **ListTools** | 4 | Discover element lists (by index / name / groups). |
| **ItemTools** | 4 | Look up items: by id, by list (paginated), all fields, batch. |
| **FieldTools** | 4 | Read field definitions and individual field values / type info. |
| **SearchTools** | 2 | Search items by name substring or by field value. |
| **ReferenceTools** | 1 | Cross-references: who points at a given item. |
| **ElementsMutationTools** | 10 | `query_items` (read) + `preview_*` mutations: set fields, add/clone/delete/rename/sort items, calculate fields, rewrite references. |
| **TasksMutationTools** | 9 | Task tree: query/read + `preview_*` set/clone/add/delete/reparent/replace-ids. |
| **AipolicyMutationTools** | 15 | AIPolicy controllers / triggers / operations: read + `preview_*` add/clone/remove/rename/set-fields. |
| **NpcGenMutationTools** | 23 | NPC generation entries (existence / resource / trigger / dynamic_object): overview, query, read + `preview_*` add/clone/remove/move/set-fields per kind. |
| **ScriptTools** | 4 | Run an ACE Script (inline or file) in preview or unsafe mode. |
| **CommonTools** | 9 | Module lifecycle: load/reload/save/save-as/backup/export, list loaded modules, and **apply_change_set / discard_change_set**. |

### Resources (10 `ace://` URIs, 1 `[McpServerResourceType]`)

Read-only JSON resources in [`Resources/AceResources.cs`](Resources/AceResources.cs):

| URI template | Description |
|--------------|-------------|
| `ace://status` | Connection + load status |
| `ace://loaded-file-info` | Loaded `elements.data` metadata |
| `ace://lists` | All element lists |
| `ace://groups` | Predefined list groups |
| `ace://list/{idx}` | One list by index |
| `ace://list/{list_idx}/fields` | Field definitions of a list |
| `ace://list/{list_idx}/items` | First 100 items of a list |
| `ace://item/{list_idx}/{item_id}` | All fields of one item |
| `ace://item/{list_idx}/{item_id}/references` | References to an item |
| `ace://search/{query}` | Search items by name |

### Error handling

`MetadataTools.SafeCall` / `SafeCommand` wrap every bridge call. On failure they
return a JSON object instead of propagating the exception, so the MCP client
always gets a well-formed payload:

```json
{ "error": true, "message": "...", "tool": "get_item_by_id" }
{ "error": true, "message": "...", "domain": "elements", "action": "set_fields" }
```

---

## Project layout

```
McpServer/
├─ ACE.McpServer.csproj      # net10.0, Sdk.Web, pinned package versions
├─ Program.cs                # entry point: stdio (default) or --http/--sse
├─ Bridge/
│  └─ AceBridgeClient.cs     # named-pipe client + request/command envelopes
├─ Resources/
│  └─ AceResources.cs        # 10 ace:// read-only resources
└─ Tools/                    # 12 [McpServerToolType] classes (87 tools)
   ├─ MetadataTools.cs       # + shared SafeCall/SafeCommand/FormatJson
   ├─ ListTools.cs  ItemTools.cs  FieldTools.cs  SearchTools.cs  ReferenceTools.cs
   ├─ ElementsMutationTools.cs  TasksMutationTools.cs
   ├─ AipolicyMutationTools.cs  NpcGenMutationTools.cs
   └─ ScriptTools.cs  CommonTools.cs
```

### Note on the recovery

The shipped DLL was protected with Eazfuscator. Each tool's JSON parameter object
was a compiler-generated anonymous type whose backing class name was renamed to a
`#=z…` symbol, but whose **property names were preserved** (they are the JSON
keys). The recovery replaces every `new global::#=z…<…>(args)` construction with
an idiomatic C# anonymous object using those real property names — e.g.

```csharp
// decompiled:
new global::#=zKthLNET8ukwkUYrVBPkGvhc=<string,int,int[],string>("preview", list_idx, item_ids, fields_json)
// recovered:
new { execution_mode = "preview", list_idx, item_ids, fields_json }
```

This is byte-for-byte equivalent on the wire and eliminates all 60 obfuscated DTO
classes. No member is stubbed.

---

## Build & run

Requires the **.NET 10 SDK**.

```powershell
# from McpServer/
dotnet restore
dotnet build -c Release
```

Run (the editor must be running with data loaded for tools to succeed):

```powershell
# stdio transport (default) - one MCP client over stdin/stdout
dotnet run -c Release

# HTTP transport, limited to this computer by default
dotnet run -c Release -- --http
# (--sse is an accepted alias for --http)

# Optional: allow access from other devices on the network
# This mode has no authentication; use only on a trusted network and restrict
# access with the host firewall.
dotnet run -c Release -- --http --listen-any
```

In local HTTP mode, connect to `http://127.0.0.1:5489`. The `--listen-any` option
binds to all network interfaces on port `5489`; it should be enabled only when a
remote MCP client is intentionally required.

Logs go to stderr (so stdout stays clean for the stdio transport) and are
appended to `mcp-logs.txt` next to the executable.
```
