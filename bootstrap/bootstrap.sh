#!/usr/bin/env bash

# Stop script on NZEC
set -e
# Stop script if unbound variable found (use ${var:-} if intentional)
set -u
# By default cmd1 | cmd2 returns exit code of cmd2 regardless of cmd1 success
# This is causing it to fail
set -o pipefail

# Use in the the functions: eval $invocation
invocation='say_verbose "Calling: ${FUNCNAME[0]}"'

# standard output may be used as a return value in the functions
# we need a way to write text on the screen in the functions so that
# it won't interfere with the return value.
# Exposing stream 3 as a pipe to standard output of the script itself
exec 3>&1

say_err() {
    printf "%b\n" "bootstrap: Error: $1" >&2
}

say() {
    # using stream 3 (defined in the beginning) to not interfere with stdout of functions
    # which may be used as return value
    printf "%b\n" "bootstrap: $1" >&3
}

say_verbose() {
    if [ "$verbose" = true ]; then
        say "$1"
    fi
}

machine_has() {
    eval $invocation
    
    hash "$1" > /dev/null 2>&1
    return $?
}

check_min_reqs() {
    if ! machine_has "curl"; then
        say_err "curl is required to download dotnet. Install curl to proceed."
        return 1
    fi
    
    return 0
}

# args:
# remote_path - $1
# [out_path] - $2 - stdout if not provided
download() {
    eval $invocation
    
    local remote_path=$1
    local out_path=${2:-}

    local failed=false
    if [ -z "$out_path" ]; then
        curl --retry 10 -sSL --create-dirs $remote_path || failed=true
    else
        curl --retry 10 -sSL --create-dirs -o $out_path $remote_path || failed=true
    fi
    
    if [ "$failed" = true ]; then
        say_err "Download failed"
        return 1
    fi
}

verbose=false
repoRoot=$(cd "$(dirname "$0")/../" ; pwd -P)
toolsLocalPath="<auto>"
cliLocalPath="<auto>"
pjCliLocalPath="<auto>"
symlinkPath="<auto>"
sharedFxVersion="<auto>"
force=
forcedCliLocalPath="<none>"
forcedPjCliLocalPath="<none>"
architecture="<auto>"
dotNetInstallBranch="rel/1.0.0"
pjDotNetInstallBranch="rel/1.0.0-preview2.1"

while [ $# -ne 0 ]
do
    name=$1
    case $name in
        -r|--repositoryRoot|-[Rr]epositoryRoot)
            shift
            repoRoot="$1"
            ;;
        -t|--toolsLocalPath|-[Tt]oolsLocalPath)
            shift
            toolsLocalPath="$1"
            ;;
        -c|--cliInstallPath|--cliLocalPath|-[Cc]liLocalPath)
            shift
            cliLocalPath="$1"
            ;;
        -u|--useLocalCli|-[Uu]seLocalCli)
            shift
            forcedCliLocalPath="$1"
            ;;
        -a|--architecture|-[Aa]rchitecture)
            shift
            architecture="$1"
            ;;
        --dotNetInstallBranch|-[Dd]ot[Nn]et[Ii]nstall[Bb]ranch)
            shift
            dotNetInstallBranch="$1"
            ;;
        --sharedFrameworkSymlinkPath|--symlink|-[Ss]haredFrameworkSymlinkPath)
            shift
            symlinkPath="$1"
            ;;
        --sharedFrameworkVersion|-[Ss]haredFrameworkVersion)
            sharedFxVersion="$1"
            ;;
        --force|-[Ff]orce)
            force=true
            ;;
        -v|--verbose|-[Vv]erbose)
            verbose=true
            ;;
        *)
            say_err "Unknown argument \`$name\`"
            exit 1
            ;;
    esac

    shift
done

if [ $toolsLocalPath = "<auto>" ]; then
    toolsLocalPath="$repoRoot/Tools"
fi

if [ $cliLocalPath = "<auto>" ]; then
    if [ $forcedCliLocalPath = "<none>" ]; then
        cliLocalPath="$toolsLocalPath/dotnetcli"
    else
        cliLocalPath=$forcedCliLocalPath
    fi
