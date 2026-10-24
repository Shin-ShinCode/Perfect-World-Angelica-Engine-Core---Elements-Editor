# Building the Angelica Core Editor (recovered source)

The deobfuscated source under [`src_deobf/`](src_deobf/) is wired into a buildable
project, [`AngelicaEditor.csproj`](AngelicaEditor.csproj). This document covers how to
build it, the third-party packages it pulls, and exactly what was changed to make the
1,174-file decompile compile.

## TL;DR

```pwsh
cd angelica_core/Editor
dotnet build AngelicaEditor.csproj -c Release
```

Result of the last verified Release build: **0 errors, 0 warnings**, producing
`../dist/Editor/Universal data Editor.exe` (~17.6 MB).

- Target: **.NET Framework 4.8** (`net48`), **x64**, **WinExe**, WinForms.
- A compatible .NET SDK builds the `net48` target using cached reference assemblies; a full
  Visual Studio install is **not** required.
- `AssemblyName` is `Universal data Editor` (matches the original); `RootNamespace` is
  empty because every recovered type carries its full namespace.

## Project layout / how the csproj is wired

- `EnableDefaultCompileItems=false`; the whole `src_deobf/**/*.cs` tree is the compile
  root (explicit `<Compile Include>`).
- `GenerateAssemblyInfo=false` — `src_deobf/Properties/AssemblyInfo.cs` is the
  hand-supplied assembly metadata from the decompile.
- WinForms `.resx` were emitted by ILSpy **flat at the `src_deobf` root**, named
  `<Namespace>.<Type>.resx`. Each is embedded with
  `LogicalName=<Namespace>.<Type>.resources` so `ComponentResourceManager` resolves it at
  runtime. (90 resx, all `bytearray.base64` image data — `GenerateResourceUsePreserializedResources`
  + the `System.Resources.Extensions` package handle them.)
- The two native embedded resources carried by the original assembly are re-embedded with
  their original logical names: `resources/app.ico` and `SiV9Az9FW` (the Eazfuscator
  string-decryption blob).
- `app.ico` / `app.manifest` (requireAdministrator) are applied as in the original.

## NuGet references (net48-compatible)

The bundled `ACE.Dependency.*` libraries (zlib.net, Ionic.Zlib, Cyotek ImageBox, …) are
decompiled **inline** in `src_deobf` and are therefore **not** referenced as packages.
The genuine third-party libraries are public NuGet packages:

| Package | Version | Used for |
|---|---|---|
| SharpDX | 4.2.0 | Direct3D9 3D viewer / map render core |
| SharpDX.Direct3D9 | 4.2.0 | DX9 device, render states, Font/FillMode/Blend |
| SharpDX.Mathematics | 4.2.0 | Vector3 / Matrix / Color4 math |
| NCalc | 1.3.8 | expression evaluation |
| LiteDB | 5.0.21 | embedded document store |
| YamlDotNet | 13.7.1 | YAML config |
| Sentry | 3.41.0 | crash telemetry (see SentryHelper note) |
| Pfim | 0.11.2 | DDS/TGA image decoding |
| Newtonsoft.Json | 13.0.3 | JSON (MCP, exports) |
| PhotoSauce.MagicScaler | 0.13.2 | image scaling |
| SharpZipLib | 1.4.2 | zip/compression |
| System.Buffers | 4.5.1 | BCL polyfill |
| System.Memory | 4.5.5 | BCL polyfill |
| System.Runtime.CompilerServices.Unsafe | 6.0.0 | BCL polyfill |
| Microsoft.Bcl.HashCode | 1.1.1 | BCL polyfill |
| System.Text.Json | 8.0.5 | JSON |
| System.Resources.Extensions | 8.0.0 | preserialized .resx resources |
| System.Net.Http.WinHttpHandler | 8.0.0 | HTTP transport |

Framework references: `System.Web`, `System.Security`, `System.IO.Compression`(+`.FileSystem`).

`dotnet restore` resolves all of the above against nuget.org.

## What compiles

**Everything builds by default**, including the data-editing tools the task targets —
Elements / eList / eListCollection, sTASKedit (Tasks), GShop, Domain & Domain2,
AIPolicyEditor, NpcGen, Cpk/Pck, EcmEditor, BonFileEditor, the MCP runtime (`ACE.Mcp`),
PWMap (map editor), and the `ACE.GFX` SharpDX viewer.

### 3D viewer (ACE.GFX) is **included**

The SharpDX 3D-viewer files (`ACE.GFX`, plus `PwMapSharpDxEditorForm`,
`BuildInModelView`) had `ref`-math decompile artifacts. Rather than carve them out — they
are woven into `MainWindow`, `RSGlobal`, and the `PWMap` change-log classes, so excluding
them cascades errors into the rest of the editor — the artifacts were **fixed in place**
and GFX builds with everything else.

