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

if grep -q '\(/docker/\|/docker-\)' "/proc/1/cgroup"; then
    export DotNetRunningInDocker=1
fi

alternateTarget=false

for arg do
  shift
  opt="$(echo "$arg" | awk '{print tolower($0)}')"
  case $opt in
    (-test) set -- "$@" "/t:RunTests"
            alternateTarget=true
            ;;
    (--run-smoke-test) set -- "$@" "/t:RunSmokeTest"
            alternateTarget=true
            ;;
    (--publish-prebuilt-report) set -- "$@" "/t:PublishPrebuiltReportData"
            alternateTarget=true
            ;;
       (*) set -- "$@" "$arg" ;;
  esac
done

if [ "$alternateTarget" == "false" ] && [[ "${SOURCE_BUILD_SKIP_SUBMODULE_CHECK:-default}" == "default" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "0" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "false" ]]; then
  source "$SCRIPT_ROOT/check-submodules.sh"
fi

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_MULTILEVEL_LOOKUP=0
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/"

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

if [ "$alternateTarget" == "true" ]; then
  CLIPATH="$scriptroot/.dotnet"
  SDKPATH="$CLIPATH/sdk/$SDK_VERSION"

  "$CLIPATH/dotnet" $SDKPATH/MSBuild.dll "$scriptroot/build.proj" /bl:source-build-test.binlog /flp:v=diag /clp:v=m "$@"
else
  "$scriptroot/eng/common/build.sh" --restore --build -c Release --warnaserror false $@ /p:Projects="$scriptroot/build.proj"
fi
