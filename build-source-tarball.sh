#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

usage() {
    echo "usage: $0 <path-to-tarball-root> [options]"
    echo "options:"
    echo "  --skip-build                       assume we have already built (requires you have built with the /p:ArchiveDownloadedPackages=true flag)"
    echo "  --enable-leak-detection            build leaked-binary detection tasts for later use while building from this tarball"
    echo "  --skip-prebuilt-check              do not confirm that all prebuilt packages used are either reference packages, previously-built, or known extras"
    echo "  --with-ref-packages <dir>          use the specified directory of available reference packages to determine what prebuilts to delete, instead of downloading the most recent version"
    echo "  --with-packages <dir>              use the specified directory of available previously-built packages to determine what prebuilts to delete, instead of downloading the most recent version"
    echo "  --with-sdk <dir>                   use the specified SDK to check out source code.  do not copy it to the tarball.  an external SDK will be required to build from the tarball."
    echo "use -- to send the remaining arguments to build.sh"
}

if [ -z "${1:-}" ]; then
    usage
    exit 1
fi

# Use uname to determine what the CPU is.
cpuname=$(uname -p)
# Some Linux platforms report unknown for platform, but the arch for machine.
if [[ "$cpuname" == "unknown" ]]; then
  cpuname=$(uname -m)
fi

case $cpuname in
  aarch64)
    targetArchitecture=arm64
    ;;
  amd64|x86_64)
    targetArchitecture=x64
    ;;
  armv7l)
    targetArchitecture=arm
    ;;
  i686)
    targetArchitecture=x86
    ;;
  *)
    echo "Unknown CPU $cpuname detected, treating it as x64"
    targetArchitecture=x64
    ;;
esac

TARBALL_ROOT=$1
shift

SKIP_BUILD=0
CUSTOM_SDK_DIR=''
INCLUDE_LEAK_DETECTION=0
MINIMIZE_DISK_USAGE=0
SKIP_PREBUILT_ENFORCEMENT=0
CUSTOM_REF_PACKAGES_DIR=''
CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR=''
MAIN_BUILD_ARGS=("/p:ArchiveDownloadedPackages=true")
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
        --minimize-disk-usage)
            MINIMIZE_DISK_USAGE=1
            ;;
        --skip-prebuilt-check)
            SKIP_PREBUILT_ENFORCEMENT=1
            ;;
        --with-sdk)
            CUSTOM_SDK_DIR="$2"
            if [ ! -d "$CUSTOM_SDK_DIR" ]; then
                echo "Custom SDK directory '$CUSTOM_SDK_DIR' does not exist"
            fi
            if [ ! -x "$CUSTOM_SDK_DIR/dotnet" ]; then
                echo "Custom SDK '$CUSTOM_SDK_DIR/dotnet' not found or not executable"
            fi
            shift
            ;;
        --with-ref-packages)
            CUSTOM_REF_PACKAGES_DIR="$2"
            if [ ! -d "$CUSTOM_REF_PACKAGES_DIR" ]; then
                echo "Custom reference packages directory '$CUSTOM_REF_PACKAGES_DIR' does not exist"
                exit 1
            fi
            MAIN_BUILD_ARGS+=( "/p:SkipDownloadingReferencePackages=true" )
            shift
            ;;
        --with-packages)
            CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR="$2"
            if [ ! -d "$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR" ]; then
                echo "Custom reference packages directory '$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR' does not exist"
                exit 1
            fi
            MAIN_BUILD_ARGS+=( "/p:SkipDownloadingPreviouslySourceBuiltPackages=true" )
            shift
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

if [ $MINIMIZE_DISK_USAGE -eq 1 ]; then
    echo "WARNING"
    echo "WARNING"
    echo "WARNING: --minimize-disk-usage intentionally trashes your local repo and any local work.  It will not be recoverable.  It is intended for CI use only."
    echo "WARNING"
    echo "WARNING"
    echo "WARNING: You have 10 seconds to cancel."
    sleep 10
fi

export FULL_TARBALL_ROOT=$(readlink -f $TARBALL_ROOT)

if [ -e "$TARBALL_ROOT" ]; then
    echo "info: '$TARBALL_ROOT' already exists"
fi

export SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
if [ -d "$CUSTOM_SDK_DIR" ]; then
  export SDK_VERSION=`"$CUSTOM_SDK_DIR/dotnet" --version`
  echo "Using custom bootstrap SDK from '$CUSTOM_SDK_DIR', version $SDK_VERSION"
  CLI_PATH="$CUSTOM_SDK_DIR"
