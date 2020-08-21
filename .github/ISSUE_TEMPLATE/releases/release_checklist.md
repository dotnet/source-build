# .NET Core Release Checklist

<!--
  To start the checklist for a new release:
  - If it's an internal release, open a new issue in dotnet/core-eng (private repo).
    - Otherwise, open a new issue in dotnet/source-build.
  - Paste one copy of the below checklist per release. (Once for 2.1, again for 3.1, if both are being serviced)
  - Delete lines that only apply to other releases. (E.g. delete [2.1] if doing a 3.1 release.)
  - Delete lines starting with [Internal] if running a non-internal release.
  - Delete lines starting with [Non-Internal] if running an internal release.
-->

<!--
  Enter the version tracked by this checklist.
-->
# {runtime-version} / {sdk-version}

1.  - [ ] Create a page at ".NET Core A&D" OneNote -> "Servicing" section -> "Retrospective" -> "{Month} {YYYY}" to take ongoing notes on problems with the process, workarounds, and fixes.
      - This is useful to make sure context is available to review later. It may end up blank if the release goes very smoothly.
      - There are other notes on servicing in this OneNote. It may be useful to review if something goes wrong to see if it's been fixed before.
      - [Non-Internal] File GitHub issues as you encounter problems, and link to them from the notes. Provide info in the issue rather than in the notes.
1.  - [ ] [Internal] Ensure internal/release/X.Y branch is up to date with mirrored release/X.Y branch.
1.  - [ ] Update to new version.
      - [2.1] [/Documentation/servicing/update-2.1.md](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/servicing/update-2.1.md)
      - [3.1] [/Documentation/servicing/update-3.1.md](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/servicing/update-3.1.md)
      - Start a new working branch and PR for WIP so others can easily look if needed and CI starts running.
        - [Internal] For internal builds, use <https://dev.azure.com/dnceng/internal/_git/dotnet-source-build>, branch name `internal/release/<SDK-version>-<month name><YYYY>`.
1.  - [ ] Version update cleanup and confirmations
      - [2.1]
        - [ ] Verify that `source-build/ProdConFeed.txt` contains the latest feed required for the release.
          - Build number should match ProdCon build number.
          - Ensure auth details are **not** included in this file.
        - [ ] Verify/update the ASP.NET versions (`MicrosoftAspNetCoreAllPackageVersion` and `MicrosoftAspNetCoreAppPackageVersion`) in dependencies.props.
        - [ ] Verify/update the `OfficialBuildId`s in updated repos (usually coreclr, corefx, core-setup).
        - [ ] Update the `DotnetCLIVersion.txt` SDK version to N-1: the latest released "2.1.XYY" SDK version, where "2.1.X" matches the SDK we're building.
      - [3.1]
        - [ ] Verify that the `PrivateSourceBuiltArtifactsPackageVersion` in `eng/Versions.props` matches N-1 release artifacts.
        - [ ] Update the `global.json` SDK version to N-1: the latest released "3.1.XYY" SDK version, where "3.1.X" matches the SDK we're building.
1.  - [ ] [2.1] Fetch internal git data for submodules.
      1.  Run `git submodule update --init --recursive` and see errors due to missing commits.
      1.  Run `fetch-vsts-commits.sh` with a PAT to automatically fetch internal refs.
      1.  Run `git submodule update --init --recursive` again to update failed submodules.
          * If some refs are still missing on unusual repos, those repos may need to be set up in `fetch-vsts-commits.sh`.
