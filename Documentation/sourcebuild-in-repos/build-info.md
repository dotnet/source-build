# Source-build build info

This is a collection of notes about how source-build can differ in general
from your repo's build and what kind of issues that can create.

## Single-version and single-RID build

Source-build is required to build on a single machine with no internet
access.  This means that we build targeting a single RID, usually the
non-portable RID for the build machines (like rhel.7-x64).  We do
support building portable (linux-x64) as well - this is useful for
bootstrapping new distributions.

Source-build cannot build with any *prebuilts*.  This is our term for
any package that comes from *outside the current source-build*.  This means
that everything that ships out of source-build and everything that is used to
build those shipping products must come from the source-build in progress.
Packages from nuget.org, Microsoft builds, or other unrelated source-builds
cannot be used in source-build except in a limited bootstrapping process.

Source-build supplies a *previously-source-built* set of packages for this
bootstrapping process.  This is one way we have of breaking cycles in the
build.  However, none of these packages can make it to the final build output.
This also means that your repo should be buildable with the immediately
previous version of the SDK than you are building for; i.e., if you are
building for 6.0.103, everything should be buildable with the 6.0.102 SDK.

We also only build one version of each repo.  This means that if your repo
turns production of some packages on and off, for instance, if you only
produce packages if they are changed, source-build will need a workaround
to force all packages to be produced.  Additionally, we can only supply
one version of each package to a repo.  This is injected into the
`$({PackageName}PackageVersion)` variables, e.g. SystemReflectionMetadataPackageVersion.
One exception is reference-only packages -
[dotnet/source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages)
produces multiple versions and these can be hard-coded or use a
`$(<PackageName>ReferenceVersion)` property or similar if you don't
need source-build to change them.

## Platform-specific packages

Packages that require components or packages only available on some other
operating system than the building OS cannot be built in source-build.
These should use `<ExcludeFromSourceBuild>true</ExcludeFromSourceBuild>` or
other options to be excluded from the source-build.  For instance, if a
project depends on a package that can only be built on Windows, it will need
to be disabled or worked around in source-build.  As an example,
[Roslyn removes](https://github.com/dotnet/roslyn/blob/b999a65c8b0feeccb2b58da3d7a6e80e5f08feab/src/Workspaces/Core/Portable/Storage/PersistentStorageExtensions.cs#L23)
a small performance improvement when building for source-build because it
requires a component that isn't available.