else
  sdkLine=`grep -m 1 'dotnet' "$SCRIPT_ROOT/global.json"`
  sdkPattern="\"dotnet\" *: *\"(.*)\""
  if [[ $sdkLine =~ $sdkPattern ]]; then
    export SDK_VERSION=${BASH_REMATCH[1]}
    CLI_DIR=".dotnet"
    CLI_PATH="$SCRIPT_ROOT/$CLI_DIR"
  fi
  echo "Found bootstrap SDK $SDK_VERSION"
fi
DarcVersion=$(cat $SCRIPT_ROOT/DarcVersion.txt)
DARC_DLL="$CLI_PATH/tools/.store/microsoft.dotnet.darc/$DarcVersion/microsoft.dotnet.darc/$DarcVersion/tools/netcoreapp3.0/any/Microsoft.DotNet.Darc.dll"

if [ $SKIP_BUILD -ne 1 ]; then

    if [ -e "$SCRIPT_ROOT/bin" ]; then
        rm -rf "$SCRIPT_ROOT/bin"
    fi

    $SCRIPT_ROOT/clean.sh
    $SCRIPT_ROOT/build.sh  ${MAIN_BUILD_ARGS[@]} "$@"
fi

mkdir -p "$TARBALL_ROOT"

# We need to keep bin/src/<repo>/.git around for sourcelink metadata but we can delete
# just about everything else, Darc will pull it from the copy in .git/modules.
# This list of extensions is everything over 6MB or so.
if [ $MINIMIZE_DISK_USAGE -eq 1 ]; then
    find $SCRIPT_ROOT/bin/src \( -type f \( \
        -iname '*.dll' -o \
        -iname '*.exe' -o \
        -iname '*.pdb' -o \
        -iname '*.mdb' -o \
        -iname '*.zip' -o \
        -iname '*.so' -o \
        -iname '*.o' -o \
        -iname '*.a' -o \
        -iname '*.tar.gz' -o \
        -iname '*.vb' -o \
        -iname '*.il' -o \
        -iname '*.xlf' -o \
        -iname '*.cpp' -o \
        -iname '*.txt' -o \
        -iname '*.map' -o \
        -iname '*.md' -o \
        -iname '*.fs' -o \
        -iname '*.h' -o \
        -iname '*.c' -o \
        -iname '*.js' -o \
        -iname '*.json' -o \
        -iname '*.ildump' -o \
        -iname '*.resx' -o \
        -iname '*.xml' -o \
        -iname '*.css' -o \
        -iname '*.nupkg' \) \) -exec rm {} \;
fi

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
ignored_repos="https://dev.azure.com/dnceng/internal/_git/dotnet-optimization;https://dev.azure.com/devdiv/DevDiv/_git/DotNet-Trusted;https://devdiv.visualstudio.com/DevDiv/_git/DotNet-Trusted;https://dnceng@dev.azure.com/dnceng/internal/_git/dotnet-optimization;https://dev.azure.com/dnceng/internal/_git/dotnet-core-setup;https://github.com/dotnet/source-build-reference-packages"

"$CLI_PATH/dotnet" "$DARC_DLL" clone --repos-folder=$TARBALL_ROOT/src/ --git-dir-folder $SCRIPT_ROOT/.git/modules/src/ --include-toolset --ignore-repos "$ignored_repos" --azdev-pat bogus --github-pat bogus --depth 0 --debug

# now we don't need .git/modules/src or Darc anymore
if [ $MINIMIZE_DISK_USAGE -eq 1 ]; then
    rm -rf "$SCRIPT_ROOT/.git/modules/src"
fi

# then delete the master copies - we only need the specific hashes
pushd "$TARBALL_ROOT/src"
find "$PWD" -maxdepth 1 -type d | grep -v reference-assemblies | grep -v netcorecli-fsc | grep -v package-source-build | grep -v "$PWD\$" | egrep -v '\.[A-Fa-f0-9]{40}' | xargs rm -rf
popd

echo 'Removing binaries from tarball src...'
# coreclr and installer have two empty placeholder pdb files.  Exclude these directories.
find $TARBALL_ROOT/src -not -path "*/src/coreclr/src/.nuget/*" -not -path "*/src/installer/pkg/*" \
    \( -type f \( \
    -iname *.dll -o \
    -iname *.exe -o \
    -iname *.pdb -o \
    -iname *.mdb -o \
    -iname *.zip -o \
    -iname *.nupkg \) \) -exec rm {} \;

