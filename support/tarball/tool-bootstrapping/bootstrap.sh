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
    local size=(`df -h .`)
    local message="[${size[10]} - ${size[11]}] : $1"
    #local message=$1
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
    LogMessage "Copy tarball-source to stage1 directory"
    cp -r $tarballSourceDir $stage1Dir

    # Build stage1 source
    LogMessage "Building stage1"
    cd $stage1Dir
    ./build.sh
    cd $bootstrapDir

    LogMessage "Completing Step1 - Build stage1 sdk" 
}

if [ -z "${3:-}" ]; then
    usage
    exit 1
fi

bootstrapDir=$1
tarballSourceDir=$2
refPkgDir=$3
startStep="${4:-}"

HERE: CHECK FOR START STEP
if [ -d "$bootstrapDir" ]; then
    echo "$bootstrapDir already exists"
    echo "exiting..."
    exit 1
fi

stage1Dir="$bootstrapDir/stage1-sdk"

# Check network access
wget -q --spider http://www.microsoft.com
if [ $? -eq 0 ]; then
    LogMessage "Network can be off for bootstrapping..."
    read -n1 -r -p "Press space to continue..." key
    echo ""
fi



