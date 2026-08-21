# Package Dependency Flow

This document describes how package dependencies are handled within source
build. It describes the mechanisms that exist to control which package versions
are used.

## Origins of Packages

A source build must be self-contained, meaning the entire product must be built
from source in an offline environment. To achieve this, all packages
dependencies must be satisfied by one of the following:

### Source-Build-Reference-Packages

The first repo that is built as part of source build is
[source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages).
This repo contains all of the reference packages used to build the product. The
repo contains [tooling to generate new reference
packages](https://github.com/dotnet/source-build-reference-packages?tab=readme-ov-file#adding-new-packages).

### Current Source Built Packages

This refers to all of the packages produced in the current build. The set of
packages available to each repo varies based on its build order. For example the
msbuild repo can take a dependency on the current version of
Microsoft.CodeAnalysis from roslyn because roslyn builds before msbuild.
Conversely, since roslyn builds before msbuild, roslyn cannot take a dependency
on the current version of Microsoft.Build; it can only take a dependency on a
previously released version.

### Previous Source Built Packages

Because the .NET product uses itself to build, the .NET source build product
must be [bootstrapped](./bootstrapping-guidelines.md). This process allows the
packages from the previous source build release to be used to build the next
version of the product. This provides a means for breaking the product's
circular dependencies. For example repos like
[arcade](https://github.com/dotnet/arcade) can self-reference its previous
version to produce the next version.

When referencing previous source built packages, it is important to not leak
these previously built packages into the resulting packages/product. This is
considered a [poison leak](./leak-detection.md) and is not permitted during a
source build as it breaks the notion of building the product entirely from
source. This hinders the ability to service the product.

### Shared Component Packages

Non-1xx feature-band builds consume shared runtime and foundational packages
from the corresponding 1xx build. Unlike previously source-built (PSB)
packages, these packages can intentionally contribute to the final product.
See [feature-band source building](./feature-band-source-building.md) for the
artifact relationship between bands.

## Package Versions

Under the dependency-only flow, package dependencies defined using
[Arcade's dependency
patterns](https://github.com/dotnet/arcade/blob/main/Documentation/Darc.md) are
eligible for lifting during a source build when these conditions are met:

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

1. A repository reference is defined in the [VMR's project dependency
 graph](https://github.com/dotnet/dotnet/tree/main/repo-projects). This
reference does not have to be direct, it can be transitive.

For each repository build, the VMR writes these repository-specific files:

- `PackageVersions.<repo>.Previous.props` describes PSB packages.
- `PackageVersions.<repo>.Current.props` describes packages produced by
  dependencies earlier in the current build.
- `PackageVersions.<repo>.SharedComponents.props` describes shared-component
  inputs when they apply.
- `PackageVersions.<repo>.Snapshot.props` is an unfiltered snapshot of current
  packages used to attribute package production. It is not an imported version
  override.
- `PackageVersions.<repo>.props` aggregates the applicable input files.

`WritePackageVersionsProps` generates the property names from package IDs and a
caller-provided set of suffixes. Depending on the configured flow type, it
writes every available package or only dependencies declared by the repository.
The aggregate props file is imported after the repository's checked-in
`Versions.props` and imports the generated inputs in this order:

1. `Previous`
2. `Current`
3. `SharedComponents`

MSBuild properties use last-assignment-wins semantics. For values that reach
repository evaluation, a property in a later input replaces the same property
from an earlier input. This is package version lifting: package references that
use these properties request versions available from the effective VMR inputs
instead of the repository defaults. This behavior applies only to source build
in the [VMR](https://github.com/dotnet/dotnet) (see also
[Repo Level Source Builds](#repo-level-source-builds)).

### Property suffixes do not guarantee provenance

The PSB generator writes the usual `*Version` and `*PackageVersion` properties
and also writes `*PreviousVersion` properties. Shared-component generation uses
the same suffix set, while current generation uses only the usual suffixes.
Consequently, `PreviousVersion` describes the suffix used while generating a
property; it does not guarantee that the property's final value came from PSB.

If PSB and shared-component inputs contain the same package ID, both can
generate the same properties. Because `SharedComponents` is imported after
`Previous`, the shared-component assignments win. The effective property set is
therefore determined by the complete PSB, current, and shared-component input
matrix. A dependency update or change to current/shared-component inputs can
expose a bootstrap mismatch even when the PSB archive is unchanged and an
earlier build passed.

The VMR separately rejects package ID conflicts between shared components and
current packages whose repository origin is not `source-build-assets`. That
check does not prevent a PSB/shared-component property collision.

### Preserve versions that require a specific origin

Generated package-version properties select an effective version; they are not
provenance guarantees. If a component requires a version from a specific
origin, preserve it in a distinct, component-specific property before later
imports can overwrite the generic property, and use that property for the
dependency.

Standalone repository builds do not receive the VMR-generated files. The
component-specific property therefore also needs an appropriate fallback to the
repository's checked-in or current dependency property.

### Transitive Version Properties

Transitive version properties in your Versions.props file may not work as
intended with source build.

#### Versions.props

```xml
...
  <MicrosoftBuildFrameworkVersion>17.7.0-preview-23217-02</MicrosoftBuildFrameworkPackageVersion>
  <MicrosoftBuildVersion>$(MicrosoftBuildFrameworkVersion)</MicrosoftBuildPackageVersion>
...
```

#### Version.Details.xml

```xml
...
  <Dependency Name="Microsoft.Build.Framework" Version="17.7.0-preview-23217-02">
    <Uri>https://github.com/dotnet/msbuild</Uri>
    <Sha>2cbc8b6aef648cf21c6a68a0dab7fe09a614e475</Sha>
  </Dependency>
  <!-- No dependency is declared for "Microsoft.Build". -->
...
```

In this case source build will override the `MicrosoftBuildFrameworkVersion` to
the latest version but the `MicrosoftBuildVersion` will remain set to
`17.7.0-preview-23217-02` because of the property evaluation order. If the
desired behavior is for `MicrosoftBuildVersion` to be set to the same value as
`MicrosoftBuildFrameworkVersion` for source build, then you either need to
declare the Microsoft.Build dependency in the Version.Details.xml file or move
the `MicrosoftBuildVersion` assignment outside of the Versions.props file.

### Repo Level Source Builds

The source build package lifting mechanism is not applicable when building
individual repos in source build mode because it doesn't have the context of the
other product repos or previous source build release. In repo source build mode,
the versions of the packages declared in the Versions.props are used (see also
[backlog issue](https://github.com/dotnet/source-build/issues/3562)).
