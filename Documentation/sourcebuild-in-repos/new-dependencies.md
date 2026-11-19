# Adding a new dependency

Adding a NuGet package reference is not enough to make a dependency available
to source-build. A normal repository build can restore a published binary from
NuGet. The VMR (Virtual Monolithic Repository) source-build must instead build
the product from source using prepared local inputs, without relying on online
package feeds. Having open-source code available does not by itself integrate
it into the build.

These requirements apply to every package used in the VMR source-build,
whether it is produced by a VMR repository,
[Source Build Assets (SBA)][sba-repo], or supplied through another allowed
source-build input. They include **transitive dependencies** and packages used
as build tools, not just packages named directly in a project. For example, if
package A depends on package B, source-building A is not enough. B must also
come from an allowed source-build input. A version upgrade can introduce the
same problem without adding a new NuGet package reference.

## Requirements for packages used by the VMR source-build

Before making a product change depend on a package, work out how the VMR
source-build will obtain it. If the package or required version is not already
source-built, we recommend [opening a source-build
issue][source-build-issue] to coordinate
the integration with the source-build team.

1. **Identify the complete dependency set and its use.** Check the package's
   direct and transitive dependencies, including the tools needed to build its
   source. Determine which packages provide executable implementation and
   which are needed only as compile-time references or text assets. Check
   whether the required package versions, not just their repositories, are
   available in the VMR. A repository-level SourceBuild leg does not prove
   that the VMR produces the specific package version.
