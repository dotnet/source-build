# Source-Build Support for Multiple SDKs

This document serves as the design planning document for how .NET source build will support multiple SDK bands. More generally, this support could be described as "partial VMR support". This is the implementation plan for https://github.com/dotnet/arcade/blob/main/Documentation/UnifiedBuild/VMR-Managing-SDK-Bands.md.

## Overview and General Approach

The general approach to supporting more than one SDK band is to **not** view the build of additional SDK bands as being any different from any other source build. Each build of the product combines a set of inputs (previously source-built artifacts + source) to produce a set of outputs that can ship to customers. When building two completely different major versions of .NET, the set of inputs is different (e.g. different source, 6.0 SDK vs. 7.0 SDK). Some of the previously source-built artifacts come from .NET, some may come from the source-built package ecosystem (e.g. icu or clang/llvm). If a source built product repo were to eliminate part of the input sources, instead relying on a prebuilt binary, that prebuilt binary would need to come from a set of source-built artifacts.

The primary restriction on building multiple SDK bands is that they must not differ in the shared runtimes. For N bands, there must be a single runtime artifact. Thus, we can view a source-build of N SDK bands as:
- As a single build of one runtime, producing a set of source-built outputs and **then**
- Building N SDK bands **using**
- The *outputs* of the runtime build combined with additional previously source-built artifacts (e.g. a matching band SDK, required tools and libraries) and source, to produce N SDK bands that meet source-build requirements.

The runtime build requires a 1xx band SDK to build **and** redistributes functionality from tooling that ships in the 1xx band (e.g. it has dependencies on roslyn and roslyn-analyzers). Furthermore, most changes to a .NET major version occur when only one SDK band exists. Therefore it makes practical sense at this point to include the source of the 1xx SDK and the shared runtime in the same VMR branch, and to produce all artifacts related to 1xx, including the runtime, in its build. Newer bands will be VMRs that contain **only** the components required to build that newer band. Only those components that differ. When building the newer band, the outputs of the 1xx build would be fed into the newer band build, in exactly the same manner as previously source built artifacts are today. If the source for a component does not exist in a given VMR, it is simply not built, and obviously no outputs would be produced for that component. Thus any downstream dependencies would be forced to use the versions provided by previously source built artifacts, typically from the 1xx source build. If no such version exists, then the input would fail to be found or restored from online sources and be reported as a prebuilt.

This approach fits naturally into the source-build methodology. Generally, additional SDK bands may be referred to as "subsetted VMRs", since use of a subsetted VMR is not restricted to SDKs only.

## Changes required for the source-build infrastructure

This section details changes to the source build infrastructure to support building of subsetted VMRs.

### Filtering builds of components

The VMR defines a set of projects (under `repo-projects`) that correspond to each component of the build. These projects also define a build dependency graph of these components via the `RepositoryReference` ItemGroup. *Note: there are a few projects that do not correspond directly to a component, but instead serve as general join points in the build graph.*. Source build invokes a root build (`dotnet.proj`), which evaluates the dependency graph and invokes the MSBuild task on dependent projects. To avoid maintenance complexity, we should avoid altering this dependency graph or removing project files when a component should not be built. Instead, it should simply be filtered out and ignored as if the node in the graph was inactive.

When filtering out components, we do not want to build a filtered subproject at all. `AfterTargets=Build`, `BeforeTargets=Build` are common in both component projects as well as the shared targets. We do not want these invoked at all, or else a large variety of special casing per-target will be required. Instead, each individual project should determine whether it should be built by setting a property. By default, this property would be set based on the whether the source for the component exists. Therefore, a user has two options for explicitly excluding or including a project:
- Explicitly setting the property value in the project file
- Removing the source code altogether from the branch.

```
// Default
// repo-projects/Directory.Build.props
<SkipRepoBuild Condition="'$(SkipRepoBuild)' == '' and !Exists('$(ProjectDirectory)')">true</SkipRepoBuild>
<SkipRepoBuild Condition="'$(SkipRepoBuild)' == ''">false</SkipRepoBuild>

// Explicit setting
// repo-projects/package-source-build.proj
<SkipRepoBuild>false</SkipRepoBuild>
```

