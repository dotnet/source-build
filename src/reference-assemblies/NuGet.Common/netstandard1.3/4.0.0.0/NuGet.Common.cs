[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("NuGet v3 core library.")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.0.2283")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.0-rtm-2283")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("NuGet")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3")]
namespace NuGet.Common
{
    public static partial class ActivityCorrelationId
    {
        public static string Current { get { throw null; } }
        public static void Clear() { }
        public static void StartNew() { }
    }
    public partial class AggregateEnumerableAsync<T> : NuGet.Common.IEnumerableAsync<T>
    {
        public AggregateEnumerableAsync(System.Collections.Generic.IList<NuGet.Common.IEnumerableAsync<T>> asyncEnumerables, System.Collections.Generic.IComparer<T> comparer, System.Collections.Generic.IEqualityComparer<T> equalityComparer) { }
        public NuGet.Common.IEnumeratorAsync<T> GetEnumeratorAsync() { throw null; }
    }
    public partial class AggregateEnumeratorAsync<T> : NuGet.Common.IEnumeratorAsync<T>
    {
        public AggregateEnumeratorAsync(System.Collections.Generic.IList<NuGet.Common.IEnumerableAsync<T>> asyncEnumerables, System.Collections.Generic.IComparer<T> orderingComparer, System.Collections.Generic.IEqualityComparer<T> equalityComparer) { }
        public T Current { get { throw null; } }
        public System.Threading.Tasks.Task<bool> MoveNextAsync() { throw null; }
    }
    public static partial class AsyncLazy
    {
        public static NuGet.Common.AsyncLazy<T> New<T>(System.Func<System.Threading.Tasks.Task<T>> asyncValueFactory) { throw null; }
        public static NuGet.Common.AsyncLazy<T> New<T>(System.Func<T> valueFactory) { throw null; }
        public static NuGet.Common.AsyncLazy<T> New<T>(System.Lazy<System.Threading.Tasks.Task<T>> inner) { throw null; }
        public static NuGet.Common.AsyncLazy<T> New<T>(T innerData) { throw null; }
    }
    [System.CLSCompliantAttribute(true)]
    public partial class AsyncLazy<T>
    {
        public AsyncLazy(System.Func<System.Threading.Tasks.Task<T>> valueFactory) { }
        public AsyncLazy(System.Lazy<System.Threading.Tasks.Task<T>> inner) { }
        public System.Runtime.CompilerServices.TaskAwaiter<T> GetAwaiter() { throw null; }
        public static implicit operator System.Lazy<System.Threading.Tasks.Task<T>> (NuGet.Common.AsyncLazy<T> outer) { throw null; }
    }
    public static partial class ClientVersionUtility
    {
        public static string GetNuGetAssemblyVersion() { throw null; }
    }
    public partial class CollectorLogger : NuGet.Common.ICollectorLogger, NuGet.Common.ILogger
    {
        public CollectorLogger(NuGet.Common.ILogger innerLogger) { }
        public System.Collections.Generic.IEnumerable<string> Errors { get { throw null; } }
        public void LogDebug(string data) { }
        public void LogError(string data) { }
        public void LogErrorSummary(string data) { }
        public void LogInformation(string data) { }
        public void LogInformationSummary(string data) { }
        public void LogMinimal(string data) { }
        public void LogVerbose(string data) { }
        public void LogWarning(string data) { }
    }
    public static partial class ConcurrencyUtilities
    {
        public static void ExecuteWithFileLocked(string filePath, System.Action action) { }
        public static System.Threading.Tasks.Task<T> ExecuteWithFileLockedAsync<T>(string filePath, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<T>> action, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class CryptoHashProvider
    {
        public CryptoHashProvider() { }
        public CryptoHashProvider(string hashAlgorithm) { }
        public byte[] CalculateHash(byte[] data) { throw null; }
        public byte[] CalculateHash(System.IO.Stream stream) { throw null; }
        public bool VerifyHash(byte[] data, byte[] hash) { throw null; }
    }
    public partial class CultureUtility
    {
        public CultureUtility() { }
        public static void DisableLocalization() { }
    }
    public partial class DatetimeUtility
    {
        public DatetimeUtility() { }
        public static string ToReadableTimeFormat(System.TimeSpan time) { throw null; }
    }
    public static partial class DirectoryUtility
    {
        public static void CreateSharedDirectory(string path) { }
    }
    public partial class EnvironmentVariableWrapper : NuGet.Common.IEnvironmentVariableReader
    {
        public EnvironmentVariableWrapper() { }
        public string GetEnvironmentVariable(string variable) { throw null; }
    }
    public partial class ExceptionLogger
    {
        public ExceptionLogger(NuGet.Common.IEnvironmentVariableReader reader) { }
        public static NuGet.Common.ExceptionLogger Instance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool ShowStack { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public static partial class ExceptionUtilities
    {
        public static string DisplayMessage(System.AggregateException exception) { throw null; }
        public static string DisplayMessage(System.Exception exception) { throw null; }
        public static string DisplayMessage(System.Exception exception, bool indent) { throw null; }
        public static string DisplayMessage(System.Reflection.TargetInvocationException exception) { throw null; }
        public static System.Exception Unwrap(System.Exception exception) { throw null; }
    }
    public static partial class FileUtility
    {
        public static readonly int MaxTries;
        public static void Delete(string path) { }
        public static System.Threading.Tasks.Task DeleteWithLock(string filePath) { throw null; }
        public static string GetTempFilePath(string directory) { throw null; }
        public static void Move(string sourceFileName, string destFileName) { }
        public static void Replace(System.Action<string> writeSourceFile, string destFilePath) { }
        public static void Replace(string sourceFileName, string destFileName) { }
        public static System.Threading.Tasks.Task ReplaceWithLock(System.Action<string> writeSourceFile, string destFilePath) { throw null; }
    }
    public partial interface ICollectorLogger : NuGet.Common.ILogger
    {
        System.Collections.Generic.IEnumerable<string> Errors { get; }
    }
    public partial interface IEnumerableAsync<T>
    {
        NuGet.Common.IEnumeratorAsync<T> GetEnumeratorAsync();
    }
    public partial interface IEnumeratorAsync<T>
    {
        T Current { get; }
        System.Threading.Tasks.Task<bool> MoveNextAsync();
    }
    public partial interface IEnvironmentVariableReader
    {
        string GetEnvironmentVariable(string variable);
    }
    public partial interface ILogger
    {
        void LogDebug(string data);
        void LogError(string data);
        void LogErrorSummary(string data);
        void LogInformation(string data);
        void LogInformationSummary(string data);
        void LogMinimal(string data);
        void LogVerbose(string data);
        void LogWarning(string data);
    }
    public partial interface INuGetPathContext
    {
        System.Collections.Generic.IReadOnlyList<string> FallbackPackageFolders { get; }
        string HttpCacheFolder { get; }
        string UserPackageFolder { get; }
    }
    public partial class LocalResourceUtils
    {
        public LocalResourceUtils() { }
        public static void DeleteDirectoryTree(string folderPath, System.Collections.Generic.List<string> failedDeletes) { }
    }
    public enum LogLevel
    {
        Debug = 0,
        Error = 5,
        Information = 2,
        Minimal = 3,
        Verbose = 1,
        Warning = 4,
    }
    public static partial class NetworkProtocolUtility
    {
        public static void ConfigureSupportedSslProtocols() { }
        public static void SetConnectionLimit() { }
    }
    public static partial class NuGetEnvironment
    {
        public static string GetDotNetLocation() { throw null; }
        public static string GetFolderPath(NuGet.Common.NuGetFolderPath folder) { throw null; }
    }
    public enum NuGetFolderPath
    {
        DefaultMsBuildPath = 5,
        HttpCacheDirectory = 3,
        MachineWideConfigDirectory = 1,
        MachineWideSettingsBaseDirectory = 0,
        NuGetHome = 4,
        Temp = 6,
        UserSettingsDirectory = 2,
    }
    public partial class NullLogger : NuGet.Common.ILogger
    {
        public NullLogger() { }
        public static NuGet.Common.ILogger Instance { get { throw null; } }
        public void LogDebug(string data) { }
        public void LogError(string data) { }
        public void LogErrorSummary(string data) { }
        public void LogInformation(string data) { }
        public void LogInformationSummary(string data) { }
        public void LogMinimal(string data) { }
        public void LogVerbose(string data) { }
        public void LogWarning(string data) { }
    }
    public static partial class PathResolver
    {
        public static void FilterPackageFiles<T>(System.Collections.Generic.ICollection<T> source, System.Func<T, string> getPath, System.Collections.Generic.IEnumerable<string> wildcards) { }
        public static System.Collections.Generic.IEnumerable<T> GetMatches<T>(System.Collections.Generic.IEnumerable<T> source, System.Func<T, string> getPath, System.Collections.Generic.IEnumerable<string> wildcards) { throw null; }
        public static bool IsDirectoryPath(string path) { throw null; }
        public static bool IsWildcardSearch(string filter) { throw null; }
        public static string NormalizeWildcardForExcludedFiles(string basePath, string wildcard) { throw null; }
        public static System.Collections.Generic.IEnumerable<string> PerformWildcardSearch(string basePath, string searchPath) { throw null; }
        public static System.Collections.Generic.IEnumerable<NuGet.Common.PathResolver.SearchPathResult> PerformWildcardSearch(string basePath, string searchPath, bool includeEmptyDirectories, out string normalizedBasePath) { normalizedBasePath = default(string); throw null; }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct SearchPathResult
        {
            public SearchPathResult(string path, bool isFile) { throw null;}
            public bool IsFile { get { throw null; } }
            public string Path { get { throw null; } }
        }
    }
    public static partial class PathUtility
    {
        public static string EnsureTrailingSlash(string path) { throw null; }
        public static string GetPathWithForwardSlashes(string path) { throw null; }
        public static System.StringComparer GetStringComparerBasedOnOS() { throw null; }
        public static System.Collections.Generic.IEnumerable<string> GetUniquePathsBasedOnOS(System.Collections.Generic.IEnumerable<string> paths) { throw null; }
    }
    public static partial class PathValidator
    {
        public static bool IsValidLocalPath(string path) { throw null; }
        public static bool IsValidRelativePath(string path) { throw null; }
        public static bool IsValidSource(string source) { throw null; }
        public static bool IsValidUncPath(string path) { throw null; }
        public static bool IsValidUrl(string url) { throw null; }
    }
    public partial class Preprocessor
    {
        public Preprocessor() { }
        public static string Process(System.Func<System.IO.Stream> fileStreamFactory, System.Func<string, string> tokenReplacement) { throw null; }
        public static string Process(System.IO.Stream stream, System.Func<string, string> tokenReplacement) { throw null; }
    }
    public partial class ProjectJsonPathUtilities
    {
        public static readonly string ProjectConfigFileEnding;
        public static readonly string ProjectConfigFileName;
        public static readonly string ProjectLockFileName;
        public ProjectJsonPathUtilities() { }
        public static string GetLockFilePath(string configFilePath) { throw null; }
        public static string GetProjectConfigPath(string directoryPath, string projectName) { throw null; }
        public static string GetProjectConfigWithProjectName(string projectName) { throw null; }
        public static string GetProjectLockFileNameWithProjectName(string projectName) { throw null; }
        public static string GetProjectNameFromConfigFileName(string configPath) { throw null; }
        public static bool IsProjectConfig(string configPath) { throw null; }
    }
    public static partial class RuntimeEnvironmentHelper
    {
        public static bool IsDev14 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public static bool IsLinux { get { throw null; } }
        public static bool IsMacOSX { get { throw null; } }
        public static bool IsMono { get { throw null; } }
        public static bool IsWindows { get { throw null; } }
    }
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public partial class Strings
    {
        internal Strings() { }
        public static string AbsolutePathRequired { get { throw null; } }
        public static string ArgumentNullOrEmpty { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public static string Error_FailedToCreateRandomFile { get { throw null; } }
        public static string NoPackageFoldersFound { get { throw null; } }
        public static string PackageFolderNotFound { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Resources.ResourceManager ResourceManager { get { throw null; } }
        public static string UnableToDetemineClientVersion { get { throw null; } }
        public static string UnauthorizedLockFail { get { throw null; } }
        public static string UnsupportedHashAlgorithm { get { throw null; } }
    }
    public partial class Token
    {
        public Token(NuGet.Common.TokenCategory category, string value) { }
        public NuGet.Common.TokenCategory Category { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Value { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public enum TokenCategory
    {
        Text = 0,
        Variable = 1,
    }
    public partial class Tokenizer
    {
        public Tokenizer(string text) { }
        public NuGet.Common.Token Read() { throw null; }
    }
    public static partial class UriUtility
    {
        public static System.Uri CreateSourceUri(string source, System.UriKind kind=(System.UriKind)(1)) { throw null; }
        public static string GetLocalPath(string localOrUriPath) { throw null; }
        public static System.Uri TryCreateSourceUri(string source, System.UriKind kind) { throw null; }
        public static string UrlEncodeOdataParameter(string value) { throw null; }
    }
}
