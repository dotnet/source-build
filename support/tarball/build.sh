#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

MSBUILD_ARGUMENTS=("/p:OfflineBuild=true" "/flp:v=detailed" "/clp:v=detailed")

$SCRIPT_ROOT/Tools/dotnetcli/dotnet $SCRIPT_ROOT/Tools/dotnetcli/sdk/2.0.0-preview1-005977/MSBuild.dll $SCRIPT_ROOT/build.proj /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true ${MSBUILD_ARGUMENTS[@]} "$@"
$SCRIPT_ROOT/Tools/dotnetcli/dotnet $SCRIPT_ROOT/Tools/dotnetcli/sdk/2.0.0-preview1-005977/MSBuild.dll $SCRIPT_ROOT/build.proj ${MSBUILD_ARGUMENTS[@]} "$@"
