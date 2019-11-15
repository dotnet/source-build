#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
sdkLine=`grep -m 1 'dotnet' "$SCRIPT_ROOT/global.json"`
sdkPattern="\"dotnet\" *: *\"(.*)\""
if [[ $sdkLine =~ $sdkPattern ]]; then
  export SDK_VERSION=${BASH_REMATCH[1]}
fi

sourceBuiltArchive=`find $SCRIPT_ROOT/packages/archive -maxdepth 1 -name 'Private.SourceBuilt.Artifacts*.tar.gz'`
if [ -f "$sourceBuiltArchive" ]; then
  tar -xzf "$sourceBuiltArchive" -C /tmp PackageVersions.props
  arcadeSdkLine=`grep -m 1 'MicrosoftDotNetArcadeSdkVersion' /tmp/PackageVersions.props`
  versionPattern="<MicrosoftDotNetArcadeSdkVersion>(.*)</MicrosoftDotNetArcadeSdkVersion>"
  if [[ $arcadeSdkLine =~ $versionPattern ]]; then
    export ARCADE_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
  fi

  sourceLinkLine=`grep -m 1 'MicrosoftSourceLinkCommonVersion' /tmp/PackageVersions.props`
  versionPattern="<MicrosoftSourceLinkCommonVersion>(.*)</MicrosoftSourceLinkCommonVersion>"
  if [[ $sourceLinkLine =~ $versionPattern ]]; then
    export SOURCE_LINK_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
  fi

  dotNetHostLine=`grep -m 1 'MicrosoftNETCoreDotNetHostVersion' /tmp/PackageVersions.props`
  versionPattern="<MicrosoftNETCoreDotNetHostVersion>(.*)</MicrosoftNETCoreDotNetHostVersion>"
  if [[ $dotNetHostLine =~ $versionPattern ]]; then
    export DOTNET_HOST_BOOTSTRAP_VERSION=${BASH_REMATCH[1]}
  fi
fi
echo "Found bootstrap SDK $SDK_VERSION, bootstrap Arcade $ARCADE_BOOTSTRAP_VERSION, bootstrap SourceLink $SOURCE_LINK_BOOTSTRAP_VERSION, bootstrap DotNetHost $DOTNET_HOST_BOOTSTRAP_VERSION"
CLI_ROOT="$SCRIPT_ROOT/.dotnet"

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/restored/"

MSBUILD_ARGUMENTS=("/p:OfflineBuild=true" "/flp:v=detailed")

echo "Rebuild reference assemblies"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:initBuildReferenceAssemblies.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:BuildReferenceAssemblies ${MSBUILD_ARGUMENTS[@]} "$@"

$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:initWriteDynamicPropsToStaticPropsFiles.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true ${MSBUILD_ARGUMENTS[@]} "$@"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:build.binlog $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@"
