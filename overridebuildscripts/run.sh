#!/usr/bin/env bash
working_tree_root="$(cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
toolRuntime=$working_tree_root/Tools
[ -n $TOOLRUNTIME_DIR ] || toolRuntime=$TOOLRUNTIME_DIR
dotnet=$toolRuntime/dotnetcli/dotnet
echo "Running: $dotnet $toolRuntime / run.exe $working_tree_root / config.json $*"
$dotnet $toolRuntime/run.exe $working_tree_root/config.json $*
if [ $? -ne 0 ];then
exit 1
fi
exit 0
