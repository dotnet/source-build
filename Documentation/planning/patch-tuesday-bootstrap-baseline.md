# Proposal: Patch Tuesday source-build baselines

## Summary

Replace the N-1 source-build policy with a monthly bootstrap baseline. Instead
of requiring the SDK from the immediately preceding release, each SDK feature
band advances its baseline on Patch Tuesday. Out-of-band (OOB) releases
normally use the latest Patch Tuesday baseline.

No OOB release is required to build a later release. The release notes for
every release list the exact bootstrap inputs: the source-built SDK and the
previously source-built (PSB) package archive.

## Scope

This proposal applies to servicing releases for supported .NET versions.
It does not change the bootstrap procedures for new major versions, new SDK
feature bands, or new platforms.

## Motivation

The [current source-build guidance](../sourcebuild-in-repos/build-info.md) says a release should build with the
immediately preceding SDK. When an OOB is the preceding release in its SDK
feature band, applying that rule makes the OOB a prerequisite for the next
build. With weekly releases, that adds work for both the .NET release team and
distro maintainers:

- The .NET release team has to switch to new bootstrap inputs and validate
  each release with them, even if the build needs no new tools.
- Distro maintainers may have to build an OOB they don't plan to ship just to
  get the SDK and package archive for the next release.

A monthly baseline lets maintainers keep building with tools they built from
source without having to build every intervening OOB. The .NET release team
can validate several releases without changing the bootstrap inputs each time.

## Which inputs each release uses

The following rules apply within each supported SDK feature band:

- **Patch Tuesday:** Build with the SDK and PSB package archive from the
  preceding Patch Tuesday release. The new outputs become the baseline for the
  next Patch Tuesday release and the default for subsequent OOBs.
- **OOB:** Use the latest Patch Tuesday baseline by default. If an OOB is scheduled to ship
  too soon after Patch Tuesday to build and validate it with the new inputs,
  it may keep the previous baseline, provided Microsoft validated the build
  with that baseline. A change in ship date alone does not require switching
  inputs.

Use the compatible SDK and PSB package archive listed in the release notes,
even for a rebuild. The ship date does not determine which versions to use.

## Example: January and February releases

These releases are all in the same SDK feature band.

| Release to build | Release that supplies the bootstrap inputs |
| --- | --- |
| January Patch Tuesday | December Patch Tuesday |
| January OOB 1 | January Patch Tuesday |
| January OOB 2 | January Patch Tuesday |
| February Patch Tuesday | January Patch Tuesday |
| February OOB 1 (validated before February Patch Tuesday) | January Patch Tuesday |
| February OOB 2 | February Patch Tuesday |

If you built January's Patch Tuesday release, you can build January OOB 2
without building January OOB 1. You can also build February's Patch Tuesday
release without building either January OOB.

Microsoft builds and validates February OOB 1 with January's inputs before
February Patch Tuesday. Because the OOB ships shortly after February Patch
Tuesday, Microsoft may not have enough time to rebuild and validate it with
February's inputs. In this example, its release notes list the SDK and PSB
archive versions from January Patch Tuesday.

February OOB 2 uses February's inputs. It does not depend on February OOB 1.

Skipping an OOB as a build prerequisite is not a recommendation to defer
security updates.

## What this means for maintainers

Keep the SDK and complete PSB package archive from each Patch Tuesday build
until you have the next baseline and no supported build still needs the old
inputs. An OOB can still need them after the next Patch Tuesday ships. Keep
the Patch Tuesday inputs even if you ship an OOB in the meantime.

## Validation and release notes

Before shipping a release, Microsoft must validate source-build with the inputs
listed in its release notes. OOBs can share a baseline, but each OOB still needs
its own validation. Patch Tuesday releases must pass with the preceding Patch
Tuesday inputs, without relying on any intervening OOB.

An OOB must not depend on anything available only in another OOB. If a change
requires newer bootstrap tools, coordinate it with the switch to a new Patch
Tuesday baseline.

The release notes name the Patch Tuesday release that supplied the inputs
and list the exact SDK and PSB archive versions. Those versions must match
the pins in the Virtual Monolithic Repository (VMR).

## Adoption

To adopt this policy, the .NET release team must update the documented N-1
guarantee and configure release builds and CI to use the declared inputs.
The team must also tell distro maintainers which release first follows the
new policy and which inputs it uses.