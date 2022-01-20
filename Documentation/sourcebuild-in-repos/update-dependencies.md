# Updating a dependency

In most cases, dependency flow should automatically update the packages you depend on.  There are some special considerations and things to keep in mind when doing manual updates.

## External packages

Updating a non-Microsoft or non-Arcade package is typically equivalent to adding the new version all over again.  Please contact a source-build team member to discuss this.

## Internal packages

If you are manually updating a package, please make sure it's from a compatible branch (e.g. runtime release/6.0 to sdk release/6.0.1xx, release/6.0.2xx, etc).  Package versions that you are updating to should be source-built in their respective repos.  If the version you need is produced in a branch that is not yet source-build-compatible please let the source-build team know.

## Splitting, combining, and moving packages

These operations often end up causing source-build issues.  A typical case of what can happen is
1. Package A is produced in version 1.
2. In version 2, Package A is split into Package A1 and Package A2.
3. A downstream repo is never updated to take the split packages.
4. The version 2 source-build succeeds because Package A exists in the previously-source-built archive, but no new version of Package A is produced.
5. Source-build version 3 fails because Package A no longer exists in the previously-source-built archive either.


So please keep in mind consumers of your packages and try to keep them informed of these kinds of changes.  If you are the consuming repo, consider tracking PRs in the repos that produce your dependencies.