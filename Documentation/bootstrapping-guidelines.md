# Bootstrapping Guidelines to Build .NET from Source

.NET utilizes itself to build therefore in order to build .NET from source, you
first need to acquire or build a bootstrapping .NET SDK. This document provides
guidance around acquiring and building this bootstrapping .NET SDK.

The version of the SDK used to source build .NET is referred to as "N-1" (e.g.
8.0.100). The version of the SDK produced by source build is referred to as "N"
(e.g. 8.0.101). The previous SDK (e.g. N-1) supplies the tools required to
build.

For new major versions or new platforms, you need to acquire or build the
bootstrapping SDK as you cannot use a previous source-built SDK. This is to say
you cannot use a 8.0 version of the SDK to build a 9.0 SDK.

Bootstrapping typically requires an exception in the distro packaging guidelines
(e.g. [Fedora Bootstrapping
Guidelines](https://docs.fedoraproject.org/en-US/packaging-guidelines/#bootstrapping)).

Refer to the [build
instructions](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build)
to review how to build the .NET SDK from source.

## Scenarios

There are three major scenarios for bootstrapping:

1. [Building on a supported platform (Using RID known to
   .NET)](#building-on-a-supported-platform-using-rid-known-to-net)
1. [Building for New OS (Using a RID unknown to
   .NET)](#building-for-new-os-using-a-rid-unknown-to-net)
1. [Building for New Architecture (Using a RID unknown to
   .NET)](#building-for-new-architecture-using-a-rid-unknown-to-net)

## Building on a supported platform (Using RID known to .NET)

To find out if your platform is supported you must first determine its
[RID](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog).  You can then
check if it's supported by looking at the RID graph in the
[runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json).

Building .NET for the first time is a two stage process:

**Stage 1:** Build bootstrapping .NET SDK for the targeted platform.

1. Download a platform-native portable Microsoft-built version of the dotnet SDK
   for bootstrapping as well as the previously-source-built package archive.

    ``` bash
    ./prep-source-build.sh
    ```

1. Build the source built .NET SDK.

    ``` bash
    ./build.sh --source-only
    ```

**Stage 2:** Use the source-built .NET SDK and source-built artifacts created in
stage 1 to build .NET SDK from source.

1. Extract your freshly-built stage 1 SDK to a convenient location.

    ``` bash
    tar -ozxf /<stage1-path>/artifacts/assets/Release/dotnet-sdk-<version>-<rid>-tar.gz -C <extracted-stage1-sdk-path>
    ```

1. Extract your freshly-built stage 1 source-built artifacts to a convenient
   location.

    ```bash
    tar -ozxf /<stage1-path>/artifacts/assets/Release/Private.SourceBuilt.Artifacts.<version>-<rid>-.tar.gz -C <extracted-stage1-artifacts-path>
    ```

1. Prep the build.

    ```bash
    ./prep-source-build.sh --no-sdk --no-artifacts --with-sdk <extracted-stage1-sdk-path> --with-packages <extracted-stage1-artifacts-path>
    ```

1. Build the source built .NET SDK.

    ``` bash
    ./build.sh --source-only --with-sdk <extracted-stage1-sdk-path> --with-packages <extracted-stage1-artifacts-path>
    ```

## Building for New OS (Using a RID unknown to .NET)

Building for an OS that Microsoft does not currently build the SDK for is
possible but requires more work.  If [Microsoft
produces](https://dotnet.microsoft.com/en-us/download/dotnet) a portable SDK for
your platform (e.g. amd64 and arm64), you can follow the two-step process below.

**RIDs:**

The RID graph or runtime fallback graph is a list of RIDs that are compatible
with each other. You can see the list of supported RIDs and the RID graph in the
[runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json).
Learn more about RID catalog
[here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).

If a compatible RID is found, you can use a compatible supported OS as host to
build. Choose a host with same processor architecture as that of the new
targeted platform.  If you choose this option, the RID of the resulting SDK will
be that of the host.  If this is acceptable follow the instructions in [Building
on a supported platform (Using RID known to
.NET)](#building-on-a-supported-platform-using-rid-known-to-net) using a
compatible host OS.

If no compatible RID is found or you want a RID specific SDK use the folloring
the steps (works for .NET 6, but requires validation for .NET 7):

**Stage 0:**

1. Get Microsoft portable SDK.
1. Update the RID graph (runtime.json) in the Microsoft-built portable SDK with
   the same changes you will make below to add your new RID to the RID graph.
   This should include a fallback to the portable RID (linux-x64 or similar).

**Stage 1:**

1. Update the RID graph in source with the same changes made in Stage 0.  For an
   example, see <https://github.com/dotnet/runtime/pull/74372>.
1. Build with Stage 0 SDK using `--with-sdk` with your modified portable SDK.
   See the Stage 1 instructions in [Building on a supported platform (Using RID
   known to .NET)](#building-on-a-supported-platform-using-rid-known-to-net).

**Stage 2:**

1. Now you have a RID-specific SDK that knows about your new RID, build with
   Stage 1 SDK as done in [Building on a supported platform (Using RID known to
   .NET)](#building-on-a-supported-platform-using-rid-known-to-net).

## Building for New Architecture (Using a RID unknown to .NET)

Building for an architecture that Microsoft does not currently build the SDK for
is possible but requires more work.

**RIDs:**

The RID graph or runtime fallback graph is a list of RIDs that are compatible
with each other. You can see the list of supported RIDs and the RID graph in the
[runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json).
Learn more about RID catalog in
[here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).

You will need to update the RID graph to include your new platform and runtime
IDs.  See <https://github.com/dotnet/runtime/pull/82382> or
<https://github.com/dotnet/runtime/pull/75396> for examples.

Building for unsupported architectures require cross-compilaton on the supported
platform. Determine the compatible host to build which provides
cross-compilation toolchain.  [IBM has
published](https://community.ibm.com/community/user/powerdeveloper/blogs/sapana-khemkar/2023/01/13/cross-build-dotnet7-on-x86-ibm-power?CommunityKey=8cc2a1f0-6307-48cb-9178-ace50920244e)
a detailed description of how they successfully built .NET 7 for IBM Power.

While this is a more complicated scenario that may differ from platform to
platform, the steps will be roughly:

**Stage 0:**

1. Cross compile an SDK (using prebuilts) on x64 for target platform (this
   process may be quite long and involved and include setting up a rootfs for
   your architecture).
2. Cross compile the runtime repo (on x64 for target platform, generally done as
   part of previous step) and save the nuget packages, use these to augment the
   Microsoft-built previously-source-built archive.

**Stage 1:**

1. Use the cross-compiled SDK and augmented previously-source-built-archive to
   build a stage 1 SDK.  See the Stage 1 instructions in [Building on a
   supported platform (Using RID known to
   .NET)](#building-on-a-supported-platform-using-rid-known-to-net).

**Stage 2:**

1. Use your stage 1 SDK to build a stage 2 SDK, pointing it to the SDK and
   previously-source-built archives from stage 1.  See the Stage 2 instructions
   in [Building on a supported platform (Using RID known to
   .NET)](#building-on-a-supported-platform-using-rid-known-to-net).

## Building a Servicing Release of .NET

Building a subsequent or servicing version of .NET requires that you have source
built the previous version of .NET available as descibed in one of the [building
scenarios](#scenarios). Once you have a previous verion of the .NET SDK
available, all you have to do is run the following build command.

``` bash
./build.sh --source-only --with-sdk <extracted-previously-source-built-sdk-path> --with-packages <extracted-previously-source-built-packages-path>
```
