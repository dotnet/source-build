# .NET Core Source-Build

[![Build Status](https://dev.azure.com/dnceng/internal/_apis/build/status/dotnet/source-build/source-build-rolling-CI?branchName=master)](https://dev.azure.com/dnceng/internal/_build/latest?definitionId=114&branchName=master)
[![Join the chat at https://gitter.im/dotnet/source-build](https://badges.gitter.im/dotnet/source-build.svg)](https://gitter.im/dotnet/source-build?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

This repository helps .NET SDK and .NET Runtime package maintainers comply with common Linux distribution guidelines.

To build the full .NET SDK from source, pick a specific Git tag with your desired version, or use a release branch to build the latest servicing release of that version. Refer to the tag/branch's README for build instructions:

* [`release/5.0`](https://github.com/dotnet/source-build/tree/release/5.0)
* [`release/3.1`](https://github.com/dotnet/source-build/tree/release/3.1)
* [`release/2.1`](https://github.com/dotnet/source-build/tree/release/2.1)

The current branch is a work in progress that produces several .NET SDK components for [Arcade-powered source-build](./Documentation/planning/arcade-powered-source-build/). Once Arcade-powered source-build is complete, it will allow building a .NET SDK from source directly from the [dotnet/installer](https://github.com/dotnet/installer) repository.

## Using this repository

The scripts are written for Bash and supported on macOS and Linux.

> The source-build repository doesn't currently support Windows. See [source-build#1190](https://github.com/dotnet/source-build/issues/1190).

### Build on Linux or macOS

Optionally, run `./check-submodules.sh` to ensure the submodules are set up and synchronized. Then, run the build command:

```console
./build.sh
```

Once the build is successful, the outputs are placed in `artifacts/packages/Debug/`.

## Goals

The key goal of source-build is to satisfy the official packaging rules of commonly used Linux distributions, such as [Fedora](https://fedoraproject.org/wiki/Packaging:Guidelines) and [Debian](https://www.debian.org/doc/manuals/maint-guide/build.en.html). Many Linux distributions have similar rules. These rules tend to have two main principles: consistent reproducibility, and source code for everything.

A secondary goal of source-build is to allow .NET Core contributors to build a .NET Core SDK with coordinated changes in multiple repositories. However, the developer experience is significantly better in individual repositories and, if possible, contributors should make and test changes in the target repo, not source-build.

## What does the source-build infrastructure do?

Source-build solves common challenges that most developers encounter when trying to build the whole .NET Core SDK from source.

* .NET Core is composed of many repositories that need to be built at a specific combination of commits.
* Each repository's build output needs to flow into the next repository's build.
* By default, most .NET Core repositories download prebuilt binary dependencies from online sources. These are forbidden by typical Linux distribution rules, and interfere with build output flow.
* Nearly all .NET Core repositories require the .NET Core SDK to build. This is a circular dependency, which presents a bootstrapping problem.

The source-build repository contains scripts and build logic to help Linux distribution maintainers address these challenges.

## License

This repo is licensed under the [MIT](LICENSE.txt) license.
