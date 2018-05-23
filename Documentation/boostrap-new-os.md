# Adding support for a new OS
## Bootstrap CLI
When adding support for a new OS, both the native (C++) and managed (C#) code components in the coreclr, corefx and core-setup repos need to be compiled. Making the native components build on a new OS is a quite straightforward process and the tools like CMake, Clang C/C++ compiler, python and awk that are required for the build are available for almost all platforms. 
But for the managed code compilation, we have a chicken and egg problem. A .NET CLI toolchain is needed to build managed components in the coreclr, corefx and core-setup repos, but it is not available for the target platform yet. 
The way to solve this problem is to create a bootstrap CLI by taking an existing CLI as a "seed" and replacing native components in it by the native components that we build for the new platform. The seed CLI we use has to be for the same processor architecture as our new platform or we have to use a seed cli that we build from sources on another platform that is already supported and opt for not crossgenning the managed components. 
### Choosing the seed CLI
While the bootstrap CLI can be built for any version of the seed CLI, it is important to pick a version of CLI that can be used to build current corefx, coreclr and core-setup repos. From time to time, a change in the CLI causes it to not to be usable for compiling one of the repos without fixes in the msbuild project files. So to stay on the safe side, the best practice is to pick a version used by one of the three repos. This version can be found in the `DotnetCLIVersion.txt` file in the root of each repo. 
### Getting the seed CLI
After choosing the seed CLI version as described in the previous paragraph, it can be used to construct an URL to download the .tar.gz file with the seed CLI itself. The way to construct the URL can be found in the `init-tools.sh` file in the root of each repo. Currently, it is constructed as follows:
```
https://dotnetcli.azureedge.net/dotnet/Sdk/${__DOTNET_TOOLS_VERSION}/dotnet-sdk-${__DOTNET_TOOLS_VERSION}-${__PKG_RID}-${__PKG_ARCH}.tar.gz
```
The `${__DOTNET_TOOLS_VERSION}` is replaced by the seed CLI version, the `${__PKG_RID}` by the RID of the current platform and `${__PKG_ARCH}` by the architecture of the current platform.
So for tools version `2.0.0` on linux distro with x64 architecture where portable dotnet core can be used, the URL is `https://dotnetcli.azureedge.net/dotnet/Sdk/2.0.0/dotnet-sdk-2.0.0-linux-x64.tar.gz`
To download it, `wget` or `curl` tools can be used.
Once the file is downloaded, create a new folder and untar the file into it.  
So e.g. for the file mentioned above, use:
```bash
tar -xf dotnet-sdk-2.0.0-linux-x64.tar.gz
```
### Choosing RID for the new OS
The new RID represents your target OS. It is used by developers to target that OS. The RID format is `<Name>.<Version>`. The name is lower case and should match the target OS. The version is optional and should be used if it is expected that in future versions the libraries that .NET Core depends on will not be binary compatible with the first supported version. So for example for FreeBSD 11, the RID would likely be `freebsd.11`.
For OS that has `/etc/os-release` file, the RID needs to match the `$ID.$VERSION_ID` extracted from that file. 
### Prerequisites
The following libraries and tools need to be installed in order to build the bootstrap CLI. The precise names of the packages are OS specific.
#### Tools
* Clang version 3.5 or higher, 3.9 recommended
* CMake version 2.8.12 or higher
* Python version 2.7
* AWK
* SED
#### Development libraries
* lttng-ust
* openssl or libressl
* krb5
* curl
* liblldb
* icu

For versions earlier than .NET Core 2.1, following dependencies are also required:
* libunwind
* libuuid

### Building the bootstrap CLI
There is a bash script file that automatizes most of the process of building the bootstrap CLI end to end. The bash script is located at `dotnet/source-build/scripts/bootstrap/buildbootstrapcli.sh`. It first creates a folder named by the new target RID, clones the coreclr, corefx and core-setup repos into it and checks out the same commit of each of the repos as the one that was used to build the seed CLI. This first step is skipped if the coreclr, corefx and core-setup folders already exist. This is important so that the sources can be modified to fix possible build issues and to target the new RID.

The script needs to be passed several arguments. The target architecture, the build configuration, the target OS, the new RID and path to the folder with the untared seed CLI. There is also an optional option to specify the version of the Clang compiler to use to compile the native code. There is also an option to pass in a System.Private.CoreLib.dll built elsewhere and an option to crossgen it. This is useful if you are building debug configuration, since the seed CLI that comes from Azure is built for release configuration and the release version of System.Private.CoreLib.dll is not compatible with debug version of libcoreclr.so.
Here is the summary of the options that you get from running the script with `--help` option:
```
Usage: buildbootstrapcli.sh [BuildType] --rid <Rid> --seedcli <SeedCli> [--os <OS>] [--clang <Major.Minor>] [--corelib <CoreLib>]

Options:
  BuildType               Type of build (-debug, -release), default: -debug
  -clang <Major.Minor>    Override of the version of clang compiler to use
  -config <Configuration> Build configuration (debug, release), default: debug
  -corelib <CoreLib>      Path to System.Private.CoreLib.dll, default: use the System.Private.CoreLib.dll from the seed CLI
  -os <OS>                Operating system (used for corefx build), default: Linux
  -rid <Rid>              Runtime identifier including the architecture part (e.g. rhel.6-x64)
  -seedcli <SeedCli>      Seed CLI used to generate the target CLI
  -outputpath <path>      Optional output directory to contain the generated cli and cloned repos, default: <Rid>
```
So, for example, when we were creating bootstrap CLI for RHEL / CentOS 6, the command was:
```bash
./buildbootstrapcli.sh -rid rhel.6 -release -os Linux -seedcli ~/seed-cli
```
After running the script, check the console output. If the last line printed is `**** Bootstrap CLI was successfully built  ****`, then everything went fine and the bootstrap CLI is ready. You can find it in the `<Rid>-<Architecture>/dotnetcli` subfolder. So for the example command above, it would be `rhel.6-x64/dotnetcli`.
If there were build errors, they need to be looked into and fixed. After that run the `buildbootstrapcli.sh` with the same arguments again. Repeat until everything builds.
### Testing the bootstrap CLI
The easiest way to test the bootstrap CLI that was just created is to create, build and run a "hello world" console application. Create a new folder for the application and then run `/your/path/to/bootstrap/dotnetcli/dotnet new console` followed by `/your/path/to/bootstrap/dotnetcli/dotnet run`. If both of these succeed and the second prints "Hello world!", then everything went ok and you have a working bootstrap CLI. If there are issues in either of these steps, they need to be debugged and the culprits figured out.
### Troubleshooting
TODO: describe how to do debug build and replace System.Private.CoreLib.dll
#### Using bootstrap CLI on platforms with different OS or architecture
If the bootstrap CLI was created for OS other than the one the seed cli supports (e.g. FreeBSD) or the target architecture of the target OS differs from the architecture of the bootstrap cli (e.g. ARM64), the managed assemblies in the bootstrap CLI cannot be loaded, since they contain native code for the target OS and architecture. Fortunately, they also contain the original IL code, so they can be re-crossgened for the target OS and architecture. Or it is possible to instruct the CoreCLR runtime to ignore the native code and use the IL by setting environment variables `COMPlus_ZapDisable=1` and `COMPlus_ReadyToRun=0`. That can be useful during the bringup. But ultimately, re-crossgening should be made to improve startup performance.
TODO: describe how to re-crossgen the managed assemblies
