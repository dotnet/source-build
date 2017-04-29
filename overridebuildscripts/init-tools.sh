#!/usr/bin/env bash

__scriptpath=$(cd "$(dirname "$0")"; pwd -P)
__init_tools_log=$__scriptpath/init-tools.log
__PACKAGES_DIR=$__scriptpath/packages
if [ ! -z $PACKAGES_DIR ];then __PACKAGES_DIR=$PACKAGES_DIR; fi
__TOOLRUNTIME_DIR=$__scriptpath/Tools
__TOOLOVERRIDE_DIR=$__scriptpath/Tools-Override
__DOTNET_PATH=$__TOOLRUNTIME_DIR/dotnetcli
if [ ! -z $DOTNET_DIR ];then __DOTNET_PATH=$DOTNET_DIR; fi
__DOTNET_CMD=$__DOTNET_PATH/dotnet
__BUILD_TOOLS_PACKAGE_VERSION=$(cat $__scriptpath/BuildToolsVersion.txt)
__INIT_TOOLS_DONE_MARKER=$__TOOLRUNTIME_DIR/done

if [ ! -e $__INIT_TOOLS_DONE_MARKER ]; then
    if [ -e $__TOOLRUNTIME_DIR ]; then rm -rf -- $__TOOLRUNTIME_DIR; fi
    echo "Running: $__scriptpath/init-tools.sh" > $__init_tools_log
    
    if [ ! -e $__DOTNET_PATH ]; then
        mkdir -p "$__DOTNET_PATH" 
        if [ -n "$DOTNET_TOOLSET_DIR" ]; then
            echo "Copying $DOTNET_TOOLSET_DIR to $__DOTNET_PATH" >> $__init_tools_log
            cp -r $DOTNET_TOOLSET_DIR/* $__DOTNET_PATH
        fi
    fi
    
    if [ -n "$BUILD_TOOLS_TOOLSET_DIR" ] && [ -d "$BUILD_TOOLS_TOOLSET_DIR/$__BUILD_TOOLS_PACKAGE_VERSION" ]; then
        echo "Initializing BuildTools..."
        echo "Running: $BUILD_TOOLS_TOOLSET_DIR/$__BUILD_TOOLS_PACKAGE_VERSION/lib/init-tools.sh $__scriptpath $__DOTNET_CMD $__TOOLRUNTIME_DIR" >> $__init_tools_log
        $BUILD_TOOLS_TOOLSET_DIR/$__BUILD_TOOLS_PACKAGE_VERSION/lib/init-tools.sh $__scriptpath $__DOTNET_CMD $__TOOLRUNTIME_DIR >> $__init_tools_log
        if [ "$?" != "0" ]; then
            echo "ERROR: An error occured when trying to initialize the tools. Please check '$__init_tools_log' for more details."1>&2
            exit 1
        fi
    fi
    
    if [ -e $__TOOLOVERRIDE_DIR ]; then 
        echo Copying supplemental overrides from Tools-Override.
        cp $__TOOLOVERRIDE_DIR/* $__scriptpath/Tools
    fi

    touch $__INIT_TOOLS_DONE_MARKER

    echo "Done initializing tools."
else
    echo "Tools are already initialized"
fi
