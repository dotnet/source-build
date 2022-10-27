# Bootstrapping the source-build

## Bootstrapping Subsequent .NET release
Subsequent versions of .NET Core, when being built for an already bootstrapped distro do not need to follow the bootstrap process. Subsequent versions will use the N-1 version of the toolset from the archive to build. Note, N-1 in this context means the previous version of .NET Core that was included in the distro archive.
As an example, to build SDK “N” (6.0.101) using “N-1” (6.0.100). 

For each major release (7.0 in the example), the bootstrap process needs to be re-executed.

## Bootstrapping New RID (Arch/OS)
Refer to this guide to learn about RIDs - https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids.  
Source-build is designed to build on a single machine with no internet access. This means that we build targeting a single RID, usually the non-portable RID for the build machines (like rhel.7-x64). We support building portable (linux-x64) as well - this is useful for bootstrapping new distributions. 

## Bootstrapping New Distro’s 
https://github.com/dotnet/source-build/blob/main/Documentation/boostrap-new-os.md
