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
    echo "  --base-tarball                     creates a tarball without sdk, previously-build packages and reference packages"
    echo "use -- to send the remaining arguments to build.sh"
}

getrealpath()
{
    if command -v realpath > /dev/null; then
        realpath $1
    else
        readlink -f $1
    fi
}

if [ -z "${1:-}" ]; then
    usage
    exit 1
fi

TARBALL_ROOT=$1
shift

SKIP_BUILD=0
BASE_TARBALL=0
CUSTOM_SDK_DIR=''
MINIMIZE_DISK_USAGE=0
CUSTOM_REF_PACKAGES_DIR=''
CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR=''
MAIN_BUILD_ARGS=("/p:ArchiveDownloadedPackages=true")

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
            MAIN_BUILD_ARGS+=( "/p:IncludeLeakDetection=true" )
            ;;
        --minimize-disk-usage)
            MINIMIZE_DISK_USAGE=1
            MAIN_BUILD_ARGS+=( "/p:DestructiveIntermediateClean=true" )
            ;;
        --skip-prebuilt-check)
            MAIN_BUILD_ARGS+=( "/p:SkipPrebuiltEnforcement=true" )
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
            MAIN_BUILD_ARGS+=( "/p:CustomRefPackagesDir=$CUSTOM_REF_PACKAGES_DIR" )
            shift
            ;;
        --with-packages)
            CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR="$2"
            if [ ! -d "$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR" ]; then
                echo "Custom reference packages directory '$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR' does not exist"
                exit 1
            fi
            MAIN_BUILD_ARGS+=( "/p:SkipDownloadingPreviouslySourceBuiltPackages=true" )
            MAIN_BUILD_ARGS+=( "/p:CustomPreviouslySourceBuiltPackagesDir=$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR" )
            shift
            ;;
        --base-tarball)
            BASE_TARBALL=1
            MAIN_BUILD_ARGS+=( "/p:PackBaseTarball=true" )
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

if [[ $BASE_TARBALL -eq 1 && ( "$CUSTOM_SDK_DIR" != "" || "$CUSTOM_REF_PACKAGES_DIR" != "" || "$CUSTOM_PREVIOUSLY_BUILT_PACKAGES_DIR" != "" ) ]]; then
    echo "ERROR: Cannot specify --base-tarball with other --with* parameters (--with-sdk --with-ref-packages --with-packages)"
    exit 1
fi

if [ $MINIMIZE_DISK_USAGE -eq 1 ]; then
    echo "WARNING"
    echo "WARNING"
    echo "WARNING: --minimize-disk-usage intentionally trashes your local repo and any local work.  It will not be recoverable.  It is intended for CI use only."
    echo "WARNING"
    echo "WARNING"
    echo "WARNING: You have 10 seconds to cancel."
    sleep 10
fi

export SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
fullTarballRoot="$TARBALL_ROOT"
while [[ -h $fullTarballRoot ]]; do
  fullTarballRoot="$(readlink "$fullTarballRoot")"

  # if $source was a relative symlink, we need to resolve it relative to the path where the
  # symlink file was located
  [[ $fullTarballRoot != /* ]] && fullTarballRoot="$SCRIPT_ROOT/$fullTarballRoot"
done
export FULL_TARBALL_ROOT="$(getrealpath "$fullTarballRoot")"
mkdir -p "$FULL_TARBALL_ROOT"

if [ -e "$TARBALL_ROOT" ]; then
    echo "info: '$TARBALL_ROOT' already exists"
fi

export SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"
if [ -d "$CUSTOM_SDK_DIR" ]; then
  export SDK_VERSION=`"$CUSTOM_SDK_DIR/dotnet" --version`
  echo "Using custom bootstrap SDK from '$CUSTOM_SDK_DIR', version $SDK_VERSION"
else
  sdkLine=`grep -m 1 'dotnet' "$SCRIPT_ROOT/global.json"`
  sdkPattern="\"dotnet\" *: *\"(.*)\""
  if [[ $sdkLine =~ $sdkPattern ]]; then
    export SDK_VERSION=${BASH_REMATCH[1]}
  fi
  echo "Found bootstrap SDK $SDK_VERSION"
fi

if [ $SKIP_BUILD -ne 1 ]; then

    if [ -e "$SCRIPT_ROOT/artifacts" ]; then
        rm -rf "$SCRIPT_ROOT/artifacts"
    fi

    $SCRIPT_ROOT/clean.sh
else
    MAIN_BUILD_ARGS+=( "/p:SkipProductionBuild=true" )
fi


MAIN_BUILD_ARGS+=( "/p:TarballRoot=$FULL_TARBALL_ROOT" )
MAIN_BUILD_ARGS+=( "/p:PackSourceBuildTarball=true" )

$SCRIPT_ROOT/build.sh ${MAIN_BUILD_ARGS[@]} /bl:$SCRIPT_ROOT/artifacts/log/Debug/BuildTarball_$(date +"%m%d%H%M%S").binlog "$@"

echo "Done. Tarball created: $TARBALL_ROOT"
