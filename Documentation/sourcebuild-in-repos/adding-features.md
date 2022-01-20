# New features

New features are great!  They also have source-build considerations though.  .NET is no longer just multi-platform but also multi-distribution: there's a Linux SDK produced by Microsoft, but there's also a Linux SDK produced by Red Hat, one produced by Fedora, and one that anyone in the community can build himself from source.

## Things to consider

New features, or expansions of current features, should act sensibly across Windows, Linux, and OSX.  This also involves taking into account the limitations and conventions of the different platforms - for instance, on Linux, it's typical for the .NET SDK to be installed by root and therefore be unchangeable by normal users, so installing global tools needs to take into account the fact that the user might not be able to add anything to the SDK directories.

XXX details on the global tools issues

New features also need to be compatible across all distributions of .NET - for instance, Fedora and Debian cannot distribute *any* non-open-source code, even samples, tests, or minor additions to licenses like restricting the field that the code can be used in.  This includes any code or packages that are used to build product code as well.

XXX fill in the details on dotnet-check/dotnet-format here

XXX Should we create a Github group for source-build community members that would be interested in reviewing things like this?