1.  - [ ] Regenerate patches as necessary.
      - Run `./build.sh` to begin clone and patch application and see what, if anything, needs to be regenerated.  Issue to track re-patching workflow: [#1468](https://github.com/dotnet/source-build/issues/1468)
      - [3.1] ASP.NET will always need to be regenerated because it contains a version number that needs to be updated.  The version should be updated to the SDK version being built.  See https://github.com/dotnet/source-build/blob/release/3.1/patches/aspnetcore/0007-Fix-version-number.patch
1.  - [ ] [Internal] [3.1] Update internal feed list in `.\build.sh`
      - Internal feeds are listed under `VSS_NUGET_EXTERNAL_FEED_ENDPOINTS`
      - Make sure to keep `dotnet3.1-internal-transport` in the list
      - Issue tracking this: [#1674](https://github.com/dotnet/source-build/issues/1674)
1.  - [ ] Start building locally (for quick diagnosis) and in CI (for super clean build) and iterate towards a green build.
      - [Internal] [3.1] Set environment variable `internalPackageFeedPat` to dnceng internal PAT with package read and code read access.
        - E.g. run `export internalPackageFeedPat;read internalPackageFeedPat` and paste the PAT. This sets up your running shell for an authenticated build. Passing `/p:` isn't sufficient.
      - [Internal] [3.1] Also pass arg `/p:AzDoPat=$internalPackageFeedPat` for darc clone in particular.
      - [Internal] [2.1] Pass auth arg `/p:ProdConBlobFeedUrlPrefix=<url up to and not including 'orchestrated-release-2-1/' from feed.txt>`
      - [Internal] [2.1] When running smoke-test locally, also pass `/p:ProdConBlobFeedUrlPrefix=<...>`
        - The smoke-test command looks like `./build.sh /t:RunSmokeTest /p:Configuration=Release /p:ProdConBlobFeedUrlPrefix=***`.
      - Update baseline from the CI job, using the `centos71 Offline` artifacts.
        - `Logs centos71 Offline/source-build/logs/artifacts/prebuilt-report/generated-new-baseline.xml`
          - => `tools-local/prebuilt-baseline-online.xml`
        - `Logs centos71 Offline/tarball/logs/artifacts/prebuilt-report/generated-new-baseline.xml`
          - => `tools-local/prebuilt-baseline-offline.xml`
1.  - [ ] Review prebuilt baseline diff and iterate builds to drive to zero.
      - Find an explanation for each change in each (online/offline) baseline.
        - If possible, figure out the cause and fix.
          - Discuss with repo or code owner if the fix is a new patch.
          - This may require adding packages to dotnet/source-build-reference-packages.
        - If the baseline change is due to the change in patch version, make sure there's an issue tracking fixing the instability, or start tracking it.
        - If in doubt, talk to the team. Someone might have already encountered a similar diff in the past.
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
1.  - [ ] Add team members as reviewers to the PR. Get acceptance.
      - Note: The PR is internal for internal builds and on GitHub for non-internal builds.
      - [Non-Internal] Merge the PR when green and accepted.
      - [Internal] Don't merge the PR.
      - [ ] Download the artifacts from the green PR validation build.
        - Download the tarball and smoke-test prereqs from each job.
          - We may require only a subset for certain releases: refer to the previous release email thread corresponding to 2.1 vs. 3.1 build.
        - Rename tarball and smoke-test prereqs to human-friendly names. Refer to previous release email for naming pattern.
          - Can use <https://github.com/dagood/terminal-setup/blob/master/bash-util/rename-inner-targz> to do this.
1.  - [ ] Upload tarballs and smoke-test prereqs to blob storage.
1.  - [ ] Coordinate with team and complete manual distributed smoke-testing. Suggested assignment below, but it's flexible.  Send email with direct links to artifacts from green PR.
      - [2.1]
        - [ ] RHEL7 and RHEL8 VMs - crummel
        - [ ] RHEL docker - dleeapho
        - [ ] Fedora30 - dseefeld
        - [ ] Fedora31 - dagood
        - [ ] Debian9 - crummel
      - [3.1]
        - [ ] RHEL 7 & 8 VM - crummel
        - [ ] RHEL Docker - dleeapho
        - [ ] Fedora30 - dseefeld
        - [ ] CentOS 7 - dagood
        - [ ] CentOS 8 - dseefeld
        - [ ] Debian - dagood
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
