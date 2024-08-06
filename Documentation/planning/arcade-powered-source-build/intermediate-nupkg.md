# The source-build intermediate NuGet package

To transfer source-built prebuilts from one repo to the next, we need a
transport format. NuGet packages are a proven method to do so, including
built-in caching, secure restore and push supported by Arcade, and versioning.

## The monster package

We can't publish individual source-built NuGet packages (nupkgs) to the feed
directly. They would conflict with Microsoft-built packages with the same IDs
and versions. These packages also have a reasonable risk of accidentally being
used by devs not familiar with source-build, poisoning the NuGet caches on their
systems.

To address both of these, source-build should assemble a monster nupkg that
contains all the nupkgs and other artifacts produced by the build.

* `source-build.dotnet-runtime.linux-x64.5.0.0-alpha.1.12345.nupkg/`
  * `Microsoft.NETCore.App.Ref.5.0.0-alpha.1.12345.nupkg`
  * `Microsoft.NETCore.App.Runtime.linux-x64.5.0.0-alpha.1.12345.nupkg`
  * `dotnet-runtime-5.0.0-alpha.1.12345-linux-x64.tar.gz`
  * ...

The version number here is the same as the official build's version number. This
makes the official build produce consistent artifacts and prevents overlap in
the same way it's prevented in existing official builds. The nupkg should always
have an unstable version because it's a transport package, helping to avoid
complicated feed management allowing mutation for stabilized rebuilds.

Official builds publish the monster nupkg, and downstream repos restore the
monster nupkg then use the contents. Note that if an official build fails to
produce its Microsoft build outputs *or* the source-build monster nupkg, it must
fail altogether. This ensures downstream repos have uninterrupted access to the
source-built intermediates.

## Too large?

Some repositories produce artifacts that would be too large for Azure DevOps
feeds to handle if put into a single intermediate package. To solve this, some
repos need to produce "supplemental intermediate nupkgs".

A "supplemental intermediate nupkg" uses the same naming convention as
intermediate nupkgs, but inserts an extra name between the repo name and the
RID.

* `Microsoft.SourceBuild.Intermediate.runtime.Libraries.linux.x64/6.0.0-foo`
  * Contains the dotnet/runtime platform extensions libraries.
  * E.g. `System.IO.Pipelines.6.0.0-foo.nupkg`,
    `System.Numerics.Tensors.6.0.0-foo.nupkg`, ...
* `Microsoft.SourceBuild.Intermediate.runtime.Crossgen2Pack.linux.x64/6.0.0-foo`
  * Contains the crossgen2 framework pack:
    * `Microsoft.NETCore.App.Crossgen2.linux-x64.6.0.0-foo.nupkg`
* `Microsoft.SourceBuild.Intermediate.runtime.Crossgen2Pack.Archive.linux.x64/6.0.0-foo`
  * This stores the `tar.gz` version of the crossgen2 framework pack:
    * `dotnet-crossgen2-6.0.0-foo-linux-x64.tar.gz`
  * Note: Calling it `.Archive` rather than `.Tarball` gives us room to handle
    `zip` files, to allow for Windows support in the future.
  * Crossgen2 is huge (~167 MB), so we need one supplemental nupkg for each
    artifact: one for the nupkg, another for the archive.

The names of the supplemental categories are based on the contents, but the
exact names are arbitrary. The goal is that it's clear enough that downstream
users will know what it contains.

For example, it would be fine to give the `Crossgen2Pack.Archive` supplemental
nupkg a name based on the artifact's filename, say, `dotnet-crossgen2`.
Arcade-powered source-build doesn't require a specific naming style. In this
case, making `Crossgen2Pack` and `Crossgen2Pack.Archive` similar seems
reasonable, since these are simply the same bits packaged different ways. Naming
is ultimately up to the project owner.

In general, the name should be concise: long NuGet package IDs can cause path
length problems.

### Contents

Each nupkg should either be < 20 MB, or contain only one artifact. This is a
heuristic to use to decide when to produce supplemental nupkgs and how to split
them up.

The non-supplemental intermediate nupkg contains:

* The prebuilt report.
* Any artifacts that are < 20 MB total and that all downstreams use.
* [New!] A list of supplemental intermediate nupkg names produced by the repo.
  * This shouldn't be read by any tooling. (Avoid complicated implementation.)
  * This makes it easier to figure out what supplemental nupkgs to include when
    working on a downstream repo. Just restore the main one and look at the list
    to see what to add.

The supplemental intermediate nupkgs only contain one or more artifacts--no
reports, and no list of supplemental nupkg names. The single *non-supplemental*
nupkg is always restored if *any supplemental* nupkg is restored, so the
report/metadata is always available to someone investigating a downstream build
that uses supplemental nupkgs. There is no need to deliver redundant data.

The supplemental packages of dotnet/runtime will have approximately these
download sizes:

Name | Download size (approx)
-- | --
RefPack | 1 MB
RefPack.Archive | 1 MB
RuntimePack | 107 MB
RuntimePack.Archive | 93 MB
HostPack | 47 MB
HostPack.Archive | 47 MB
Crossgen2Pack | 167 MB
Crossgen2Pack.Archive | 167 MB
Libraries | 6 MB
CoreCLR (ilasm/ildasm/testhost) | 6 MB

For context, some other repositories' intermediate nupkg total download size
that do not need any supplemental nupkgs:

* Arcade's intermediate nupkg is ~12 MB.
* SourceLink's intermediate nupkg is < 1 MB.
* xliff-tasks's intermediate nupkg is < 100 kB.

### Alternatives to manually split supplemental nupkgs

There are a few alternate solutions that aren't suitable:

* Split just enough for the nupkg to fit on Azure DevOps, and always restore
  every supplemental package.
  * This is direct workaround for the immediate problem: Azure DevOps has a 500
    MB limit on nupkg size (as of writing), and our intermediate nupkg for
    dotnet/runtime is ~1 GB.
  * This simplifies the design: the supplemental packages don't need meaningful
    names, and there are no extra lines needed in `eng/Version.Details.xml`.
  * This creates significant concern for CI performance, because every build
    downstream of dotnet/runtime will have to download all of that data, whether
    or not it's needed.
  * We have an opportunity to avoid a significant perf regression by rejecting
    this bare minimum approach.

* Split artifacts into one artifact per package.
  * This absolutely minimizes downloading artifacts that aren't needed.
  * This will either:
    * Significantly bloat the `eng/Version.Details.xml` file, specifying every
      single required artifact. This makes it less maintainable and more brittle
      to upstream changes.
    * Require much more complicated intermediate nupkg restore logic to figure
      out which supplemental intermediate nupkgs are necessary for the build.
  * This doesn't seem like it has major benefits vs. establishing a reasonable
    splitting heuristic. This is rejected to keep arcade-powered source-build
    simple.

## Addressability with different build args?

With a generic build cache, it's typically important for the build inputs to be
captured and incorporated in how the cache is addressed later. The build and its
artifacts must be deterministic, or else the distro maintainer ends up with
something different and we've failed to do useful validation.

However, the source-build intermediate packages are not a generic build cache. A
given official build version number is *never* built twice by Microsoft, let
alone with unpredictably varying arguments. That immutability is automatically
shared by the source-build official build.
