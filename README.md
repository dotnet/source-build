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

The key goal of source-build is to satisfy the official packaging rules of commonly used Linux distributions, such as [Fedora](https://fedoraproject.org/wiki/Packaging:Guidelines) and [Debian](https://www.debian.org/doc/manuals/maint-guide/build.en.html). Many Linux distributions have similar rules. These rules tend to have two main principles: consistent reproducibility, and source code for everything.

A secondary goal of source-build is to allow .NET contributors to build a .NET SDK with coordinated changes in multiple repositories. However, the developer experience is significantly better in individual repositories and, if possible, contributors should make and test changes in the target repo, not source-build.

## What does the source-build infrastructure do?

Source-build solves common challenges that most developers encounter when trying to build the whole .NET SDK from source.

* .NET is composed of many repositories that need to be built at a specific combination of commits.
* Each repository's build output needs to flow into the next repository's build.
* By default, most .NET repositories download prebuilt binary dependencies from online sources. These are forbidden by typical Linux distribution rules, and interfere with build output flow.
* Nearly all .NET repositories require the .NET SDK to build. This is a circular dependency, which presents a bootstrapping problem.

Starting with .NET 6, the core source-build infrastructure is integrated into the [dotnet/installer](https://github.com/dotnet/installer/tree/main/src/SourceBuild) repo. The `main` branch on this repo now contains the tooling needed to build .NET's external dependencies from source.

## Comprehensive Guidelines
This section provides detailed end-to-end guidelines on bootstrapping, building, packaging, and more, covering different scenarios for source-build.
* [System Requirements]()
* [Quick Build Instructions](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build)
* [Bootstrapping]()
* [Packaging](https://learn.microsoft.com/en-us/dotnet/core/distribution-packaging)
* [Troubleshooting]()

## .NET in Linux Distributions
| Distro | Package Feed | Maintainer |
|---|---|---|
| Alpine | [Community](https://pkgs.alpinelinux.org/packages?name=dotnet*&branch=v3.16&repo=&arch=&maintainer=) | [@ayakael](https://github.com/ayakael) |
| Arch Linux | [Community](https://archlinux.org/packages/?q=dotnet)<br>[Arch User Repo](https://aur.archlinux.org/packages?K=dotnet) | [@alucryd](https://github.com/alucryd) |
| CentOS Stream | [CentOS Stream Mirror](http://mirror.stream.centos.org/9-stream/AppStream/x86_64/os/Packages/) | [@omajid](https://github.com/omajid) |
| [Fedora](https://fedoraproject.org/wiki/DotNet) | [Default](https://packages.fedoraproject.org/search?query=dotnet) | [@omajid](https://github.com/omajid), [@crummel](https://github.com/crummel) |
| Homebrew | [Formula](https://formulae.brew.sh/formula/dotnet) | [@asbjornu](https://github.com/asbjornu) |
| [Red Hat Enterprise Linux](https://developers.redhat.com/products/dotnet/overview) | [Default](https://access.redhat.com/documentation/en-us/net/6.0) | [@omajid](https://github.com/omajid) |
| [Ubuntu](https://canonical.com/blog/install-dotnet-on-ubuntu) | [Default](https://packages.ubuntu.com/search?suite=default&section=all&arch=any&keywords=dotnet&searchon=names)<br>[Personal Package Archives](https://launchpad.net/ubuntu/+ppas?name_filter=dotnet) | [@mirespace](https://github.com/mirespace) |


## Support

.NET Source-Build is supported on the oldest available .NET SDK feature update for each major release, and on Linux only.
For example, if .NET `6.0.1xx`, `6.0.2xx`, `7.0.1xx`, and `7.0.2xx` feature updates are available from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), Source-Build will support `6.0.1xx` and `7.0.1xx`.

For the latest information about Source-Build support for new .NET versions, please check our [GitHub Discussions page](https://github.com/dotnet/source-build/discussions) for announcements.

* [More information about .NET Versioning](https://docs.microsoft.com/en-us/dotnet/core/versions/)
* [More information about .NET Support Policies](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core)

## License

This repo is licensed under the [MIT](LICENSE.txt) license.
