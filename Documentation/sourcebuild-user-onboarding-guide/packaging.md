## Linux Distribution Packaging Guidelines

 If you want to create a Linux distribution package (rpm, deb) out of the source-build SDK here are some suggestions. See [.NET Core distribution packaging](https://learn.microsoft.com/en-us/dotnet/core/distribution-packaging) for information on suggested packages, sub-packages, name and contents. This is the minimal amount of content you need to package up:

1. Extract the tarball to the distribution appropriate location such as /usr/lib64/dotnet/, /usr/lib/dotnet/, or /usr/lib/x86_64-linux-gnu/dotnet/. 

2. Create a symlink from /usr/bin/dotnet (or equivalent) to the dotnet binary in the SDK that you installed in the previous step.   
For example: ln -s /usr/lib64/dotnet/dotnet /usr/bin/dotnet 
Now users can simply run dotnet and it will work. 

3. Create an /etc/dotnet/install_location file and add the path of the SDK directory in there. The file should contain a single line like this: /usr/lib64/dotnet  
 This file is used by [.NET Core to find the SDK/Runtime location](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md). 

4. Define DOTNET_ROOT and update PATH by saving the following as /etc/profile.d/dotnet.sh (or equivalent).

    Set location for AppHost lookup[ -z "$DOTNET_ROOT"] &&exportDOTNET_ROOT=/usr/lib64/dotnet.  
    
    Add dotnet tools directory to PATHDOTNET_TOOLS_PATH="$HOME/.dotnet/tools"case"$PATH"in*"$DOTNET_TOOLS_PATH"*) true;; 
         *) PATH="$PATH:$DOTNET_TOOLS_PATH";; 
         esac

    Adjust the paths to match what the distribution policies. This snippet should work in sh (including dash) and bash. You may need to adapt it, or use something entirely different, for other shells. This allows apphost-lookup to work via DOTNET_ROOT and allows users to easily use dotnet tools directly after a dotnet tool install.
    
There are other optional things you can do: 
• .NET Core source repositories include main pages. You can search for them and package them up: find -iname '*.1' -exec cp {} /usr/share/man/man1/ \; 
• .NET Core includes [bash-completion](https://github.com/dotnet/cli/blob/master/scripts/register-completions.bash) and [zsh-completion](https://github.com/dotnet/cli/blob/master/scripts/register-completions.zsh) scripts. The copies in the source code you used to build the SDK should be the latest version. See how to [enable tab completion](https://learn.microsoft.com/en-us/dotnet/core/tools/enable-tab-autocomplete) for .NET Core cli for more information.