# Eliminating pre-builts in .NET repositories

This is a detailed guide on how to eliminate pre-builts in a source-buildable repository.
It is primarily intended for developers contributing to the `dotnet` organization.

> **Important**: Starting with .NET 10.0, prebuilt detection was removed from individual repositories due to accuracy and usability issues.
> Prebuilt detection now only occurs within the VMR (Virtual Monolithic Repository).

## Table of contents

- [What is a Prebuilt](#what-is-a-prebuilt)
- [.NET 10.0+ VMR-based prebuilt detection](#net-100-vmr-based-prebuilt-detection)
- [Pre-10.0 repository-based prebuilt detection](#pre-100-repository-based-prebuilt-detection)
- [Allowed exceptions (Pre-10.0)](#allowed-exceptions-pre-100)
- [Contacts](#contacts)

## What is a Prebuilt

_Source-build_ is a process of building a given product on a single machine from
source with no internet access.

By definition, _pre-builts_ are dependencies that are not built from source,
such as reference packages, nuget packages and built tools. _Build from source_
points to any package produced during the _current source-build_ with the
exception of dependencies that are picked up from the host distro such as
`cmake`. In layman terms, this means that packages from `nuget.org`, Microsoft
builds or other non-source-built binaries cannot be used for source-building a
given repository.

When onboarding a repository to source-build or adding a new dependency to a
source-buildable one, the contributor runs the risk of introducing a new
pre-built to the product. To protect against this, the source-build infrastructure provides _pre-built
detection_ - MSBuild logic responsible for verifying that no used dependency is a
pre-built. In case one is discovered (for example, during a PR pipeline), the
build will fail with an appropriate message somewhat similar to the following:

```text
3 new packages used not in baseline! See report at ./artifacts/log/Release/baseline-comparison.xml for more information. Package IDs are:
  Microsoft.Bcl.AsyncInterfaces.8.0.0-alpha.1.22557.11  
  Microsoft.Build.16.7.0
  Microsoft.Build.Framework.14.3.0
```

Pre-built detection identifies the source of dependencies used to build the
repository. These dependencies include not only direct dependencies, but also
build tooling as well as dangling dependencies - packages downloaded / used by
tooling during the build process and not referenced by the project itself.
Dependencies retrieved from external sources that are not explicitly excluded
from pre-built detection will be flagged as pre-builts.

## .NET 10.0+ VMR-based prebuilt detection

Starting with .NET 10.0, prebuilt detection was removed from individual repositories because it was inaccurate and problematic.
Prebuilt detection now only occurs during full source builds within the VMR.

### For repository developers

Prebuilts will typically be surfaced when repository changes forward flow into the VMR.
There are two ways to detect prebuilts before they reach the VMR:

1. **VMR validation against repository PRs**: Use the process described in [VMR Validation documentation](https://github.com/dotnet/arcade/blob/main/Documentation/VmrValidation.md) to validate your repository changes against the VMR.

2. **Direct VMR changes**: Changes made directly against the VMR will have prebuilt detection performed as part of the PR validation checks.

### VMR source-build instructions

Prebuilt detection is enabled anytime a source build is performed within the VMR.
For complete guidance on how to build the VMR from source, see the [VMR build documentation](https://github.com/dotnet/dotnet/blob/main/README.md#building).

### Resolving prebuilts

When prebuilts are detected in the VMR, they will cause a build failure.
Refer to the [adding a new source-build dependency](https://github.com/dotnet/source-build/blob/main/Documentation/sourcebuild-in-repos/new-dependencies.md) documentation for guidance on resolving them.

## Pre-10.0 repository-based prebuilt detection

To check if new pre-builts were introduced, the repository needs to be
source-built first. This can be done through the following command:

```sh
./build.sh --sb
```

If a new unhandled pre-built is found, the build will fail with a detailed
exception pointing to the exact package / version of the dependency that caused
the failure. Additional information can also be found in the generated pre-built
detection reports, located in the
`./artifacts/source-build/self/prebuild-report` directory, specifically in the
`./prebuild-usage.xml` file. The information in question can, for example, be
the path to the project that is referencing the dependency.

Once you've identified a pre-built, refer to the [adding a new source-build dependency](https://github.com/dotnet/source-build/blob/main/Documentation/sourcebuild-in-repos/new-dependencies.md) documentation for guidance on resolving it.

## Pre-builts through transitive dependencies

During a project dependency update, a new pre-built might be introduced by a
new or updated transitive dependency. While the Arcade tooling will highlight
the name and version of the pre-built in the build exception as well as the
project that restored the dependency in question, it will not point out where
exactly in the dependency tree it is. This means that it's up to the developer
to identify what type of dependency they are dealing with (direct or transitive)
and choose the correct way of handling the issue. In case of a transitive
dependency, it might be hard to identify the relationship that is bringing in
the pre-built into the project, especially if the developer has limited
knowledge of the project or code-base in general.

Arcade source-build infrastructure helps accomplish this by pointing out
the `project.assets.json` file that is referencing the pre-built in the
`./artifacts/log/Release/prebuilt-usage.xml` report file.
A `project.assets.json` file is a NuGet restore process artifact that contains a
resolved dependency tree for a specific project. Every package that was restored
by a given project is mentioned there with links between the dependencies,
allowing the reader to identify transitive dependencies and the direct
dependencies referencing them.

Example of a pre-built caused by a transitive dependency and corresponding
entries in files mentioned above:

Exception identifying the pre-built:

```text
1 new packages used not in baseline! See report at ./artifacts/log/Release/baseline-comparison.xml for more information. Package IDs are:
  System.Text.Json.8.0.0
```

Entry in prebuilt-usage.xml:

```xml
<UsageData>
  <Usages>
    <Usage Id="System.Text.Json" Version="8.0.0" File=".../SomeProject/project.assets.json">
  </Usages>
</UsageData>
```

Entry in project.assets.json:

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

In this example, `Microsoft.Extensions.DependencyModel` would be the direct
dependency causing the `System.Text.Json` pre-built.

## Allowed exceptions (Pre-10.0)

> **Note**: The information in this section applies to .NET versions **prior to 10.0**.

The list of permitted pre-builts can be found in the `./eng/SourceBuildPrebuiltBaseline.xml` file in the root of the repository.
It contains package information of pre-builts that for one reason or another are allowed in the source-build of the repository.

Any new additions to the pre-built exception list must be signed-off by a member of the `@dotnet/source-build` team.

In cases where a specific package needs to be excluded from pre-built detection
(for example, to not block the introduction of changes until a source-build
acceptable solution for the pre-built is provided), the developer can directly
specify the name / version of the dependency:

```xml
<UsageData>
  <Usages>
    <Usage Id="Foo.Bar" Version="x.y.z" />
  </Usages>
</UsageData>
```

If a new pre-built is encountered, pre-built detection will also generate a new
version of the baseline file by adding the dependency that contains the
pre-built to the existing baseline. The new file can be found at
`./artifacts/source-build/self/prebuild-report/generated-new-baseline.xml`.

## Contacts

For questions or additional information about this document, pre-builts or source-build in general, please use one of the following:

- [Open an issue](https://github.com/dotnet/source-build/issues)
- [Create a new discussion](https://github.com/dotnet/source-build/discussions)
- [Mention @dotnet/source-build](https://github.com/orgs/dotnet/teams/source-build)
