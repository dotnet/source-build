# Eliminating pre-builts in .NET repositories

This is a detailed guide on how to eliminate pre-builts in a source-buildable repository.
It is primarily intended for developers contributing to the `dotnet` organization.

## Table of content
  - [What is a Prebuilt](#what-is-a-prebuilt)
  - [Elimitating pre-builts](#eliminating-pre-builts)
  - [Allowed exceptions](#allowed-exceptions)
  - [Contacts](#contacts)

# What is a Prebuilt

_Source-build_ is a process of building a given product on a single machine from source with no internet access.

By definition, _pre-builts_ are dependencies that are not built from source, such as reference packages, nuget packages and built tools. _Build from source_ points to any package produced during the _current source-build_ with the exception of dependencies that are picked up from the host distro such as `cmake`.
In layman terms, this means that packages from `nuget.org`, Microsoft builds or other non-source-built binaries cannot be used for source-building a given repository.

When onboarding a repository to source-build or adding a new dependency to a source-buildable one, the contributor runs the risk of introducing a new pre-built to the product. 
To protect against this and catch any new pre-builts as soon as possible, Arcade source-build infrastructure provides _pre-built detection_ - MSBuild logic responsible for veryfing that no used dependency is a pre-built. In case one is discovered (for example, during a PR pipeline), the build will fail with an appropriate message somewhat similar to the following:

```
3 new packages used not in baseline! See report at ./artifacts/source-build/self/prebuilt-report/baseline-comparison.xml for more information. Package IDs are:
  Microsoft.Bcl.AsyncInterfaces.8.0.0-alpha.1.22557.11  
  Microsoft.Build.16.7.0
  Microsoft.Build.Framework.14.3.0
```

Pre-built detection identifies the source of dependencies used to build the repository. 
These dependencies include not only direct dependencies, but also build tooling as well as dangling dependencies - packages downloaded / used by tooling during the build process and not referenced by the project itself.
Dependencies retrieved from external sources that are not explicitly excluded from pre-built detection will be flagged as pre-builts.

# Eliminating pre-builts

When altering the dependecy tree of a repository, specifically adding or updating dependencies, there is a posibility that a new pre-built is introduced, failing the build and blocking any merge.
This can be resolved by identifying what exactly is the pre-built and following the approriate steps listed below.

To check if new pre-builts were introduce, the repository needs to be source-built first. This can be done through the following command:

```sh
./build.sh --sb
```

If a new unhandled pre-built is found, the build will fail with a detailed exception pointing to the exact package / version of the dependency that caused the failure.
Additional information can also be found in the generated pre-built detection reports, located in the `./artifacts/source-build/self/prebuild-report` directory, specifically in the `./prebuild-usage.xml` file. The information in question can, for example, be the path to the project that is referencing the dependency.

With this information retrieved, the [adding a new source-build dependency](https://github.com/dotnet/source-build/blob/main/Documentation/sourcebuild-in-repos/new-dependencies.md#adding-dependencies) documentation should be referred to as the main guide for resolving the pre-built.

# Allowed exceptions

The list of permitted pre-builts can be found in the `./eng/SourceBuildPrebuiltBaseline.xml` file in the root of the repository. It contains package information of pre-builts that for one reason or another are allowed in the source-build of the repository.

Any new addition to the pre-built exception list must be signed-off by a member of the `@dotnet/source-build-internal` team.

A common example of a exception that is present in several .NET repositories is an [_intermediate package_](https://github.com/dotnet/source-build/blob/main/Documentation/planning/arcade-powered-source-build/intermediate-nupkg.md).
When a repository utilizes an intermediate package, it will be excluded from pre-built detection with the following declaration in the above-mentioned file:

```xml
<UsageData>
  <IgnorePatterns>
    <UsagePattern IdentityGlob="Microsoft.SourceBuild.Intermediate.*" />
  </IgnorePatterns>
</UsageData>
```

With this ignore pattern in place, pre-built detection will not mark any .NET intermediate package as long as it conforms to the naming in the pattern.

In cases where a specific package needs to be excluded from pre-built detection (for example, to not block the introduction of changes until a source-build acceptable solution for the pre-built is provided), the developer can directly specify the name / version of the depedency:

```xml
<UsageData>
    <Usage Id="Foo.Bar" Version="x.y.z" />
  </Usages>
</UsageData>
```

If a new pre-built is encountered, pre-built detection will also generate a new version of the baseline file by adding the dependency that contains the pre-built to the existing baseline.
The new file can be found at `./artifacts/source-build/self/prebuild-report/generated-new-baseline.xml`.

# Contacts

For any questions or additional information about this document, pre-builts or source-build in general, please create an [issue](https://github.com/dotnet/source-build/issues) or open a [discussion](https://github.com/dotnet/source-build/discussions) in the [source-build](https://github.com/dotnet/source-build) repository.
