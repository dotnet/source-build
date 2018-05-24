#!/usr/bin/env bash
__currentWorkingDirectory=`pwd`
__buildArch=$1
shift;

# Check build configuration and choose Docker image
__dockerEnvironmentVariables=""
if [ "$__buildArch" == "arm" ]; then
    __dockerImage=" microsoft/dotnet-buildtools-prereqs:ubuntu-14.04-cross-0cd4667-20172211042239"
    __dockerEnvironmentVariables+=" -e ROOTFS_DIR=/crossrootfs/arm"
elif [ "$__buildArch" == "armel" ]; then
    __dockerImage=" hqueue/dotnetcore:ubuntu1404_cross_prereqs_v4-tizen_rootfs"
    __dockerEnvironmentVariables+=" -e ROOTFS_DIR=/crossrootfs/armel.tizen.build"
fi
__dockerCmd="sudo docker run ${__dockerEnvironmentVariables} --privileged --cap-add=ALL -v /lib/modules:/lib/modules -i --rm -v $__currentWorkingDirectory:/opt/code -w /opt/code $__dockerImage"
echo "Running docker: $__dockerCmd"
$__dockerCmd "$@"
