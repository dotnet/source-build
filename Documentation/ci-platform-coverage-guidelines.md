# Guidelines for Platforms Tested in CI

This document contains the guidelines for which platforms (OS and architectures)
to test in the source build CI.

## Distro Families

1. Prefer testing base distros of families over derivatives.
1. Prioritize testing distros that source build .NET.
1. Use CentOS Stream instead of Red Hat because it is the free alternative.
1. Include a permutation of distros for the supported C standard library
implementations (e.g. glibc and musl).
1. For each C standard library implementation, include at least one distro that
uses the minimum supported version of this library.
1. Only test [distros that are officially supported by
.NET](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md#net-supported-os-policy).
Community supported distros will not be covered.

## Distro Versions

1. Prefer testing latest LTS version. If LTS is unsupported, use the latest
   version instead.
1. Drop distro versions that will be or are nearing EOL on the .NET release day.
1. Stop updating the test matrix in the last 6 months of support for a .NET
version as new distro versions are released.

## Architectures

1. Amd64
1. Arm64

## Permutations

It is not the intent to test every permutation of distro family, distro version,
and architecture. Rather, smart decisions should be made to best utilize
resources.

The following distro versions will be included in the [CI
matrix](https://github.com/dotnet/dotnet/blob/main/eng/pipelines/templates/stages/vmr-build.yml):

1. CentOS Stream - Latest version (amd64)
1. Fedora - Latest version (amd64)
1. Ubuntu - Latest LTS version at the time of the release (amd64/arm64)
1. Alpine - Latest version (amd64)
1. AlmaLinux - Oldest version (targets lowest glibc version) (amd64)

## Updating Distro Versions in the VMR

Some OS legs in CI produce artifacts that are consumed downstream (e.g. as N-1
previously source-built artifacts or as shared component artifacts for feature
bands). When a distro version is updated for one of these legs, the previous
distro version must be kept temporarily so that downstream consumers can
continue using its artifacts until they are transitioned to the new version.
The scope and mechanism differ between the main branch and servicing branches:

- **Main branch:** Only distros whose OS legs produce N-1 artifacts need to
  follow this process. A re-bootstrap is sufficient to publish new artifacts;
  no release is required. Distros that do not produce N-1 artifacts can be
  updated directly without the multi-step process.
- **Servicing branches:** All distros are in scope because all 1xx OS legs
  produce artifacts consumed by feature bands. A release of the 1xx feature
  band is required to publish the artifacts.

### Step 1: Update Distro Version

Add CI legs for both the previous and current distro versions. Both versions
must coexist temporarily so that downstream consumers can continue to consume
the previous version's artifacts until they are updated.

1. **Update VMR pipeline variables:**
   - Create "Previous" versions of existing distro variables by adding `Previous` suffix to preserve the old values - [example](https://github.com/dotnet/dotnet/blob/12c9fccc3192d5bbf9f98ea15cedcdcf55334f89/eng/pipelines/templates/variables/vmr-build.yml#L117-L121)
   - Update current distro variables to new version values - [example](https://github.com/dotnet/dotnet/pull/1093/files#diff-821e317646a065ee331aa7444ca5e2ae9f76512e5ca316e045280e526db23724R192-R193)

1. **Update VMR pipeline:**
   - Add container configuration for previous version - [example](https://github.com/dotnet/dotnet/blob/12c9fccc3192d5bbf9f98ea15cedcdcf55334f89/eng/pipelines/ci.yml#L94-L96)
   - For previous legs, update the distro parameters to use the previous variables you created above - [example](https://github.com/dotnet/dotnet/blob/12c9fccc3192d5bbf9f98ea15cedcdcf55334f89/eng/pipelines/templates/stages/source-build-and-validate.yml#L33-L38)

1. **Update SBRP Cleanup pipeline:**
   - If applicable, update the default artifact name in the source-build-reference-packages clean up pipeline - [example](https://github.com/dotnet/source-build-reference-packages/pull/1284)

1. **File a tracking issue** to remove references to the old version once all feature bands have been updated - [example](https://github.com/dotnet/source-build/issues/5238)

1. **Submit and test your changes:**
   - Open a pull request with all changes - [example](https://github.com/dotnet/dotnet/pull/1093)
   - Queue a full build of the VMR to validate the changes

### Step 2: Publish Artifacts

Artifacts for both the previous and current distro versions must be available
before downstream consumers can be updated.

1. **Update release pipelines:**
   - Update the artifact names for the relevant .NET version in the release infrastructure.
     ([example](https://dev.azure.com/dnceng/internal/_git/dotnet-release/commit/c9be53307205765ebae48c18d00ef6260e596817?path=/eng/pipeline/source-build-release/steps/re-bootstrap.yml&version=GBmain&line=90&lineEnd=91&lineStartColumn=1&lineEndColumn=1&type=2&lineStyle=plain&_a=files)).
   - The release validation will fail until the next source-build release; file
     an issue to update the artifacts used for the release validation after the
     next release.

How the artifacts are then published depends on whether the .NET version is in
development or in servicing:

- **Main branch:** Queue the re-bootstrap pipeline after the changes merge.
- **Servicing branches:** A release of the 1xx feature band must occur so that
  artifacts for both distro versions are published. Feature band branches
  cannot be updated until this release is available.

### Step 3: Update To Current Distro Version

Once artifacts for both distro versions are available (via re-bootstrap or
release), update each subsequent feature band branch to reference the current
distro versions.

Update the artifact RID used in `prep-source-build.sh` if the updated distro
is the default RID ([example](https://github.com/dotnet/dotnet/pull/1187/commits/622843880cb3fb0c78896b1c9b5ef76b2a114017)).

### Step 4: Remove the Previous Distro Version

Once all downstream consumers have been updated to use the current distro
version, remove the previous distro version legs and variables from the
main/1xx branch. Close the tracking issue filed in Step 1.

## Timing Guidelines for Distro Updates

1. Update `main` to the newer version one to two months prior to the distro GA/EOL date.
    This is done to flush out any issues and to avoid destabilizing the servicing
    branches.
1. At the distro GA/EOL date, update the servicing branches.
