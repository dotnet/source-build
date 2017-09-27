# Automatic dependency contracts examples/prototypes

**Status: WIP.** Implementing changes based on design reviews.

The auto dependency flow repo API has a prototype implementation in CoreCLR, CoreFX, Core-Setup, and Standard. The prototypes can be used to guide further implementations, and for those repos in particular, they might be directly usable.

In general, the `flow` branch on the `dagood` fork of each repo contains the prototype changes. They are based on `release/2.0.0`.

 * CoreCLR [`flow` diff](https://github.com/dotnet/coreclr/compare/release/2.0.0...dagood:flow)
 * CoreFX [`flow` diff](https://github.com/dotnet/corefx/compare/release/2.0.0...dagood:flow)
 * Standard [`flow` diff](https://github.com/dotnet/standard/compare/release/2.0.0...dagood:flow)
 * (Initial implementation: not a clean build) Core-Setup [`flow` diff](https://github.com/dotnet/core-setup/compare/release/2.0.0...dagood:flow)

Prototype source-build orchestration, including up to date submodules: Source-Build [`flow` diff](https://github.com/dotnet/source-build/compare/dev/release/2.0...dagood:flow).
