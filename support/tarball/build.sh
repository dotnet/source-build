#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
sdkLine=`grep -m 1 'dotnet' "$SCRIPT_ROOT/global.json"`
sdkPattern="\"dotnet\" *: *\"(.*)\""
if [[ $sdkLine =~ $sdkPattern ]]; then
  export SDK_VERSION=${BASH_REMATCH[1]}
fi
echo "Found bootstrap SDK $SDK_VERSION"
CLI_ROOT="$SCRIPT_ROOT/.dotnet"

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/restored/"

MSBUILD_ARGUMENTS=("/p:OfflineBuild=true" "/flp:v=detailed")

$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:BuildXPlatTasks.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:BuildXPlatTasks ${MSBUILD_ARGUMENTS[@]} "$@"

echo "Rebuild reference assemblies"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:initBuildReferenceAssemblies.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:BuildReferenceAssemblies ${MSBUILD_ARGUMENTS[@]} "$@"

$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:initWriteDynamicPropsToStaticPropsFiles.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true ${MSBUILD_ARGUMENTS[@]} "$@"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$SDK_VERSION/MSBuild.dll /bl:build.binlog $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@"
