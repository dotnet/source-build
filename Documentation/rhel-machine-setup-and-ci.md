# Red Hat machine setup and internal CI machines

## Machine setup

### RHEL 7

- It's usually easiest to install the server or minimal workloads and add needed stuff from there.
- You will need a RHEL developer account (https://developers.redhat.com/register).
- You will need to install the [EPEL](https://www.redhat.com/en/blog/whats-epel-and-how-do-i-use-it) and [rhel-server-rhscl-7-rpms](https://access.redhat.com/solutions/472793) repos.
- The build prereqs are mostly the same as the [Fedora docker image](https://github.com/dotnet/dotnet-buildtools-prereqs-docker/blob/main/src/fedora/32/amd64/Dockerfile).
  - Clang and LLVM are pretty old in the default repos.  The easiest way to get a version that will work with both release/3.1 and release/5.0 is to install llvm-toolset-6.0 and devtoolset-8 from the RHSCL repo.  Then you can run `scl enable devtoolset-8 llvm-toolset-6.0 bash` to get a shell with the updated Clang and LLVM available.

### RHEL 8

- See RHEL 7, but you shouldn't need the RHSCL repo - the Clang and LLVM versions are already good enough.


## CI Machines

- Our RHEL CI machines are dnsb-rhel7-1, dnsb-rhel7-2, dnsb-rhel8-1, and dnsb-rhel8-2 in the DotNet-SourceBuild-Internal pool.
  - These are not accessible with their hostnames; IP addresses are in [OneNote](https://microsoft.sharepoint.com/teams/dotNETDeployment/_layouts/OneNote.aspx?id=%2Fteams%2FdotNETDeployment%2FShared%20Documents%2FGeneral%2FNET%20Core%20Acquisition%20and%20Deployment&wd=target%28source-build%2FServicing.one%7C594D6D3A-E971-4C2A-8BA6-4E13782F4585%2FRHEL%20CI%20Reference%7C1157395A-8D3D-4897-B3A5-C1FE22035C25%2F%29).
  - These can only be remoted into from a REDMOND-joined machine.  The username is dotnet-bot and the password can be found in Keyvault as usual.
- The most common operation needed is to clean up their source directories.  Typically this is when we get the "object reference is not a tree" or "missing submodule MessagePack" errors in CI and the cause is not missing commits.
  - Log in to the machines, go to the agent work directory (/data/a/_work), and delete \*/[abs]/\* and \*/[abs]/.\* (this will be 1/a/\*, 1/b/\*, 1/s/\*, 1/s/.*, 2/a/\*, etc).  You may have to sudo to do it.
