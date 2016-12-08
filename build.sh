#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

./bootstrap/bootstrap.sh
./Tools/dotnetcli/dotnet restore tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj
./Tools/dotnetcli/dotnet build tasks/Microsoft.DotNet.SourceBuild.Tasks/Microsoft.DotNet.SourceBuild.Tasks.csproj
./Tools/dotnetcli/dotnet msbuild build.proj "$@"
