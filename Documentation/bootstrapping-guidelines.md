# Bootstrapping Guidelines to Build .NET SDK from Source

To build .NET SDK from source requires previously source-built .NET SDK and toolset which is also referred as bootstrapping .NET SDK and toolset. This document provides guidance for getting or building  bootstrapping .NET SDK and toolset in different scenarios (covering step 2 and step 3 of source-build instructions).

Check out quick [instructions](https://github.com/dotnet/installer/blob/main/README.md#build-net-from-source-source-build) to build SDK using source-build.

## Building New .NET Version

Building New .NET Version is two stage process:  

**Stage 1:**
Build bootstrapping .NET SDK and toolset for the targeted platform.

- prep.sh (args???)  
 This downloads platform-native version of .NET SDK and toolset. So if you are building on x64 machine, you get x64.
- build.sh (args???)
Create source built .NET SDK

**Stage 2:**
Use source built .NET SDK created in stage 1 to build .NET SDK from source. No need to run prep.sh in this stage.

- Build.sh (Args - path to the source built SDK?????)

## Building Subsequent .NET (Servicing)

If you already have source-built .NET SDK and toolset in archive for the targeted platform and .NET version, then you do not need to recreate the bootstrapping .NET SDK and toolset. Subsequent versions will use the N-1 version toolset from the archive to build. Note, N-1 in this context means the previous version of .NET that was already built from source. As an example, to build SDK “N” (7.0.101) using “N-1” (7.0.100).

To build .NET SDK from source -  
 build.sh (args - path to the source built SDK???)

## Building for New OS (Supported, RID Existing)

**Supported OS**  
[Check](https://learn.microsoft.com/en-us/dotnet/core/install/linux) officially supported linux distributions.  
[List](https://github.com/dotnet/installer/blob/release/7.0.1xx/src/SourceBuild/Arcade/eng/common/templates/job/source-build-run-tarball-build.yml#L12-L16) of Linux distribution officially building and testing using source-build.  
Community building .NET for the [following](https://github.com/dotnet/source-build#net-in-linux-distributions) linux distributions.

**Supported RIDs**
You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).

Follow this two stage build process:

**Stage 1:**
Build bootstrapping .NET SDK and toolset.

- prep.sh (args???)  
 Downloads platform-native version of .NET SDK and toolset. So if you are building on x64 you get x64. Build .NET on the targeted platform to get intended platform-native version of .NET.
- build.sh (args???)  
Create source built .NET SDK.

**Stage 2:**
Use source built .NET SDK and toolset created in stage 1 to build .NET SDK from source. No need to run prep.sh in this stage.

- Build.sh (Args?????)

## Building for New OS (Unsupported)  

**RIDs**  
The RID graph or runtime fallback graph is a list of RIDs that are compatible with each other. You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).
Determine the compatible supported OS to use as host to build. Choose the host with same processor architecture as that of the new targeted platform.  

**Stage 1:**
Build bootstrapping .NET SDK and toolset.

- prep.sh (args???)  
 Downloads platform-native version of .NET SDK and toolset. So if you are building on x64 you get x64.
- build.sh (args???)
Create source built .NET SDK which will be utilized to bootstrap in stage 2.

**Stage 2:**
Use source built .NET SDK and toolset created in stage 1 to build .NET SDK from source. No need to run prep.sh in this stage.

- Build.sh (Arg?????)
[UPDATE THE RID GRAPH???]

**If no compatible OS/platform found**
In stage 1, create portable SDK (this step works for .NET 6, but not for .NET 7). [Define the steps in here???]

## Building for New Architecture (Supported, RID Existing)

**Supported Archs**  
Officially building and testing for the following architectures - x64, Arm64  
Community building for following architectures - x64, Arm64, S390, Arm32, IBM Z

**Supported RIDs**
You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).

To build for new supported platform, follow this two stage build process:

**Stage 1:**
Build bootstrapping .NET SDK and toolset.

- prep.sh (args???)  
 Downloads platform-native version of .NET SDK and toolset. So if you are building on x64 you get x64. Build .NET on the targeted platform to get intended platform-native version of .NET.
- build.sh (args???)  
Create source built .NET SDK and toolset.

**Stage 2:**
Use source built .NET SDK and toolset created in stage 1 to build .NET SDK from source. No need to run prep.sh in this stage.

- Build.sh (Args?????)

## Building for New Architecture (Unsupported)

[Define the recommended process and add the steps in this section???]

**RIDs**  
The RID graph or runtime fallback graph is a list of RIDs that are compatible with each other. You can see the list of supported RIDs and the RID graph in the [runtime.json](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json). Learn more about RID catalog in [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids).

Approach 1: Building for unsupported architectures require cross-compilaton on the supported paltform. Determine the compatible host to build which provides cross-compilation toolchain.

Approach 2:
The alternative to this is to support creating a bootstrap SDK directly on the target platform by combining: pre-compiled managed bits, with native assets that are built directly on the platform.
<https://github.com/dotnet/source-build/blob/release/3.1/scripts/bootstrap/buildbootstrapcli.sh>
