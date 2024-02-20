# Package Dependency Flow

This document describes how package dependencies are handled within source build.
It describes the mechanisms that exist to control which package versions are used.

## Origins of Packages

A source build must be self-contained, meaning the entire product must be built
from source in an offline environment. To achieve this, all packages dependencies must
be satisfied by one of the following:

### Source-Build-Reference-Packages

The first repo that is built as part of source build is
[source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages).
This repo contains all of the reference packages used to build the product. The repo
contains [tooling to generate new reference packages](https://github.com/dotnet/source-build-reference-packages?tab=readme-ov-file#adding-new-packages).

### Current Source Built Packages

This refers to all of the packages produced in the current build. The set of packages
available to each repo varies based on its build order. For example the msbuild repo
can take a dependency on the current version of Microsoft.CodeAnalysis from roslyn
because roslyn builds before msbuild. Conversely, since roslyn builds before msbuild,
roslyn cannot take a dependency on the current version of Microsoft.Build; it can only
take a dependency on a previously released version.

### Previous Source Built Packages

Because the .NET product uses itself to build, the .NET source build product must be
[bootstrapped](./bootstrapping-guidelines.md). This process allows the packages from the
previous source build release to be used to build the next version of the product. This
provides a means for breaking the product's circular dependencies. For example repos like
[arcade](https://github.com/dotnet/arcade) can self-reference its previous version to
produce the next version.

When referencing previous source built packages, it is important to not leak these
previously built packages into the resulting packages/product. This is considered a
[poison leak](./leak-detection.md) and is not permitted during a source build as it
breaks the notion of building the product entirely from source. This hinders the
ability to service the product.

## Package Versions

Package dependencies that defined using 
[Arcade's Darc patterns](https://github.com/dotnet/arcade/blob/main/Documentation/Darc.md)
will get lifted dynamically during a source build if the following conditions are met:

1. The dependency is declared in the Version.Details.xml file.

    **Version.Details.xml**

    ```xml
    ...
      <Dependency Name="System.CommandLine" Version="2.0.0-beta4.24068.1">
        <Uri>https://github.com/dotnet/command-line-api</Uri>
        <Sha>02fe27cd6a9b001c8feb7938e6ef4b3799745759</Sha>
      </Dependency>
    ...
    ```

1. A corresponding version property is defined in the Versions.props.

    **Versions.props**

    ```xml
    ...
      <SystemCommandLineVersion>2.0.0-beta4.24068.1</SystemCommandLineVersion>
    ...
    ```

1. A repository reference is defined in the
 [VMR's project dependency graph](https://github.com/dotnet/dotnet/tree/main/repo-projects).
This reference does not have to be direct, it can be transitive.

    **{VMR repo project}.proj**

    ```xml
    ...
      <RepositoryReference Include="command-line-api" />
    ...
    ```

When these conditions are met during a source build, the infrastructure will scan
the Version.Details.xml file and dynamically create two new Versions.props files
containing updated version properties for all non-pinned dependencies.  

**PackageVersions.Previous.props:** This will contain version properties with the
package versions from the [previous release of source build](#previous-source-built-packages).
If a new package exists that has never been released before, it will not have a 
version property defined.

```xml
...
  <SystemCommandLineVersion>2.0.0-beta3</SystemCommandLineVersion>
...
```

**PackageVersions.Current.props:** This will contain version properties with the
package versions from the [current source build](#current-source-built-packages).
If a package comes from a repo that has not been built yet, it will not have a version
property defined.

```xml
...
  <SystemCommandLineVersion>2.0.0-beta4</SystemCommandLineVersion>
...
```

These two version.props files get imported by the arcade source build infrastructure after
the repo's Version.props file. Therefore the repo's Versions.props property versions
get overridden by the source build versions. In the case of the `SystemCommandLineVersion`
example, the current source build version, 2.0.0-beta4, would win. All msbuild references 
(e.g. project PackageReferences) to these Versions.props properties pick up the newer 
versions. This is known as package version lifting since it lifts the originally defined
package version to the current source built version. This behavior only applies to source
build in the context of the [VMR](https://github.com/dotnet/dotnet) (see also 
[Repo Level Source Builds](#repo-level-source-builds)).

### Transitive Version Properties

Transitive version properties in your Versions.props file may not work as intended with
source build.

**Versions.props**

```xml
...
  <MicrosoftBuildFrameworkVersion>17.7.0-preview-23217-02</MicrosoftBuildFrameworkPackageVersion>
  <MicrosoftBuildVersion>$(MicrosoftBuildFrameworkVersion)</MicrosoftBuildPackageVersion>
...
```

**Version.Details.xml**

```xml
...
  <Dependency Name="Microsoft.Build.Framework" Version="17.7.0-preview-23217-02">
    <Uri>https://github.com/dotnet/msbuild</Uri>
    <Sha>2cbc8b6aef648cf21c6a68a0dab7fe09a614e475</Sha>
  </Dependency>
  <!-- No dependency is declared for "Microsoft.Build". -->
...
```

In this case source build will override the `MicrosoftBuildFrameworkVersion` to the
latest version but the `MicrosoftBuildVersion` will remain set to `17.7.0-preview-23217-02`
because of the property evaluation order. If the desired behavior is for
`MicrosoftBuildVersion` to be set to the same value as `MicrosoftBuildFrameworkVersion`
for source build, then you either need to declare the Microsoft.Build dependency
in the Version.Details.xml file or move the `MicrosoftBuildVersion` assignment outside
of the Versions.props file.


### Repo Level Source Builds

The source build package lifting mechanism is not applicable when building individual
repos in source build mode because it doesn't have the context of the other product
repos or previous source build release. In repo source build mode, the versions of the
packages declared in the Versions.props are used (see also 
[backlog issue](https://github.com/dotnet/source-build/issues/3562)).
