# Guidelines for Platforms Tested in CI

This document contains the guidelines for which platforms (OS and architectures) to test in
the source build CI.

## Distro Families

1. Prefer testing base distros of families over derivatives.
1. Prioritize testing distros that source build .NET.
1. Use CentOS Stream instead of Red Hat because it is the free alternative.
1. Include a permutation of distros for the supported C standard library implementations
(e.g. glibc and musl).
1. Only test [distros that are officially supported by .NET](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md#net-supported-os-policy).
Community supported distros will not be covered.

**Note:** There will be conflicts within these guidelines.  When they occur, it is an indication
that multiple legs will be needed. For example, Ubuntu is based on Debian. However, .NET is included
in Ubuntu's repositories by default but not Debian's (at the time of writing). As such, it is best
to include legs for both Ubuntu and Debian.

## Distro Versions

When selecting which distro versions to test the .NET version in development, it is important to take into account which distro versions will be insupport at the time of the .NET release.  Don't worry about testing .NET on distro versions that will be or nearing EOL on the .NET release day.

1. Latest LTS version. If the distro doesn't have an LTS notion, then test latest.
1. Oldest version that will be in-support for the lifetime of the .NET release.

## Architectures

1. Amd64
1. Arm64

## Permutations

It is not the intent to test every permutation of distro family, distro version, and architecture.
Rather, smart decisions should be made to utilize resources. For example, test the oldest LTS version
of Debian on amd64 and the latest LTS version of Ubuntu on arm64.

1. CentOS Stream
    1. Newest in support version
    1. Oldest in support version (for the lifetime of .NET)
1. Fedora - Newest in support version
1. Debian - Oldest LTS version (for the lifetime of .NET)
1. Ubuntu - Newest LTS version (arm64)
1. Alpine - Newest in support version
