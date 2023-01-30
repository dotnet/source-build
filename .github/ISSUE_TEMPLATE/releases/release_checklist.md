<!--
  .NET 6.0+ Release Checklist

  To start the checklist for a new release:
  - Open a new issue in dotnet/release (private repo).
  - Delete lines starting with [Internal] if running a non-internal release.
  - Delete lines starting with [Non-Internal] if running an internal release.
-->

<!-- Issue Title: --> Source-build {runtime-version} / {sdk-version} {Month} {Year} Servicing

# {runtime-version} / {sdk-version}

1. - [ ] Create a page at ".NET Core A&D" OneNote -> "Servicing" section -> "Retrospective" -> "{Month} {YYYY}" to take ongoing notes on problems with the process, workarounds, and fixes.
    - This is useful to make sure context is available to review later. It may end up blank if the release goes very smoothly.
    - There are other notes on servicing in this OneNote. It may be useful to review if something goes wrong to see if it's been fixed before.
    - File issues appropriately as you encounter problems, and link to them from the notes. Provide info in the issue rather than in the notes.
1. - [ ] Retrieve the final run of the [Stage-DotNet](https://dev.azure.com/dnceng/internal/_build?definitionId=792&_a=summary) pipeline from internal release communications.
1. - [ ] Run the [source-build-pre-release](https://dev.azure.com/dnceng/internal/_build?definitionId=1188) pipeline.
    - ⚠️ 6.0 / 7.0: [source-build-pre-release](https://dev.azure.com/dnceng/internal/_build?definitionId=1188)
    - ⚠️ 8.0: [source-build-pre-release-8.0](https://dev.azure.com/dnceng/internal/_build?definitionId=TODO)
    - When staging the pipeline run, click "Resources" and select the final run of Stage-DotNet mentioned above.
    - This pipeline automatically pushes a branch with the sources that are being released to [`dnceng/security-partners-dotnet`](https://dev.azure.com/dnceng/internal/_git/security-partners-dotnet).
    - ⚠️ 6.0 / 7.0: This pipeline also uploads the dotnet source tarball to `dotnetclimsrc` with the tarball contents.
    - The `dotnet/installer` commit that represents the release will be in the logs for "Read Release Info"
    - The `Get Associated Pipeline Run IDs` build step will contain links to pipelines associated with this release:
        - ⚠️ 6.0 / 7.0: [dotnet-installer-official-ci](https://dev.azure.com/dnceng/internal/_build?definitionId=286) and [dotnet-installer-source-build-tarball-build](https://dev.azure.com/dnceng/internal/_build?definitionId=1011)
        - ⚠️ 8.0: [dotnet-dotnet](https://dev.azure.com/dnceng/internal/_build?definitionId=1219)
        - ⚠️ 8.0: The `dotnet/dotnet` commit that represents the release
    - [ ] Ensure the `PoisonTests` and `SdkContentTests` are passing.  Warnings indicate a baseline diff and should be inspected carefully.
1. - [ ] Gather smoke-test prereqs ([🔁 automation tracking issue](https://github.com/dotnet/source-build/issues/3068))
    - [ ] Retrieve smoke-test prereqs artifact for each architecture
        - [ ] ⚠️ 6.0 / 7.0: [dotnet-installer-source-build-tarball-build](https://dev.azure.com/dnceng/internal/_build?definitionId=1011)
            - [ ] x64 - `Build Tarball CentOS7-Offline_Artifacts/dotnet-smoke-test-prereqs.6.0.xxx.tar.gz`
            - [ ] arm64 - `Build Tarball Debian9-Offline_Artifacts/dotnet-smoke-test-prereqs.6.0.xxx.tar.gz`
        - [ ] ⚠️ 8.0: [dotnet-dotnet](https://dev.azure.com/dnceng/internal/_build?definitionId=1219)
            - [ ] x64 - `CentOSStream8_Offline_x64_Artifacts/dotnet-smoke-test-prereqs.8.0.xxx.centos.8-x64.tar.gz`
            - [ ] arm64 - `Debian11_Offline_arm64_Artifacts/dotnet-smoke-test-prereqs.8.0.xxx.debian.11-arm64.tar.gz`
    - [ ] Retrieve additional packages from internal MSFT feed using [this project](https://gist.github.com/lbussell/47a3953686c218ede865e305478df74a).
    - [ ] Create a new tarball of unique packages using [this script](https://gist.github.com/lbussell/5789974491e3d3ed737aac0e8b97b594).
    - [ ] Upload `smoke-test-prereqs` tarball to `dotnetclimsrc` storage account, following the pattern of previous releases for directory and filename.
        - Never overwrite a tarball. At least change the blob storage virtual dir to represent a new build. This can help avoid timing issues and make it more obvious if stale links were accidentally re-sent rather than new ones.
1. - [ ] Update `dotnet-security-partners`
    - [ ] Submit a PR to the appropriate `release/*` branch on [dnceng/security-partners-dotnet](https://dev.azure.com/dnceng/internal/_git/security-partners-dotnet). A branch was automatically created with the `source-build-pre-release` pipeline, you just have to submit the PR. ([🔁 automation tracking issue for this step](https://github.com/dotnet/source-build/issues/3069))
    - [ ] Squash merge the PR once CI finishes successfully.
1. - [ ] Run the [source-build-release-mirror](https://dev.azure.com/dnceng/internal/_build?definitionId=1221&_a=summary) pipeline
     - **Important**: this pipeline should be ran only once per hand-off. It mirrors and tags all of the branches listed in the parameters of `source-build-release-mirror.yml`. If you need to mirror and tag only some branches/repos, you can edit the yaml object directly at pipeline queue time.
    - **Important**: replace the `sdkVersion` with the new SDK version (e.g. 6.0.112) in the "mirrors" parameter for each branch.
1. - [ ] Notify partners of release. Send one email for all releases ([🔁 automation tracking issue for this step](https://github.com/dotnet/source-build/issues/3196)). Include the following in your email:
    - links to MSRC work items in the dotnet-security-partners org, being careful not to disclose any vulnerable info in the email.
    - links to each release's source tarball and smoke test prereqs tarball in the `dotnetclimsrc` storage account.
    - links to each release's dotnet-security-partners tag that was created with the source-build-release-mirror pipeline.
    - the expected release date.
    - information about how confident we are that this is the final release.
1. - [ ] SYNC POINT: Wait for Microsoft build release.
1. - [ ] Run the [source-build-release pipeline](https://dev.azure.com/dnceng/internal/_build?definitionId=1124) (internal link).
    - Under Resources, select the same pipeline run of `Stage-DotNet` that was used in the `source-build-pre-release` pipeline. Leave the version of `dotnet/installer` alone, the pipeline will checkout the correct tag.
    - If a special source-build tag was created for the release, check `Use custom tag?` and set the `Installer custom tag` parameter.
    - If necessary, run the pipeline as a dry-run first to make sure the stages have the correct output.
    - Click `Run` and wait for the pipeline to complete.
    - Verify that the announcement was posted to [dotnet/source-build discussions](https://github.com/dotnet/source-build/discussions) and that the content is correct and all links work.
        - If special edits to the announcement are needed, or the content of the announcement discussion is incorrect, source-build repo maintainers can edit the discussion directly once it is posted.
        - [ ] ⚠️ 7.0 / 8.0: Fix the release notes link ([known issue](https://github.com/dotnet/source-build/issues/3178))
    - Verify that the release-day PR was submitted to [dotnet/installer](https://github.com/dotnet/installer/pulls) and the content is correct.
        - If there is an error in the PR, commit directly to the PR branch directly to fix the problem by hand, then submit an issue to [dotnet/source-build](https://github.com/dotnet/source-build).
1. - [ ] Once the internal changes have been merged to the public GitHub repos, update the `PoisonTests` and `SdkContentTests` with any diffs from the tarball build in step 3.
1. - [ ] Clean up retrospective notes if necessary.