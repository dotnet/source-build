# .NET Core Packaging and Installation

This document helps you install or package a .NET Core SDK built using source-build.

The SDK built by source-build is generally not portable. That means it will work on the same operating system where it was built. It will not work on older operating systems. It may work on newer operating systems.

The built SDK is generally located at `artifacts/${ARCHITECTURE}/Release/dotnet-sdk-${SDK_VERSION}-${RUNTIME_ID}.tar.gz`.

## Using the SDK directly (install per-user)

To use the SDK directly, unpack the SDK to any directory and then use the `dotnet` executable from it.

You can find more details on how to manually install an SDK from a tarball at [manually installing an SDK](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#manual-install). The same steps listed should work for all Linux distributions where `bash` (or `sh`) is the default shell.

## Installing the SDK globally

If you want to install the SDK globally (and not per user), here are some suggestions.

1. Extract the tarball to a distribution-appropriate location such as `/usr/local/lib64/dotnet/`, `/usr/local/lib/dotnet/`, or `/usr/local/lib/x86_64-linux-gnu/dotnet/`.

2. Create a symlink from `/usr/local/bin/dotnet` (or an equivalent location available in `$PATH`) to the `dotnet` binary in the SDK that you installed in the previous step. For example:

   ```bash
   ln -s /usr/local/lib64/dotnet/dotnet /usr/local/bin/dotnet
   ```

   Now users can simply run `dotnet` and it will work.

3. Create an `/etc/dotnet/install_location` file and add the path of the SDK directory in there. The file should contain a single line like this:

   ```
   /usr/local/lib64/dotnet/
   ```

   This file is used by [.NET Core to find the SDK/Runtime location](https://github.com/dotnet/designs/blob/master/accepted/2020/install-locations.md)

4. Define `DOTNET_ROOT` and update `PATH` by saving the following as `/etc/profile.d/dotnet-local.sh` (or equivalent)

   ```bash
   # Set location for AppHost lookup
   [ -z "$DOTNET_ROOT" ] && export DOTNET_ROOT=/usr/local/lib64/dotnet

   # Add dotnet tools directory to PATH
   DOTNET_TOOLS_PATH="$HOME/.dotnet/tools"
   case "$PATH" in
       *"$DOTNET_TOOLS_PATH"* ) true ;;
       * ) PATH="$PATH:$DOTNET_TOOLS_PATH" ;;
   esac
   ```

   Make sure to adjust the paths to match what you used on your system.

   This snippet should work in `sh` (including `dash`) and `bash`. You may need to adapt it, or use something entirely different, for other shells.

   This allows apphost-lookup to work via `DOTNET_ROOT` and allows users to easily use dotnet tools directly after a `dotnet tool install`.

## Creating a Linux distribution package

If you want to create a Linux distribution package (`rpm`, `deb`) out of the source-build SDK here are some suggestions.

See [.NET Core distribution packaging](https://docs.microsoft.com/en-us/dotnet/core/distribution-packaging) for information on suggested packages, subpackages, name and contents.

This is the minimal amount of content you need to package up:

1. Extract the tarball to the distribution appropriate location such as `/usr/lib64/dotnet/`, `/usr/lib/dotnet/`, or `/usr/lib/x86_64-linux-gnu/dotnet/`.

2. Create a symlink from `/usr/bin/dotnet` (or equivalent) to the `dotnet` binary in the SDK that you installed in the previous step. For example:

   ```bash
   ln -s /usr/lib64/dotnet/dotnet /usr/bin/dotnet
   ```

   Now users can simply run `dotnet` and it will work.

3. Create an `/etc/dotnet/install_location` file and add the path of the SDK directory in there. The file should contain a single line like this:

   ```bash
   /usr/lib64/dotnet
   ```

   This file is used by [.NET Core to find the SDK/Runtime location](https://github.com/dotnet/designs/blob/master/accepted/2020/install-locations.md).

4. Define `DOTNET_ROOT` and update `PATH` by saving the following as `/etc/profile.d/dotnet.sh` (or equivalent)

   ```bash
   # Set location for AppHost lookup
   [ -z "$DOTNET_ROOT" ] && export DOTNET_ROOT=/usr/lib64/dotnet

   # Add dotnet tools directory to PATH
   DOTNET_TOOLS_PATH="$HOME/.dotnet/tools"
   case "$PATH" in
       *"$DOTNET_TOOLS_PATH"* ) true ;;
       * ) PATH="$PATH:$DOTNET_TOOLS_PATH" ;;
   esac
   ```

   Make sure to adjust the paths to match what the distribution policies.

   This snippet should work in `sh` (including `dash`) and `bash`. You may need to adapt it, or use something entirely different, for other shells.

   This allows apphost-lookup to work via `DOTNET_ROOT` and allows users to easily use dotnet tools directly after a `dotnet tool install`.

There are other optional things you can do:

- .NET Core source repositories include man pages. You can search for them and package them up: `find -iname '*.1' -exec cp {} /usr/share/man/man1/ \;`

- .NET Core includes [bash-completion](https://github.com/dotnet/cli/blob/master/scripts/register-completions.bash) and [zsh-completion](https://github.com/dotnet/cli/blob/master/scripts/register-completions.zsh) scripts. The copies in the source code you used to build the SDK should be the latest version. See [how to enable tab completion for .NET Core cli](https://docs.microsoft.com/en-us/dotnet/core/tools/enable-tab-autocomplete) for more information.

## Resources and references

- [.NET Core distribution packaging](https://docs.microsoft.com/en-us/dotnet/core/distribution-packaging)
- [Fedora .NET Core 3.1 package](https://src.fedoraproject.org/rpms/dotnet3.1/tree/master)
- [.NET Core - ArchWiki](https://wiki.archlinux.org/index.php/.NET_Core)
- [State of .NET Core on Arch - a discussion between a few distribution package maintainers](https://www.reddit.com/r/archlinux/comments/cx64r5/the_state_of_net_core_on_arch/)
