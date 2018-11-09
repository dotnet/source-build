# .NET Core Build Scripts

[![Join the chat at https://gitter.im/dotnet/source-build](https://badges.gitter.im/dotnet/source-build.svg)](https://gitter.im/dotnet/source-build?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

<!-- Use scripts/generate-readme-table.sh to update table. -->
<!-- Generated table start -->
| OS | *Jenkins*<br/>Release | <br/>Debug | *Azure DevOps*<br/>Release |
| -- | :-- | :-- | :-- |
| CentOS7.1 | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Debug/) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=centos71&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| CentOS7.1 (Online) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Tarball_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Tarball_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Tarball_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Tarball_Debug/) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=centos71&configuration=Online)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| CentOS7.1 (Online Portable) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Tarball_Release_Portable)](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Tarball_Release_Portable/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Tarball_Debug_Portable)](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Tarball_Debug_Portable/) | 
| CentOS7.1 (Offline) | | | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=centos71&configuration=Offline)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| CentOS7.1 (Offline Portable) | | | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=centos71&configuration=Offline%20Portable)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| Debian8.2 | | | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=debian82&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| Debian8.2 (Online) | | | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=debian82&configuration=Online)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| Debian8.4 | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Debian8.4_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/Debian8.4_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Debian8.4_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/Debian8.4_Debug/) | 
| Fedora24 | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Fedora24_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/Fedora24_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Fedora24_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/Fedora24_Debug/) | 
| Fedora29 | | | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=fedora29&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| Fedora29 (Online) | | | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=fedora29&configuration=Online)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| Fedora29 (Offline) | | | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=fedora29&configuration=Offline)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| Fedora29 (Offline Portable) | | | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=fedora29&configuration=Offline%20Portable)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| OSX10.12 | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/OSX10.12_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/OSX10.12_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/OSX10.12_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/OSX10.12_Debug/) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=OSX&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| RHEL7.2 | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Debug/) | 
| RHEL7.2 (Online) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Tarball_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Tarball_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Tarball_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Tarball_Debug/) | 
| RHEL7.2 (Online Portable) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Tarball_Release_Portable)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Tarball_Release_Portable/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Tarball_Debug_Portable)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Tarball_Debug_Portable/) | 
| RHEL7.2 (Offline) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Unshared_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Unshared_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Unshared_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Unshared_Debug/) | 
| RHEL7.2 (Offline Portable) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Unshared_Release_Portable)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Unshared_Release_Portable/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Unshared_Debug_Portable)](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Unshared_Debug_Portable/) | 
| Ubuntu16.04 | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Ubuntu16.04_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/Ubuntu16.04_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Ubuntu16.04_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/Ubuntu16.04_Debug/) | [![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-CI?branchName=master&jobname=ubuntu1604&configuration=Production)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master) | 
| Windows | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Windows_NT_Release)](https://ci.dot.net/job/dotnet_source-build/job/master/job/Windows_NT_Release/) | [![Build Status](https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Windows_NT_Debug)](https://ci.dot.net/job/dotnet_source-build/job/master/job/Windows_NT_Debug/) | 
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
