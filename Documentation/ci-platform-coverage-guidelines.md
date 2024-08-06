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
1. Alpine - Latest and previous versions (amd64)
1. AlmaLinux - Oldest version (targets lowest glibc version) (amd64)
