@echo off
setlocal
cd /d "%~dp0"

where dotnet >nul 2>&1
if errorlevel 1 (
    echo.
    echo   The .NET SDK was not found.
    echo   Install .NET SDK 10 ^(x64^) from https://dotnet.microsoft.com/download/dotnet/10.0
    echo.
    pause
    exit /b 1
)

echo Building Angelica Core ^(Release^)...
echo.
dotnet build AngelicaCore.sln -c Release
if errorlevel 1 (
    echo.
    echo   Build FAILED. See BUILD-AND-RUN.md, section 5.
    echo.
    pause
    exit /b 1
)

echo.
echo   Build OK. Review any warnings reported above.
echo.
echo     Editor      dist\Editor\Universal data Editor.exe
echo     MCP server  dist\McpServer\ACE.McpServer.exe
echo.
echo   Start the editor first; the MCP server talks to it over a named pipe.
echo.
pause
