# Incremental improvements to source-build in official builds

We can add official source-build to repos one at a time. This incrementally
creates a tree of cached builds.

## Dependency leaves

The following diagram is the source-build intermediate output flow in 3.1, with
leaf nodes colored gold and the Core-SDK (dotnet/installer) product at the top:

> ![](img/official-leaves.svg)
> [source (img/official-leaves.dot)](img/official-leaves.dot)

To build up the tree of cached builds, source-build must be distributed amongst
the repos. We should do this by repeatedly adding source-build functionality to
leaf repos (removing completed repos from the graph) until every repo runs
source-build.

> Note: the .NET Core build does have circular dependencies, so technically no
> repos are pure leaves. For example, compiling C# in the leaves above requires
> a .NET Core SDK toolset. Source-build cuts the dependencies as shown above and
> uses a bootstrap flow to avoid prebuilts. The bootstrap flow is out of the
> scope of this incremental official build doc. See ["The speculative SDK" in
> README.md](README.md#the-speculative-sdk).

## Leaf first

The reason to add source-build to leaf official builds first is that they don't
require any source-built intermediate assets. We can add source-build to their
official builds without yet implementing the logic to fetch intermediate assets.
Once the leaves are added, we can onboard the repos that depend on those leaves
and have them restore the necessary source-build intermediate nupkgs.

It is possible to pick a non-leaf repo, however it needs to get its
prerequisites from somewhere. It would need to build every repo from source.
(Depending on something like Microsoft-built NuGet packages defeats the point.)
See [incremental-official-chunked.md](incremental-official-chunked.md) for an
exploration of the idea of building small sets of repos from source at the same
time: it's a much costlier approach than it may seem. We plan not to do this.

## Consume intermediates in dotnet/installer

After the dotnet/source-build-reference-packages (SBRP) leaf starts producing
source-built intermediates, we should update dotnet/installer to consume it.
This way we validate the intermediate nupkg infrastructure and get a chance to
move it into dotnet/arcade before we roll it out across multiple repos.

Note that we only plan to do this partially cached source-build with a single
leaf and dependency, SBRP => dotnet/installer. We won't repeat the exercise with
other intermediate nupkgs that will be incrementally added, because it's not yet
feasible at this point in the plan to keep source-build in dotnet/installer up
to date with the work being done in 5.0 branches.

Once it works, intermediate consumption support should be added to the Arcade
SDK to allow for rollout.

## Rollout

Additional repos can then be added from the bottom up, building using upstream
source-built intermediates.
