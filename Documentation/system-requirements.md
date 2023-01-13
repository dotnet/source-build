# System Requirements for Building

This document outlines the system requirements to build .NET from source.

## Operating System

### Linux

Refer to the [requirements](https://github.com/dotnet/runtime/blob/main/docs/workflow/requirements/linux-requirements.md) for building on Linux. You may use one of our [preconfigured container images](https://github.com/dotnet/dotnet-buildtools-prereqs-docker).

Additional links:

* [distros source building .NET](https://github.com/dotnet/source-build#net-in-linux-distributions)

### MacOS

MacOS is not currently supported. [Tracking Issue](https://github.com/dotnet/source-build/issues/2909)

### Windows

Windows is not currently supported. [Tracking Issue](https://github.com/dotnet/source-build/issues/2910)

## Hardware

### Disk Space

80 GB of space is required for a typical build. You can reduced this down to ~30 GB if you build with the ``clean-while-building` option. This might increase over time, so consider this to be a minimum bar.

### Memory

A minimum of 8 GB of memory is recommended.

### Architectures

#### Officially Supported

* arm64
* x64

#### Community Supported

* arm32
* s390
* IBM Z

## Network

The following assets will need to be downloaded in order to build.

* Source: 525 GB
* SDK: 230 MB
* Artifacts
  * .NET 8.0: 1 GB
  * .NET 7.0: 1.2 GB
  * .NET 6.0: 4 GB
