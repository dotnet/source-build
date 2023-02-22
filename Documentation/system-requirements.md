# System Requirements to Source-Build

This document provides recommendation on host system and network requirements to build .NET SDK for a targeted platform using source-build. Refer this to avoid interruptions while building SDK using source-build.  

## Network Requirement

Acquiring .NET SDK source code ([Step 1](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build)) takes ~1.5 GB of network transfer.  

When building for new .NET version or new platform, you will need to get SDK and other toolset packages to create bootstrapping source-built SDK. This requires to run ([Step 2](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build)), which takes 4 GB of network transfer for .NET 6.0 and 1.2 GB for .NET 7.0.

## Operating System

### Linux

Refer to the [requirements](https://github.com/dotnet/runtime/blob/main/docs/workflow/requirements/linux-requirements.md) for building on Linux. You may use one of our [preconfigured container images](https://github.com/dotnet/dotnet-buildtools-prereqs-docker).

Additional links:

* [distros source building .NET](https://github.com/dotnet/source-build#net-in-linux-distributions)

### MacOS

MacOS is not currently supported: [Tracking Issue](https://github.com/dotnet/source-build/issues/2909).  However, community users have created a [Homebrew project](https://github.com/Homebrew/homebrew-core/blob/master/Formula/dotnet.rb) to build .NET for OSX.  Please feel free to open new issues in individual repos or in source-build for OSX issues and we can redirect them if possible.

### Windows

Windows is not currently supported. [Tracking Issue](https://github.com/dotnet/source-build/issues/2910)

## Hardware

### Disk Space

80 GB of space is required for a typical build. You can reduced this down to ~30 GB if you build with the `clean-while-building` option. This might increase over time, so consider this to be a minimum bar.

### Memory

A minimum of 8 GB of memory is recommended.

### Architectures

#### Officially Supported

* ARM64
* x64

#### Community Supported

* ARM32
* s390x
* ppc64le

## Network

The following assets will need to be downloaded in order to build.

* Source: 525 GB
* SDK: 230 MB
* Artifacts
  * .NET 8.0: 1 GB
  * .NET 7.0: 1.2 GB
  * .NET 6.0: 4 GB
