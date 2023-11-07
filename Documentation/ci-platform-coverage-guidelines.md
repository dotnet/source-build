# Guidelines for Platforms Tested in CI

This document contains the guidelines for which platforms (OS and architectures) to test in
the source build CI.

## Distro Families

1. Prefer testing base distros of families over derivatives.
1. Prioritize testing distros that source build .NET.
1. Use CentOS Stream instead of Red Hat because it is the free alternative.
1. Include a permutation of distros for the supported C standard library implementations
(e.g. glibc and musl).
1. Only test officially supported distros. Community supported distros will not be covered.

**Note:** There will be conflicts within these guidelines.  When they occur, it is an indication
that multiple legs will be needed. For example Debian is the base of a large graph of distros one
of which is Ubuntu. .NET is included in Ubuntu but not Debian (at least at the time this document
was written). As such, it is best to include legs for both Ubuntu and Debian.

## Distro Versions

1. It is not feasible to cover all supported distro versions. Judicously select the versions to test.
1. Once a version reaches EOL, upgrade to the next latest LTS/non-LTS version based on type of the
EOL version.

## Architectures

1. All officially supported architecture (e.g. amd64 and arm64) will be covered. Community supported
architectures will not be covered.

## Permutations

It is not the intent to test every permuation of distro family, distro version, and architecture.
Rather, smart decisions should be made to utilize resources. For example, test the oldest LTS version
of debian on arm64 and the latest LTS version of ubuntu on amd64.

1. CentOS Stream
    1. Oldest in support version
    1. Newest in support version
1. Fedora - Newest in support version
1. Debian - Oldest LTS version
1. Ubuntu - Newest LTS version (arm64)
1. Alpine - Newest in support version