# Bootstrapping Guidelines to Build .NET SDK from Source
To build the .NET from source for version "N" (7.0.101), you will need "N-1" version of .NET SDK (7.0.100) supplying the tools required to build, referred to as bootstrapping .NET SDK and toolset. For new major version or new platform, you need to acquire or build the bootstrapping SDK and toolset as you cannot use the previous source-built SDK. As in to build 7.0.100, you cannot use 6.0.400.

This document provides guidance for acquiring or building bootstrapping .NET SDK and toolset in different scenarios (covering step 2 and step 3 of source-build instructions).
Check out quick [instructions](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build) to build SDK using source-build.

On high-level, you need to acquire .NET SDK and toolset for the targeted platform, create source-built SDK, and use either the acquired or source-built SDK to fully build from source.

## Building New .NET Major Version
Building new .NET major version is two stage process:  

**Stage 1:**
Build bootstrapping .NET SDK and toolset for the targeted platform.  `prep.sh` downloads a portable Microsoft-built version of the dotnet SDK for bootstrapping as well as an archive of already-built packages called the previously-source-built archive.

- `./prep.sh`
 This downloads platform-native version of .NET SDK and toolset. So if you are building on x64 machine, you get x64.

- `./build.sh`
Create source built .NET SDK.

**Stage 2:**
Use source built .NET SDK created in stage 1 to build .NET SDK from source. No need to run prep.sh in this stage.  Before running this command, extract your freshly-built stage1 SDK from `bin/arch/dotnet-sdk-version.tar.gz` to a convenient location.

- `./build.sh --with-sdk /path/to/stage1/sdk --with-packages /path/to/stage1/obj/bin/arch/blob-feed/packages`

## Building Subsequent .NET (Servicing)

If you already have source-built .NET SDK and toolset in archive for the targeted platform and .NET version, then you do not need to create the bootstrapping .NET SDK and toolset. Subsequent versions will use the N-1 version toolset from the archive to build. Note, N-1 in this context means the previous version of .NET that was already built from source. As an example, to build SDK “N” (7.0.101) using “N-1” (7.0.100).  These paths will vary based on where your distro installs these.

To build .NET SDK from source -  
- `./build.sh --with-sdk /usr/bin/dotnet --with-packages /lib/dotnet/previously-source-built`

## Building for New OS/Arch (Supported, RID Existing)

**Supported OS**  
[Check](https://learn.microsoft.com/en-us/dotnet/core/install/linux) officially supported linux distributions.  
[List](https://github.com/dotnet/installer/blob/release/7.0.1xx/src/SourceBuild/Arcade/eng/common/templates/job/source-build-run-tarball-build.yml#L12-L16) of Linux distribution officially building and testing using source-build.  
Community building .NET for the [following](https://github.com/dotnet/source-build#net-in-linux-distributions) linux distributions.

**Supported Archs**  
Officially building and testing for the following architectures - x64, ARM64  
Community building for following architectures - s390x, ARM32, ppc64le

**Supported RIDs**
You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).

**Refer section "Building New .NET Major Version" for the steps to build.**

## Building for New OS (Unsupported)  

**RIDs**  
The RID graph or runtime fallback graph is a list of RIDs that are compatible with each other. You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).
Determine the compatible supported OS to use as host to build. Choose the host with same processor architecture as that of the new targeted platform.  

**Stage 1:**
Build bootstrapping .NET SDK and toolset.

- `./prep.sh`
 Downloads platform-native version of .NET SDK and toolset. So if you are building on x64 you get x64.
- `./build.sh`
Create source built .NET SDK which will be utilized to bootstrap in stage 2.

**Stage 2:**
Use source built .NET SDK and toolset created in stage 1 to build .NET SDK from source. No need to run prep.sh in this stage.

- `./build.sh --with-sdk /path/to/stage1/sdk --with-packages /path/to/stage1/obj/bin/arch/blob-feed/packages`
[NO NEED TO UPDATE THE RID GRAPH, though parameters may need to be passed?????]

**If no compatible OS/platform found**

Use portable SDK (works for .NET 6, but require validation for .NET 7) and follow the steps:

**Stage 0:**

- Get Microsoft protable SDK
- Update RID graph to include new RID

**Stage 1:**

- Update RID graph in source
- Build with Stage 0 SDK

**Stage 2:**

- Build with Stage 1 SDK

## Building for New Architecture (Unsupported)

[Define the recommended process and add the steps in this section???]

**RIDs**  
The RID graph or runtime fallback graph is a list of RIDs that are compatible with each other. You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).

Building for unsupported architectures require cross-compilaton on the supported paltform. Determine the compatible host to build which provides cross-compilation toolchain.

[Define the steps?????]
