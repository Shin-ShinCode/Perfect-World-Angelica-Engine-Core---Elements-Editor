# Build and run — quick start

Source-only distribution. You build it once, then run it. Two projects come out of a
single build:

| Project | Output | What it is |
|---|---|---|
| `Editor/AngelicaEditor.csproj` | `dist/Editor/Universal data Editor.exe` | The desktop editor (net48, x64, WinForms) |
| `McpServer/ACE.McpServer.csproj` | `dist/McpServer/ACE.McpServer.exe` | The MCP server (.NET 10) that drives the editor over a named pipe |

---

## 1. Prerequisites

You need **Windows x64** and one install:

- **.NET SDK 10 or a newer compatible SDK** — https://dotnet.microsoft.com/download/dotnet/10.0 (pick *SDK*, x64)

That is genuinely all. The editor targets .NET Framework 4.8, but its reference
assemblies come from a NuGet package, so you do **not** need Visual Studio or the
.NET Framework Developer Pack. The .NET Framework 4.8 *runtime* the editor needs at
launch ships with Windows 10 1903+ and Windows 11.

Check it:

```pwsh
dotnet --list-sdks
```

You want a line starting with `10.` or a newer compatible version.

---

## 2. Build

From this folder:

```pwsh
dotnet build AngelicaCore.sln -c Release
```

Or just double-click **`build.cmd`**.

First run takes a few minutes (NuGet restores ~20 packages); after that it's ~15
seconds. The current clean Release build reports:

```
    0 Warning(s)
    0 Error(s)
```

If warnings appear, record and review them rather than treating a fixed count as normal.

---

## 3. Run

```
dist\Editor\Universal data Editor.exe
```

- The build copies all runtime data (`Configs/`, `Database.edb`, `i18n/`, `UserData/`,
  `images/`, `Pictures/`, `Default.rae`) next to the .exe automatically — nothing to
  stage by hand.
- The app manifest requests administrator, so **Windows will show a UAC prompt.** That
  is from the original program, not something added here.

For the MCP server (optional — only if you want to drive the editor from an AI client):

```
dist\McpServer\ACE.McpServer.exe
```

Start the **editor first**. The server is only a protocol adapter: it forwards every
request over the named pipe `ACE_MCP_BRIDGE` to the running editor, which owns the
loaded game data. With no editor running, every tool returns a JSON error. See
`McpServer/README.md` and `Editor/MCP_BRIDGE_PROTOCOL.md`.

---

## 4. First launch — point it at your game data

`Default.rae` ships with **all paths empty** — it is a clean profile, not anyone's
working setup. On first launch the editor has no idea where your client is, so set the
paths for whatever you intend to edit. The main ones, as stored in `Default.rae`:

| Setting | Points at |
|---|---|
| `ClientPath` | your client's `element\` folder — set this first, most others hang off it |
| `LastElementsPath` | `element\data\elements.data` |
| `TasksPath` | `element\data\tasks.data` |
| `NPCGenPath` | `element\data\npcgen.data` |
| `AIPolicyPath` | `element\data\aipolicy.data` |
| `GShopPath` / `GShopSevPath` | `element\data\gshop.data` / `gshopsev.data` |
| `DomainSevPath` / `Domain2SevPath` | `element\data\domain.sev` / `domain2.sev` |
| `ConfigsPckPath` / `SurfacesPckPath` / `ModelsPckPath` | the matching `.pck` archives |

Set them in the editor's path/profile dialog and it writes them back to `Default.rae`.
The `SSH*` settings (for editing files on a remote server) are likewise empty — fill
them in only if you need them.

---

## 5. If the build fails

| Symptom | Cause and fix |
|---|---|
| `The current .NET SDK does not support targeting .NET 10` | SDK too old. Install .NET SDK 10. |
| `NU1101` / restore cannot find a package | No internet, or a private NuGet feed is configured. `dotnet nuget list source`, and restore against nuget.org. |
| `MSB3644: reference assemblies for .NETFramework,Version=v4.8 were not found` | The reference-assemblies package failed to restore. Run `dotnet restore` again, or install the .NET Framework 4.8 Developer Pack. |
| Errors only in `ACE.GFX` / SharpDX files | Do not use `-p:ExcludeGfxViewer=true`. That switch is experimental and is *not* a clean build; the viewer is woven into `MainWindow`. The default build is the green one. |
| Editor builds but won't start | Install the .NET Framework 4.8 runtime, and accept the UAC prompt. |

To start over completely:

```pwsh
dotnet clean AngelicaCore.sln
Remove-Item -Recurse -Force dist, Editor\obj, McpServer\obj -ErrorAction SilentlyContinue
dotnet build AngelicaCore.sln -c Release
```

---

## Where to read next

- `README.md` — what this project is and how it was recovered
- `Editor/BUILD.md` — full build detail: every NuGet package, and every fix applied to
  make the 1,174-file decompile compile
- `Editor/README.md` — the recovery write-up and source-tree map
- `McpServer/README.md` — the MCP tool API
- `Editor/RAW/DEOBF_NOTES.md` — how `src_deobf/` was produced from the shipped binary
