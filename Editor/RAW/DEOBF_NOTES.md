# AngelicaEditor deobfuscation notes (Eazfuscator.NET)

> The `.dll` dumps described below are **not included** in this distribution — these are
> notes on how `src_deobf/` was produced. Building needs only `src_deobf/`.

## Input
`AngelicaEditor.managed-dump.dll` — Angelica Core editor managed assembly, captured from
memory (valid `BSJB` metadata, CLR-loadable as a PE32+/x64 image). Obfuscated with
**Eazfuscator.NET**: namespaces + type names preserved, private members/params mangled
(`#=z…`), string literals encrypted via a caller-token-keyed decrypter
(`Class16::smethod_0(int)→string`, originally `#=zluKJ…::#=z2efCNJc=`) reading the
embedded resource `SiV9Az9FW`.

## Tool
**de4dot-cex v4.0.0** (github.com/ViRb3/de4dot-cex). The released binary crashed with a
`NullReferenceException` in `Eazfuscator_NET.Deobfuscator.DeobfuscateEnd()` because this
memory dump lacks some helper types the Eazfuscator handler expects (assembly/resource
resolvers), leaving them null during final cleanup. Built from source with a one-method
null-guard patch to `DeobfuscateEnd()` (each cleanup target wrapped in a null check; string
decryption already happens earlier in `DeobfuscateMethodEnd`). Built with VS 18 MSBuild,
`TreatWarningsAsErrors=false` (CS1685 ExtensionAttribute dup is benign), dnlib submodule
initialised.

## Command that worked
    de4dot.exe -f AngelicaEditor.managed-dump.dll -p ef -o AngelicaEditor.deobf.dll

(`-p ef` forces the Eazfuscator handler — auto-detect reports "Unknown Obfuscator" on the
dump. The patched build is required to get past the cleanup crash.)

## What de4dot fixed
- Renamed `#=z…` mangled members → `Class16` / `smethod_N` / `Method_N` etc.
- Control-flow + symbol cleanup.
- Rewrote the tampered memory-dump PE into a normal, CLR-loadable on-disk assembly.

`#=z` decompiler artifacts: **312,738 → 14** (the 14 residuals are only
`[IteratorStateMachine(typeof(#=z…))]` attribute references to compiler-generated iterator
state-machine types — cosmetic, no functional impact). CS0100 duplicate-mangled-param
patterns: **593 → 0**.

## Strings
de4dot did **not** inline the decrypted strings into the DLL. Eazfuscator's decrypter is
**caller-metadata-token keyed** — invoking `smethod_0(id)` directly out of context returns the
sentinel `"X0X"` for every id (verified with a net48 x64 reflection host, see
`../../tools/strhost/probe.cs`). So neither de4dot's runtime decryption nor a naive reflection
host can bulk-decrypt; the decrypter call-sites remain in the DLL.

However, **ILSpy 10.1 decrypts these strings statically** during decompilation (it emulates
the Eazfuscator algorithm without executing it). The re-decompile in `../src_deobf/` therefore
contains the real plaintext: e.g. `"Angelica Core (C) 2026"`,
`"Angelica File Package, Perfect World."`, `"Universal data Editor"`, P/Invoke names
(`CreateRemoteThread`, `CloseHandle`), config keys, and the original dev path
`C:\Users\halys\AngelicaCoreEditor\UniversalDataEditor\`. **Zero `"X0X"` sentinels** appear in
the 1174-file decompile, confirming clean decryption throughout.

Note: the example literals cited in the task (`\\.\pipe\ACE_MCP_BRIDGE`, `elements.get_item`,
dotted MCP command names) do **not** exist in this assembly — `ACE.Mcp` dispatches via handler
types/methods, not string command names. The pipe/bridge transport is not a string literal here.

## Outputs
- `AngelicaEditor.deobf.dll` — deobfuscated, symbol-cleaned, CLR-loadable assembly.
- `../src_deobf/` — ILSpy project re-decompile (1174 .cs + `AngelicaEditor.deobf.csproj`),
  string literals decrypted.

## Re-decompile command
    ilspycmd AngelicaEditor.deobf.dll -p -o ../src_deobf
