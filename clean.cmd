@if not defined _echo @echo off

git submodule foreach --recursive git clean -xdf
git submodule foreach --recursive git reset --hard

if [%1] == [-a] (
  call git clean -xdf
  exit /b %ERRORLEVEL%
)

if EXIST "%~dp0Tools\dotnetcli\dotnet.exe" (
  set DOTNET_CLI_TELEMETRY_OPTOUT=1
  set DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
  set DOTNET_MULTILEVEL_LOOKUP=0
  "%~dp0Tools\dotnetcli\dotnet.exe" msbuild "%~dp0build.proj" -t:Clean
  exit /b %ERRORLEVEL%
)