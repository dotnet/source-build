#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
SDK_VERSION=$(cat $SCRIPT_ROOT/DotnetCLIVersion.txt)

if [ -z "${HOME:-}" ]; then
    export HOME="$SCRIPT_ROOT/.home"
    mkdir "$HOME"
fi

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_MULTILEVEL_LOOKUP=0
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/"

(
    # init-tools.sh isn't compatible with these flags. Unset them in this subshell.
    set +euo pipefail
    . "$SCRIPT_ROOT/init-tools.sh"
)

CLIPATH="$SCRIPT_ROOT/Tools/dotnetcli"
SDKPATH="$CLIPATH/sdk/$SDK_VERSION"

set -x

$CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj /flp:v=diag /clp:v=m "$@"

