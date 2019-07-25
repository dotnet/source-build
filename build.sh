#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
export SDK_VERSION=$(cat $SCRIPT_ROOT/DotnetCLIVersion.txt)
export SDK3_VERSION=$(cat $SCRIPT_ROOT/Dotnet3CLIVersion.txt)
arcadeLine=`grep -m 1 'Microsoft\.DotNet\.Arcade\.Sdk' "$SCRIPT_ROOT/global.json"`
pattern="\"Microsoft\.DotNet\.Arcade\.Sdk\" *: *\"(.*)\""
if [[ $arcadeLine =~ $pattern ]]; then
  export ARCADE_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
fi
echo "Found 2.x SDK $SDK_VERSION, 3.x SDK $SDK3_VERSION, Arcade bootstrap $ARCADE_BOOTSTRAP_VERSION"

if [ -z "${HOME:-}" ]; then
    export HOME="$SCRIPT_ROOT/.home"
    mkdir "$HOME"
fi

if [[ "${SOURCE_BUILD_SKIP_SUBMODULE_CHECK:-default}" == "default" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "0" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "false" ]]; then
  source "$SCRIPT_ROOT/check-submodules.sh"
fi

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_MULTILEVEL_LOOKUP=0
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/"

source "$SCRIPT_ROOT/init-tools.sh"

# While Arcade works as an SDK so we can use our SourceBuiltSdkOverride, BuildTools does not.
# Additionally, a few repos expect BuildTools and Arcade to be in the same directories.
# We don't build BuildTools, so we copy the existing BuildTools into the source-built folder so it can live with Arcade.
# This source-built folder is only used during the build and thrown away after that, so there's no rish of contaminating
# the shipping product with BuildTools binaries.
if [[ ! -d "$SCRIPT_ROOT/Tools/source-built" ]]; then
    mkdir "$SCRIPT_ROOT/Tools/source-built"
    cp -r "$SCRIPT_ROOT/Tools" /tmp/
    mv /tmp/Tools /tmp/source-built/
    mv /tmp/source-built "$SCRIPT_ROOT/Tools/"
fi

CLIPATH="$SCRIPT_ROOT/Tools/dotnetcli"
SDKPATH="$CLIPATH/sdk/$SDK_VERSION"

set -x

$CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj /bl:build.binlog /flp:v=diag /clp:v=m "$@"

