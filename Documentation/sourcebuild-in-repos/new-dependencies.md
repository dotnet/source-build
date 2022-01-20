# Adding a new dependency

## Basics
When adding a new dependency, there are a few steps common between any type of dependency.  If you use darc, `darc add-dependency` will take care of this process for you.  Otherwise:
1. Add the package and a default version to eng/Versions.props.  The default version property should be named `<PackageName>PackageVersion`, e.g. `SystemCollectionsImmutablePackageVersion`.
2. Add the package and a repo reference to eng/Version.Details.xml.
3. Set up dependency flow from the foreign repo to your repo.

In general, you should aim to use one version of each package.  If you are using a package as reference-only, it is possible to use multiple versions, but only one implementation version of each package will be used - source-build will override it to the version that is being built in this version of the SDK.

## Deciding what version to use
- If you are using the package as reference-only and want the version to be pinned, use a literal version number in the csprojs that reference the project.  You can also set up a reference-only package version variable in eng/Versions.props, for instance `<PackageNameReferenceOnly>1.2.3</PackageNameReferenceOnly>` in addition to `<PackageNamePackageVersion>4.5.6</PackageNamePackageVersion>`.  Also verify that the package is available in source-build-reference-packages, and if not, contact the source-build team.
- If you are using the package in the actual build or want the version to be updated whenever the foreign repo publishes to your channel, use the version number property set up in eng/Versions.props.  This will be overridden in some cases by source-build. 

## Internal dependencies
Adding a new dotnet dependency is usually pretty straightforward but does have some edge cases.  Use this checklist:
1. Are you already using a package from the same repo?
	1. This is the simplest case.  You can add new dependencies from repos you are already using freely.
2. Is this a Microsoft repo that uses Arcade to build?
	1. Does the foreign repo depend on your repo, directly or indirectly?  i.e. would adding the dependency create a cycle?
		1. This isn't necessarily a deal-breaker - it can sometimes be worked around with reference-only packages.  Please contact a source-build team member to discuss.
	2. Does the foreign repo publish to BAR?
		1. If not, please contact them to get them publishing to BAR in an appropriate channel.
	3. If neither of these caveats apply you should be in good shape.  Follow the instructions under "Basics" above.
3. Source-build has in the past used Arcade shims to allow non-Arcade repos to build appropriate packages for source-build.  Please contact the source-build team to determine if this is a workable approach for your foreign repo.

## External dependencies

External (non-Microsoft or even non-dotnet) dependencies need to be carefully considered for source-build in addition to the licensing issues you are probably already familiar with.
1. Microsoft but non-dotnet repos should usually be able to use the same Arcade wrapper to publish appropriate packages for source-build - please contact a source-build team member to discuss.
2. Dependencies that have no code (e.g. SDKs with just props and targets) can usually be added using the source-build text-only-package process.  Contact a source-build team member for more information.
3. We build some external dependencies in the dotnet/source-build repo.  Good targets for this generally have very few if any dependencies and very simple build processes.  Contact a source-build team member for more information.