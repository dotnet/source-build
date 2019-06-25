## Source-Build Prebuilt Removal Status Overview

Last source-build Build Date: 2019-06-25

Last updated: 2019-06-25

For more detailed information, see: [SourceBuildPrebuiltReport](https://msit.powerbi.com/groups/dc6359c5-e96a-44ce-9d86-0af7fab1c15e/dashboards/73f852d5-4ca7-45d7-8e5c-977c2da3b11c/reports/64e989dd-8072-4d84-8268-140bde0cbc7d/ReportSection4ba78a029c61708d6808)

<!--TrackingTable-->
| Repo/Issue | Owner | Overall Status | # of Patches | # of Prebuilts | Comments |
| :--- | :--- | :--- |  :---: | :---: | --- |
| [ApplicationInsights-dotnet][900] | Sergey Kanzhelev | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [arcade][970] | Mark Wilke | ![ot] On Track | 2 | 10 |
| [cli][880] | Nick Guerrera | ![bn] Bounced | 8 | 2 | 
| [cliCommandLineParser][976] | Nick Guerrera | ![cp] Complete | 3 | - | All direct-dependency prebuilts removed.
| [cli-migrate][881] | Nick Guerrera | ![cp] Complete | - | - | Repo removed
| [common][882] | Nate McMaster | ![cp] Complete | - | - | All direct-dependency prebuilts removed.
| [coreclr][883] | Russ Keldorph | ![ot] On Track | 6 | 1 |
| [corefx][884] | Eric St. John | ![ot] On Track | 2 | 8 |
| [core-sdk][972] | Nick Guerrera | ![ot] On Track | 6 | 4 |
| [core-setup][885] | Davis Goodin | ![ot] On Track | 5 | 9 |
| [linker][887] | Dan Seefeldt | ![ot] On Track | 4 | 1 |
| [msbuild][888] | Nick Guerrera | ![ot] On Track | 1 | 5 |
| [Newtonsoft.Json][889] | Chris Rummel | ![bn] Bounced | - | 1 | 
| [NuGet.Client][890] | Rob Relyea | ![ot] On Track | 2 | 5 |
| [roslyn][891] | Jared Parsons / Fred Silberberg | ![ot] On Track | 2 | 12 |
| [roslyn-tools][892] | Tomas Matousek | ![cp] Complete | - | - | Repo removed
| [sdk][893] | Nick Guerrera | ![ot] On Track | 2 | 3 |
| [source-build-infra][975] | Dan Seefeldt | ![ot] On Track | - | 4 |
| [standard][894] | Eric St. John | ![cp] Complete | 1 | - | All direct-dependency prebuilts removed.
| [templating][895] | Vijay Ramakrishnan | ![ot] On Track | 2 | 1 |
| [Tools][974] | Dan Seefeldt | ![ot] On Track | - | 4 |
| [toolset][973] | Nick Guerrera | ![ot] On Track | 2 | 4 |
| [tools-local tasks][971] | Dan Seefeldt | ![ot] On Track | - | 1 |
| [visualfsharp][886] | Brett Forsgren | ![ot] On Track | - | 3 |
| [vstest][896] | Shiva Shankar Thangadurai / Sarabjot Singh | ![pl] Planned | 3 | 6 |
| [websdk][897] | Vijay Ramakrishnan | ![ot] On Track | 1 | 5 |
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
arcade | 2b0830b8cc561f327e4e1b10b6e21a188b9ecee6 | 2019-06-13
cli | 99151dfa08364242d93c861568abaf044e134d8c | 2019-06-04
cliCommandLineParser | 0e89c2116ad28e404ba56c14d1c3f938caa25a01 | 2019-04-08
common | 6e37cdfe96ac8b06a923242120169fafacd720e6 | 2018-11-02
core-sdk | be3f0c1a03f80492d45396c9f5b855b10a8a0b79 | 2019-06-07
core-setup | 730e8c6700dacfcb2e68a69227233010407edc3d | 2019-06-24
coreclr | 48431cc037776ca359de36bf71bda8c154cc2aa9 | 2019-05-09
corefx | a28176b5ec68b6da1472934fe9493790d1665cae | 2019-05-14
linker | 15b5a5f682a3f3345f473b655d51940bdd8fd1a8 | 2019-05-31
msbuild | d635043bd5f9f856422369fb2d222ee8f1ea57b7 | 2019-05-28
Newtonsoft.Json | cac0690ad133c5e166ce5642dc71175791404fad | 2019-06-19
NuGet.Client | 27af96bdb7ba8d6d7ea9ad53fc76cd1d1aa80703 | 2019-03-29
roslyn | 58a4b1e79aea28115e66b06f850c83a3f1fcb6d3 | 2019-05-31
sdk | 9a92095d8ad0112291573385dc8f67adfdfe9322 | 2019-06-03
source-build-reference-packages | 6831be6a0dd4d03316da79d5da96657e50e51582 | 2019-06-20
standard | 034dbc3c88aa1663fbbc6a22a3563c8a2c99d604 | 2019-05-31
templating | 3f2e65dd99395dfb5741d943158243bc77c4ac80 | 2019-06-03
toolset | bb3ce585b563e3c6e647923b30e07308dca0fd19 | 2019-06-07
visualfsharp | 42526fe359672a05fd562dc16a91a43d0fe047a7 | 2019-05-03
vstest | ea406627f919daa1d8da7daabe2d1f6619d2ad72 | 2019-03-04
websdk | a6579163ec0020f52efa2b2bc15803be46a1d034 | 2019-06-07
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
