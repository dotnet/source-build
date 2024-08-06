# Adding a new repository to source build

This document describes the overall process of onboarding new repos onto source
build.

1. [Source Build Configuration](#source-build-configuration)
1. [Setup CI](#setup-ci)
1. [Incorporate the new repo into the source build dependency
   tree](#incorporate-the-new-repo-into-the-source-build-dependency-tree)
1. [Source build repos and the VMR](#source-build-repos-and-the-vmr)
1. [Validate](#validate)
1. [Additional resources](#additional-resources)

## Source Build Configuration

Configuring source build involves setting up files in `eng/` that determine the
behavior of source build in the repo.

These changes are all needed before source build will work:

* [`eng/SourceBuild.props`](#engsourcebuildprops) - Basic properties, such as
  repo name.
* [`eng/SourceBuildPrebuiltBaseline.xml`](#engsourcebuildprebuiltbaselinexml) -
  List of allowed prebuilts (approval required).
* [`eng/Version.Details.xml`](#engversiondetailsxml) - Already exists, but
  modifications are needed to pull dependencies from upstream [intermediate
  nupkgs](planning/arcade-powered-source-build/README.md#intermediate-nupkg-outputsinputs).

See the following sections for details:

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
MSBuild code that can change the way source build behaves.

### `eng/SourceBuildPrebuiltBaseline.xml`

```xml
<!-- Whenever altering this or other Source Build files, please include @dotnet/source-build-internal as a reviewer. -->
<!-- See https://aka.ms/dotnet/prebuilts for guidance on what pre-builts are and how to eliminate them. -->

<UsageData>
  <IgnorePatterns>
    <UsagePattern IdentityGlob="Microsoft.SourceBuild.Intermediate.*/*" />
  </IgnorePatterns>
</UsageData>
```

This defines which prebuilt NuGet packages are allowed to be used during the
build. Initially, only the source build intermediate packages are allowed. The
`*/*` glob means "any intermediate package, any version". All other prebuilts
require approval from the source build team.

When a PR introduces an unexpected prebuilt, PR validation will fail and let us
resolve the source-buildability issue before the PR gets merged.

### CODEOWNERS

Add the source build team as the
[CODEOWNER](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-code-owners)
of the source build infrastructure.

``` text
/eng/SourceBuild* @dotnet/source-build-internal
```

### Trying it out locally

If a repo passes build options through to the common arcade build script, a
source build can be triggered via the following command.

```bash
./build.sh -sb
```

If a repo does not pass through build options through to the common arcade build
script, then you must specify the `/p:ArcadeBuildFromSource=true` property as
follows.

```bash
./build.sh -c Release --restore --build --pack /p:ArcadeBuildFromSource=true -bl
```

> Note: [source build is not supported on
Windows](https://github.com/dotnet/source-build/issues/1190), only Linux and
macOS.

After running the build, source build artifacts will be in
`artifacts/source-build`, and the [intermediate nupkg] will be something like
`artifacts/packages/*/Microsoft.SourceBuild.Intermediate.*.nupkg`.

The MSBuild binlog will be placed somewhere like:
`artifacts/log/Debug/Build.binlog`. However, this "outer" binlog doesn't contain
the meat of the build: the "inner" build runs inside an `Exec` task. The inner
binlog will be written to:
`artifacts/source-build/self/src/artifacts/sourcebuild.binlog`.

### Excluding components

It is not always necessary or correct to include all repo components in source
build.  Components should be excluded if they are not required for the platform
being source-built.  Including them expands the source build graph and may not
be possible because of licensing. Examples include tests, Windows components
(remember source build currently only supports Linux and macOS), etc. To exlcude
these components use the `DotNetBuildFromSource` msbuild property to
conditionally exclude.

```code
Condition="'$(DotNetBuildFromSource)' != 'true'"
```

### `eng/Version.Details.xml`

```xml
...
    <Dependency Name="Microsoft.NETCore.App.Runtime.win-x64" Version="6.0.0-alpha.1.20468.7"
                CoherentParentDependency="Microsoft.NET.Sdk">
      <Uri>https://github.com/dotnet/runtime</Uri>
      <Sha>a820ca1c4f9cb5892331e2624d3999c39161fe2a</Sha>
      <SourceBuild RepoName="runtime" />
    </Dependency>
...
    <Dependency Name="Microsoft.SourceBuild.Intermediate.source-build-reference-packages"
                Version="5.0.0-alpha.1.20473.1">
      <Uri>https://github.com/dotnet/source-build-reference-packages</Uri>
      <Sha>def2e2c6dc5064319250e2868a041a3dc07f9579</Sha>
      <SourceBuild RepoName="source-build-reference-packages"
                   ManagedOnly="true" />
    </Dependency>
...
```

Dependency changes may include adding `SourceBuild` to existing dependency
elements, and adding a new `source-build-reference-packages` element.

`SourceBuild` causes the source build targets in the Arcade SDK to download
[intermediate nupkg]s from the upstream repo's official build, rather than using
prebuilt binaries to fulfill the dependencies. Note that `RepoName` is used to
calculate the ID of the [intermediate
nupkg](planning/arcade-powered-source-build/README.md#intermediate-nupkg-outputsinputs):
the `Dependency` `Name` is ignored by source build.

Building with the source-built versions of your dependencies also means that any
upstream repos will have been built in a source build context, including things
projects that are excluded from the source build.  This can help you find issues
where your source build depends on an upstream component that isn't actually
built in source build.

`ManagedOnly` determines whether a RID suffix is necessary on the [intermediate
nupkg](planning/arcade-powered-source-build/README.md#intermediate-nupkg-outputsinputs)
ID. For example, running source build on `dotnet/installer` with `linux-x64`
with the above example configuration will restore:

* `Microsoft.SourceBuild.Intermediate.runtime.linux-x64`
  * `.linux-x64` because `ManagedOnly` is not `true`.
* `Microsoft.SourceBuild.Intermediate.source-build-reference-packages`
  * Ends with the `RepoName` without a suffix because `ManagedOnly="true"`.

## Setup CI

Source build needs to run during official builds to create source build
[intermediate nupkg]s for the downstream repos that will consume them. Source
build should also run in PR validation builds, to prevent regressions.

Source build CI can be activated with a single flag in the ordinary Arcade SDK
jobs template for easy consumption. If a repo can't simply use the Arcade SDK
jobs template, more granular templates are also available.

See <https://github.com/dotnet/arcade/tree/main/eng/common/templates> for the
current template source code. The inline comments in the `parameters:` section
in those files are the most up to date docs, maintained with higher priority
than this general onboarding doc.

### `eng/common/templates/jobs/jobs.yml` opt-in switch

The simplest way to onboard. This approach applies if the repo already uses the
`eng/common/templates/jobs/jobs.yml` template.

To opt in:

1. Set `enableSourceBuild: true`

    Set `enableSourceBuild: true` in the template parameters.

    This should look something like [this sourcelink
    implementation:](https://github.com/dotnet/sourcelink/blob/dfe619dc722be42d475595c755c958afe6177554/azure-pipelines.yml#L40)

    ```yaml
    stages:
    - stage: build
    displayName: Build
    jobs:
    - template: /eng/common/templates/jobs/jobs.yml
        parameters:
        enablePublishUsingPipelines: true
        enablePublishBuildArtifacts: true
        enablePublishBuildAssets: true
        enableSourceBuild: true
        artifacts:
            publish:
            artifacts: true
            manifests: true
    ```

1. Specify platforms (if repo is not managed-only)

    A repo is managed-only if `eng/SourceBuild.props` contains
    `<SourceBuildManagedOnly>true</SourceBuildManagedOnly>`. If this is true,
    this step is not necessary. Otherwise, specify `sourceBuildParameters` in
    the `jobs.yml` template's parameters like this:

    ```yaml
    sourceBuildParameters:
    platforms:
    - name: 'CentosStream8_Portable'
        container: 'mcr.microsoft.com/dotnet-buildtools/prereqs:centos-stream8'
    - name: 'CentosStream8'
        nonPortable: true
        container: 'mcr.microsoft.com/dotnet-buildtools/prereqs:centos-stream8'
    ```

#### End result

Submit the changes above in a PR and include
[@source-build-internal](https://github.com/orgs/dotnet/teams/source-build-internal)
as a reviewer. The jobs (or job, if managed-only) are automatically be added to
CI in the existing pipeline alongside existing jobs, with a name like `Build
Source-Build (<Platform>)`:

![Build jobs image with source build leg](img/ci-job.png)

Once this PR works, run a mock official build (AKA "validation build") in your
official build definition. The usual workflow is to push a
`dev/<your-alias>/<branch-name>` branch to the AzDO repo and then queue a build
on that branch. This makes sure that merging the PR won't immediately break the
official build: `enableSourceBuild: true` does add job(s) to the official build,
not just PR validation.

If the PR is green, but merging it produces red PR or Official builds,
immediately let the source build team know about the failure and revert the
source build PR to unblock dev work.

### Advanced: granular templates

If the repo doesn't use the basic Arcade jobs template, or has advanced job
templating infra built on top of the Arcade jobs template, the simple
`enableSourceBuild` flag might not work out. There are a few more granular
templates to use in this case.

Look at the documentation in each YAML file itself to figure out how to use it
properly, and if it fits the scenario. This list is only an overview.

#### `eng/common/templates/jobs/source-build.yml`

This is one level deeper than `eng/common/templates/jobs/jobs.yml`. It is a
`jobs` template that produces just the set of source build jobs based on the
specified `platforms`. Or, just one job with the default platform, if
managed-only.

#### `eng/common/templates/job/source-build.yml`

This template defines a single `job` that runs source build on a
specifiedplatform.

#### `eng/common/templates/steps/source-build.yml`

This template defines the build `steps` for a single source build job. This is
the most granular template, and may be useful if some repo-specific preamble or
cleanup steps are required, or if the repo already has job matrix templates and
this just happens to fit in nicely.

### Official build publishing

Publishing [intermediate nupkg]s in the official build is handled by the
standard Arcade publish infrastructure, which should already be set up in the
repo. The source build steps handle uploading the [intermediate nupkg] to the
pipeline in the standard way that Arcade will detect and publish.

[intermediate nupkg]:
    https://github.com/dotnet/source-build/blob/main/Documentation/planning/arcade-powered-source-build/intermediate-nupkg.md

## Incorporate the new repo into the source build dependency tree

Once your repo can be source-built, it is time to register it into the source
build dependency tree. The graph of the product is defined by the
`eng/Version.Details.xml` files. This dependency graph starts at
[dotnet/installer](https://github.com/dotnet/installer/blob/main/eng/Version.Details.xml).
The dependendecies of repos declared in these files are walked and the first
copy/commit of each repo found in the dependency graph is used.

Therefore, when adding new repositories, a dependency must be created within the
`eng/Version.Details.xml` graph. To do this, **go to the repo which depends on
the new repo and add a [new source build dependency](#engversiondetailsxml) to
the new source build repo**.

## Source build repos and the VMR

Another effect of adding a new source build repository is that its sources will
be synchronized into the [Virtual Monolithic Repository of
.NET](https://github.com/dotnet/dotnet). The VMR is then where the official
source build happens from. The sources are synchronized once the associated
commit/package flows into `dotnet/installer`.

In order for the sources of the new repo to by synchronized into the VMR, the
repo needs to be registered in the [`source-mappings.json`
file](https://github.com/dotnet/dotnet/blob/main/src/source-mappings.json) which
tells the tooling where from and which sources should be synchronized. Please
open a PR in [`dotnet/installer`](https://github.com/dotnet/installer) and add
your repository into `src/VirtualMonoRepo/source-mappings.json`. The name must
match the name declared in the `SourceBuild` tag in `Version.Details.xml`
created in the previous step.

### Cloaking (filtering) the repository sources

When creating the `source-mappings.json` record for the new repo, there is a
possibility of filtering which sources get synchronized into the VMR. The VMR
should only really contain plain text-based files as it is consumed by 3rd party
.NET distro builders who do not accept any non-text sources (e.g. binaries).
When registering the repository into the VMR, it is a good time to consider
which files are required for it to build and only synchronize those. Commonly,
repositories contain binaries that are required for testing or similar purposes.
Files like these should not be synchronized into the VMR. Another common
scenario is that the repo has multiple products/ship vehicles and only a subset
is needed for the source-built .NET scenario.

## Validate

Once the downstream dependency(s) are added to the new repo and those changes
flow into `dotnet/installer`, a complete .NET product can be built from source.
The repository will be synchronized into the VMR during the first build and the
VMR will be built. This will validate that no prebuilts were added to the system
and everything is functioning correctly. Please notify
[@source-build-internal](https://github.com/orgs/dotnet/teams/source-build-internal)
to be on the lookout for the new repo and they will validate as necessary.

## Additional resources

* For more details about how the build executes, see [Arcade's build
  tools](https://github.com/dotnet/arcade/tree/main/src/Microsoft.DotNet.Arcade.Sdk/tools/SourceBuild).
* The source code for the build tasks that run for prebuilt validation and
  intermediate nupkg dependency reading are maintained in
  [Arcade](https://github.com/dotnet/arcade/tree/main/src/Microsoft.DotNet.SourceBuild)
  as well.
