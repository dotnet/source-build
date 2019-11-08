# Servicing Granularity

This doc describes the granularity difference between Microsoft servicing and
source-build servicing, and the risk this causes. It proposes continuing with
the current overall approach, but reducing risk by adding tests to the Microsoft
build ensuring source-build doesn't get broken.

This is related to the problems in [source-build#923 "Figure out how
source-build will work with CoreFX per-package servicing
policy"](https://github.com/dotnet/source-build/issues/923).

## "Build only if changed" policy

This is a maintenance strategy where if a product hasn't changed, it isn't
rebuilt and won't be rereleased under a new patch version.

> A *product* for the sake of this doc is any released asset where an
independent decision is made whether that specific asset will be patched and
shipped.

For projects that release NuGet packages, it's ordinary to treat each NuGet
package as a product. For example, when a new .NET Core SDK patch is being built
to take a networking stack fix, the Microsoft servicing workflow doesn't involve
building and releasing new MSBuild `.nupkg` files to the NuGet Gallery. When the
patched SDK is built, old MSBuild binaries are retrieved from the NuGet Gallery.

Linux distributions tend to follow the same strategy, but the product is the set
of distro packages built from a single source package. To create a distro
package release, the entire source package is built. If one of the patched
distro packages takes a dependency built by a different source package, that
source package doesn't need to be rebuilt: the old build of the dependency is
used.

The difference is that the Microsoft .NET Core SDK build is very granular: each
NuGet package may be a product, even if it's built from the same source tree as
other NuGet packages. This causes a conflict when Microsoft chooses to build and
release a subset of what it considers the products contained in a specific
source package, but Linux distro expectations are to release the entire product
(all packages) from that source package. The partial build behavior is the
default when building from a `vX.Y.Z` Git tag in a dotnet repository.

## How source-build works now, despite different granularity

The current approach is to disable the partial build behavior through a build
flag while building the tag.

🚩 This is a risky workaround with the current state of the repos. There's no
mechanism in place that ensures the new packages will behave the same as the
ones produced by earlier Microsoft releases. See [source-build#923 "Figure out
how source-build will work with CoreFX per-package servicing
policy"](https://github.com/dotnet/source-build/issues/923).

## Can we unify servicing behavior?

In general, we want to minimize differences between the Microsoft build and
source-build. Making the builds behave the same way would be the natural way to
resolve the issue.

Applying the Microsoft build approach to source-build, we could split the
source-build .NET Core SDK into many source packages (and in turn, many distro
packages). This is considered unmaintainable. (See ['Switching to microsoft
build
granularity'](ServicingGranularity-RejectedApproaches.md#switching-to-microsoft-build-granularity).)

The other direction, making the Microsoft build use source-build's less granular
policy, is likely a non-starter. It would force unnecessary redownload of
products with no meaningful changes, a regression affecting products such as
Visual Studio.

Neither direction appears to be viable.

## Reduce the risk and continue disabling partial build behavior

We can continue with how things are now, but add tests to validate the different
approaches don't cause incompatibilities.

We should run the usual tests against the source-build outputs, to know the SDK
and runtimes function as expected. This is a base level of validation.

However, that would miss compatibility issues between source-build and the
Microsoft build. For example, if source-build produces a 3.0.2 version of some
assembly, but Microsoft hasn't released a patch to that assembly since 3.0.0, it
may be possible for a dev to publish a project that depends on the 3.0.2 binary
and fails to run on the Microsoft .NET Core Runtime because it only has 3.0.0.

Additional testing may be able to cover compatibility problems. If the .NET Core
repos know the version Microsoft last shipped of each product (already the case
in some repos), tests can download the last Microsoft-shipped packages and
compare the contents to the current. Tests can also analyze source code diffs to
spot suspicious unreleased changes.

Reversing the perspective may help clarify. Microsoft has an atypical servicing
policy where some source packages are not fully built. The proposal is to add
tests that help ensure compatibility when Microsoft chooses not to build part of
a source package.
