@if "%_echo%" neq "on" echo off
setlocal

set INIT_TOOLS_LOG=%~dp0init-tools.log
if [%PACKAGES_DIR%]==[] set PACKAGES_DIR=%~dp0packages
if [%TOOLRUNTIME_DIR%]==[] set TOOLRUNTIME_DIR=%~dp0Tools
set DOTNET_PATH=%TOOLRUNTIME_DIR%\dotnetcli\
if [%DOTNET_CMD%]==[] set DOTNET_CMD=%DOTNET_PATH%dotnet.exe
if [%BUILDTOOLS_SOURCE%]==[] set BUILDTOOLS_SOURCE=https://dotnet.myget.org/F/dotnet-buildtools/api/v3/index.json
set /P BUILDTOOLS_VERSION=< "%~dp0BuildToolsVersion.txt"
set BUILD_TOOLS_PATH=%PACKAGES_DIR%\Microsoft.DotNet.BuildTools\%BUILDTOOLS_VERSION%\lib\
set PROJECT_JSON_PATH=%TOOLRUNTIME_DIR%\%BUILDTOOLS_VERSION%
set PROJECT_JSON_CONTENTS={ "dependencies": { "Microsoft.DotNet.BuildTools": "%BUILDTOOLS_VERSION%" }, "frameworks": { "netcoreapp1.0": { } } }
set BUILD_TOOLS_SEMAPHORE=%PROJECT_JSON_PATH%\init-tools.completed

:: if force option is specified then clean the tool runtime and build tools package directory to force it to get recreated
if [%1]==[force] (
  if exist "%TOOLRUNTIME_DIR%" rmdir /S /Q "%TOOLRUNTIME_DIR%"
  if exist "%PACKAGES_DIR%\Microsoft.DotNet.BuildTools" rmdir /S /Q "%PACKAGES_DIR%\Microsoft.DotNet.BuildTools"
)

:: If sempahore exists do nothing
if exist "%BUILD_TOOLS_SEMAPHORE%" (
  echo Tools are already initialized.
  goto :EOF
)

echo Initializing BuildTools ...
echo Running: "%BUILD_TOOLS_PATH%init-tools.cmd" "%~dp0" "%DOTNET_CMD%" "%TOOLRUNTIME_DIR%" >> "%INIT_TOOLS_LOG%"
call "%BUILD_TOOLS_PATH%init-tools.cmd" "%~dp0" "%DOTNET_CMD%" "%TOOLRUNTIME_DIR%" >> "%INIT_TOOLS_LOG%"
set INIT_TOOLS_ERRORLEVEL=%ERRORLEVEL%
if not [%INIT_TOOLS_ERRORLEVEL%]==[0] (
	echo ERROR: An error occured when trying to initialize the tools. Please check '%INIT_TOOLS_LOG%' for more details.
	exit /b %INIT_TOOLS_ERRORLEVEL%
)

echo Copying supplemental overrides from Tools-Override.
copy %~dp0Tools-Override\* %~dp0Tools

:: Create sempahore file
echo Done initializing tools.
echo Init-Tools.cmd completed for BuildTools Version: %BUILDTOOLS_VERSION% > "%BUILD_TOOLS_SEMAPHORE%"