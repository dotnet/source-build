# .NET Core Build Script Documentation

The following document includes documentation for the build scripts. Over time, this README is expected to just be a TOC as the instructions move into separate docs.

## Building the .NET Core SDK

The scripts are supported on Windows, macOS and Linux. The scripts are based on PowerShell on Windows and Bash on macOS and Linux.

### Syncing

This repo uses submodules so remember on fresh clones or when updating/switching branches to run

```
git submodule update --init --recursive
```

### Building

```console
./build.{cmd|sh}
```

## Building one repo

By default we build the cli and its dependencies but the default root repository to build can be passed in. For example, if you just want to build the .NET Core Runtime, you would just build the `core-setup` repo and its dependencies:

```console
./build.{cmd|sh} /p:RootRepo=core-setup
```

Sometimes you want to just iterate on a single repo build and not rebuild all dependencies that can be done passing another property.

```console
./build.{cmd|sh} /p:RootRepo=core-setup /p:SkipRepoReferences=true
```

### Cleaning

```console
./clean.{cmd|sh}      # Cleans root binary directory and fully git cleans and hard resets all submodules
./clean.{cmd|sh} -a   # Does a full git clean on the root repo as well as fully git cleans and hard resets all submodules
```

## Building .NET Core SDK and a Source tarball

You can build the .NET Core SDK and generate a source tarball in a specific directory. This script is bash-only and is intended to be run on Linux.

```console
./build-source-tarball.sh <path-to-tarball-root>
tar -czf <tarball-destination> --directory <path-to-tarball-root> "."
```

After this completes, you can take the output tarball to another machine and build .NET Core again without an internet connection.

```console
tar -xf <tarball-destination> -C <path-to-extraction-root>
cd <path-to-extraction-root>
./build.sh
```
## Building a custom .NET Runtime

You can also build a .NET Core Runtime with custom changes in order to test locally the produced runtime with the affected changes.

The .NET Core Runtime consists of 4 repos, core-setup at the top of the stack (which produces the runtime), standard, corefx (BCL repo), coreclr (Runtime repo). 

This means that in order to get a runtime you'll need to build the source-build repo with the `/p:RootRepo=core-setup` parameter, this will automatically build coreclr, standard and corefx. Source-Build is composed by git submodules, so the first thing you need to run before doing anything is:

```console
git submodule --init --recursive
```

This will initialize the submodules and clone the repos under the src folder if they haven't been initialized. Note that this will update every submodule to their tracking commit checked in to the `source-build` repo . However you can go to each repo indivually, add custom remotes and checkout certain branches containing your changes.

### Example .NET Runtime build from source
Let's say that you want to produce a runtime that has a new API that it's implementation lives in coreclr and you want to create a .NET Core console app that uses it to test it without waiting for a new SDK or Runtime to be produced by official builds. Imagine we will add an API that just throws in Hashtable. 

Hashtable implementation lives in coreclr and it's APIs are exposed in corefx in the System.Runtime.Extensions.cs contract. So in my local coreclr repo I will just add Hashtable.cs the following API:

```cs
public static void PNSE()
{
    throw new PlatformNotSupportedException();
}
```

Then in my local corefx repo let's expose it in System.Runtime.Extensions.cs in the Hashtable class:

```cs
public static void PNSE() { }
```

Of course we need to commit this changes in our current repos. Once we've commited this locally, let's move to the source-build repo.

Once in the source-build in our commmand prompt or terminal, lets navigate to `src/coreclr`. Once there, we will need to add a remote to the local coreclr repo, in example:
```console
git remote add local C:\repos\coreclr
```

Then, let's fetch the changes from our repo, by running:
```console
git fetch local
```

Once we've fetched the changes, we just need to checkout the branch where we made the changes:
```console
git checkout branchWithChanges
```

Just repeat this steps under `src/corefx` as well, to pull the corefx changes. Once we've done that, let's navigate to the `source-build` root and run:

```console
build.{cmd|sh} /p:RootRepo=core-setup
```

The build detects you've changed the coreclr and corefx commits and offers to move them back to the tracked commits. Press `n` when you see the following message to decline and keep your changes:

```console
 WARNING: submodule src/corefx, currently at 831264e53e5b9333850baa659af8a2857a9cb9b7, has diverged from checked-in
 version 5b7674e4ae5cc782e99f50b2919dfdeb29106a46
 If you are changing a submodule branch or moving a submodule backwards, this is expected.
 Should I checkout src/corefx to the expected commit 5b7674e4ae5cc782e99f50b2919dfdeb29106a46 [N]o / [y]es / [q]uit
 ```

> To skip this check and avoid pressing `n` for each build, you can either:
>  * Set the environment variable `SOURCE_BUILD_SKIP_SUBMODULE_CHECK=1`.
>  * Stage the submodule changes with `git add src/corefx` and/or `git add src/coreclr`.

Once the build is done, we will have a .NET Runtime containing the `Hashtable.PNSE()` API that can be used with our local cli in .NET Core projects.

### How to use the produced Runtime

The produced runtime will be under `bin/obj/{architecture}/{configuration}/blob-feed/packages`.

Now create a new .NET Core project:
```console
dotnet new Console -o source-build-test
```

In your new project add a new NuGet.config to point to the Microsoft.NETCore.App and runtime packages.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <!-- NOTE: Leave this file here and keep it in sync with list in dir.props. -->
  <!-- The command-line doesn't need it, but the IDE does.                    -->
  <packageSources>
    <clear/>
    <add key="local feed" value="C:\repos\source-build\bin\obj\x64\Release\blob-feed\packages" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```

Then in your csproj we need to set the Runtime version:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    <RootNamespace>source_build_test</RootNamespace>
    <RuntimeFrameworkVersion>2.2.0-preview1-26509-04</RuntimeFrameworkVersion>
    <NETCoreAppMaximumVersion>2.2</NETCoreAppMaximumVersion>
  </PropertyGroup>

</Project>
```

Note that the `TargetFramework` value needs to be the minimum or later framework that the Runtime supports. Therefore if there is no cli produced yet or you don't have installed a dotnet cli that supports that `TargetFramework` you need to add the property `NETCoreAppMaximumVersion` to match the version framework you want to target.

If you don't set this property, you will see an error similar to this one:

`C:\Program Files\dotnet\sdk\2.1.300\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.TargetFrameworkInference.targets(137,5): error : The current .NET SDK does not support targeting .NET Core 2.2.  Either target .NET Core 2.1 or lower, or use a version of the .NET SDK that supports .NET Core 2.2.`


Also, `RuntimeFrameworkVersion` needs to match whatever version of the runtime was produced.

After that you're all set to use your new API and test it with a locally produced runtime.

```cs
using System;
using System.Collections;

namespace source_build_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable.PNSE();
        }
    }
}
```

In order to run the app you have two options:

1. Publish the app:
   - Run `dotnet publish -r RID`. You more information about publish and RID in [this guide](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog).
   - Run produced executable in publish directory.
2. Use `dotnet run`:
   - In order to use `dotnet run` you will have to install the produced runtime before running the app. Note that installing the runtime, whenever a real runtime for the current produced version is released, if you forget to delete/uninstall the custom runtime, it could cause issues.