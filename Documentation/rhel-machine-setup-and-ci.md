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
- These can only be remoted into from a REDMOND-joined machine.  The username is dotnet-bot and the password can be found in Keyvault as usual.
- The most common operation needed is to clean up their source directories.  Typically this is when we get the "object reference is not a tree" or "missing submodule MessagePack" errors in CI and the cause is not missing commits.
  - Log in to the machines, go to the agent work directory (/data/a/_work), and delete \*/s/\* (this will be 1/s/\*, 2/s/\*, etc).  You may have to sudo to do it.