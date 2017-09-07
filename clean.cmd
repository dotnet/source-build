@if not defined _echo @echo off

git submodule foreach --recursive git clean -xdf
git submodule foreach --recursive git reset --hard

if [%1] == [-a] (
  call git clean -xdf
  exit /b %ERRORLEVEL%
)

if EXIST "%~dp0Tools\dotnetcli\dotnet.exe" (
  "%~dp0Tools\dotnetcli\dotnet.exe" msbuild "%~dp0build.proj" -t:Clean
  exit /b %ERRORLEVEL%
)