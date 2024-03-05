# Eliminating pre-builts in .NET repositories

This is a detailed guide on how to eliminate pre-builts in a source-buildable repository.
It is primarily intended for developers contributing to the `dotnet` organization.

## Table of content

- [Introduction](#introduction)
- [What is a Pre-built](#what-is-a-pre-built)
- [Pre-built Detection](#pre-built-detection)
- [Types of Pre-builts](#types-of-pre-builts)
  - [Direct Dependencies](#direct-dependencies)
  - [Transitive Dependencies](#transitive-dependencies)
  - [Version Conflicts](#version-conflicts)
- [Identifying Pre-builts](#identifying-pre-builts)
- [Common Pre-built Examples](#common-pre-built-examples)
  - [Direct Dependency](#direct-dependency)
  - [Transitive Dependency](#transitive-dependency)
  - [Version Conflict](#version-conflict)
- [Allowed Exceptions](#allowed-exceptions)
- [Contacts](#contacts)

## Introduction

_Source-build_ is a process of building a given product on a single machine from source with no internet access.

Understanding pre-builts in a source-build context is crucial for developers contributing to the dotnet organization. This document provides a detailed guide on how to eliminate pre-builts in a source-buildable repository. It covers topics such as the definition of pre-builts, the reasons why they should be eliminated, pre-built detection, and the process of eliminating pre-builts.

## What is a Pre-built

### Definition

In the context of source-building, _pre-builts_ are dependencies that are not built from the source code during the current build process.

With the exception of dependencies that are picked up from the host distro, such as `cmake`, pre-builts can include reference packages, packages from online feeds such as `nuget.org` and `AzDO Artifacts`, Microsoft builds, directly downloaded binaries, or build tools that are used in the build process but are not themselves built from source during that process.

### Why We Care about Pre-builts

- **Reproducibility Issues -** By the nature of source-building, partners of the source-built product must be able to reproduce errors and actions in the software without making use of already compiled binaries. Pre-builts can be a hindrance to this reproducability.
- **Servicability -** Pre-builts can pose challenges to the ease of maintaining, updating, or repairing a product. If a product relies on pre-builts, addressing defects or vulnerabilities in these components can be difficult.
- **Security Concerns -** Source code is trustworthy because everything can be compiled from source, ensuring that the code can be audited and verified, and that no malicious code is present in the binaries. This security is not guaranteed when pre-builts are present in the source-code because pre-builts are not always built from source. 
- **Dependency Management -** Pre-builts might maintain dependencies that are unknown or different from the ones specified by the source-built code. These dependencies can lead to discrepancies and incompatibility issues in the product.
- **Building for Multiple Platforms and Architectures -** One advantage of source-building is that the software can be specifically configured for the environment it will be run in. Pre-builts, however, can be made for specific environments and thus hinder the product from running in various environments.

## Pre-built Detection

To protect against the use of pre-builts and detect them promptly, the Arcade source-build infrastructure provides _pre-built detection_.

_Pre-built detection_ is the MSBuild logic for ensuring that no dependency used is a pre-built. If a pre-built is identified (such as during a PR pipeline), the build will fail and an appropriate error message will be displayed:

```text
3 new packages used not in baseline! See report at ./artifacts/source-build/self/prebuilt-report/baseline-comparison.xml for more information. Package IDs are:
  Microsoft.Bcl.AsyncInterfaces.8.0.0-alpha.1.22557.11  
  Microsoft.Build.16.7.0
  Microsoft.Build.Framework.14.3.0
```

Pre-built detection identifies various types of dependencies. These include direct dependencies, indirect or transitive dependencies, build tooling, and dangling dependencies. Dangling dependencies refer to packages downloaded or used by tooling during the build process but not referenced by the project itself. Additionally, pre-built detection also considers dependencies retrieved from external sources that are not explicitly excluded from the detection process.

## Types of Pre-builts

Below are three common types of prebuilts. Examples on how to resolve these types of pre-builts can be found in [Common Pre-built examples](#common-pre-built-examples)

### Direct Dependencies

A direct dependency is something your code directly uses. In a .csproj file, you might have a reference like this.

```xml
<ItemGroup>
    <PackageReference Include="System.Text.Json" Version="8.0.0" />
</ItemGroup>
```

Here, `System.Text.Json` is a direct dependency.

### Transitive Dependencies

Transitive dependencies are the dependencies that are pulled in because your direct dependencies need them. These dependencies will be fetched automatically when you build your project, because they are dependencies of your direct dependencies, and they will not appear in your .csproj file:

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.Extensions.DependencyModel" Version="8.0.0" />
</ItemGroup>
```

In this example, if `Microsoft.Extensions.DependencyModel` depends on another package, then that package is a transitive dependency.

### Version Conflicts

Version conficts happen when different dependencies of your project need different versions of the same package. Let's say you have two direct dependencies, Microsoft.Build and Microsoft.CodeAnalysis.Features, in your project. Microsoft.Extensions.DependencyModel requires version 6.0.0 of System.Text.Json and Microsoft.CodeAnalysis.Features requires version 9.0.0-preview.1.24073.8 of System.Text.Json:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Build" Version="17.3.2" /> <!-- depends on 'System.Text.Json' version 6.0.0 -->
  <PackageReference Include="Microsoft.CodeAnalysis.Features" Version="4.10.0-1.24067.21" /> <!-- depends on 'System.Text.Json' version 9.0.0-preview.1.24073.8 -->
</ItemGroup>
```

This is a version mismatch. In this case, `System.Text.Json.6.0.0` and `System.Text.Json.9.0.0-preview.1.24073.8` are also transitive dependencies.

## Identifying Pre-builts

A build might encounter a failure caused by the introduction of a new pre-built. Such failures will block merging.

Source build the repository if you haven't already done so. This can be done by running the following command:

 ```sh
  ./build.sh --sb
  ```

If a new unhandled pre-built is found, the build will fail with an error pointing to the exact package and version of the dependency that was detected as a pre-built.

At this point, it is important to determine what caused the pre-built:

1. Begin by looking at the generated pre-built detection reports, located in the `./artifacts/sb/prebuilt-report` directory. This directory contains the following files:
    1. `annotated-usage.xml` - Contains information about how each pre-built package is used within the project.
    2. `baseline-comparison.xml` - Comparison between the `generated-new-baseline.xml` and the current pre-built baseline file, `./eng/SourceBuildPrebuiltBaseline.xml`
    3. `generated-new-baseline.xml` - The newly generated baseline for all detected pre-builts.
    4. `prebuilt-usage.xml` - Report of all detected pre-builts, including those in the baseline.
2. Determine which pre-builts to tackle.
    1. If you have detected a new pre-built that is not in the current baseline, `./eng/SourceBuildPrebuiltBaseline.xml`, continue to step 3.0.
    2. If you are trying to eliminate a pre-built that currently exists in the baseline, do so cautiously. More often than not, pre-builts in the baseline contain comments about why they are in the baseline and when/if it is appropriate the eliminate the pre-built.
3. Examine `./prebuilt-usage.xml`.
    1. Begin by tackling the direct dependencies. These are dependencies with `IsDirectDependency="true"` attribute. Eliminating pre-builts that are direct dependencies will often eliminate related transitive pre-builts. After eliminating all direct dependency pre-builts, eliminate other pre-builts using the same steps below. Refer to [Common Pre-built examples](#common-pre-built-examples) for helpful pre-built examples and use cases.
    2. If available, locate the `project.assets.json` file for the pre-built referenced in the `./prebuilt-usage.xml` file (some dependencies, such as implicit framework references, don't have `project.assets.json` entries. If this is the case for your pre-built, skip this step and the following step):

        ```xml
        <UsageData>
          <Usages>
            <Usage Id="Microsoft.Build.Utilities.Core" Version="17.3.2" File=".../SomeProject/project.assets.json"  IsDirectDependency="true">
          </Usages>
        </UsageData>
        ```

    3. Identify the pre-built in `project.assets.json`:

        ```json
          { 
            "targets": {
              "net9.0": {
                "Microsoft.Build.Utilities.Core/17.3.2": {
                  "type": "package",
                  "dependencies": {
                    ...
                  }
                }
              }
            }
          }
        ```

With this information retrieved, the [adding a new source-build dependency](https://github.com/dotnet/source-build/blob/main/Documentation/sourcebuild-in-repos/new-dependencies.md#adding-dependencies) documentation should be referred to as the main guide for resolving the pre-built.

## Common Pre-built Examples

Pre-builts are almost always caused by adding or updating a dependency within a repository. In more detail, the introduction of new pre-builts are often attributed to direct dependencies, transitive dependencies, and version mismatches.

### Direct Dependency

Your build has output the following error message:

```text
1 new packages used not in baseline! See report at ./artifacts/source-build/self/prebuilt-report/baseline-comparison.xml for more information. Package IDs are:
  System.Text.Json.8.0.0
```

You examine `./prebuilt-usage.xml` and see the following:

```xml
<UsageData>
  <Usages>
    <Usage Id="System.Text.Json" Version="8.0.0" File=".../SomeProject/project.assets.json" IsDirectDependency="true">
  </Usages>
</UsageData>
```

The `project.assets.json` file shows the following:

```json
{ 
  "targets": {
    "net8.0": {
      "System.Text.Json/8.0.0": {
        "type": "package",
        "dependencies": {
        }
      }
    }
  }
}
```

You find a package reference to `System.Text.Json.8.0.0`, like the one above, in one of your .csproj files:

```xml
<ItemGroup>
    <PackageReference Include="System.Text.Json" Version="8.0.0" />
</ItemGroup>
```

In this example, `System.Text.Json` is a direct dependency causing a pre-built.

At this point, determine how to handle the dependency by following the [adding dependencies documentation](https://github.com/dotnet/source-build/blob/main/Documentation/sourcebuild-in-repos/new-dependencies.md#adding-dependencies). Based on what you determine, you will likely have to do one or more of the following:

- **Update version -** Update the version of System.Text.Json to match the version of the repository that the package is flowing in from.
- **Use Version.Details and Version.Props -**
  - Add an entry to `./eng/Version.Details.xml` for System.Text.Json
  - Define/use `<SystemTextJsonVersion>8.0.0</SystemTextJsonVersion>` in `./eng/Versions.Props`
- **Source-build-reference-packages -** Add `System.Text.Json.8.0.0` to the [source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages/) repo.
- **Source-build-externals -** (Note, System.Text.Json is not an appropriate candidate for source-build-externals) Add the dependency to the [source-build-externals](https://github.com/dotnet/source-build-externals) repo.

### Transitive Dependency

Your build has output the following error message:

```text
1 new packages used not in baseline! See report at ./artifacts/source-build/self/prebuilt-report/baseline-comparison.xml for more information. Package IDs are:
  System.Text.Json.8.0.0
```

You examine `./prebuilt-usage.xml` and see the following:

```xml
<UsageData>
  <Usages>
    <Usage Id="System.Text.Json" Version="8.0.0" File=".../SomeProject/project.assets.json">
  </Usages>
</UsageData>
```

Note that the `IsDirectDependency="true"` attribute is not present for this pre-built.

The `project.assets.json` file shows the following:

```json
{ 
  "targets": {
    "net8.0": {
      "Microsoft.Extensions.DependencyModel/8.0.0": {
        "type": "package",
        "dependencies": {
          "System.Text.Json": "8.0.0"
        }
      }
    }
  }
}
```

In this example, `Microsoft.Extensions.DependencyModel` would be the direct dependency causing the `System.Text.Json` pre-built.

At this point, determine how to handle the dependency by following [adding dependencies documentation](https://github.com/dotnet/source-build/blob/main/Documentation/sourcebuild-in-repos/new-dependencies.md#adding-dependencies). Based on what you determine, you will likely have to do one or more of the following:

- **Update version -** Use a different version of Microsoft.Extensions.DependencyModel.
- **Use Version.Details and Version.Props -**
  - Add entries to `./eng/Version.Details.xml` for Microsoft.Extensions.DependencyModel and System.Text.Json.
  - Define/use `<MicrosoftExtensionsDependencyModelVersion>8.0.0</MicrosoftExtensionsDependencyModelVersion>` and `<SystemTextJsonVersion>8.0.0</SystemTextJsonVersion>` in `./eng/Versions.Props`
- **Source-build-reference-packages -** Add System.Text.Json.8.0.0 to the [source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages/) repo.
- **Source-build-externals -** (Note, System.Text.Json is not an appropriate candidate for source-build-externals) Add the dependency to the [source-build-externals](https://github.com/dotnet/source-build-externals) repo.

### Version Conflict

Your build has output the following error message:

```text
2 new packages used not in baseline! See report at ./artifacts/source-build/self/prebuilt-report/baseline-comparison.xml for more information. Package IDs are:
  System.Text.Json.6.0.0
  System.Text.Json.9.0.0-preview.1.24073.8
```

You examine `./prebuilt-usage.xml` and see the following:

```xml
<UsageData>
  <Usages>
    <Usage Id="System.Text.Json" Version="6.0.0" File=".../SomeProject/project.assets.json">
    <Usage Id="System.Text.Json" Version="9.0.0-preview.1.24073.8" File=".../SomeProject/project.assets.json">
  </Usages>
</UsageData>
```

Note that the `IsDirectDependency="true"` attribute is not present for these pre-builts.

The `project.assets.json` file shows the following:

```json
{ 
  "targets": {
    "net9.0": {
      "Microsoft.Build/17.3.2": {
        "type": "package",
        "dependencies": {
          "System.Text.Json": "6.0.0"
        }
      },
      "Microsoft.CodeAnalysis.Features/4.10.0-1.24067.21": {
        "type": "package",
        "dependencies": {
          "System.Text.Json": "9.0.0-preview.1.24073.8"
        },
      }
    }
  }
}
```

At this point, determine how to handle the dependencies by following At this point, determine how to handle the dependency by following [adding dependencies documentation](https://github.com/dotnet/source-build/blob/main/Documentation/sourcebuild-in-repos/new-dependencies.md#adding-dependencies). Based on what you determine, you will likely have to do one or more of the following:

- **Update version -** Use a different versions of Microsoft.Build and/or Microsoft.CodeAnalysis.Features.
- **Use Version.Details and Version.Props -**
  - Investigate the repos for Microsoft.Build and Microsoft.CodeAnalysis.Features. They may need to flow in the live versions of System.Text.Json. In this case, add System.Text.Json as a package reference & update `./eng/Version.Details.xml` and `./eng/Versions.Props` for System.Text.Json in these repos.
  - Add entries to `./eng/Version.Details.xml` for Microsoft.Build, Microsoft.CodeAnalysis.Features, and System.Text.Json.
  - Define/use `<MicrosoftBuildVersion>17.3.2</MicrosoftBuildVersion>`, `<MicrosoftCodeAnalysisFeaturesVersion>4.10.0-1.24067.21</MicrosoftCodeAnalysisFeaturesVersion>`, and `<SystemTextJsonVersion>9.0.0-preview.1.24073.8</SystemTextJsonVersion>` in `./eng/Versions.Props`
- **Source-build-reference-packages -** Add System.Text.Json.6.0.0 and potentially System.Text.Json.9.0.0-preview.1.24073.8 to the [source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages/) repo.
- **Source-build-externals -** (Note, System.Text.Json is not an appropriate candidate for source-build-externals) Add the dependency to the [source-build-externals](https://github.com/dotnet/source-build-externals) repo.

## Allowed Exceptions

The list of permitted pre-builts can be found in the `./eng/SourceBuildPrebuiltBaseline.xml` file in the root of the repository. It contains package information of pre-builts that for one reason or another are allowed in the source-build of the repository.

Any new addition to the pre-built exception list must be signed-off by a member of the `@dotnet/source-build-internal` team. **The newly added exception should also include a comment with a link to an issue or an in-depth description about why the exception is needed.**

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

## Contacts

For any questions or additional information about this document, pre-builts or source-build in general, please create an [issue](https://github.com/dotnet/source-build/issues) or open a [discussion](https://github.com/dotnet/source-build/discussions) in the [source-build](https://github.com/dotnet/source-build) repository.
