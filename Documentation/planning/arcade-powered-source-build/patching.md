# How do we patch without an orchestration-focused repo?

Enabling Core-SDK to perform an official build means we no longer need
source-build, which has traditionally held `.patch` files. When we get to our
goal of each repo performing an official source-build, where do patches go?

## Ideal: no more patches

In the best world, patches are no longer considered as a solution to build or
functionality problems. If source-build doesn't work, we fix it and respin the
official build, because a source-build issue is treated the same as an issue
with the Microsoft-built .NET Core SDK.

## Pragmatic: additional branches if necessary

However, there are reasons a respin may not be feasible. In an intermediate
state, source-build performance may be slow enough that it must be built and
fixed up outside the Microsoft official build. But even if that's fixed, there
may be a case where an issue with source-build is discovered very late, and we
can identify a patch that fixes it but can't afford to respin the Microsoft
build.

In these cases, we should create a branch in the affected repo based on the
current commit that includes the patch as a Git commit. This avoids a
specialized "patch file" workflow, and it is business as usual to merge the
hotfix into the branch for the next build.

This implies that Darc/Maestro++/BAR must be able to flow builds from the new
branch through official builds using a "source-build patch" channel.
Alternatively, we can temporarily stop using intermediates and build the entire
product from source in Core-SDK until the next release.
