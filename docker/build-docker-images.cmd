@echo off
setlocal ENABLEDELAYEDEXPANSION

set SCRIPT_ROOT=%~dp0

if "%1" == "" (
  echo Usage: build-docker-images.cmd [image-base-name]
  exit /b 1
)
set IMAGE_NAME=%1
for /F "tokens=2,3,4,5,6,7 delims=/:. " %%i IN ('echo %DATE% %TIME%') DO set IMAGE_TIMESTAMP=%%i%%j%%k%%l%%m%%n
echo %IMAGE_TIMESTAMP%
exit /b 1
for /D %%i in (%SCRIPT_ROOT%*) do (
  set PARENT_DIR=%%i
  set PARENT_DIR=!PARENT_DIR:\= !
  for %%j in (!PARENT_DIR!) do set TAG=%%j
  echo !TAG!
  docker build -t %IMAGE_NAME%:!TAG!.%IMAGE_TIMESTAMP% %%i
)

endlocal 