# Adding support for a new OS
## Bootstrap CLI
When adding support for a new OS, both the native (C++) and managed (C#) code components in the coreclr, corefx and core-setup repos need to be compiled. Making the native components build on a new OS is a quite straightforward process and the tools like CMake, Clang C/C++ compiler, python and awk that are required for the build are available for almost all platforms. 
But for the managed code compilation, we have a chicken and egg problem. A .NET CLI toolchain is needed to build managed components in the coreclr, corefx and core-setup repos, but it is not available for the target platform yet. 
The way to solve this problem is to create a bootstrap CLI by taking an existing CLI as a "seed" and replacing native components in it by the native components that we build for the new platform. The seed CLI we use has to be for the same processor architecture as our new platform or we have to use a seed cli that we build from sources on another platform that is already supported and opt for not crossgenning the managed components. 
### Choosing the seed CLI
While the bootstrap CLI can be built for any version of the seed CLI, it is important to pick a version of CLI that can be used to built current corefx, coreclr and core-setup repos. From time to time, a change in the CLI causes it to not to be usable for compiling one of the repos without fixes in the msbuild project files. So to stay on the safe side, the best practice is to pick a version used by one of the three repos. This version can be found in the `DotnetCLIVersion.txt` file in the root of each repo. 
### Getting the seed CLI
After getting the seed CLI version as described in the previous paragraph, it can be used to construct an URL to download the .tar.gz file with the seed CLI itself. The way to construct the URL can be found in the `init-tools.sh` file in the root of each repo. Currently, it is constructed as follows:
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
* libunwind
* lttng-ust
* openssl or libressl
* krb5
* curl
* liblldb
* icu
* libuuid
### Building the bootstrap CLI
There is a bash script file that automatizes most of the process of building the bootstrap CLI end to end. It first creates a folder named by the new target RID, clones the coreclr, corefx and core-setup repos into it and checks out the same commit of each of the repos as the one that was used to build the seed CLI. This first step is skipped if the coreclr, corefx and core-setup folders already exist. This is important so that the sources can be modified to fix possible build issues and to target the new RID.
The script needs to be passed several arguments. The target architecture, the build configuration, the target OS, the new RID and path to the folder with the untared seed CLI. There is also an optional option to specify the version of the Clang compiler to use to compile the native code. There is also an option to pass in a System.Private.CoreLib.dll built elsewhere and an option to crossgen it. This is useful if you are building debug configuration, since the seed CLI that comes from Azure is built for release configuration and the release version of System.Private.CoreLib.dll is not compatible with debug version of libcoreclr.so.
Here is the summary of the options that you get from running the script with `--help` option:
```
Usage: buildbootstrapcli.sh [BuildType] --rid <Rid> --seedcli <SeedCli> [--arch <Architecture>] [--os <OS>] [--clang <Major.Minor>] [--corelib <CoreLib>] [--crossgen]

Options:
  BuildType               Type of build (-debug, -release), default: -debug
  -arch <Architecture>    Architecture (x64, x86, arm, arm64, armel), default: x64
  -clang <Major.Minor>    Override of the version of clang compiler to use
  -config <Configuration> Build configuration (debug, release), default: debug
  -corelib <CoreLib>      Path to System.Private.CoreLib.dll, default: use the System.Private.CoreLib.dll from the seed CLI
  -crossgen               Crossgen the System.Private.CoreLib.dll, default: do not crossgen
  -os <OS>                Operating system (used for corefx build), default: Linux
  -rid <Rid>              Runtime identifier (without the architecture part)
  -seedcli <SeedCli>      Seed CLI used to generate the target CLI
```
So, for example, when we were creating bootstrap CLI for RHEL / CentOS 6, the command was:
```bash
./buildbootstrapcli.sh -arch x64 -rid rhel.6 -release -os Linux -seedcli ~/seed-cli
```
After running the script, check the console output. If the last line printed is `**** Bootstrap CLI was successfully built  ****`, then everything went fine and the bootstrap CLI is ready. You can find it in the `<Rid>-<Architecture>/dotnetcli` subfolder. So for the example command above, it would be `rhel.6-x64/dotnetcli`.
If there were build errors, they need to be looked into and fixed. After that run the `buildbootstrapcli.sh` with the same arguments again. Repeat until everything builds.
### Testing the bootstrap CLI
The easiest way to test the bootstrap CLI that was just created is to create, built and run a "hello world" console application. Create a new folder for the application and then run `/your/path/to/bootstrap/dotnetcli/dotnet new console` followed by `/your/path/to/bootstrap/dotnetcli/dotnet run`. If both of these succeed and the second prints "Hello world!", then everything went ok and you have a working bootstrap CLI. If there are issues in either of these steps, they need to be debugged and the culprits figured out.
### Troubleshooting
TODO: describe how to do debug build and replace System.Private.CoreLib.dll
#### Using bootstrap CLI on platforms with different OS or architecture
If the bootstrap CLI was created for OS other than the one the seed cli supports (e.g. FreeBSD) or the target architecture of the target OS differs from the architecture of the bootstrap cli (e.g. ARM64), the managed assemblies in the bootstrap CLI cannot be loaded, since they contain native code for the target OS and architecture. Fortunately, they also contain the original IL code, so they can be re-crossgened for the target OS and architecture. Or it is possible to instruct the CoreCLR runtime to ignore the native code and use the IL by setting environment variables `COMPlus_ZapDisable=1` and `COMPlus_ReadyToRun=0`. That can be useful during the bringup. But ultimately, re-crossgening should be made to improve startup performance.
TODO: describe how to re-crossgen the managed assemblies
## Building nuget packages
Now that the bootstrap CLI works, it can be used to build coreclr, corefx and core-setup repos in its completeness, including the managed code. First set the `DOTNET_TOOL_DIR` env variable to the path where the boostrap CLI is located. That will cause the build process to use these tools instead of trying to download a `.tar.gz` package with OS specific tools from Azure.
You can use the boostrap tools to build any recent state of the three repos. `release/2.0.0` branch can be used to build the 2.0.0 release packages or `master` branch to build the latest stuff.
For the sake of simplicity, the following paragraphs assume the following:
* we are building release configuration
* we are targetting x64
* the new RID is `mynewrid`
* the coreclr, corefx and core-setup folders with clones of the three repos are in the same directory
### Adding support for the new RID
#### CoreCLR
* Unless the target OS has `/etc/os-release` file that can be used to extract the RID, the `initHostDistroRid` function in the `build.sh` file needs to be updated to be able to detect the target OS and report the proper RID by setting the `__HostDistroRid` to the RID combined with the target architecture (e.g. `mynewrid-x64`).
* In `src/.nuget/dir.props` add a new `OfficialBuildRID` element with the new RID and target architecture. So for example, `<OfficialBuildRID Include="mynewrid-x64" />`
#### CoreFX
* Unless the target OS has `/etc/os-release` file that can be used to extract the RID, the `initHostDistroRid` function in the `src/Native/build-native.sh` file needs to be updated to be able to detect the target OS and report the proper RID by setting the `__HostDistroRid` to the RID combined with the target architecture (e.g. `mynewrid-x64`).
* In `dependencies.props`, the `CoreClrPackageVersion` needs to be updated to contain the version of packages built in the coreclr repo.
* In `external/runtime/runtime.depproj`, the content of the `Version` element under `<PackageReference Include="Microsoft.NETCore.DotNetHost">` and `<PackageReference Include="Microsoft.NETCore.DotNetHostPolicy">` needs to be updated to contain the version of packages built in the core-setup repo.
* In `external/test-runtime/XUnit.Runtime.depproj`, add `<NoWarn>NU1603</NoWarn>` to the first `<PropertyGroup>` element.
* In `pkg/Microsoft.NETCore.Platforms/runtime.json`, add new elements describing the new RID and its relationship under the `runtimes` key. Here is an example of what we would add for Alpine Linux 3.6:
```json
    "alpine": {
        "#import": [ "linux" ]
    },
    "alpine-x64": {
        "#import": [ "alpine", "linux-x64" ]
    },
    "alpine.3.6": {
        "#import": [ "alpine" ]
    },
    "alpine.3.6-x64": {
        "#import": [ "alpine.3.6", "alpine-x64" ]
    },
```
* In `pkg/Microsoft.Private.CoreFx.NETCoreApp/netcoreapp.rids.props`, add a new `OfficialBuildRID` element with the new RID and target architecture. So for example, `<OfficialBuildRID Include="mynewrid-x64" />`
#### Core-Setup
* Unless the target OS has `/etc/os-release` file that can be used to extract the RID, the `init_rid_plat` function in the `src/corehost/build.sh` file needs to be updated to be able to detect the target OS and report the proper RID by setting the `__rid_plat` variable. Please note that unlike the similar case in coreclr and corefx repos, this variable is set to the RID without the target architecture (so just `mynewrid` and not e.g. `mynewrid-x64`).
* In `dependencies.props`, update the `MicrosoftPrivateCoreFxNETCoreAppPackageVersion` element to and the `MicrosoftNETCoreRuntimeCoreCLRPackageVersion` element to.
* In `src/pkg/projects/netcoreappRIDs.props`, add a new `OfficialBuildRID` element with the new RID and target architecture. So for example, `<OfficialBuildRID Include="mynewrid-x64" />`
### Building CoreCLR
The first step is to build coreclr. Go to the root of the coreclr and run 
```bash
DOTNET_TOOL_DIR=/your/path/to/bootstrap/dotnetcli ./build.sh release -portablebuild=false msbuildonunsupportedplatform
```
The `DOTNET_TOOL_DIR` variable was recently renamed to `DotNetBuildToolsDir` in corefx and this change is going to be propagated to all three repos, so it is worth checking the `init-tools.sh` to see which of the variables is used there before starting the build.
You may need to add an option to specify the version of Clang to use for the build. 
If the build completes ok, it would generate nuget `.nupkg` package files into `bin/Product/Linux.x64.Release\.nuget\pkg`. If it fails, investigate and fix the problems and run the build command again.
After the build succeeds, list the contents of the `bin/Product/Linux.x64.Release\.nuget\pkg` directory and note the version number e.g. in the `Microsoft.NETCore.Runtime.CoreCLR` package filename. So for example, the filename can be `Microsoft.NETCore.Runtime.CoreCLR.2.0.2-servicing-25708-0.nupkg`. The version is `2.0.2-servicing-25708-0`. It will be needed in the next step.
### Building CoreFX
Now that we have built the CoreCLR, we can build the CoreFX. Since CoreFX depends on CoreCLR packages, we need to pass the location of the packages built in CoreCLR as an additional nuget source using the `/p:OverridePackageSource=xxxx` option. Also, the corefx build needs to know the version of the coreclr packages so that it can get proper nuget packages. The previous paragraph on CoreCLR build describes how to get the version. 
Change the current directory to the corefx directory, edit the `dependencies.props` file and replace the version in the `<CoreClrPackageVersion>` node by the version of your coreclr build.
Then run the following command.
```bash
DOTNET_TOOL_DIR=/your/path/to/bootstrap/dotnetcli ./build.sh -release -runtimeos=mynewrid -stripSymbols -SkipTests=true -- /p:OverridePackageSource=../coreclr/bin/Product/Linux.x64.Release/.nuget/pkg/ /p:PortableBuild=false
```
If the build completes ok, it would generate nuget `.nupkg` package files into `bin/packages/Release`. If it fails, investigate and fix the problems and run the build command again.
Now you need to find the version of the nuget packages that were just built. List files in the `bin/packages/Release` folder and note the version number in the `Microsoft.Private.CoreFx.NETCoreApp` package file. So for example, if the filename is `Microsoft.Private.CoreFx.NETCoreApp.4.4.0-preview1-25304-0.nupkg`, the version is `4.4.0-preview1-25304-0`. You will need it in the next step.
### Building Core-Setup
The core-setup build depends on the nuget packages that were just built in coreclr and corefx. Since the overriding of package source can only be a single directory, we first create a folder where we copy the nuget packages from both coreclr and corefx. 
Change the current directory to the parent directory of coreclr, corefx and core-setup
```bash
mkdir combinednugets
cp coreclr/bin/Product/Linux.x64.Release\.nuget\pkg\*.nupkg combinednugets
cp corefx/bin/packages/Release/*.nupkg combinednugets
```
Now change the current directory to the core-setup directory, edit the `dependencies.props` file and replace the version in the `<MicrosoftPrivateCoreFxNETCoreAppPackageVersion>` node by the version of your corefx build and the version in the `<MicrosoftNETCoreRuntimeCoreCLRPackageVersion>` node by the version of your coreclr build.
Then build core-setup using the following command:
```bash
DOTNET_TOOL_DIR=/your/path/to/bootstrap/dotnetcli ./build.sh -portable=false -release -stripSymbols -DistroRid=mynewrid-x64 -os=Linux -- /p:OverridePackageSource=../combinednugets/
```
If the build completes ok, it would generate nuget `.nupkg` package files into `Bin/mynewrid-x64.Release/packages`. If it fails, investigate and fix the problems and run the build command again.
