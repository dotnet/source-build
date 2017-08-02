[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("NuGet's protocol-level base types used for connecting to API v2 and API v3 repositories.")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("3.5.0.1996")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("3.5.0-rtm-1996")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("NuGet")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3")]
namespace NuGet.Protocol
{
    public enum FeedType
    {
        FileSystemPackagesConfig = 32,
        FileSystemUnknown = 1024,
        FileSystemUnzipped = 16,
        FileSystemV2 = 4,
        FileSystemV3 = 8,
        HttpV2 = 1,
        HttpV3 = 2,
        Undefined = 0,
    }
    public partial class FeedTypePackageSource : NuGet.Configuration.PackageSource
    {
        public FeedTypePackageSource(string source, NuGet.Protocol.FeedType feedType) : base (default(string)) { }
        public NuGet.Protocol.FeedType FeedType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class FeedTypeResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        public FeedTypeResource(NuGet.Protocol.FeedType feedType) { }
        public NuGet.Protocol.FeedType FeedType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
}
namespace NuGet.Protocol.Core.Types
{
    public abstract partial class AutoCompleteResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        protected AutoCompleteResource() { }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string>> IdStartsWith(string packageIdPrefix, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token);
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> VersionStartsWith(string packageId, string versionPrefix, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token);
    }
    public abstract partial class DependencyInfoResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        protected DependencyInfoResource() { }
        public abstract System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.SourcePackageDependencyInfo> ResolvePackage(NuGet.Packaging.Core.PackageIdentity package, NuGet.Frameworks.NuGetFramework projectFramework, NuGet.Common.ILogger log, System.Threading.CancellationToken token);
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.RemoteSourceDependencyInfo>> ResolvePackages(string packageId, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.SourcePackageDependencyInfo>> ResolvePackages(string packageId, NuGet.Frameworks.NuGetFramework projectFramework, NuGet.Common.ILogger log, System.Threading.CancellationToken token);
    }
    public abstract partial class DownloadResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        protected DownloadResource() { }
        public event System.EventHandler<NuGet.Protocol.Core.Types.PackageProgressEventArgs> Progress { add { } remove { } }
        public abstract System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.DownloadResourceResult> GetDownloadResourceResultAsync(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Configuration.ISettings settings, NuGet.Common.ILogger logger, System.Threading.CancellationToken token);
    }
    public partial class DownloadResourceResult : System.IDisposable
    {
        public DownloadResourceResult(NuGet.Protocol.Core.Types.DownloadResourceResultStatus status) { }
        public DownloadResourceResult(System.IO.Stream stream) { }
        public DownloadResourceResult(System.IO.Stream stream, NuGet.Packaging.PackageReaderBase packageReader) { }
        public NuGet.Packaging.PackageReaderBase PackageReader { get { throw null; } }
        public System.IO.Stream PackageStream { get { throw null; } }
        public NuGet.Protocol.Core.Types.DownloadResourceResultStatus Status { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public void Dispose() { }
    }
    public enum DownloadResourceResultStatus
    {
        Available = 0,
        Cancelled = 2,
        NotFound = 1,
    }
    public partial class FatalProtocolException : NuGet.Protocol.Core.Types.NuGetProtocolException
    {
        public FatalProtocolException(string message) : base (default(string)) { }
        public FatalProtocolException(string message, System.Exception innerException) : base (default(string)) { }
    }
    public abstract partial class HttpHandlerResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        protected HttpHandlerResource() { }
        public abstract System.Net.Http.HttpClientHandler ClientHandler { get; }
        public abstract System.Net.Http.HttpMessageHandler MessageHandler { get; }
    }
    public partial class HttpSourceCacheContext
    {
        public HttpSourceCacheContext() { }
        public HttpSourceCacheContext(NuGet.Protocol.Core.Types.SourceCacheContext context) { }
        public HttpSourceCacheContext(NuGet.Protocol.Core.Types.SourceCacheContext context, System.TimeSpan overrideMaxAge) { }
        public System.TimeSpan MaxAge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string RootTempFolder { get { throw null; } }
        public static NuGet.Protocol.Core.Types.HttpSourceCacheContext CreateCacheContext(NuGet.Protocol.Core.Types.SourceCacheContext cacheContext, int retryCount) { throw null; }
    }
    public partial interface INuGetResource
    {
    }
    public partial interface INuGetResourceProvider
    {
        System.Collections.Generic.IEnumerable<string> After { get; }
        System.Collections.Generic.IEnumerable<string> Before { get; }
        string Name { get; }
        System.Type ResourceType { get; }
        System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token);
    }
    public partial interface IPackageSearchMetadata
    {
        string Authors { get; }
        System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> DependencySets { get; }
        string Description { get; }
        System.Nullable<long> DownloadCount { get; }
        System.Uri IconUrl { get; }
        NuGet.Packaging.Core.PackageIdentity Identity { get; }
        System.Uri LicenseUrl { get; }
        string Owners { get; }
        System.Uri ProjectUrl { get; }
        System.Nullable<System.DateTimeOffset> Published { get; }
        System.Uri ReportAbuseUrl { get; }
        bool RequireLicenseAcceptance { get; }
        string Summary { get; }
        string Tags { get; }
        string Title { get; }
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.VersionInfo>> GetVersionsAsync();
    }
    public partial interface ISourceRepositoryProvider
    {
        NuGet.Configuration.IPackageSourceProvider PackageSourceProvider { get; }
        NuGet.Protocol.Core.Types.SourceRepository CreateRepository(NuGet.Configuration.PackageSource source);
        NuGet.Protocol.Core.Types.SourceRepository CreateRepository(NuGet.Configuration.PackageSource source, NuGet.Protocol.FeedType type);
        System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.SourceRepository> GetRepositories();
    }
    public partial class ListCommandResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        public ListCommandResource(string listEndpoint) { }
        public string GetListEndpoint() { throw null; }
    }
    public abstract partial class MetadataResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        protected MetadataResource() { }
        public System.Threading.Tasks.Task<bool> Exists(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public abstract System.Threading.Tasks.Task<bool> Exists(NuGet.Packaging.Core.PackageIdentity identity, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token);
        public System.Threading.Tasks.Task<bool> Exists(string packageId, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public abstract System.Threading.Tasks.Task<bool> Exists(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token);
        public System.Threading.Tasks.Task<NuGet.Versioning.NuGetVersion> GetLatestVersion(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, NuGet.Versioning.NuGetVersion>>> GetLatestVersions(System.Collections.Generic.IEnumerable<string> packageIds, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token);
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetVersions(string packageId, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetVersions(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token);
    }
    public abstract partial class NuGetProtocolException : System.Exception
    {
        public NuGetProtocolException(string message) { }
        public NuGetProtocolException(string message, System.Exception innerException) { }
    }
    public sealed partial class NuGetResourceProviderPositions
    {
        public const string First = "First";
        public const string Last = "Last";
        public NuGetResourceProviderPositions() { }
    }
    public static partial class NuGetTestMode
    {
        public const string NuGetTestClientName = "NuGet Test Client";
        public static bool Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static T InvokeTestFunctionAgainstTestMode<T>(System.Func<T> function, bool testModeEnabled) { throw null; }
    }
    public abstract partial class PackageMetadataResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        protected PackageMetadataResource() { }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.IPackageSearchMetadata>> GetMetadataAsync(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token);
    }
    public partial class PackageProgressEventArgs : System.EventArgs
    {
        public PackageProgressEventArgs(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Configuration.PackageSource source, double complete) { }
        public double Complete { get { throw null; } }
        public bool HasPackageSource { get { throw null; } }
        public bool IsComplete { get { throw null; } }
        public NuGet.Packaging.Core.PackageIdentity PackageIdentity { get { throw null; } }
        public NuGet.Configuration.PackageSource PackageSource { get { throw null; } }
    }
    public partial class PackageSearchMetadataBuilder
    {
        internal PackageSearchMetadataBuilder() { }
        public NuGet.Protocol.Core.Types.IPackageSearchMetadata Build() { throw null; }
        public static NuGet.Protocol.Core.Types.PackageSearchMetadataBuilder FromIdentity(NuGet.Packaging.Core.PackageIdentity identity) { throw null; }
        public static NuGet.Protocol.Core.Types.PackageSearchMetadataBuilder FromMetadata(NuGet.Protocol.Core.Types.IPackageSearchMetadata metadata) { throw null; }
        public NuGet.Protocol.Core.Types.PackageSearchMetadataBuilder WithVersions(NuGet.Common.AsyncLazy<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.VersionInfo>> lazyVersionsFactory) { throw null; }
    }
    public static partial class PackageSearchMetadataExtensions
    {
        public static NuGet.Protocol.Core.Types.IPackageSearchMetadata WithVersions(this NuGet.Protocol.Core.Types.IPackageSearchMetadata metadata, System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.VersionInfo> versions) { throw null; }
        public static NuGet.Protocol.Core.Types.IPackageSearchMetadata WithVersions(this NuGet.Protocol.Core.Types.IPackageSearchMetadata metadata, System.Func<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.VersionInfo>> valueFactory) { throw null; }
        public static NuGet.Protocol.Core.Types.IPackageSearchMetadata WithVersions(this NuGet.Protocol.Core.Types.IPackageSearchMetadata metadata, System.Func<System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.VersionInfo>>> asyncValueFactory) { throw null; }
    }
    public abstract partial class PackageSearchResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        protected PackageSearchResource() { }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.IPackageSearchMetadata>> SearchAsync(string searchTerm, NuGet.Protocol.Core.Types.SearchFilter filters, int skip, int take, NuGet.Common.ILogger log, System.Threading.CancellationToken cancellationToken);
    }
    public partial class RemoteSourceDependencyInfo : System.IEquatable<NuGet.Protocol.Core.Types.RemoteSourceDependencyInfo>
    {
        public RemoteSourceDependencyInfo(NuGet.Packaging.Core.PackageIdentity identity, bool listed, System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> dependencyGroups, string contentUri) { }
        public string ContentUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> DependencyGroups { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.Core.PackageIdentity Identity { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Listed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Equals(NuGet.Protocol.Core.Types.RemoteSourceDependencyInfo other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class Repository
    {
        public static NuGet.Protocol.Core.Types.Repository.RepositoryFactory Factory { get { throw null; } }
        public static NuGet.Protocol.Core.Types.Repository.ProviderFactory Provider { get { throw null; } }
        public static NuGet.Protocol.Core.Types.ISourceRepositoryProvider CreateProvider(System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.INuGetResourceProvider> resourceProviders) { throw null; }
        public static NuGet.Protocol.Core.Types.ISourceRepositoryProvider CreateProvider(System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.INuGetResourceProvider> resourceProviders, string rootPath) { throw null; }
        public static NuGet.Protocol.Core.Types.SourceRepository CreateSource(System.Collections.Generic.IEnumerable<System.Lazy<NuGet.Protocol.Core.Types.INuGetResourceProvider>> resourceProviders, NuGet.Configuration.PackageSource source) { throw null; }
        public static NuGet.Protocol.Core.Types.SourceRepository CreateSource(System.Collections.Generic.IEnumerable<System.Lazy<NuGet.Protocol.Core.Types.INuGetResourceProvider>> resourceProviders, NuGet.Configuration.PackageSource source, NuGet.Protocol.FeedType type) { throw null; }
        public static NuGet.Protocol.Core.Types.SourceRepository CreateSource(System.Collections.Generic.IEnumerable<System.Lazy<NuGet.Protocol.Core.Types.INuGetResourceProvider>> resourceProviders, string sourceUrl) { throw null; }
        public static NuGet.Protocol.Core.Types.SourceRepository CreateSource(System.Collections.Generic.IEnumerable<System.Lazy<NuGet.Protocol.Core.Types.INuGetResourceProvider>> resourceProviders, string sourceUrl, NuGet.Protocol.FeedType type) { throw null; }
        public partial class ProviderFactory
        {
            public ProviderFactory() { }
        }
        public partial class RepositoryFactory
        {
            public RepositoryFactory() { }
        }
    }
    public abstract partial class ResourceProvider : NuGet.Protocol.Core.Types.INuGetResourceProvider
    {
        public ResourceProvider(System.Type resourceType) { }
        public ResourceProvider(System.Type resourceType, string name) { }
        public ResourceProvider(System.Type resourceType, string name, System.Collections.Generic.IEnumerable<string> before, System.Collections.Generic.IEnumerable<string> after) { }
        public ResourceProvider(System.Type resourceType, string name, string before) { }
        public System.Collections.Generic.IEnumerable<string> After { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Before { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Type ResourceType { get { throw null; } }
        public abstract System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token);
    }
    public partial class RetriableProtocolException : NuGet.Protocol.Core.Types.NuGetProtocolException
    {
        public RetriableProtocolException(string message) : base (default(string)) { }
        public RetriableProtocolException(string message, System.Exception innerException) : base (default(string)) { }
    }
    public partial class SearchFilter
    {
        public SearchFilter() { }
        public SearchFilter(System.Collections.Generic.IEnumerable<string> supportedFrameworks, bool includePrerelease, bool includeDelisted) { }
        public SearchFilter(System.Collections.Generic.IEnumerable<string> supportedFrameworks, bool includePrerelease, bool includeDelisted, System.Collections.Generic.IEnumerable<string> packageTypes) { }
        public bool IncludeDelisted { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IncludePrerelease { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> PackageTypes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> SupportedFrameworks { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class SourceCacheContext : System.IDisposable
    {
        public SourceCacheContext() { }
        public string GeneratedTempFolder { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool IgnoreFailedSources { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<System.DateTimeOffset> ListMaxAge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.TimeSpan ListMaxAgeTimeSpan { get { throw null; } }
        public bool NoCache { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<System.DateTimeOffset> NupkgMaxAge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.TimeSpan NupkgMaxAgeTimeSpan { get { throw null; } }
        public void Dispose() { }
    }
    public partial class SourcePackageDependencyInfo : NuGet.Packaging.Core.PackageDependencyInfo
    {
        public SourcePackageDependencyInfo(NuGet.Packaging.Core.PackageIdentity identity, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependency> dependencies, bool listed, NuGet.Protocol.Core.Types.SourceRepository source, System.Uri downloadUri, string packageHash) : base (default(string), default(NuGet.Versioning.NuGetVersion)) { }
        public SourcePackageDependencyInfo(string id, NuGet.Versioning.NuGetVersion version, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependency> dependencies, bool listed, NuGet.Protocol.Core.Types.SourceRepository source) : base (default(string), default(NuGet.Versioning.NuGetVersion)) { }
        public SourcePackageDependencyInfo(string id, NuGet.Versioning.NuGetVersion version, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependency> dependencies, bool listed, NuGet.Protocol.Core.Types.SourceRepository source, System.Uri downloadUri, string packageHash) : base (default(string), default(NuGet.Versioning.NuGetVersion)) { }
        public System.Uri DownloadUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Listed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string PackageHash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Protocol.Core.Types.SourceRepository Source { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class SourceRepository
    {
        protected SourceRepository() { }
        public SourceRepository(NuGet.Configuration.PackageSource source, System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.INuGetResourceProvider> providers) { }
        public SourceRepository(NuGet.Configuration.PackageSource source, System.Collections.Generic.IEnumerable<System.Lazy<NuGet.Protocol.Core.Types.INuGetResourceProvider>> providers) { }
        public SourceRepository(NuGet.Configuration.PackageSource source, System.Collections.Generic.IEnumerable<System.Lazy<NuGet.Protocol.Core.Types.INuGetResourceProvider>> providers, NuGet.Protocol.FeedType feedTypeOverride) { }
        public NuGet.Protocol.FeedType FeedTypeOverride { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual NuGet.Configuration.PackageSource PackageSource { get { throw null; } }
        public virtual System.Threading.Tasks.Task<NuGet.Protocol.FeedType> GetFeedType(System.Threading.CancellationToken token) { throw null; }
        public virtual System.Threading.Tasks.Task<T> GetResourceAsync<T>() where T : class, NuGet.Protocol.Core.Types.INuGetResource { throw null; }
        public virtual System.Threading.Tasks.Task<T> GetResourceAsync<T>(System.Threading.CancellationToken token) where T : class, NuGet.Protocol.Core.Types.INuGetResource { throw null; }
        public virtual T GetResource<T>() where T : class, NuGet.Protocol.Core.Types.INuGetResource { throw null; }
        public virtual T GetResource<T>(System.Threading.CancellationToken token) where T : class, NuGet.Protocol.Core.Types.INuGetResource { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceRepositoryProvider : NuGet.Protocol.Core.Types.ISourceRepositoryProvider
    {
        public SourceRepositoryProvider(NuGet.Configuration.IPackageSourceProvider packageSourceProvider, System.Collections.Generic.IEnumerable<System.Lazy<NuGet.Protocol.Core.Types.INuGetResourceProvider>> resourceProviders) { }
        public SourceRepositoryProvider(NuGet.Configuration.ISettings settings, System.Collections.Generic.IEnumerable<System.Lazy<NuGet.Protocol.Core.Types.INuGetResourceProvider>> resourceProviders) { }
        public NuGet.Configuration.IPackageSourceProvider PackageSourceProvider { get { throw null; } }
        public NuGet.Protocol.Core.Types.SourceRepository CreateRepository(NuGet.Configuration.PackageSource source) { throw null; }
        public NuGet.Protocol.Core.Types.SourceRepository CreateRepository(NuGet.Configuration.PackageSource source, NuGet.Protocol.FeedType type) { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.SourceRepository> GetRepositories() { throw null; }
    }
    public static partial class UserAgent
    {
        public static string UserAgentString { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static void SetUserAgent(System.Net.Http.HttpClient client) { }
        public static void SetUserAgentString(NuGet.Protocol.Core.Types.UserAgentStringBuilder builder) { }
    }
    public partial class UserAgentStringBuilder
    {
        public static readonly string DefaultNuGetClientName;
        public UserAgentStringBuilder() { }
        public UserAgentStringBuilder(string clientName) { }
        public string NuGetClientVersion { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Build() { throw null; }
        public NuGet.Protocol.Core.Types.UserAgentStringBuilder WithOSDescription(string osInfo) { throw null; }
        public NuGet.Protocol.Core.Types.UserAgentStringBuilder WithVisualStudioSKU(string vsInfo) { throw null; }
    }
    public partial class VersionInfo
    {
        public VersionInfo(NuGet.Versioning.NuGetVersion version) { }
        public VersionInfo(NuGet.Versioning.NuGetVersion version, System.Nullable<long> downloadCount) { }
        public VersionInfo(NuGet.Versioning.NuGetVersion version, string downloadCount) { }
        public System.Nullable<long> DownloadCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Protocol.Core.Types.IPackageSearchMetadata PackageSearchMetadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
}
