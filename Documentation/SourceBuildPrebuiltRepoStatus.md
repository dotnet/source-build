## Source-Build Prebuilt Removal Status Overview

Last source-build Build Date: 2019-07-25

Last updated: 2019-07-25

For more detailed information, see: [SourceBuildPrebuiltReport](https://msit.powerbi.com/groups/dc6359c5-e96a-44ce-9d86-0af7fab1c15e/dashboards/73f852d5-4ca7-45d7-8e5c-977c2da3b11c/reports/64e989dd-8072-4d84-8268-140bde0cbc7d/ReportSection4ba78a029c61708d6808)

<!--TrackingTable-->
| Repo/Issue | Owner | Overall Status | # of Patches | # of Prebuilts | Comments |
| :--- | :--- | :--- |  :---: | :---: | --- |
| [ApplicationInsights-dotnet][900] | Sergey Kanzhelev | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [arcade][970] | Mark Wilke | ![ot] On Track | 1 | 4 |
| [AspNetCore-Tooling][1150] | John Luo | ![ot] On Track | - | 1 | New repo added on 7/12
| [cli][880] | Nick Guerrera | ![cp] Complete | 5 | - |  All direct-dependency prebuilts removed.
| [cliCommandLineParser][976] | Nick Guerrera | ![cp] Complete | 3 | - | All direct-dependency prebuilts removed.
| [cli-migrate][881] | Nick Guerrera | ![cp] Complete | - | - | Repo removed
| [common][882] | Nate McMaster | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [coreclr][883] | Russ Keldorph | ![cp] Complete | 8 | - | All direct-dependency prebuilts removed.
| [corefx][884] | Eric St. John | ![ot] On Track | 2 | 6 |
| [core-sdk][972] | Nick Guerrera | ![cp] Complete | 2 | - | All direct-dependency prebuilts removed.
| [core-setup][885] | Davis Goodin | ![ot] On Track | 7 | 5 |
| [linker][887] | Dan Seefeldt | ![cp] Complete | 4 | - | All direct-dependency prebuilts removed.
| [Extensions][1132] | Nate McMaster / John Luo | ![ot] On Track | - | 7 | New repo added on 6/28
| [msbuild][888] | Nick Guerrera | ![ot] On Track | 1 | 5 |
| [Newtonsoft.Json][889] | Chris Rummel | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [NuGet.Client][890] | Rob Relyea | ![ot] On Track | 2 | 4 |
| [roslyn][891] | Jared Parsons / Fred Silberberg | ![ot] On Track | 3 | 4 |
| [roslyn-tools][892] | Tomas Matousek | ![cp] Complete | - | - | Repo removed
| [sdk][893] | Nick Guerrera | ![ot] On Track | 1 | 1 |
| [source-build-infra][975] | Dan Seefeldt | ![ot] On Track | - | 3 |
| [standard][894] | Eric St. John | ![cp] Complete | 1 | - | All direct-dependency prebuilts removed.
| [templating][895] | Vijay Ramakrishnan | ![ot] On Track | - | 1 |
| [Tools][974] | Dan Seefeldt | ![ot] On Track | - | 4 |
| [toolset][973] | Nick Guerrera | ![ot] On Track | 1 | 4 |
| [tools-local tasks][971] | Dan Seefeldt | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [fsharp][886] | Brett Forsgren | ![ot] On Track | - | 1 |
| [vstest][896] | Shiva Shankar Thangadurai / Sarabjot Singh | ![ot] On Track | - | 5 |
| [websdk][897] | Vijay Ramakrishnan | ![ot] On Track | 1 | 3 |
| xdt | Nate McMaster / John Luo | ![cp] Complete | - | - | No direct-dependency prebuilts.
| [xliff-tasks][899] | Tom Meschter | ![cp] Complete | - | - | All direct-dependency prebuilts removed.

<br/>

| Status   | Description |
| -------- | ----------- |
| ![ns] Not Started | Team has not started on prebuilts |
| ![pl] Planned | Prebuilts have been categorized and issues have been logged to remove |
| ![ot] On Track | Engineers are working through issues to remove prebuilts |
| ![ar] At Risk  | Prebuilt removal tasks not on track for completion or blocked |
| ![cp] Complete | All prebuilts removed |
| ![bn] Bounced | Previously complete, but new prebuilts have emerged |

[ns]: https://img.icons8.com/office/16/000000/medium-risk.png
[pl]: https://img.icons8.com/office/16/000000/gantt-chart.png
[ot]: https://img.icons8.com/office/16/000000/gps-device.png
[ar]: https://img.icons8.com/office/16/000000/high-risk.png
[cp]: https://img.icons8.com/office/16/000000/checked.png
[bn]: https://img.icons8.com/office/16/000000/return--v2.png

<br/>

<!--RepoCommitsAndDates-->
| Repo | Latest Commit | Commit Date
| --- | --- | ---
ApplicationInsights-dotnet | 53b80940842204f78708a538628288ff5d741a1d | 2017-12-21
arcade | 8f3c22397990aeb20a88690b51dad4b33f21e7ff | 2019-07-15
AspNetCore-Tooling | c1aafc5dce1a2372c9c3ebb310d6e64f0cced0a5 | 2019-07-24
cli | 25421a9dae0118afd4c14da085ae17dca7482f02 | 2019-07-04
cliCommandLineParser | 0e89c2116ad28e404ba56c14d1c3f938caa25a01 | 2019-04-08
common | 6e37cdfe96ac8b06a923242120169fafacd720e6 | 2018-11-02
core-sdk | ad21996be34bafd85f484acbda73643057db4b01 | 2019-07-05
core-setup | 7d68d147accb91858bfee92e599ad8507691040b | 2019-07-25
coreclr | ac4ab6c990d5ebee49dc03397a2e199241021f26 | 2019-06-27
corefx | 9c3c40ac8b4f9b56791bc3c18c540079dad8a812 | 2019-07-02
Extensions | 0db848f9c0091be8980db79c0b88c519910c4c3b | 2019-07-03
fsharp | 5289eb027336eb4c1ea70eaff246f42ca5584b4d | 2019-06-21
linker | 3dd5e55dc9cb7a7c5eaa73aefc70c3655e75f97b | 2019-06-24
msbuild | d31fdbf016616835b237d2846f3f1535560bb2d5 | 2019-06-28
Newtonsoft.Json | e43dae94c26f0c30e9095327a3a9eac87193923d | 2018-05-31
NuGet.Client | 27af96bdb7ba8d6d7ea9ad53fc76cd1d1aa80703 | 2019-03-29
roslyn | f5a3cafcbf01c6c15f6c9b1b17a602a31b667964 | 2019-06-26
sdk | 67b776f3ae8d393f777fb7186cf2023c6a20f93a | 2019-07-04
source-build-reference-packages | cffb0d986fc6a64554f1b0f25777d9ff26af3b9e | 2019-07-19
standard | a9422da6ed91b413019ef93051613c5f03801d64 | 2019-07-02
templating | b8f20a964a083fb9f53043aa9e0ddd53e376c4bf | 2019-07-02
toolset | 582d6b86ca0b2ba2106a294e2cfe330e5ed187f2 | 2019-07-05
vstest | 7d28e2008209c29289119aa87038dc2858524eef | 2019-05-29
websdk | 091b6630cdb5e964e4f4a2f17b4dff9feadd0ff9 | 2019-07-03
xdt | c01a538851a8ab1a1fbeb2e6243f391fff7587b4 | 2019-04-30
xliff-tasks | 173ee3bd61c9549557eefa3cfb718bdef157cb87 | 2019-05-02

**Prebuilts**

Prebuilts are dependencies that a repo has on binary files that are not built from source.  All packages included in the distro are built by the distro and the source requirements are inclusive of build tools and build dependencies. The default position for inclusion in a distro is no pre-built binaries though there are proper exceptional cases to bootstrap builds.

**Patches**

Patches are created in source-build when a repo's code doesn't build as-is. Patches are required to keep source-build moving forward and building on new product builds. As patches are created, issues are opened in the corresponding repo to incorporate the code and remove the patch.

| Patch name | Status| Type | Disposition | Responsibility | Notes | Issue
| --- | --- | --- | --- | --- | --- | ---
arcade/0001-Fix-InternalsVisibleTo-generation.patch | ![cp] Merged | One-off | Incorporate | source-build | Patch was needed only for cli-migrate signing issues.  Have PR out to Arcade anyway as it's a reasonable fix.
arcade/0002-Exclude-test-projects-from-source-build.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | https://github.com/dotnet/arcade/issues/3014
arcade/0003-Remove-projects-that-increased-prebuilts.patch | ![cp] Merged | ProjRemoval | Incorporate | Repo |  | 
arcade/0004-Use-alternate-workaround-for-bootstrapping-Arcade.patch | ![ns] No action | One-off | Soft-patch | source-build | Allows us to use the bootstrap version of arcade.  Will be fixed eventually by toolset bootstrapping. | 
aspnet-razor/0001-Remove-Internal.AspNetCore.Sdk-avoid-prebuilt.patch | ![cp] Not needed | Prebuilt | Incorporate | Repo |  | 
aspnet-razor/0002-Add-reference-assemblies-to-allow-net46-build.patch | ![cp] Not needed | Build | Incorporate | Repo |  | 
cli/0001-Implement-PVP-repo-API.patch | ![cp] Fixed upstream | Flow | Incorporate | Repo |  | https://github.com/dotnet/cli/issues/11518
cli/0002-Exclude-test-projects-from-source-build.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | 
cli/0003-Add-repo-specific-target-emptying-file.patch | ![ot] In PR | Build | Incorporate | Repo |  | 
cli/0004-Consolidate-Newtonsoft.Json-versions.patch | ![pl] Needs upstream fix | No-op | Remove | source-build | Rebased after CLI took the fix but due to a whitespace diff this patch remained although it does nothing. | 
cli/0005-Disable-signing.patch | ![cp] Fixed upstream | Build | Repo | source-build |  | 
cli/0006-Remove-keys-from-InternalsVisibleTo.patch | ![cp] Fixed upstream | Build | Repo | source-build |  | 
cli/0007-Consolidate-CommandLine-versions.patch | ![cp] Removed | Bug | RepoRemoval | Repo | This was an additional workaround for the cli-migrate signing issue and should go away when that does. | 
cli/0008-Add-LangVersion-to-CLI.patch | ![pl] May no longer be needed | ToolCompat | Remove | source-build |  | 
cli/0009-Revert-to-using-Newtonsoft.Json.patch | ![cp] Removed | ToolCompat | Remove | source-build |  | 
clicommandlineparser/0001-Remove-test-and-sample-projects-from-solution.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | 
clicommandlineparser/0002-Add-PackageProjectUrl-to-avoid-new-SDK-warning.patch | ![cp] Not needed | ToolCompat | Remove | source-build |  | 
clicommandlineparser/0003-Ignore-LicenseUrl-warning.patch | ![cp] Not needed | ToolCompat | Remove | source-build |  | 
cli-migrate/0001-Ignore-NU5125-warning-error-for-2.1.500-SDK.patch | ![cp] Repo removed | ToolCompat | RepoRemoval | source-build |  | 
cli-migrate/0002-Partial-revert-of-0943def486e13fb376c7cc4a78ff2f9d82.patch | ![cp] Repo removed | ToolCompat | RepoRemoval | source-build |  | 
cli-migrate/0003-Remove-test-projects-from-build.patch | ![cp] Repo removed | ProjRemoval | RepoRemoval | source-build |  | 
cli-migrate/0004-Add-PackageProjectUrl-to-fix-warning.patch | ![cp] Repo removed | ToolCompat | RepoRemoval | source-build |  | 
cli-migrate/0005-add-PVP-import.patch | ![cp] Repo removed | Flow | RepoRemoval | source-build |  | 
cli-migrate/0006-fix-package-version-properties.patch | ![cp] Repo removed | Flow | RepoRemoval | source-build |  | 
cli-migrate/0007-Add-LicenseExpression-for-new-warning.patch | ![cp] Repo removed | ToolCompat | RepoRemoval | source-build |  | 
coreclr/0001-Allow-separate-tool-and-SDK-directories.patch | ![ot] Working with Jarret | Build | Incorporate | Repo |  | https://github.com/dotnet/coreclr/issues/25058
corefx/0001-Remove-publishing-package-that-source-build-doesn-t-.patch | ![cp] Merged | Build | Incorporate | Repo |  | https://github.com/dotnet/corefx/issues/38412
core-sdk/0001-Don-t-reset-blob-URL-if-we-pass-it-in.patch | ![cp] Merged | Build | Incorporate | Repo |  | https://github.com/dotnet/core-sdk/issues/2398
core-sdk/0002-Don-t-copy-over-packages-if-there-are-no-packages-to.patch | ![cp] Merged | Build | Incorporate | Repo |  | 
core-sdk/0003-Remove-test-projects-from-solution.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | 
core-sdk/0004-Add-PVP-import.patch | ![cp] Fixed upstream | Flow | Incorporate | Repo |  | 
core-sdk/0005-Allow-specifying-CoreSetupRid.patch | ![cp] Merged | Build | Incorporate | Repo |  | 
core-setup/0001-Copy-run.cmd-changes-from-corefx.patch | ![pl] In progress | Build | Remove | Repo | This will go away once core-setup switches to Arcade. | https://github.com/dotnet/core-setup/issues/6762
core-setup/0002-Disable-licenseUrl-warning.patch | ![cp] No longer needed | ToolCompat | Remove | source-build |  | 
core-setup/0003-Disable-overriding-CentOS-as-RHEL.patch | ![pl] In progress | Bug | Incorporate | Repo | | 
core-setup/0003-Import-dependencies-props-after-eng-Versions-props.patch | ![pl] In progress | Flow | Incorporate | Repo | May also go away with the Arcade switch. | 
linker/0001-Add-an-option-to-use-reflection-heuristics-during-ma.patch | ![ns] No action | One-off | Fork | source-build | Patches in a feature needed by other repos that the maintainers rejected a PR for. | 
linker/0002-Exclude-test-projects-from-source-build.patch | ![ns] No action | ProjRemoval | Fork | source-build |  | 
msbuild/0001-Add-PackageLicenseExpression.patch | ![cp] No longer needed | ToolCompat | Remove | source-build |  | https://github.com/microsoft/msbuild/issues/4428
msbuild/0002-Enable-full-framework-builds-for-SDK.patch | ![pl] Needs ref asm | Build | Remove | source-build |  | 
msbuild/0003-Don-t-overwrite-source-build-s-MS.NETCore.Compilers-.patch | ![cp] Fixed upstream | Flow | Incorporate | Repo |  | 
nuget-client/0001-Update-Reference-Assemblies-package-to-get-net472-ve.patch | ![ot] Working with Fernando | Build | Incorporate | Repo |  | https://github.com/NuGet/Home/issues/8214
nuget-client/0002-use-netcoreapp2.1-to-match-netstandard.patch | ![cp] Removed | One-off | Remove | source-build |  | 
nuget-client/0003-Add-roslyn-tools-restore-source-back-to-NuGet.Config.patch | ![ns] No action | ToolCompat | Remove | source-build |  | 
roslyn/0001-Don-t-append-description-from-source-information-bec.patch | ![pl] Needs SourceLink uptake | Build | Incorporate | source-build | | https://github.com/dotnet/source-build/issues/1075
roslyn/0002-Add-repository-properties-for-new-SDK-warning.patch | ![cp] No longer needed | ToolCompat | Remove | source-build |  | 
sdk/0001-Upgrade-to-netcoreapp2.1.patch | ![ot] In PR | ToolCompat | Unknown | source-build |  | https://github.com/dotnet/sdk/issues/3317
sdk/0002-Add-missing-PlatformAbstractions-reference.patch | ![pl] Nick believes unneeded | Bug | Incorporate | source-build |  | 
sdk/0003-Consolidate-versions.patch | ![pl] Nick believes unneeded | Coherence | Incorporate | source-build |  | 
templating/0001-Don-t-build-test-projects-when-building-from-source.patch | ![ot] Being worked on | ProjRemoval | Incorporate | Repo |  | https://github.com/dotnet/templating/issues/1927
templating/0002-Fix-casing-in-template-projects.patch | ![cp] Fixed upstream | Bug | Incorporate | Repo |  | 
templating/0003-Use-source-built-version-of-Newtonsoft.Json.patch | ![ot] Talking about correct fix | Flow | Incorporate | Repo |  | 
toolset/0001-Exclude-test-projects-from-source-build.patch | ![cp] Fixed upstream | ProjRemoval | Incorporate | Repo |  | https://github.com/dotnet/toolset/issues/1178
vstest/0001-Conditionally-remove-uap-from-TargetFramework-and-co.patch | ![pl] Talking about correct fix | Build | Incorporate | Repo |  | https://github.com/microsoft/vstest/issues/2050
vstest/0002-Remove-unneccessary-projects-from-sln.patch | ![pl] Talking about correct fix | ProjRemoval | Incorporate | Repo |  | 
websdk/0001-Remove-test-project.patch | ![cp] Merged | ProjRemoval | Incorporate | Repo |  | https://github.com/aspnet/websdk/issues/702
xliff-tasks/0001-Hardcode-version-until-we-fix-Arcade.patch | ![ot] In progress on our side | Build | SourceBuildFix | source-build |  | https://github.com/dotnet/source-build/issues/1076


**Repo BAR status**

The Build Asset Registry is used to inform source-build about what version of each repo we want to build.  Publishing to BAR is simple for Arcade repos.  We also have an example build that publishes to BAR without Arcade: https://github.com/dotnet/source-build-reference-packages/blob/master/eng/common/templates/job/publish-build-assets.yml.

Not publishing to BAR, not planning to be:
- application-insights (not owned by us and doesn't change often)
- aspnet/common (obsolete)
- newtonsoft-json (not owned by us)

Not on Arcade or BAR:
- VSTest

On Arcade but not BAR:
- xliff-tasks (https://github.com/dotnet/xliff-tasks/issues/114)


<!--StartOfIssuesList-->
[900]: https://github.com/dotnet/source-build/issues/900
[970]: https://github.com/dotnet/source-build/issues/970
[880]: https://github.com/dotnet/source-build/issues/880
[881]: https://github.com/dotnet/source-build/issues/881
[976]: https://github.com/dotnet/source-build/issues/976
[882]: https://github.com/dotnet/source-build/issues/882
[883]: https://github.com/dotnet/source-build/issues/883
[884]: https://github.com/dotnet/source-build/issues/884
[972]: https://github.com/dotnet/source-build/issues/972
[885]: https://github.com/dotnet/source-build/issues/885
[886]: https://github.com/dotnet/source-build/issues/886
[887]: https://github.com/dotnet/source-build/issues/887
[888]: https://github.com/dotnet/source-build/issues/888
[889]: https://github.com/dotnet/source-build/issues/889
[890]: https://github.com/dotnet/source-build/issues/890
[891]: https://github.com/dotnet/source-build/issues/891
[892]: https://github.com/dotnet/source-build/issues/892
[893]: https://github.com/dotnet/source-build/issues/893
[894]: https://github.com/dotnet/source-build/issues/894
[895]: https://github.com/dotnet/source-build/issues/895
[975]: https://github.com/dotnet/source-build/issues/975
[971]: https://github.com/dotnet/source-build/issues/971
[973]: https://github.com/dotnet/source-build/issues/973
[974]: https://github.com/dotnet/source-build/issues/974
[896]: https://github.com/dotnet/source-build/issues/896
[897]: https://github.com/dotnet/source-build/issues/897
[899]: https://github.com/dotnet/source-build/issues/899
[1132]: https://github.com/dotnet/source-build/issues/1132
[1150]: https://github.com/dotnet/source-build/issues/1150
