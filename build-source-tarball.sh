#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

if [ -z "${1:-}" ]; then
    echo "usage: $0 <path-to-tarball-root> [--skip-build]"
    exit 1
fi

SKIP_BUILD=0

if [ "${2:-}" == "--skip-build" ]; then
    SKIP_BUILD=1
fi

TARBALL_ROOT=$1

if [ -e "$TARBALL_ROOT" ]; then
    echo "error '$TARBALL_ROOT' exists"
fi

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"

if [ $SKIP_BUILD -ne 1 ]; then

    if [ -e "$SCRIPT_ROOT/bin" ]; then
        rm -rf "$SCRIPT_ROOT/bin"
    fi

    $SCRIPT_ROOT/clean.sh
    $SCRIPT_ROOT/build.sh /p:ArchiveDownloadedPackages=true /flp:v=detailed
fi

$SCRIPT_ROOT/clean.sh

mkdir -p "$TARBALL_ROOT"

mkdir -p $TARBALL_ROOT/Tools
cp -rf $SCRIPT_ROOT/Tools/* $TARBALL_ROOT/Tools/

rm -f $TARBALL_ROOT/Tools/dotnetcli/dotnet.tar

cp -r $SCRIPT_ROOT/build.proj $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/dir.props $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/keys $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/patches $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/repositories.props $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/scripts $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/src $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/targets $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/tasks $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/Tools $TARBALL_ROOT/

find $TARBALL_ROOT/src -maxdepth 2 -name '.git' -exec rm {} \;

rm -rf $TARBALL_ROOT/Tools/dotnetcli/dotnet.tar
rm -rf $TARBALL_ROOT/Tools/dotnetcli/sdk/2.0.0-preview3-006845/nuGetPackagesArchive.lzma
rm -rf $TARBALL_ROOT/Tools/dotnetcli/store
rm -rf $TARBALL_ROOT/Tools/dotnetcli/additionalDeps

cp $SCRIPT_ROOT/support/tarball/build.sh $TARBALL_ROOT/build.sh

mkdir -p $TARBALL_ROOT/prebuilt/nuget-packages
find $SCRIPT_ROOT/bin/obj/x64/Release/nuget-packages -name '*.nupkg' -exec cp {} $TARBALL_ROOT/prebuilt/nuget-packages/ \;

for built_package in $(find $SCRIPT_ROOT/bin/obj/x64/Release/source-built -name '*.nupkg' | tr '[:upper:]' '[:lower:]')
do
    if [ -e $TARBALL_ROOT/prebuilt/nuget-packages/$(basename $built_package) ]; then
        rm $TARBALL_ROOT/prebuilt/nuget-packages/$(basename $built_package)
    fi
done

# Record commits for the source-build repo and all submodules, to aid in reproducibility.
echo -e "path\tchecked-in\tactual" > $TARBALL_ROOT/commits.txt
echo -e "source-build\t$(git rev-parse HEAD)\t$(git rev-parse HEAD)" >> $TARBALL_ROOT/commits.txt
git submodule foreach --recursive 'actual=$(git rev-parse HEAD); echo "$toplevel/$path\t$sha1\t$actual" >> $TARBALL_ROOT/commits.txt'

