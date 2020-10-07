# CI onboarding

Source-build needs to run during official builds to create source-build
[intermediate nupkg]s for the downstream repos that will consume them.
Source-build should also run in PR validation builds, to prevent regression in
the source-build flow and (when enabled) catch unintended prebuilt usage.

The source-build job implementation is provided in the ordinary Arcade jobs
template for easy consumption, but more detailed templates are also available in
case the Arcade jobs template isn't suitable for certain repos.

See <https://github.com/dotnet/arcade/tree/master/eng/common/templates> for
current implementation of the templates. The `parameters:` inline comments in
those files should be the most up to date docs and maintained with higher
priority than this doc.

## `eng/common/templates/jobs/jobs.yml` opt-in switch

This is the simplest way to onboard. So far we think this should only require a
two line change if the repo already uses the arcade
`eng/common/templates/jobs/jobs.yml` template and it's managed-only.
("Managed-only" meaning it doesn't produce any NuGet packages that are specific
to certain RIDs, like `Microsoft.NETCore.App.Runtime.linux-x64`.)

To opt in:
* Set `runSourceBuild: true`
* If the repo is managed-only, set:
  ```yaml
  sourceBuildParameters:
    includeDefaultManagedPlatform: true
  ```
* If the repo is not managed-only, set `platforms:` to a list of objects.

A managed-only repo using this implementation should look something like
[this source-build-reference-packages implementation:](https://github.com/dotnet/source-build-reference-packages/blob/0ee4e822dad9cc624b67f7486c2902fcbee05312/azure-pipelines/builds/ci.yml#L16-L31)

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
      artifacts:
        publish:
          artifacts: true
          manifests: true
      runSourceBuild: true
      sourceBuildParameters:
        includeDefaultManagedPlatform: true
```

A non-managed-only repo would instead specify `sourceBuildParameters` like this:

```yaml
sourceBuildParameters:
  platforms:
  - name: 'Centos71_Portable'
    container: 'mcr.microsoft.com/dotnet-buildtools/prereqs:centos-7-3e800f1-20190501005343'
  - name: 'MacOS_Portable'
    pool: { vmImage: 'macOS-10.14' }
  - name: 'Centos71'
    nonPortable: true
    container: 'mcr.microsoft.com/dotnet-buildtools/prereqs:centos-7-3e800f1-20190501005343'
  - name: 'Centos8'
    nonPortable: true
    container: 'mcr.microsoft.com/dotnet-buildtools/prereqs:centos-8-daa5116-20200325130212'
  - name: 'Debian9'
    nonPortable: true
    container: 'mcr.microsoft.com/dotnet-buildtools/prereqs:debian-stretch-20200918130533-047508b'
  - name: 'Fedora30'
    nonPortable: true
    container: 'mcr.microsoft.com/dotnet-buildtools/prereqs:fedora-30-38e0f29-20191126135223'
  - name: 'Fedora32'
    nonPortable: true
    container: 'mcr.microsoft.com/dotnet-buildtools/prereqs:fedora-32-20200512010618-163ed2a'
  - name: 'MacOS'
    nonPortable: true
    pool: { vmImage: 'macOS-10.14' }
  - name: 'Ubuntu1804'
    nonPortable: true
    container: 'mcr.microsoft.com/dotnet-buildtools/prereqs:ubuntu-18.04-20200918145614-047508b'
```

## `eng/common/templates/jobs/source-build.yml`

This is one level deeper than `eng/common/templates/jobs/jobs.yml`. It is a
`jobs` template that produces just the set of source-build jobs.

This template defines the platform used for `includeDefaultManagedPlatform`.

## `eng/common/templates/job/source-build.yml`

This template defines a single `job` that runs source-build on a specified
platform.

## `eng/common/templates/steps/source-build.yml`

This template defines the `steps` for a single source-build job. This is the
most granular template, and may be useful if some repo-specific preamble or
cleanup steps are required, or if the repo already has job matrix templates and
this just fits in nicely.


# Official build publishing

Publishing [intermediate nupkg]s in the official build is handled by the
standard Arcade publish infrastructure, which should already be set up in the
repo. The source-build steps handle uploading the [intermediate nupkg] to the
pipeline in the correct way for Arcade to detect and publish.


[intermediate nupkg]: https://github.com/dotnet/source-build/blob/release/3.1/Documentation/planning/arcade-powered-source-build/intermediate-nupkg.md
