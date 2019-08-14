# .NET Core Build Scripts

[![Join the chat at https://gitter.im/dotnet/source-build](https://badges.gitter.im/dotnet/source-build.svg)](https://gitter.im/dotnet/source-build?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

<!-- Use scripts/generate-readme-table.sh to update table. -->
<!-- Generated table start -->
| OS | *Azure DevOps*<br/>Release |
| -- | :-- |
| CentOS7.1 | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-rolling-CI?branchName=release/3.0&jobName=centos71&configuration=centos71%20Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| CentOS7.1 (Online) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-rolling-CI?branchName=release/3.0&jobName=centos71&configuration=centos71%20Online)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| CentOS7.1 (Offline) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-rolling-CI?branchName=release/3.0&jobName=centos71&configuration=centos71%20Offline)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| CentOS7.1 (Offline Portable) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-rolling-CI?branchName=release/3.0&jobName=centos71&configuration=centos71%20Offline%20Portable)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| Debian8.2 | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/3.0&jobname=debian82&configuration=debian82%20Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| Debian8.2 (Online) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/3.0&jobname=debian82&configuration=debian82%20Online)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| Fedora29 | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/3.0&jobname=fedora29&configuration=fedora29%20Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| Fedora29 (Online) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/3.0&jobname=fedora29&configuration=fedora29%20Online)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| Fedora29 (Offline) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/3.0&jobname=fedora29&configuration=fedora29%20Offline)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| Fedora29 (Offline Portable) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/3.0&jobname=fedora29&configuration=fedora29%20Offline%20Portable)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| OSX | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-rolling-CI?branchName=release/3.0&jobName=OSX)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| Ubuntu16.04 | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/3.0&jobname=ubuntu1604&configuration=ubuntu1604%20Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
| Windows | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-rolling-CI?branchName=release/3.0&jobName=Windows)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/3.0) |
<!-- Generated table end -->

This repository contains a set of scripts for building the .NET Core Runtime and SDK from source. The scripts were built to make it easy for anyone to build the .NET Core product.

You can use these scripts to build the .NET Core product for Windows, macOS or Linux. See [Documentation](Documentation) for complete instructions.

## Using the Scripts

The scripts are supported on Windows, macOS and Linux. The scripts are based on PowerShell on Windows and Bash on macOS and Linux.  Currently, Windows scripts only build through core-setup and do not build the complete SDK.

If you are building on Windows or OSX, building is possible via Docker. (https://hub.docker.com/r/microsoft/dotnet/)

### Build on Windows

```console
./build.ps1
```

### Build on Linux or macOS

```console
./build.sh
```

##  Script Users

The most common users are expected to be:

* .NET Core contributors.
* Linux distribution maintainers.
* Cloud service developers.

You do not have to build the entire product to contribute to .NET Core. Often, you only need to build a single binary to test a change. There are some scenarios where building the whole product is useful, such as adding and testing a feature that requires changes to multiple repos.

## What the Scripts Do

The scripts can be thought of as solving challenges that would otherwise making building the whole product difficult. The following challenges are the primary ones that developers often hit before these scripts were available.

* .NET Core is composed of several repositories that all need to be built.
* The .NET Core SDK generated by the build requires a specific layout in order to correctly function.
* Most of the product is written in managed code and requires the .NET Core SDK to build. This approach is a great use of the product, but presents a boot-strapping problem for the build.

## Goals

Many Linux distributions have specific rules for official packages. The rules can be summarized as two main rules: source for everything, and consistent reproducibility.

A key goal of this repository was to satisfy the official packaging rules of commonly used Linux distributions, such as [Fedora](https://fedoraproject.org/wiki/Packaging:Guidelines) and [Debian](https://www.debian.org/doc/manuals/maint-guide/build.en.html).

## License

This repo is licensed with [MIT](LICENSE.txt).
