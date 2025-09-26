# Source-build build info

This is a collection of notes about how source-build can differ in general from
your repo's build and what kind of issues that can create.

## Single-version and single-RID build

Source-build is required to build on a single machine with no internet access.
This means that we build targeting a single RID, usually the non-portable RID
for the build machines (like rhel.7-x64).  We do support building portable
(linux-x64) as well - this is useful for bootstrapping new distributions.

Source-build cannot build with any *prebuilts*.  This is our term for any
package that comes from *outside the current source-build*.  This means that
everything that ships out of source-build and everything that is used to build
those shipping products must come from the source-build in progress. Packages
from nuget.org, Microsoft builds, or other unrelated source-builds cannot be
used in source-build except in a limited bootstrapping process.

Source-build supplies a *previously-source-built* set of packages for this
bootstrapping process.  This is one way we have of breaking cycles in the build.
However, none of these packages can make it to the final build output. This also
means that your repo should be buildable with the immediately previous version
of the SDK than you are building for; i.e., if you are building for 8.0.103,
everything should be buildable with the 8.0.102 SDK.

We also only build one version of each repo.  This means that if your repo turns
production of some packages on and off, for instance, if you only produce
packages if they are changed, source-build will need a workaround to force all
packages to be produced.  Additionally, we can only supply one version of each
package to a repo.  This is injected into the `$({PackageName}PackageVersion)`
variables, e.g. SystemReflectionMetadataPackageVersion. One exception is
reference-only packages -
[dotnet/source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages)
produces multiple versions and these can be hard-coded or use a
`$(<PackageName>ReferenceVersion)` property or similar if you don't need
source-build to change them.

## Platform-specific components

It is not always necessary or correct to include all repo components in source build.
**Important philosophy: The Microsoft build and source build should be as close to the same as possible.**
Components should be excluded based on platform requirements rather than source-build specific reasons.
To exclude components, use the [VMR Controls](https://github.com/dotnet/dotnet/blob/main/docs/VMR-Controls.md) properties.

Common patterns include:

```xml
<!-- Exclude Windows-only components on non-Windows platforms -->
<ItemGroup Condition="'$(TargetOS)' == 'windows'">
  <ProjectReference Include="WindowsSpecific.csproj" />
</ItemGroup>

<!-- Exclude components from source-only builds when truly necessary -->
<ItemGroup Condition="'$(DotNetBuildSourceOnly)' != 'true'">
<ProjectReference Include="MicrosoftProprietary.csproj" />
</ItemGroup>
```

**Avoid using `DotNetBuildSourceOnly` conditions unless absolutely necessary.**
**Prefer platform-based conditions** (like `TargetOS`) **to maintain alignment between Microsoft and source builds.**
