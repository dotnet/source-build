#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
CLI_VERSION==$(cat $SCRIPT_ROOT/DotnetCLIVersion.txt)
CLI_ROOT="$SCRIPT_ROOT/Tools/dotnetcli"

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export NUGET_PACKAGES="$SCRIPT_ROOT/packages/"

MSBUILD_ARGUMENTS=("/p:OfflineBuild=true" "/flp:v=detailed" "/clp:v=detailed")

$CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll $SCRIPT_ROOT/tools-local/init-build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true ${MSBUILD_ARGUMENTS[@]} "$@"
$CLI_ROOT/dotnet $CLI_ROOT/sdk/$CLI_VERSION/MSBuild.dll $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@"
