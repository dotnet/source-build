# Incremental improvements to source-build in official builds

We can add official source-build to repos one at a time. This is effectively a
build cache, and adding each repo provides incremental benefit to build times
for official and local builds alike.

## Dependency leaves

The following diagram is the source-build intermediate output flow in 3.1, with
leaf nodes colored gold and the Core-SDK product at the top:

> ![](img/official-leaves.svg)
> [source (img/official-leaves.dot)](img/official-leaves.dot)

Initially, Core-SDK is the only node performing source-build, and it builds all
constituent repos from source. To reduce that build time, source-build must be
distributed amongst the repos. We should do this by repeatedly adding
source-build functionality to leaf repos (removing completed repos from the
graph) until every repo runs source-build.

> Note: the .NET Core build does have circular dependencies, so technically no
> repos are pure leaves. For example, compiling C# in the leaves above requires
> a .NET Core SDK toolset. Source-build cuts the dependencies as shown above and
> uses a bootstrap flow to avoid prebuilts. The bootstrap flow is out of the
> scope of this incremental official build doc. See ["The speculative SDK" in
> README.md](README.md#the-speculative-sdk).

## Leaf first

The reason to add source-build to leaf official builds first is that they don't
require any source-built intermedaite assets. We can add source-build to their
official builds without yet implementing the logic to fetch intermediate assets.

It is possible to pick a non-leaf repo, however it needs to get its
prerequisites from somewhere. It would need to build every repo from source.
(Depending on something like Microsoft-built NuGet packages defeats the point.)
See [incremental-official-chunked.md](incremental-official-chunked.md) for an
exploration of the idea of building small sets of repos from source at the same
time: it's a much costlier approach than it may seem.

## Consume intermediates in Core-SDK

After a leaf starts producing source-built intermediates, we should update
Core-SDK to consume it. This is basically a build cache: when intermediates
exist, use them rather than source-building the target repo. This lets us
prototype the infrastructure to consume source-built prebuilts before we roll it
out across multiple repos.

Once it works, intermediate consumption support should be added to the Arcade
SDK to allow for rollout.

## Rollout

Additional repos can then be added from the bottom up, building using upstream
source-built intermediates.
