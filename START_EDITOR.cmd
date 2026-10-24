@echo off
setlocal
cd /d "%~dp0dist\Editor"
if not exist "Universal data Editor.exe" (
  echo Run BUILD_TOOL.cmd from the project root first.
  pause
  exit /b 1
)
start "" "Universal data Editor.exe"
