@echo off
setlocal EnableDelayedExpansion

set __ProjectDir=%~dp0
set __DotNet=%__ProjectDir%\Tools\dotnetcli\dotnet.exe
set __MSBuild=%__ProjectDir%\Tools\MSBuild.dll

:: Initialize the MSBuild Tools
call "%__ProjectDir%\init-tools.cmd"

:: Clean up existing nupkgs
if exist "%__ProjectDir%\bin" (rmdir /s /q "%__ProjectDir%\bin")

"%__DotNet%" "%__MSBuild%" "%__ProjectDir%\tasks\core-setup.tasks.builds" /t:Build /p:PackagesDir=%NUGET_PACKAGES% /verbosity:minimal /flp:logfile=tools.log;v=diag
if not ERRORLEVEL 0 goto :Error

:: Package the assets using Tools
"%__DotNet%" "%__MSBuild%" "%__ProjectDir%\packages.builds" /t:Build /p:PackagesDir=%NUGET_PACKAGES% /p:OSGroup=Windows_NT /verbosity:minimal

if not ERRORLEVEL 0 goto :Error
exit /b 0

:Error
echo An error occurred during packing.
exit /b 1