if [ $MINIMIZE_DISK_USAGE -eq 1 ]; then
    pushd "$TARBALL_ROOT/src"
    echo 'Removing unneeded files to trim tarball...'
    # we don't build CoreCLR tests right now and they have a lot of them - ~380MB
    rm -rf coreclr.*/tests
    popd
fi

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
cp $SCRIPT_ROOT/DarcVersion.txt $TARBALL_ROOT/
cp $SCRIPT_ROOT/ProdConFeed.txt $TARBALL_ROOT/
cp $SCRIPT_ROOT/smoke-test* $TARBALL_ROOT/
if [ ! -d "$CUSTOM_SDK_DIR" ]; then
  cp -r $CLI_PATH $TARBALL_ROOT/
  rm -rf $TARBALL_ROOT/$CLI_DIR/shared/2.1.0/
  rm -rf $TARBALL_ROOT/$CLI_DIR/tools/
fi
cp -r $SCRIPT_ROOT/eng $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/keys $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/patches $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/scripts $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/repos $TARBALL_ROOT/
cp -r $SCRIPT_ROOT/tools-local $TARBALL_ROOT/
rm -rf $TARBALL_ROOT/tools-local/arcade-services/
rm -rf $TARBALL_ROOT/tools-local/tasks/*/bin
rm -rf $TARBALL_ROOT/tools-local/tasks/*/obj
cp -r $SCRIPT_ROOT/bin/git-info $TARBALL_ROOT/

cp $SCRIPT_ROOT/support/tarball/build.sh $TARBALL_ROOT/build.sh
cp -r $SCRIPT_ROOT/support/tarball/tool-bootstrapping/ $TARBALL_ROOT

mkdir -p $TARBALL_ROOT/packages/prebuilt
mkdir -p $TARBALL_ROOT/packages/source-built
find $SCRIPT_ROOT/packages/restored/ -name '*.nupkg' -exec cp {} $TARBALL_ROOT/packages/prebuilt/ \;
find $SCRIPT_ROOT/bin/obj/$targetArchitecture/Release/nuget-packages -name '*.nupkg' -exec cp {} $TARBALL_ROOT/packages/prebuilt/ \;

# Copy reference-packages from bin dir to reference-packages directory.
# See corresponding change in dir.props to change ReferencePackagesBasePath conditionally in offline build.
mkdir -p $TARBALL_ROOT/packages/reference

