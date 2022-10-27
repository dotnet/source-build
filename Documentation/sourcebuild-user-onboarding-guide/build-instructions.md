# Build .NET from Source

**Check the prerequisites before starting the build **
## Fetch the Source Code

**For .NET 6.0/.NET 7.0,**
1. Clone the dotnet/installer repo and check out the tag for the desired release. Please see the support section below to see which feature branches are currently supported. 
 
2. Create a .NET source tarball 

```code
 ./build.sh /p:ArcadeBuildTarball=true /p:TarballDir=/path/to/place/complete/dotnet/sources 
```
 This fetches the complete .NET source code and creates a tarball at artifacts/packages/Release/Shipping/. The extracted source code is also placed at /path/to/place/complete/dotnet/sources. The source directory should be outside (and not somewhere under) the installer directory.

**For .NET 8.0 (Preview),**
Coming Soon

## Prep to build .NET from Source (Bootstrap)

```code
 cd /path/to/complete/dotnet/sources 
 ./prep.sh 
```
On non-amd64 platforms, use ./prep.sh --bootstrap instead. This issue is being tracked [here](https://github.com/dotnet/source-build/issues/2758).
This step downloads a .NET SDK and several .NET packages needed to build .NET from source.  

To learn more about the bootstrapping refer in here.

## Build .NET SDK from source
```code
./build.sh --clean-while-building  
```
Once the build is successful, the built SDK tarball is placed at: `artifacts/${ARCHITECTURE}/Release/dotnet-sdk-${SDK_VERSION}-${RUNTIME_ID}.tar.gz`
`${ARCHITECTURE}` is your platform architecture (probably x64)  
`${SDK_VERSION}` is the SDK version you are building  
`${RUNTIME_ID}` is your OS name and architecture (something like debian.9-x64 or fedora.33-x64)  
For example, building a 3.1.105 SDK on an x64 (aka x86_64) platform running Fedora 32 will produce `artifacts/x64/Release/dotnet-sdk-3.1.105-fedora.32-x64.tar.gz`
 
**Parameters**  
--online: To add online NuGet restore sources to the build. This is useful for testing unsupported releases that don't yet build without downloading pre-built binaries from the internet.  
--help: To see more information about supported build options.  
/p:RootRepo=<repo name>: To build a specific repo use this argument, e.g. `/p:RootRepo=roslyn`.  This is mostly useful for debugging.  All repos that the `RootRepo` depends on will also be built unless you also specify `/p:SkipRepoReferences=true`.  
/p:UseSystemLibraries=true or /p:UseSystemLibraries=false: Use to explicitly link against the system libraries. false will make it dlopen any required libraries at runtime.  
/p:UseSystemLibunwind=true or /p:UseSystemLibunwind=false: Use either the system libunwind or the version of libunwind included in the dotnet/runtime repository. Defaults to the value of UseSystemLibraries.  
/p:SkipRepoReferences=true: just iterate on a single repo build and not rebuild all dependencies