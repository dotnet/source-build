<!--
  .NET 6.0 Release Checklist

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
1. - [ ] Retrieve dotnet/installer commit sha from internal communications for the release.
1. - [ ] Ensure the official installer and tarball builds have completed for the release's commit sha.
     - [ ] [Installer](https://dev.azure.com/dnceng/internal/_build?definitionId=286) (internal link)
       - [ ] Retrieve the source tarball artifact - `BlobArtifacts/dotnet-sdk-source-6.0.xxx.tar.gz`
     - [ ] [Tarball](https://dev.azure.com/dnceng/internal/_build?definitionId=1011) (internal link)
       - [ ] Ensure the PoisonTests and SdkContentTests are passing.  Warnings indicate a baseline diff and should be inspected carefully.
1. - [ ] [Internal] Gather smoke-test prereqs and package in dotnet-smoke-test-prereqs-6.0.101.tar.gz.
     - [ ] Retrieve the smoke-test prereqs artifact for each architecture (e.g. x64 and arm64) from [tarball build](https://dev.azure.com/dnceng/internal/_build?definitionId=1011) (internal link) - `Build Tarball CentOS7-Offline_Artifacts/dotnet-smoke-test-prereqs.6.0.xxx.tar.gz`
     - [ ] Manually retrieve `microsoft.net.runtime.monoaotcompiler.task` package by running `dotnet workload install macos` or manually downloading. Add package to each smoke-test prereqs tarball. [Automation tracking issue](https://github.com/dotnet/source-build/issues/2774) for this step.
1. - [ ] [Internal] Upload source and smoke-test-prereqs tarball to dotnetclimsrc storage account.
1. - [ ] Notify partners of release.  Include info about how certain we are that this will be the final Microsoft build.
     - [Internal] Send the dotnetclimsrc tarball links to partners.
         - Never overwrite a tarball. At least change the blob storage virtual dir to represent a new build. This can help avoid timing issues and make it more obvious if stale links were accidentally re-sent rather than new ones.
     - [Non-Internal] Send the dotnet/installer commit sha along w/link to publicly built source tarball.  Link to the public instructions for building source-build.
1. - [ ] SYNC POINT: Wait for Microsoft build release.
1. - [ ] Upload the source-build artifacts to dotnetcli/source-built-artifacts blob storage.
     - [ ] Retrieve the source-build artifacts from [Tarball](https://dev.azure.com/dnceng/internal/_build?definitionId=1011) (internal link) - `Build Tarball CentOS7-Offline_Artifacts/Private.SourceBuilt.Artifacts.6.0.xxx.tar.gz`
1. - [ ] Run the [source-build-release pipeline](https://dev.azure.com/dnceng/internal/_build?definitionId=1124) (internal link).
     - Set the `SDK Version` parameter.
     - If a special source-build tag was created for the release, check `Use custom tag?` and set the `Installer custom tag` parameter.
     - Do not edit the `Branch/tag` parameter. The pipeline will check out `dotnet/installer` itself and verify that the specified release tag exists.
     - Verify that the announcement was posted to [dotnet/source-build discussions](https://github.com/dotnet/source-build/discussions) and that the content is correct and all links work.
          - If special edits to the announcement are needed, or the content of the announcement discussion is incorrect, source-build repo maintainers can edit the discussion directly once it is posted.
     - Verify that the release-day PR was submitted to [dotnet/installer](https://github.com/dotnet/installer/pulls) and the content is correct.
          - If there is an error in the PR, commit directly to the PR branch directly to fix the problem by hand, then submit an issue to [dotnet/source-build](https://github.com/dotnet/source-build).
1. - [ ] Once the internal changes have been merged to the public GitHub repos, update the PoisonTests and SdkContentTests with any diffs from the tarball build in step 3.
1. - [ ] Clean up retrospective notes if necessary.
