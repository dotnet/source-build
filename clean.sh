#!/usr/bin/env bash
set -e

git submodule foreach --recursive git clean -xdf
git submodule foreach --recursive git reset --hard

if [ "$*" == "-a" ]
then
    echo "Removing all untracked files in the working tree"
    git clean -xdf
    exit $?
fi

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"

if [ -e "$SCRIPT_ROOT/Tools/dotnetcli/dotnet" ]; then
    export DOTNET_CLI_TELEMETRY_OPTOUT=1
    export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
    export DOTNET_MULTILEVEL_LOOKUP=0
    "$SCRIPT_ROOT/Tools/dotnetcli/dotnet" msbuild "$SCRIPT_ROOT/build.proj" -t:Clean
    exit $?
fi