Given this set of properties, a new target can be added that will determine the active dependency projects (those `RepositoryReference` items that should be built) given the original set of a particular project's dependencies. Then, only active dependency projects would be built. Example code from the Proof-of-Concept is shown below.

```xml
<Target Name="GetActiveDependencyProjects" Outputs="@(ActiveDependencyProjects)">
    <ItemGroup>
        <_AllDependencyProjects Include="@(RepositoryReference -> '%(Identity).proj')">
            <RepositoryName>%(Identity)</RepositoryName>
        </_AllDependencyProjects>
    </ItemGroup>

<!-- To enable partial builds, the graph is filtered to remove repos that are not available.
     To determine whether a repo should build, invoke the repo project with the ShouldSkip target.
     The target will determine whether repo should be built. By default, a repo is not built if its
     sources are not available. -->
    <MSBuild Projects="@(_AllDependencyProjects)"
             Targets="GetSkipRepoBuild">
        <Output TaskParameter="TargetOutputs" ItemName="_DependencyProjectsSkipRepoBuild" />
    </MSBuild>

    <ItemGroup>
        <ActiveDependencyProjects Include="@(_DependencyProjectsSkipRepoBuild -> '%(OriginalItemSpec)')" Condition="'%(Identity)'=='false'">
            <RepositoryName>%(RepositoryName)</RepositoryName>
        </ActiveDependencyProjects>
    </ItemGroup>
</Target>
  
<Target Name="BuildRepoReferences"
        DependsOnTargets="GetActiveDependencyProjects"
        Condition="'$(SkipRepoReferences)' != 'true'">

    <Message Importance="High"
            Text="Building active dependencies [@(ActiveDependencyProjects -> '%(RepositoryName)')] needed by '$(RepositoryName)'."
            Condition="'@(ActiveDependencyProjects)' != ''" />

    <MSBuild Projects="@(ActiveDependencyProjects)" Targets="Build" BuildInParallel="$(BuildInParallel)" StopOnFirstFailure="true" />
</Target>
```

### Choosing the correct source-built MSBuild SDKs

There is one wrinkle to the simple graph filtering approach. Most .NET projects have dependencies on the arcade toolset and associated MSBuild SDK. This dependency is handled specially by source-build as it helps bootstrap a repo's build process. There are two potential arcade versions available:
- The bootstrap arcade version coming in via the previously source-built packages
- The arcade built during the current source build invocation.

Repositories built **before** arcade (and arcade itself) is built must choose the bootstrap arcade and know its location and version. Today, repos explicitly choose this via the `UseBootstrapArcade` property, which causes a series of environment variables to be set up for the Arcade SDK. If arcade is filtered from the graph, however, then a repo must **always** use the bootstrap arcade version. *In this case, the arcade should have been produced by the 1xx band build.* To achieve this, the UseBootstrapArcade property must be dynamically set, since the graph is dynamically filtered, based on whether arcade appears in the filtered input dependency projects. Then, the appropriate environment variables like `_InitializeToolset` would be set in a target based on its value.

Example code from the PoC:

```
// From SetSourceBuiltSdkOverrides target in repo-projects/Directory.Build.targets.
<ItemGroup>
    <ActiveArcadeDependency Include="@(ActiveDependencyProjects)" Condition="'%(RepositoryName)' == 'arcade'" />
</ItemGroup>

<PropertyGroup>
    <UseBootstrapArcade Condition="'$(UseBootstrapArcade)' == '' and '@(ActiveArcadeDependency)' == ''">true</UseBootstrapArcade>
</PropertyGroup>

<ItemGroup>
    <UseSourceBuiltSdkOverride Condition="'$(UseBootstrapArcade)' != 'true'" Include="@(ArcadeSdkOverride)" />
    <UseSourceBuiltSdkOverride Condition="'$(UseBootstrapArcade)' == 'true'" Include="@(ArcadeBootstrapSdkOverride)" />
    <EnvironmentVariables Include="_InitializeToolset=$(SourceBuiltSdksDir)Microsoft.DotNet.Arcade.Sdk/tools/Build.proj" Condition="'$(UseBootstrapArcade)' != 'true'" />
</ItemGroup>
```

***Note: Today it is necessary to explicitly set UseBootstrapArcade for those projects where arcade is not available (arcade, source-build-reference-packages). It may be possible to remove this requirement, simply relying on the repo dependency graph to give the correct answer.***

