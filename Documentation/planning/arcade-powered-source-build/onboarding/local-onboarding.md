# Local onboarding

Local onboarding involves setting up files in `eng/` that determine the behavior
of source-build in the repo.


## Source-build configuration overview

### `eng/SourceBuild.props`

```xml
<Project>

  <PropertyGroup>
    <GitHubRepositoryName>this-repo</GitHubRepositoryName>
    <SourceBuildManagedOnly>true</SourceBuildManagedOnly>
  </PropertyGroup>

</Project>
```

This file contains basic configuration used to restore the correct dependencies
(managed-only or not) and produce the right name for the repo's [intermediate
nupkg].

* `this-repo` should be the same as the repo's name on GitHub, without the
  GitHub organization name.
* `SourceBuildManagedOnly` defaults to false if omitted. `true` means that the
  repo doesn't produce any RID-specific artifacts like
  `Microsoft.NETCore.App.Runtime.linux-x64`, only managed code.

These two properties determine the name of the [intermediate nupkg]:
`Microsoft.SourceBuild.Intermediate.$(GitHubRepositoryName)[.$(RidSuffix)]`.

It's possible more configuration will be required for specific repos.
`eng/SourceBuild.props`, similar to `eng/Build.props`, is a place to add extra
MSBuild code that can change the way source-build behaves.

### `eng/SourceBuildPrebuiltBaseline.xml`

```xml
<UsageData>
  <IgnorePatterns>
    <UsagePattern IdentityGlob="*/*" />
  </IgnorePatterns>
</UsageData>
```

This defines which prebuilt NuGet packages are allowed to be used during the
build. Initially, all package IDs and versions are permitted (`*/*`).

The `*/*` glob means "any nupkg id, any version". It will be replaced with more
specific rules at a later phase of the implementation plan. The goal is to make
it specific, so when a PR introduces an unexpected prebuilt, PR validation will
fail and let us resolve the source-buildability issue before the PR gets merged.

### `eng/Version.Details.xml`

```xml
...
    <Dependency Name="Microsoft.NETCore.App.Runtime.win-x64" Version="6.0.0-alpha.1.20468.7" CoherentParentDependency="Microsoft.NET.Sdk">
      <Uri>https://github.com/dotnet/runtime</Uri>
      <Sha>a820ca1c4f9cb5892331e2624d3999c39161fe2a</Sha>
      <SourceBuild RepoName="runtime" />
    </Dependency>
...
    <Dependency Name="Microsoft.SourceBuild.Intermediate.source-build-reference-packages" Version="5.0.0-alpha.1.20473.1">
      <Uri>https://github.com/dotnet/source-build-reference-packages</Uri>
      <Sha>def2e2c6dc5064319250e2868a041a3dc07f9579</Sha>
      <SourceBuild RepoName="source-build-reference-packages" ManagedOnly="true" />
    </Dependency>
...
```

Dependency changes may include adding `SourceBuild` to existing dependency
elements, and adding a new `source-build-reference-packages` element.

`SourceBuild` causes the source-build targets in the Arcade SDK to download
[intermediate nupkg]s from the upstream repo's official build, rather than using
prebuilt binaries to fulfill the dependencies. Note that `RepoName` is used to
calculate the ID of the [intermediate nupkg]: the `Dependency` `Name` is
ignored by source-build.

`ManagedOnly` determines whether a RID suffix is necessary on the [intermediate
nupkg] ID. For example, running source-build on `dotnet/installer` with
`linux-x64` with the above example configuration will restore:

* `Microsoft.SourceBuild.Intermediate.runtime.linux-x64`
  * `.linux-x64` because `ManagedOnly` is not `true`.
* `Microsoft.SourceBuild.Intermediate.source-build-reference-packages`
  * Ends with the `RepoName` without a suffix because `ManagedOnly="true"`.


# Trying it out locally

Running source-build locally is done by passing `/p:ArcadeBuildFromSource=true`
at the end of the usual arcade-based build command for the repo. For example:

```
./build.sh -c Release --restore --build --pack /p:ArcadeBuildFromSource=true
```

> Note: [source-build is not supported on
> Windows](https://github.com/dotnet/source-build/issues/1190), only Linux and
> macOS.

After running the build, source-build artifacts will be in
`artifacts/source-build`, and the [intermediate nupkg] will be something like
`artifacts/packages/*/Microsoft.SourceBuild.Intermediate.*.nupkg`.

It isn't strictly necessary to try it out locally to proceed with CI onboarding.
The source-build contributor who submits the initial configuration PR to the
repo will have tested out the build locally themselves.


[intermediate nupkg]: https://github.com/dotnet/source-build/blob/release/3.1/Documentation/planning/arcade-powered-source-build/intermediate-nupkg.md
