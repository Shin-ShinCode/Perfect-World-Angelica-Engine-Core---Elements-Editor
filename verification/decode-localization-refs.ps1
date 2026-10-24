$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$exe = Join-Path $root 'verification\build-theme-language-restart-2026-10-22\Universal data Editor.exe'
$assembly = [Reflection.Assembly]::LoadFrom($exe)
$decode = $assembly.GetType('Class16').GetMethod('smethod_0', [Reflection.BindingFlags]'NonPublic,Static')
$files = @(
    'Editor\src_deobf\ACE.Elements.eListCollection\eListCollection.cs',
    'Editor\src_deobf\ACE.MainWindow\MainWindow.cs',
    'Editor\src_deobf\ACE.Classes\CommonStorage.cs',
    'Editor\src_deobf\ACE.RSGlobal\NamesConverter.cs'
)
foreach ($file in $files) {
    $source = [IO.File]::ReadAllText((Join-Path $root $file))
    $ids = @([regex]::Matches($source, 'Class16\.smethod_0\((\d+)\)') | ForEach-Object { [int]$_.Groups[1].Value } | Sort-Object -Unique)
    foreach ($id in $ids) {
        $key = [int]$id
        try { $value = [string]$decode.Invoke($null, @($key)) } catch { continue }
        if ($value -match 'UserLang|UserTypes|\.cfg|[Ll]ist.?[Nn]ame|[Ff]ield.?[Nn]ame') {
            Write-Output ($file + ' ' + $id + ' ' + $value)
        }
    }
}
