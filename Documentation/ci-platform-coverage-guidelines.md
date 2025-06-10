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
matrix](https://github.com/dotnet/sdk/blob/main/eng/pipelines/templates/stages/vmr-build.yml):

1. CentOS Stream - Latest version (amd64)
1. Fedora - Latest version (amd64)
1. Ubuntu - Latest LTS version at the time of the release (amd64/arm64)
1. Alpine - Latest version (amd64)
1. AlmaLinux - Oldest version (targets lowest glibc version) (amd64)

## Updating Distro Versions in the VMR

There are two scenarios when updating distro versions in the CI pipeline:

### Case 1: OS Used in N-1 Leg (Previous Version Support)

When updating a distro that is used in a n-1 (previous version) build leg:

1. Update pipeline build configuration variables

1. Create backup pipeline RID variable for old version:
   - Create a new distro RID variable with suffix `Old`
     (eg. if current variable is `centOSStreamX64Rid`, create `centOSStreamX64RidOld`)
   - Set the value to the RID of the old distro version being replaced

1. File tracking issue:
   - Create an issue in [dotnet/source-build](https://github.com/dotnet/source-build) repository
   - Title should indicate need to update artifacts RID after next rebootstrap or release
   - This ensures the old RID is properly cleaned up later

1. Update n-1 build legs:
   - Change the `artifactsRid` template parameter for n-1 build legs to use the `<name>Old` variable
   - Add a comment with a link to the issue created in step 3

1. Update prep-source-build.sh:
   - Add a comment above the [`defaultArtifactsRid`](https://github.com/dotnet/dotnet/blob/604a6612d130bc042dc973aba84889f529f9cb69/prep-source-build.sh#L40) variable to update the default value
   - Include a link to the issue created in step 3

1. Submit changes:
   - Open a pull request with all the above changes
   - Ensure all changes are reviewed and tested by doing a full run of the VMR
      - 8.0/9.0: [dotnet-source-build-pre10.0](https://dev.azure.com/dnceng/internal/_build?definitionId=1219)
      - 10.0+: [dotnet-unified-build](https://dev.azure.com/dnceng/internal/_build?definitionId=1330)

1. Update release pipeline infrastructure:
   - After the public PR is merged, update [the leg name(s)](https://dev.azure.com/dnceng/internal/_git/dotnet-release?path=/eng/pipeline/source-build-release/steps/re-bootstrap.yml&version=GBmain&line=68&lineEnd=86&lineStartColumn=1&lineEndColumn=1&lineStyle=plain&_a=contents) for the release artifacts to match the new configuration in the VMR
   - Create and merge this PR to complete the update process

1. Close tracking issue from step 3:
   - After the subsequent release or reboostrap (whichever comes first),
     open a PR with the changes linked to the tracking issue from step 3.
   - Merge the changes, and close the issue

### Case 2: Regular Artifact (Standard Update)

For distros not used in n-1 legs (simpler case):

1. Update build configuration variables
1. Submit changes:
   - Open a pull request with all the above changes
   - Ensure all changes are reviewed and tested by doing a full run of the VMR
      - 8.0/9.0: [dotnet-source-build-pre10.0](https://dev.azure.com/dnceng/internal/_build?definitionId=1219)
      - 10.0+: [dotnet-unified-build](https://dev.azure.com/dnceng/internal/_build?definitionId=1330)

## Timing Guidelines for Distro Updates

When updating distro versions as new versions are released and older versions reach end-of-life (EOL):

1. **Pre-GA/EOL updates (1-2 months before):**
   - Update the `main` branch to use the newer distro version
   - This allows time to identify and resolve any compatibility issues
   - Helps avoid destabilizing servicing branches close to release dates
   - Follow guidelines described in [Permutations](#permutations)

2. **GA/EOL date updates:**
   - Update all active servicing branches (`release/x.0` branches)
   - Ensure consistency across all supported .NET versions
   - Follow guidelines described in [Permutations](#permutations)
