# Dependency Management
_Written by @mmitche, @MichaelSimons, @mthalman and @ViktorHofer_

.NET, like any product, has numerous internal and external dependencies. This is expected. Unlike many products, however, .NET must maintain tight control over those dependencies to meet certain build environment restrictions. Failure to do so means that .NET will not ship in some Linux package feeds. Furthermore, the ability identify and control dependencies pays dividends in .NET's general long-term maintainability.

This document serves as a guide to developers altering .NET's dependencies.

## Source-build vs. Microsoft's proprietary build

.NET builds in two primary configurations: Offline source-build and Microsoft's proprietary build. The source build configuration is more restrictive. The product is constructed from source code, on a machine isolated from the internet, using only a set of inputs that have been previously source-built or provided by Microsoft for bootstrapping purposes. Microsoft's build is generally free to use available remote resources (e.g. package feeds), though this may change in the future.

### What do dependencies have to do with these different build configurations?

We must determine how this dependency will be satisfied in both the Microsoft build as well as the source-build configuration. Because the build requirements are different, it may be necessary to provide them in different ways.

***TODO: Add section about enabling dependency that's already available as source but not yet built in source build. ***

## I want to introduce a dependency on Foo. What do I do?

***TODO: Section about trying to avoiding new dependency when possible (i.e. by upgrading to a newer version or picking another library that's already available in the sources)***

## I really want to introduce dependency on Foo. What do I do?

The table below describes available methods of introducing dependencies in the product.
1. Evaluate each row to determine whether the method applies to your dependency.
2. For each applicable method, note which build configuration(s) it applies to.
3. After completing the evaluations, you should have at least one method that applies to source build, and one method that applies to Microsoft's propriety build. If you do not, please file an issue in the source-build repository.
4. Choose one method for each configuration. Using a single method is better.
5. Implement according to the guide below the table.

*Note: This list is not exhaustive and may not cover all cases. If you suspect your dependency is special, please contact **TODO***.

| **Dependency Source** | **Description** | **Requirements** | **Configurations** |
| --------------------- | ----------------| ---------------- | --------------------------- |
| [Source Build Externals (SBE)](https://github.com/dotnet/source-build-externals) | The source-build-externals repo contains the source of external .NET dependencies. The repository wraps and builds them according to source-build requirements. | <ul><li>Repository producing dependency is not on arcade</li><li>Dependency should not update often</li><li>NuGet package</li></ul> | Source-Build |
| [Source Build Reference Packages (SBRP)](https://github.com/dotnet/source-build-reference-packages) | The source-build-reference packages repo contains source for the surface area of released .NET packages. | <ul><li>Dependency is contract-only. Not executed</li><li>Should not update often</li><li>Dependency is stable and released</li><li>Not already included in source-build-externals.</li><li>Package should be produced by .NET.</li><li>NuGet package.</li></ul> | Source-Build |
| Previously source-built packages | As input to source-build, a set of previously source built packages are supplied, generated from the previous release or Microsoft's own release in certain bootstrapping scenarios. The versions of these inputs are flows into the build, overriding elements in eng/Versions.props. | <ul><li>Input must be part of the previously source built product.</li><li>Input package must provide a compatible surface area.</li><li>Contents of package may not be redistributed into a shipping product asset.</li></ul> | Source-Build |
| .NET 'Maestro' dependency flow | Maestro is the system by which outputs of repository builds are flowed into downstream dependent repositories, eventually constructing a complete product. For example, new builds of dotnet/runtime's .NET 8 branch flow downstream into winforms, aspnetcore, sdk, etc. | <ul><li>Dependency must be built previously in the source-build build graph**.</li><li>Must have active Maestro dependency subscriptions.</li><li>Dependency must be produced by .NET.</li></ul> **Maestro divides dependencies into two categories: product and toolset. Generally, toolset dependencies are only used for infrastruture and testing. Toolset dependencies may create cycles in dependency graph, but product dependencies may not. | Source-Build, Microsoft Build |
| External endpoints (dotnet-public, npmjs, MCR) | Dependencies can be pulled from public or internal package feeds using package managers. | <ul><li>Not updated often.</li><li>Must come from approved sources (e.g. dotnet-public, not directly from nuget.org).</li></ul> | Microsoft Build |
| Pre-installed on base images | Many dependencies are provided by the base environment. Examples include: Visual Studio, debian packaging tooling, etc. | <ul><li>If supporting a scenario included in the source-built product, compatible version must be available in all distribution maintainer build environments.</li></ul> | Source-Build, Microsoft Build |

***TODO: Section about implementation***
