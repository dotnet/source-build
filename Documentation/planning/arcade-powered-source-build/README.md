# DRAFT

**This is a proposal, checked in for reference and review. It has not been
ratified.**

# Arcade-powered source-build

Source-build existing outside the Microsoft build process impedes efforts to
maintain the source-buildability of .NET Core. Integration into the normal build
process is driven by two major goals:

1. Official build. When the .NET Core SDK official build completes, its
   artifacts include validated, ship-ready source-build outputs, in addition to
   the Microsoft build outputs.

   * This has two core benefits over the current situation: we know immediately
     whether an SDK can be source-built cleanly, and the status is as visible as
     an SDK build failure.

   * Breaks in source-build can be detected and fixed immediately by repo
     owners, just as any other build failure, rather than fixed by source-build
     maintainers weeks to months after the fact using patches.

   * Decisions about rebuilding the SDK close to release day don't need to
     consider source-build status and respin time as external factors.

   * Rebuilding the SDK close to a release day doesn't cause setbacks to
     source-build maintainers by throwing away manual build uptake work.

   * This eliminates the delay between Microsoft build completion and
     source-build tarball availability, as long as we treat a source-build
     failure as seriously as a Microsoft build failure.

2. PR validation. Every repo involved in source-build validates
   source-buildability in its PR validation build.

   * This allows developers and release owners to understand the source-build
     impact of changes, reducing the frequency the source-build servicing team
     has to root-cause and patch over problems.

This doc is about where we can start, what incremental progress would look like,
and the vision.

## Starting point: official build

The output of source-build is a set of tarballs that can be used to build the
.NET Core SDK from source. We can move the current behavior of source-build to
the Core-SDK official build. That is, Core-SDK clones all constituent repos,
applies patches, builds each repo using customized build commands, and produces
the source-build tarballs as artifacts.

This immediately makes the dotnet/source-build repo unnecessary: it only held
the source-build orchestration behavior.

This needs more work to meet our goals due to build performance. It is simply
too slow (> 2hrs) to build all constituent repos within one official build. It
needs to be fast enough that it is reasonable for the entire official build to
be rejected when the source-build fails.

> Note: practically, the source-build official build should run in an
> independent build pipeline at first: the long build time would interfere with
> other .NET 5 work if integrated directly.

For more info, see [source-build-in-pipeline.md].

## Starting point: PR validation

We can start here by adding extra jobs that run the standard source-build
command and arguments. This is a simple step to confirm the build isn't
fundamentally broken.

This needs more work to meet our goals for many reasons:

* Prebuilt dependency usage isn't tracked, because all dependencies are
  downloaded as non-source-built prebuilts.
* Source-build behavior may not work with source-built upstreams.
* The artifacts built by the repo may not work downstream.
* Advanced build flows aren't checked, such as source-build bootstrap or using
  an N-1 SDK.

For more info, see [source-build-in-pipeline.md].

## Incremental progress

### The performance gap
We need to avoid building all constituent repos in the Core-SDK build. To do
this, each repo needs to produce intermediate source-built artifacts during its
official build, to be consumed by downstream repos. On the other end,
source-build needs to support restoring from an intermediate artifact.

To make incremental progress, we should pick one of Core-SDK's upstreams, and
add source-build functionality that produces source-built intermediates.
Core-SDK should consume them. We should choose a leaf in the source-build
dependency graph, say, Linker. When Core-SDK is looking at the build graph to
determine which repos to build, instead of building Linker, it should restore
the Linker intermediate artifact. Once we have this flow working, the
functionality should be integrated into Arcade SDK for easy onboarding.

Then, working from the bottom (leaves) upward (towards Core-SDK), more repos
should consume and produce source-built intermediates in their official builds.
When this completes, each repo only needs to build itself. See
[incremental-official.md] for more details about this process.

It is possible to instead only implement official source-build in a handful of
repos. This segments the build into chunks, which must be coherent. This idea is
discussed in [incremental-official-chunked.md], and is not recommended.

> Note: some constituent repos aren't maintained by Microsoft, so it isn't
> feasible to add them directly to this flow. We could fork them and set up a
> build just for source-build intermediates. If a repo builds quickly, however,
> it might be better to simply rebuild it whenever the outputs are needed.

### Getting into Arcade
The initial plan to run source-build in Core-SDK doesn't assume any changes to
Arcade: this should be possible due to the extension points that already exist
in the Arcade SDK. Once we have that, it will be clearer what logic is missing,
and how to add it. This allows us to migrate source-build logic incrementally
and in parallel with other work.

For more info, see [in-arcade.md].

### The speculative SDK
It's difficult to validate that a PR won't break downstream repos. This problem
is shared by source-build and the Microsoft build. "Speculative builds" have
been proposed to try to help with this, but would be very difficult to implement
in the Microsoft build. It may be more reasonable in the context of
source-build: all builds happen on a single machine, so the problem is focused
on figuring out a build graph rather than organizing dozens of machines in a
build lab and flowing bits across a network.

This is also necessary in source-build to validate several distro maintenance
scenarios: by making a PR, is it still possible to run a bootstrap build of the
.NET Core SDK? Can .NET Core SDK version N be built using SDK N-1?

This can be developed in parallel to other efforts. See [speculative-build.md]
for more info about speculative builds.

## End result

When all of this is working, the official Microsoft build of the .NET Core SDK
also produces tarballs that distro maintainers can use to build it from source.
Contributors in each repo use checks in PR validation to verify each change is
compatible with source-build requirements, and if validation runs into a
problem, they are able to reproduce the build locally using an Arcade build
command.

---

## Q&A

### Q: How do we patch without an orchestration-focused repo?
A: We shouldn't! But if we have to, use a forked branch. See
[patching.md](patching.md).


[in-arcade.md]: in-arcade.md
[incremental-official-chunked.md]: incremental-official-chunked.md
[incremental-official.md]: incremental-official.md
[source-build-in-pipeline.md]: source-build-in-pipeline.md
[speculative-build.md]: speculative-build.md
