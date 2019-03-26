## Source-Build Prebuilt Removal Status Overview

Last source-build Build Date: 2019-03-18

Last updated: 2019-03-26

For more detailed information, see: [SourceBuildPrebuiltReport](https://msit.powerbi.com/groups/dc6359c5-e96a-44ce-9d86-0af7fab1c15e/dashboards/73f852d5-4ca7-45d7-8e5c-977c2da3b11c/reports/64e989dd-8072-4d84-8268-140bde0cbc7d/ReportSection4ba78a029c61708d6808)

| Repo/Issue | Owner | Overall Status | # of Patches | # of Prebuilts | Comments |
| :--- | :--- | :--- |  :---: | :---: | --- |
| [application-insights][900] | Sergey Kanzhelev | ![ot] On Track | - | 4 |
| [arcade][970] | Mark Wilke | ![ot] On Track | 6 | 15 |
| [cli][880] | Nick Guerrera | ![ot] On Track | 8 | 19 |
| [clicommandlineparser][976] | Nick Guerrera | ![ot] On Track | 3 | 5 |
| [cli-migrate][881] | Nick Guerrera | ![ot] On Track | 6 | 7 |
| [common][882] | Nate McMaster | ![pl] Planned | - | 3 |
| [coreclr][883] | Russ Keldorph | ![pl] Planned | - | 9 |
| [corefx][884] | Jeremy Barton | ![ns] Not Started | 3 | 26 |
| [core-sdk][972] | Nick Guerrera | ![pl] Planned | 5 | 11 |
| [core-setup][885] | Davis Goodin | ![pl] Planned | 2 | 25 |
| [fsharp][886] | Brett Forsgren | ![ns] Not Started | 7 | 25 |
| [linker][887] | ??? | ![ns] Not Started | 2 | 4 |
| [msbuild][888] | Nick Guerrera | ![ns] Not Started | 4 | 23 |
| [newtonsoft-json][889] | Chris Rummel | ![pl] Planned | 1 | 14 |
| [nuget-client][890] | Rob Relyea | ![ns] Not Started | 4 | 10 |
| [roslyn][891] | Jared Parsons / Fred Silberberg | ![ns] Not Started | 2 | 18 |
| [roslyn-tools][892] | Tomas Matousek | ![cp] Complete | - | - | Repo removed
| [sdk][893] | Nick Guerrera | ![pl] Planned | 1 | 10 |
| [source-build-infra][975] | Dan Seefeldt | ![pl] Planned | - | 6 |
| [standard][894] | Jeremy Barton | ![ns] Not Started | - | 15 |
| templating | Mike Lorbetske | ![cp] Complete | 3 | - | Repo removed
| [Tools][974] | Dan Seefeldt | ![pl] Planned | - | 7 |
| [toolset][973] | Nick Guerrera | ![pl] Planned | 4 | 14 |
| [tools-local tasks][971] | Dan Seefeldt | ![pl] Planned | - | 2 |
| [vstest][896] | Shiva Shankar Thangadurai / Sarabjot Singh | ![ns] Not Started | 2 | 41 |
| [websdk][897] | Mike Lorbetske | ![ns] Not Started | 2 | 10 |
| [xliff-tasks][899] | Tom Meschter | ![pl] Planned | - | 2 |

<br/>

| Status   | Description |
| -------- | ----------- |
| ![ns] Not Started | Team has not started on prebuilts |
| ![pl] Planned | Prebuilts have been categorized and issues have been logged to remove |
| ![ot] On Track | Engineers are working through issues to remove prebuilts |
| ![ar] At Risk  | Prebuilt removal tasks not on track for completion or blocked |
| ![cp] Complete | All prebuilts removed |

[ns]: https://img.icons8.com/office/16/000000/medium-risk.png
[pl]: https://img.icons8.com/office/16/000000/gantt-chart.png
[ot]: https://img.icons8.com/office/16/000000/gps-device.png
[ar]: https://img.icons8.com/office/16/000000/high-risk.png
[cp]: https://img.icons8.com/office/16/000000/checked.png

**Prebuilts**

Prebuilts are dependencies that a repo has on binary files that are not built from source.  All packages included in the distro are built by the distro and the source requirements are inclusive of build tools and build dependencies. The default position for inclusion in a distro is no pre-built binaries though there are proper exceptional cases to bootstrap builds.

**Patches**

Patches are created in source-build when a repo's code doesn't build as-is. Patches are required to keep source-build moving forward and building on new product builds. As patches are created, issues are opened in the corresponding repo to incorporate the code and remove the patch

[startOfIssuesList]: https://dummy
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
[975]: https://github.com/dotnet/source-build/issues/975
[971]: https://github.com/dotnet/source-build/issues/971
[973]: https://github.com/dotnet/source-build/issues/973
[974]: https://github.com/dotnet/source-build/issues/974
[896]: https://github.com/dotnet/source-build/issues/896
[897]: https://github.com/dotnet/source-build/issues/897
[899]: https://github.com/dotnet/source-build/issues/899
