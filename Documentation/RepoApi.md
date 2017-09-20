# Standard Repo API

In order to build the .NET Core product from its constiuent repos, there needs to be a standardized set of actions
each repo can perform. Not only will this make building the repos easier, it will make it easier to onboard
new repos. If a new repo conforms to the standardized set of actions, source-build can easily start consuming it.

This document describes the basic structure of this "Repo API", and the requirements imposed on a repo that needs
to participate in source-build.

## build.cmd/sh

Each repo will have two files that implement the repo API:

* build.cmd
* build.sh

The `.cmd` file will be called when running on Windows, while the `.sh` file will be called on all other operating systems.

These scripts will contain the logic necessary in order to build, test, publish the repo's assets.

source-build will invoke these scripts on each repo passing in:

1. An action to perform
1. A set of parameters

Individual repos are free to implement more features in these build scripts than what is required by source-build. For
example, a repo may want to provide a default action. These extra behaviors are not defined by source-build.

### Actions

To start, there are a number of actions source-build will need the repos to implement.  The actions are:

1. `Restore` - Sync any external dependencies/tools necessary to build the repo.
1. `Build` - Assemble the product from the current source contained in the repo.
1. `Publish` - Put the assembled product in the specified location.
1. `Test` - Ensure the assembled product works/acts correctly.

This list of actions can be added to in the future as more scenarios are implemented.

source-build formats arguments using a style that is compatible with MSBuild. The reasoning for this is that the
majority of repos have an MSBuild based build system. Using this format will allow for arguments to easily be passed
through to MSBuild. Similarly, both action and parameter arguments are case-insensitive, just like MSBuild default
behavior.

Actions will take the form of `-t:ActionName`, just like MSBuild targets are passed to `msbuild.exe`.

### Parameters

Each action above will take a set of parameters used to pass information into the action and control its behavior.

Parameters will take the form of `-p:ParameterName=ParameterValue`, just like MSBuild properties are passed to `msbuild.exe`.
One slight variation here is the usage of `-p` instead of `/p`.  MSBuild supports both forms, but source-build chooses `-p` because
it meets [POSIX recommendations](https://www.gnu.org/software/libc/manual/html_node/Argument-Syntax.html) for command line parameters
and avoids any confusion with file paths on Unix machines.

In order to avoid conflicts between existing MSBuild properties used by the repos and the properties passed in by source-build,
source-build will append a prefix to every property it passes in: `DotNet`.

#### Detecting build from source

The first parameter used by source-build will be a value indicating whether the build is being performed in "source only" mode. This
means repos cannot use tools/packages/references that haven't already been built by the current build.

`-p:DotNetBuildFromSource=true`

Some repos build more projects than is necessary to build the .NET Core stack. For example, the `dotnet/roslyn` repo builds
the C# compiler, which is needed, but it also builds Visual Studio extensions, which aren't needed. These VS extensions
cannot be built without using an external dependency on tooling that isn't available when building from source.

#### Available tools

In order for repos to build, they need tools in order to do the build (ex. MSBuild). These tools are not generally available
on all supported operating systems. As such, many repos today have the ability to pull these tools from the internet during the
build.

However, there are a couple problems with each repo downloading its own toolset.

1. Different versions can cause inconsistencies
1. It takes a non-trivial amount of time to download the toolset, if every repo does it during the complete .NET Core build,
it will add a lot of overhead to the build.

To solve this, source-build will have a set of common tools available that it will pass into each repos build.

First, a [.NET Core SDK](https://www.microsoft.com/net/download/core#/sdk) will be available for repos to be able to invoke
MSBuild, NuGet, etc. The path to the folder containing the `dotnet` executable will be available using the

`-p:DotNetToolDir`

property. This can be used to call `dotnet restore`, `dotnet build`, `dotnet publish`, `dotnet msbuild`, or any other CLI
verb on the repo's projects.

Second, a common set of tools used by the `dotnet` org repos is [BuildTools](https://github.com/dotnet/buildtools). This will
be available using the

`-p:DotNetBuildToolsDir`

property. This can be used to invoke any current or future tool that is part of BuildTools. It is not required that each repo
use BuildTools, but if the repo wants to, it can get the tools from this property.

### Example

Here is an example of the list of calls source-build will make on the `dotnet/corefx` repo:

```
/path/to/corefx/build.sh -t:Restore -p:DotNetBuildFromSource=true -p:DotNetToolDir=/path/to/dotnet -p:DotNetBuildToolsDir=/path/to/buildtools
/path/to/corefx/build.sh -t:Build -p:DotNetBuildFromSource=true -p:DotNetToolDir=/path/to/dotnet -p:DotNetBuildToolsDir=/path/to/buildtools
/path/to/corefx/build.sh -t:Publish -p:DotNetBuildFromSource=true -p:DotNetToolDir=/path/to/dotnet -p:DotNetBuildToolsDir=/path/to/buildtools
```

> **Note:** Not all properties have been specified above. As each action gets designed in detail, more `DotNet` properties will be
specified. For example, the `Publish` action above isn't getting told where to publish the assets to.

### .rsp files

As you can imagine, specifying properties this way is going to create really long command line strings. On Windows machines, there is a
limit to how many characters can be specified. It also becomes really hard to diagnose and reproduce build errors. Parsing large command
lines is rather difficult, especially when there are many file paths.

To solve this issue, we could implement a response (.rsp) file, where each command line argument is on a line in a text file. Then that
text file is passed into the `build` with a `@` character preceeding the file name.

`build.sh @/path/to/currentBuildParameters.rsp`

Where `currentBuildParameters.rsp` contains

```
-t:Build
-p:DotNetBuildFromSource=true
-p:DotNetToolDir=/path/to/dotnet
-p:DotNetBuildToolsDir=/path/to/buildtools
```

## Future Work

As we get more detailed requirements and specifications for the different pieces of source-build, more properties and actions will
be documented. This document outlined the base framework for the Repo API. Other design specs will build on top and further define
these APIs.
