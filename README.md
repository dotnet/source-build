# .NET Source-Build

Please use [GitHub discussions](https://github.com/dotnet/source-build/discussions) to see announcements, ask questions, make suggestions, and share information with other members of the source-build community.

This repo is the starting point for building .NET 6 from source. Instructions for building other .NET versions are provided near the end of this document.

## Prerequisites

The dependencies for building .NET from source can be found [here](https://github.com/dotnet/runtime/blob/main/docs/workflow/requirements/linux-requirements.md). It may also be helpful to reference the Dockerfiles in [dotnet-buildtools-prereqs-docker](https://github.com/dotnet/dotnet-buildtools-prereqs-docker). We use these images to build and test source-build CI [here](https://github.com/dotnet/installer/blob/release/7.0.1xx/src/SourceBuild/Arcade/eng/common/templates/job/source-build-run-tarball-build.yml#L12-L16).

## Building .NET 7.0 and .NET 6.0

.NET 6.0 and 7.0 are built from source using the [dotnet/installer](https://github.com/dotnet/installer) repo.
Clone the dotnet/installer repo and check out the tag for the desired release.
Then, follow the instructions in [dotnet/installer's README](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build) to build .NET from source.
Please see the [support](#support) section below to see which feature branches are currently supported.

## .NET Core 3.1

To build .NET Core 3.1 from source, pick a specific Git tag from this repo with your desired version, or use a release branch to build the latest servicing release of that version. Refer to the tag/branch's README for build instructions:

* [`release/3.1`](https://github.com/dotnet/source-build/tree/release/3.1)


> The source-build repository doesn't currently support Windows. See [source-build#1190](https://github.com/dotnet/source-build/issues/1190).

## Source-build goals

There are two primary goals of the source-build effort:

1. Increase .NET adoption by focusing on making .NET available everywhere

   If .NET was available everywhere - including Linux distributions and package managers like Homebrew - as a first class citizen, it would make .NET a more attractive option for developers who might otherwise look at other languages or runtimes. Users would be more likely to start using and keep using .NET if .NET is available on their development and release platforms of choice.

   To achieve this, we try to make it easier for community and partner maintainers to build and release .NET for their platforms. We need to make sure source-build satisfies the official packaging rules of commonly used Linux distributions, such as [Fedora](https://fedoraproject.org/wiki/Packaging:Guidelines) and [Debian](https://www.debian.org/doc/manuals/maint-guide/build.en.html). Many Linux distributions have similar rules. These rules tend to have three main principles:

   - Limited or no network access
   - Consistent reproducibility
   - Source code for everything

2. Make maintenance of the .NET product easier

   The current way of making changes to .NET during a servicing release is to make changes to individual product repositories and then adjust the dependency versions to flow the changes to the next set of repositories. This is repeated until all the repositories are updated. If there's an issue discovered late in the release cycle, the fixes and the dependency updates need to be re-done quickly, which becomes difficult. It's also difficult to verify that the issue is fixed in the final product. It would be much easier to make and test product-wide changes if we could make atomic changes to one repository and be able to build the whole product based on that source code at once.

   In addition, getting source-build fully functional would provide everyone with a place to try changes that would otherwise require a lot of coordination between multiple repositories - such as landing features that require changes to both the runtime and the SDK.

   For mor details about this Unified Build, see [this overview](https://github.com/dotnet/arcade/blob/main/Documentation/UnifiedBuild/Overview.md).

Source-build can help achieve both these goals by making it easier for everyone to build and release the entire .NET product end-to-end.


## What does the source-build infrastructure do?

Source-build solves common challenges that most developers encounter when trying to build the whole .NET SDK from source.

* .NET is composed of many repositories that need to be built at a specific combination of commits.
* Each repository's build output needs to flow into the next repository's build.
* By default, most .NET repositories download prebuilt binary dependencies from online sources. These are forbidden by typical Linux distribution rules, and interfere with build output flow.
* Some of the binary build dependencies are under a proprietary license, making it difficult to build everything without taking accidental dependencies on non-Open Source code. Many of our community members and partners want to build an Open Source .NET only.
* Flowing the build output automatically also means we can make and test changes that require coordination across a number of repositories.
* Nearly all .NET repositories require the .NET SDK to build. This is a circular dependency, which presents a bootstrapping problem, whether that's bringing up new architectures (eg, riscv), or support new operating systems (eg, FreeBSD).
* Microsoft controls the SDKs used by `dotnet-install.sh` scripts and `Microsoft.*` and `runtime.*` nuget packages at nuget.org; source-build makes it possible for the community to bring up the platforms without Microsoft having to accept/bless things.

Starting with .NET 6, the core source-build infrastructure is integrated into the [dotnet/installer](https://github.com/dotnet/installer/tree/main/src/SourceBuild) repo. The `main` branch on this repo now contains the tooling needed to build .NET's external dependencies from source.

## Support

.NET Source-Build is supported on the oldest available .NET SDK feature update, and on Linux only.
For example, if both .NET 6.0.1XX and 6.0.2XX feature updates are available from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), Source-Build will support 6.0.1XX.
For the latest information about Source-Build support for new .NET versions, please check our [GitHub Discussions page](https://github.com/dotnet/source-build/discussions) for announcements.

* [More information about .NET Versioning](https://docs.microsoft.com/en-us/dotnet/core/versions/)
* [More information about .NET Support Policies](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core)

## License

This repo is licensed under the [MIT](LICENSE.txt) license.
