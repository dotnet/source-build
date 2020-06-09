# Source-build 5.0 Implementation Plan

To get each repo building with the new source-build 5.0 plan, [Arcade-Powered Source-Build](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/planning/arcade-powered-source-build), the following stages will be accomplished.  Below, the repos are placed in a table representing the earliest dependencies are available and work can begin.  Stages can be completed in parallel, but stage 4 may depend on output from stage 6 from previous repos.  The following graph and table will be used to track progress for each repo.

> ![](img/implementation-plan-graph.png)
> [source (img/implementation-plan-graph.dgml)](img/implementation-plan-graph.dgml)

| Tier | Repo | Owner | (Stage 1)<br>Build from source - 5.0 | (Stage 2)<br>Patch Removal | (Stage 3)<br>Move build params to eng dir | (Stage 4)<br>Input Intermediate Packages Available | (Stage 5)<br>Official build | (Stage 6)<br>Source-build PR validation | (Stage 7)<br>Prebuilt check / enforcement |
| --- | --- | --- | :---: | :---: | :---: | :---: | :---: | :---: | :---: |
| sbrp | Source-build-reference-packages | Dan Seefeldt | ✔️ | ✔️ | | | | | |
| Tools | sourcelink | Tomas Matousek | ✔️ | 4 | | | | | |
| Tools | arcade | Mark Wilkie | ✔️ | 11 | | | | | |
| 1 | application-insights |  | ✔️ | ✔️ | | | | | |
| 1 | aspnet-xdt | Vijay Ramakrishnan | ✔️ | 2 | | | | | |
| 1 | newtonsoft-json | Chris Rummel | ✔️ | ✔️ | | | | | |
| 1 | netcorecli-fsc | Chris Rummel | ✔️ | ✔️ | | | | | |
| 1 | newtonsoft-json901 | Chris Rummel | ✔️ | ✔️ | | | | | |
| 1 | xliff-tasks | William Li | ✔️ | 1 | | | | | |
| 1 | clicommandlineparser | Sarah Oslund | ✔️ | 1 | | | | | |
| 1 | roslyn | Fred Silberberg | ✔️ | 4 | | | | | |
| 2 | linker | Dan Seefeldt | ✔️ | 3 | | | | | |
| 2 | runtime | Jared Parsons | ✔️ | 10 | | | | | |
| 2 | msbuild | Ben Villalobos | ✔️ | 4 | | | | | |
| 2 | NuGet.Client | Fernando Aguilar Reyes | ✔️ | 8 | | | | | |
| 2 | templating | Jose Aguilar | ✔️ | ✔️ | | | | | |
| 3 | extensions | John Luo | ⏱ | 1 | | | | | |
| 3 | aspnetcore-tooling | John Luo | ⏱ | 3 | | | | | |
| 3 | aspnetcore | John Luo | ⏱ | 11 | | | | | |
| 3 | websdk | Vijay Ramakrishnan | ⏱ | 1 | | | | | |
| 4 | sdk | Sarah Oslund |  | 2 + 3(cli) + 3(toolset) | | | | | |
| 4 | vstest | Sarabjot Singh |  | 6 | | | | | |
| 4 | fsharp | Brett Forsgren |  | 2 | | | | | |
| 5 | installer | Sarah Oslund |  | 5 | | | | | |

| Status | Description |
| --- | --- |
| ✔️ | Complete |
| ⏱ | In progress |
| ❗ | At Risk |

## Stage descriptions:
  - **(1) Build from Source 5.0** – Get repo building from source with 5.0 source in dotnet/source-build.
  - **(2) Patch Removal** – Incorporate patches required to build from source into the repo code base.
  - **(3) Move Build Params to Eng Dir** – Move all source-build specific build parameter from `/repos/<reponame>.proj` in source-build repo to repo `/eng` directory.
  - **(4) Input Intermediate Packages Available** – Indicates upstream intermediate packages are available, and work on this repo can begin.
  - **(5) Official build** – Build source-built intermediate packages in official build.
  - **(6) Source-build PR validation** – Add AzDO build jobs to PR validation to ensure build-from-source continues running without avoidable regressions.
  - **(7) Prebuilt check / enforcement** – Add a check to PR validation to ensure that no prebuilts are included when building repo.

## Key Milestone Dates:

| Stage(s) | Start | End |
| --- | :---: | :---: |
| Stage 1 - Build from Source 5.0 | 5/28 | 6/29 |
| Stage 2 - Patch Removal | 6/16 | 7/23 |
| Stages 3-5 - Get into Official Build | 6/25 | 9/16 |
| Stages 6-7 - PR Validation / Prebuilt check | 7/28 | 10/5 |


