# .NET Core Release Checklist

## Release Versions

_The set of .NET Core versions that are being released as a unit._

* 2.1.X: <runtime/SDK>
* 3.1.X: <runtime/SDK>

## 1. Non MSRC releases

1. - [ ] Verify that we are building with the appropriate stability and release tag (either none for RTM, or "preview1" etc).  This can apply to the SDK itself as well as the core-setup runtime component.
        
            dotnet --info
            dotnet --version

      - [ ] Verify ASP.NET package versions used in templates are correct (dependencies.props may need to be updated)
      - [ ] Verify MS.NETCore.App packages versions used in downlevel templates are correct (dependencies.props may need to be updated)
1. - [ ] Wait for .NET Core archive files (.zip, .tar.gz) to be available at blob storage location
1. - [ ] Run `update-dependencies` tool to update all the necessary files to reflect the specified .NET Core versions (run this command for each version being released):
      - [ ] `dotnet run --project .\eng\update-dependencies\update-dependencies.csproj --sdk-version <sdk> --runtime-version <runtime> --aspnet-version <runtime>`
1. - [ ] Inspect generated changes for correctness
1. - [ ] Commit generated changes
1. - [ ] Create PR
1. - [ ] Get PR signoff
1. - [ ] Merge PR
1. - [ ] Wait for changes to be mirrored to internal [dotnet-docker repo](https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-docker) (internal MSFT link)
1. - [ ] Build images - Queue build stage of [dotnet-docker pipeline](https://dev.azure.com/dnceng/internal/_build?definitionId=373) (internal MSFT link) with variables:

      All releases:

          stages: build

      Servicing release:

          imageBuilder.pathArgs: --path '2.1*' --path '3.1*'

      Preview release:

          imageBuilder.pathArgs: --path '5.0*'
1. - [ ] Wait for NuGet packages to be published during release tic-toc
1. - [ ] Test and publish images - Queue build of [dotnet-docker pipeline](https://dev.azure.com/dnceng/internal/_build?definitionId=373) (internal MSFT link) with variables:

      All releases:

          stages: test;publish
          sourceBuildId: <Build ID from the build stage>

      Servicing release:

          imageBuilder.pathArgs: --path '2.1*' --path '3.1*'

      Preview release:

          imageBuilder.pathArgs: --path '5.0*'
1. - [ ] Confirm images have been ingested by MCR
1. - [ ] Confirm READMEs have been updated in [Docker Hub](https://hub.docker.com/_/microsoft-dotnet-core)




	1. Verify that we are building with the appropriate stability and release tag (either none for RTM, or "preview1" etc).  This can apply to the SDK itself as well as the core-setup runtime component.
		a. dotnet --info
		b. dotnet --version
		c. Verify ASP.NET package versions used in templates are correct (dependencies.props may need to be updated)
		d. Verify MS.NETCore.App packages versions used in downlevel templates are correct (dependencies.props may need to be updated)
	2. Complete prebuilt and poison audit.
	3. Tag runtime version (e.g." v2.1.0") with an annotated (preferably signed) tag including runtime and SDK versions, e.g. "Release for 2.1.0 runtime and 2.1.300 SDK."
		a. git tag -s v2.1.0-runtime c7012bcc8
	4. Tag SDK version (e.g. "v2.1.300-SDK") with the same annotation, also preferably signed.
	5. Push these tags to GitHub.
		a. git push <remote> v2.1.0-runtime && git push <remote> v2.1.300-SDK
		b. Do not use "git push --tags" unless you have a fresh repo with no other tags - this will push all your tags.
	6. Notify Omair/Red Hat.
		a. Should we do this later? (?) - here seems good
	7. Download the tarball from VSTS CI to your machine.
		a. Which platform? (We only have centos now.) (?) - put platform and version in tarball name
	8. Create a GitHub release for the runtime tag you just pushed - see instructions below.
		a. Description (?) - CRummel to look into sourcing tags from other repos.  Or automated changelog?
	9. Additionally upload the release tarball to dotnetcli Azure storage.
		a. source-build container, virtual dir "red-hat/{release branch version}/{runtime tag without 'v'}/"
Build from the release tarball on a clean Red Hat machine and upload the artifacts to dotnetcli Azure storage beside the tarball.