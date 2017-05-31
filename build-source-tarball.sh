#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

if [ -z "${1:-}" ]; then
    echo "usage: $0 <path-to-tarball-root>"
    exit 1
fi

TARBALL_ROOT=$1

if [ -e "$TARBALL_ROOT" ]; then
    echo "error '$TARBALL_ROOT' exists"
fi

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"

if [ -e "$SCRIPT_ROOT/bin" ]; then
    rm -rf "$SCRIPT_ROOT/bin"
fi

$SCRIPT_ROOT/clean-submodules.sh

$SCRIPT_ROOT/build.sh /p:ArchiveDownloadedPackages=true /flp:v=detailed

mkdir -p "$TARBALL_ROOT"

# Hack, copy BuildTools from CoreFX before blowing everything away.
mkdir -p $TARBALL_ROOT/prebuilt/toolset/buildtools
cp -rf $SCRIPT_ROOT/src/corefx/Tools/* $TARBALL_ROOT/prebuilt/toolset/buildtools/

$SCRIPT_ROOT/clean-submodules.sh

cp -r $SCRIPT_ROOT/build.proj $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/dir.props $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/keys $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/packages $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/patches $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/repositories.props $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/scripts $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/src $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/targets $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/tasks $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/Tools $TARBALL_ROOT/

mkdir -p $TARBALL_ROOT/prebuilt/nuget-packages

find $SCRIPT_ROOT/bin/obj/x64/Release/nuget-packages -name '*.nupkg' -exec cp {} $TARBALL_ROOT/prebuilt/nuget-packages/ \;
find $TARBALL_ROOT/src -maxdepth 2 -name '.git' -exec rm {} \;