### Non-NuGet input assets

The input assets required for the .NET build come in two primary forms:
- NuGet assets
- Non-NuGet assets (typically `.zip` or `.tar.gz` archives)

Source build handles NuGet assets using a set of local nuget feeds (which are just directories of nuget packages). It handles non-Nuget assets by using one of these local nuget feeds as a shared storage location where repos producing archives (e.g. runtime, sdk, aspnetcore) place their outputs (`blob-feed` dir). Downstream repos that need these archives copy the files from that location. They locate specific file names based on set naming patterns combined with package input versions. For instance, the installer repo might find the runtime archive for linux-x64 by looking for `dotnet-runtime-<version of runtime package>-linux-x64.tar.gz`. When building a subsetted VMR, just as the shared location may not contain all the input packages, it may not contain all of the input archives. For NuGet packages, this is handled reasonably transparently. Given a set of potential input feeds, NuGet simply checks each one. So if arcade wasn't built and version 1.2.3 isn't available in the shared `blob-feed` dir, NuGet will look in the previously source-built artifacts feed.

Builds of subsetted VMRs need a way to locate artifacts not produced in the same build. Potentially, one could simply pre-populate the shared `blob-feed` directory with the archives of the previous build. This is not desirable, however. It mixes the outputs of the current build with the inputs. Furthermore, the outputs of the blob-feed dir are used as the output artifacts. Instead, repositories should be altered to accept an additional location where they may find input artifacts. This has precedent, as it is the same logic used in installer, aspnetcore, windowsdesktop, and others. These repos will check a public official source for binaries first, then a public build artifacts location, and finally an internal build artifacts location, if the appropriate credentials are available.

For example, installer.proj might add the following logic. dotnet/installer then uses AdditionalBaseUrl when available, adding it as a location for downloading assets:

```
<BuildCommandArgs Condition="'$(CustomPrebuiltSourceBuiltPackagesPath)' != ''">$(BuildCommandArgs) /p:AdditionalBaseUrl=file:%2F%2F$(CustomPrebuiltSourceBuiltPackagesPath)</BuildCommandArgs>
```

In the above example, the path where the archives are located is the custom previously source built packages path (provided by --with-packages). A user would copy the archives of the input 1xx build into the --with-packages path.

### Scripting changes

