@echo off
powershell -NoProfile -NoLogo -Command "& \"%~dp0build.ps1\" %*; exit $LastExitCode;"
echo on
echo "crummel debug output windows directories"
dir /a /s %~dp0 > %~dp0bin\logs\windowsfiles.log
tree %~dp0 > %~dp0bin\logs\windowstree.log
dir /a /s %~dp0
if %errorlevel% neq 0 exit /b %errorlevel%

