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
    "$SCRIPT_ROOT/Tools/dotnetcli/dotnet" msbuild "$SCRIPT_ROOT/build.proj" -t:Clean
    exit $?
fi