1. **Build implementations from source in the VMR.** Packages that contain
   executable code used by the product must be built from their source as part
   of the VMR build. This includes
   their transitive implementation dependencies. Build-time packages must
   also come from the VMR build or an allowed source-build input so the build
   runs without network access. The limited reference-only, text-only, and
   bootstrap inputs are described
   [below](#reference-only-text-only-and-bootstrap-inputs).
   Before flowing implementation packages to consumers, check the produced
   package and binary versions. Preserve strong names when the original
   binaries have them.
1. **Check that the sources can be included in the VMR.** Included sources must
   meet the VMR's [license and binary
   policies](https://github.com/dotnet/dotnet/blob/main/docs/VMR-Permissible-Sources.md).
   Public source hosting alone does not establish license compliance.
   Checked-in binaries are subject to validation and source-build cleaning;
   they are not a substitute for building the dependency.
1. **Connect the producer to its consumers.** For packages produced in the
   VMR, make the source-built packages available before the consuming
   repository builds, and align the requested versions with the produced
   versions. Coordinate producer and consumer changes so the dependency does
   not reach the VMR before its source-build support. See [package dependency
   flow](../package-dependency-flow.md) for repository ordering and version
   overrides.
1. **Validate in the VMR source-build.** Validate the integration with a [full
   VMR source-build](https://github.com/dotnet/dotnet/blob/main/README.md#building),
   not only a normal repository
   build or a repository-level source-build leg.

## Adding dependencies

### Choose an integration path

Choose how to provide the package based on its producer. The requirements
above apply to each path:

- **A package already produced by the VMR:** Reuse that producer and arrange
  the graph and version flow.
- **A repository onboarded directly into the VMR:** Follow the
  [VMR Repository Onboarding
  Guide](https://github.com/dotnet/dotnet/blob/main/docs/Repository-Onboarding.md).
  This path requires Arcade onboarding, builds registered in BAR, and
  source-build compatibility.
- **An external component built through [SBA][sba-repo]:** Use this option for
  a repository that does not use Arcade and cannot be onboarded directly.
  Repositories with few dependencies and simple builds are good candidates.
  Pin the source submodule to the revision for the release tag corresponding to
  the package version, and maintain its build project and patches. Coordinate
  the
  [SBA][sba-repo] source flow with consumer version updates so the package is
  available when needed. Follow the [SBA][sba-repo] guidance for
  [adding an external component](https://github.com/dotnet/source-build-assets/blob/main/README.md#adding-a-new-external-component).

If none of these paths fits an implementation dependency, coordinate with the
source-build team before adding it.

## Reference-only, text-only, and bootstrap inputs

These inputs have specific uses and do not replace product implementations:

- **Reference-only:** [SBA][sba-repo] reference packages contain API
  signatures, not implementations. Targeting packages bundle reference
  assemblies. Neither replaces code that executes during the build or ships
  with the product, and [SBA][sba-repo] reference assemblies must not leak
  into SDK output. See the
  [reference package](https://github.com/dotnet/source-build-assets/blob/main/README.md#reference)
  and [targeting package](https://github.com/dotnet/source-build-assets/blob/main/README.md#targeting)
  guidance, including restrictions on current-major and preview versions.
- **Text-only:** Packages containing only text assets, such as props and
  targets without executable code, can use [SBA][sba-repo]'s [text-only package
  process](https://github.com/dotnet/source-build-assets/blob/main/README.md#text-only).
  Any implementation dependencies those assets introduce still need to be
  accounted for.
- **Bootstrap:** Previously source-built (PSB) packages can supply tools and
  other build-time inputs, but PSB implementations must not leak into the
  product. See
  [previously source-built packages](../package-dependency-flow.md#previous-source-built-packages)
  and [bootstrapping guidelines](../bootstrapping-guidelines.md).

## Basics

For dependencies managed through Arcade, declare the package and its producing
repository in the dependency metadata. `darc add-dependency` handles the normal
dependency entries; verify the source-build metadata and flow as well.
For manual changes:

1. Add the package and a default version to eng/Versions.props.  The default
  version property should be named `<PackageName>PackageVersion`, e.g.
  `SystemCollectionsImmutablePackageVersion`.
1. Add the package and a repo reference to eng/Version.Details.xml.  This should
  include a SourceBuild metadata entry, looking something like:

```xml
   <Dependency Name="Microsoft.Net.Compilers.Toolset"
                  Version="4.2.0-3.22205.5"
                  CoherentParentDependency="Microsoft.NET.Sdk">
      <Uri>https://github.com/dotnet/roslyn</Uri>
      <Sha>0167599e0e1634ea3ed8d0e41390a3c0d9b3e4e9</Sha>
      <SourceBuild RepoName="roslyn" ManagedOnly="true" />
    </Dependency>
```

1. Set up dependency flow from the foreign repo to your repo.

In general, aim to use one implementation version of each package and align
consumers with the version produced by the source-build graph. Multiple
reference-only versions can satisfy different compile-time requirements.
If multiple implementation versions are needed, coordinate that explicitly;
[SBA][sba-repo] documents how to [build multiple versions of an external
component](https://github.com/dotnet/source-build-assets/blob/main/README.md#building-multiple-versions-of-an-external-component).

The source-build metadata is important - this tells source-build which repo
package contains the specific nupkg you want.

Another uncommon case that can cause problems is when the repo `<Dependency>`
version and the source-built intermediate package version don't match. In this
case, a direct dependency should be added to the source-build intermediate
package and the CoherentParentDependency attribute should be set to the repo
that consumes the dependency. For an example, see [installer's F#
dependency](https://github.com/dotnet/installer/blob/ba1739a2363b1062f03ea386ec67174c6468d3b2/eng/Version.Details.xml#L128).
You can find the version needed by running `darc get-build` or using
[BAR](https://aka.ms/bar).

## Deciding what version to use

- If you are using the package as reference-only and want the version to be
  pinned, use a literal version number in the csprojs that reference the
  project.  You can also set up a reference-only package version variable in
  eng/Versions.props, for instance
  `<PackageNameReferenceOnly>1.2.3</PackageNameReferenceOnly>` in addition to
  `<PackageNamePackageVersion>4.5.6</PackageNamePackageVersion>`. Also verify
  that the package is available in
  [Source Build Assets][sba-repo],
  and if not, consider [opening a source-build
  issue][source-build-issue].
- If you are using the package in the actual build or want the version to be
  updated whenever the foreign repo publishes to your channel, use the version
  number property set up in eng/Versions.props.  When performing a source-build,
  the version number will get updated to the current source-built version.
- If you are using an external or non-Arcade package, please coordinate as much
  as possible with other teams using that package.  Each package-version is
  essentially maintained as a separate concern, so something like repo A
  requiring Newtonsoft.Json 9.0.1 and repo B requiring 12.0.2 essentially
  doubles the source-build team's work.

[sba-repo]: https://github.com/dotnet/source-build-assets
[source-build-issue]: https://github.com/dotnet/source-build/issues/new/choose
