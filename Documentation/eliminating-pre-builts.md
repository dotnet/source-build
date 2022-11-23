# Eliminating pre-builts in .NET repositories

This is a detailed guide on how to eliminate pre-builts in a source-buildable repository.
It is primarily intended for developers contributing to the `dotnet` organization.

## Table of content
  - [Pre-builts](#pre-builts)
  - [Elimitating pre-builts](#eliminating-pre-builts)
  - [FAQ](#faq)
  - [Contacts](#contacts)

# Pre-builts

_Source-build_ is a process of building a given product on a single machine from source with no internet access.

By definition, _pre-builts_ are dependencies that a repo has on binary files that are not built from source, where _build from source_ points to any package produced during the _current source-build_ or _already present_ in the distro at the time of building (such as `cmake`).
In layman terms, this means that packages from `nuget.org`, Microsoft builds or other non-source-built binaries cannot be used for source-building a given repository.

When adding a new dependency to a source-buildable repository, the contributor runs the risk of introducing a new pre-built to the product. 
To protect against this and catch any new pre-builts as soon as possible, the repositories in question have _pre-built detection_ - MSBuild logic responsible for veryfing that no used dependency is a pre-built. In case one is discovered (for example, during a PR pipeline), the build will fail with an appropriate message somewhat similar to the following:

```
3 new packages used not in baseline! See report at ./artifacts/source-build/self/prebuilt-report/baseline-comparison.xml for more information. Package IDs are:
  Microsoft.Bcl.AsyncInterfaces.8.0.0-alpha.1.22557.11  
  Microsoft.Build.16.7.0
  Microsoft.Build.Framework.14.3.0
```

Pre-built detection identifies the source of dependencies used to built the repository. 
These dependencies include not only direct dependencies, but also build tooling as well as dangling dependencies - packages downloaded / used by tooling during the build process and not referenced by the project itself.
A dependency that contains sources (binaries), was retrieved from an external source and was not explicitly excluded from pre-built detection it will be flagged as a pre-built.

Since any given project can require packages / libraries from other .NET repositories or outside the organization, pre-built detection can contain exceptions for packages with source-built content ([_intermediate packages_](https://github.com/dotnet/source-build/blob/main/Documentation/planning/arcade-powered-source-build/intermediate-nupkg.md)) or packages without any sources, such as _text-only packages_ (for example, SDKs with MSBuild props and targets) and _reference packages_ (essentially reference assemblies).
The packages are exempt from pre-build detection as they do not contain actual sources or, in case of intermediate packages, are used for local / non-release CI builds only.
This and other exceptions can be found in the `./eng/SourceBuildPrebuiltBaseline.xml` file in the root of the repository.


# Eliminating pre-builts

When adding a new dependecy to a repository, there is a posibility that the dependency in question will be flagged as a pre-built, failing the build and blocking any merge.
This can be resolved by identifying what exactly is the pre-built and following the approriate steps listed below.

To check if new pre-builts were introduce, the repository needs to be source-built first. This can be done trough the following command:

```sh
./build.sh -bl --sb
```

If a new unhandled pre-built is found, the build will fail with a detailed exception pointing to the exact package / version of the dependency that caused the failure.
Additional information can also be found in the generated pre-built detection reports, located in the `./artifacts/source-build/self/prebuild-report` directory, specifically in the `./prebuild-usage.xml` file. The information in question can, for example, be the path to the project that is referencing the dependency.

With this information retrieved, the [adding a new source-build dependency](https://github.com/dotnet/source-build/blob/main/Documentation/sourcebuild-in-repos/new-dependencies.md#adding-dependencies) documentation should be referred to as the main guide for resolving the pre-built.

# FAQ

WIP

# Contacts

For any questions or additional information about this document, pre-builts or source-build in general, please contact the `@dotnet/source-build-internal` team.
