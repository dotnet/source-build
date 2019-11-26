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

    LogMessage "Copy coreclr-tools to $refPkgsDir/source-built"
    cp -r $stage1Dir/Tools/source-built/coreclr-tools/ $refPkgsDir/source-built

    LogMessage "Un-tar private source-built artifacts into $refPkgsDir/source-built/"
    tar -xzf $stage1Dir/bin/x64/Release/Private.SourceBuilt.Artifacts.*.tar.gz --directory $refPkgsDir/source-built/

    LogMessage "Un-tar sdk into $refPkgsDir/.dotnet/"
    if [ -d "$refPkgsDir/.dotnet/" ]; then
        rm -rf $refPkgsDir/.dotnet/
    fi
    mkdir $refPkgsDir/.dotnet/
    tar -xzf $stage1Dir/bin/x64/Release/dotnet-sdk-3*.tar.gz --directory $refPkgsDir/.dotnet/

    LogMessage "Update SDK version in global.json file"
    sdkVer=`ls $refPkgsDir/.dotnet/sdk`
    LogMessage "    Sdk version = [$sdkVer]"
    sed -i "s|\"dotnet\": \".*|\"dotnet\": \"$sdkVer\"|g" $refPkgsDir/global.json

    LogMessage "Build stage1 ref-pkgs"
    pushd $refPkgsDir
    ./build.sh
    popd

    LogMessage "Package built reference packages into new tarball"
    pushd $refPkgsDir/artifacts/reference-packages
    tar --numeric-owner -czf $refPkgsDir/artifacts/Private.SourceBuild.ReferencePackages.bootstrap.tar.gz *.nupkg
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
    rm -rf $finalSdkDir/packages/archive/*
    rm -rf $finalSdkDir/packages/source-built/*
    rm -rf $finalSdkDir/.dotnet

    LogMessage "Copy stage1 coreclr-tools to $finalSdkDir/packages/source-built"
    cp -r $stage1Dir/Tools/source-built/coreclr-tools $finalSdkDir/packages/source-built

    LogMessage "Copy source-built packages archive from $stage1Dir/bin/x64/Release/Private.SourceBuilt.Artifacts*.tar.gz to $finalSdkDir/packages/archive"
    cp $stage1Dir/bin/x64/Release/Private.SourceBuilt.Artifacts*.tar.gz $finalSdkDir/packages/archive

    LogMessage "Extract .NET Core SDK from $stage1Dir/bin/x64/Release/dotnet-sdk-3*.tar.gz to $finalSdkDir/.dotnet/"
    if [ -d "$finalSdkDir/.dotnet/" ]; then
        rm -rf $finalSdkDir/.dotnet/
    fi
    mkdir $finalSdkDir/.dotnet/
    tar -xzf $stage1Dir/bin/x64/Release/dotnet-sdk-3*.tar.gz --directory $finalSdkDir/.dotnet/

    LogMessage "Copy reference packages from $refPkgsDir/artifacts/Private.SourceBuild.ReferencePackages.bootstrap.tar.gz to $finalSdkDir/packages/archive"
    cp $refPkgsDir/artifacts/Private.SourceBuild.ReferencePackages.bootstrap.tar.gz $finalSdkDir/packages/archive

    LogMessage "Update version of SDK and arcade in global.json"
    arcadeName=$(tar -tf $finalSdkDir/packages/archive/Private.SourceBuilt.Artifacts*.tar.gz Microsoft.DotNet.Arcade.Sdk.*.nupkg)
    arcadeVer=${arcadeName//Microsoft.DotNet.Arcade.Sdk.}
    arcadeVer=${arcadeVer//.nupkg}
    LogMessage "    Arcade version = [$arcadeVer]"
    sed -i "s|\(\"Microsoft.DotNet.Arcade.Sdk\": \"\)[^\"]*\"|\1$arcadeVer\"|g" $finalSdkDir/global.json

    sdkVer=$(ls $finalSdkDir/.dotnet/sdk)
    LogMessage "    Sdk version = [$sdkVer]"
    sed -i "s|\"dotnet\": \".*|\"dotnet\": \"$sdkVer\"|g" $finalSdkDir/global.json

    LogMessage "Build final sdk"
    pushd $finalSdkDir
    ./build.sh
    popd

    LogMessage "Completing Step3 - Build final sdk"
}

if [ -z "${3:-}" ]; then
    usage
    exit 1
fi

bootstrapDir=$1
tarballSourceDir=$2
refPkgSourceDir=$3
startStep="${4:-}"

stage1Dir="$bootstrapDir/stage1-sdk"
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
