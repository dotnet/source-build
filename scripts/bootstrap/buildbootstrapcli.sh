#!/usr/bin/env bash
set -e
set -o pipefail

usage()
{
    echo "Builds a bootstrap CLI from sources"
    echo "Usage: $0 [BuildType] --rid <Rid> --seedcli <SeedCli> [--arch <Architecture>] [--os <OS>] [--clang <Major.Minor>] [--corelib <CoreLib>] [--crossgen]"
    echo ""
    echo "Options:"
    echo "  BuildType               Type of build (-debug, -release), default: -debug"
    echo "  -arch <Architecture>    Architecture (x64, x86, arm, arm64, armel), default: x64"
    echo "  -clang <Major.Minor>    Override of the version of clang compiler to use"
    echo "  -config <Configuration> Build configuration (debug, release), default: debug"
    echo "  -corelib <CoreLib>      Path to System.Private.CoreLib.dll, default: use the System.Private.CoreLib.dll from the seed CLI"
    echo "  -os <OS>                Operating system (used for corefx build), default: Linux"
    echo "  -rid <Rid>              Runtime identifier (without the architecture part)"
    echo "  -seedcli <SeedCli>      Seed CLI used to generate the target CLI"
}

disable_pax_mprotect()
{
    if [[ $(command -v paxctl) ]]; then
        paxctl -c -m $1
    fi
}

