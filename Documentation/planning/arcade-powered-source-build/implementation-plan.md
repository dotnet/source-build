# Source-build 5.0 Implementation Plan

To get each repo building with the new source-build 5.0 plan, [Arcade-Powered Source-Build](https://github.com/dotnet/source-build/tree/release/3.1/Documentation/planning/arcade-powered-source-build), the following stages will be accomplished.  Below, the repos are placed in a table representing the earliest dependencies are available and work can begin.  Stages can be completed in parallel, but stage 4 may depend on output from stage 6 from previous repos.  The following graph and table will be used to track progress for each repo.

> ![](img/implementation-plan-graph.png)
> [source (img/implementation-plan-graph.dgml)](img/implementation-plan-graph.dgml)

| Tier | Repo | (Stage 1)<br>Build from source - 5.0 | (Stage 2)<br>Patch Removal | (Stage 3)<br>Move build params to eng dir | (Stage 4)<br>Input Intermediate Packages Available | (Stage 5)<br>Official build | (Stage 6)<br>Source-build PR validation | (Stage 7)<br>Prebuilt check / enforcement |
| --- | --- | :---: | :---: | :---: | :---: | :---: | :---: | :---: |
| sbrp | Source-build-reference-packages | ✔️ | ✔️ | | | | | |
| Tools | sourcelink | ✔️ | 4 | | | | | |
| Tools | arcade | ✔️ | 11 | | | | | |
| 1 | application-insights | ✔️ | ✔️ | | | | | |
| 1 | aspnet-✔️dt | ✔️ | 2 | | | | | |
| 1 | newtonsoft-json | ✔️ | ✔️ | | | | | |
| 1 | netcorecli-fsc | ✔️ | ✔️ | | | | | |
| 1 | newtonsoft-json901 | ✔️ | ✔️ | | | | | |
| 1 | xliff-tasks | ✔️ | 1 | | | | | |
| 1 | clicommandlineparser | ✔️ | 1 | | | | | |
| 1 | roslyn | ✔️ | 4 | | | | | |
| 2 | linker | ✔️ | 3 | | | | | |
| 2 | runtime | ✔️ | 10 | | | | | |
| 2 | msbuild | ✔️ | 4 | | | | | |
| 2 | NuGet.Client | ✔️ | 8 | | | | | |
| 2 | templating |  | ✔️ | | | | | |
| 3 | extensions |  | 1 | | | | | |
| 3 | aspnetcore-tooling |  | 3 | | | | | |
| 3 | aspnetcore |  | 11 | | | | | |
| 3 | websdk |  | 1 | | | | | |
| 4 | sdk |  | 2 + 3(cli) + 3(toolset) | | | | | |
| 4 | vstest |  | 6 | | | | | |
| 4 | fsharp |  | 2 | | | | | |
| 5 | installer |  | 5 | | | | | |

## Stage descriptions:
  - **(1) Build from Source 5.0** – Get repo building from source with 5.0 source in dotnet/source-build.
  - **(2) Patch Removal** – Incorporate patches required to build from source into the repo code base.
  - **(3) Move Build Params to Eng Dir** – Move all source-build specific build parameter from `/repos/<reponame>.proj` in source-build repo to repo `/eng` directory.
  - **(4) Input Intermediate Packages Available** – Indicates upstream intermediate packages are available, and work on this repo can begin.
  - **(5) Official build** – Build source-built intermediate packages in official build.
  - **(6) Source-build PR validation** – Add AzDO build jobs to PR validation to ensure build-from-source continues running without avoidable regressions.
  - **(7) Prebuilt check / enforcement** – Add a check to PR validation to ensure that no prebuilts are included when building repo.