A `-p:ExcludeGfxViewer=true` switch exists (drops `ACE.GFX/**`) but is **not** a clean
build; it is only for experimentation. The default (GFX included) is the green build.

## Recovered fixes applied to the decompile

All edits are tagged `// TODO(recovered):` in-source. Categories:

1. **14 residual `[IteratorStateMachine(typeof(#=z…))]` attributes** removed (they
   referenced mangled compiler iterator types; cosmetic, the iterators still work).
2. **SharpDX `ref`-math artifacts (~95 sites)** — ILSpy rendered struct ctors/methods as
   `((Vector3)(ref v))._002Ector(…)` / `((Vector3)(ref v)).Normalize()`. Rewritten to
   `v = new Vector3(…)` and `v.Normalize()` in `ACE.PWMap`, `ACE.Models`, `ACE.GFX`.
3. **94 `Type.op_Implicit(expr)` calls** (explicit calls to implicit conversion operators
   — SharpDX RawMatrix/RawVector3/RawBool, JToken) rewritten to `(expr)`, letting the
   implicit conversion fire from context.
4. **Materialized anonymous types** — ILSpy emitted **empty** stubs for 22
   `<>f__AnonymousTypeN` classes that the editor references by name in signatures and
   cached-lambda `Func<>` fields. They are reconstructed as real generic records with a
   type-inferring `Create(…)` factory
   ([`src_deobf/_RecoveredAnon/RecoveredAnonymousTypes.cs`](src_deobf/_RecoveredAnon/RecoveredAnonymousTypes.cs)),
   and the 75 `new { … }` projections that fed them were rewritten to `…Create(…)`.
   (Only `ACE.Mcp`, `ACE.NpcGen.NPCGenEditorForm`, `ACE.Elements.eListCollection` were
   affected.)
5. **Ambiguous-type disambiguation aliases** added at the top of the SharpDX/WinForms
   mixed files (`Color`/`Point`/`Rectangle`/`Font` → `System.Drawing`,
   `Matrix`/`Blend`/`FillMode` → SharpDX, `ImageFormat` → `Pfim`, `Formatting` qualified
   per-use to Newtonsoft vs `System.Xml`).
6. **Accessibility bumps** — 6 nested `private struct`s (+1 `Class394`) that appear as
   `ref` parameters of `internal` methods were promoted to `internal` (CS0051/CS0052).
7. **Mis-rendered members restored to methods** — ILSpy turned indexer/parameterized
   lookups into malformed parameterless properties:
   - `eList.get_fields(string)` (was a broken `fields` property referencing undefined `name`),
   - `eListCollection.get_LI(string)` (130+ call sites; was a parameterless `LI` property),
   - `InfBlocks.set_dictionary(byte[], int, int)` (was an `int dictionary` setter dropping 2 params).
8. **mshtml shim** — the `Microsoft.mshtml` PIA is not resolvable in an SDK-only build, so
   the only two surfaces used (`tagPOINT`, `IHTMLDocument2.createStyleSheet`) are provided
   by [`src_deobf/_RecoveredMshtml/MshtmlInterop.cs`](src_deobf/_RecoveredMshtml/MshtmlInterop.cs)
   with the original COM GUIDs. A `tagPOINT*` pointer-deref artifact in `RSGlobal` was
   fixed (`(tagPOINT)lpPoint).x` → `lpPoint->x`).
9. **Control-flow / IL artifacts** (a handful, all in `MainWindow` / `MainEditor` /
   `Save`): a goto-flattened `DataGridView` pattern variable hoisted to method scope; a
   `Task` local hoisted above a `goto` that skipped its declaration; a `ref int` local
   demoted to a value local; an explicit `base..ctor()` removed; one undecodable
   `ldtoken`/`GetMethodFromHandle` (`LdMemberToken`) stubbed to `null` (falls through to
   the non-reflective path).

### Stubbed (signature-preserving), not fully recovered

- **`ACE.Classes.SentryHelper`** — the original bound to bleeding-edge Sentry APIs
  (`SentryHint` before-send, `SentrySdk.Logger` structured logs, `EnableLogs`/
  `EnableMetrics`) and the `Gapotchenko.Eazfuscator.NET.SDK` symbol decoder
  (`ISymbolDecoder`), none available at the net48-compatible Sentry 3.41 used here. It is
  reduced to a signature-preserving shim: `Init()` still boots Sentry with the stable
  options and `Capture*` forward to the stable `SentrySdk` overloads; the stack-symbol
  demangling before-send hook and the `Log*` structured-logging helpers are no-ops.
  Crash telemetry is non-essential to the data editors. Restore against the original
  Sentry/Eazfuscator SDK versions for full crash reporting. All 530+ `SentryHelper.*` call
  sites compile unchanged.

There are **no excluded files** in the default build.
