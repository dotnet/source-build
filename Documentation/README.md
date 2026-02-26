# Source-Build Documentation

## Building .NET from Source

| Document | Description |
|---|---|
| [System Requirements](system-requirements.md) | Hardware, OS, and architecture requirements |
| [Bootstrapping Guidelines](bootstrapping-guidelines.md) | How to acquire or build a bootstrapping SDK |
| [Cross-Building](cross-building.md) | How to build .NET for a target platform using a cross-build container |
| [How to Run a Stage 2 Build](how-to-stage2-build.md) | How to perform a stage 2 source build for validation |
| [Adding Support for a New OS](boostrap-new-os.md) | Steps to bring up .NET on a new operating system |

## Maintaining Source-Build

| Document | Description |
|---|---|
| [CI Platform Coverage Guidelines](ci-platform-coverage-guidelines.md) | Guidelines for which platforms to test in CI |
| [Feature Band Source Building](feature-band-source-building.md) | Guide for Linux distro maintainers on building feature band branches |
| [Packaging and Installation](packaging-installation.md) | How to install or package a source-built .NET SDK |
| [Patching Guidelines](patching-guidelines.md) | How to address build errors and other issues via patches |
| [Package Dependency Flow](package-dependency-flow.md) | How package dependencies are managed within source-build |
| [Eliminating Pre-builts](eliminating-pre-builts.md) | How to eliminate pre-built binaries in .NET repositories |
| [Leak Detection](leak-detection.md) | How the poisoning mechanism works to detect pre-built leaks |
| [Poison Report Format](poison-report-format.md) | How to interpret the poison report |

## Repo Owner's Handbook

See [sourcebuild-in-repos/README.md](sourcebuild-in-repos/README.md) for documentation
aimed at repository owners who participate in source-build.
