#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

# resolve $SOURCE until the file is no longer a symlink
source="${BASH_SOURCE[0]}"
scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"
while [[ -h $source ]]; do
  scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"
  source="$(readlink "$source")"

  # if $source was a relative symlink, we need to resolve it relative to the path where the
  # symlink file was located
  [[ $source != /* ]] && source="$scriptroot/$source"
done

arcadeLine=`grep -m 1 'Microsoft\.DotNet\.Arcade\.Sdk' "$scriptroot/global.json"`
sdkLine=`grep -m 1 'dotnet' "$scriptroot/global.json"`
arcadePattern="\"Microsoft\.DotNet\.Arcade\.Sdk\" *: *\"(.*)\""
sdkPattern="\"dotnet\" *: *\"(.*)\""
if [[ $arcadeLine =~ $arcadePattern ]]; then
  export ARCADE_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
fi
if [[ $sdkLine =~ $sdkPattern ]]; then
  export SDK_VERSION=${BASH_REMATCH[1]}
fi
echo "Found bootstrap SDK $SDK_VERSION, bootstrap Arcade $ARCADE_BOOTSTRAP_VERSION"

if [ -z "${HOME:-}" ]; then
    export HOME="$scriptroot/.home"
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
    (--generate-prebuilt-data) set -- "$@" "/t:GeneratePrebuiltBurndownData"
            alternateTarget=true
            ;;
       (*) set -- "$@" "$arg" ;;
  esac
done

if [ "$alternateTarget" == "false" ] && [[ "${SOURCE_BUILD_SKIP_SUBMODULE_CHECK:-default}" == "default" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "0" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "false" ]]; then
  source "$scriptroot/check-submodules.sh"
fi

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_MULTILEVEL_LOOKUP=0
export NUGET_PACKAGES="$scriptroot/packages/restored/"

set -x
scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"

# runtime 2.1.0 required for darc
"$scriptroot/eng/common/dotnet-install.sh"  -runtime dotnet -version 2.1.0

if [ "$alternateTarget" == "true" ]; then
  CLIPATH="$scriptroot/.dotnet"
  SDKPATH="$CLIPATH/sdk/$SDK_VERSION"

  "$CLIPATH/dotnet" $SDKPATH/MSBuild.dll "$scriptroot/build.proj" /bl:source-build-test.binlog /flp:v=diag /clp:v=m "$@"
else
  "$scriptroot/eng/common/build.sh" --restore --build -c Release --warnaserror false $@ /p:Projects="$scriptroot/build.proj"
fi