# Copy tarballs to ./packages/archive directory
if [[ -d "$SCRIPT_ROOT/bin/obj/$targetArchitecture/Release/external-tarballs" && ! -z "$(find $SCRIPT_ROOT/bin/obj/$targetArchitecture/Release/external-tarballs -iname '*.tar.gz')" ]]; then
    mkdir -p $TARBALL_ROOT/packages/archive
    cp -r $SCRIPT_ROOT/bin/obj/$targetArchitecture/Release/external-tarballs/*.tar.gz $TARBALL_ROOT/packages/archive/
fi

# Copy generated source from bin to src/generatedSrc
cp -r $SCRIPT_ROOT/bin/obj/$targetArchitecture/Release/generatedSrc $TARBALL_ROOT/src/generatedSrc

if [ -e $SCRIPT_ROOT/testing-smoke/smoke-test-packages ]; then
    cp -rf $SCRIPT_ROOT/testing-smoke/smoke-test-packages $TARBALL_ROOT/packages
fi

echo 'Saving off required arcade prebuilts...'
mkdir -p $TARBALL_ROOT/packages/arcadeRequired
while IFS= read -r packagePattern
do
    if [[ "$packagePattern" =~ ^# ]]; then
        continue
    fi
    cp -f $TARBALL_ROOT/packages/prebuilt/$packagePattern $TARBALL_ROOT/packages/arcadeRequired/
done < $SCRIPT_ROOT/support/arcade-required-prebuilts.txt


echo 'Removing source-built packages from tarball prebuilts...'

for built_package in $(find $SCRIPT_ROOT/bin/obj/$targetArchitecture/Release/blob-feed/packages/ -name '*.nupkg' | tr '[:upper:]' '[:lower:]')
do
    if [ -e $TARBALL_ROOT/packages/prebuilt/$(basename $built_package) ]; then
        rm $TARBALL_ROOT/packages/prebuilt/$(basename $built_package)
    fi
    if [ -e $TARBALL_ROOT/packages/smoke-test-packages/$(basename $built_package) ]; then
        rm $TARBALL_ROOT/packages/smoke-test-packages/$(basename $built_package)
    fi
done

# Setup package version props to include both source-built and running PackageVersions.props
mkdir --parents $TARBALL_ROOT/bin/obj/$targetArchitecture/Release/
cp $SCRIPT_ROOT/support/tarball/PackageVersions.props $TARBALL_ROOT/bin/obj/$targetArchitecture/Release/

if [ $INCLUDE_LEAK_DETECTION -eq 1 ]; then
  echo 'Building leak detection MSBuild tasks...'
  "$CLI_PATH/dotnet" restore $SCRIPT_ROOT/tools-local/tasks/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection.csproj --source $FULL_TARBALL_ROOT/packages/source-built --source $FULL_TARBALL_ROOT/packages/prebuilt
  "$CLI_PATH/dotnet" publish -o $FULL_TARBALL_ROOT/tools-local/tasks/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection $SCRIPT_ROOT/tools-local/tasks/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection/Microsoft.DotNet.SourceBuild.Tasks.LeakDetection.csproj
fi

echo 'Removing reference packages from tarball prebuilts...'

if [ -d "$CUSTOM_REF_PACKAGES_DIR" ]; then
    allRefPkgs=(`ls "$CUSTOM_REF_PACKAGES_DIR"  | tr '[:upper:]' '[:lower:]'`)
else
    allRefPkgs=(`tar -tf $TARBALL_ROOT/packages/archive/Private.SourceBuild.ReferencePackages.*.tar.gz | tr '[:upper:]' '[:lower:]'`)
fi
if [ -d "$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR" ]; then
    allSourceBuiltPkgs=(`ls "$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR"  | tr '[:upper:]' '[:lower:]'`)
else
    allSourceBuiltPkgs=(`tar -tf $TARBALL_ROOT/packages/archive/Private.SourceBuilt.Artifacts.*.tar.gz | tr '[:upper:]' '[:lower:]'`)
fi

echo 'Removing reference-packages from tarball prebuilts...'

for ref_package in ${allRefPkgs[@]}
do
    if [ -e $TARBALL_ROOT/packages/prebuilt/$ref_package ]; then
        rm $TARBALL_ROOT/packages/prebuilt/$ref_package
    fi
done

echo 'Removing previously source-built packages from tarball prebuilts...'

for ref_package in ${allSourceBuiltPkgs[@]}
do
    if [ -e $TARBALL_ROOT/packages/prebuilt/$ref_package ]; then
        rm $TARBALL_ROOT/packages/prebuilt/$ref_package
    fi
done

echo 'Removing known extra packages from tarball prebuilts...'
while IFS= read -r packagePattern
do
    if [[ "$packagePattern" =~ ^# ]]; then
        continue
    fi
    rm -f $TARBALL_ROOT/packages/prebuilt/$packagePattern
done < $SCRIPT_ROOT/support/additional-prebuilts-to-delete.txt

if [ $SKIP_PREBUILT_ENFORCEMENT -ne 1 ]; then
  echo 'Checking for extra prebuilts...'
  error_encountered=false
  for package in `ls -A $TARBALL_ROOT/packages/prebuilt`
  do
      if grep -q "$package" $SCRIPT_ROOT/support/allowed-prebuilts.txt; then
          echo "Allowing prebuilt $package"
      else
          echo "ERROR: $package is not in the allowed prebuilts list ($SCRIPT_ROOT/support/allowed-prebuilts.txt)"
          error_encountered=true
      fi
  done
  if [ "$error_encountered" = "true" ]; then
    echo "Either remove this prebuilt, add it to the known extras list ($SCRIPT_ROOT/support/additional-prebuilts-to-delete.txt) or add it to the allowed prebuilts list."
    exit 1
  fi
fi

echo 'Recording commits for the source-build repo and all submodules, to aid in reproducibility...'

cat >$TARBALL_ROOT/source-build-info.txt << EOF
source-build:
 $(git rev-parse HEAD) . ($(git describe --always HEAD))

submodules:
$(git submodule status --recursive)
EOF

echo "Done. Tarball created: $TARBALL_ROOT"
