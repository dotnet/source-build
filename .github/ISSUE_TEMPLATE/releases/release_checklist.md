# .NET Core Release Checklist

<!--
  To start the checklist for a new release:
  - If it's an internal release, open a new issue in dotnet/release (private repo).
    - Otherwise, open a new issue in dotnet/source-build.
  - Paste a copy of the below checklist.
  - Delete lines starting with [Internal] if running a non-internal release.
  - Delete lines starting with [Non-Internal] if running an internal release.
-->

<!--
  Enter the version tracked by this checklist.
-->
# {runtime-version} / {sdk-version}

1.  - [ ] Copy this template to a new issue in [dotnet/release](https://github.com/dotnet/release/issues) and fill in the runtime and SDK versions above.  Update this issue as you progress with servicing.
1.  - [ ] Create a OneNote page in [NET Core Acquisition and Deployment XXX Can we link to this?](https://microsoft.sharepoint.com/placeholderlink) > source-build > Servicing > Retrospective > "May 2022" (for example) to take ongoing notes on problems with the process, workarounds, and fixes.
      - This is useful to make sure context is available to review later. It may end up blank if the release goes very smoothly.
      - There are other notes on servicing in this OneNote. It may be useful to review if something goes wrong to see if it's been fixed before.
      - [Non-Internal] File GitHub issues as you encounter problems, and link to them from the notes. Provide info in the issue rather than in the notes.
1.  - [ ] [Internal] Work in the [dotnet-source-build](https://dnceng.visualstudio.com/internal/_git/dotnet-source-build?path=%2F&version=GBmain&_a=contents) repo.
    - [ ] [Non-Internal] Work in the [GitHub source-build](https://github.com/dotnet/source-build) repo.
1.  - [ ] [Internal] Ensure [internal/release/3.1](https://dnceng.visualstudio.com/internal/_git/dotnet-source-build?path=/&version=GBinternal/release/3.1&_a=history) branch is up to date with mirrored [release/3.1](https://github.com/dotnet/source-build/commits/release/3.1) branch.
1.  - [ ] Update to new version.
      - [3.1] [/Documentation/servicing/update-3.1.md](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/servicing/update-3.1.md)
      - Start a new working branch and PR for WIP so others can easily look if needed and CI starts running.
        - [Internal] For internal builds, use the branch name `dev/<youralias>/<SDK-version>-<month name><YYYY>`.  This is necessary because some branch protection kicks in on branches with "release" in the name.
1.  - [ ] Version update cleanup and confirmations
      - [3.1]
        - [ ] Verify that the `PrivateSourceBuiltArtifactsPackageVersion` in `eng/Versions.props` matches N-1 release artifacts.
        - [ ] Update the `global.json` SDK version to N-1: the latest released "3.1.XYY" SDK version, where "3.1.X" matches the SDK we're building.
        - [ ] Update feeds:
             - [ ] If new feeds were added to NuGet.config, copy them to smoke-testNuGet.config and the `VSS_NUGET_EXTERNAL_FEED_ENDPOINTS` section in `build.sh`.
             - [ ] Add the servicing feed to build.sh and smoke-testNuGet.config
				1. The URL will look like this: https://pkgs.dev.azure.com/dnceng/internal/_packaging/3.1.419-servicing.22219.28-shipping/nuget/v3/index.json
				1. In build.sh, add this feed to the `VSS_NUGET_EXTERNAL_FEED_ENDPOINTS`.
				1. In smoke-testNuGet.config, add another feed entry that looks like the others, with key="5.0.408-servicing.22219.28-shipping" (for example) and value as the servicing url.
        - [ ] Verify that all repos were updated, except for these expected to usually be stable:
          - arcade
          - sourcelink
          - aspnet-xdt
          - cliCommandLineParser
          - xliff-tasks
          - Newtonsoft.Json
          - common
          - Roslyn (except for feature band updates)
          - MSBuild (except for feature band updates)
          - NuGet-client (except for feature band updates)
          - fsharp (except for feature band updates)
          - VSTest (except for feature band updates)
1.  - [ ] Regenerate patches as necessary.
      - Run `./build.sh` to begin clone and patch application and see what, if anything, needs to be regenerated.  Issue to track re-patching workflow: [#1468](https://github.com/dotnet/source-build/issues/1468)
      - [3.1] ASP.NET will always need to be regenerated because it contains a version number that needs to be updated.  The version should be updated to the SDK version being built.  See https://github.com/dotnet/source-build/blob/release/3.1/patches/aspnetcore/0006-Fix-version-number.patch
1.  - [ ] Start building locally (for quick diagnosis) and in CI (for super clean build) and iterate towards a green build.
      - [Internal] [3.1] Set environment variable `internalPackageFeedPat` to dnceng internal PAT with package read and code read access.
        - E.g. run `export internalPackageFeedPat;read internalPackageFeedPat` and paste the PAT. This sets up your running shell for an authenticated build. Passing `/p:` isn't sufficient.
      - [Internal] [3.1] Also pass arg `/p:AzDoPat=$internalPackageFeedPat` to build.sh.
      - [Internal] To run CI, from [dnceng/internal/source-build-pre-arcade-CI](https://dev.azure.com/dnceng/internal/_build?definitionId=251), click "Run pipeline" and select your dev/… branch under "Branch/tag", then click "Run"
         - If you are unsure if your build will be successful, you can run only the centos71_* stages to save resources.
1.  - [ ] Review prebuilt baseline diff and iterate builds to drive to zero.
      - Find an explanation for each change in each (online/offline) baseline.
        - If possible, figure out the cause and fix.
          - Discuss with repo or code owner if the fix is a new patch.
          - This may require adding packages to dotnet/source-build-reference-packages.
        - If the baseline change is due to the change in patch version, make sure there's an issue tracking fixing the instability, or start tracking it.
        - If in doubt, talk to the team. Someone might have already encountered a similar diff in the past.
1.  - [ ] Add team members as reviewers to the PR. Get acceptance.
      - Note: The PR is internal for internal builds and on GitHub for non-internal builds.
      - [Non-Internal] Merge the PR when green and accepted.
      - [Internal] Don't merge the PR.
1.  - [ ] [Internal] Download the artifacts from the centos71_Online_BaseTarball PR validation build onto a machine with Bash.
      - From the "Artifacts" page, navigate to "Tarball centos71_Online_BaseTarball" and download the `base_tarball_*.tar.gz` and `tarball_*-smoke-test-prereqs.tar.gz` files.
      - The smoke-test prereqs are platform-independent but should be taken from this non-portable build, *not* CentOS7 Offline Portable.
      - Can use <https://github.com/dotnet/source-build/blob/release/3.1/scripts/fetch-azdo-artifact-tarball.sh> as a library.
        - E.g. download the tarballs with `download_tarball`, and fix them up with `fix_azdo_tarball` if necessary.
1.  - [ ] [Internal] Rename tarball and smoke-test prereqs to human-friendly names. (Can use `rename_tarball_inner_dir`.)
      - Refer to previous release's email threads for naming pattern.
1.  - [ ] [Internal] Upload tarballs and smoke-test prereqs to blob storage.
1.  - [ ] Complete manual validation steps
      - [ ] Ask for confirmation on poison report.
        - Confirm with team how to check this for a specific build/release.
      - [ ] [3.1] Verify the packs included in the SDK are from source-build-reference-packages, not source-build.
        - E.g. in `testing-smoke/builtCli`, run `find . -iname System.IO.Pipelines.dll -exec sha256sum {} \; | sort` and look at file origin based on checksum of the file in the SDK.
      - [ ] [3.1] Verify the packs included in the SDK have XML documentation comments. Presence of XML files in the SDK dir is adequate.  Issue tracking automation of this: [#1579](https://github.com/dotnet/source-build/issues/1579)
      - [ ] Re-validate the SHA1s in Versions file with the manifest in VSU share dir.
      - [ ] [3.1] Review the file list diff between Microsoft-built SDK and source-built SDK in smoke-test output.
        - [Internal] [3.1] For internal builds, smoke-test fails to acquire the Microsoft-built SDK. Manually acquire the Microsoft-built SDK from the build email you should have received, then run `scripts/compare-builds.sh` yourself to get the output to review.
          - [#1631](https://github.com/dotnet/source-build/issues/1631) tracks a fix.
        - Use <https://gist.github.com/omajid/9111a9310d452b3594b770d4ca8a3d87> as a loose baseline.
          - [#1630](https://github.com/dotnet/source-build/issues/1630) tracks a checked-in baseline.
1.  - [ ] Coordinate with team and complete manual distributed smoke-testing. Suggested assignment below, but it's flexible.  Send email with direct links to artifacts from green PR.
      - [3.1]
        - [ ] RHEL 7 & 8 VM - crummel
        - [ ] Fedora 30 - msimons
        - [ ] CentOS 7 - msimons
        - [ ] CentOS 8 - lbussell
        - [ ] Debian 9 - lbussell
1.  - [ ] [Internal] Send the tarball to partners. Include info about how certain we are that this will be the final Microsoft build.
      - Never overwrite a tarball. At least change the blob storage virtual dir to represent a new build. This can help avoid timing issues and make it more obvious if stale links were accidentally re-sent rather than new ones.
1.  - [ ] SYNC POINT: Wait for Microsoft build release.
      - Wait for dotnet/announcements post. <kbd>Watch</kbd> the repo to get emails so you don't have to poll.
        - Example: <https://github.com/dotnet/announcements/issues/160>.
1.  - [ ] [Internal] [3.1] In a dev branch on your GitHub fork of source-build, clean up.
      - [ ] [Internal] [3.1] Convert internal URIs to public in `eng/Version.Details.xml`.
        - `https://dev.azure.com/dnceng/internal/_git/<org>-<repo>` => `https://github.com/<org>/<repo>`
      - [ ] [Internal] [3.1] Remove internal package feeds from source-build.
        - `/NuGet.Config`
        - `/smoke-testNuGet.Config`
        - Do not remove from subrepos. The build infra removes these sources automatically while modifying each subrepo nuget.config file.
1.  - [ ] [Internal] Push the servicing branch to your GitHub fork and submit a source-build PR.
1.  - [ ] [Internal] If a build hits `fatal: reference is not a tree: cb5f173b`, [make the commit available on a fork and switch to it temporarily](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/servicing/make-commit-available.md).
1.  - [ ] [Internal] Add source-build team as reviewers.
1.  - [ ] [Internal] When CI is green and two reviewers approve, merge.
      - Avoid squash/rebase: nice to preserve commit hashes. However, there are no known dependencies on *source-build* commits being preserved.
1.  - [ ] Create and push tags on the post-merge commit. [/Documentation/servicing/tagging.md](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/servicing/tagging.md)
1.  - [ ] Create a GitHub release on the tag with SDK versioning.
      - Go to <https://github.com/dotnet/source-build/tags>
      - Expand the SDK-versioned tag's message and copy it
      - Click <kbd>...</kbd> on the right on the SDK-versioned tag and press "Create release"
      - Paste into the release title
      - Click submit.
1.  - [ ] Notify distro maintainers and partners about the release tags
1.  - [ ] [3.1] Download merged Private.SourceBuilt.Artifacts.XX.tar.gz files from the prepare-artifacts leg in source-build-rolling-CI.
1.  - [ ] [3.1] Upload merged Private.SourceBuilt.Artifacts.XX.tar.gz file to dotnetcli account source-built-artifacts blob container.
      - Never overwrite a tarball. Use a sub-patch version if one already exists, e.g. `0.1.0-3.1.105.1`.
1.  - [ ] If there's a respin (for any reason: source-build infra fixes or upstream repo problems):
      - Go back in this process checklist as far as necessary.
      - When tagging, make sure to create a new tag. A sub-patch version tag for SDK and runtime must be generated. E.g - v2.1.300.1-SDK
1.  - [ ] Clean up retrospective notes if necessary.
