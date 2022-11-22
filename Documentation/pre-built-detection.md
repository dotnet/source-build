# Pre-built detection guide

This is a detailed guide on how to approach enabling pre-built detection for a source-buildable repository.
It is primarily intended for repository maintainers in the `dotnet` organization.

## Pre-requisites

This guide places several assumptions on the repository and the maintainer in charge of enabling pre-built detection:

  - the repository in question is source-buildable;
  - the person performing the task is aware of basic source-build concepts;

## Table of content
  - [Pre-builts](#pre-builts)
  - [Enabling mandatory pre-built detection](#enabling-mandatory-pre-built-detection)
  - [Elimitating pre-builts](#eliminating-pre-builts)
  - [FAQ](#faq)
  - [Contacts](#contacts)

# Pre-builts

_Source-build_ is a process of building a given product on a single machine with no internet access.
As such, all of the upstream packages must be part of the current source-build, since their _pre-built_ versions cannot be retrieved from, for example, `nuget.org` or some internal feed.

By definition, _pre-builts_ are dependencies that a repo has on binary files that are not build from source, where _build from source_ points to any package produced during the _current source-build_.
In lament terms, this means that packages from `nuget.org`, Microsoft builds or other unrelated source-builds cannot be used for source-building a given repository.

Several different methods are provided to repositories to be able to handle pre-builts for their individual builds while being source-buildable.
These methods are expanded on in the [Eliminating pre-builts](#eliminating-pre-builts) section of the guide.

# Enabling mandatory pre-built detection

## Motivation

WIP

## Verifying that the repository is source-buildable (?)

WIP

## Identifying used pre-builts

By default, when source-build logic was first introduced to the repository, all pre-builts were allowed.
This was accomplished by instructing pre-built detection logic to not fail the build for any found pre-builts via a dedicated glob rule.
The rule itself can be found in the `./eng/SourceBuildPrebuildBaseline.xml` file.

Nevertheless, pre-built detection compiles a report of pre-built usage regardless of any rules set.
To receive the afore-mentioned report, the repository must be source-build first.
This can be done via the following command:

```
./build.sh --sb --bl
```

Once the source-build succeddes, several files related to pre-built detection can be found in the `./artifacts/source-build/self/prebuild-report` directory.
For now, the one that is of particular interest is `./prebuild-usage.xml`.
It contains a list of pre-builts discovered during the build process together with a path to the project that requires the pre-built in question. 

If the list is empty - the build does not utilize any pre-builts. 
However, in most cases it will contain several of them and will require additional actions before mandatory pre-built detection can be enabled.

# Eliminating pre-builts

To better understand how a pre-built can be tackled, first its type should be identified. 

In general, project dependencies can be split into the following categorizes:
  - direct - dependency of the repository itself, i.e. declared in its `./eng/Version.Details.xml` file
  - indirect (transitive) - dependencies of a direct dependency that are required by the later
  - dangling - dependencies that are not part of the `restore` during repository build but are installed as part of the build by, for example, some tooling
  - external - dependency on a component outside of Microsoft / .NET

Knowing what exactly is the pre-built in question helps greatly in eliminating it from the report based on the following flow:

  1. [Direct dependency from a Microsoft / .NET repository](#direct-dependency-from-a-microsoft--net-repository)
  2. [Dependencies witout any code](#dependencies-without-any-code)
  3. [External dependencies](#external-dependencies)

## Direct dependency from a Microsoft / .NET repository

When a repository depends on package from another Microsoft / .NET repository, existence of a source-build for the latter should be checked.
This can be done by fetching the list of source-build repositories from the latest product source-build, avaialble at [TO BE IMPLEMENTED](https://github.com/dotnet/source-build/issues/1319). 

If yes, then [adding source-build metadata](https://github.com/dotnet/source-build/blob/main/Documentation/sourcebuild-in-repos/new-dependencies.md#basics) to the upstream repository's declaration in `Version.Details.xml` would allow free usage of the said package.
Nevertheless, currently the approach has several limitations:
  - the same version for all packages from the repo should be used. Example: repo A depends on libraries B and C from runtime. The B and C versions should be identical or the source-build intermediate dependency will not be resolved.
  - the source-build metadata for a specific repository can be declared only once. Example: repo A depends on librabries B and C from runtime. Only B or only C can have the source-build metadata for runtime, otherwise a duplicate dependency exception will be raised during build [GitHub issue](https://github.com/dotnet/source-build/issues/3003). 

TODO - if product dependency is not part of source-build

### Utilizing latest versions

Use of latest versions for repository dependencies is the preffered and highly recommended approach in source-build setting.
This stems from a mariad of reasons, the primary one being that in an end product build only the latest source-built version of any repository should exist.
As a result, any older version of a repository would normally be overriden by the source-built one and down-stream repositories would have to utilize it.

Deviation from this policy would result in higher maintanance cost for the source-build team, higher infrastructure load and bigger end product size.
Nevertheless, if absolutely required, older versions of packages / libraries can be added to source-build throught a dedicated repository [source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages). 

To have a package added to the repo, please [log an issue](https://github.com/dotnet/source-build/issues/new/choose) explaining the use-case in question and the source-build team will help you make the right decision.

If the package you require is already in the source-build reference packages, it can be directly added to the `Version.Details.xml` dependency list:

```xml
  <Dependency Name="Microsoft.SourceBuild.Intermediate.source-build-reference-packages" Version="x.y.z">
    <Uri>https://github.com/dotnet/source-build-reference-packages</Uri>
    <Sha>xxx000</Sha>
    <SourceBuildTarball RepoName="source-build-reference-packages" ManagedOnly="true" />
  </Dependency>
```

## Dependencies without any code

Dependencies that do not have any code (eg. SDKs with just props and targets) can usually be added to the [text-only packages](https://github.com/dotnet/source-build-reference-packages/tree/main/src/textOnlyPackages/src). 
If the package in question is not already present in the list, please [log an issue](https://github.com/dotnet/source-build/issues/new/choose) to determine if a text-only package would solve the use-case in question.

To make the text-only packages available to the source-build of the repository, a dependency on source-build reference packages should be declared in the `Version.Details.props` file:

```xml
  <Dependency Name="Microsoft.SourceBuild.Intermediate.source-build-reference-packages" Version="x.y.z">
    <Uri>https://github.com/dotnet/source-build-reference-packages</Uri>
    <Sha>xxx000</Sha>
    <SourceBuildTarball RepoName="source-build-reference-packages" ManagedOnly="true" />
  </Dependency>
```

## External dependencies

Some external dependencies, specifically those that have very few dependencies themselves and are simple to build, are placed in the [source-build-external](https://github.com/dotnet/source-build-externals) repository. 
As with text-only packages, please [log an issue](https://github.com/dotnet/source-build/issues/new/choose) to get the process started.

To make the text-only packages available to the source-build of the repository, a dependency on source-build externals package should be declared in the `Version.Details.props` file:

```xml
  <Dependency Name="Microsoft.SourceBuild.Intermediate.source-build-externals" Version="x.y.z">
    <Uri>https://github.com/dotnet/source-build-externals</Uri>
    <Sha>xxx000</Sha>
    <SourceBuild RepoName="source-build-externals" ManagedOnly="true" />
  </Dependency>
```

# FAQ

WIP

# Contacts

WIP