fi

if [ $pjCliLocalPath = "<auto>" ]; then
    if [ $forcedPjCliLocalPath = "<none>" ]; then
        pjCliLocalPath="$toolsLocalPath/pjdotnetcli"
    else
        pjCliLocalPath=$forcedPjCliLocalPath
    fi
fi

if [ $symlinkPath = "<auto>" ]; then
    symlinkPath="$toolsLocalPath/dotnetcli/shared/Microsoft.NETCore.App/version"
fi

rootToolVersions="$repoRoot/.toolversions"
bootstrapComplete="$toolsLocalPath/bootstrap.complete"

# if the force switch is specified delete the semaphore file if it exists
if [[ $force && -f $bootstrapComplete ]]; then
    rm -f $bootstrapComplete
fi

# if the semaphore file exists and is identical to the specified version then exit
if [[ -f $bootstrapComplete && ! `cmp $bootstrapComplete $rootToolVersions` ]]; then
    say "$bootstrapComplete appears to show that bootstrapping is complete.  Use --force if you want to re-bootstrap."
    exit 0
fi

initCliScript="dotnet-install.sh"
dotnetInstallPath="$toolsLocalPath/$initCliScript"
pjDotnetInstallPath="$toolsLocalPath/pj$initCliScript"

# blow away the tools directory so we can start from a known state
if [ -d $toolsLocalPath ]; then
    # if the bootstrap.sh script was downloaded to the tools directory don't delete it
    find $toolsLocalPath -type f -not -name bootstrap.sh -exec rm -f {} \;
else
    mkdir $toolsLocalPath
fi

if [ $forcedCliLocalPath = "<none>" ]; then
    check_min_reqs

    # download CLI boot-strapper script
    download "https://raw.githubusercontent.com/dotnet/cli/$dotNetInstallBranch/scripts/obtain/dotnet-install.sh" "$dotnetInstallPath"
    chmod u+x "$dotnetInstallPath"

    # load the version of the CLI
    rootCliVersion="$repoRoot/.cliversion"
    dotNetCliVersion=`cat $rootCliVersion`

    if [ ! -e $cliLocalPath ]; then
        mkdir -p "$cliLocalPath"
    fi

    # now execute the script
    say_verbose "installing CLI: $dotnetInstallPath --version \"$dotNetCliVersion\" --install-dir $cliLocalPath --architecture \"$architecture\""
    $dotnetInstallPath --version "$dotNetCliVersion" --install-dir $cliLocalPath --architecture "$architecture"
    if [ $? != 0 ]; then
        say_err "The .NET CLI installation failed with exit code $?"
        exit $?
    fi
fi

if [ $forcedPjCliLocalPath = "<none>" ]; then
    check_min_reqs

    # download CLI boot-strapper script
    download "https://raw.githubusercontent.com/dotnet/cli/$pjDotNetInstallBranch/scripts/obtain/dotnet-install.sh" "$pjDotnetInstallPath"
    chmod u+x "$pjDotnetInstallPath"

    # load the version of the CLI
    rootCliVersion="$repoRoot/.cliversion"
    dotNetCliVersion=`cat $rootCliVersion`

    if [ ! -e $pjCliLocalPath ]; then
        mkdir -p "$pjCliLocalPath"
    fi

    # now execute the script
    say_verbose "installing CLI: $pjDotnetInstallPath --install-dir $pjCliLocalPath --architecture \"$architecture\""
    $pjDotnetInstallPath --install-dir $pjCliLocalPath --architecture "$architecture"
    if [ $? != 0 ]; then
        say_err "The .NET CLI installation failed with exit code $?"
        exit $?
    fi
fi

runtimesPath="$cliLocalPath/shared/Microsoft.NETCore.App"
if [ $sharedFxVersion = "<auto>" ]; then
    # OSX doesn't support --version-sort, https://stackoverflow.com/questions/21394536/how-to-simulate-sort-v-on-mac-osx
    sharedFxVersion=`ls $runtimesPath | sed 's/^[0-9]\./0&/; s/\.\([0-9]\)$/.0\1/; s/\.\([0-9]\)\./.0\1./g; s/\.\([0-9]\)\./.0\1./g' | sort -r | sed 's/^0// ; s/\.0/./g' | head -n 1`
