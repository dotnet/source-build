## Build Requirements and Prerequisites

Please click on the link below that matches your machine and ensure you have installed all the prerequisites for the build to work.  

|**Chip** | **Linux**  |**Windows** |**MacOS**|
|:--------------:|:----------------:|:--------------:|:----------------:|
|x64|Supported |Not Supported|Not Supported|
|x86|Not Supported |Not Supported|Not Supported|
|ARM64|Supported |Not Supported|Not Supported|
||[Prerequisites](https://github.com/dotnet/runtime/blob/main/docs/workflow/requirements/linux-requirements.md)|||

Additionally, keep in mind that cloning takes roughly 1.5GB of network transfer, inflating to a repository that can consume somewhere around 600 MB. A build of the repo can take somewhere around 80 GB of space for a single OS and Platform configuration. This might increase over time, so consider this to be a minimum bar for working with this codebase.

Note:  
.NET Source-Build is supported on the oldest available .NET SDK feature update. For example, if both .NET 6.0.1XX and 6.0.2XX feature updates are available from dotnet.microsoft.com, Source-Build will support 6.0.1XX.