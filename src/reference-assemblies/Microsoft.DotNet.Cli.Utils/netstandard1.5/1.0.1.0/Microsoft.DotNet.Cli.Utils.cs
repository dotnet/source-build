[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft.DotNet.Cli.Utils")]
[assembly:System.Reflection.AssemblyConfigurationAttribute("Release")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("Package Description")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.1.0")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.1")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft.DotNet.Cli.Utils")]
[assembly:System.Reflection.AssemblyTitleAttribute("Microsoft.DotNet.Cli.Utils")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("dotnet, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Microsoft.DotNet.Cli.Utils.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Microsoft.DotNet.ProjectJsonMigration, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Microsoft.DotNet.Tools.Test, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Microsoft.DotNet.Tools.Tests.Utilities, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.5", FrameworkDisplayName="")]
namespace Microsoft.DotNet.Cli.Utils
{
    public abstract partial class AbstractPathBasedCommandResolver : Microsoft.DotNet.Cli.Utils.ICommandResolver
    {
        protected Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory _commandSpecFactory;
        protected Microsoft.DotNet.Cli.Utils.IEnvironmentProvider _environment;
        public AbstractPathBasedCommandResolver(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory commandSpecFactory) { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments commandResolverArguments) { throw null; }
    }
    public static partial class AnsiColorExtensions
    {
        public static string Black(this string text) { throw null; }
        public static string Blue(this string text) { throw null; }
        public static string Bold(this string text) { throw null; }
        public static string Cyan(this string text) { throw null; }
        public static string Green(this string text) { throw null; }
        public static string Magenta(this string text) { throw null; }
        public static string Red(this string text) { throw null; }
        public static string White(this string text) { throw null; }
        public static string Yellow(this string text) { throw null; }
    }
    public partial class AnsiConsole
    {
        internal AnsiConsole() { }
        public System.ConsoleColor OriginalForegroundColor { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.IO.TextWriter Writer { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static Microsoft.DotNet.Cli.Utils.AnsiConsole GetError() { throw null; }
        public static Microsoft.DotNet.Cli.Utils.AnsiConsole GetOutput() { throw null; }
        public void Write(string message) { }
        public void WriteLine(string message) { }
    }
    public partial class AppBaseCommandResolver : Microsoft.DotNet.Cli.Utils.AbstractPathBasedCommandResolver
    {
        public AppBaseCommandResolver(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory commandSpecFactory) : base (default(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider), default(Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory)) { }
    }
    public partial class AppBaseDllCommandResolver : Microsoft.DotNet.Cli.Utils.ICommandResolver
    {
        public AppBaseDllCommandResolver() { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments commandResolverArguments) { throw null; }
    }
    public static partial class ArgumentEscaper
    {
        public static string EscapeAndConcatenateArgArrayForCmdProcessStart(System.Collections.Generic.IEnumerable<string> args) { throw null; }
        public static string EscapeAndConcatenateArgArrayForProcessStart(System.Collections.Generic.IEnumerable<string> args) { throw null; }
        public static string EscapeSingleArg(string arg) { throw null; }
    }
    public sealed partial class BlockingMemoryStream : System.IO.Stream
    {
        public BlockingMemoryStream() { }
        public override bool CanRead { get { throw null; } }
        public override bool CanSeek { get { throw null; } }
        public override bool CanWrite { get { throw null; } }
        public override long Length { get { throw null; } }
        public override long Position { get { throw null; } set { } }
        protected override void Dispose(bool disposing) { }
        public void DoneWriting() { }
        public override void Flush() { }
        public override int Read(byte[] buffer, int offset, int count) { throw null; }
        public override long Seek(long offset, System.IO.SeekOrigin origin) { throw null; }
        public override void SetLength(long value) { }
        public override void Write(byte[] buffer, int offset, int count) { }
    }
    public partial class BuiltInCommand : Microsoft.DotNet.Cli.Utils.ICommand
    {
        public BuiltInCommand(string commandName, System.Collections.Generic.IEnumerable<string> commandArgs, System.Func<string[], int> builtInCommand) { }
        public string CommandArgs { get { throw null; } }
        public string CommandName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy ResolutionStrategy { get { throw null; } }
        public Microsoft.DotNet.Cli.Utils.ICommand CaptureStdErr() { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand CaptureStdOut() { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand EnvironmentVariable(string name, string value) { throw null; }
        public Microsoft.DotNet.Cli.Utils.CommandResult Execute() { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand ForwardStdErr(System.IO.TextWriter to=null, bool onlyIfVerbose=false, bool ansiPassThrough=true) { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand ForwardStdOut(System.IO.TextWriter to=null, bool onlyIfVerbose=false, bool ansiPassThrough=true) { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand OnErrorLine(System.Action<string> handler) { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand OnOutputLine(System.Action<string> handler) { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand WorkingDirectory(string workingDirectory) { throw null; }
    }
    public static partial class CollectionsExtensions
    {
        public static System.Collections.Generic.IEnumerable<T> OrEmptyIfNull<T>(this System.Collections.Generic.IEnumerable<T> enumerable) { throw null; }
    }
    public partial class Command : Microsoft.DotNet.Cli.Utils.ICommand
    {
        internal Command() { }
        public string CommandArgs { get { throw null; } }
        public string CommandName { get { throw null; } }
        public Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy ResolutionStrategy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Microsoft.DotNet.Cli.Utils.ICommand CaptureStdErr() { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand CaptureStdOut() { throw null; }
        public static Microsoft.DotNet.Cli.Utils.Command Create(Microsoft.DotNet.Cli.Utils.CommandSpec commandSpec) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.Command Create(Microsoft.DotNet.Cli.Utils.ICommandResolverPolicy commandResolverPolicy, string commandName, System.Collections.Generic.IEnumerable<string> args, NuGet.Frameworks.NuGetFramework framework=null, string configuration="Debug", string outputPath=null, string applicationName=null) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.Command Create(string commandName, System.Collections.Generic.IEnumerable<string> args, NuGet.Frameworks.NuGetFramework framework=null, string configuration="Debug", string outputPath=null, string applicationName=null) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.Command CreateDotNet(string commandName, System.Collections.Generic.IEnumerable<string> args, NuGet.Frameworks.NuGetFramework framework=null, string configuration="Debug") { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand EnvironmentVariable(string name, string value) { throw null; }
        public Microsoft.DotNet.Cli.Utils.CommandResult Execute() { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand ForwardStdErr(System.IO.TextWriter to=null, bool onlyIfVerbose=false, bool ansiPassThrough=true) { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand ForwardStdOut(System.IO.TextWriter to=null, bool onlyIfVerbose=false, bool ansiPassThrough=true) { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand OnErrorLine(System.Action<string> handler) { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand OnOutputLine(System.Action<string> handler) { throw null; }
        public Microsoft.DotNet.Cli.Utils.ICommand WorkingDirectory(string projectDirectory) { throw null; }
    }
    public static partial class CommandContext
    {
        public static bool IsVerbose() { throw null; }
        public static void SetVerbose(bool value) { }
        public static bool ShouldPassAnsiCodesThrough() { throw null; }
        public static partial class Variables
        {
            public static readonly string AnsiPassThru;
            public static readonly string Verbose;
        }
    }
    public partial class CommandFactory : Microsoft.DotNet.Cli.Utils.ICommandFactory
    {
        public CommandFactory() { }
        public Microsoft.DotNet.Cli.Utils.ICommand Create(string commandName, System.Collections.Generic.IEnumerable<string> args, NuGet.Frameworks.NuGetFramework framework=null, string configuration="Debug") { throw null; }
    }
    public enum CommandResolutionStrategy
    {
        BaseDirectory = 3,
        DepsFile = 0,
        None = 8,
        OutputPath = 7,
        Path = 5,
        ProjectDependenciesPackage = 1,
        ProjectLocal = 4,
        ProjectToolsPackage = 2,
        RootedPath = 6,
    }
    public partial class CommandResolverArguments
    {
        public CommandResolverArguments() { }
        public string ApplicationName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string BuildBasePath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> CommandArguments { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string CommandName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Configuration { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string DepsJsonFile { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Frameworks.NuGetFramework Framework { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> InferredExtensions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string OutputPath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string ProjectDirectory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct CommandResult
    {
        public static readonly Microsoft.DotNet.Cli.Utils.CommandResult Empty;
        public CommandResult(System.Diagnostics.ProcessStartInfo startInfo, int exitCode, string stdOut, string stdErr) { throw null;}
        public int ExitCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Diagnostics.ProcessStartInfo StartInfo { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string StdErr { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string StdOut { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class CommandSpec
    {
        public CommandSpec(string path, string args, Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy resolutionStrategy, System.Collections.Generic.Dictionary<string, string> environmentVariables=null) { }
        public string Args { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.Dictionary<string, string> EnvironmentVariables { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy ResolutionStrategy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class CommandUnknownException : Microsoft.DotNet.Cli.Utils.GracefulException
    {
        public CommandUnknownException(string commandName) : base (default(string)) { }
        public CommandUnknownException(string commandName, System.Exception innerException) : base (default(string)) { }
    }
    public partial class CompositeCommandResolver : Microsoft.DotNet.Cli.Utils.ICommandResolver
    {
        public CompositeCommandResolver() { }
        public System.Collections.Generic.IEnumerable<Microsoft.DotNet.Cli.Utils.ICommandResolver> OrderedCommandResolvers { get { throw null; } }
        public void AddCommandResolver(Microsoft.DotNet.Cli.Utils.ICommandResolver commandResolver) { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments commandResolverArguments) { throw null; }
    }
    public static partial class Constants
    {
        public static readonly string BinDirectoryName;
        public static readonly string ConfigSuffix;
        public const string DefaultConfiguration = "Debug";
        public static readonly string DynamicLibSuffix;
        public static readonly string ExeSuffix;
        public static readonly string[] HostBinaryNames;
        public static readonly string HostExecutableName;
        public static readonly string[] LibCoreClrBinaryNames;
        public static readonly string LibCoreClrFileName;
        public static readonly string LibCoreClrName;
        public static readonly string MSBUILD_EXE_PATH;
        public static readonly string ObjDirectoryName;
        public static readonly string ProjectArgumentName;
        public static readonly string ProjectFileName;
        public static readonly string PublishedHostExecutableName;
        public static readonly string ResponseFileSuffix;
        public static readonly string[] RunnableSuffixes;
        public static readonly string SolutionArgumentName;
        public static readonly string StaticLibSuffix;
    }
    public static partial class CoreHost
    {
        public static string HostExePath { get { throw null; } }
        public static void CopyTo(string destinationPath, string hostExeName) { }
    }
    public static partial class DebugHelper
    {
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void HandleDebugSwitch(ref string[] args) { }
        public static void WaitForDebugger() { }
    }
    public partial class DefaultCommandResolverPolicy : Microsoft.DotNet.Cli.Utils.ICommandResolverPolicy
    {
        public DefaultCommandResolverPolicy() { }
        public static Microsoft.DotNet.Cli.Utils.CompositeCommandResolver Create() { throw null; }
        public Microsoft.DotNet.Cli.Utils.CompositeCommandResolver CreateCommandResolver() { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CompositeCommandResolver CreateDefaultCommandResolver(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPackagedCommandSpecFactory packagedCommandSpecFactory, Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory platformCommandSpecFactory, Microsoft.DotNet.Cli.Utils.IPublishedPathCommandSpecFactory publishedPathCommandSpecFactory) { throw null; }
    }
    public partial class DepsJsonCommandFactory : Microsoft.DotNet.Cli.Utils.ICommandFactory
    {
        public DepsJsonCommandFactory(string depsJsonFile, string runtimeConfigFile, string nugetPackagesRoot, string temporaryDirectory) { }
        public Microsoft.DotNet.Cli.Utils.ICommand Create(string commandName, System.Collections.Generic.IEnumerable<string> args, NuGet.Frameworks.NuGetFramework framework=null, string configuration="Debug") { throw null; }
    }
    public partial class DepsJsonCommandResolver : Microsoft.DotNet.Cli.Utils.ICommandResolver
    {
        public DepsJsonCommandResolver(Microsoft.DotNet.Cli.Utils.Muxer muxer, string nugetPackageRoot) { }
        public DepsJsonCommandResolver(string nugetPackageRoot) { }
        public string GetCommandPathFromDependencyContext(string commandName, Microsoft.Extensions.DependencyModel.DependencyContext dependencyContext) { throw null; }
        public Microsoft.Extensions.DependencyModel.DependencyContext LoadDependencyContextFromFile(string depsJsonFile) { throw null; }
        public Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments commandResolverArguments) { throw null; }
    }
    public static partial class Env
    {
        public static System.Collections.Generic.IEnumerable<string> ExecutableExtensions { get { throw null; } }
        public static string GetCommandPath(string commandName, params string[] extensions) { throw null; }
        public static string GetCommandPathFromRootPath(string rootPath, string commandName, System.Collections.Generic.IEnumerable<string> extensions) { throw null; }
        public static string GetCommandPathFromRootPath(string rootPath, string commandName, params string[] extensions) { throw null; }
        public static bool GetEnvironmentVariableAsBool(string name, bool defaultValue=false) { throw null; }
    }
    public partial class EnvironmentProvider : Microsoft.DotNet.Cli.Utils.IEnvironmentProvider
    {
        public EnvironmentProvider(System.Collections.Generic.IEnumerable<string> extensionsOverride=null, System.Collections.Generic.IEnumerable<string> searchPathsOverride=null) { }
        public System.Collections.Generic.IEnumerable<string> ExecutableExtensions { get { throw null; } }
        public string GetCommandPath(string commandName, params string[] extensions) { throw null; }
        public string GetCommandPathFromRootPath(string rootPath, string commandName, System.Collections.Generic.IEnumerable<string> extensions) { throw null; }
        public string GetCommandPathFromRootPath(string rootPath, string commandName, params string[] extensions) { throw null; }
        public string GetEnvironmentVariable(string name) { throw null; }
        public bool GetEnvironmentVariableAsBool(string name, bool defaultValue) { throw null; }
    }
    internal static partial class ExceptionExtensions
    {
        public static TException DisplayAsError<TException>(this TException exception) where TException : System.Exception { throw null; }
        public static void ReportAsWarning(this System.Exception e) { throw null; }
        public static bool ShouldBeDisplayedAsError(this System.Exception e) { throw null; }
    }
    public static partial class FileAccessRetrier
    {
        public static System.Threading.Tasks.Task<T> RetryOnFileAccessFailure<T>(System.Func<T> func, int maxRetries=3000, System.TimeSpan sleepDuration=default(System.TimeSpan)) { throw null; }
    }
    public static partial class FileNameSuffixes
    {
        public const string DepsJson = ".deps.json";
        public const string RuntimeConfigDevJson = ".runtimeconfig.dev.json";
        public const string RuntimeConfigJson = ".runtimeconfig.json";
        public static Microsoft.DotNet.Cli.Utils.FileNameSuffixes.PlatformFileNameSuffixes CurrentPlatform { get { throw null; } }
        public static Microsoft.DotNet.Cli.Utils.FileNameSuffixes.PlatformFileNameSuffixes DotNet { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static Microsoft.DotNet.Cli.Utils.FileNameSuffixes.PlatformFileNameSuffixes Linux { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static Microsoft.DotNet.Cli.Utils.FileNameSuffixes.PlatformFileNameSuffixes OSX { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static Microsoft.DotNet.Cli.Utils.FileNameSuffixes.PlatformFileNameSuffixes Windows { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct PlatformFileNameSuffixes
        {
            public string DynamicLib { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
            public string Exe { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
            public string ProgramDatabase { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
            public string StaticLib { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        }
    }
    public partial class GenericPlatformCommandSpecFactory : Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory
    {
        public GenericPlatformCommandSpecFactory() { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec CreateCommandSpec(string commandName, System.Collections.Generic.IEnumerable<string> args, string commandPath, Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy resolutionStrategy, Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment) { throw null; }
    }
    public partial class GracefulException : System.Exception
    {
        public GracefulException(string message) { }
        public GracefulException(string message, System.Exception innerException) { }
        public GracefulException(string format, params string[] args) { }
    }
    public partial interface ICommand
    {
        string CommandArgs { get; }
        string CommandName { get; }
        Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy ResolutionStrategy { get; }
        Microsoft.DotNet.Cli.Utils.ICommand CaptureStdErr();
        Microsoft.DotNet.Cli.Utils.ICommand CaptureStdOut();
        Microsoft.DotNet.Cli.Utils.ICommand EnvironmentVariable(string name, string value);
        Microsoft.DotNet.Cli.Utils.CommandResult Execute();
        Microsoft.DotNet.Cli.Utils.ICommand ForwardStdErr(System.IO.TextWriter to=null, bool onlyIfVerbose=false, bool ansiPassThrough=true);
        Microsoft.DotNet.Cli.Utils.ICommand ForwardStdOut(System.IO.TextWriter to=null, bool onlyIfVerbose=false, bool ansiPassThrough=true);
        Microsoft.DotNet.Cli.Utils.ICommand OnErrorLine(System.Action<string> handler);
        Microsoft.DotNet.Cli.Utils.ICommand OnOutputLine(System.Action<string> handler);
        Microsoft.DotNet.Cli.Utils.ICommand WorkingDirectory(string projectDirectory);
    }
    public partial interface ICommandFactory
    {
        Microsoft.DotNet.Cli.Utils.ICommand Create(string commandName, System.Collections.Generic.IEnumerable<string> args, NuGet.Frameworks.NuGetFramework framework=null, string configuration="Debug");
    }
    public partial interface ICommandResolver
    {
        Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments arguments);
    }
    public partial interface ICommandResolverPolicy
    {
        Microsoft.DotNet.Cli.Utils.CompositeCommandResolver CreateCommandResolver();
    }
    public partial interface IEnvironmentProvider
    {
        System.Collections.Generic.IEnumerable<string> ExecutableExtensions { get; }
        string GetCommandPath(string commandName, params string[] extensions);
        string GetCommandPathFromRootPath(string rootPath, string commandName, System.Collections.Generic.IEnumerable<string> extensions);
        string GetCommandPathFromRootPath(string rootPath, string commandName, params string[] extensions);
        string GetEnvironmentVariable(string name);
        bool GetEnvironmentVariableAsBool(string name, bool defaultValue);
    }
    public partial class InvalidProjectException : System.Exception
    {
        public InvalidProjectException() { }
        public InvalidProjectException(string message) { }
        public InvalidProjectException(string message, System.Exception innerException) { }
    }
    public partial interface IPackagedCommandSpecFactory
    {
        Microsoft.DotNet.Cli.Utils.CommandSpec CreateCommandSpecFromLibrary(NuGet.ProjectModel.LockFileTargetLibrary toolLibrary, string commandName, System.Collections.Generic.IEnumerable<string> commandArguments, System.Collections.Generic.IEnumerable<string> allowedExtensions, string nugetPackagesRoot, Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy commandResolutionStrategy, string depsFilePath, string runtimeConfigPath);
    }
    public partial interface IPlatformCommandSpecFactory
    {
        Microsoft.DotNet.Cli.Utils.CommandSpec CreateCommandSpec(string commandName, System.Collections.Generic.IEnumerable<string> args, string commandPath, Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy resolutionStrategy, Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment);
    }
    public partial interface IPublishedPathCommandSpecFactory
    {
        Microsoft.DotNet.Cli.Utils.CommandSpec CreateCommandSpecFromPublishFolder(string commandPath, System.Collections.Generic.IEnumerable<string> commandArguments, Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy commandResolutionStrategy, string depsFilePath, string runtimeConfigPath);
    }
    public static partial class LockFileFormatExtensions
    {
        public static System.Threading.Tasks.Task<NuGet.ProjectModel.LockFile> ReadWithLock(this NuGet.ProjectModel.LockFileFormat subject, string path) { throw null; }
    }
    public partial class Muxer
    {
        public static readonly string MuxerName;
        public Muxer() { }
        public string MuxerPath { get { throw null; } }
        public static string GetDataFromAppDomain(string propertyName) { throw null; }
    }
    public partial class MuxerCommandResolver : Microsoft.DotNet.Cli.Utils.ICommandResolver
    {
        public MuxerCommandResolver() { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments commandResolverArguments) { throw null; }
    }
    public partial class OutputPathCommandResolver : Microsoft.DotNet.Cli.Utils.AbstractPathBasedCommandResolver
    {
        public OutputPathCommandResolver(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory commandSpecFactory) : base (default(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider), default(Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory)) { }
    }
    public partial class PackagedCommandSpecFactory : Microsoft.DotNet.Cli.Utils.IPackagedCommandSpecFactory
    {
        internal PackagedCommandSpecFactory() { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec CreateCommandSpecFromLibrary(NuGet.ProjectModel.LockFileTargetLibrary toolLibrary, string commandName, System.Collections.Generic.IEnumerable<string> commandArguments, System.Collections.Generic.IEnumerable<string> allowedExtensions, string nugetPackagesRoot, Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy commandResolutionStrategy, string depsFilePath, string runtimeConfigPath) { throw null; }
    }
    public partial class PackagedCommandSpecFactoryWithCliRuntime : Microsoft.DotNet.Cli.Utils.PackagedCommandSpecFactory
    {
        public PackagedCommandSpecFactoryWithCliRuntime() { }
    }
    public partial class PathCommandResolver : Microsoft.DotNet.Cli.Utils.AbstractPathBasedCommandResolver
    {
        public PathCommandResolver(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory commandSpecFactory) : base (default(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider), default(Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory)) { }
    }
    public partial class PathCommandResolverPolicy : Microsoft.DotNet.Cli.Utils.ICommandResolverPolicy
    {
        public PathCommandResolverPolicy() { }
        public static Microsoft.DotNet.Cli.Utils.CompositeCommandResolver Create() { throw null; }
        public Microsoft.DotNet.Cli.Utils.CompositeCommandResolver CreateCommandResolver() { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CompositeCommandResolver CreatePathCommandResolverPolicy(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory platformCommandSpecFactory) { throw null; }
    }
    public static partial class PerfTrace
    {
        public static Microsoft.DotNet.Cli.Utils.PerfTraceThreadContext Current { get { throw null; } }
        public static bool Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public static System.Collections.Generic.IEnumerable<Microsoft.DotNet.Cli.Utils.PerfTraceThreadContext> GetEvents() { throw null; }
    }
    public partial class PerfTraceEvent
    {
        public PerfTraceEvent(string type, string instance, System.Collections.Generic.IEnumerable<Microsoft.DotNet.Cli.Utils.PerfTraceEvent> children, System.DateTime startUtc, System.TimeSpan duration) { }
        public System.Collections.Generic.IList<Microsoft.DotNet.Cli.Utils.PerfTraceEvent> Children { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.TimeSpan Duration { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Instance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.DateTime StartUtc { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Type { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class PerfTraceOutput
    {
        public PerfTraceOutput() { }
        public static void Print(Microsoft.DotNet.Cli.Utils.Reporter reporter, System.Collections.Generic.IEnumerable<Microsoft.DotNet.Cli.Utils.PerfTraceThreadContext> contexts) { }
    }
    public partial class PerfTraceThreadContext
    {
        public PerfTraceThreadContext(int threadId) { }
        public Microsoft.DotNet.Cli.Utils.PerfTraceEvent Root { get { throw null; } }
        public System.IDisposable CaptureTiming(string instance="", [System.Runtime.CompilerServices.CallerMemberNameAttribute]string memberName="", [System.Runtime.CompilerServices.CallerFilePathAttribute]string filePath="") { throw null; }
    }
    public partial class Product
    {
        public static readonly string LongName;
        public static readonly string Version;
        public Product() { }
    }
    public partial class ProjectDependenciesCommandFactory : Microsoft.DotNet.Cli.Utils.ICommandFactory
    {
        public ProjectDependenciesCommandFactory(NuGet.Frameworks.NuGetFramework nugetFramework, string configuration, string outputPath, string buildBasePath, string projectDirectory) { }
        public Microsoft.DotNet.Cli.Utils.ICommand Create(string commandName, System.Collections.Generic.IEnumerable<string> args, NuGet.Frameworks.NuGetFramework framework=null, string configuration=null) { throw null; }
    }
    public partial class ProjectDependenciesCommandResolver : Microsoft.DotNet.Cli.Utils.ICommandResolver
    {
        public ProjectDependenciesCommandResolver(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPackagedCommandSpecFactory packagedCommandSpecFactory) { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments commandResolverArguments) { throw null; }
    }
    public partial class ProjectPathCommandResolver : Microsoft.DotNet.Cli.Utils.AbstractPathBasedCommandResolver
    {
        public ProjectPathCommandResolver(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory commandSpecFactory) : base (default(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider), default(Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory)) { }
    }
    public partial class ProjectToolsCommandResolver : Microsoft.DotNet.Cli.Utils.ICommandResolver
    {
        public ProjectToolsCommandResolver(Microsoft.DotNet.Cli.Utils.IPackagedCommandSpecFactory packagedCommandSpecFactory, Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment) { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments commandResolverArguments) { throw null; }
    }
    public partial class PublishedPathCommandFactory : Microsoft.DotNet.Cli.Utils.ICommandFactory
    {
        public PublishedPathCommandFactory(string publishDirectory, string applicationName) { }
        public Microsoft.DotNet.Cli.Utils.ICommand Create(string commandName, System.Collections.Generic.IEnumerable<string> args, NuGet.Frameworks.NuGetFramework framework=null, string configuration="Debug") { throw null; }
    }
    public partial class PublishedPathCommandResolver : Microsoft.DotNet.Cli.Utils.ICommandResolver
    {
        public PublishedPathCommandResolver(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPublishedPathCommandSpecFactory commandSpecFactory) { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments commandResolverArguments) { throw null; }
    }
    public partial class PublishPathCommandSpecFactory : Microsoft.DotNet.Cli.Utils.IPublishedPathCommandSpecFactory
    {
        public PublishPathCommandSpecFactory() { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec CreateCommandSpecFromPublishFolder(string commandPath, System.Collections.Generic.IEnumerable<string> commandArguments, Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy commandResolutionStrategy, string depsFilePath, string runtimeConfigPath) { throw null; }
    }
    public partial class Reporter
    {
        internal Reporter() { }
        public static Microsoft.DotNet.Cli.Utils.Reporter Error { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static bool IsVerbose { get { throw null; } }
        public static Microsoft.DotNet.Cli.Utils.Reporter Output { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static Microsoft.DotNet.Cli.Utils.Reporter Verbose { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static void Reset() { }
        public void Write(string message) { }
        public void WriteLine() { }
        public void WriteLine(string message) { }
    }
    public partial class RootedCommandResolver : Microsoft.DotNet.Cli.Utils.ICommandResolver
    {
        public RootedCommandResolver() { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec Resolve(Microsoft.DotNet.Cli.Utils.CommandResolverArguments commandResolverArguments) { throw null; }
    }
    public partial class RuntimeConfig
    {
        public RuntimeConfig(string runtimeConfigPath) { }
        public Microsoft.DotNet.Cli.Utils.RuntimeConfigFramework Framework { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool IsPortable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static bool IsApplicationPortable(string entryAssemblyPath) { throw null; }
    }
    public partial class RuntimeConfigFramework
    {
        public RuntimeConfigFramework() { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public static Microsoft.DotNet.Cli.Utils.RuntimeConfigFramework ParseFromFrameworkRoot(Newtonsoft.Json.Linq.JObject framework) { throw null; }
    }
    public static partial class RuntimeEnvironmentRidExtensions
    {
        public static System.Collections.Generic.IEnumerable<string> GetAllCandidateRuntimeIdentifiers() { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetAllCandidateRuntimeIdentifiers(System.Collections.Generic.IEnumerable<string> fallbackIdentifiers=null) { throw null; }
        public static string GetLegacyRestoreRuntimeIdentifier() { throw null; }
    }
    public partial class ScriptCommandResolverPolicy
    {
        public ScriptCommandResolverPolicy() { }
        public static Microsoft.DotNet.Cli.Utils.CompositeCommandResolver Create() { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CompositeCommandResolver CreateScriptCommandResolver(Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment, Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory platformCommandSpecFactory) { throw null; }
    }
    public sealed partial class StreamForwarder
    {
        public StreamForwarder() { }
        public string CapturedOutput { get { throw null; } }
        public System.Threading.Tasks.Task BeginRead(System.IO.TextReader reader) { throw null; }
        public Microsoft.DotNet.Cli.Utils.StreamForwarder Capture() { throw null; }
        public Microsoft.DotNet.Cli.Utils.StreamForwarder ForwardTo(System.Action<string> writeLine) { throw null; }
        public void Read(System.IO.TextReader reader) { }
    }
    public partial class ToolPathCalculator
    {
        public ToolPathCalculator(string packagesDirectory) { }
        public string GetBestLockFilePath(string packageId, NuGet.Versioning.VersionRange versionRange, NuGet.Frameworks.NuGetFramework framework) { throw null; }
        public string GetLockFilePath(string packageId, NuGet.Versioning.NuGetVersion version, NuGet.Frameworks.NuGetFramework framework) { throw null; }
    }
    public partial class WindowsExePreferredCommandSpecFactory : Microsoft.DotNet.Cli.Utils.IPlatformCommandSpecFactory
    {
        public WindowsExePreferredCommandSpecFactory() { }
        public Microsoft.DotNet.Cli.Utils.CommandSpec CreateCommandSpec(string commandName, System.Collections.Generic.IEnumerable<string> args, string commandPath, Microsoft.DotNet.Cli.Utils.CommandResolutionStrategy resolutionStrategy, Microsoft.DotNet.Cli.Utils.IEnvironmentProvider environment) { throw null; }
    }
}
namespace Microsoft.DotNet.Cli.Utils.CommandParsing
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct Chain<TLeft, TDown>
    {
        public readonly TDown Down;
        public readonly TLeft Left;
        public Chain(TLeft left, TDown down) { throw null;}
    }
    public partial class CommandGrammar : Microsoft.DotNet.Cli.Utils.CommandParsing.Grammar
    {
        internal CommandGrammar() { }
        public readonly Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<System.Collections.Generic.IList<string>> Parse;
        public static string[] Process(string text, System.Func<string, string> variables, bool preserveSurroundingQuotes) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct Cursor
    {
        public Cursor(string text, int start, int end) { throw null;}
        public bool IsEnd { get { throw null; } }
        public Microsoft.DotNet.Cli.Utils.CommandParsing.Result<TValue> Advance<TValue>(TValue result, int length) { throw null; }
        public char Peek(int index) { throw null; }
    }
    public partial class Grammar
    {
        public Grammar() { }
        protected static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<char> Ch() { throw null; }
        protected static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<char> Ch(char ch) { throw null; }
        protected static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<System.Collections.Generic.IList<TValue>> Rep1<TValue>(Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<TValue> parser) { throw null; }
        protected static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<System.Collections.Generic.IList<TValue>> Rep<TValue>(Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<TValue> parser) { throw null; }
    }
    public static partial class ParserExtensions
    {
        public static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<Microsoft.DotNet.Cli.Utils.CommandParsing.Chain<T1, T2>> And<T1, T2>(this Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T1> parser1, Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T2> parser2) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T2> Build<T1, T2>(this Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T1> parser, System.Func<T1, T2> builder) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T2> Down<T1, T2>(this Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<Microsoft.DotNet.Cli.Utils.CommandParsing.Chain<T1, T2>> parser) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T1> Left<T1, T2>(this Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<Microsoft.DotNet.Cli.Utils.CommandParsing.Chain<T1, T2>> parser) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T1> Not<T1, T2>(this Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T1> parser1, Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T2> parser2) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T1> Or<T1>(this Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T1> parser1, Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<T1> parser2) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<string> Str(this Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<System.Collections.Generic.IList<char>> parser) { throw null; }
        public static Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<string> Str(this Microsoft.DotNet.Cli.Utils.CommandParsing.Parser<System.Collections.Generic.IList<string>> parser) { throw null; }
    }
    public delegate Microsoft.DotNet.Cli.Utils.CommandParsing.Result<TValue> Parser<TValue>(Microsoft.DotNet.Cli.Utils.CommandParsing.Cursor cursor);
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct Result<TValue>
    {
        public readonly Microsoft.DotNet.Cli.Utils.CommandParsing.Cursor Remainder;
        public readonly TValue Value;
        public Result(TValue value, Microsoft.DotNet.Cli.Utils.CommandParsing.Cursor remainder) { throw null;}
        public static Microsoft.DotNet.Cli.Utils.CommandParsing.Result<TValue> Empty { get { throw null; } }
        public bool IsEmpty { get { throw null; } }
        public Microsoft.DotNet.Cli.Utils.CommandParsing.Result<TValue2> AsValue<TValue2>(TValue2 value2) { throw null; }
    }
}
namespace Microsoft.DotNet.Tools.Common
{
    public static partial class PathUtility
    {
        public static void EnsureAllPathsExist(System.Collections.Generic.List<string> paths, string pathDoesNotExistLocalizedFormatString) { }
        public static void EnsureDirectoryExists(string directoryPath) { }
        public static string EnsureNoTrailingDirectorySeparator(string path) { throw null; }
        public static void EnsureParentDirectoryExists(string filePath) { }
        public static string EnsureTrailingForwardSlash(string path) { throw null; }
        public static string EnsureTrailingSlash(string path) { throw null; }
        public static string GetAbsolutePath(string basePath, string relativePath) { throw null; }
        public static string GetDirectoryName(string path) { throw null; }
        public static string GetFullPath(string path) { throw null; }
        public static string GetPathWithBackSlashes(string path) { throw null; }
        public static string GetPathWithDirectorySeparator(string path) { throw null; }
        public static string GetPathWithForwardSlashes(string path) { throw null; }
        public static string GetRelativePath(System.IO.DirectoryInfo directory, System.IO.FileSystemInfo childItem) { throw null; }
        public static string GetRelativePath(string path1, string path2) { throw null; }
        public static string GetRelativePath(string path1, string path2, char separator, bool includeDirectoryTraversals) { throw null; }
        public static string GetRelativePathIgnoringDirectoryTraversals(string path1, string path2) { throw null; }
        public static bool HasExtension(string filePath, string extension) { throw null; }
        public static bool IsChildOfDirectory(string dir, string candidate) { throw null; }
        public static bool IsPlaceholderFile(string path) { throw null; }
        public static string RemoveExtraPathSeparators(string path) { throw null; }
        public static bool TryDeleteDirectory(string directoryPath) { throw null; }
    }
}
