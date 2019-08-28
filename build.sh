#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
export SDK_VERSION=$(cat $SCRIPT_ROOT/DotnetCLIVersion.txt)
arcadeLine=`grep -m 1 'Microsoft\.DotNet\.Arcade\.Sdk' "$SCRIPT_ROOT/global.json"`
pattern="\"Microsoft\.DotNet\.Arcade\.Sdk\" *: *\"(.*)\""
if [[ $arcadeLine =~ $pattern ]]; then
  export ARCADE_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
fi
echo "Found bootstrap SDK $SDK_VERSION, bootstrap Arcade $ARCADE_BOOTSTRAP_VERSION"

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

CLIPATH="$SCRIPT_ROOT/Tools/dotnetcli"
SDKPATH="$CLIPATH/sdk/$SDK_VERSION"

source="${BASH_SOURCE[0]}"

# resolve $SOURCE until the file is no longer a symlink
while [[ -h $source ]]; do
  scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"
  source="$(readlink "$source")"

  # if $source was a relative symlink, we need to resolve it relative to the path where the
  # symlink file was located
  [[ $source != /* ]] && source="$scriptroot/$source"
done

set -x

scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"
"$scriptroot/eng/common/build.sh" --restore --build -c Release --warnaserror false $@ /p:Projects="$scriptroot/build.proj"
