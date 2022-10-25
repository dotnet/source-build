## Installation on Linux

The built SDK is generally located at `artifacts/${ARCHITECTURE}/Release/dotnet-sdk-${SDK_VERSION}-${RUNTIME_ID}.tar.gz`.  

**Installing the SDK directly (install per-user)**  
Details on how to [manually install an SDK](https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#manual-install). The same steps listed should work for all Linux distributions where bash (or sh) is the default shell.  

**Installing the SDK globally**  
If you want to install the SDK globally (and not per user), here are some suggestions.  

1. Extract the tarball to a distribution-appropriate location such as /usr/local/lib64/dotnet/, /usr/local/lib/dotnet/, or /usr/local/lib/x86_64-linux-gnu/dotnet/. 
	
2. Create a symlink from /usr/local/bin/dotnet (or an equivalent location available in $PATH) to the dotnet binary in the SDK that you installed in the previous step. For example:  
         ln -s /usr/local/lib64/dotnet/dotnet /usr/local/bin/dotnet 
        Now users can simply run dotnet and it will work. 

3. Create an /etc/dotnet/install_location file and add the path of the SDK directory in there. The file should contain a single line like this: /usr/local/lib64/dotnet/. This file is used by .NET Core to find the SDK/Runtime location

4. Define DOTNET_ROOT and update PATH by saving the following as /etc/profile.d/dotnet.sh (or equivalent).

    Set location for AppHost lookup[ -z "$DOTNET_ROOT"] &&exportDOTNET_ROOT=/usr/lib64/dotnet.  
    
    Add dotnet tools directory to PATHDOTNET_TOOLS_PATH="$HOME/.dotnet/tools"case"$PATH"in*"$DOTNET_TOOLS_PATH"*) true;; 
         *) PATH="$PATH:$DOTNET_TOOLS_PATH";; 
         esac

    Adjust the paths to match what the distribution policies. This snippet should work in sh (including dash) and bash. You may need to adapt it, or use something entirely different, for other shells. This allows apphost-lookup to work via DOTNET_ROOT and allows users to easily use dotnet tools directly after a dotnet tool install.