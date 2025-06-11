# ArPow (arcade-powered source-build)

Source-build exists as a process outside the Microsoft build, taking place after
the Microsoft build is complete. This creates a significant amount of catch-up
work to keep .NET buildable from source. Integration into the normal build
process is necessary to make source-build sustainable.

This is a user story in .NET 6.0:
[dotnet/core#5448](https://github.com/dotnet/core/issues/5448)

> *Definitions*:
>
> * **Official builds** run in Azure DevOps and produce the signed bits released
>   by Microsoft. These run on a daily or per-commit basis depending on repo and
>   point in time.
> * **PR validation** builds run on each pull request submitted to a repository,
>   and are typically required to succeed to merge. There are also **rolling
>   builds** that run either periodically or after each merge that run
>   lower-priority and/or slower tests.

ArPow consists of two main goals with some key benefits:

1. When the .NET Core SDK **official build** completes, its artifacts include
   validated, ship-ready source-build outputs, in addition to the Microsoft
   build outputs.

   * This way, we know that if a given SDK commit has a Microsoft build
     available, it is also buildable from source.

   * If an error occurs during source-build, it is visible to the same
     stakeholders as a Microsoft build failure, not just the source-build team.

   * Breaks in source-build can be detected and fixed immediately by repo
     owners, just as any other build failure. This is opposed to the traditional
     workflow: source-build maintainers detect the issue weeks to months after
     the fact, and must fix it using patches.

   * With ArPow and sufficient automated testing, there is zero delay between
     Microsoft build completion and source-build readiness. The traditional
     delay no longer needs to be considered by the Microsoft release process
     owners when figuring out a release timeline.

   * Rebuilding the SDK close to a release day doesn't cause setbacks to
     source-build maintainers by throwing away manual build uptake work.

2. Every repo involved in source-build validates source-buildability in its **PR
   validation** build.

   * This allows developers and release owners to understand the source-build
     impact of changes, reducing the frequency the source-build servicing team
     has to root-cause and patch over problems.

   * Gives us a place to add additional source-build-specific tests for common
     problems, such as prebuilt usage regressions.

This doc is about where we can start, what incremental progress would look like,
and the vision.

## Starting point: SBRP (dotnet/source-build-reference-packages)

Status: Complete.

We start by putting ArPow build infrastructure into SBRP, a repository owned by
the source-build team that has no upstream dependencies. This is done using the
Arcade SDK's extension points and custom Azure DevOps templates. Both are
integrated into Arcade after we see them working in SBRP. This lets us quickly
prototype the core ArPow functionality.

There are a few key parts of the infrastructure to prototype:

### Build integration

The official build and PR validation build pipelines work, with a reasonable API
for other repositories to adopt.

* [source-build-in-pipeline.md]

### Intermediate nupkg outputs/inputs

Every ArPow-enabled repository creates a NuGet package containing its build
outputs, for downstream repositories to use. On the other side, the Arcade SDK
infrastructure needs to be able to restore and use source-built intermediate
nupkg content.

SBRP ultimately won't use the restore-side infrastructure because it has no
upstreams, however, it can be developed here as a prototype.

* [intermediate-nupkg.md]
* [Create proof of concept: the source-build intermediate nupkg format
  #1543](https://github.com/dotnet/source-build/issues/1543)
* [Use SBRP intermediate nupkg to build SBRP
  #1636](https://github.com/dotnet/source-build/issues/1636)

### Prebuilt usage tracking

We aren't eliminating instances of prebuilt usage at this stage in the process,
but the tooling needs to work in the context of an Arcade-powered build.

* [Include prebuilt reports in intermediate nupkgs
  #1725](https://github.com/dotnet/source-build/issues/1725)

### Managed-only and RID-specific builds

Some .NET repositories only produce managed code outputs, and others produce
RID-specific outputs such as native binaries. To reduce the burden of ArPow on
small managed-only repositories, we build only one RID and use the same results
for all RIDs downstream. All repositories must be buildable under any RID, but
for simple managed-only repositories, this is a reasonable assumption. The
templates and Arcade SDK need to handle this.

* [Add mechanism to restore RID-specific intermediate nupkgs
  #1722](https://github.com/dotnet/source-build/issues/1722)

### Integrating tooling into Arcade

The ArPow tooling can be implemented inside the Arcade SDK's MSBuild extension
points, initially. Before onboarding any extra repos, it should be integrated
into the Arcade SDK proper to reuse the code.

* [in-arcade.md]
* [Source-build-specific MSBuild tool source in Arcade SDK
  (`Microsoft.DotNet.SourceBuild`)](https://github.com/dotnet/arcade/tree/main/src/Microsoft.DotNet.SourceBuild)

## Incremental progress

### Adding ArPow to the build graph

When we have ArPow SBRP complete, we start adding ArPow to repositories in the
.NET SDK dependency graph.

Working from the bottom (leaves) upward (towards dotnet/installer), we onboard
repos to ArPow: consume intermediate nupkgs from upstreams, run ArPow PR
validation, and produce intermediate nupkgs in the official build. For more
details about this process, see:

* [incremental-official.md]

It is possible to instead only implement official source-build in a handful of
repos. This segments the build into chunks, which must be coherent. This idea is
discussed in [incremental-official-chunked.md], and is not recommended.

Some repos required to build .NET aren't maintained by Microsoft, and don't have
official builds that inject artifacts into the Arcade dependency flow system
(Darc/BAR/Maestro++). It isn't feasible to add ArPow to these repos in the same
way. These repos will continue being built by dotnet/source-build, and
dotnet/source-build becomes a leaf in the build graph instead of an
orchestration repo.

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

### Adding unit tests

Unit tests are typically disabled in dotnet/source-build, because the test
infrastructure isn't built from source, and it increases build time. We should
run tests on the source-build product to catch bugs. However, this isn't
critical for the sustainability goals of this plan.

## End result

When all of this is working, the official Microsoft build of the .NET Core SDK
also produces tarballs that distro maintainers can use to build it from source.
Contributors in each repo use checks in PR validation to verify each change is
compatible with source-build requirements, and if validation runs into a
problem, they are able to reproduce the build locally using an Arcade build
command.

[in-arcade.md]: in-arcade.md
[incremental-official-chunked.md]: incremental-official-chunked.md
[incremental-official.md]: incremental-official.md
[source-build-in-pipeline.md]: source-build-in-pipeline.md
[speculative-build.md]: speculative-build.md
[intermediate-nupkg.md]: intermediate-nupkg.md
[intermediate nupkgs]: intermediate-nupkg.md

---

## Revisions

**2021-02-17** dagood  
Updated this doc to align with the current ArPow implementation plan. The old
implementation plan can be found at:
[2bf686a9](https://github.com/dotnet/source-build/tree/2bf686a91560911477885ae139909bbf10b7ca98/Documentation/planning/arcade-powered-source-build).
The plan has shifted towards purely incremental changes, with no end-to-end
ArPow source-build working until completion.

**2021-02-11** dagood  
Added a plan to use "supplemental intermediate nupkgs" to handle situations
where the [intermediate nupkgs] are too large to publish to Azure DevOps.

**2020-07-15** dagood  
Removed the plan to test every added intermediate nupkg all the way downstream
in dotnet/installer. Looking at it after some hands-on work has been done, we
don't think this end-to-end integration test is actually feasible. Not running
these tests creates some uncertainty, but it seems acceptable. We will likely
end up with a backlog of unknown issues to work through once we start building a
tarball in dotnet/installer. They *may* have been avoided with testing. We don't
expect this will be disruptive enough to make it worth trying to more
exhaustively find some way to get end-to-end testing feasible.
