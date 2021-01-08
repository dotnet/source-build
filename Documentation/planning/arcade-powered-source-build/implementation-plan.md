# Arcade-powered source-build implementation plan

To get each repo building with the new source-build sustainability plan, [Arcade-Powered Source-Build](./README.md), each repo will go through several stages. Some stages have dependencies on upstream repos, so this process will be completed in dependency order with some exceptions.

Below, the repo status is in a graph to show the dependencies and make it easy to tell which repos are ready to work on. There's also a table, for searchable and more detailed status. These will both be kept up to date.

> ![](img/implementation-plan-graph.svg)  
> [source (img/implementation-plan-graph.dot)](img/implementation-plan-graph.dot)

| Tier | Repo | Owner | (Stage 1)<br>Build from source - 5.0 | (Stage 2)<br>Input intermediate packages available | (Stage 3)<br>Merge patches & local build infra | (Stage 4)<br>Merge CI, generate official build | (Stage 5)<br>Validate & merge dev branch into 5.0 | (Stage 6)<br>Prebuilt baseline enforcement |
| --- | --- | --- | :---: | :---: | :---: | :---: | :---: | :---: |
| sbrp | Source-build-reference-packages | [Dan Seefeldt](https://github.com/dseefeld) | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | |
| Tools | sourcelink | [Tomas Matousek](https://github.com/tmat) | ✔️ | ✔️ | ✔️ | | | |
| Tools | arcade | [Mark Wilkie](https://github.com/markwilkie) | ✔️ | | | | | |
| 1 | *cssparser*<sup>1</sup> | ? | ✔️ | ✔️ | | | | |
| 1 | *humanizer*<sup>1</sup> | ? | ✔️ | ✔️ | | | | |
| 1 | *netcorecli-fsc*<sup>1</sup> | [Chris Rummel](https://github.com/crummel) | ✔️ | ✔️ | | | | |
| 1 | *newtonsoft-json*<sup>1</sup> | [Chris Rummel](https://github.com/crummel) | ✔️ |  | | | | |
| 1 | *newtonsoft-json901*<sup>1</sup> | [Chris Rummel](https://github.com/crummel) | ✔️ | ✔️ | | | | |
| 1 | application-insights | [Reiley Yang](https://github.com/reyang) | ✔️ | ✔️ | | | | |
| 1 | aspnet-xdt | [Vijay Ramakrishnan](https://github.com/vijayrkn) | ✔️ | | | | | |
| 1 | clicommandlineparser | [Sarah Oslund](https://github.com/sfoslund) | ✔️ | | | | | |
| 1 | command-line-api | [?](https://github.com/) | ✔️ | | | | | |
| 1 | diagnostics | ? | ✔️ | ✔️ | | | | |
| 1 | roslyn | [Fred Silberberg](https://github.com/333fred) | ✔️ | | | | | |
| 1 | symreader | ? | ✔️ | | | | | |
| 1 | test-templates | ? | ✔️ | | | | | |
| 1 | xliff-tasks | [Mark Wilkie](https://github.com/markwilkie) | ✔️ | ✔️ | | | | |
| 2 | linker | [Dan Seefeldt](https://github.com/dseefeld) | ✔️ | ✔️ | | | | |
| 2 | msbuild | [Ben Villalobos](https://github.com/BenVillalobos) | ✔️ | | | | | |
| 2 | NuGet.Client | [Fernando Aguilar Reyes](https://github.com/dominoFire) | ✔️ | | | | | |
| 2 | runtime | [Jared Parsons](https://github.com/jaredpar) | ✔️ | | | | | |
| 2 | templating | [Vlada Shubina](https://github.com/vlada-shubina) | ✔️ | | | | | |
| 3 | roslyn-analyzers | [Jonathon Marolf](https://github.com/jmarolf) | ✔️ | | | | | |
| 4 | aspnetcore | [John Luo](https://github.com/JunTaoLuo) | ✔️ | | | | | |
| 4 | websdk | [Vijay Ramakrishnan](https://github.com/vijayrkn) | ✔️ | | | | | |
| 5 | fsharp | [Brett Forsgren](https://github.com/brettfo) | ✔️ | | | | | |
| 5 | sdk | [Sarah Oslund](https://github.com/sfoslund) | ✔️ | | | | | |
| 5 | vstest | [Jakub Jares](https://github.com/nohwnd) | ✔️ | | | | | |
| 6 | installer | [Sarah Oslund](https://github.com/sfoslund) | ✔️ | | | | | |

| Status | Description |
| --- | --- |
| ✔️ | Complete |
| ⏱ | In progress |
| ❗ | At Risk |

> <sup>1</sup> — Source will be maintained in central dotnet/source-build repo. It is not feasible to add full arcade-powered source-build infrastructure in some cases.

## Stage descriptions:
  - **(1) Build from source 5.0**
    - Get repo building from source with 5.0 source in dotnet/source-build.
  - **(2) Input intermediate packages available**
    - Indicates upstream intermediate packages are available, and work on this repo can begin.
  - **(3) Merge patches & local build infra**
    - All source-build specific build parameters from `/repos/<reponame>.proj` in source-build repo moved to repo `/eng` directory.
    - Repo-specific patches are incorporated.
    - If necessary, create a dev branch to manage changes.
  - **(4) Merge CI, generate official build**
    - PR validation and Official Build CI jobs added to repo and run to generate intermediate package for repo.
  - **(5) Validate & merge dev branch into 5.0**
    - Build logs and intermediate package of an official build are reviewed and validated by source-build team.
    - Source-build changes are live for the repo in the `main`/`master` branch.
    - If a dev branch was created, it is merged into `main`/`master`.
    - The changes are ported to the branch for `5.0`.
  - **(6) Prebuilt baseline enforcement**
    - Prebuilt check baseline is narrowed down to necessary packages.
    - PR validation builds fail if new prebuilts are introduced.
