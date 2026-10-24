@echo off
setlocal
cd /d "%~dp0"
where dotnet >nul 2>&1
if errorlevel 1 (
  echo Install a Windows x64 .NET SDK and retry. The editor targets .NET Framework 4.8.
  pause
  exit /b 1
)
if not exist verification\logs mkdir verification\logs
dotnet build verification\Regression.csproj -c Release > verification\logs\build.log 2>&1
if errorlevel 1 (
  type verification\logs\build.log
  echo BUILD FAILED. No release package was created.
  pause
  exit /b 1
)
dist\Verification\Regression.exe > verification\logs\regression.log 2>&1
if errorlevel 1 (
  type verification\logs\regression.log
  echo REGRESSION FAILED. No release package was created.
  pause
  exit /b 1
)
powershell -NoProfile -Command "$ErrorActionPreference='Stop'; Compress-Archive -Path 'dist\Editor\*' -DestinationPath 'AngelicaCore_Integrated_Windows_x64.zip' -Force"
if errorlevel 1 (
  echo Packaging failed. See dist\Editor for build output.
  pause
  exit /b 1
)
echo Built: dist\Editor\Universal data Editor.exe
echo Packaged: AngelicaCore_Integrated_Windows_x64.zip
echo Check verification\logs before use. Real-data GUI validation is still required.
pause
