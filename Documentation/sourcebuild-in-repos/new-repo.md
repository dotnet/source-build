# Adding a new repository to source build

This document describes the overall process of onboarding new repos onto source
build.

1. [Source Build Configuration](#source-build-configuration)
1. [Setup CI](#setup-ci)
1. [Source build repos and the VMR](#source-build-repos-and-the-vmr)
1. [Validate](#validate)

## Source Build Configuration

### Trying it out locally

If a repo passes build options through to the common arcade build script, a
source build can be triggered via the following command.

```bash
./build.sh -sb
```

> Note: [source build is not supported on
Windows](https://github.com/dotnet/source-build/issues/1190), only Linux and
macOS.

### Excluding components

It is not always necessary or correct to include all repo components in source
build.  Components should be excluded if they are not required for the platform
being source-built.  Including them expands the source build graph and may not
be possible because of licensing. Examples include tests, Windows components
(remember source build currently only supports Linux and macOS), etc. To exlcude
these components use the `DotNetBuildSourceOnly` msbuild property to
conditionally exclude.

```code
Condition="'$(DotNetBuildSourceOnly)' != 'true'"
```

See the [Unified Build Controls](https://github.com/dotnet/arcade/blob/main/Documentation/UnifiedBuild/Unified-Build-Controls.md)
for more options on how to exclude components from source build.

## Setup CI

Source build should run in PR validation builds, to prevent regressions.

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
[@source-build](https://github.com/orgs/dotnet/teams/source-build)
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

## Source build repos and the VMR

Another effect of adding a new source build repository is that its sources will
be synchronized into the [Virtual Monolithic Repository of
.NET](https://github.com/dotnet/dotnet). The VMR is then where the official
source build happens from.

In order for the sources of the new repo to by synchronized into the VMR, the
repo needs to be registered in the [`source-mappings.json`
file](https://github.com/dotnet/dotnet/blob/main/src/source-mappings.json) which
tells the tooling where from and which sources should be synchronized. Please
open a PR in [`dotnet/dotnet`](https://github.com/dotnet/dotnet) and add
your repository into `src/source-mappings.json`.

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

Once the code flows to the VMR, the PR validation legs will ensure that no
[prebuilts](https://github.com/dotnet/source-build/blob/main/Documentation/eliminating-pre-builts.md#what-is-a-prebuilt)
were added to the system and everything is functioning correctly.
If you need help on addressing any prebuilds, reach out to @source-build.
