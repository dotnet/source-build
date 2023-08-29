# New features

New features are great!  They also have source-build considerations though.
.NET is no longer just multi-platform but also multi-distribution: there's
a Linux SDK produced by Microsoft, but there's also a Linux SDK produced
by Red Hat, one produced by Fedora, and one that anyone in the community
can build himself from source.

## Things to consider

New features, or expansions of current features, should act sensibly
across Windows, Linux, and OSX.  This also involves taking into account
the limitations and conventions of the different platforms - for instance,
on Linux, it's typical for the .NET SDK to be installed by root and
therefore be unchangeable by normal users, so installing global tools
needs to take into account the fact that the user might not be able to
add anything to the SDK directories (see
[this docker global tools issue](https://github.com/dotnet/dotnet-docker/issues/520)
and [a similar installer issue](https://github.com/dotnet/installer/issues/7069)).

New features also need to be compatible across all distributions of
.NET - for instance, Fedora and Debian cannot distribute *any*
non-open-source code, even samples, tests, or minor additions to
licenses like restricting the field that the code can be used in.
This includes any code or packages that are used to build product
code as well.  Microsoft generally prefers the MIT license.

One example of a licensing issue that source-build found was with
dotnet-check and dotnet-format: these tools were brought into the
product build but had a dependency that was not licensed compatibly -
even without the source-build aspect.  We had to scramble to replace
the dependency before the release.  Dependencies need to be carefully
checked for license compatibility as well.

## Resources

Fedora's approved open-source licenses can be found
[on their wiki](https://fedoraproject.org/wiki/Licensing:Main#Good_Licenses),
or  you can check on the [OSI-approved list of licenses](https://opensource.org/licenses/alphabetical).

If you would like some of our distribution maintainer partners to
review your new feature you can ping @dotnet/distro-maintainers
on a PR or issue.
