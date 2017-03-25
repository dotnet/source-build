#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

ORIGINALARGS=$#
declare -a ADDITIONALARGS=()
SHAREDFRAMEWORKPATH=""
SUBMODULETOOLRUNTIMEDIR=""
MANAGEDCORECLRPATH="none"
NETCORESDK=""
NETCORESDK11=""
SDKVERSION=""
__BUILD_TOOLS_PATH=""
BUILDTOOLS_DIR=""
BOOTSTRAPUNSUPPORTED="false"
USEBUILTTOOLS="false"
SKIPCORECLR11BUILD="false"
SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

usage()
{
    echo "Build .NET Core product"
    echo "build.sh [options] [additional arguments]"
    echo ""
    echo "Options"
    echo " For bootstrapping"
    echo " -s11|--netcore_sdk_11_path [.NET Core SDK Path]"
    echo " -s20|--netcore_sdk_20_path [.NET Core SDK Path]"
    echo " --skip_coreclr_11_rebuild"
    echo " -f|--shared_framework_path [Shared Framework Path]"
    echo " -m|--managed_coreclr_path [Managed CoreClr Path]"
    echo "Use built CLI / BuildTools"
    echo " -c|--msbuild_cli [MSBuild based CLI Path]"
    echo " -b|--projectjson_buildtools [Project Json based buildtools path]"
    echo " -h|--help"
    echo ""
    echo "For '--netcore_sdk_11_path', released versions of the .NET Core SDK are available from https://www.microsoft.com/net/download/linux"
    echo "For '--netcore_sdk_20_path', a new version of .NET Core SDK is available from https://dotnetcli.blob.core.windows.net/dotnet/Sdk/rel-1.0.0/dotnet-dev-ubuntu-x64.latest.tar.gz"
    echo "For '--shared_framework_path', a new version of the shared framework is available from https://dotnetcli.blob.core.windows.net/dotnet/master/Binaries/Latest/dotnet-ubuntu-x64.latest.tar.gz"
    echo "For '--managed_coreclr_path', we require mscorlib.dll and System.Private.CoreLib.dll matching the coreclr native binaries.  You can produce these by building coreclr with 'linuxbuild' on Windows."
}

unsupported_arg_check()
{
  ARGERROR="false"

  if [[ "$SHAREDFRAMEWORKPATH" == "" ]]; then
    echo "Error: Missing required parameter '--shared_framework_path'"
    ARGERROR="true"
  fi
  if [[ "$MANAGEDCORECLRPATH" == "" ]]; then
    echo "Error: Missing required parameter '--managed_coreclr_path'"
    ARGERROR="true"
  fi
  if [[ "$NETCORESDK" == "" ]]; then
    echo "Error: Missing required parameter '--netcore_sdk_20_path'"
    ARGERROR="true"
  fi
    if [[ "$NETCORESDK11" == "" ]]; then
      echo "Error: Missing required parameter '--netcore_sdk_11_path'"
      ARGERROR="true"
    fi
    if [[ ! -d "$NETCORESDK11" ]]; then
      echo "--netcore_sdk_11_path option specified, but cannot find directory '$NETCORESDK11'"
      ARGERROR="true"
    fi
  if [[ ! -d "$NETCORESDK" ]]; then
    echo "--netcore_sdk_20_path option specified, but cannot find directory '$NETCORESDK'"
    ARGERROR="true"
  fi
  if [[ ! -d "$SHAREDFRAMEWORKPATH" ]]; then
    echo "--shared_framework_path option specified, but cannot find directory '$SHAREDFRAMEWORKPATH'"
    ARGERROR="true"
  fi

  if [[ "$ARGERROR" == "true" ]]; then
    usage
    exit 1
  fi
}

