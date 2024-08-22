# System Requirements to Source-Build

This document provides the system requirements to source build the .NET SDK for
a targeted platform.

## Operating System

### Linux

* [Toolchain
  Setup](https://github.com/dotnet/runtime/blob/main/docs/workflow/requirements/linux-requirements.md#toolchain-setup)
* [Preconfigured Container
  Images](https://github.com/dotnet/dotnet-buildtools-prereqs-docker) - These
  images are used by
  [CI](https://github.com/dotnet/dotnet/blob/main/src/sdk/eng/pipelines/templates/stages/vmr-build.yml)
  to build and test source-build.
* [Distros Source Building
  .NET](https://github.com/dotnet/source-build#net-in-linux-distributions)

### MacOS

MacOS is not currently supported: [Tracking
Issue](https://github.com/dotnet/source-build/issues/2909).  However, community
users have created a [Homebrew
project](https://github.com/Homebrew/homebrew-core/blob/master/Formula/d/dotnet.rb)
to build .NET for OSX.  Please feel free to open new issues in individual repos
or in source-build for OSX issues.

### Windows

Windows is not currently supported. [Tracking
Issue](https://github.com/dotnet/source-build/issues/2910)

## Hardware

### Disk Space

80 GB of space is required for a typical build. You can reduced this down to ~30
GB if you build with the `clean-while-building` option. This might increase over
time, so consider this to be a minimum bar.

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

* Source:
  * .NET 8.0: ~300 MB
  * .NET 6.0: ~500 MB
* SDK: ~200 MB
* Artifacts
  * .NET 8.0: ~1 GB
  * .NET 6.0: ~4 GB
