# Adding New Dependencies in .NET repositories

This is a detailed guide on how to add a new dependency in a source-buildable repository.
It is primarily intended for developers contributing to the `dotnet` organization.

## Table of content

- [Introduction](#introduction)
- [Background Information](#background-information)
- [Adding dependencies](#adding-dependencies)
  - [Case 1: Already Using a Package from the Same Repo](#case-1-already-using-a-package-from-the-same-repo)
  - [Case 2: Repo is source built](#case-2-repo-is-source-built)
  - [Case 3: Repo Built in Source-Build but Specific Package is Not](#case-3-repo-built-in-source-build-but-specific-package-is-not)
  - [Case 4: Repo uses Arcade to Build](#case-4-repo-uses-arcade-to-build)
  - [Case 5: Reference Only/Pinned Version Dependencies](#case-5-reference-onlypinned-version-dependencies)
  - [Case 6: Dependencies with No Code](#case-6-dependencies-with-no-code)
  - [Case 7: Non-Arcade Repos](#case-7-non-arcade-repos)
  - [Case 8: External Dependencies](#case-8-external-dependencies)
- [Versioning](#versioning)
- [Contacts](#contacts)

## Introduction

Understanding how to add a dependency in a source-build context is crucial for developers contributing to the dotnet organization. This document provides a detailed guide on how to add such dependencies. It covers topics such as types of dependencies, how and where to add a dependency, and how adding different dependencies may work to resolve pre-builts.

## Background Information

When adding a new dependency, there are a few steps common between any type
of dependency. 

1. Always use darc. `darc add-dependency` will take care of
this process for you. Be sure to set up dependency flow from the foreign repo to your repo.
1. Aim to use one version of each package.  If you are using a package as reference-only, it is possible to use multiple versions, but only one implementation version of each package will be used - source-build will override it to the version that is being built in this version of the SDK.
1. The source-build metadata is important - this tells source-build which repo
package contains the specific nupkg you want. It should only be placed on an entry for `Microsoft.SourceBuild.Intermediate.reponame` in `Version.Details`. Placing it on a non-intermediate dependency will result in errors. See [Case 2: Repo is source built](#case-2-repo-is-source-built) for more information on the source-built metadata.
1. In the case where the repo `<Dependency>` version and the source-built intermediate package version don't match, place `CoherentParentDependency` attributes to the repo that consumes the dependency on the dependency and related source-built intermediate entry. For an example, see [installer's F# dependency](https://github.com/dotnet/installer/blob/ba1739a2363b1062f03ea386ec67174c6468d3b2/eng/Version.Details.xml#L128). You can find the version needed by running `darc get-build` or using [BAR](https://aka.ms/bar).

## Adding dependencies

Source build classifies dependencies in the following ways:

1. .NET - a dependency on a component from the .NET org - e.g. dotnet/runtime
2. Microsoft - a dependency on a component from the Microsoft org - e.g. microsoft/vstest
3. External - a dependency on a component outside of Microsoft/.NET - e.g. JamesNK/Newtonsoft.Json

### Case 1: Already Using a Package from the Same Repo

Ensure that the repo is source-built and the new dependency is source-built (you can verify this by checking if the repo has a source-build build leg and that the dependency is in previously-source-built artifacts).

If both are source-built and you are already using a package from the new dependency's repo, then you can freely add the new dependency using [`darc add-dependency`](https://github.com/dotnet/arcade/blob/main/Documentation/Darc.md#add-dependency) as normal.

If you're experiencing a prebuilt and your dependency falls under this case, first ensure that it's already been added via `darc add-dependency`, then try bumping the version of the dependency with [`darc update-dependencies`](https://github.com/dotnet/arcade/blob/main/Documentation/Darc.md#update-dependencies).

### Case 2: Repo is source built

This is the first time that you're adding a dependency from a given repo. First, ensure that the repo is source-built (you can verify this by checking if the repo has a source-build build leg). Next, verify that the dependency is source-built (you can verify this by checking if the dependency is in previously-source-built artifacts).

If the repo and the dependency are both source-built, add the new dependency using [`darc add-dependency`](https://github.com/dotnet/arcade/blob/main/Documentation/Darc.md#add-dependency). Next, add a new dependency on the repo's source-built intermediate package using add the new dependency using [`darc add-dependency`](https://github.com/dotnet/arcade/blob/main/Documentation/Darc.md#add-dependency). Include the source-built metadata (`<SourceBuild RepoName="reponamne" ManagedOnly="trueOrfalse" />`) on the intermediate package.

The source-built intermediate should look like this:
```xml
   <Dependency Name="Microsoft.Intermediate.sourcebuilt.reponame" Version="repoversion" >
      <Uri>https://github.com/dotnet/reponame</Uri>
      <Sha>Sha</Sha>
      <SourceBuild RepoName="reponame" ManagedOnly="trueOrfalse" />
    </Dependency>
```

If your new dependency has a coherent parent, make sure to add the coherent parent attribute to the source-built intermediate dependency as well.

If you're experiencing a prebuilt and your dependency falls under this case, ensure that you've added the source-built intermediate with the appropriate metadata.

### Case 3: Repo Built in Source-Build but Specific Package is Not

There's probably an issue with source-building this package. Please talk to a [source-build team member](https://github.com/orgs/dotnet/teams/source-build-internal) about why that is and whether we can fix it.

### Case 4: Repo uses Arcade to Build

If the foreign repo depends on your repo, either directly or indirectly (adding the dependency creates a cycle), then please contact a [source-build team member](https://github.com/orgs/dotnet/teams/source-build-internal) to discuss.

If the foreign repo does not publish to BAR, please contact the repo to get them publishing to BAR in an appropriate channel.

If neither of the above caveats apply to you, follow the instructions under **Case 2: Repo is source built** above.

### Case 5: Reference Only/Pinned Version Dependencies

If you are using the package as reference-only and want the version to be pinned, use a source-build-reference-package.

First, verify that the package is available in [source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages), and if not, follow the instructions in the README.md to add the reference package.

You can also set up a reference-only package version variable in `eng/Versions.props`, for instance `<PackageNameReferenceOnly>1.2.3</PackageNameReferenceOnly>` in addition to `<PackageNamePackageVersion>4.5.6</PackageNamePackageVersion>`.

If you're trying to resolve a prebuilt, adding a package to SBRP isn't always the right step to take. In the context of the VMR, if the dependency causing your prebuilt comes from another repo that gets built before your repo, the package in SBRP is not needed because the VMR will flow the live version so long as it's specified in `eng/Version.Details` (see [Versioning](#versioning) below). In this case we don't want the package added to SBRP. Rather, the package should rather be marked as an exclusion in the prebuilt baseline.

### Case 6: Dependencies with No Code

Dependencies that have no code (e.g. SDKs with just props and targets) can usually be added using the [source-build text-only-package process](https://github.com/dotnet/source-build-reference-packages/tree/main/src/textOnlyPackages/src). If the package is not already included there, you can [open a PR](https://github.com/dotnet/source-build-reference-packages/pulls) or [file an issue](https://github.com/dotnet/source-build/issues/new/choose) to include it.

### Case 7: Non-Arcade Repos

Source-build has in the past used Arcade shims to allow non-Arcade repos to build appropriate packages for source-build. Please [log an issue](https://github.com/dotnet/source-build/issues/new/choose) to determine if this is a workable approach for your foreign repo.

### Case 8: External Dependencies

We build some external dependencies in the [dotnet/source-build-externals](https://github.com/dotnet/source-build-externals) repo. Good targets for this generally have very few if any dependencies and very simple build processes. [Please log an issue](https://github.com/dotnet/source-build/issues/new/choose) to get the process started.

## Versioning

If you are using a package in the actual build or want the version to be updated whenever the foreign repo publishes to your channel, use the version number property set up in `eng/Versions.props` and `eng/Version.details` via [`darc`](https://github.com/dotnet/arcade/blob/main/Documentation/Darc.md#darc).  When this is set up, the version number will get updated to the current source-built version when performing a source-build.

If you are using an external or non-Arcade package, please coordinate as much as possible with other teams using that package. Each package-version is essentially maintained as a separate concern, so something like repo A requiring Newtonsoft.Json 9.0.1 and repo B requiring 12.0.2 essentially doubles the source-build team's work.

## Contacts

For any questions or additional information about this document, pre-builts or source-build in general, please create an [issue](https://github.com/dotnet/source-build/issues) or open a [discussion](https://github.com/dotnet/source-build/discussions) in the [source-build](https://github.com/dotnet/source-build) repository.