# Chunked approach to including source-build in official builds

Instead of adding source-build to all official builds from the bottom up, it is
possible to separate the repos into chunks. Each chunk is several repos with one
"builder" repo that builds the entire chunk from source. This has some
significant restrictions:

* The builder must use all repos in the chunk as upstreams.
  * The builder needs to know which version to build, so it needs a dependency.
* The repos in a chunk need to be coherent.
  * The builder won't build multiple versions of the same repo, so all
    references to repos within the chunk need to be on the same version.
* When a downstream repo takes a dependency on any repo in the chunk, it must
  have a coherent parent dependency on the builder.
  * If the downstream repo takes a dependency on a repo that isn't part of a
    coherent build, source-build intermediates won't be available.

These coherency and upstream restrictions apply to the Microsoft build as well,
because it shares the same dependency graph. This will slow down dependency flow
in some cases. For example, a new package may need to flow through several repos
to maintain coherency rather than being uptaken immediately by a downstream
repo, due to the fake dependencies put in place to make the chunks work.

## Suggestion: avoid it

A chunked approach *could* be a backup if it ends up being extremely costly to
implement source-build in every official build. This is not expected.
