# Source-build build info

This is a collection of notes about how source-build can differ in general from your repo's build and what kind of issues that can create. 

## Single-version and single-RID build

Source-build is required to build on a single machine with no internet access.  This means that we build targeting a single RID, usually the non-portable RID for the build machines (like rhel.7-x64).  We do support building portable (linux-x64) as well - this is useful for bootstrapping new distributions.

We also only build one version of each repo.  This means that if your repo turns production of some packages on and off, for instance, if you only produce packages if they are changed, source-build will need a workaround to force all packages to be produced.  Additionally, we can only supply one version of each package to a repo.  This is injected into the `$(<PackageName>PackageVersion)` variables.  The exception is reference-only packages - dotnet/source-build-reference-packages produces multiple versions and these can be hard-coded or use a `$(<PackageName>ReferenceVersion)` property or similar if you don't need source-build to change them.

## No Windows-specific packages

Packages that require Windows components or references cannot be built in source-build.  These should use `<ExcludeFromSourceBuild>true</ExcludeFromSourceBuild>` or other options to be excluded from the source-build.