#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

usage() {
    echo "usage: $0 <path-to-tarball-root> [--skip-build] [--enable-leak-detection] [-- [extra build.sh args]]"
    echo ""
}

if [ -z "${1:-}" ]; then
    usage
    exit 1
fi

TARBALL_ROOT=$1
shift

SKIP_BUILD=0
INCLUDE_LEAK_DETECTION=0
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

while :; do
    if [ $# -le 0 ]; then
        break
    fi

    lowerI="$(echo $1 | awk '{print tolower($0)}')"
    case $lowerI in
        --skip-build)
            SKIP_BUILD=1
            ;;
        --enable-leak-detection)
            INCLUDE_LEAK_DETECTION=1
            ;;
        --)
            shift
            echo "Detected '--': passing remaining parameters '$@' as build.sh arguments."
            break
            ;;
        -?|-h|--help)
            usage
            exit 0
            ;;
        *)
            echo "Unrecognized argument '$1'"
            usage
            exit 1
            ;;
    esac

    shift
done

export FULL_TARBALL_ROOT=$(readlink -f $TARBALL_ROOT)

if [ -e "$TARBALL_ROOT" ]; then
    echo "info: '$TARBALL_ROOT' already exists"
fi

export SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
sdkLine=`grep -m 1 'dotnet' "$SCRIPT_ROOT/global.json"`
sdkPattern="\"dotnet\" *: *\"(.*)\""
if [[ $sdkLine =~ $sdkPattern ]]; then
  export SDK_VERSION=${BASH_REMATCH[1]}
fi
echo "Found bootstrap SDK $SDK_VERSION"
CLI_PATH="$SCRIPT_ROOT/.dotnet"
DARC_DLL="$SCRIPT_ROOT/tools-local/arcade-services/artifacts/bin/Microsoft.DotNet.Darc/Release/netcoreapp3.0/Microsoft.DotNet.Darc.dll"

if [ $SKIP_BUILD -ne 1 ]; then

    if [ -e "$SCRIPT_ROOT/bin" ]; then
        rm -rf "$SCRIPT_ROOT/bin"
    fi

    $SCRIPT_ROOT/clean.sh
    $SCRIPT_ROOT/build.sh /p:ArchiveDownloadedPackages=true "$@"
fi

mkdir -p "$TARBALL_ROOT"

echo 'Copying sources to tarball...'

# Use Git to put sources in the tarball. This ensure it's fresh, without having to clean and reset
# the working dir. This helps preserve diagnostic information if the tarball build doesn't work.

# Checkout non-submodule sources into tarball.
git --work-tree="$TARBALL_ROOT" checkout HEAD -- src
# Checkout submodule sources into tarball.
git submodule foreach --quiet --recursive '
    SCRIPT_SUBMODULE_PATH="$toplevel/$path"
    TARBALL_SUBMODULE_PATH="$FULL_TARBALL_ROOT/${SCRIPT_SUBMODULE_PATH#$SCRIPT_ROOT/}"
    mkdir -p "$TARBALL_SUBMODULE_PATH"
    echo "Checking out $(pwd) => $TARBALL_SUBMODULE_PATH ..."
    if [ "$(ls -A)" = ".git" ]; then
        # Checkout fails for an empty tree. (E.g. nuget-client submodule NuGet.Build.Localization.)
        echo "  Nothing to check out from $TARBALL_SUBMODULE_PATH"
    else
        git --work-tree="$TARBALL_SUBMODULE_PATH" checkout -- .
    fi'

# Now re-uberclone into the tarball src directory.  Since we reuse the .gitdirs, this shouldn't hit the network at all.
ignored_repos="https://dev.azure.com/dnceng/internal/_git/dotnet-optimization;https://dev.azure.com/devdiv/DevDiv/_git/DotNet-Trusted;https://devdiv.visualstudio.com/DevDiv/_git/DotNet-Trusted;https://dnceng@dev.azure.com/dnceng/internal/_git/dotnet-optimization;https://dev.azure.com/dnceng/internal/_git/dotnet-core-setup"
"$CLI_PATH/dotnet" "$DARC_DLL" clone --repos-folder=$TARBALL_ROOT/src/ --git-dir-folder $SCRIPT_ROOT/.git/modules/src/ --include-toolset --ignore-repos "$ignored_repos" --azdev-pat bogus --github-pat bogus --depth 0 --debug
# then delete the master copies - we only need the specific hashes
pushd "$TARBALL_ROOT/src"
find "$PWD" -maxdepth 1 -type d | grep -v reference-assemblies | grep -v netcorecli-fsc | grep -v package-source-build | grep -v "$PWD\$" | egrep -v '\.[A-Fa-f0-9]{40}' | xargs rm -rf
popd

echo 'Removing binaries from tarball src...'
find $TARBALL_ROOT/src \( -type f \( \
    -iname *.dll -o \
    -iname *.exe -o \
    -iname *.pdb -o \
    -iname *.mdb -o \
    -iname *.zip -o \
    -iname *.nupkg \) \) -exec rm {} \;

echo 'Copying sourcelink metadata to tarball...'
pushd $SCRIPT_ROOT
for srcDir in `find bin/src -name '.git' -type d`; do
  newPath=`echo $srcDir | sed 's/^bin\///' | sed 's/\.git$//'`
  cp -r $srcDir $TARBALL_ROOT/$newPath
done
popd

echo 'Copying scripts and tools to tarball...'