Input source-built packages and archives from a 1xx build should be not be viewed as significantly different from each other. Today, a distro maintainer would pass --with-packages to provide a set of previously source-built NuGet packages. This switch should be changed as to generally refer to input artifacts, in a flat folder. These artifacts may be nuget packages or archives. To this end, the --with-packages switch should be deprecated and changed to `--with-artifacts`.` When present, the additional base url used for finding archives will point to this directory.

In addition, we should add a script that prepares the input artifacts for the build of a particular VMR branch, given a set of input directories from other builds/other previously source built artifacts. See [below](#what-artifacts-should-be-passed-with---with-artifacts--with-packages) for an explanation of the input artifacts.

### Gathering assets for delivery to customers

To gather assets for delivery to customers, the outputs present in each of the `artifacts/<arch>/<Flavor>` (e.g. `artifacts/x64/Release`) should be used. For each build, the artifacts present in the output directory are only those artifacts that were produced in that build.

## Changes to distro maintainer workflow

A distro maintainer wishing to support a newer band, either in addition to or in place of an older band, would see some change in workflow. First off, it is important to remember that the 1xx band will still be required. This is for two reasons:
- The 1xx SDK is the only SDK that is supported for building the runtime components. Because tooling differs between the bands, using a newer band to build the runtime is likely to expose new warnings or issues.
- There are components of the 1xx band that are used in the runtime. There are "sdk-like" components present in the runtime (analyzers, generators, etc.) that are dependent upon "sdk" functionality. Substituting in a 2xx aligned roslyn, for instance, would result in a product that differs from Microsoft's build.

### What artifacts should be passed with --with-artifacts/--with-packages?

Today, `--with-packages` is used to pass the previously source-built packages. This serves as a feed containing packages that the .NET SDK internally depends on, as well as bootstrap input packages for the current build iteration (e.g. arcade). The source-build infrastructure will read this set of packages and produce a package version props file for each repo, depending on the dependencies listed in the `Version.Details.xml` file. If multiple packages exist with the same ID in this package source, the *latest* is chosen. 

When performing a source-build of a product, there are 4 required input set of input artifacts:

1. The .NET SDK to use
2. The NuGet artifacts supporting that SDK
3. The non-SDK NuGet artifacts required to bootstrap any component that depends on assets built *later* in the build. (e.g. arcade depends on itself to build, but is not provided by the .NET SDK).
4. The input artifacts for components **not** built in the the product source build. Examples include:
   - Prebuilts
   - In a subsetted VMR case, components built in *another* VMR build.

***Note: When dealing with just a 1xx SDK, full build, with no prebuilts, #4 is an empty set, and #2 and #3 are the previously-source-built artifacts passed with --with-packages.***

When building a VMR, a distro maintainer will combine the sets of artifacts from #2, #3 and #4 into a single directory and pass it with --with-artifacts. Below, distro maintainer workflow scenarios are presented. The following abbreviations are used:

- PSB - Previously source-built (from a previous servicing/preview iteration, or from a bootstrap build)
- CSB - Current source-built (just built, e.g. from a 1xx VMR build).

### Previews and major release GA builds

**No Change**

A distro maintainer sees no change here. Until a few months **after** GA, only the 1xx band ships. The workflow remains the same as today. Clone the VMR branch/tag in question, build using previously source-built artifacts and SDKs.

### A distro maintainer wishing to only support the 1xx SDK

**No change**

### A distro maintainer wishing to build the initial release (n00) of a 2xx+ band SDK

The initial release of a 2xx+ band SDK should be straightforward. It is unlikely (though possible) that the initial 2xx band would depend on a 2xx SDK to build. If this is not the case, then a distro maintainer performs the following actions, and no bootstrap will be required:
1. **Checkout** 1xx branch:
2. **Build** using `./build.sh --with-sdk <PSB 1xx SDK> --with-artifacts <PSB 1xx artifacts>`.
3. **Gather** 1xx build outputs from `artifacts/x64/Release` = `<CSB 1xx artifacts>`.
4. **Prepare** 2xx inputs - `<PSB 1xx artifacts> + <CSB 1xx artifacts>`
5. **Checkout** 2xx branch
6. **Build** using `./build.sh --with-sdk <PSB 1xx SDK> --with-artifacts <2xx inputs>`

If a 2xx SDK is required to build the initial 2xx SDK, then the following workflow is used:

1. **Checkout** 1xx branch:
2. **Build** using `./build.sh --with-sdk <PSB 1xx SDK> --with-artifacts <PSB 1xx artifacts>`.
3. **Gather** 1xx build outputs from `artifacts/x64/Release` = `<CSB 1xx artifacts>`.
4. **Prepare** 2xx bootstrap inputs - `<PSB 1xx artifacts> + <CSB 1xx artifacts>`
5. **Checkout** 2xx branch
6. **Build** using `./build.sh --with-artifacts <2xx bootstrap inputs>`
7. **Prepare** 2xx inputs - `<PSB 1xx artifacts> + <CSB 1xx artifacts> + <CSB 2xx artifacts>`
8. **Build** using `./build.sh --with-sdk <CSB 2xx SDK> --with-artifacts <2xx inputs>`

### A distro maintainer wishing to support only a 2xx SDK (monthly workflow)

A distro maintainer who only wants to support the 2xx SDK still needs to build the 1xx branch to obtain the runtime and an updated 1xx SDK for use the next month. In this case, we build the 2xx inputs with the 2xx SDK.

1. **Checkout** 1xx branch:
2. **Build** using `./build.sh --with-sdk <PSB 1xx SDK> --with-artifacts <PSB 1xx artifacts>`.
3. **Gather** 1xx build outputs from `artifacts/x64/Release` = `<CSB 1xx artifacts>`.
4. **Prepare** 2xx inputs - `<PSB 2xx artifacts> + <CSB 1xx artifacts> + <PSB 1xx artifacts>`
5. **Checkout** 2xx branch
6. **Build** using `./build.sh --with-sdk <PSB 2xx SDK> --with-artifacts <2xx inputs>`

### A distro maintainer wishing to support all available SDKs (monthly workflow)

A distro maintainer wishing to support all SDK bands builds the 1xx band, then may build all Nxx bands in parallel.

1. **Checkout** 1xx branch:
2. **Build** using `./build.sh --with-sdk <PSB 1xx SDK> --with-artifacts <PSB 1xx artifacts>`.
3. **Gather** 1xx build outputs from `artifacts/x64/Release` = `<CSB 1xx artifacts>`.

The following additional steps may be done in parallel:

For each SDK band Nxx:

   1. **Prepare** Nxx inputs - `<PSB Nxx artifacts> + <CSB 1xx artifacts> + <PSB 1xx artifacts>`
   2. **Checkout** Nxx branch
   3. **Build** using `./build.sh --with-sdk <PSB Nxx SDK> --with-artifacts <Nxx inputs>`

## Poison and Prebuilt detection

Prebuilt detection should not change. Poisoning workflows may need to change. We don't want to poison inputs from the 1xx VMR, used when building the 2xx VMR. We **do** want to poison the previously source built inputs prior to adding in the 1xx inputs. So, in a poisoning check on a 2xx VMR build, the following workflow would be used:

1. **Checkout** 1xx branch:
2. **Build** using `./build.sh --with-sdk <PSB 1xx SDK> --with-artifacts <PSB 1xx artifacts>`.
3. **Gather** 1xx build outputs from `artifacts/x64/Release` = `<CSB 1xx artifacts>`.
4. **Prepare (pre-poison)** 2xx inputs - `<PSB 2xx artifacts> + <PSB 1xx artifacts>`
5. **Poison** 2xx inputs
6. **Augment (post-poison)** 2xx inputs - `<2xx inputs> <CSB 1xx artifacts>`
7. **Checkout** 2xx branch
8. **Build** using `./build.sh --with-sdk <PSB 2xx SDK> --with-artifacts <2xx inputs>`

## Potential issues and mitigations

There are a few potential issues that may require tweaks to this approach, source fixes, additional guidance, etc. They are listed below:

### A newer SDK band may continue to require an older (typically 1xx band) SDK to build

This could happen if a newer SDK band's (e.g. 2xx) components never take a dependency on newer 2xx features, yet do not successfully build with 2xx, due to new warnings, analyzers, etc. A two pronged approach is proposed to deal with this:
- Microsoft documents the set of supported build combinations, including required inputs for all active SDK bands. This provides a guide for distro maintainers.
- Where a band takes a dependency on a 'mix' of SDKs (e.g. dotnet/installer @ 2xx requires a 2xx SDK, but dotnet/roslyn cannot build with 2xx), Microsoft will fix input components so that the highest supported SDK band works across all the input components. So in this case, Microsoft would change dotnet/roslyn to build successfully with the 2xx SDK.

### A toolset input to a newer band does not work with the PSB from that same band

When preparing a newer band's input artifacts, there would be up to 3 versions of some components. For example:
- PSB 1xx Microsoft.NET.Compilers.Toolset @ 4.7.1
- CSB 1xx Microsoft.NET.Compilers.Toolset @ 4.7.2
- PSB 2xx Microsoft.NET.Compilers.Toolset @ 4.8.0

In this scenario, the *newest* version of Microsoft.NET.Compilers.Toolset will get used as input to any repo taking a dependency it it, before the 2xx dotnet/roslyn is built. If this particular repo has an explicit dependency on 4.7.x, then transparently updating to 4.8.x might cause a break. In the current source build infrastructure, the only way to avoid that transparent upgrade would be to not use the PSB 2xx inputs with the 2xx SDK build. But of course, the 2xx inputs would be required to provide supporting packages that the SDK depends on.

If this scenario ends up becoming a common problem, I think we could alter the source build PVP infrastructure to be smarter about version selection, attempting to match on best "MAJOR.MINOR" when multiple input versions are available.

### Confusion around the input artifact set

The current design has all the inputs for a subsetted VMR build lumped into a single directory. This relies on the source build infrastructure to select the correct input versions, and the distro maintainer to prepare this directory. It may be that this is a confusing model that lacks the flexibility required to build the product using the correct input versions for each component. If this is the case, then it may make sense to add a new switch to the source-build process, splitting `--with-packages/--with-assets` into two input sets:
- `--with-psb-assets` - Previously source built assets, either bootstrap or 
- `--with-csb-assets` - Assets from a build of another VMR, provided as input to a subsetted VMR.
