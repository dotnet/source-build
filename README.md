# .NET Core Build Scripts

[![Join the chat at https://gitter.im/dotnet/source-build](https://badges.gitter.im/dotnet/source-build.svg)](https://gitter.im/dotnet/source-build?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

|OS|Release|Debug|
|--|-------|-----|
|CentOS7.1|[![Build Status][centos-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Release/)|[![Build Status][centos-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Debug/)
|CentOS7.1 (Tarball)|[![Build Status][centos-tarball-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Tarball_Release/)|[![Build Status][centos-tarball-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/CentOS7.1_Tarball_Debug/)
|Debian8.4|[![Build Status][debian-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/Debian8.4_Release/)|[![Build Status][debian-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/Debian8.4_Debug/)
|Fedora24|[![Build Status][fedora-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/Fedora24_Release/)|[![Build Status][fedora-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/Fedora24_Debug/)
|OSX10.12|[![Build Status][osx-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/OSX10.12_Release/)|[![Build Status][osx-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/OSX10.12_Debug/)
|RHEL7.2|[![Build Status][rhel-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Release/)|[![Build Status][rhel-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Debug/)
|RHEL7.2 (Tarball)|[![Build Status][rhel-tarball-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Tarball_Release/)|[![Build Status][rhel-tarball-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Tarball_Debug/)
|RHEL7.2 (Unshared)|[![Build Status][rhel-unshared-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Unshared_Release/)|[![Build Status][rhel-unshared-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/RHEL7.2_Unshared_Debug/)
|Ubuntu16.04|[![Build Status][ubuntu-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/Ubuntu16.04_Release/)|[![Build Status][ubuntu-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/Ubuntu16.04_Debug/)
|Windows|[![Build Status][windows-release-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/Windows_NT_Release/)|[![Build Status][windows-debug-badge]](https://ci.dot.net/job/dotnet_source-build/job/master/job/Windows_NT_Debug/)

[centos-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Release
[centos-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Debug
[centos-tarball-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Tarball_Release
[centos-tarball-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/CentOS7.1_Tarball_Debug
[debian-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Debian8.4_Release
[debian-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Debian8.4_Debug
[fedora-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Fedora24_Release
[fedora-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Fedora24_Debug
[linux_arm-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Linux_ARM_Release
[linux_arm-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Linux_ARM_Debug
[osx-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/OSX10.12_Release
[osx-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/OSX10.12_Debug
[rhel-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Release
[rhel-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Debug
[rhel-tarball-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Tarball_Release
[rhel-tarball-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Tarball_Debug
[rhel-unshared-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Unshared_Release
[rhel-unshared-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/RHEL7.2_Unshared_Debug
[ubuntu-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Ubuntu16.04_Release
[ubuntu-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Ubuntu16.04_Debug
[windows-release-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Windows_NT_Release
[windows-debug-badge]: https://ci.dot.net/buildStatus/icon?job=dotnet_source-build/master/Windows_NT_Debug

This repository contains a set of scripts for building the .NET Core Runtime and SDK from source. The scripts were built to make it easy for anyone to build the .NET Core product.

You can use these scripts to build the .NET Core product for Windows, macOS or Linux. See [Documentation](Documentation) for complete instructions.

## Using the Scripts

The scripts are supported on Windows, macOS and Linux. The scripts are based on PowerShell on Windows and Bash on macOS and Linux.

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
 
Many Linux distributions have specific rules for official packages. The rules can be summarized as two main rules: source for everything, and consistent reproducability.

A key goal of this repository was to satisfy the official packaging rules of commonly used Linux distributions, such as [Fedora](https://fedoraproject.org/wiki/Packaging:Guidelines) and [Debian](https://www.debian.org/doc/manuals/maint-guide/build.en.html). 

## License

This repo is licensed with [MIT](LICENSE.txt).
