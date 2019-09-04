#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
CLI_VERSION=$(cat $SCRIPT_ROOT/DotnetCLIVersion.txt)
CLI_ROOT="$SCRIPT_ROOT/.dotnet"
export SDK_VERSION=$CLI_VERSION

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/"

MSBUILD_ARGUMENTS=("/p:OfflineBuild=true" "/flp:v=detailed")

echo "Rebuild reference assemblies"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll /bl:initBuildReferenceAssemblies.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:BuildReferenceAssemblies ${MSBUILD_ARGUMENTS[@]} "$@"

echo "Expanding BuildTools dependencies into packages directory..."
# init-tools tries to copy from its script directory to Tools, which in this case is a copy to
# itself. This is an error. To avoid the error, use a temp dir that we immediately delete.
PREBUILT_PACKAGE_SOURCE="$SCRIPT_ROOT/prebuilt/nuget-packages"
REF_PACKAGE_SOURCE="$SCRIPT_ROOT/reference-packages/packages"

$CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll /bl:initWriteDynamicPropsToStaticPropsFiles.binlog $SCRIPT_ROOT/tools-local/init-build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true ${MSBUILD_ARGUMENTS[@]} "$@"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll /bl:build.binlog $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@"