cp $SCRIPT_ROOT/*.proj $TARBALL_ROOT/
cp $SCRIPT_ROOT/*.props $TARBALL_ROOT/
cp $SCRIPT_ROOT/*.targets $TARBALL_ROOT/
cp $SCRIPT_ROOT/global.json $TARBALL_ROOT/
cp $SCRIPT_ROOT/ProdConFeed.txt $TARBALL_ROOT/
cp $SCRIPT_ROOT/smoke-test* $TARBALL_ROOT/
cp -r $CLI_PATH $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/eng $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/keys $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/patches $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/scripts $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/repos $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/tools-local $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/bin/git-info $TARBALL_ROOT/

cp $SCRIPT_ROOT/support/tarball/build.sh $TARBALL_ROOT/build.sh

mkdir -p $TARBALL_ROOT/packages/prebuilt
mkdir -p $TARBALL_ROOT/packages/source-built
find $SCRIPT_ROOT/packages -name '*.nupkg' -exec cp {} $TARBALL_ROOT/packages/prebuilt/ \;
find $SCRIPT_ROOT/bin/obj/x64/Release/nuget-packages -name '*.nupkg' -exec cp {} $TARBALL_ROOT/packages/prebuilt/ \;

# Copy reference-packages from bin dir to reference-packages directory.
# See corresponding change in dir.props to change ReferencePackagesBasePath conditionally in offline build.
mkdir -p $TARBALL_ROOT/packages/reference
cp -r $SCRIPT_ROOT/bin/obj/x64/Release/reference-packages/source $TARBALL_ROOT/packages/reference/source
cp -r $SCRIPT_ROOT/bin/obj/x64/Release/reference-packages/staging $TARBALL_ROOT/packages/reference/staging

# Copy tarballs to ./packages/archive directory
mkdir -p $TARBALL_ROOT/packages/archive
cp -r $SCRIPT_ROOT/bin/obj/x64/Release/external-tarballs/*.tar.gz $TARBALL_ROOT/packages/archive/

# Copy generated source from bin to src/generatedSrc
cp -r $SCRIPT_ROOT/bin/obj/x64/Release/generatedSrc $TARBALL_ROOT/src/generatedSrc

if [ -e $SCRIPT_ROOT/testing-smoke/smoke-test-packages ]; then
    cp -rf $SCRIPT_ROOT/testing-smoke/smoke-test-packages $TARBALL_ROOT/prebuilt
fi

echo 'Removing source-built packages from tarball prebuilts...'

for built_package in $(find $SCRIPT_ROOT/bin/obj/x64/Release/blob-feed/packages/ -name '*.nupkg' | tr '[:upper:]' '[:lower:]')
do
    if [ -e $TARBALL_ROOT/packages/prebuilt/$(basename $built_package) ]; then
        rm $TARBALL_ROOT/packages/prebuilt/$(basename $built_package)
    fi
    if [ -e $TARBALL_ROOT/prebuilt/smoke-test-packages/$(basename $built_package) ]; then
        rm $TARBALL_ROOT/prebuilt/smoke-test-packages/$(basename $built_package)
    fi
done

echo 'Copying source-built packages to tarball to replace packages needed before they are built...'
mkdir -p $TARBALL_ROOT/packages/source-built
cp -r $SCRIPT_ROOT/Tools/source-built/coreclr-tools $TARBALL_ROOT/packages/source-built/

# Setup package version props to include both source-built and running PackageVersions.props
mkdir --parents $TARBALL_ROOT/bin/obj/x64/Release/
cp $SCRIPT_ROOT/support/tarball/PackageVersions.props $TARBALL_ROOT/bin/obj/x64/Release/

if [ $INCLUDE_LEAK_DETECTION -eq 1 ]; then
  echo 'Building leak detection MSBuild tasks...'
  "$CLI_PATH/dotnet" restore $SCRIPT_ROOT/tools-local/tasks/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection.csproj --source $FULL_TARBALL_ROOT/prebuilt/source-built --source $FULL_TARBALL_ROOT/prebuilt/nuget-packages
  "$CLI_PATH/dotnet" publish -o $FULL_TARBALL_ROOT/tools-local/tasks/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection $SCRIPT_ROOT/tools-local/tasks/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection.csproj
fi

echo 'Removing reference-only packages from tarball prebuilts...'

for ref_package in $(find $SCRIPT_ROOT/bin/obj/x64/Release/reference-packages/packages-to-delete/ -name '*.nupkg' | tr '[:upper:]' '[:lower:]')
do
    if [ -e $TARBALL_ROOT/packages/prebuilt/$(basename $ref_package) ]; then
        rm $TARBALL_ROOT/packages/prebuilt/$(basename $ref_package)
    fi
done

echo 'Removing reference-packages from tarball prebuilts...'

for ref_package in $(tar -tf $TARBALL_ROOT/packages/archive/Private.SourceBuild.ReferencePackages.*.tar.gz | tr '[:upper:]' '[:lower:]')
do
    if [ -e $TARBALL_ROOT/packages/prebuilt/$(basename $ref_package) ]; then
        rm $TARBALL_ROOT/packages/prebuilt/$(basename $ref_package)
    fi
done

echo 'Recording commits for the source-build repo and all submodules, to aid in reproducibility...'

cat >$TARBALL_ROOT/source-build-info.txt << EOF
source-build:
 $(git rev-parse HEAD) . ($(git describe --always HEAD))

submodules:
$(git submodule status --recursive)
EOF

echo "Done. Tarball created: $TARBALL_ROOT"
