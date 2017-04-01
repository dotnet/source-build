# Build from Source - .NET Core Stack

## Instructions on Supported platforms
1. git submodule update --init --update
2. bootstrap/bootstrap.sh
3. Tools/dotnetcli/dotnet restore tasks/Microsoft.Dotnet.SourceBuild.Tasks/Microsoft.Dotnet.SourceBuild.Tasks.csproj
4. Tools/dotnetcli/dotnet build tasks/Microsoft.Dotnet.SourceBuild.Tasks/Microsoft.Dotnet.SourceBuild.Tasks.csproj
5. Tools/dotnetcli/dotnet Tools/dotnetcli/sdk/1.0.0/MSBuild.dll /t:WriteDynamicPropsToStaticPropsFiles /p:GeneratingStaticPropertiesFile=true
6. Tools/dotnetcli/dotnet Tools/dotnetcli/sdk/1.0.0/MSBuild.dll /t:Sync
7. Tools/dotnetcli/dotnet Tools/dotnetcli/sdk/1.0.0/MSBuild.dll /t:GenerateSourceTarball