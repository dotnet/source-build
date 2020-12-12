#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd -P "$( dirname "$0" )" && pwd)"

usage() {
    echo "usage: $0 <path-to-new-bootstrap-dir> <path-to-source-build-tarball> <path-to-ref-pkg-source-dir> [ <step> ]"
    echo ""
    echo "  Creates a new directory and runs the bootstrap scripts using the tarball and reference package source paths given"
    echo ""
    echo "  Steps:"
    echo "      1. Build stage1 sdk and arcade from tarball using stage0 sdk and ref-pkgs in the tarball"
    echo "      2. Build final ref-pkgs using stage1 sdk and arcade"
    echo "      3. Build final sdk using final ref-pkgs and stage1 sdk and arcade"
    echo ""
}

function LogMessage {
    local message=$1
    local dt=`date '+%d/%m/%Y %H:%M:%S'`
    local outFile="$bootstrapDir/status.log"

    echo "==================================================================================================="
    echo "= $message "
    echo "==================================================================================================="

    echo "[$dt] : $message" >> "$outFile"
}

function BuildStage1Sdk {
    LogMessage "Starting Step1 - Build stage1 sdk"

    if [ -d "$stage1Dir" ]; then
        echo "$stage1Dir already exists"
        echo "exiting..."
        exit 1
    fi

    if [ ! -d "$tarballSourceDir" ]; then
        echo "$tarballSourceDir doesn't exist"
        echo "exiting..."
        exit 1
    fi

    # Copy tarball-source to stage1 directory
    LogMessage "Copy $tarballSourceDir to $stage1Dir"
    cp -r $tarballSourceDir $stage1Dir

    # Build stage1 source
    LogMessage "Building stage1"
    pushd $stage1Dir
    ./build.sh
    popd

    LogMessage "Completing Step1 - Build stage1 sdk"
}

function BuildRefPkgs {
    LogMessage "Starting Step2 - Build Reference Packages"

    if [ ! -d "$refPkgSourceDir" ]; then
        echo "$refPkgSourceDir doesn't exist"
        echo "exiting..."
        exit 1
    fi

    if [ -d "$refPkgsDir" ]; then
        echo "$refPkgsDir already exists"
        echo "exiting..."
        exit 1
    fi

    if [ ! -d "$stage1Dir" ]; then
        echo "$stage1Dir doesn't exist"
        echo "exiting..."
        exit 1
    fi

    LogMessage "Copy $refPkgSourceDir to $refPkgsDir"
    cp -r $refPkgSourceDir $refPkgsDir

    LogMessage "Un-tar sdk into $stage1SdkInstallDir"
    if [ -d "$stage1SdkInstallDir" ]; then
        rm -rf $stage1SdkInstallDir
    fi
    mkdir $stage1SdkInstallDir
    tar -xzf $stage1Dir/artifacts/x64/Release/dotnet-sdk-5*.tar.gz --directory $stage1SdkInstallDir

    LogMessage "Build stage1 ref-pkgs"
    pushd $refPkgsDir
    ./build.sh --with-packages $stage1Dir/artifacts/x64/Release/Private.SourceBuilt.Artifacts.*.tar.gz --with-sdk $stage1SdkInstallDir
    popd

    LogMessage "Completing Step2 - Build Reference Packages"
}

function buildFinalSdk {
    LogMessage "Starting Step3 - Build final sdk"

    if [ -d "$finalSdkDir" ] && [ "${1-default}" != "test" ]; then
        echo "$finalSdkDir already exists"
        echo "exiting..."
        exit 1
    fi

    if [ ! -d "$stage1Dir" ]; then
        echo "$stage1Dir doesn't exist"
        echo "exiting..."
        exit 1
    fi

    if [ ! -d "$refPkgsDir" ]; then
        echo "$refPkgsDir doesn't exist"
        echo "exiting..."
        exit 1
    fi

    if [ ! -d "$tarballSourceDir" ]; then
        echo "$tarballSourceDir doesn't exist"
        echo "exiting..."
        exit 1
    fi

    if [ "${1-default}" != "test" ]; then
        LogMessage "Copy $tarballSourceDir to $finalSdkDir"
        cp -r $tarballSourceDir $finalSdkDir
    fi

    LogMessage "Remove archive packages, source-built packages and SDK from final-sdk dir"
    rm -rf $finalSdkDir/packages/archive
    rm -rf $finalSdkDir/packages/source-built/*
    rm -rf $finalSdkDir/.dotnet

    LogMessage "Install previously source-built archive from $stage1Dir/artifacts/x64/Release/Private.SourceBuilt.Artifacts*.tar.gz to $stage1SourceBuiltArtifactsInstallDir"
    mkdir -p $stage1SourceBuiltArtifactsInstallDir
    tar -xzf $stage1Dir/artifacts/x64/Release/Private.SourceBuilt.Artifacts*.tar.gz --directory $stage1SourceBuiltArtifactsInstallDir

    LogMessage "Build final sdk"
    pushd $finalSdkDir
    ./build.sh --with-ref-packages $refPkgsDir/artifacts/reference-packages --with-packages $stage1SourceBuiltArtifactsInstallDir --with-sdk $stage1SdkInstallDir
    popd

    LogMessage "Completing Step3 - Build final sdk"
}

function abspath() {
  # $1 : relative filename
  parentdir=$(dirname "$1")

  if [ -d "$1" ]; then
      echo "$(cd "$1" && pwd)"
  elif [ -d "${parentdir}" ]; then
    echo "$(cd "${parentdir}" && pwd)/$(basename "$1")"
  fi
}

if [ -z "${3:-}" ]; then
    usage
    exit 1
fi

bootstrapDir="$(abspath $1)"
tarballSourceDir="$(abspath $2)"
refPkgSourceDir="$(abspath $3)"
startStep="${4:-}"

stage1Dir="$bootstrapDir/stage1-sdk"
stage1SdkInstallDir="$bootstrapDir/stage1-sdk-install"
stage1SourceBuiltArtifactsInstallDir="$bootstrapDir/stage1-source-built-artifacts-install"
refPkgsDir="$bootstrapDir/reference-packages"
finalSdkDir="$bootstrapDir/final-sdk"

if [[ -d "$bootstrapDir" && "$startStep" == "" ]]; then
    echo "$bootstrapDir already exists"
    echo "exiting..."
    exit 1
fi

if [ ! -d "$bootstrapDir" ]; then
    mkdir "$bootstrapDir"
fi

# Check network access
if command -v wget 2>/dev/null; then
    if wget -q --spider http://www.microsoft.com 2>/dev/null; then
        echo "Network can be off for bootstrapping..."
        read -n1 -r -p "Press space to continue..." key
        echo ""
    fi
    if wget -q --spider http://www.microsoft.com 2>/dev/null; then
        LogMessage "Network is ON"
    else
        LogMessage "Network is OFF"
    fi
else
    LogMessage "Unknown network status"
fi

if [[ "$startStep" == "" || "$startStep" == "1" ]]; then
    BuildStage1Sdk
fi
if [[ "$startStep" == "" || "$startStep" == "2" ]]; then
    BuildRefPkgs
fi
if [[ "$startStep" == "" || "$startStep" == "3" ]]; then
    buildFinalSdk
fi
