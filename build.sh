#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

ADDITIONALARGS=()
SHAREDFRAMEWORKPATH=""
NETCORESDK=""
SDKVERSION=""
BOOTSTRAPUNSUPPORTED=false
SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

usage()
{
    echo "Build .NET Core product"
    echo "build.sh [options] [additional arguments]"
    echo ""
    echo "Options"
    echo " -s|--netcore_sdk_path [.NET Core SDK Path]"
    echo " -f|--shared_framework_path [Shared Framework Path]"
    echo " -h|--help"
    echo ""
    echo "A new version of .NET Core SDK is available from https://dotnetcli.blob.core.windows.net/dotnet/Sdk/rel-1.0.0/dotnet-dev-ubuntu-x64.latest.tar.gz"
    echo "A new version of the shared framework is available from https://dotnetcli.blob.core.windows.net/dotnet/master/Binaries/Latest/dotnet-ubuntu-x64.latest.tar.gz"
}

parse_args()
{
  while [[ $# -gt 0 ]]
    do
      key="$1"

      case $key in
        -s|--netcore_sdk_path)
        NETCORESDK="$2"
        shift 2
        ;;
        -f|--shared_framework_path)
        SHAREDFRAMEWORKPATH="$2"
        shift 2
        ;;
        -h|--help)
        usage
        exit 0
        ;;
        *)
        ADDITIONALARGS+=($key)
        shift
      esac
  done

  if [[ ! "$NETCORESDK" == "" ]] && [[ ! -d "$NETCORESDK" ]]; then
    echo "--netcore_sdk_path option specified, but cannot find directory '$NETCORESDK'"
    usage
    exit 1
  fi
  if [[ ! "$SHAREDFRAMEWORKPATH" == "" ]] && [[ ! -d "$SHAREDFRAMEWORKPATH" ]]; then
    echo "--shared_framework_path option specified, but cannot find directory '$SHAREDFRAMEWORKPATH'"
    usage
    exit 1
  fi

  if [[ ! "$NETCORESDK" == "" ]] && [[ "$SHAREDFRAMEWORKPATH" == "" ]]; then
    echo "Error: Missing required parameter '--shared_framework_path'"
    usage
    exit 1
  fi
  if [[ "$NETCORESDK" == "" ]] && [[ ! "$SHAREDFRAMEWORKPATH" == "" ]]; then
    echo "Error: Missing required parameter '--netcore_sdk_path'"
    usage
    exit 1
  fi
  if [[ ! "$NETCORESDK" == ""]] && [[ ! "$SHAREDFRAMEWORKPATH" == "" ]]; then
    BOOTSTRAPUNSUPPORTED=true
  fi
}

determine_sdk_version()
{
  echo "Using specified NETCore SDK from $NETCORESDK"

  # Determine SDK Version from cli payload
  declare -a SDKVERSIONS=()
  SDKVERSIONS=($(ls $NETCORESDK/sdk))
  if [[ "${#SDKVERSIONS[@]}" -gt "1" ]]; then
    echo "Discovered SDK versions:"
    echo "  ${SDKVERSIONS[*]}"
    echo "Error: Multiple sdk versions found.  Only one sdk version is permitted, please remove extra sdks."
    exit 1
  fi
  if [[ "${#SDKVERSIONS[@]}" == "0" ]]; then
    echo "Error: Unable to determine sdk version.  Did you download and extract a '.NET CORE SDK' from https://github.com/dotnet/cli?"
    exit 1
  fi
  SDKVERSION="${SDKVERSIONS[0]}"
}

bootstrap()
{
  # bootstrap the CLI if no local payload is specified
  if [[ "$BOOTSTRAPUNSUPPORTED" == false ]]; then
    SDKVERSION="$(cat $SCRIPT_ROOT/.cliversion)"
    ./bootstrap/bootstrap.sh
    CLIPATH="$SCRIPT_ROOT/Tools/dotnetcli"
  fi

  if [[ "$BOOTSTRAPUNSUPPORTED" == true ]]; then
    CLIPATH=$NETCORESDK.patch
    $SCRIPT_ROOT/bootstrap/bootstrap-unsupported.sh -s $NETCORESDK -f $SHAREDFRAMEWORKPATH -o $CLIPATH
    determine_sdk_version
  fi

  SDKPATH="$CLIPATH/sdk/$SDKVERSION"

  if [[ ! -d $SDKPATH ]]; then
    echo "Error: Unable to find CLI sdk at '$SDKPATH'."
    exit 1
  fi
}

# Parse command-line arguments
parse_args

# Bootstrap supported or unsupported OS
bootstrap
echo "SDKPATH: $SDKPATH"

# Main build loop
echo "$CLIPATH/dotnet restore tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj"
$CLIPATH/dotnet restore tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj

echo "$CLIPATH/dotnet build tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj"
$CLIPATH/dotnet build tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj

echo "$CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj ${ADDITIONALARGS[@]}"
$CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj "${ADDITIONALARGS[@]}"

if [[ "$BOOTSTRAPUNSUPPORTED" == true ]]; then
  echo "Patch CLI with built binaries"
  #$SCRIPT_ROOT/buildscripts/patchpayload.sh --verbose --netcore_sdk_path "$NETCORESDK" --coreclr_repo_path $SCRIPT_ROOT/src/coreclr --corefx_repo_path $SCRIPT_ROOT/src/corefx --coresetup_repo_path $SCRIPT_ROOT/src/core-setup
fi
exit 0