get_max_version()
{
    local maxversionhi=0
    local maxversionmid=0
    local maxversionlo=0
    local maxversiontag
    local versionrest
    local versionhi
    local versionmid
    local versionlo
    local versiontag
    local foundmax

    for d in $1/*; do

        if [[ -d $d ]]; then
            versionrest=$(basename $d)
            versionhi=${versionrest%%.*}
            versionrest=${versionrest#*.}
            versionmid=${versionrest%%.*}
            versionrest=${versionrest#*.}
            versionlo=${versionrest%%-*}
            versiontag=${versionrest#*-}
            if [[ $versiontag == $versionrest ]]; then
                versiontag=""
            fi

            foundmax=0

            if [[ $versionhi -gt $maxversionhi ]]; then
                foundmax=1
            elif [[ $versionhi -eq $maxversionhi ]]; then
                if [[ $versionmid -gt $maxversionmid ]]; then
                    foundmax=1
                elif [[ $versionmid -eq $maxversionmid ]]; then
                    if [[ $versionlo -gt $maxversionlo ]]; then
                    foundmax=1
                    elif [[ $versionlo -eq $maxversionlo ]]; then
                        # tags are used to mark pre-release versions, so a version without a tag
                        # is newer than a version with one.
                        if [[ "$versiontag" == "" || $versiontag > $maxversiontag ]]; then
                            foundmax=1
                        fi
                    fi
                fi
            fi

            if [[ $foundmax != 0 ]]; then
                maxversionhi=$versionhi
                maxversionmid=$versionmid
                maxversionlo=$versionlo
                maxversiontag=$versiontag
            fi
        fi
    done

    echo $maxversionhi.$maxversionmid.$maxversionlo${maxversiontag:+-$maxversiontag}
}

__build_arch=x64
__build_os=Linux
__runtime_id=
__corelib=
__configuration=debug
__clangversion=

while [[ "$1" != "" ]]; do
    lowerI="$(echo $1 | awk '{print tolower($0)}')"
    case $lowerI in
    -h|--help)
        usage
        exit 1
        ;;
    -arch)
        shift
        __build_arch=$1
        ;;
    -rid)
        shift
        __runtime_id=$1
        ;;
    -os)
        shift
        __build_os=$1
        ;;
    -debug)
        __configuration=debug
        ;;
    -release)
        __configuration=release
        ;;
    -corelib)
        shift
        __corelib=$1
        ;;
    -seedcli)
        shift
        __seedclipath=$1
        ;;
    -clang)
        shift
        __clangversion=clang$1
        ;;
     *)
    echo "Unknown argument to build.sh $1"; exit 1
    esac
    shift
done

# NOTE: when realpath is not present, use readlink -e or readlink --canonicalize depending on the platform
__seedclipath=`realpath $__seedclipath`

mkdir -p $__runtime_id-$__build_arch
cd $__runtime_id-$__build_arch

if [[ -d dotnetcli ]]; then
    /bin/rm -r dotnetcli
fi
mkdir -p dotnetcli
cp -r $__seedclipath/* dotnetcli

__frameworkversion="2.0.0"
__sdkversion="2.0.0"
__fxrversion="2.0.0"

echo "**** DETECTING VERSIONS IN SEED CLI ****"

__frameworkversion=`get_max_version dotnetcli/shared/Microsoft.NETCore.App`
__sdkversion=`get_max_version dotnetcli/sdk`
__fxrversion=`get_max_version dotnetcli/host/fxr`

echo "Framework version: $__frameworkversion"
echo "SDK version:       $__sdkversion"
echo "FXR version:       $__fxrversion"

__frameworkpath="dotnetcli/shared/Microsoft.NETCore.App/$__frameworkversion"

echo "**** DETECTING GIT COMMIT HASHES ****"

# Extract the git commit hashes representig the state of the three repos that
# the seed cli package was built from
__coreclrhash=`strings $__seedclipath/shared/Microsoft.NETCore.App/$__frameworkversion/libcoreclr.so | grep "@(#)" | grep -o "[a-f0-9]\{40\}"`
__corefxhash=`strings $__seedclipath/shared/Microsoft.NETCore.App/$__frameworkversion/System.Native.so | grep "@(#)" | grep -o "[a-f0-9]\{40\}"`
__coresetuphash=`strings $__seedclipath/dotnet | grep "[a-f0-9]\{40\}"`

echo "coreclr hash:    $__coreclrhash"
echo "corefx hash:     $__corefxhash"
echo "core-setup hash: $__coresetuphash"

# Clone the three repos if they were not clonned yet. If the folders already
# exist, leave them alone. This allows patching the cloned sources as needed

if [[ ! -d coreclr ]]; then
    echo "**** CLONING CORECLR REPOSITORY ****"
    git clone https://github.com/dotnet/coreclr.git
    cd coreclr
    git checkout $__coreclrhash
    cd ..
fi

if [[ ! -d corefx ]]; then
    echo "**** CLONING COREFX REPOSITORY ****"
    git clone https://github.com/dotnet/corefx.git
    cd  corefx
    git checkout $__corefxhash
    cd ..
fi

if [[ ! -d core-setup ]]; then
    echo "**** CLONING CORE-SETUP REPOSITORY ****"
    git clone https://github.com/dotnet/core-setup.git
    cd  core-setup
    git checkout $__coresetuphash
    cd ..
fi

echo "**** BUILDING CORE-SETUP NATIVE COMPONENTS ****"
cd core-setup
src/corehost/build.sh --arch "$__build_arch" --hostver "2.0.0" --apphostver "2.0.0" --fxrver "2.0.0" --policyver "2.0.0" --commithash `git rev-parse HEAD`
cd ..

echo "**** BUILDING CORECLR NATIVE COMPONENTS ****"
cd coreclr
./build.sh $__configuration $__build_arch $__clangversion 2>&1 | tee coreclr.log
export __coreclrbin=$(cat coreclr.log | sed -n -e 's/^.*Product binaries are available at //p')
cd ..
echo "CoreCLR binaries will be copied from $__coreclrbin"

echo "**** BUILDING COREFX NATIVE COMPONENTS ****"
corefx/src/Native/build-native.sh $__build_arch $__configuration $__clangversion $__build_os 2>&1 | tee corefx.log
export __corefxbin=$(cat corefx.log | sed -n -e 's/^.*Build files have been written to: //p')
echo "CoreFX binaries will be copied from $__corefxbin"

echo "**** Copying new binaries to dotnetcli/ ****"

# First copy the coreclr repo binaries
cp $__coreclrbin/*so $__frameworkpath
cp $__coreclrbin/corerun $__frameworkpath
cp $__coreclrbin/crossgen $__frameworkpath

# Mark the coreclr executables as allowed to create executable memory mappings
disable_pax_mprotect $__frameworkpath/corerun
disable_pax_mprotect $__frameworkpath/crossgen

# Now copy the core-setup repo binaries
cp core-setup/cli/exe/dotnet/dotnet dotnetcli
cp core-setup/cli/exe/dotnet/dotnet $__frameworkpath/corehost

cp core-setup/cli/dll/libhostpolicy.so $__frameworkpath
cp core-setup/cli/dll/libhostpolicy.so dotnetcli/sdk/$__sdkversion

cp core-setup/cli/fxr/libhostfxr.so $__frameworkpath
cp core-setup/cli/fxr/libhostfxr.so dotnetcli/host/fxr/$__fxrversion
cp core-setup/cli/fxr/libhostfxr.so dotnetcli/sdk/$__sdkversion

# Mark the core-setup executables as allowed to create executable memory mappings
disable_pax_mprotect dotnetcli/dotnet
disable_pax_mprotect $__frameworkpath/corehost

# Finally copy the corefx repo binaries
cp $__corefxbin/**/System.* $__frameworkpath

# Copy System.Private.CoreLib.dll override from somewhere if requested
if [[ "$__corelib" != "" ]]; then
    cp "$__corelib" $__frameworkpath
fi

# Add the new RID to Microsoft.NETCore.App.deps.json
# Replace the linux-x64 RID in the target, runtimeTarget and runtimes by the new RID
# and add the new RID to the list of runtimes.
echo "**** Adding new rid to Microsoft.NETCore.App.deps.json ****"

#TODO: add parameter with the parent RID sequence

sed \
    -e 's/runtime\.linux-x64/runtime.'$__runtime_id-$__build_arch'/g' \
    -e 's/runtimes\/linux-x64/runtimes\/'$__runtime_id-$__build_arch'/g' \
    -e 's/Version=v\([0-9].[0-9]\)\/linux-x64/Version=v\1\/'$__runtime_id-$__build_arch'/g' \
    -e 's/"runtimes": {/&\n    "'$__runtime_id-$__build_arch'": [\n      "unix", "unix-x64", "any", "base"\n    ],/g' \
$__seedclipath/shared/Microsoft.NETCore.App/$__frameworkversion/Microsoft.NETCore.App.deps.json \
>$__frameworkpath/Microsoft.NETCore.App.deps.json

echo "**** Bootstrap CLI was successfully built  ****"

