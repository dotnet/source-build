# Standard Repo API

In order to build the .NET Core product from its constiuent repos, there needs to be a standardized set of actions each repo can perform. Not only will this make building the repos easier, it will make it easier to onboard new repos. If a new repo conforms to the standardized set of actions, source-build can easily start consuming it.

This document describes the basic structure of this "Repo API", and the requirements imposed on a repo that needs to participate in source-build.

## build.cmd/sh

Each repo will have two files that implement the repo API:

* build.cmd
* build.sh

The `.cmd` file will be called when running on Windows, while the `.sh` file will be called on all other operating systems.

These scripts will contain the logic necessary in order to build, test, publish the repo's assets.

source-build will invoke these scripts on each repo passing in:

1. An action to perform
1. A set of parameters

Individual repos are free to implement more features in these build scripts than what is required by source-build. For example, a repo may want to provide a default action. These extra behaviors are not defined by source-build.

### Actions

There will be a number of actions source-build will need the repos to implement. As more scenarios are designed and implemented, more commands will specified. The first action necessary is the `Build` action:

1. `Build` - Assemble the product from the current source contained in the repo.

Actions will take the form of `ActionName` and are the first parameter passed to the build script. Action names are case insensitive.

### Parameters

Each action above will take a set of parameters used to pass information into the action and control its behavior.

Parameters will take the form of `-ParameterName ParameterValue`. This form avoids any confusion with file paths on Unix machines by not using `/` to start the argument and works well in both powershell and shell script parsing. Every parameter passed by source-build will have a value, even if that value is just `true`.

In order to avoid conflicts between existing properties (MSBuild or otherwise) used by the repos and the properties passed in by source-build, source-build will append a prefix to every property name it passes in: `DotNet`.

#### Detecting build from source

Some repos build more projects than are necessary to build the .NET Core stack. For example, the `dotnet/roslyn` repo builds the C# compiler, which is needed, but it also builds Visual Studio extensions, which aren't needed. These VS extensions cannot be built without using an external dependency on tooling that isn't available when building from source.

In order to tell repos that these projects shouldn't be built, source-build will pass the following parameter

`-DotNetBuildFromSource true`

#### Available tools

In order for repos to build, they need tools in order to do the build (ex. MSBuild). These tools are not generally available on all supported operating systems. As such, many repos today have the ability to pull these tools from the internet during the build.

However, there are a couple problems with each repo downloading its own toolset.

1. Different versions can cause inconsistencies
1. It takes a non-trivial amount of time to download the toolset, if every repo does it during the complete .NET Core build, it will add a lot of overhead to the build.
1. The version downloaded from a the official location may not work on a new architecture or platform or even a different version of a linux distribution. Using one version supplied by source-build (which might be hand-fixed to work) will address this.
1. Many Linux distributions only carry (will carry) one or two versions of tools, not 8 or 10 different versions. For .NET Core to work there, we will want to fix all repos to use one set of tools.

To solve this, source-build will have a set of common tools available that it will pass into each repos build.

First, a [.NET Core SDK](https://www.microsoft.com/net/download/core#/sdk) will be available for repos to be able to invoke MSBuild, NuGet, etc. The path to the folder containing the `dotnet` executable will be available using the

`-DotNetCoreSdkDir`

property. This can be used to call `dotnet restore`, `dotnet build`, `dotnet publish`, `dotnet msbuild`, or any other CLI verb on the repo's projects.

Second, a common set of tools used by the `dotnet` org repos is [BuildTools](https://github.com/dotnet/buildtools). This will be available using the

`-DotNetBuildToolsDir`

property. This can be used to invoke any current or future tool that is part of BuildTools. It is not required that each repo use BuildTools, but if the repo wants to, it can get the tools from this property.

Note that paths will always be enclosed in double quotes `"/path/to"` on all operating systems.

As more toolsets are identified, source-build can and will make more toolsets available when necessary.

### Example

Here is an example of a call source-build will make on the `dotnet/corefx` repo:

```
/path/to/corefx/build.sh Build -DotNetBuildFromSource true -DotNetCoreSdkDir "/path/to/dotnet" -DotNetBuildToolsDir "/path/to/buildtools"
```

> **Note:** Not all properties have been specified above. As each action gets designed in detail, more `DotNet` properties will be specified. For example, the `Build` action above isn't getting told which dependency versions to use.

### .rsp files

As you can imagine, specifying properties this way is going to create really long command line strings. On Windows machines, there is a limit to how many characters can be specified. It also becomes really hard to diagnose and reproduce build errors. Parsing large command lines is rather difficult, especially when there are many file paths.

To solve this issue, we could implement a response (.rsp) file, where each command line argument is on a line in a text file. Then that text file is passed into the `build` with a `@` character preceeding the file name.

`build.sh @/path/to/currentBuildParameters.rsp`

Where `currentBuildParameters.rsp` contains

```
Build
-DotNetBuildFromSource true
-DotNetCoreSdkDir "/path/to/dotnet"
-DotNetBuildToolsDir "/path/to/buildtools"
```

## Future Work

As we get more detailed requirements and specifications for the different pieces of source-build, more properties and actions will be documented. This document outlined the base framework for the Repo API. Other design specs will build on top and further define these APIs.
