. "$PSScriptRoot/eng/common/tools.ps1"
InitializeToolset
Write-Host "$PSScriptRoot/eng/common/build.ps1 -bl -restore -build -pack -publish /p:Projects=`"$PSScriptRoot/eng/publishPackages/publish.proj`" /p:PublishingToBlobStorage=true /p:DeterministicSourcePaths=false /p:EnableSourceLink=false $args"
Invoke-Expression "$PSScriptRoot/eng/common/build.ps1 -bl -restore -build -pack -publish /p:Projects=`"$PSScriptRoot/eng/publishPackages/publish.proj`" /p:PublishingToBlobStorage=true /p:DeterministicSourcePaths=false /p:EnableSourceLink=false $args"
