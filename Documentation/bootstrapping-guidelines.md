# Bootstrapping Guidelines to Build .NET SDK from Source

.NET utilizes itself to build therefore in order to build .NET from source, you first need to acquire or build a bootstrapping .NET SDK. This document provides guideance around acquiring and building this bootstrapping .NET SDK.

The version of the SDK used to source build .NET is referred to as "N-1" (e.g. 7.0.100). The version of the SDK produced by source build is referred to as "N" (e.g. 7.0.101). The previous SDK (e.g. N-1) supplies the tools required to build.

For new major versions or new platforms, you need to acquire or build the bootstrapping SDK as you cannot use a previous source-built SDK. This is to say you cannot use a 6.0 version of the SDK to build a 7.0 SDK. There is an [open issue](https://github.com/dotnet/source-build/issues/3100) to add support for this.

Refer to the [build instructions](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build) to review how to build the .NET SDK from source.

## Building a New .NET Major Version

Building a new .NET major version is two stage process:

**Stage 1:** Build bootstrapping .NET SDK for the targeted platform.

1. Download a platform-native portable Microsoft-built version of the dotnet SDK for bootstrapping as well as the previously-source-built package archive.

    ``` bash
    ./prep.sh
    ```

1. Build the source built .NET SDK.

    ``` bash
    ./build.sh
    ```

**Stage 2:** Use the source built .NET SDK created in stage 1 to build .NET SDK from source. There is no need to run `prep.sh` in this stage.

1. Extract your freshly-built stage 1 SDK to a convenient location.

    ``` bash
    tar -ozxf /<stage1-path>/artifacts/<arch>/Release/dotnet-sdk-<version>-<rid>-tar.gz -C <extracted-stage1-sdk-path>
    ```

1. Build the source built .NET SDK.

    ``` bash
    ./build.sh --with-sdk <extracted-stage1-sdk-path> --with-packages /<stage1-path>/obj/bin/<arch>/blob-feed/packages
    ```

## Building a Servicing Release of .NET

Building a subsequent or servicing version of .NET requires that you have source built the previous version of .NET available as descibed in [Building New .NET Major Version](#building-a-new-net-major-version). If you already have the previous verions of the .NET SDK available, all you have to do is run the following build command.

``` bash
./build.sh --with-sdk <extracted-previously-source-built-sdk-path> --with-packages <extracted-previously-source-built-packages-path>
```

## Building for a New OS/Arch (Supported RID)

**Supported OS**  
[Check](https://learn.microsoft.com/en-us/dotnet/core/install/linux) officially supported linux distributions.  
[List](https://github.com/dotnet/installer/blob/release/7.0.1xx/src/SourceBuild/Arcade/eng/common/templates/job/source-build-run-tarball-build.yml#L12-L16) of Linux distribution officially building and testing using source-build.  
Community building .NET for the [following](https://github.com/dotnet/source-build#net-in-linux-distributions) linux distributions.  If the RID for your platform is already in the [runtime RID graph](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json), you can source-build the SDK without any source changes.

**Supported Archs**  
Officially building and testing for the following architectures - x64, ARM64  
Community building for following architectures - s390x, ARM32, ppc64le

**Supported RIDs**
You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).

**Refer section "Building New .NET Major Version" for the steps to build.**

## Building for New OS (Unsupported)  

**RIDs:**

The RID graph or runtime fallback graph is a list of RIDs that are compatible with each other. You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).
Determine the compatible supported OS to use as host to build. Choose the host with same processor architecture as that of the new targeted platform.

**Stage 1:**
Build bootstrapping .NET SDK and toolset.

- `./prep.sh`
 Downloads platform-native version of .NET SDK and toolset. If you are building on x64, you will get x64.
- `./build.sh`
Create source-built .NET SDK which will be utilized to bootstrap in stage 2.

Now that you have a stage1 SDK which knows about your new RID, you can build stage2 targeting that RID.

**Stage 2:**
Extract the source-built .NET SDK and toolset created in stage 1 to build .NET SDK from source. No need to run prep.sh in this stage.

- `./build.sh --with-sdk /path/to/stage1/sdk --with-packages /path/to/stage1/obj/bin/arch/blob-feed/packages`

**If no compatible OS/platform found**

Use portable SDK (works for .NET 6, but require validation for .NET 7) and follow the steps:

**Stage 0:**

- Get Microsoft portable SDK.
- Update the RID graph (runtime.json) in the Microsoft-built portable SDK with the same changes you will make below to add your new RID to the RID graph.  This should include a fallback to the portable RID (linux-x64 or similar).

**Stage 1:**

- Before building your stage1 SDK, update the RID graph in source to include your new target RID.  For an example, see <https://github.com/dotnet/runtime/pull/74372>.
- Build with Stage 0 SDK using `--with-sdk` with your modified portable SDK.

**Stage 2:**

- Now you have a RID-specific SDK that knows about your new RID.
- Build with Stage 1 SDK as above, using `--with-sdk` and `--with-packages`.

## Building for New Architecture (Unsupported)

**RIDs:**

The RID graph or runtime fallback graph is a list of RIDs that are compatible with each other. You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).

You will need to update the RID graph to include your new platform and runtime IDs.  See <https://github.com/dotnet/runtime/pull/82382> or <https://github.com/dotnet/runtime/pull/75396> for examples.

Building for unsupported architectures require cross-compilaton on the supported platform. Determine the compatible host to build which provides cross-compilation toolchain.  [IBM has published](https://community.ibm.com/community/user/powerdeveloper/blogs/sapana-khemkar/2023/01/13/cross-build-dotnet7-on-x86-ibm-power?CommunityKey=8cc2a1f0-6307-48cb-9178-ace50920244e) a detailed description of how they successfully built .NET 7 for IBM Power.
