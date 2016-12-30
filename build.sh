#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
SDK_VERSION="$(cat $SCRIPT_ROOT/.cliversion)"

./bootstrap/bootstrap.sh
./Tools/dotnetcli/dotnet restore tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj
./Tools/dotnetcli/dotnet build tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj
./Tools/dotnetcli/dotnet ./Tools/dotnetcli/sdk/$SDK_VERSION/MSBuild.dll build.proj "$@"
