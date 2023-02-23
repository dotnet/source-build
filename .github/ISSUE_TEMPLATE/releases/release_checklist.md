<!-- Issue Title: --> Source-build {runtime-version} / {sdk-version} {Month} {Year} Servicing

# {runtime-version} / {sdk-version}

1. - [ ] Create a page at ".NET Core A&D" OneNote -> "Servicing" section -> "Retrospective" -> "{Month} {YYYY}" to take ongoing notes on problems with the process, workarounds, and fixes.
     - This is useful to make sure context is available to review later. It may end up blank if the release goes very smoothly.
     - There are other notes on servicing in this OneNote. It may be useful to review if something goes wrong to see if it's been fixed before.
     - File issues appropriately as you encounter problems, and link to them from the notes. Provide info in the issue rather than in the notes.
1. - [ ] Retrieve the final run of the [Stage-DotNet](https://dev.azure.com/dnceng/internal/_build?definitionId=792&_a=summary) pipeline from internal release communications.
1. - [ ] Run the [`source-build-release-official`](https://dev.azure.com/dnceng/internal/_build?definitionId=1229) pipeline.
     - When staging the pipeline run, click "Resources" and select the final run of `Stage-DotNet` mentioned above.
     - If a special source-build tag was created for the release, check `Use custom tag?` and set the `Installer custom tag` parameter.
     - If necessary, run the pipeline as a dry-run first to make sure the stages have the correct output.
     - In case a different installer commit is being released than the one in the associated staging pipeline, input the official build numbers of the builds belonging to the released commit.
     - The pipeline has several stages with approval gates in between them where each approval should follow some verification described in this checklist.
     - Follow the steps below as the pipeline progresses. There will be manual steps needed through out the run.

     #### `source-build-release-official` stages:

      1. - [ ] `Pre-Release` stage
           - This stage automatically pushes a branch with the sources that are being released to [`dnceng/security-partners-dotnet`](https://dev.azure.com/dnceng/internal/_git/security-partners-dotnet).
           - **It is advised to run this stage a day prior to the release to verify that all required builds exist.**
           - ⚠️ 8.0: It can happen that the commit of installer that the staging pipeline is associated with doesn't have a corresponding VMR build (as this one is batched). In this case, the stage will fail to find it and let you know it didn't find the build. When this happens, queue the [`dotnet-dotnet`](https://dev.azure.com/dnceng/internal/_build?definitionId=1219) pipeline from the VMR commit that has synchronized the installer commit that is being released (you can search commits in VMR for the commit SHA as it's part of the commit message). The resulting build run should be tagged with the installer SHA. You can then re-run the `Pre-Release` stage and it should find this build.
           - ⚠️ 6.0 / 7.0: This pipeline also uploads the dotnet source tarball to `dotnetclimsrc` with the tarball contents.
           - The `dotnet/installer` commit that represents the release will be in the logs for "Read Release Info"
           - The `Get Associated Pipeline Run IDs` build step will contain links to pipelines associated with this release:
                - ⚠️ 6.0 / 7.0: [dotnet-installer-official-ci](https://dev.azure.com/dnceng/internal/_build?definitionId=286) and [dotnet-installer-source-build-tarball-build](https://dev.azure.com/dnceng/internal/_build?definitionId=1011)
                - ⚠️ 8.0: [dotnet-dotnet](https://dev.azure.com/dnceng/internal/_build?definitionId=1219) and the `dotnet/dotnet` commit that represents the release
           - [ ] Ensure the `PoisonTests` and `SdkContentTests` are passing. Warnings indicate a baseline diff and should be inspected carefully.
                - Please note that failures of these tests manifest as warnings in the `Run Tests` build step and not as failed tests in the test result viewer. This means you need to verify the `dotnet-dotnet` build doesn't have any warnings regarding these tests.
      1. - [ ] `Approval - Test prereqs` stage
           - [ ] Gather smoke-test prereqs ([🔁 automation tracking issue](https://github.com/dotnet/source-build/issues/3068))
                - [ ] Retrieve smoke-test prereqs artifact for each architecture
                    - [ ] ⚠️ 6.0 / 7.0: [dotnet-installer-source-build-tarball-build](https://dev.azure.com/dnceng/internal/_build?definitionId=1011)
                        - [ ] x64 - `Build Tarball CentOS7-Offline_Artifacts/dotnet-smoke-test-prereqs.6.0.xxx.tar.gz`
                        - [ ] arm64 - `Build Tarball Debian9-Offline_Artifacts/dotnet-smoke-test-prereqs.6.0.xxx.tar.gz`
                    - [ ] ⚠️ 8.0: [dotnet-dotnet](https://dev.azure.com/dnceng/internal/_build?definitionId=1219)
                        - [ ] x64 - `CentOSStream8_Offline_x64_Artifacts/dotnet-smoke-test-prereqs.8.0.xxx.centos.8-x64.tar.gz`
                        - [ ] arm64 - `Debian11_Offline_arm64_Artifacts/dotnet-smoke-test-prereqs.8.0.xxx.debian.11-arm64.tar.gz`
                - [ ] Retrieve additional packages from internal MSFT feed using [this project](../../../test/GatherPackages.csproj).
                - [ ] Create a new tarball of unique packages using [this script](https://gist.github.com/lbussell/5789974491e3d3ed737aac0e8b97b594).
                - [ ] Upload `smoke-test-prereqs` tarball to `dotnetclimsrc` storage account, following the pattern of previous releases for directory and filename.
                    - Never overwrite a tarball. At least change the blob storage virtual dir to represent a new build. This can help avoid timing issues and make it more obvious if stale links were accidentally re-sent rather than new ones.
           - [ ] ⚠️ 6.0 / 7.0: Update `dotnet-security-partners`
                - [ ] Submit a PR to the appropriate `release/*` branch on [dnceng/security-partners-dotnet](https://dev.azure.com/dnceng/internal/_git/security-partners-dotnet). A branch was automatically created during the `Pre-Release` stage. You just have to submit the PR. ([🔁 automation tracking issue for this step](https://github.com/dotnet/source-build/issues/3069))
                     - [ ] Squash-merge the PR once CI finishes successfully.
           - [ ] Approve the `Approval - Test prereqs` approval stage.
      1. - [ ] `Mirror branch to DSP` stage
           - This stage mirrors and tags branches associated with the current release.
           - This stage should be ran only once per hand-off. If a new run is needed, removal of the previously created tags/branches might be needed.
      1. - [ ] `Approval - Partner notification` approval stage
           - [ ] Notify partners of release. Send one email for all releases ([🔁 automation tracking issue for this step](https://github.com/dotnet/source-build/issues/3196)). Include the following in your email:
                - links to MSRC work items in the dotnet-security-partners org, being careful not to disclose any vulnerable info in the email.
                - links to each release's source tarball and smoke test prereqs tarball in the `dotnetclimsrc` storage account.
                - links to each release's dotnet-security-partners tag that was created with the source-build-release-mirror pipeline.
                - the expected release date.
                - information about how confident we are that this is the final release.
           - [ ] Approve the `Approval - Partner notification` approval stage.
      1. - [ ] `Approval - Release` stage
           - [ ] **SYNC POINT**: Wait for Microsoft build release.
           - [ ] ⚠️ 8.0: Push the release tag to `dotnet/dotnet`
                - The tag name should match the custom tag used when staging the release pipeline.
                - The tag should be available in the `dnceng/dotnet-security-partners` repository.
                - The commit to which this tag belongs is shown in the `Pre-Release` stage (in the `Get Associated Pipeline Run IDs` step).
           - [ ] Approve the `Approval - Release` approval stage.
      1. - [ ] `Release` stage
           - [ ] Verify that the announcement was posted to [dotnet/source-build discussions](https://github.com/dotnet/source-build/discussions) and that the content is correct and all links work.
                - If special edits to the announcement are needed, or the content of the announcement discussion is incorrect, source-build repo maintainers can edit the discussion directly once it is posted.
                - [ ] ⚠️ 7.0 / 8.0: Fix the release notes link ([known issue](https://github.com/dotnet/source-build/issues/3178))
           - [ ] Verify that the release-day PR was submitted to [dotnet/installer](https://github.com/dotnet/installer/pulls) and the content is correct.
                - If there is an error in the PR, commit directly to the PR branch directly to fix the problem by hand, then submit an issue to [dotnet/source-build](https://github.com/dotnet/source-build).
1. - [ ] Once the internal changes have been merged to the public GitHub repos, update the `PoisonTests` and `SdkContentTests` with any diffs from the official associated build.
1. - [ ] Clean up retrospective notes if necessary.
