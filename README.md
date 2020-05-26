# .NET Core Source-Build

[![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-rolling-CI?branchName=release%2F3.1)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=release%2F3.1)
[![Join the chat at https://gitter.im/dotnet/source-build](https://badges.gitter.im/dotnet/source-build.svg)](https://gitter.im/dotnet/source-build?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

This repository contains infrastructure for building the .NET Core Runtime and SDK from source. The scripts allow .NET Core package maintainers to comply with common Linux distribution guidelines.

## Using this repository

The scripts are written for Bash and supported on macOS and Linux. See [Documentation](Documentation) for complete instructions.

> The source-build repository doesn't currently support Windows. See [source-build#1190](https://github.com/dotnet/source-build/issues/1190).

### Build on Linux or macOS

```console
./build.sh
```

## Goals

The key goal of this repository is to satisfy the official packaging rules of commonly used Linux distributions, such as [Fedora](https://fedoraproject.org/wiki/Packaging:Guidelines) and [Debian](https://www.debian.org/doc/manuals/maint-guide/build.en.html). Many Linux distributions have similar rules. These rules tend to have two main principles: consistent reproducibility, and source code for everything.

A secondary goal of source-build is to allow .NET Core contributors to build a .NET Core SDK with coordinated changes in multiple repositories. However, the developer experience is significantly better in individual repositories and, if possible, contributors should make and test changes in the target repo, not source-build.

## What does the source-build infrastructure do?

Source-build solves common challenges that most developers encounter when trying to build the whole .NET Core SDK from source.

* .NET Core is composed of many repositories that need to be built at a specific combination of commits.
* Each repository's build output needs to flow into the next repository's build.
* Nearly all .NET Core repositories require the .NET Core SDK to build. This is a circular dependency, which presents a bootstrapping problem.

The source-build repository contains scripts and build logic to help Linux distribution maintainers address these challenges.

## License

This repo is licensed under the [MIT](LICENSE.txt) license.
