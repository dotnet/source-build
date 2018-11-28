# .NET Core Build Scripts

[![Join the chat at https://gitter.im/dotnet/source-build](https://badges.gitter.im/dotnet/source-build.svg)](https://gitter.im/dotnet/source-build?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

<!-- Use scripts/generate-readme-table.sh to update table. -->
<!-- Generated table start -->
| OS | *Azure DevOps*<br/>Release |
| -- | :-- |
| CentOS7.1 | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=centos71&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| CentOS7.1 (Online) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=centos71&configuration=Online)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| CentOS7.1 (Offline) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=centos71&configuration=Offline)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| CentOS7.1 (Offline Portable) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=centos71&configuration=Offline%20Portable)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| Debian8.2 | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=debian82&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| Debian8.2 (Online) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=debian82&configuration=Online)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| Fedora29 | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=fedora29&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| Fedora29 (Online) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=fedora29&configuration=Online)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| Fedora29 (Offline) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=fedora29&configuration=Offline)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| Fedora29 (Offline Portable) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=fedora29&configuration=Offline%20Portable)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| OSX | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=OSX&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| Ubuntu16.04 | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=ubuntu1604&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
| Windows | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=release/2.2&jobname=Windows&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release/2.2) | 
<!-- Generated table end -->

This repository contains a set of scripts for building the .NET Core Runtime and SDK from source. The scripts were built to make it easy for anyone to build the .NET Core product.

You can use these scripts to build the .NET Core product for Windows, macOS or Linux. See [Documentation](Documentation) for complete instructions.

## Using the Scripts

The scripts are currently support only Linux at the moment. Windows and OSX are in the pipeline.

If you are building on Windows or OSX, building is possible via Docker. (https://hub.docker.com/r/microsoft/dotnet/)

### Build on Linux

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

Many Linux distributions have specific rules for official packages. The rules can be summarized as two main rules: source for everything, and consistent reproducability.

A key goal of this repository was to satisfy the official packaging rules of commonly used Linux distributions, such as [Fedora](https://fedoraproject.org/wiki/Packaging:Guidelines) and [Debian](https://www.debian.org/doc/manuals/maint-guide/build.en.html).

## License

This repo is licensed with [MIT](LICENSE.txt).
