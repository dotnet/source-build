#!/usr/bin/env bash

while true ; do
	case "$1" in
		-c|--clear-cache) CLEAR_CACHE=1 ; shift ;;
        --skip-build) SKIP_BUILD=true ; shift ;;
        --skip-test) SKIP_TEST=true ; shift ;;
		--) shift ; break ;;
		*) shift ; break ;;
	esac
done

RESULTCODE=0

if [ -z $DOTNET_INSTALL_DIR ];then
    # Download the CLI install script to cli
    echo "Installing dotnet CLI"
    mkdir -p cli
    curl -o cli/dotnet-install.sh https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0-preview2/scripts/obtain/dotnet-install.sh
    
    # Run install.sh for cli
    chmod +x cli/dotnet-install.sh
    cli/dotnet-install.sh -i cli -c preview -v 1.0.0-preview2-003121
fi
if [ -z $TEST_DOTNET_INSTALL_DIR ];then
# Download the CLI install script to cli test
    echo "Installing dotnet CLI test"
    mkdir -p cli_test
    curl -o cli_test/dotnet-install.sh https://raw.githubusercontent.com/dotnet/cli/d2bbe1faa294012cec60b640e6522e0674224d3f/scripts/obtain/dotnet-install.sh
    
    # Run install.sh fot cli test
    chmod +x cli_test/dotnet-install.sh
    cli_test/dotnet-install.sh -i cli_test -c preview -v 1.0.0-rc4-004788
fi

# Display current version
test_dotnet_install_dir="$(pwd)/cli_test"
[ -z $TEST_DOTNET_INSTALL_DIR ] || test_dotnet_install_dir=$TEST_DOTNET_INSTALL_DIR
dotnet_install_dir="$(pwd)/cli"
[ -z $DOTNET_INSTALL_DIR ] || dotnet_install_dir=$DOTNET_INSTALL_DIR
DOTNET="$dotnet_install_dir/dotnet"
$DOTNET --version

echo "================="

# init the repo
git submodule init
git submodule update

# clear caches
if [ "$CLEAR_CACHE" == "1" ]
then
	# echo "Clearing the nuget web cache folder"
	# rm -r -f ~/.local/share/NuGet/*

	echo "Clearing the nuget packages folder"
	rm -r -f ~/.nuget/packages/*
fi

if [ $SKIP_BUILD ];then
    echo "Skipping product build..."
    exit 0
fi

# restore packages
echo "$DOTNET restore src/NuGet.Core test/NuGet.Core.Tests --verbosity minimal"
$DOTNET restore src/NuGet.Core test/NuGet.Core.Tests --verbosity minimal
if [ $? -ne 0 ]; then
	echo "Restore failed!!"
	exit 1
fi

# build xplat dll
echo "$DOTNET build src/NuGet.Core/NuGet.CommandLine.XPlat --configuration release --framework netcoreapp1.0"
$DOTNET build src/NuGet.Core/NuGet.CommandLine.XPlat --configuration release --framework netcoreapp1.0

if [ $SKIP_TEST ];then
    echo "Skipping product build..."
    exit 0
fi

DOTNET="$test_dotnet_install_dir/dotnet"

# run tests
for testProject in `find test/NuGet.Core.Tests -type f -name project.json`
do
	testDir="$(pwd)/$(dirname $testProject)"

	if grep -q "netcoreapp1.0" "$testProject"; then
		pushd $testDir

		case "$(uname -s)" in
			Linux)
				echo "$DOTNET test $testDir --configuration release --framework netcoreapp1.0 -notrait Platform=Windows -notrait Platform=Darwin"
				$DOTNET test $testDir --configuration release --framework netcoreapp1.0 -notrait Platform=Windows -notrait Platform=Darwin
				;;
			Darwin)
				echo "$DOTNET test $testDir --configuration release --framework netcoreapp1.0 -notrait Platform=Windows -notrait Platform=Linux"
				$DOTNET test $testDir --configuration release --framework netcoreapp1.0 -notrait Platform=Windows -notrait Platform=Linux
				;;
			*) ;;
		esac

		if [ $? -ne 0 ]; then
			echo "$testDir FAILED on CoreCLR"
			RESULTCODE=1
		fi

		popd
	else
		echo "Skipping the tests in $testDir on CoreCLR"
	fi

done

exit $RESULTCODE
