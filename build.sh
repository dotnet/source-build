#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
export SDK_VERSION=$(cat $SCRIPT_ROOT/DotnetCLIVersion.txt)
export SDK3_VERSION=$(cat $SCRIPT_ROOT/Dotnet3CLIVersion.txt)

if [ -z "${HOME:-}" ]; then
    export HOME="$SCRIPT_ROOT/.home"
    mkdir "$HOME"
fi

test=false
args=""
separator=""

while [[ $# > 0 ]]
do
  opt="$(echo "$1" | awk '{print tolower($0)}')"
  case "$opt" in
    -test)
      test=true
      args+="${separator}/t:RunTests"
      shift
      ;;
    *)
      args+="${separator}$1"
      shift
      ;;
  esac
  separator=" "
done

if [ "$test" == "false" ] && [[ "${SOURCE_BUILD_SKIP_SUBMODULE_CHECK:-default}" == "default" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "0" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "false" ]]; then
  source "$SCRIPT_ROOT/check-submodules.sh"
fi

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_MULTILEVEL_LOOKUP=0
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/"

source "$SCRIPT_ROOT/init-tools.sh"

CLIPATH="$SCRIPT_ROOT/Tools/dotnetcli"
SDKPATH="$CLIPATH/sdk/$SDK_VERSION"

set -x

$CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj /bl /flp:v=diag /clp:v=m "$args"

