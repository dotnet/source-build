# .NET Source-Build

[![Join the chat at https://gitter.im/dotnet/source-build](https://badges.gitter.im/dotnet/source-build.svg)](https://gitter.im/dotnet/source-build?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

This repository helps .NET SDK and .NET Runtime package maintainers comply with common Linux distribution guidelines.

## .NET 6.0

### Prerequisites

The dependencies for building .NET 6.0 from source can be found [here](https://github.com/dotnet/runtime/blob/main/docs/workflow/requirements/linux-requirements.md).

### Building

.NET 6.0 is built from source using the [dotnet/installer](https://github.com/dotnet/installer) repo.
...
For example, in Fedora 33:

1. Clone the repo and check out the tag for the desired release.
    ```bash
    git clone https://github.com/dotnet/installer
    cd installer/
    git checkout v6.0.100-rtm.21527.11
    ```

3. Create a .NET source tarball.

   ```bash
   ./build.sh /p:ArcadeBuildTarball=true /p:TarballDir=/path/to/place/complete/dotnet/sources
   ```

   This fetches the complete .NET source code and creates a tarball at `artifacts/packages/<Release|Debug>/Shipping/`.
   The extracted source code is also placed at `/path/to/place/complete/dotnet/sources`.
   The source directory should be outside (and not somewhere under) this repository.

3. Prep the source to build on your distro.

    ```bash
    cd /path/to/complete/dotnet/sources
    ./prep.sh
    ```

    This downloads a .NET SDK and a number of .NET packages and other prebuilts needed to build .NET from source.

    > On Linux distros other than Fedora 33, an additional bootstrapping step is required.  After running `prep.sh` above, run the following:
    >
    > ```bash
    > tar xf ../packages/archive/Private.SourceBuilt.Artifacts.*.tar.gz
    > sed -i -E 's|<MicrosoftNETHostModelPackageVersion>6.0.0-rtm.21521.1</|> <MicrosoftNETHostModelPackageVersion>6.0.0-rtm.21521.4</|' PackageVersions.props
    > sed -i -E 's|<MicrosoftNETHostModelVersion>6.0.0-rtm.21521.1</|> <MicrosoftNETHostModelVersion>6.0.0-rtm.21521.4</|' PackageVersions.props
    > tar czf ../packages/archive/Private.SourceBuilt.Artifacts.*.tar.gz *
    > ```
    > 
    > This issue is being tracked [here](https://github.com/dotnet/source-build/issues/2599).

4. Build the .NET SDK

    `./build.sh`

    This builds the entire .NET SDK from source. The resulting SDK is placed at `artifacts/x64/Release/dotnet-sdk-6.0.100-fedora.33-x64.tar.gz`.

5. (Optional) Unpack and install the .NET SDK

    ```bash
    mkdir -p $HOME/dotnet && tar zxf artifacts/x64/Release/dotnet-sdk-6.0.100-fedora.33-x64.tar.gz -C $HOME/dotnet
    ln -s $HOME/dotnet/dotnet /usr/bin/dotnet
    ```
    
    To test your source-built SDK, run the following:

    ```bash
    dotnet --info
    ```

## .NET 5.0 and .NET Core 3.1
To build older versions of the .NET SDK from source, pick a specific Git tag with your desired version, or use a release branch to build the latest servicing release of that version. Refer to the tag/branch's README for build instructions:

* [`release/5.0`](https://github.com/dotnet/source-build/tree/release/5.0)
* [`release/3.1`](https://github.com/dotnet/source-build/tree/release/3.1)

The scripts are written for Bash and supported on macOS and Linux.

> The source-build repository doesn't currently support Windows. See [source-build#1190](https://github.com/dotnet/source-build/issues/1190).

# Source build goals

The key goal of source-build is to satisfy the official packaging rules of commonly used Linux distributions, such as [Fedora](https://fedoraproject.org/wiki/Packaging:Guidelines) and [Debian](https://www.debian.org/doc/manuals/maint-guide/build.en.html). Many Linux distributions have similar rules. These rules tend to have two main principles: consistent reproducibility, and source code for everything.

A secondary goal of source-build is to allow .NET contributors to build a .NET SDK with coordinated changes in multiple repositories. However, the developer experience is significantly better in individual repositories and, if possible, contributors should make and test changes in the target repo, not source-build.

## What does the source-build infrastructure do?

Source-build solves common challenges that most developers encounter when trying to build the whole .NET SDK from source.

* .NET is composed of many repositories that need to be built at a specific combination of commits.
* Each repository's build output needs to flow into the next repository's build.
* By default, most .NET repositories download prebuilt binary dependencies from online sources. These are forbidden by typical Linux distribution rules, and interfere with build output flow.
* Nearly all .NET repositories require the .NET SDK to build. This is a circular dependency, which presents a bootstrapping problem.

The source-build repository contains scripts and build logic to help Linux distribution maintainers address these challenges.

## License

This repo is licensed under the [MIT](LICENSE.txt) license.
