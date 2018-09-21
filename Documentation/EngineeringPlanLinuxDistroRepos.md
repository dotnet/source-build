# Engineering plan for including .NET Core in Linux Distro Repositories #

## Requirements ##

Requirements for getting .NET Core into other Linux Distros are included in *.NET Core in Linux Distro Repositories*. 
See https://github.com/dotnet/source-build/issues/782

### Distro Packaging Guidelines ###

Each distro has specific packaging guidelines along with a well-defined review process.  These guidelines are similar across distros, with one of the main guidelines being that the source provided contain no pre-built binaries.  This is the biggest obstacle to getting .NET Core into distro archives.  .NET Core is included in the Red Hat distro today even though the source-build process requires a large number of pre-builts in order to successfully build.  Red Hat has given exceptions for us to be able to be included in their distro.

### Toolset for Building .NET Core ###
There is one exception to the *"no prebuilt binaries rule"* for the case of bootstrapping a toolset.  This is an exception that .NET Core will need to take advantage of.  This boostrap process is illustrated below.  An exsting toolset is used to build a toolset from source.  The existing toolset is then thrown away and the newly built toolset is used for the actual build of the assemblies that go into the archive.  The source is the same for each stage of the build.

Toolset bootstrapping is different than runtime bootstapping provided in https://github.com/dotnet/source-build/blob/master/scripts/bootstrap/buildbootstrapcli.sh.  This script is only needed when starting with a new distro on which .NET Core has never built.  For the distros being discussed in this document, there are already existing .NET Core runtime and SDK builds available.  For that reason, runtime bootstrapping is outside the scope of this document.