while [[ $# -gt 0 ]]
  do
    key="$1"
    case $key in
      -s11|--netcore_sdk_11_path)
      NETCORESDK11="$2"
      BOOTSTRAPUNSUPPORTED="true"
      shift 2
      ;;
      -s20|--netcore_sdk_20_path)
      NETCORESDK="$2"
      BOOTSTRAPUNSUPPORTED="true"
      shift 2
      ;;
      -f|--shared_framework_path)
      SHAREDFRAMEWORKPATH="$2"
      BOOTSTRAPUNSUPPORTED="true"
      shift 2
      ;;
      --skip_coreclr_11_rebuild)
      SKIPCORECLR11BUILD="true"
      shift 1
      ;;
      -c|--msbuild_cli)
      CLIPATH="$2"
      USEBUILTTOOLS="true"
      shift 2
      ;;
      -b|--projectjson_buildtools)
      SUBMODULETOOLRUNTIMEDIR="$2"
      USEBUILTTOOLS="true"
      shift 2
      ;;
      -m|--managed_coreclr_path)
      MANAGEDCORECLRPATH="$2"
      shift 2
      ;;
      -h|--help)
      usage
      exit 0
      ;;
      *)
      if [[ ${#ADDITIONALARGS[@]} -gt 0 ]]; then
        ADDITIONALARGS=(${ADDITIONALARGS[@]} $key)
      else
        ADDITIONALARGS=($key)
      fi
      shift
    esac
done

if [[ "$BOOTSTRAPUNSUPPORTED" == "true" ]]; then
  unsupported_arg_check
fi

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
  BOOTSTRAPARGS=""

  # Produce a version of the cli to work on an unsupported OS
  if [[ "$BOOTSTRAPUNSUPPORTED" == "true" ]]; then

    CLI11PATH=$NETCORESDK11.patch
    SUBMODULETOOLRUNTIMEDIR=$SCRIPT_ROOT/tools_for_submodules
    if [[ "$SKIPCORECLR11BUILD" == "false" ]]; then
      # CLI 11 is currently required for repo builds
      echo "Bootstrapping 1.1 CLI to $CLI11PATH..."
      $SCRIPT_ROOT/bootstrap/bootstrap-unsupported.sh -s $NETCORESDK11 -f $SHAREDFRAMEWORKPATH -x $SCRIPT_ROOT/src/corefx -r $SCRIPT_ROOT/src/coreclr -o $CLI11PATH -m $MANAGEDCORECLRPATH

      echo "Creating BuildTools for submodules at $SUBMODULETOOLRUNTIMEDIR..."
      # Create buildtools for project.json based CLI submodules
      echo "DOTNET_TOOL_DIR=$CLI11PATH __TOOLRUNTIME_DIR=$SUBMODULETOOLRUNTIMEDIR __PUBLISH_RID=ubuntu.14.04-x64 $SCRIPT_ROOT/bootstrap/init-tools.sh"
      DOTNET_TOOL_DIR=$CLI11PATH __TOOLRUNTIME_DIR=$SUBMODULETOOLRUNTIMEDIR __PUBLISH_RID=ubuntu.14.04-x64 $SCRIPT_ROOT/bootstrap/init-tools.sh
      # Overlay shared framework into buildtools
      cp -f $SHAREDFRAMEWORKPATH/shared/Microsoft.NETCore.App/*/*.so $SUBMODULETOOLRUNTIMEDIR

      # Save restore CodeAnalysis assemblies from tool-runtime restore so
      # we don't overwrite them with the shared framework copies'

      if [[ ! -d "$SUBMODULETOOLRUNTIMEDIR/tmp" ]]; then
        mkdir $SUBMODULETOOLRUNTIMEDIR/tmp
      fi
      cp -f $SUBMODULETOOLRUNTIMEDIR/Microsoft.CodeAnalysis*.dll $SUBMODULETOOLRUNTIMEDIR/tmp
      cp -f $SHAREDFRAMEWORKPATH/shared/Microsoft.NETCore.App/*/*.dll $SUBMODULETOOLRUNTIMEDIR
      cp -f $SUBMODULETOOLRUNTIMEDIR/tmp/* $SUBMODULETOOLRUNTIMEDIR

      # Include any necessary overrides
      if [[ -d "$SCRIPT_ROOT/bootstrap/Tools-Override" ]]; then
        cp -f $SCRIPT_ROOT/bootstrap/Tools-Override/* $SUBMODULETOOLRUNTIMEDIR
      fi
      # Carry along BuildToolsVersion.txt
      cp -f $SCRIPT_ROOT/bootstrap/BuildToolsVersion.txt $SUBMODULETOOLRUNTIMEDIR 
    fi

    CLIPATH=$NETCORESDK.patch
    echo "Bootstrapping 2.0 CLI to $CLIPATH..."
    $SCRIPT_ROOT/bootstrap/bootstrap-unsupported.sh -s $NETCORESDK -f $SHAREDFRAMEWORKPATH -x $SCRIPT_ROOT/src/corefx -r $SCRIPT_ROOT/src/coreclr -o $CLIPATH -m $MANAGEDCORECLRPATH
    
    determine_sdk_version
    _BOOTSTRAPARGS=("--repositoryRoot" "$SCRIPT_ROOT" "--useLocalCli" "$CLIPATH" "--verbose")
    BOOTSTRAPARGS="${_BOOTSTRAPARGS[*]}"
  else
    CLIPATH="$SCRIPT_ROOT/Tools/dotnetcli"
    SDKVERSION="$(cat $SCRIPT_ROOT/.cliversion)"

    # bootstrapping the cli will try to remove the tools directory if present, and it uses the 'find'
    # command, which is not supported on all Linux distros.  Prevent that code path by removing tools first
    if [ -d $SCRIPT_ROOT/Tools ]; then
      rm -dfr $SCRIPT_ROOT/Tools
    fi
    # bootstrap the CLI
    echo $SCRIPT_ROOT/bootstrap/bootstrap.sh $BOOTSTRAPARGS
    $SCRIPT_ROOT/bootstrap/bootstrap.sh $BOOTSTRAPARGS
  fi

  SDKPATH="$CLIPATH/sdk/$SDKVERSION"

  if [[ ! -d $SDKPATH ]]; then
    echo "Error: Unable to find CLI sdk at '$SDKPATH'."
    exit 1
  fi
}

# Parse command-line arguments
# parse_args

# Create a fake HOME if none is set
if [ -z "${HOME:-}" ]; then
    mkdir -p $SCRIPT_ROOT/bin/obj/home
    export HOME=$SCRIPT_ROOT/bin/obj/home
fi

# Bootstrap supported or unsupported OS
if [[ "$USEBUILTTOOLS" == "false" ]]; then
  bootstrap
fi

if [[ -d "$CLIPATH" ]] && [[ -d "$SUBMODULETOOLRUNTIMEDIR" ]]; then
  echo "Using prebuilt MSBuild CLI and BuildTools."
  if [[ ${#ADDITIONALARGS[@]} -gt 0 ]]; then
    ADDITIONALARGS=(${ADDITIONALARGS[@]} "/p:BootstrapBuildToolsDir=$SUBMODULETOOLRUNTIMEDIR")
  else
    ADDITIONALARGS=("/p:BootstrapBuildToolsDir=$SUBMODULETOOLRUNTIMEDIR")
  fi
  ADDITIONALARGS=(${ADDITIONALARGS[@]} "/p:BootstrapMsbuildCliDir=$CLIPATH")
fi

NETCORESDK=$CLIPATH
determine_sdk_version
SDKPATH="$CLIPATH/sdk/$SDKVERSION"

echo "SDKPATH: $SDKPATH"

# Main build loop
echo "$CLIPATH/dotnet restore tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj"
set -x ; $CLIPATH/dotnet restore tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj

echo "$CLIPATH/dotnet build tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj"
set -x ; $CLIPATH/dotnet build tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj

if [[ ${#ADDITIONALARGS[@]} -gt 0 ]]; then
  echo "$CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj ${ADDITIONALARGS[@]}"
  set -x ; $CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj ${ADDITIONALARGS[@]} /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true
  set -x ; $CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj ${ADDITIONALARGS[@]}
else
  echo "$CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj"
  set -x ; $CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true
  set -x ; $CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj
fi

if [[ "$BOOTSTRAPUNSUPPORTED" == "true" ]]; then
  echo "Patch CLI with built binaries"
  #$SCRIPT_ROOT/buildscripts/patchpayload.sh --verbose --netcore_sdk_path "$NETCORESDK" --coreclr_repo_path $SCRIPT_ROOT/src/coreclr --corefx_repo_path $SCRIPT_ROOT/src/corefx --coresetup_repo_path $SCRIPT_ROOT/src/core-setup
fi
exit 0
