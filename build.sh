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
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/public/_packaging/darc-pub-dotnet-roslyn-analyzers-92e6dca2/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/public/_packaging/darc-pub-dotnet-roslyn-analyzers-92e6dca2-2/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/public/_packaging/darc-pub-dotnet-roslyn-analyzers-92e6dca2-1/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-runtime-f431858f/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-runtime-f431858f-2/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-runtime-f431858f-1/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-runtime-5709275b/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-runtime-b3afe992/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/public/_packaging/darc-pub-dotnet-templating-5a6c095d/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/public/_packaging/darc-pub-dotnet-templating-5a6c095d-2/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/public/_packaging/darc-pub-dotnet-templating-5a6c095d-1/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-67acc3d3/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-67acc3d3-1/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-67acc3d3-2/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-ae2eabad/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-c663adee/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-c663adee-1/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-c663adee-2/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-55738ff9/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/internal/_packaging/darc-int-dotnet-aspnetcore-0bc3c376/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/internal/_packaging/darc-int-dotnet-runtime-d5b56c63/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-b92c9f50/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/darc-int-dotnet-aspnetcore-eeb31f66/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/internal/_packaging/dotnet5-internal-transport/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/internal/_packaging/darc-int-dotnet-aspnetcore-88ca061d/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
    {"endpoint":"https://pkgs.dev.azure.com/dnceng/_packaging/5.0.406-servicing.22119.1-shipping/nuget/v3/index.json", "username":"optional", "password":"'$internalPackageFeedPat'"},
  ]}'
fi

set -x
scriptroot="$( cd -P "$( dirname "$source" )" && pwd )"

if [ "$alternateTarget" == "true" ]; then
  "$CLIPATH/dotnet" $SDKPATH/MSBuild.dll "$scriptroot/build.proj" /bl:source-build-test.binlog /flp:v=diag /clp:v=m "$@"
else
  "$scriptroot/eng/common/build.sh" --restore --build -c Release --warnaserror false /bl:$scriptroot/artifacts/log/Debug/Build_$(date +"%m%d%H%M%S").binlog /flp:v=diag "$@"
fi
