# Dependency Management
_Written by @mmitche, @MichaelSimons, @mthalman and @ViktorHofer_

Start with most restrictive build environment which is source build today.

// TODO: Add section about trying to avoiding new dependency when possible (i.e. by upgrading to a newer version or picking another library that's already available in the sources)

// TODO: Add section about enabling dependency that's already available as source but not yet built in source build. 

### Dependency sources
- [Source Build Externals (SBE)](https://github.com/dotnet/source-build-externals)

  * Not part of Arcade
  * Fairly static dependency

- [Source Build Reference Packages (SBRP)](https://github.com/dotnet/source-build-reference-packages)

  * Contract / Content only
  * Fairly static dependency
  * Stable released version
  * Not included in SBE
  * Should be a .NET produced dependency
  * Can't re-distribute into a shipping asset

  _Consider upgrading to a version covered by SBRP._

- Previous Sourcebuild

  * Must be part of the previously source built product
  * Must provide a compatible surface area
  * Can't re-distribute into a shipping asset

- .NET "Maestro" dependency flow

  * Product dependency must be built previously in the build graph
  * Toolset dependency is allowed to create cycle in the dependency graph
  * Active dependency flow
  * Dependency is produced by .NET

- "Public" endpoints (i.e. dotnet-public, npmjs, ...)

  * Only applicable to MSFT build
  * Relatively stable
  * Produced by .NET or externally

- Machine installed toolset

  * Compatible versions must be available in all distribution maintainer build environments
