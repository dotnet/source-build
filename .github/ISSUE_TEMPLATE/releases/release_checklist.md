<!-- Issue Title: --> Source-build {runtime-version} / {sdk-version} {Month} {Year} Servicing

# {runtime-version} / {sdk-version}

1. - [ ] Create a page at ".NET Core A&D" OneNote -> "Servicing" section -> "Retrospective" -> "{Month} {YYYY}" to take ongoing notes on problems with the process, workarounds, and fixes.
     - This is useful to make sure context is available to review later. It may end up blank if the release goes very smoothly.
     - There are other notes on servicing in this OneNote. It may be useful to review if something goes wrong to see if it's been fixed before.
     - File issues appropriately as you encounter problems, and link to them from the notes. Provide info in the issue rather than in the notes.
1. - [ ] Retrieve the final run of the [Stage-DotNet](https://dev.azure.com/dnceng/internal/_build?definitionId=792&_a=summary) pipeline from internal release communications.
1. - [ ] Run the [`source-build-release-official`](https://dev.azure.com/dnceng/internal/_build?definitionId=1229) pipeline.
     - When staging the pipeline run, click "Resources" and select the final run of `Stage-DotNet` mentioned above.
     - If a special source-build tag was created for the release, check `Use custom tag` and set the `Custom release tag` parameter. Otherwise, a release name from the release manifest is used by default.
     - In case a different installer commit is being released than the one in the associated staging pipeline, check `Use specific pipeline run IDs` and input the official build numbers of the builds belonging to the released commit for the parameter(s) relevant to the target .NET version ("Specific {pipeline} run name").
     - In case you will be using a gist to craft the GitHub announcement, create a secret gist with a single `.md` file. Name the whole gist what you want the title of the announcement to be, e.g. `.NET 8 March 2023 Update - .NET 8.0.0-preview.2.23128.3 / SDK 8.0.100-preview.2.23153.6`. The name of the gist file is not relevant (make it an `.md` though). Suggested content of the announcement will be shown in the `Pre-Release` stage.
     - If necessary, run the pipeline as a dry-run first to make sure the stages have the correct output.
     - The pipeline has several stages with approval gates in between them where each approval should follow some verification described in this checklist.
     - Follow the steps below as the pipeline progresses. There will be manual steps needed throughout the run.

     #### `source-build-release-official` stages:

      1. - [ ] `Pre-Release` stage
           - This stage automatically pushes a branch with the sources that are being released to [`dnceng/security-partners-dotnet`](https://dev.azure.com/dnceng/internal/_git/security-partners-dotnet).
           - **It is advised to run this stage a day prior to the release to verify that all required builds exist.**
           - ⚠️ 8.0: It can happen that the commit of installer that the staging pipeline is associated with doesn't have a corresponding VMR build (as this one is batched). In this case, the stage will fail to find it and let you know it didn't find the build. When this happens, queue the [`dotnet-dotnet`](https://dev.azure.com/dnceng/internal/_build?definitionId=1219) pipeline from the VMR commit that has synchronized the installer commit that is being released (you can search commits in VMR for the commit SHA as it's part of the commit message). The resulting build run should be tagged with the installer SHA. You can then re-run the `Pre-Release` stage and it should find this build.
           - ⚠️ 6.0 / 7.0: This pipeline also uploads the dotnet source tarball to `dotnetclimsrc` with the tarball contents.
           - [ ] Verify the release metadata logged as part of the `Read Release Info` build step.
           - The `Get Associated Pipeline Run IDs` build step will contain links to pipelines associated with this release:
                - ⚠️ 6.0 / 7.0: [dotnet-installer-official-ci](https://dev.azure.com/dnceng/internal/_build?definitionId=286) and [dotnet-installer-source-build-tarball-build](https://dev.azure.com/dnceng/internal/_build?definitionId=1011)
                - ⚠️ 8.0: [dotnet-dotnet](https://dev.azure.com/dnceng/internal/_build?definitionId=1219) and the `dotnet/dotnet` commit that represents the release
           - [ ] ⚠️ 6.0 / 7.0: Navigate to the build link and ensure the `PoisonTests` and `SdkContentTests` are passing. Warnings indicate a baseline diff and should be inspected carefully.
                - Please note that failures of these tests manifest as warnings in the `Run Tests` build step and not as failed tests in the test result viewer. This means you need to verify the `dotnet-dotnet` build doesn't have any warnings regarding these tests.
           - [ ] ⚠️ 8.0: Verify the run of [source-build-sdk-diff-tests](https://dev.azure.com/dnceng/internal/_build?definitionId=1231) for the related release branch has run cleanly.
           - [ ] The `Create announcement draft` step should produce a valid announcement text. When using the announcement gist, copy the text to your gist file, copy the suggested title to your gist's title.
      1. - [ ] `Approval - PR merged & ready for dotnet-security-partners mirroring` stage
           - [ ] ⚠️ 6.0 / 7.0: Update `dotnet-security-partners`
                - [ ] A PR will be created for the appropriate `release/*` branch on [dnceng/security-partners-dotnet](https://dev.azure.com/dnceng/internal/_git/security-partners-dotnet). A branch was automatically created during the `Pre-Release` stage.
                     - [ ] Review and squash-merge the PR once CI finishes successfully.
           - [ ] Approve the `Approval - PR merged & ready for dotnet-security-partners mirroring` approval stage.
      1. - [ ] `Mirror sources & packages` stage
           - This stage mirrors and tags branches associated with the current release.
           - This stage should be ran only once per hand-off. If a new run is needed, removal of the previously created tags/branches might be needed.
      1. - [ ] `Approval - Partner notification` approval stage (Servicing releases only)
           - [ ] Create a wiki page for the release in [dotnet-security-partners](https://dev.azure.com/dotnet-security-partners/dotnet/_wiki/wikis/dotnet.wiki). Include the following information:
                - links to [MSRC work items in the dotnet-security-partners org](https://dev.azure.com/dotnet-security-partners/dotnet/_workitems/recentlycreated/).
                - links to each release's source tarball and smoke test prereqs tarball in the `dotnetclimsrc` storage account. [Generate a URL with a SAS token](https://learn.microsoft.com/azure/vs-azure-tools-storage-explorer-blobs?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&bc=%2Fazure%2Fstorage%2Fblobs%2Fbreadcrumb%2Ftoc.json#get-the-sas-for-a-blob-container) that expires in 1 month.
                - link to the [artifact feed](https://dev.azure.com/dotnet-security-partners/dotnet/_artifacts/feed/dotnet) for smoke test prereqs
                - links to each release's dotnet-security-partners tag that was created with the source-build-release-mirror pipeline.
                - the expected release date.
                - information about how confident we are that this is the final release.
           - [ ] Notify partners of release. Send one email for all releases. Include the following in your email:
                - Link to the wiki page created in the previous step.
                - TO line should be dnsbReleaseAnnounce alias.
                - BCC line should be the list found [here](https://microsoft.sharepoint.com/teams/dotNETDeployment/_layouts/OneNote.aspx?id=%2Fteams%2FdotNETDeployment%2FShared%20Documents%2FGeneral%2FNET%20Core%20Acquisition%20and%20Deployment&wd=target%28source-build%2FServicing.one%7CB33C6848-FC82-4585-B69F-204C8449E219%2FPartner%20notification%20emails%7C359F2672-DA5F-4631-9526-423F2BF408AC%2F%29).
                - CC anyone who may be interested in this particular release.
           - ⚠️ For any updates to the release that need to be communicated to partners, update the wiki page and send another email summarizing the update with a link to the wiki page.
           - [ ] Approve the `Approval - Partner notification` approval stage.
      1. - [ ] `Approval - Release` stage
           - [ ] **SYNC POINT**: Wait for Microsoft build release.
           - [ ] ⚠️ 8.0: Verify the release tag in the `dnceng/dotnet-security-partners` repository matches theVMR commit to which is shown in the `Pre-Release` stage (in the `Get Associated Pipeline Run IDs` step).
           - [ ] Approve the `Approval - Release` approval stage.
      1. - [ ] `Release` stage
           - [ ] Verify that the announcement was posted to [dotnet/source-build discussions](https://github.com/dotnet/source-build/discussions) and that the content is correct and all links work.
                - If special edits to the announcement are needed, or the content of the announcement discussion is incorrect, source-build repo maintainers can edit the discussion directly once it is posted.
           - [ ] ⚠️ 8.0: In case a release has been published into `dotnet/dotnet` as draft, check its contents and publish it. The URL to the draft can be find in the `Create GitHub release` step.
           - [ ] Verify that the release-day PR was submitted to [dotnet/installer](https://github.com/dotnet/installer/pulls) and the content is correct.
                - If there is an error in the PR, commit directly to the PR branch directly to fix the problem by hand, then submit an issue to [dotnet/source-build](https://github.com/dotnet/source-build).
1. - [ ] Once the internal changes have been merged to the public GitHub repos, update the `PoisonTests` and `SdkContentTests` with any diffs from the official associated build.
1. - [ ] Update the [version of OmniSharp in the smoke tests](https://github.com/dotnet/installer/blob/04244dd8d4ba4409d1fd71a7fabd27d8d7338950/src/SourceBuild/content/test/Microsoft.DotNet.SourceBuild.SmokeTests/OmniSharpTests.cs#L21-L22) to the latest release.
1. - [ ] Clean up retrospective notes if necessary.
