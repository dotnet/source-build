# Onboarding to arcade-powered source-build

Onboarding to ArPow (arcade-powered source-build) has several stages:

* **(1) Local build infra merged**
   * See [local-onboarding.md](local-onboarding.md).
   * PR submitted by source-build team.
   * Exit criteria:
	  - Local dev build works.
	  - Source-build intermediate packages are produced.
		- Intermediate packages contain the same set of packages as the in-progress 6.0 branch or the 5.0 branch.
	  - Prebuilts are reviewed (best effort basis).
	    - It will be difficult to determine if all prebuilts are correct before we have the whole graph building.
		- Packages built earlier in the source-build graph should not be using external prebuilts if the source-build intermediates for those are ready.
	  - If the target repo already has source-build CI, it is upgraded to ArPow. 
   * After completing this step:
	  - Log an issue in the target repo to remove source-build patches.
	  - Log an issue in the target repo to enable source-build CI.
* **(2) CI implemented** (PR + Official)
   * See [ci-onboarding.md](ci-onboarding.md).
   * PR submitted by repo's source-build champion.
   * Exit criteria:
      - All source-build patches are removed.
* **(3) Artifacts greenlit** for downstream usage
   * The source-build team looks at the results of an official build and marks
     the repo greenlit. No tooling.
   * Exit criteria:
      - CI is reviewed.
      - CI runs on release builds, checkins, and PRs.
      - Intermediate packages are produced and published to BAR.
      - Source-build team verifies that all expected packages are included in the intermediate packages.
* **(4) Prebuilt regressions blocked**
   * This involves reducing `eng/SourceBuildPrebuiltBaseline.xml` to a minimal
     set and enabling a flag that makes CI fail when a regression is detected.
   * PR submitted by source-build team.
   * Exit criteria:
      - All prebuilts are removed.

See [implementation-plan.md](../implementation-plan.md) for more details about
the steps and the overall ArPow implementation status.

See [arcade-powered-source-build/README.md](..) for more general information
about the end-to-end ArPow plan.


# Issue templates to track stage implementation in each repo

## 1

This is a starting point for the title/description of the initial PR.

```
ArPow stage 1: local source-build infrastructure
```

    This PR adds the local build infrastructure that lets ArPow (arcade-powered source-build) run in this repo. See <https://github.com/dotnet/source-build/blob/master/Documentation/planning/arcade-powered-source-build/onboarding/local-onboarding.md> for more details about how it works.

    To try it out locally, run this on Linux: `./build.sh -c Release --restore --build --pack /p:ArcadeBuildFromSource=true -bl`

    This PR should have no effect on ordinary builds, or CI. ArPow stage 2 will add source-build to CI: PR validation and official builds.

    For <https://github.com/dotnet/source-build/blob/master/Documentation/planning/arcade-powered-source-build/implementation-plan.md>

## 2

```
ArPow stage 2: implementing source-build CI
```

    To make sure ArPow (arcade-powered source-build) keeps working in this repo, we need to add it to PR validation. We also need it to run in the official build to publish source-built artifacts that can be tested downstream.

    Let us know when an official build runs with ArPow enabled, and the source-build team will look at it to greenlight the artifacts or make fixes.

    See <https://github.com/dotnet/source-build/blob/master/Documentation/planning/arcade-powered-source-build/onboarding/ci-onboarding.md> for ArPow CI onboarding info.

    For <https://github.com/dotnet/source-build/blob/master/Documentation/planning/arcade-powered-source-build/implementation-plan.md>

### Patches

If any patches were added in stage 1, they should get a tracking issue:

```
ArPow followup: incorporate the .patch files added to the repo
```

    The infra enabling ArPow (arcade-powered source-build) involves some `.patch` files checked into this repo at `eng/source-build-patches/*.patch` that fix up the repo to work for source-build. These patch files are prone to conflicting with dev changes, and may block some PRs until the PR author fixes up the patch file to match. The changes in these `.patch` files should be incorporated into the main branch of this repo to remove this possibility.

    Some background on source-build patches, for anyone who isn't familiar with previous pushes for patch incorporation:

    A patch is essentially just a commit that has been extracted from Git into a `.patch` file that can be applied on demand. The effort to build .NET from source involves creating patches because repos make changes that are incompatible with source-build and need to be fixed up after the original released source code has already been finalized. When the original repo gets PRs over time for servicing, the PR changes sometimes conflict with the source-build patches, just like a merge conflict. The patch files need to be fixed up when this happens, which is a significant maintenance problem for the source-build team.

    Several times, the source-build team has pushed for "patch incorporation". This means to merge the commit represented in the `.patch` file into the original repo's official branch. Doing so prevents patch merge conflicts, because there's no longer a patch to merge against. However, patches inevitably pile up again when getting subsequent servicing releases to work in source-build.

    ArPow lets us end this maintenance-heavy process. By running source-build inside CI, patch merge conflicts will immediately block PR validation, so fixup can be handled in place, not solely by the source-build team. Running source-build in CI also means creating new patches won't be necessary except in exceptional circumstances.

    This issue tracks using `git am eng/source-build-patches/*.patch` and submitting a PR to incorporate the patches, or making changes to the repo that accomplish the same goals as the patches.

    For <https://github.com/dotnet/source-build/blob/master/Documentation/planning/arcade-powered-source-build/implementation-plan.md>

## 3

Artifact greenlighting is a source-build exercise and doesn't require
documentation in the repo--just update the implementation status page.

## 4

TODO. We don't have the infra that makes it possible to block prebuilt
regression, as of writing.
