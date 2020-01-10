#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

usage() {
    echo "usage: $0 [options]"
    echo "options:"
    echo "  --with-ref-packages <dir>          use the specified directory of available reference packages to determine what prebuilts to delete, instead of downloading the most recent version"
    echo "  --with-packages <dir>              use the specified directory of available previously-built packages to determine what prebuilts to delete, instead of downloading the most recent version"
    echo "use -- to send the remaining arguments to MSBuild"
    echo ""
}

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"

MSBUILD_ARGUMENTS=("/p:OfflineBuild=true" "/flp:v=detailed")
CUSTOM_REF_PACKAGES_DIR=''
CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR=''

while :; do
    if [ $# -le 0 ]; then
        break
    fi

    lowerI="$(echo $1 | awk '{print tolower($0)}')"
    case $lowerI in
        --with-ref-packages)
            CUSTOM_REF_PACKAGES_DIR="$2"
            if [ ! -d "$CUSTOM_REF_PACKAGES_DIR" ]; then
                echo "Custom reference packages directory '$CUSTOM_REF_PACKAGES_DIR' does not exist"
                exit 1
            fi
            shift
            ;;
        --with-packages)
            CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR="$2"
            if [ ! -d "$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR" ]; then
                echo "Custom prviously built packages directory '$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR' does not exist"
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

sdkLine=`grep -m 1 'dotnet' "$SCRIPT_ROOT/global.json"`
sdkPattern="\"dotnet\" *: *\"(.*)\""
if [[ $sdkLine =~ $sdkPattern ]]; then
  export SDK_VERSION=${BASH_REMATCH[1]}
fi

packageVersionsPath=''

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

arcadeSdkLine=`grep -m 1 'MicrosoftDotNetArcadeSdkVersion' "$packageVersionsPath"
versionPattern="<MicrosoftDotNetArcadeSdkVersion>(.*)</MicrosoftDotNetArcadeSdkVersion>"
if [[ $arcadeSdkLine =~ $versionPattern ]]; then
  export ARCADE_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
fi

sourceLinkLine=`grep -m 1 'MicrosoftSourceLinkCommonVersion' "$packageVersionsPath"
versionPattern="<MicrosoftSourceLinkCommonVersion>(.*)</MicrosoftSourceLinkCommonVersion>"
if [[ $sourceLinkLine =~ $versionPattern ]]; then
  export SOURCE_LINK_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
fi

dotNetHostLine=`grep -m 1 'MicrosoftNETCoreDotNetHostVersion' "$packageVersionsPath"
versionPattern="<MicrosoftNETCoreDotNetHostVersion>(.*)</MicrosoftNETCoreDotNetHostVersion>"
if [[ $dotNetHostLine =~ $versionPattern ]]; then
  export DOTNET_HOST_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
fi

echo "Found bootstrap SDK $SDK_VERSION, bootstrap Arcade $ARCADE_BOOTSTRAP_VERSION, bootstrap SourceLink $SOURCE_LINK_BOOTSTRAP_VERSION, bootstrap DotNetHost $DOTNET_HOST_BOOTSTRAP_VERSION"
CLI_ROOT="$SCRIPT_ROOT/.dotnet"

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/restored/"


$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:BuildXPlatTasks.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:BuildXPlatTasks ${MSBUILD_ARGUMENTS[@]} "$@"

echo "Rebuild reference assemblies"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:initBuildReferenceAssemblies.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:BuildReferenceAssemblies ${MSBUILD_ARGUMENTS[@]} "$@"

$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:initWriteDynamicPropsToStaticPropsFiles.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true ${MSBUILD_ARGUMENTS[@]} "$@"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:build.binlog $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@"
