#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

usage() {
    echo "usage: $0 [options]"
    echo "options:"
    echo "  -test                          run supported individal repo unit tests"
    echo "  --run-smoke-test               run smoke tests"
    echo "  --publish-prebuilt-report      publish prebuilt report data to Azure Storage"
    echo "  --generate-prebuilt-data       generate prebuilt burndown data"
    echo "  --with-sdk <dir>               use the SDK in the specified directory for bootstrapping"
    echo "extra arguments will be passed to MSBuild"
    echo ""
}

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

if [ -z "${HOME:-}" ]; then
    export HOME="$scriptroot/.home"
    mkdir "$HOME"
fi

# If .git doesn't exist at the repo root, create it. It's required for the build to work. The very
# prominent source tar.gz and zip files created by GitHub don't include it, so it's worth having a
# fallback here. See https://github.com/dotnet/source-build/issues/1646 for details.
if [ ! -e "$scriptroot/.git" ]; then
  (
    cd "$scriptroot"
    git init
  )
fi

if grep -q '\(/docker/\|/docker-\)' "/proc/1/cgroup"; then
    export DotNetRunningInDocker=1
fi

alternateTarget=false
CUSTOM_SDK_DIR=''

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
    (--with-sdk)
            CUSTOM_SDK_DIR="$(cd -P "$1" && pwd)"
            if [ ! -d "$CUSTOM_SDK_DIR" ]; then
                echo "Custom SDK directory '$CUSTOM_SDK_DIR' does not exist"
                exit 1
            fi
            if [ ! -x "$CUSTOM_SDK_DIR/dotnet" ]; then
                echo "Custom SDK '$CUSTOM_SDK_DIR/dotnet' does not exist or is not executable"
                exit 1
            fi
            shift
            ;;
       (*) set -- "$@" "$arg" ;;
  esac
done

arcadeLine=`grep -m 1 'Microsoft\.DotNet\.Arcade\.Sdk' "$scriptroot/global.json"`
sdkLine=`grep -m 1 'dotnet' "$scriptroot/global.json"`
arcadePattern="\"Microsoft\.DotNet\.Arcade\.Sdk\" *: *\"(.*)\""
sdkPattern="\"dotnet\" *: *\"(.*)\""
if [[ $arcadeLine =~ $arcadePattern ]]; then
  export ARCADE_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
fi
if [ -d "$CUSTOM_SDK_DIR" ]; then
  export SDK_VERSION=`"$CUSTOM_SDK_DIR/dotnet" --version`
  echo "Using custom bootstrap SDK from '$CUSTOM_SDK_DIR', version $SDK_VERSION"
  CLIPATH="$CUSTOM_SDK_DIR"
  SDKPATH="$CLIPATH/sdk/$SDK_VERSION"
  export _InitializeDotNetCli="$CLIPATH"
  export CustomDotNetSdkDir="$CLIPATH"
  else
  if [[ $sdkLine =~ $sdkPattern ]]; then
    export SDK_VERSION=${BASH_REMATCH[1]}
    CLIPATH="$scriptroot/.dotnet"
    SDKPATH="$CLIPATH/sdk/$SDK_VERSION"
  fi
fi
echo "Found bootstrap SDK $SDK_VERSION, bootstrap Arcade $ARCADE_BOOTSTRAP_VERSION"

if [ "$alternateTarget" == "false" ] && [[ "${SOURCE_BUILD_SKIP_SUBMODULE_CHECK:-default}" == "default" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "0" || $SOURCE_BUILD_SKIP_SUBMODULE_CHECK == "false" ]]; then
  source "$scriptroot/check-submodules.sh"
fi

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_MULTILEVEL_LOOKUP=0
export NUGET_PACKAGES="$scriptroot/packages/restored/"

if [ "${internalPackageFeedPat:-}" ]; then
  echo "Setting up NuGet credential provider using PAT from env var 'internalPackageFeedPat'..."
  . "$scriptroot/eng/install-nuget-credprovider.sh"
  # TODO: Read these from nuget.config
  # The internal transport isn't added by Darc, though, so it will still need special-casing.
  export VSS_NUGET_EXTERNAL_FEED_ENDPOINTS='{"endpointCredentials": [
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-7e8bbb70/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-535da077/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-tooling-198cc5ec/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-core-setup-4c6b4aa2/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-extensions-60938620/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-templating-241b4771-1/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/public/_packaging/darc-pub-dotnet-templating-f8760d03/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/dotnet3.1-internal-transport/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/internal/_packaging/3-1-13-2-18-21/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/3.1.117-servicing-015334-shipping/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"}
  ]}'
fi

set -x
scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"

if [ "$alternateTarget" == "true" ]; then
  "$CLIPATH/dotnet" $SDKPATH/MSBuild.dll "$scriptroot/build.proj" /bl:source-build-test.binlog /flp:v=diag /clp:v=m "$@"
else
  "$scriptroot/eng/common/build.sh" --restore --build -c Release --warnaserror false /bl:$scriptroot/artifacts/log/Debug/Build_$(date +"%m%d%H%M%S").binlog /flp:v=diag "$@"
fi
