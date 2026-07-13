# Debugging a Source-Built .NET SDK

A goal of source-build is that a .NET SDK built from source provides the same
debugging, profiling, and tracing experience as the SDK that Microsoft ships.
Developers should be able to step into framework code, symbolize stack traces,
collect traces, and analyze crash dumps regardless of who built their SDK.

This document explains:

* [What a source build produces](#what-a-source-build-produces) for debugging
  (sources, binaries, and symbols).
* [How to verify](#verifying-the-debugging-artifacts) that those artifacts are
  correct — useful for anyone building or packaging .NET from source.
* [How end users consume](#using-sources-binaries-and-symbols) the sources,
  binaries, and symbols when debugging, profiling, and tracing.
* [Known issues](#known-issues).
* [Platform support](#platform-support) for the diagnostics tools.

> **Audience.** The first half of this document is aimed at people who build and
> package .NET from source (for example, Linux distribution maintainers and the
> source-build team). The second half is guidance you can pass on to the end
> users who consume your build.

## Background: the three things a debugger needs

To give a good debugging experience, three kinds of artifacts have to line up:

| Artifact | Managed code (C#/IL) | Native code (C/C++) |
|---|---|---|
| **Binaries** | `*.dll` assemblies | `*.so`/`*.dylib` shared objects (e.g. `libcoreclr.so`) |
| **Symbols** | Portable PDBs (`*.pdb`) | DWARF debug info |
| **Sources** | Located via [Source Link](https://github.com/dotnet/sourcelink) metadata embedded in the PDB | Located via DWARF source paths |

A source-built SDK has to produce all three for both managed and native code, in
a way that lets the standard .NET diagnostics tools (the VS Code C# debugger,
`lldb` + SOS, `dotnet-dump`, etc) find them.

## What a source build produces

The actual build is performed by the [.NET
VMR](https://github.com/dotnet/dotnet) (`dotnet/dotnet`). The notes below
describe what that build emits today.

### Managed binaries and symbols

Managed assemblies are built with portable PDBs. During the build, every repo's
PDBs are collected (the `CopyRepoSymbols` target in the VMR) and packaged into
two symbol archives that are emitted next to the SDK tarball in
`artifacts/assets/Release/`:

| Archive | Contents |
|---|---|
| `dotnet-symbols-sdk-<version>-<rid>.tar.gz` | PDBs for the binaries in an installed SDK — the SDK tooling plus the .NET and ASP.NET Core runtimes it includes. |
| `dotnet-symbols-all-<version>-<rid>.tar.gz` | PDBs for every binary the build produces — a superset that also covers binaries shipped only in NuGet packages and other build outputs not present in an install. |

In these names, `<version>` is the SDK version and `<rid>` is the runtime
identifier.

The two archives differ in both scope and layout.

`dotnet-symbols-sdk` holds a PDB for every binary that lands in an installed SDK,
and only those. The archive mirrors the install layout — for every
`shared/Microsoft.NETCore.App/<version>/Some.Assembly.dll` there is a matching
`Some.Assembly.pdb` at the same relative path — so extracting it over an install
drops each PDB next to its DLL.

`dotnet-symbols-all` is a superset of `dotnet-symbols-sdk`: the raw collection of
every PDB produced across all of the product's repositories, organized by source
repository and build-output (`obj`) path rather than by install layout. Beyond
what an install contains, it therefore also includes symbols for binaries that
ship only inside NuGet packages (such as runtime packs and out-of-band libraries)
and for internal build outputs that are never laid into an SDK. Use it when you
need symbols for something that is not part of the installed SDK.

Because it is the complete set, `dotnet-symbols-all` is also embedded inside
`Private.SourceBuilt.Artifacts.*.tar.gz` so that non-1xx feature-band builds,
which only redistribute the shared runtime but do not rebuild it, still have
access to runtime symbols.

PDBs are **not** shipped inside the main SDK tarball by default; they are
delivered separately through the archives above. This lets you decide how to
package them (for example, in a distro `-dbg` symbols subpackage).

### Native binaries and symbols

Native shared objects (such as `libcoreclr.so`, `libclrjit.so`, and
`libmscordaccore.so`) are emitted with their **DWARF debug info embedded** in
the binary. Source-build does **not** strip the binaries and does **not** split
the debug info into separate `.debug`/`.dbg` files, so there is no
`.gnu_debuglink`. The runtime's native binaries also carry an ELF build-id,
which `debuginfod` and symbol servers use to match a binary to its debug info.

If your packaging policy requires stripped binaries with separate debug-info
files, perform the split yourself using your normal tooling (for example,
`objcopy --only-keep-debug` / `objcopy --add-gnu-debuglink`, or your distro's
`find-debuginfo` step).

### Source Link

Managed PDBs contain [Source Link](https://github.com/dotnet/sourcelink)
metadata that maps compiled code back to its exact source on GitHub
(`https://raw.githubusercontent.com/<org>/<repo>/<commit>/...`). This is what
lets a debugger download the precise runtime/SDK sources when you step into
framework code.

Source Link metadata is produced by the `Microsoft.SourceLink.GitHub` package
that the product repositories reference. So that the embedded source paths are
deterministic rather than machine-specific, the VMR's official builds run with
`ContinuousIntegrationBuild=true` (set by the `-ci` build switch), which enables
`DeterministicSourcePaths` and the compiler `PathMap`. The result is:

* The Source Link document table in the PDB maps source files to GitHub URLs.
* Source paths are normalized to a deterministic root (`/_/...`) instead of an
  absolute build path such as `/builddir/build/BUILD/...`.

> **Native binaries do not carry Source Link.** Native `.so` files embed
> build-time source paths in their DWARF debug info rather than Source Link URLs.
> Stepping into native runtime code from sources therefore requires
> the matching source tree locally, or a `debuginfod` server (see
> [Known issues](#known-issues)).

## Verifying the debugging artifacts

If you build or repackage .NET from source, you can verify the debugging story
before you ship. The VMR runs automated tests for this, and you can also check
the output by hand.

### Automated tests in the VMR

These tests live in
[`test/Microsoft.DotNet.SourceBuild.Tests`](https://github.com/dotnet/dotnet/tree/main/test/Microsoft.DotNet.SourceBuild.Tests)
and run as part of the source-build test pass. They are the authoritative,
regression-protected checks:

| Test | What it verifies |
|---|---|
| `DebugTests.SourceBuiltSdkContainsNativeDebugSymbols` | Every 64-bit ELF binary in the SDK has `.debug_info` and `.debug_abbrev` DWARF sections (via `eu-readelf -S`) and no unexpected `.gnu_debuglink`. |
| `SymbolsTests.VerifySdkSymbols` | Every SDK file that should have a PDB has a matching PDB in `dotnet-symbols-sdk-*.tar.gz`. |
| `SourcelinkTests.VerifySourcelinks` | Runs `dotnet-sourcelink test --offline` over every PDB in `dotnet-symbols-all-*.tar.gz` to confirm Source Link metadata is well-formed. Runs in official builds only. |
| `SourceBuiltArtifactsTests.EnsureNoSymbolsNupkgs` | Confirms `*.symbols.nupkg` files are not bundled into `Private.SourceBuilt.Artifacts` (symbols ship via the tarballs instead). |

### Manual verification

You can run the same kinds of checks against an installed or extracted SDK. The
examples below assume the SDK is at `$DOTNET_ROOT`. PDBs are not installed next
to their binaries by default, so the managed examples assume you have first
overlaid the symbols — for example, by extracting `dotnet-symbols-sdk-*.tar.gz`
over `$DOTNET_ROOT`, which places each PDB beside its DLL.

**Managed Source Link** — verify that a PDB points at real sources. The
`dotnet-sourcelink` tool reads the Source Link metadata out of a PDB or assembly.

It ships as a `dotnet-sourcelink*.nupkg` package inside the `Private.SourceBuilt.Artifacts.*.tar.gz`
archive (written under `artifacts/assets/`), and it is the same build that the
automated `SourcelinkTests.VerifySourcelinks` check runs. Extract and run it as
shown below.

```bash
# Path to the source-built artifacts archive produced by the build.
ARTIFACTS=Private.SourceBuilt.Artifacts.<version>.<rid>.tar.gz

# Pull the dotnet-sourcelink package out of the archive, unzip the .nupkg, and
# locate the tool binary.
mkdir -p sourcelink-tool
tar xzf "$ARTIFACTS" -C sourcelink-tool --wildcards '*dotnet-sourcelink*.nupkg'
nupkg=$(find sourcelink-tool -name 'dotnet-sourcelink*.nupkg' | head -1)
unzip -o "$nupkg" -d sourcelink-tool/extracted
tool=$(find sourcelink-tool/extracted -name dotnet-sourcelink.dll | head -1)

# Print the embedded Source Link JSON for inspection.
dotnet "$tool" print-json \
    "$DOTNET_ROOT/shared/Microsoft.NETCore.App/<version>/System.Private.CoreLib.pdb"

# Validate the document table.
dotnet "$tool" test --offline \
    "$DOTNET_ROOT/shared/Microsoft.NETCore.App/<version>/System.Private.CoreLib.pdb"
```

For a healthy managed PDB, `print-json` prints a document map such as
`{"documents":{"/_/*":"https://raw.githubusercontent.com/dotnet/dotnet/<commit>/*"}}`,
and `test --offline` reports `File '...' validated.`.

`--offline` verifies only that every document in the PDB maps to a Source Link
URL — that the table is complete and well-formed — without contacting the server.
Omitting `--offline` additionally downloads each referenced document and
checksum-compares it against the PDB, which succeeds only when the commit is
public.

**Managed PDB presence** — confirm a symbol file exists for an assembly.
`dotnet-symbols-sdk-*.tar.gz` follows the SDK's install layout, so each PDB sits
at the same relative path as its DLL. (`dotnet-symbols-all-*.tar.gz` instead
groups PDBs by source repository and build-output path.)

```bash
# The SDK symbols archive mirrors the SDK layout, so for an installed
# sdk/<version>/<Assembly>.dll there is a matching <Assembly>.pdb at the same
# relative path. Confirm a given assembly's PDB is present in the archive:
tar tzf dotnet-symbols-sdk-<version>-<rid>.tar.gz | grep -i '<Assembly>\.pdb$'
```

**Native debug info** — confirm DWARF is present in a shared object:

```bash
# Look for .debug_info / .debug_abbrev sections.
eu-readelf -S "$DOTNET_ROOT/shared/Microsoft.NETCore.App/<version>/libcoreclr.so" | grep debug
# or, without elfutils:
objdump -h "$DOTNET_ROOT/shared/Microsoft.NETCore.App/<version>/libcoreclr.so" | grep debug

# Confirm the binary has a build-id (debuginfod and symbol servers key off this).
file "$DOTNET_ROOT/shared/Microsoft.NETCore.App/<version>/libcoreclr.so"
```

The source build's own output keeps embedded DWARF, so these sections are
present. A distribution that repackages .NET may strip its binaries instead.
On a stripped binary the `.debug_*` sections are absent; depending on how the
distro split the debug info you may instead see a `.gnu_debuglink` section
(and, on Fedora, `.gnu_debugdata`), while `file` reports the binary as
`stripped`.

## Using sources, binaries, and symbols

Guidance for the end users of a source-built SDK — people who did not build the
SDK themselves but need to debug, profile, or trace applications running on it.
The following sections cover where to get symbols, how to step into framework
sources, and how to analyze dumps and live processes.

### Getting symbols

Unlike Microsoft's build, the symbols for a source-built SDK are **not** on
Microsoft's symbol servers (`msdl.microsoft.com`). Symbols come from whoever
built the SDK:

* **Managed PDBs** — install the managed-symbols package your SDK provider
  ships. On Fedora/RHEL and Ubuntu this is `dotnet-runtime-dbg-<version>`, which
  contains the PDB files (availability varies by distro release and .NET
  version). If you built the SDK yourself, the PDBs are in the
  `dotnet-symbols-all` (or `dotnet-symbols-sdk`) archive that build produced.
  Either way, placing a PDB next to its DLL lets tools find it automatically.
* **Native debug info** — if your distribution strips native binaries, install
  the matching native debug-info package: on Fedora/RHEL use
  `dnf debuginfo-install dotnet-runtime-<version>` (which pulls the `-debuginfo`
  RPM), and on Debian/Ubuntu install the corresponding `-dbgsym` package. Many
  distributions also expose native debug info through a
  [`debuginfod`](https://sourceware.org/elfutils/Debuginfod.html) server: `gdb`
  consults `DEBUGINFOD_URLS` automatically, and `lldb` does too when it
  was built with debuginfod support.

### Stepping into framework sources

With Source Link working, a debugger can fetch the exact .NET sources when you
step into framework code. In the VS Code C# experience this requires disabling
*Just My Code* (`"justMyCode": false`) and having network access to GitHub. With
*Just My Code* enabled (the default), the framework is treated as a black box and
no sources are needed.

### Analyzing dumps and live processes (SOS, dotnet-dump, lldb)

`dotnet-dump` and SOS (under `lldb`) work against a source-built runtime on the
architectures where SOS is supported (see [Platform support](#platform-support)).
The basic flow is the same as on a Microsoft-built .NET SDK — collect a dump and
analyze it with SOS commands:

```bash
dotnet-dump collect -p <pid> -o core.dmp   # or start from an existing core file
dotnet-dump analyze core.dmp               # then, e.g.: clrstack, clrthreads, dumpheap -stat
```

A few things specific to a source-built runtime are worth knowing:

* The data access component (`libmscordaccore.so`) must come from the **same
  build** as the runtime being debugged. It ships in the runtime package, so
  analyze dumps with the matching runtime installed.
* **Managed symbols resolve automatically** when the portable PDBs sit next to
  the assemblies. SOS reads them directly, so `clrstack` reports managed frames
  with file and line numbers without any symbol server configured. Make sure the
  PDBs are present — they ship in the `dotnet-symbols-*` tarballs and in the
  distro `*-dbg` symbols package (see [Getting symbols](#getting-symbols)).
* **Do not rely on a symbol server for a source build.** Microsoft's server
  (`setsymbolserver -ms`) has no symbols for it, and the `loadsymbols` command
  only downloads *native* symbols, which are not published anywhere for a source
  build — obtain native debug info from your distro instead. If your symbol files
  live somewhere other than the module paths recorded in the dump, point SOS at a
  local directory:

  ```text
  (lldb) setsymbolserver -directory /usr/lib64/dotnet/shared/Microsoft.NETCore.App/<version>/
  ```

### Profiling and tracing

The EventPipe-based tools (`dotnet-trace`, `dotnet-counters`, and
`dotnet-gcdump`) are managed-side tools built on the runtime's EventPipe
infrastructure, so they behave identically to a Microsoft-built .NET (see the
[.NET diagnostics tools overview](https://learn.microsoft.com/dotnet/core/diagnostics/)) and work even on architectures where SOS is unavailable. Two
source-build-relevant caveats: `dotnet-gcdump` heap-dump support is more
limited on Mono, and `dotnet-trace convert` does not run on big-endian
s390x (see [Platform support](#platform-support)).

## Known issues

* **Native binaries do not carry Source Link.** Native `.so` DWARF embeds
  build-time source paths instead of Source Link URLs — a property of
  native/DWARF debugging generally, not a source-build regression. To step into
  native runtime code, check out the matching `dotnet/dotnet` commit locally and
  map the source path in your debugger (or use a `debuginfod` server).
* **`dotnet-symbol` cannot fetch distro or source-build symbols.** It only
  downloads from Microsoft's servers
  ([dotnet/diagnostics#1506](https://github.com/dotnet/diagnostics/issues/1506)).
  Obtain symbols from your distribution's debug packages or a `debuginfod`
  server instead; `dotnet-symbol --server-path <url>` can target an explicit
  symbol server.
* **Some files legitimately lack PDBs** (for example, certain MSBuild ref
  assemblies).
  [dotnet/source-build#5219](https://github.com/dotnet/source-build/issues/5219)
  tracks the remaining gaps and the corresponding test exclusions.

## Platform support

The architectures Microsoft builds with CoreCLR (`x64`, `arm64`, `arm`) have the
fullest diagnostics support. Architectures brought up only through source-build
vary:

* **`ppc64le` and `s390x`** run the **Mono** runtime rather than CoreCLR. Most of
  the diagnostics tooling (SOS, the DAC, `dotnet-dump` analysis) is built around
  CoreCLR and is therefore unavailable there. EventPipe-based tools still work.
* **`riscv64` and `loongarch64`** run CoreCLR, so EventPipe tools, managed
  Source Link, and the open-source `netcoredbg` debugger work. Microsoft does
  not publish the SOS/`dotnet-dump` native binaries for these architectures,
  so `dotnet-sos install` fails with "Operating system or architecture not
  supported" — the same error as on the Mono platforms.

The matrix below reflects the general state for a source-built runtime.

| Tool | x64 / arm64 / arm | riscv64 / loongarch64 | ppc64le / s390x (Mono) | Notes |
|---|---|---|---|---|
| `dotnet-counters` | ✅ | ✅ | ✅ | EventPipe-based. |
| `dotnet-gcdump` | ✅ | ✅ | ⚠️ | Uses EventPipe; GC heap-dump support can be more limited on Mono. |
| `dotnet-trace` collect | ✅ | ✅ | ✅ | EventPipe-based. |
| `dotnet-trace convert` | ✅ | ✅ | ⚠️ s390x | `TraceEvent` is little-endian only; convert on a little-endian machine ([dotnet/diagnostics#4506](https://github.com/dotnet/diagnostics/issues/4506)). |
| `dotnet-dump` | ✅ | ⚠️ | ❌ | `collect` works wherever CoreCLR runs (runtime `createdump`); `analyze` needs SOS (next row). |
| SOS (in `lldb` / `dotnet-dump analyze`) | ✅ | ❌ | ❌ | Native SOS binaries are published only for `x64`/`arm64`/`arm`, so `dotnet-sos install` fails on `riscv64`/`loongarch64` and Mono. |
| VS Code C# debugger (`vsdbg`) | ✅ (proprietary) | ❌ | ❌ | `vsdbg` is a closed-source Microsoft component shipped only for Microsoft-supported architectures (`x64`/`arm64`/`arm`). |
| `netcoredbg` (open-source) | ✅ | ✅ | ❌ | Samsung's open-source debugger; targets CoreCLR (supports `riscv64`/`loongarch64`), an option where `vsdbg` is unavailable. Does not list `ppc64le`/`s390x` support. |
| Source Link (managed) | ✅ | ✅ | ✅ | Embedded in PDBs for all architectures. |

For an open-source debugging experience where `vsdbg` is not available,
[`netcoredbg`](https://github.com/Samsung/netcoredbg) is the usual alternative
on CoreCLR architectures. A fully supported interactive managed debugger for the
Mono-based `ppc64le`/`s390x` platforms remains an open area.

## References

* [Source Link](https://github.com/dotnet/sourcelink)
* [.NET diagnostics tools
  overview](https://learn.microsoft.com/dotnet/core/diagnostics/)
* [SOS debugging
  extension](https://learn.microsoft.com/dotnet/core/diagnostics/dotnet-sos)
* [Debugging .NET Core on Linux with SOS and
  lldb](https://github.com/dotnet/diagnostics/blob/main/documentation/sos.md)
* [Packaging and installation](packaging-installation.md)
