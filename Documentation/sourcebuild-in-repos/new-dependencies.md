# Adding a new dependency

## Basics

When adding a new dependency, there are a few steps common between any type of
dependency.  If you use darc, `darc add-dependency` will take care of this
process for you.  Otherwise:

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

In general, you should aim to use one version of each package.  If you are using
a package as reference-only, it is possible to use multiple versions, but only
one implementation version of each package will be used - source-build will
override it to the version that is being built in this version of the SDK.

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

## Adding dependencies

Source build classifies dependencies in the following ways

1. .NET - a dependency on a component from the .NET org - e.g. dotnet/runtime
1. Microsoft - a dependency on a component from the Microsoft org - e.g.
   microsoft/vstest
1. External - a dependency on a component outside of Microsoft/.NET - e.g.
   JamesNK/Newtonsoft.Json

The following checklist can be used to determine how to handle each type of
dependency and the nuances it may have.

1. Are you already using a package from the same repo and is the new dependency
  already source-built?  You can determine this by checking if the repo has a
  SourceBuild leg building, e.g. runtime's is `runtime-dev-innerloop (Build
  Linux x64 release SourceBuild)`.

    1. This is the simplest case.  You can add new dependencies from repos you
      are already using freely.  Note that you need to use the same version for
      all packages from the repo.
1. Is the repo already built in source-build including the specific package you
  want?
    1. Add the dependency using [`darc
      add-dependency`](https://github.com/dotnet/arcade/blob/main/Documentation/Darc.md#add-dependency)
      as normal, then add the [source-build metadata](#basics) as above.
1. Is the repo already built in source-build but the specific package is not?
    1. There's probably an issue with source-building this package.  Please talk
      to a [source-build team
      member](https://github.com/orgs/dotnet/teams/source-build) about
      why that is and whether we can fix it.
1. Is this a repo that uses Arcade to build?
    1. Does the foreign repo depend on your repo, directly or indirectly? i.e.
      would adding the dependency create a cycle?
        1. This isn't necessarily a deal-breaker - it can sometimes be worked
          around with reference-only packages.  Please contact a [source-build
          team
          member](https://github.com/orgs/dotnet/teams/source-build) to
          discuss.
    1. Does the foreign repo publish to BAR?
        1. If not, please contact them to get them publishing to BAR in an
          appropriate channel.
    1. If neither of these caveats apply you should be in good shape. Follow the
      instructions under "Basics" above.
1. Dependencies that have no code (e.g. SDKs with just props and targets) can
  usually be added using the [source-build text-only-package
  process](https://github.com/dotnet/source-build-reference-packages/tree/main/src/textOnlyPackages/src).
  If the package is not already included there, you can [open a
  PR](https://github.com/dotnet/source-build-reference-packages/pulls) or [file
  an issue](https://github.com/dotnet/source-build/issues/new/choose) to include
  it.
1. Source-build has in the past used Arcade shims to allow non-Arcade repos to
  build appropriate packages for source-build.  Please [log an
  issue](https://github.com/dotnet/source-build/issues/new/choose) to determine
  if this is a workable approach for your foreign repo.
1. We build some external dependencies in the
  [dotnet/source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages/tree/main/src/externalPackages/src)
  repo.  Good targets for this generally have very few if any dependencies and
  very simple build processes. [Please log an
  issue](https://github.com/dotnet/source-build/issues/new/choose) to get the
  process started.

## Deciding what version to use

- If you are using the package as reference-only and want the version to be
  pinned, use a literal version number in the csprojs that reference the
  project.  You can also set up a reference-only package version variable in
  eng/Versions.props, for instance
  `<PackageNameReferenceOnly>1.2.3</PackageNameReferenceOnly>` in addition to
  `<PackageNamePackageVersion>4.5.6</PackageNamePackageVersion>`. Also verify
  that the package is available in
  [source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages),
  and if not, [file a source-build
  issue](https://github.com/dotnet/source-build/issues).
- If you are using the package in the actual build or want the version to be
  updated whenever the foreign repo publishes to your channel, use the version
  number property set up in eng/Versions.props.  When performing a source-build,
  the version number will get updated to the current source-built version.
- If you are using an external or non-Arcade package, please coordinate as much
  as possible with other teams using that package.  Each package-version is
  essentially maintained as a separate concern, so something like repo A
  requiring Newtonsoft.Json 9.0.1 and repo B requiring 12.0.2 essentially
  doubles the source-build team's work.
