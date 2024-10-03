# Updating a dependency

In most cases, dependency flow should automatically update the packages you
depend on.  There are some special considerations and things to keep in mind
when doing manual updates.  If you are manually updating a version, also see
[the doc on new dependencies](new-dependencies.md) for special considerations.

## Internal packages

If you are manually updating a package, please make sure it's from a compatible
branch (e.g. runtime release/6.0 to sdk release/6.0.1xx, release/6.0.2xx, etc).
Package versions that you are updating to should be source-built in their
respective repos.  If the version you need is produced in a branch that is not
yet source-build-compatible please let the [source-build
team](https://github.com/orgs/dotnet/teams/source-build-internal) know.

Another common error we see is updating eng/Versions.props but not
eng/Version.Details.xml.  This causes problems for source-build because we
depend on these files being updated in lockstep.  Please prefer updating with
Darc - it takes care of these issues - or, if a manual update really is
necessary, make sure you update both files.

Example Darc command: `darc update-dependencies --name MyCoolPackage -v 1.2.3`

## External packages

Updating a non-Microsoft (e.g. Newtonsoft.Json 9.0.1 to 13.0.1) or non-Arcade
(e.g. ApplicationInsights) package is typically equivalent to adding the new
version all over again.  Please [log an
issue](https://github.com/dotnet/source-build/issues/new/choose) to discuss
this.  You can check if the external package you want is already included in
source-build in the
[source-build-externals](https://github.com/dotnet/source-build-externals) repo.

## Splitting, combining, and moving packages

These operations often end up causing source-build issues.  A typical case of
what can happen is

1. Package A is produced in version 1.
1. In version 2, Package A is split into Package A1 and Package A2.
1. A downstream repo is never updated to take the split packages.
1. The version 2 source-build succeeds because Package A exists in the
  [previously-source-built
  archive](build-info.md#Single_version_and_single_RID_build), but no new
  version of Package A is produced.
1. Source-build version 3 fails because Package A no longer exists in the
  previously-source-built archive either.

So please keep in mind consumers of your packages and try to keep them informed
of these kinds of changes.  If you are the consuming repo, consider tracking PRs
in the repos that produce your dependencies.
