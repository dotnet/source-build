#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

usage() {
    echo "usage: $0 [options]"
    echo "options:"
    echo "  --with-ref-packages <dir>          use the specified directory of reference packages"
    echo "  --with-packages <dir>              use the specified directory of previously-built packages"
    echo "  --with-sdk <dir>                   use the SDK in the specified directory for bootstrapping"
    echo "use -- to send the remaining arguments to MSBuild"
    echo ""
}

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"

MSBUILD_ARGUMENTS=("/p:OfflineBuild=true" "/flp:v=detailed")
CUSTOM_REF_PACKAGES_DIR=''
CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR=''
CUSTOM_SDK_DIR=''

while :; do
    if [ $# -le 0 ]; then
        break
    fi

    lowerI="$(echo $1 | awk '{print tolower($0)}')"
    case $lowerI in
        --with-ref-packages)
            CUSTOM_REF_PACKAGES_DIR="$(cd -P "$2" && pwd)"
            if [ ! -d "$CUSTOM_REF_PACKAGES_DIR" ]; then
                echo "Custom reference packages directory '$CUSTOM_REF_PACKAGES_DIR' does not exist"
                exit 1
            fi
            MSBUILD_ARGUMENTS+=( "/p:CustomReferencePackagesPath=$CUSTOM_REF_PACKAGES_DIR" )
            shift
            ;;
        --with-packages)
            CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR="$(cd -P "$2" && pwd)"
            if [ ! -d "$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR" ]; then
                echo "Custom prviously built packages directory '$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR' does not exist"
                exit 1
            fi
            MSBUILD_ARGUMENTS+=( "/p:CustomPrebuiltSourceBuiltPackagesPath=$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR" )
            shift
            ;;
        --with-sdk)
            CUSTOM_SDK_DIR="$(cd -P "$2" && pwd)"
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
        --)
            shift
            echo "Detected '--': passing remaining parameters '$@' as build.sh arguments."
            break
            ;;
        -?|-h|--help)
            usage
            exit 0
            ;;
        *)
            echo "Unrecognized argument '$1'"
            usage
            exit 1
            ;;
    esac
    shift
done

if [ -d "$CUSTOM_SDK_DIR" ]; then
  export SDK_VERSION=`"$CUSTOM_SDK_DIR/dotnet" --version`
  export CLI_ROOT="$CUSTOM_SDK_DIR"
  export _InitializeDotNetCli="$CLI_ROOT/dotnet"
  export CustomDotNetSdkDir="$CLI_ROOT"
  echo "Using custom bootstrap SDK from '$CLI_ROOT', version '$SDK_VERSION'"
else
  sdkLine=`grep -m 1 'dotnet' "$SCRIPT_ROOT/global.json"`
  sdkPattern="\"dotnet\" *: *\"(.*)\""
  if [[ $sdkLine =~ $sdkPattern ]]; then
    export SDK_VERSION=${BASH_REMATCH[1]}
    export CLI_ROOT="$SCRIPT_ROOT/.dotnet"
  fi
fi

packageVersionsPath=''
restoredPackagesDir="$SCRIPT_ROOT/packages/restored"

if [ -d "$SCRIPT_ROOT/packages/archive" ]; then
  sourceBuiltArchive=`find $SCRIPT_ROOT/packages/archive -maxdepth 1 -name 'Private.SourceBuilt.Artifacts*.tar.gz'`
  if [ -f "$sourceBuiltArchive" ]; then
    tar -xzf "$sourceBuiltArchive" -C /tmp PackageVersions.props
    packageVersionsPath=/tmp/PackageVersions.props
  fi
else
  if [ -f "$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR/PackageVersions.props" ]; then
    packageVersionsPath="$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR/PackageVersions.props"
  fi
fi

if [ ! -f "$packageVersionsPath" ]; then
  echo "Cannot find PackagesVersions.props.  Debugging info:"
  echo "  Attempted archive path: $SCRIPT_ROOT/packages/archive"
  echo "  Attempted custom PVP path: $CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR/PackageVersions.props"
  exit 1
fi

arcadeSdkLine=`grep -m 1 'MicrosoftDotNetArcadeSdkVersion' "$packageVersionsPath"`
versionPattern="<MicrosoftDotNetArcadeSdkVersion>(.*)</MicrosoftDotNetArcadeSdkVersion>"
if [[ $arcadeSdkLine =~ $versionPattern ]]; then
  export ARCADE_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}

  # Ensure that by default, the bootstrap version of the Arcade SDK is used. Source-build infra
  # projects use bootstrap Arcade SDK, and would fail to find it in the tarball build. The repo
  # projects overwrite this so that they use the source-built Arcade SDK instad.
  export SOURCE_BUILT_SDK_ID_ARCADE=Microsoft.DotNet.Arcade.Sdk
  export SOURCE_BUILT_SDK_VERSION_ARCADE=$ARCADE_BOOTSTRAP_VERSION
  export SOURCE_BUILT_SDK_DIR_ARCADE=$restoredPackagesDir/ArcadeBootstrapPackage/microsoft.dotnet.arcade.sdk/$ARCADE_BOOTSTRAP_VERSION
fi

sourceLinkLine=`grep -m 1 'MicrosoftSourceLinkCommonVersion' "$packageVersionsPath"`
versionPattern="<MicrosoftSourceLinkCommonVersion>(.*)</MicrosoftSourceLinkCommonVersion>"
if [[ $sourceLinkLine =~ $versionPattern ]]; then
  export SOURCE_LINK_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
fi

dotNetHostLine=`grep -m 1 'MicrosoftNETCoreDotNetHostVersion' "$packageVersionsPath"`
versionPattern="<MicrosoftNETCoreDotNetHostVersion>(.*)</MicrosoftNETCoreDotNetHostVersion>"
if [[ $dotNetHostLine =~ $versionPattern ]]; then
  export DOTNET_HOST_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
fi

echo "Found bootstrap SDK $SDK_VERSION, bootstrap Arcade $ARCADE_BOOTSTRAP_VERSION, bootstrap SourceLink $SOURCE_LINK_BOOTSTRAP_VERSION, bootstrap DotNetHost $DOTNET_HOST_BOOTSTRAP_VERSION"

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export NUGET_PACKAGES=$restoredPackagesDir/

LogDateStamp=$(date +"%m%d%H%M%S")
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:BuildXPlatTasks_$LogDateStamp.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:PrepareOfflineLocalTools ${MSBUILD_ARGUMENTS[@]} "$@"

echo "Rebuild reference assemblies"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:initBuildReferenceAssemblies_$LogDateStamp.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:BuildReferenceAssemblies ${MSBUILD_ARGUMENTS[@]} "$@"

$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:initWriteDynamicPropsToStaticPropsFiles_$LogDateStamp.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true ${MSBUILD_ARGUMENTS[@]} "$@"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:Build_$LogDateStamp.binlog $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@"