This is discussed in the Fedora packaging guidelines as an exception to the guideline of *no inclusion of pre-built binaries or libraries*.  See [Bootstrap Exception](https://fedoraproject.org/wiki/Packaging:Guidelines#Exceptions)

![Source Build Bootstrap](https://github.com/dseefeld/Sandbox/raw/master/Documentation/SourceBuildBootstrap.png)

### Runtime vs. SDK ###

In the requirements doc above, it is suggested that we *Reduce the problem space and get in the door. Deliver the runtime first.*  The full toolset is required to build both the runtime and the SDK.  Delivering runtime first doesn't necessarily reduce the problem space because of this requirement to create a bootstrap toolset, first.

In either case, it makes sense to split out the creation of a separate archive package for runtime and toolset with the appropriate package dependency.

### N-1 Toolset ###
Subsequent versions of .NET Core, when being built for an already bootstrapped distro do not need to follow the boostrap process as described above.  Subsequent versions will use the N-1 version of the toolset from the archive to build.  Note, N-1 in this context means the previous version of .NET Core that was included in the distro archive.  If, during development of a new version, it is necessary to use a feature from that version, there are two options with regards to source-build:
1. Ship an intermediate release to establish the toolset baseline.  
2. Re-execute the boostrap process for the distro to establish a new baseline for the toolset.


For patch releases and minor releases, we should be able to stick to building with an N-1 version, since the scale of changes are less and releases are more frequent.  When doing major releases, it may be required to use features that are developed in that release because major releases are generally longer and have more new features.  As mentioned above, the solution to this is more frequent, intermediate releases.  If this isn't possible, the bootstrap process will need to be re-executed.

## Roadmap for 2.1 Support ##

In the document above, the desire is to select a pilot distro to work through the details of submitting to a distro archive.  

From the document:

>* _Reduce the problem space and get in the door. Deliver the runtime first._
>* _Reduce pre-built binaries to only those required to bootstrap the build_
>* _Select a pilot distro from among 'Golden' distros for which we will serve as the primary maintainers_
>    * _Fedora_
>    * _Ubuntu_
>    * _CentOS_
>    * _Debian_
>* _Update source-build to create rpm|deb assets for submission into distro archive acceptance process_
>* _Work through the first distro submission process_
>* _Add distro archive maintenance to the .NET Core servicing and release processes_

One of the 'Golden' distros, Fedora, has an existing special interest group (SIG) that maintains spec files for building .NET Core RPMs.  Their goal is to make these the official .NET Core packages in Fedora, but the source does not meet the Fedora packaging guidelines.  We should target Fedora as the first 'Golden' distro so we can focus on getting the source to a state that meets the packaging guidelines while the DotNet SIG can continue to focus on packaging for Fedora.  https://fedoraproject.org/wiki/SIGs/DotNet


## Work Breakdown ##
With this partnership, there are four main area of focus to get .NET Core ready for inclusion into Fedora's package archive:
1. Prove out and define process for toolset bootstrapping.(https://github.com/dotnet/source-build/issues/724)
2. Split runtime build and SDK build and define dependencies correctly. (https://github.com/dotnet/source-build/issues/725)
3. Eliminate prebuilt binaries. (https://github.com/dotnet/source-build/issues/753)
4. Work with DotNet SIG to get packaging ready.

As stated in the requirements, work will be done in the `release/2.1` branch of source-build.  Any changes required to source repos will follow this process:
1. Include changes in source-build as patches to continue moving work forward.
2. Write up issue in target repo to include change in `release/2.1` branch and port to `release/2.2` and `master` branches.
3. Update source-build to move to updated code and remove patch.

Source-build changes will be ported to `release/2.2` and `master` on a regular basis to keep those branches up to date.  The desire is to have `release/2.2` and `master` updated and ready to be included in other distros when they are ready to be released.

### Toolset Bootstrapping ##
This work requires setting up scripts to build the .NET Core toolset from source and then using the result to build source-build.  This is to define the process and to ensure that it works consistently by adding CI.  It also will require working out issues that we've encountered building source-build with the same version that is being built.  See https://github.com/dotnet/source-build/issues/606.  This will also track work with source-building buildTools and the eventual move to Arcade, if it is ported to the `release/2.1` branch for any repos.

### Runtime / SDK Split ###
The main part of this work is to split and isolate the runtime and sdk builds into separate directories with separate build scripts in source-build.  The result of the runtime build should be input to the sdk build.  Each should be able to be built independently.

### Prebuilt Binary Elimination ###

There are 6 categories of prebuilts to eliminate:
1. Prebuilts that end up in the built product. - These must be eliminated and a process must be put into place to detect and track these to make sure they don't happen again.
2. Prebuilts loaded in unneccessary functionality - These are prebuilts that are loaded by a repo's source even though the functionality for the source is not included in source-build.  The main group of these are test assemblies, since source-build does not build tests.
3. Prebuilts that have a version built with source-build - The source-build process should be modified to get repos to use the source-built version of the package.  Many of these are older
4. Prebuilts containing reference assemblies - These prebuilts can be delivered as IL-only code and re-compiled as reference assemblies.
5. First party prebuilts - If there are dependencies on 1st party packages that are not built as part of source-build, we should investigate including them in source-build if possible or eliminating the dependency.
6. Third party prebuilts - Steps should be taken to remove any dependencies on 3rd party packages.

The first steps to eliminating prebuilt binaries it to setup tools that will track changes to prebuilts within the source-build.  The purpose is two-fold:  First, it identifies the work remaining and progress that is being made.  Second, it catches any regressions in cases of additional prebuilts or prebuilts that get into the built output.  The tools should:
* Track deltas between subsequent builds with regards to prebuilts and their versions.
* Identify cases where prebuilts end up in the built output. (#1)
* Be visible and accessible to source-build team members, partners and management.
* Identify the category of prebuilt, if possible.

### Coordidinate with DotNet SIG ###

The DotNet SIG is an existing group that is conducting regular weekly meetings.  The source-build team will join and attend these meetings to share and track our plans with the community.

## Addendum: Prebuilt Analysis ##

Analysis is done on latest build of release 2.1 branch on 8/22:

Category | Count
--- | ---:
Total Distinct Packages/Versions | 667
Total Distinct Package Names | 338
Packages that have source-built version | 38
Distinct xunit packages | 30
Packages that contain only reference assemblies | 188
Package usages across all projects | 9593

### Distinct Count of Package/Versions by Project: ###
Project | Distinct Package/Version Count
--- | ---:
unknown | 205
/src/cli | 233
/src/clicommandlineparser | 63
/src/cli-migrate | 113
/src/common | 93
/src/coreclr | 52
/src/corefx | 177
/src/core-setup | 136
/src/fsharp | 104
/src/msbuild | 145
/src/newtonsoft-json | 25
/src/nuget-client | 242
/src/roslyn | 152
/src/roslyn-tools | 152
/src/sdk | 109
/src/standard | 18
/src/templating | 155
/src/vstest | 185
/src/websdk | 140
/src/xliff-tasks | 131
/Tools | 18
/tools-local/tasks | 97