fi

# create a junction to the shared FX version directory. this is
# so we have a stable path to dotnet.exe regardless of version.
junctionTarget="$runtimesPath/$sharedFxVersion"
junctionParent="$(dirname "$symlinkPath")"

if [ ! -d $junctionParent ]; then
    mkdir -p $junctionParent
fi

if [ ! -e $symlinkPath ]; then
    ln -s $junctionTarget $symlinkPath
fi

# create a project.json for the packages to restore
projectJson="$toolsLocalPath/project.csproj"
propsString=''
targetsString=''
pjContent=$'<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">\n'
pjContent="$pjContent"$'  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" />\n'
pjContent="$pjContent  <PropertyGroup><TargetFramework>netstandard1.4</TargetFramework></PropertyGroup>"$'\n'
pjContent="$pjContent  <ItemGroup>"$'\n'

while read v; do
    IFS='=' read -r -a line <<< "$v"
    pjContent="$pjContent    <PackageReference Include=\"${line[0]}\"><Version>${line[1]}</Version></PackageReference>"$'\n'
done <$rootToolVersions
pjContent="$pjContent  </ItemGroup>"$'\n'
pjContent="$pjContent"$'  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />\n'
pjContent="$pjContent</Project>"
echo "$pjContent" > "$projectJson"

# now restore the packages
buildToolsSource="${BUILDTOOLS_SOURCE:-https://dotnet.myget.org/F/dotnet-buildtools/api/v3/index.json}"
nugetOrgSource="https://api.nuget.org/v3/index.json"

packagesPath="$repoRoot/packages"
dotNetExe="$cliLocalPath/dotnet"
restoreArgs="restore $projectJson --packages $packagesPath --source $buildToolsSource --source $nugetOrgSource"
say_verbose "Running $dotNetExe $restoreArgs"
$dotNetExe $restoreArgs
if [ $? != 0 ]; then
    say_err "project.json restore failed with exit code $?"
    exit $?
fi

# now stage the contents to tools directory and run any init scripts
while read v; do
    IFS='=' read -r -a line <<< "$v"
    id=$(echo "${line[0]}" | tr '[:upper:]' '[:lower:]')
    version="${line[1]}"
    # verify that the version we expect is what was restored
    pkgVerPath="$packagesPath/$id/$version"
    if [ ! -d $pkgVerPath ]; then
        say_err "Directory $pkgVerPath doesn't exist, ensure that the version restore matches the version specified."
        exit 1
    fi
    # at present we have the following conventions when staging package content:
    #   1.  if a package contains a "tools" directory then recursively copy its contents
    #       to a directory named the package ID that's under $ToolsLocalPath.
    #   2.  if a package contains a "libs" directory then recursively copy its contents
    #       under the $ToolsLocalPath directory.
    #   3.  if a package contains a file "lib\init-tools.cmd" execute it.
    if [ -d "$pkgVerPath/tools" ]; then
        destination="$toolsLocalPath/$id"
        mkdir -p $destination
        cp -r $pkgVerPath/* $destination
    fi
    if [ -d "$pkgVerPath/lib" ]; then
        cp -r $pkgVerPath/lib/* $toolsLocalPath
    fi
    if [ -f "$pkgVerPath/lib/init-tools.sh" ]; then
        (
            set +e
            "$pkgVerPath/lib/init-tools.sh" "$repoRoot" "$dotNetExe" "$toolsLocalPath" > "init-$id.log"
            if [ $? -ne 0 ]; then
                say "$pkgVerPath/lib/init-tools.sh: non-zero exit code. Ignoring. CLI mismatch is likely."
                exit 0
            fi
        )
    fi
done <$rootToolVersions

cp $rootToolVersions $bootstrapComplete
DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

say "Bootstrap finished successfully."

