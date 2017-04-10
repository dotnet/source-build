# Build from Source .NET Stack

The corefx repo contains the library implementation (called "CoreFX") for [.NET Core](http://github.com/dotnet/core). It includes System.Collections, System.IO, System.Xml, and many other components. You can see more information in [Documentation](Documentation/README.md). The corresponding [.NET Core Runtime repo](https://github.com/dotnet/coreclr) contains the runtime implementation (called "CoreCLR") for .NET Core. It includes RyuJIT, the .NET GC, and many other components. Runtime-specific library code - namely [System.Private.Corelib](https://github.com/dotnet/coreclr/tree/master/src/mscorlib) - lives in the CoreCLR repo. It needs to be built and versioned in tandem with the runtime. The rest of CoreFX is agnostic of runtime-implementation and can be run on any compatible .NET runtime.

## Instructions on Supported platforms

1. bootstrap.sh
2. Tools/dotnetcli/dotnet restore tasks/Microsoft.Dotnet.Build.Tasks/Microsoft.Dotnet.Build.Tasks.csproj
3. Tools/dotnetcli/dotnet build tasks/Microsoft.Dotnet.Build.Tasks/Microsoft.Dotnet.Build.Tasks.csproj
4. $CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj ${ADDITIONALARGS[@]} /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true
5. $CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj /t:Sync
6. $CLIPATH/dotnet $SDKPATH/MSBuild.dll $SCRIPT_ROOT/build.proj ${ADDITIONALARGS[@]} /t:GenerateSourceTarball