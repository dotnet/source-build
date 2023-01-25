# System Requirements to Source-Build

This document provides recommendation on host system and network requirements to build .NET SDK for a targeted platform using source-build. Refer this to avoid interruptions while building SDK using source-build.  

## Network Requirement

Acquiring .NET SDK source code ([Step 1](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build)) takes ~1.5 GB of network transfer.  

When building for new .NET version or new platform, you will need to get SDK and other toolset packages to create bootstrapping source-built SDK. This requires to run ([Step 2](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build)), which takes 4 GB of network transfer for .NET 6.0 and 1.2 GB for .NET 7.0.

## Operating System

**Linux**  
Source-build is supported on Linux. [Here](https://github.com/dotnet/runtime/blob/main/docs/workflow/requirements/linux-requirements.md) is the toolchain required to build on Linux. To get Linux distribution specific toolchain [refer](https://github.com/dotnet/dotnet-buildtools-prereqs-docker/tree/main/src).  

[List](https://github.com/dotnet/installer/blob/release/7.0.1xx/src/SourceBuild/Arcade/eng/common/templates/job/source-build-run-tarball-build.yml#L12-L16) of Linux distribution officially building and testing using source-build.  
Community building .NET for [following](https://github.com/dotnet/source-build#net-in-linux-distributions) linux distributions.  

**Windows/MacOS**  
Windows and MacOS are not yet supported. Issues tracking [Windows](https://github.com/dotnet/source-build/issues/2910) and [MacOS](https://github.com/dotnet/source-build/issues/2909).

## Hardware

**Disk Space/Memory**  
Inflating to a repository can consume ~600 MB. A build of .NET SDK product can take ~80 GB of space for a single OS and Platform configuration. This might increase over time, so consider this to be a minimum bar.
Consider the system with the minimum of 8 GB memory to source-build.

**Architecture Supported**  
Officially building and testing for following architectures - x64, Arm64  
Community building for following architectures - x64, Arm64, S390, Arm32, IBM Z
