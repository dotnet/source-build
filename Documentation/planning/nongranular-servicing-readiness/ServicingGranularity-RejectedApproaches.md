# Servicing Granularity - Rejected Approaches
See [README.md](README.md) for context on the servicing granularity problem.
This document discusses rejected approaches.

# Switching to microsoft build granularity
This section discusses the consequences of switching to the very granular
Microsoft servicing policy.

## Background: granularity of the Microsoft servicing build
How granular is the Microsoft build really? Each dotnet repo is generally a
product, but some repositories go further, containing multiple products in a
single source tree. This is an example based on 3.0 (some products may be
missing from the list):

* CoreFX
  * The NETCoreApp shared framework implementation (product)
    * `runtime.linux-x64.Microsoft.Private.CoreFx.NETCoreApp`
    * Always built when NETCoreApp gets any patch.
  * The out of band (OOB) packages (*each* is a product)
    * `System.Data.SqlClient`
    * `System.Diagnostics.EventLog`
    * `System.Drawing.Common`
    * `System.IO.Pipelines`
    * `System.IO.Ports`
    * ...more. These `System.*` packages are produced in CoreFX, but aren't
      included in the NETCoreApp framework. Some are used by downstream
      frameworks like ASP.NET Core, and by the tools and SDK. They are also used
      by apps directly via `PackageReference`.
    * These are somewhat likely to get patches over time.

* Core-Setup
  * The NETCoreApp shared framework and Runtime/AppHost pack (product)
    * `Microsoft.NETCore.App.Runtime.linux-x64`
    * Always built when NETCoreApp gets any patch.
  * The NETCoreApp Targeting pack (product)
  * NETStandard Targeting pack (product)
    * Targeting packs are unlikely to get patches.

* AspNetCore
  * ASP.NET Core shared framework and Runtime pack (product)
    * `Microsoft.AspNetCore.App.Runtime.linux-x64`
  * ASP.NET Core Targeting pack (product)

This means if you assemble a dependency graph of a theoretical .NET Core SDK,
say 3.0.103, it will contain multiple versions of the same repos:

* .NET Core SDK `v3.0.103`
  * CoreFX
    * `v3.0.3` - System.Security.Permissions, shared framework implementation
    * `v3.0.2` - System.ServiceProcess.ServiceController
    * `v3.0.1` - System.Security.Cryptography.Xml
    * `v3.0.0` - System.IO.Pipelines
  * [...]

This shows how the number of nodes will naturally grow over time. The max number
of versions of a specific repo is bounded by the number of products it builds.
The max is only three for Core-Setup, but larger (dozens?) for CoreFX because of
the number of independent OOB packages.

## Consequences of depending on multiple versions of the same repo

### Microsoft builds
This is completely fine for Microsoft servicing builds, because they use
prebuilts. When building a repo, all upstream products are downloaded from an
online source, so the *version* of each product isn't important.

### Building from source
Multiple versions of the same repo has significant consequences for
source-build, on the other hand. Downloading prebuilt products is forbidden, so
every upstream product must be built from source. The more commits built, the
longer the build takes.

In some cases, we can redistribute the previous source-built binaries, but we
have to account for bootstrapping on new distros (no previous source-build
exists) and distros that don't keep old binaries around:

> Some (not all) Linux distribution do keep around older distro packages in
their distro repository (eg, we build source-build 3.0.10, and 3.0.9 is still
around for installation). If that was a general policy (it's not, for example,
in Fedora) than source-build could do what Microsoft build does and use older
builds. Aside from being not being supported everywhere, it also means
source-build needs previous patch versions to have been built in that distro
too. A new distro couldn't skip packaging 3.0.0 if 3.0.10 still needs something
from there. [[omajid's review
comment](https://github.com/dotnet/source-build/pull/1389#discussion_r350783942)]

Even worse, the number of dependency nodes will tend to increase over time as a
branch gets serviced, as demonstrated above with the list of tags comprising a
theoretical `v3.0.103` SDK. This means the difficulty and complexity of building
.NET Core would then depend on how many times the branch has had a servicing
release.

A few concrete reasons this causes significant overhead and/or upfront work for
source-build infra maintainers:

1. Say a new distro appears that can't build anything earlier than CoreFX
   `v3.0.3`, but we need to bootstrap .NET Core. To build the required `v3.0.0`,
   `v3.0.1`, and `v3.0.2` tags, we must add patches to each one to get them to
   build. The patching work *probably* only needs to be done once and applied on
   all affected commits, but as the release branch continues to be serviced, the
   amount of work to get the product built on a new distro compounds.
2. Each repo must be checked out at every required commit/tag, which syncs a
   *lot* of irrelevant source code.
3. The repo must either be built in its entirety, or we need significant infra
   work to allow source-build to pick the exact product it needs to build.

## Q&A

### Can we split up source-build products to make this less difficult?
The thought here is that we might be able to split source-build into more
tarballs with more intermediate distro packages. This could reduce the amount of
code being compiled at once, making the build more incremental.

There is direct feedback from experienced distro maintainers that we need to
keep it simple: continue building a ".NET Core SDK + Runtime" product. Asking
distro maintainers to keep track of many products is a significant burden and
expected to cause mistakes.

This also doesn't solve (1) from above. We would still need to add patches to
old, unmaintained tags to bring up .NET Core on a new distro.

### Does source-build-reference-packages help?
Context: any NuGet package that only contains references can be built by
[dotnet/source-build-reference-packages](https://github.com/dotnet/source-build-reference-packages)
rather than checking out and building the original repo. In some cases, such as
targeting packs, we already do this.

This doesn't work for CoreFX OOB packages, which contain implementation. The OOB
packages are a particular pain point with this approach, so
source-build-reference-packages doesn't help significantly.
