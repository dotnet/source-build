[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("NuGet Protocol for 3.1.0 servers")]
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
    public partial class AmbientAuthenticationState
    {
        public AmbientAuthenticationState() { }
        public int AuthenticationRetriesCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool IsBlocked { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public void Block() { }
        public void Increment() { }
    }
    public partial class AutoCompleteResourceV2Feed : NuGet.Protocol.Core.Types.AutoCompleteResource
    {
        public AutoCompleteResourceV2Feed(NuGet.Protocol.HttpSourceResource httpSourceResource, string baseAddress, NuGet.Configuration.PackageSource packageSource) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string>> IdStartsWith(string packageIdPrefix, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> VersionStartsWith(string packageId, string versionPrefix, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class AutoCompleteResourceV2FeedProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public AutoCompleteResourceV2FeedProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class AutoCompleteResourceV3 : NuGet.Protocol.Core.Types.AutoCompleteResource
    {
        public AutoCompleteResourceV3(NuGet.Protocol.HttpSource client, NuGet.Protocol.ServiceIndexResourceV3 serviceIndex, NuGet.Protocol.RegistrationResourceV3 regResource) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string>> IdStartsWith(string packageIdPrefix, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> VersionStartsWith(string packageId, string versionPrefix, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class AutoCompleteResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public AutoCompleteResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class CachingSourceProvider : NuGet.Protocol.Core.Types.ISourceRepositoryProvider
    {
        public CachingSourceProvider(NuGet.Configuration.IPackageSourceProvider packageSourceProvider) { }
        public NuGet.Configuration.IPackageSourceProvider PackageSourceProvider { get { throw null; } }
        public NuGet.Protocol.Core.Types.SourceRepository CreateRepository(NuGet.Configuration.PackageSource source) { throw null; }
        public NuGet.Protocol.Core.Types.SourceRepository CreateRepository(NuGet.Configuration.PackageSource source, NuGet.Protocol.FeedType type) { throw null; }
        public NuGet.Protocol.Core.Types.SourceRepository CreateRepository(string source) { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.SourceRepository> GetRepositories() { throw null; }
    }
    public partial class DependencyInfoResourceV2Feed : NuGet.Protocol.Core.Types.DependencyInfoResource
    {
        public DependencyInfoResourceV2Feed(NuGet.Protocol.V2FeedParser feedParser, NuGet.Protocol.Core.Types.SourceRepository source) { }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.SourcePackageDependencyInfo> ResolvePackage(NuGet.Packaging.Core.PackageIdentity package, NuGet.Frameworks.NuGetFramework projectFramework, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.SourcePackageDependencyInfo>> ResolvePackages(string packageId, NuGet.Frameworks.NuGetFramework projectFramework, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class DependencyInfoResourceV2FeedProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public DependencyInfoResourceV2FeedProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public sealed partial class DependencyInfoResourceV3 : NuGet.Protocol.Core.Types.DependencyInfoResource
    {
        public DependencyInfoResourceV3(NuGet.Protocol.HttpSource client, NuGet.Protocol.RegistrationResourceV3 regResource, NuGet.Protocol.Core.Types.SourceRepository source) { }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.SourcePackageDependencyInfo> ResolvePackage(NuGet.Packaging.Core.PackageIdentity package, NuGet.Frameworks.NuGetFramework projectFramework, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.RemoteSourceDependencyInfo>> ResolvePackages(string packageId, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.SourcePackageDependencyInfo>> ResolvePackages(string packageId, NuGet.Frameworks.NuGetFramework projectFramework, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class DependencyInfoResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public DependencyInfoResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class DownloadResourceV2Feed : NuGet.Protocol.Core.Types.DownloadResource
    {
        public DownloadResourceV2Feed(NuGet.Protocol.V2FeedParser feedParser) { }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.DownloadResourceResult> GetDownloadResourceResultAsync(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Configuration.ISettings settings, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class DownloadResourceV2FeedProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public DownloadResourceV2FeedProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class DownloadResourceV3 : NuGet.Protocol.Core.Types.DownloadResource
    {
        public DownloadResourceV3(NuGet.Protocol.HttpSource client, NuGet.Protocol.RegistrationResourceV3 regResource) { }
        public DownloadResourceV3(NuGet.Protocol.HttpSource client, string packageBaseAddress) { }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.DownloadResourceResult> GetDownloadResourceResultAsync(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Configuration.ISettings settings, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class DownloadResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public DownloadResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class DownloadTimeoutStream : System.IO.Stream
    {
        public DownloadTimeoutStream(string downloadName, System.IO.Stream networkStream, System.TimeSpan timeout) { }
        public override bool CanRead { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool CanSeek { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool CanWrite { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override long Length { get { throw null; } }
        public override long Position { get { throw null; } set { } }
        protected override void Dispose(bool disposing) { }
        public override void Flush() { }
        public override int Read(byte[] buffer, int offset, int count) { throw null; }
        public override System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override long Seek(long offset, System.IO.SeekOrigin origin) { throw null; }
        public override void SetLength(long value) { }
        public override void Write(byte[] buffer, int offset, int count) { }
    }
    public partial class DownloadTimeoutStreamContent : System.Net.Http.StreamContent
    {
        public DownloadTimeoutStreamContent(string downloadName, System.IO.Stream networkStream, System.TimeSpan timeout) : base (default(System.IO.Stream)) { }
    }
    public static partial class FactoryExtensionsV2
    {
        public static NuGet.Protocol.Core.Types.SourceRepository GetCoreV2(this NuGet.Protocol.Core.Types.Repository.RepositoryFactory factory, NuGet.Configuration.PackageSource source) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Lazy<NuGet.Protocol.Core.Types.INuGetResourceProvider>> GetCoreV3(this NuGet.Protocol.Core.Types.Repository.ProviderFactory factory) { throw null; }
        public static NuGet.Protocol.Core.Types.SourceRepository GetCoreV3(this NuGet.Protocol.Core.Types.Repository.RepositoryFactory factory, string source) { throw null; }
        public static NuGet.Protocol.Core.Types.SourceRepository GetCoreV3(this NuGet.Protocol.Core.Types.Repository.RepositoryFactory factory, string source, NuGet.Protocol.FeedType type) { throw null; }
    }
    public partial class FeedTypeResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public FeedTypeResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public static partial class FeedTypeUtility
    {
        public static NuGet.Protocol.FeedType GetFeedType(NuGet.Configuration.PackageSource packageSource) { throw null; }
    }
    public abstract partial class FindLocalPackagesResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        protected FindLocalPackagesResource() { }
        public string Root { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]protected set { } }
        public virtual bool Exists(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public virtual bool Exists(string packageId, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public abstract System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> FindPackagesById(string id, NuGet.Common.ILogger logger, System.Threading.CancellationToken token);
        public abstract NuGet.Protocol.LocalPackageInfo GetPackage(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger logger, System.Threading.CancellationToken token);
        public abstract NuGet.Protocol.LocalPackageInfo GetPackage(System.Uri path, NuGet.Common.ILogger logger, System.Threading.CancellationToken token);
        public abstract System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackages(NuGet.Common.ILogger logger, System.Threading.CancellationToken token);
    }
    public partial class FindLocalPackagesResourcePackagesConfig : NuGet.Protocol.FindLocalPackagesResource
    {
        public FindLocalPackagesResourcePackagesConfig(string root) { }
        public override System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> FindPackagesById(string id, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override NuGet.Protocol.LocalPackageInfo GetPackage(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override NuGet.Protocol.LocalPackageInfo GetPackage(System.Uri path, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackages(NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class FindLocalPackagesResourcePackagesConfigProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public FindLocalPackagesResourcePackagesConfigProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class FindLocalPackagesResourceUnzipped : NuGet.Protocol.FindLocalPackagesResource
    {
        public FindLocalPackagesResourceUnzipped(string root) { }
        public override bool Exists(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> FindPackagesById(string id, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override NuGet.Protocol.LocalPackageInfo GetPackage(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override NuGet.Protocol.LocalPackageInfo GetPackage(System.Uri path, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackages(NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class FindLocalPackagesResourceUnzippedProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public FindLocalPackagesResourceUnzippedProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class FindLocalPackagesResourceV2 : NuGet.Protocol.FindLocalPackagesResource
    {
        public FindLocalPackagesResourceV2(string root) { }
        public override System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> FindPackagesById(string id, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override NuGet.Protocol.LocalPackageInfo GetPackage(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override NuGet.Protocol.LocalPackageInfo GetPackage(System.Uri path, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackages(NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class FindLocalPackagesResourceV2Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public FindLocalPackagesResourceV2Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class FindLocalPackagesResourceV3 : NuGet.Protocol.FindLocalPackagesResource
    {
        public FindLocalPackagesResourceV3(string root) { }
        public override System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> FindPackagesById(string id, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override NuGet.Protocol.LocalPackageInfo GetPackage(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override NuGet.Protocol.LocalPackageInfo GetPackage(System.Uri path, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public override System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackages(NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class FindLocalPackagesResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public FindLocalPackagesResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public static partial class GetDownloadResultUtility
    {
        public static System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.DownloadResourceResult> GetDownloadResultAsync(NuGet.Protocol.HttpSource client, NuGet.Packaging.Core.PackageIdentity identity, System.Uri uri, NuGet.Configuration.ISettings settings, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
    }
    public static partial class GlobalPackagesFolderUtility
    {
        public static System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.DownloadResourceResult> AddPackageAsync(NuGet.Packaging.Core.PackageIdentity packageIdentity, System.IO.Stream packageStream, NuGet.Configuration.ISettings settings, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
        public static NuGet.Protocol.Core.Types.DownloadResourceResult GetPackage(NuGet.Packaging.Core.PackageIdentity packageIdentity, NuGet.Configuration.ISettings settings) { throw null; }
    }
    public partial class HttpCacheResult
    {
        public HttpCacheResult(System.TimeSpan maxAge, string newCacheFile, string cacheFile) { }
        public string CacheFile { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.TimeSpan MaxAge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string NewCacheFile { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.IO.Stream Stream { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public static partial class HttpCacheUtility
    {
        public static System.Threading.Tasks.Task CreateCacheFileAsync(NuGet.Protocol.HttpCacheResult result, string uri, System.Net.Http.HttpResponseMessage response, NuGet.Protocol.Core.Types.HttpSourceCacheContext context, System.Action<System.IO.Stream> ensureValidContents, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static NuGet.Protocol.HttpCacheResult InitializeHttpCacheResult(string httpCacheDirectory, System.Uri baseUri, string cacheKey, NuGet.Protocol.Core.Types.HttpSourceCacheContext context) { throw null; }
        public static System.IO.Stream TryReadCacheFile(string uri, System.TimeSpan maxAge, string cacheFile) { throw null; }
    }
    public partial class HttpFileSystemBasedFindPackageByIdResource : NuGet.Protocol.Core.Types.FindPackageByIdResource
    {
        public HttpFileSystemBasedFindPackageByIdResource(System.Collections.Generic.IReadOnlyList<System.Uri> baseUris, NuGet.Protocol.HttpSource httpSource) { }
        public override NuGet.Common.ILogger Logger { get { throw null; } set { } }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetAllVersionsAsync(string id, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.FindPackageByIdDependencyInfo> GetDependencyInfoAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> GetNupkgStreamAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Packaging.Core.PackageIdentity> GetOriginalIdentityAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class HttpFileSystemBasedFindPackageByIdResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public HttpFileSystemBasedFindPackageByIdResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository sourceRepository, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class HttpHandlerResourceV3 : NuGet.Protocol.Core.Types.HttpHandlerResource
    {
        public HttpHandlerResourceV3(System.Net.Http.HttpClientHandler clientHandler, System.Net.Http.HttpMessageHandler messageHandler) { }
        public override System.Net.Http.HttpClientHandler ClientHandler { get { throw null; } }
        public static NuGet.Configuration.ICredentialService CredentialService { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public static System.Action<System.Uri, System.Net.ICredentials> CredentialsSuccessfullyUsed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override System.Net.Http.HttpMessageHandler MessageHandler { get { throw null; } }
    }
    public partial class HttpHandlerResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public HttpHandlerResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class HttpRequestMessageConfiguration
    {
        public static readonly NuGet.Protocol.HttpRequestMessageConfiguration Default;
        public HttpRequestMessageConfiguration(NuGet.Common.ILogger logger=null, bool promptOn403=true) { }
        public NuGet.Common.ILogger Logger { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool PromptOn403 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public static partial class HttpRequestMessageExtensions
    {
        public static NuGet.Protocol.HttpRequestMessageConfiguration GetOrCreateConfiguration(this System.Net.Http.HttpRequestMessage request) { throw null; }
        public static void SetConfiguration(this System.Net.Http.HttpRequestMessage request, NuGet.Protocol.HttpRequestMessageConfiguration configuration) { }
    }
    public static partial class HttpRequestMessageFactory
    {
        public static System.Net.Http.HttpRequestMessage Create(System.Net.Http.HttpMethod method, string requestUri, NuGet.Common.ILogger log) { throw null; }
        public static System.Net.Http.HttpRequestMessage Create(System.Net.Http.HttpMethod method, string requestUri, NuGet.Protocol.HttpRequestMessageConfiguration configuration) { throw null; }
        public static System.Net.Http.HttpRequestMessage Create(System.Net.Http.HttpMethod method, System.Uri requestUri, NuGet.Common.ILogger log) { throw null; }
        public static System.Net.Http.HttpRequestMessage Create(System.Net.Http.HttpMethod method, System.Uri requestUri, NuGet.Protocol.HttpRequestMessageConfiguration configuration) { throw null; }
    }
    public partial class HttpRetryHandler : NuGet.Protocol.IHttpRetryHandler
    {
        public HttpRetryHandler() { }
        public System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(NuGet.Protocol.HttpRetryHandlerRequest request, NuGet.Common.ILogger log, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class HttpRetryHandlerRequest
    {
        public static readonly System.TimeSpan DefaultDownloadTimeout;
        public HttpRetryHandlerRequest(System.Net.Http.HttpClient httpClient, System.Func<System.Net.Http.HttpRequestMessage> requestFactory) { }
        public System.Net.Http.HttpCompletionOption CompletionOption { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.TimeSpan DownloadTimeout { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Net.Http.HttpClient HttpClient { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public int MaxTries { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Func<System.Net.Http.HttpRequestMessage> RequestFactory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.TimeSpan RequestTimeout { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.TimeSpan RetryDelay { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class HttpSource : System.IDisposable
    {
        public HttpSource(NuGet.Configuration.PackageSource packageSource, System.Func<System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.HttpHandlerResource>> messageHandlerFactory, NuGet.Protocol.IThrottle throttle) { }
        public string HttpCacheDirectory { get { throw null; } set { } }
        public NuGet.Protocol.IHttpRetryHandler RetryHandler { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public static NuGet.Protocol.HttpSource Create(NuGet.Protocol.Core.Types.SourceRepository source) { throw null; }
        public static NuGet.Protocol.HttpSource Create(NuGet.Protocol.Core.Types.SourceRepository source, NuGet.Protocol.IThrottle throttle) { throw null; }
        public void Dispose() { }
        public System.Threading.Tasks.Task<NuGet.Protocol.HttpSourceResult> GetAsync(NuGet.Protocol.HttpSourceCachedRequest request, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JObject> GetJObjectAsync(NuGet.Protocol.HttpSourceRequest request, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public System.Threading.Tasks.Task<T> ProcessResponseAsync<T>(NuGet.Protocol.HttpSourceRequest request, System.Func<System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task<T>> processAsync, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public System.Threading.Tasks.Task<T> ProcessStreamAsync<T>(NuGet.Protocol.HttpSourceRequest request, System.Func<System.IO.Stream, System.Threading.Tasks.Task<T>> processAsync, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        protected virtual System.IO.Stream TryReadCacheFile(string uri, System.TimeSpan maxAge, string cacheFile) { throw null; }
    }
    public partial class HttpSourceAuthenticationHandler : System.Net.Http.DelegatingHandler
    {
        public static readonly int MaxAuthRetries;
        public HttpSourceAuthenticationHandler(NuGet.Configuration.PackageSource packageSource, System.Net.Http.HttpClientHandler clientHandler, NuGet.Configuration.ICredentialService credentialService) { }
        protected override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class HttpSourceCachedRequest
    {
        public HttpSourceCachedRequest(string uri, string cacheKey, NuGet.Protocol.Core.Types.HttpSourceCacheContext cacheContext) { }
        public System.Collections.Generic.IList<System.Net.Http.Headers.MediaTypeWithQualityHeaderValue> AcceptHeaderValues { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Protocol.Core.Types.HttpSourceCacheContext CacheContext { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string CacheKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.TimeSpan DownloadTimeout { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Action<System.IO.Stream> EnsureValidContents { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IgnoreNotFounds { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.TimeSpan RequestTimeout { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Uri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class HttpSourceCredentials : System.Net.CredentialCache, System.Net.ICredentials
    {
        public HttpSourceCredentials() { }
        public HttpSourceCredentials(System.Net.ICredentials credentials=null) { }
        public System.Net.ICredentials Credentials { get { throw null; } set { } }
        public System.Guid Version { get { throw null; } }
        System.Net.NetworkCredential System.Net.ICredentials.GetCredential(System.Uri uri, string authType) { throw null; }
    }
    public partial class HttpSourceRequest
    {
        public static readonly System.TimeSpan DefaultRequestTimeout;
        public HttpSourceRequest(System.Func<System.Net.Http.HttpRequestMessage> requestFactory) { }
        public HttpSourceRequest(string uri, NuGet.Common.ILogger log) { }
        public HttpSourceRequest(System.Uri uri, NuGet.Common.ILogger log) { }
        public System.TimeSpan DownloadTimeout { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IgnoreNotFounds { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Func<System.Net.Http.HttpRequestMessage> RequestFactory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.TimeSpan RequestTimeout { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class HttpSourceResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        public HttpSourceResource(NuGet.Protocol.HttpSource httpSource) { }
        public NuGet.Protocol.HttpSource HttpSource { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class HttpSourceResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public HttpSourceResourceProvider() : base (default(System.Type)) { }
        public static NuGet.Protocol.IThrottle Throttle { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class HttpSourceResult : System.IDisposable
    {
        public HttpSourceResult(NuGet.Protocol.HttpSourceResultStatus status) { }
        public HttpSourceResult(NuGet.Protocol.HttpSourceResultStatus status, string cacheFileName, System.IO.Stream stream) { }
        public string CacheFileName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Protocol.HttpSourceResultStatus Status { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.IO.Stream Stream { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public void Dispose() { }
    }
    public enum HttpSourceResultStatus
    {
        NoContent = 1,
        NotFound = 0,
        OpenedFromDisk = 2,
    }
    public static partial class HttpStreamValidation
    {
        public static void ValidateJObject(string uri, System.IO.Stream stream) { }
        public static void ValidateNupkg(string uri, System.IO.Stream stream) { }
        public static void ValidateXml(string uri, System.IO.Stream stream) { }
    }
    public partial interface IHttpRetryHandler
    {
        System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(NuGet.Protocol.HttpRetryHandlerRequest request, NuGet.Common.ILogger log, System.Threading.CancellationToken cancellationToken);
    }
    public partial interface IThrottle
    {
        void Release();
        System.Threading.Tasks.Task WaitAsync();
    }
    public static partial class JsonExtensions
    {
        public const int JsonSerializationMaxDepth = 512;
        public static readonly Newtonsoft.Json.JsonSerializerSettings ObjectSerializationSettings;
        public static object FromJson(this string json, System.Type type) { throw null; }
        public static T FromJson<T>(this string json) { throw null; }
        public static T FromJson<T>(this string json, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static object FromJToken(this Newtonsoft.Json.Linq.JToken jtoken, System.Type type) { throw null; }
        public static T FromJToken<T>(this Newtonsoft.Json.Linq.JToken jtoken) { throw null; }
        public static System.Nullable<bool> GetBoolean(this Newtonsoft.Json.Linq.JObject json, string propertyName) { throw null; }
        public static T GetJObjectProperty<T>(this Newtonsoft.Json.Linq.JObject jobject, string propertyName) { throw null; }
        public static string ToJson(this object obj, Newtonsoft.Json.Formatting formatting=(Newtonsoft.Json.Formatting)(0)) { throw null; }
        public static Newtonsoft.Json.Linq.JToken ToJToken(this object obj) { throw null; }
    }
    public static partial class JsonProperties
    {
        public const string Authors = "authors";
        public const string Data = "data";
        public const string Dependencies = "dependencies";
        public const string DependencyGroups = "dependencyGroups";
        public const string Description = "description";
        public const string DownloadCount = "totalDownloads";
        public const string IconUrl = "iconUrl";
        public const string Language = "language";
        public const string LatestVersion = "latestVersion";
        public const string LicenseUrl = "licenseUrl";
        public const string MinimumClientVersion = "minClientVersion";
        public const string Owners = "owners";
        public const string PackageContent = "packageContent";
        public const string PackageId = "id";
        public const string ProjectUrl = "projectUrl";
        public const string Published = "published";
        public const string Range = "range";
        public const string RequireLicenseAcceptance = "requireLicenseAcceptance";
        public const string SubjectId = "@id";
        public const string Summary = "summary";
        public const string Tags = "tags";
        public const string TargetFramework = "targetFramework";
        public const string Title = "title";
        public const string Type = "@type";
        public const string Version = "version";
        public const string Versions = "versions";
    }
    public partial class ListCommandResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public ListCommandResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalAutoCompleteResource : NuGet.Protocol.Core.Types.AutoCompleteResource
    {
        public LocalAutoCompleteResource(NuGet.Protocol.FindLocalPackagesResource localResource) { }
        protected System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetPackageVersionsFromLocalPackageRepository(string packageId, string versionPrefix, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string>> IdStartsWith(string packageIdPrefix, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> VersionStartsWith(string packageId, string versionPrefix, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalAutoCompleteResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public LocalAutoCompleteResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalDependencyInfoResource : NuGet.Protocol.Core.Types.DependencyInfoResource
    {
        public LocalDependencyInfoResource(NuGet.Protocol.FindLocalPackagesResource localResource, NuGet.Protocol.Core.Types.SourceRepository source) { }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.SourcePackageDependencyInfo> ResolvePackage(NuGet.Packaging.Core.PackageIdentity package, NuGet.Frameworks.NuGetFramework projectFramework, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.SourcePackageDependencyInfo>> ResolvePackages(string packageId, NuGet.Frameworks.NuGetFramework projectFramework, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalDependencyInfoResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public LocalDependencyInfoResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalDownloadResource : NuGet.Protocol.Core.Types.DownloadResource
    {
        public LocalDownloadResource(NuGet.Protocol.FindLocalPackagesResource localResource) { }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.DownloadResourceResult> GetDownloadResourceResultAsync(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Configuration.ISettings settings, NuGet.Common.ILogger logger, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalDownloadResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public LocalDownloadResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public static partial class LocalFolderUtility
    {
        public static System.IO.DirectoryInfo GetAndVerifyRootDirectory(string root) { throw null; }
        public static System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetDistinctPackages(System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> packages) { throw null; }
        public static NuGet.Packaging.Core.PackageIdentity GetIdentityFromNupkgPath(System.IO.FileInfo file, string id) { throw null; }
        public static NuGet.Protocol.FeedType GetLocalFeedType(string root, NuGet.Common.ILogger log) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.IO.FileInfo> GetNupkgsFromFlatFolder(string root, NuGet.Common.ILogger log) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.IO.FileInfo> GetNupkgsFromFlatFolder(string root, string id, NuGet.Common.ILogger log) { throw null; }
        public static NuGet.Protocol.LocalPackageInfo GetPackage(System.Uri path, NuGet.Common.ILogger log) { throw null; }
        public static NuGet.Protocol.LocalPackageInfo GetPackagesConfigFolderPackage(string root, NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger log) { throw null; }
        public static NuGet.Protocol.LocalPackageInfo GetPackagesConfigFolderPackage(string root, string id, NuGet.Versioning.NuGetVersion version, NuGet.Common.ILogger log) { throw null; }
        public static System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackagesConfigFolderPackages(string root, NuGet.Common.ILogger log) { throw null; }
        public static System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackagesConfigFolderPackages(string root, string id, NuGet.Common.ILogger log) { throw null; }
        public static System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackagesV2(string root, NuGet.Common.ILogger log) { throw null; }
        public static System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackagesV2(string root, string id, NuGet.Common.ILogger log) { throw null; }
        public static System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackagesV3(string root, NuGet.Common.ILogger log) { throw null; }
        public static System.Collections.Generic.IEnumerable<NuGet.Protocol.LocalPackageInfo> GetPackagesV3(string root, string id, NuGet.Common.ILogger log) { throw null; }
        public static NuGet.Protocol.LocalPackageInfo GetPackageV2(string root, NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger log) { throw null; }
        public static NuGet.Protocol.LocalPackageInfo GetPackageV2(string root, string id, NuGet.Versioning.NuGetVersion version, NuGet.Common.ILogger log) { throw null; }
        public static NuGet.Protocol.LocalPackageInfo GetPackageV3(string root, NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger log) { throw null; }
        public static NuGet.Protocol.LocalPackageInfo GetPackageV3(string root, string id, NuGet.Versioning.NuGetVersion version, NuGet.Common.ILogger log) { throw null; }
        public static NuGet.Versioning.NuGetVersion GetVersionFromFileName(string fileName, string id, string extension) { throw null; }
        public static bool IsPossiblePackageMatch(System.IO.FileInfo file, NuGet.Packaging.Core.PackageIdentity identity) { throw null; }
        public static bool IsPossiblePackageMatch(System.IO.FileInfo file, string id) { throw null; }
    }
    public partial class LocalMetadataResource : NuGet.Protocol.Core.Types.MetadataResource
    {
        public LocalMetadataResource(NuGet.Protocol.FindLocalPackagesResource localResource) { }
        public override System.Threading.Tasks.Task<bool> Exists(NuGet.Packaging.Core.PackageIdentity identity, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<bool> Exists(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, NuGet.Versioning.NuGetVersion>>> GetLatestVersions(System.Collections.Generic.IEnumerable<string> packageIds, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetVersions(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalMetadataResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public LocalMetadataResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalPackageInfo
    {
        protected LocalPackageInfo() { }
        public LocalPackageInfo(NuGet.Packaging.Core.PackageIdentity identity, string path, System.DateTime lastWriteTimeUtc, System.Lazy<NuGet.Packaging.NuspecReader> nuspec, System.Func<NuGet.Packaging.PackageReaderBase> getPackageReader) { }
        public virtual NuGet.Packaging.Core.PackageIdentity Identity { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual bool IsNupkg { get { throw null; } }
        public virtual System.DateTime LastWriteTimeUtc { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual NuGet.Packaging.NuspecReader Nuspec { get { throw null; } }
        public virtual string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual NuGet.Packaging.PackageReaderBase GetReader() { throw null; }
    }
    public partial class LocalPackageMetadataResource : NuGet.Protocol.Core.Types.PackageMetadataResource
    {
        public LocalPackageMetadataResource(NuGet.Protocol.FindLocalPackagesResource localResource) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.IPackageSearchMetadata>> GetMetadataAsync(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalPackageMetadataResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public LocalPackageMetadataResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalPackageSearchMetadata : NuGet.Protocol.Core.Types.IPackageSearchMetadata
    {
        public LocalPackageSearchMetadata(NuGet.Protocol.LocalPackageInfo package) { }
        public string Authors { get { throw null; } }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> DependencySets { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Nullable<long> DownloadCount { get { throw null; } }
        public System.Uri IconUrl { get { throw null; } }
        public NuGet.Packaging.Core.PackageIdentity Identity { get { throw null; } }
        public System.Uri LicenseUrl { get { throw null; } }
        public string Owners { get { throw null; } }
        public System.Uri ProjectUrl { get { throw null; } }
        public System.Nullable<System.DateTimeOffset> Published { get { throw null; } }
        public System.Uri ReportAbuseUrl { get { throw null; } }
        public bool RequireLicenseAcceptance { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Tags { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.VersionInfo>> GetVersionsAsync() { throw null; }
    }
    public partial class LocalPackageSearchResource : NuGet.Protocol.Core.Types.PackageSearchResource
    {
        public LocalPackageSearchResource(NuGet.Protocol.FindLocalPackagesResource localResource) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.IPackageSearchMetadata>> SearchAsync(string searchTerm, NuGet.Protocol.Core.Types.SearchFilter filters, int skip, int take, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalPackageSearchResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public LocalPackageSearchResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalV2FindPackageByIdResource : NuGet.Protocol.Core.Types.FindPackageByIdResource
    {
        public LocalV2FindPackageByIdResource(NuGet.Configuration.PackageSource packageSource) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetAllVersionsAsync(string id, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.FindPackageByIdDependencyInfo> GetDependencyInfoAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> GetNupkgStreamAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Packaging.Core.PackageIdentity> GetOriginalIdentityAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalV2FindPackageByIdResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public LocalV2FindPackageByIdResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalV3FindPackageByIdResource : NuGet.Protocol.Core.Types.FindPackageByIdResource
    {
        public LocalV3FindPackageByIdResource(NuGet.Configuration.PackageSource source) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetAllVersionsAsync(string id, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.FindPackageByIdDependencyInfo> GetDependencyInfoAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> GetNupkgStreamAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Packaging.Core.PackageIdentity> GetOriginalIdentityAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class LocalV3FindPackageByIdResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public LocalV3FindPackageByIdResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class MetadataFieldConverter : Newtonsoft.Json.JsonConverter
    {
        public MetadataFieldConverter() { }
        public override bool CanWrite { get { throw null; } }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class MetadataResourceV2Feed : NuGet.Protocol.Core.Types.MetadataResource
    {
        public MetadataResourceV2Feed(NuGet.Protocol.V2FeedParser feedParser, NuGet.Protocol.Core.Types.SourceRepository source) { }
        public override System.Threading.Tasks.Task<bool> Exists(NuGet.Packaging.Core.PackageIdentity identity, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<bool> Exists(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, NuGet.Versioning.NuGetVersion>>> GetLatestVersions(System.Collections.Generic.IEnumerable<string> packageIds, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetVersions(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class MetadataResourceV2FeedProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public MetadataResourceV2FeedProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class MetadataResourceV3 : NuGet.Protocol.Core.Types.MetadataResource
    {
        public MetadataResourceV3(NuGet.Protocol.HttpSource client, NuGet.Protocol.RegistrationResourceV3 regResource) { }
        public override System.Threading.Tasks.Task<bool> Exists(NuGet.Packaging.Core.PackageIdentity identity, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<bool> Exists(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, NuGet.Versioning.NuGetVersion>>> GetLatestVersions(System.Collections.Generic.IEnumerable<string> packageIds, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetVersions(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class MetadataResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public MetadataResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class NuGetVersionConverter : Newtonsoft.Json.JsonConverter
    {
        public NuGetVersionConverter() { }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class NullThrottle : NuGet.Protocol.IThrottle
    {
        public NullThrottle() { }
        public static NuGet.Protocol.NullThrottle Instance { get { throw null; } }
        public void Release() { }
        public System.Threading.Tasks.Task WaitAsync() { throw null; }
    }
    public partial class ODataServiceDocumentResourceV2 : NuGet.Protocol.Core.Types.INuGetResource
    {
        public ODataServiceDocumentResourceV2(string baseAddress, System.DateTime requestTime) { }
        public string BaseAddress { get { throw null; } }
        public virtual System.DateTime RequestTime { get { throw null; } }
    }
    public partial class ODataServiceDocumentResourceV2Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        protected readonly System.Collections.Concurrent.ConcurrentDictionary<string, NuGet.Protocol.ODataServiceDocumentResourceV2Provider.ODataServiceDocumentCacheInfo> _cache;
        public ODataServiceDocumentResourceV2Provider() : base (default(System.Type)) { }
        public System.TimeSpan MaxCacheDuration { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]protected set { } }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
        protected partial class ODataServiceDocumentCacheInfo
        {
            public ODataServiceDocumentCacheInfo() { }
            public System.DateTime CachedTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
            public NuGet.Protocol.ODataServiceDocumentResourceV2 ServiceDocument { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        }
    }
    public partial class OnDemandParsedVersionsConverter : Newtonsoft.Json.JsonConverter
    {
        public OnDemandParsedVersionsConverter() { }
        public override bool CanWrite { get { throw null; } }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class PackageDependencyGroupConverter : Newtonsoft.Json.JsonConverter
    {
        public PackageDependencyGroupConverter() { }
        public override bool CanWrite { get { throw null; } }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class PackageMetadataResourceV2Feed : NuGet.Protocol.Core.Types.PackageMetadataResource
    {
        public PackageMetadataResourceV2Feed(NuGet.Protocol.HttpSourceResource httpSourceResource, string baseAddress, NuGet.Configuration.PackageSource packageSource) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.IPackageSearchMetadata>> GetMetadataAsync(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class PackageMetadataResourceV2FeedProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public PackageMetadataResourceV2FeedProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class PackageMetadataResourceV3 : NuGet.Protocol.Core.Types.PackageMetadataResource
    {
        public PackageMetadataResourceV3(NuGet.Protocol.HttpSource client, NuGet.Protocol.RegistrationResourceV3 regResource, NuGet.Protocol.ReportAbuseResourceV3 reportAbuseResource) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.IPackageSearchMetadata>> GetMetadataAsync(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class PackageMetadataResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public PackageMetadataResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class PackageSearchMetadata : NuGet.Protocol.Core.Types.IPackageSearchMetadata
    {
        public PackageSearchMetadata() { }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(NuGet.Protocol.MetadataFieldConverter))]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="authors")]
        public string Authors { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> DependencySets { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="dependencyGroups", ItemConverterType=typeof(NuGet.Protocol.PackageDependencyGroupConverter))]
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> DependencySetsInternal { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="description")]
        public string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="totalDownloads")]
        public System.Nullable<long> DownloadCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="iconUrl")]
        public System.Uri IconUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public NuGet.Packaging.Core.PackageIdentity Identity { get { throw null; } }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(NuGet.Protocol.SafeUriConverter))]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="licenseUrl")]
        public System.Uri LicenseUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(NuGet.Protocol.OnDemandParsedVersionsConverter))]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="versions")]
        public System.Lazy<NuGet.Protocol.Core.Types.VersionInfo[]> OnDemandParsedVersions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(NuGet.Protocol.MetadataFieldConverter))]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="owners")]
        public string Owners { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="id")]
        public string PackageId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(NuGet.Protocol.SafeUriConverter))]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="projectUrl")]
        public System.Uri ProjectUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="published")]
        public System.Nullable<System.DateTimeOffset> Published { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public System.Uri ReportAbuseUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(NuGet.Protocol.SafeBoolConverter))]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="requireLicenseAcceptance", DefaultValueHandling=(Newtonsoft.Json.DefaultValueHandling)(2))]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool RequireLicenseAcceptance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="summary")]
        public string Summary { get { throw null; } }
        [Newtonsoft.Json.JsonConverterAttribute(typeof(NuGet.Protocol.MetadataFieldConverter))]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="tags")]
        public string Tags { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="title")]
        public string Title { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName="version")]
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.VersionInfo>> GetVersionsAsync() { throw null; }
    }
    public partial class PackageSearchMetadataV2Feed : NuGet.Protocol.Core.Types.IPackageSearchMetadata
    {
        public PackageSearchMetadataV2Feed(NuGet.Protocol.V2FeedPackageInfo package) { }
        public string Authors { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> DependencySets { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<long> DownloadCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Uri IconUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Packaging.Core.PackageIdentity Identity { get { throw null; } }
        public System.Uri LicenseUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Lazy<NuGet.Protocol.Core.Types.VersionInfo[]> OnDemandParsedVersions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Owners { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string PackageId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Uri ProjectUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<System.DateTimeOffset> Published { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Uri ReportAbuseUrl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool RequireLicenseAcceptance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Summary { get { throw null; } }
        public string Tags { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Title { get { throw null; } }
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.VersionInfo>> GetVersionsAsync() { throw null; }
    }
    public partial class PackageSearchResourceV2Feed : NuGet.Protocol.Core.Types.PackageSearchResource
    {
        public PackageSearchResourceV2Feed(NuGet.Protocol.HttpSourceResource httpSourceResource, string baseAddress, NuGet.Configuration.PackageSource packageSource) { }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.VersionInfo>> GetVersions(NuGet.Protocol.V2FeedPackageInfo package, NuGet.Protocol.Core.Types.SearchFilter filter, NuGet.Common.ILogger log, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.IPackageSearchMetadata>> SearchAsync(string searchTerm, NuGet.Protocol.Core.Types.SearchFilter filters, int skip, int take, NuGet.Common.ILogger log, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class PackageSearchResourceV2FeedProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public PackageSearchResourceV2FeedProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class PackageSearchResourceV3 : NuGet.Protocol.Core.Types.PackageSearchResource
    {
        public PackageSearchResourceV3(NuGet.Protocol.RawSearchResourceV3 searchResource, NuGet.Protocol.Core.Types.PackageMetadataResource metadataResource) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Protocol.Core.Types.IPackageSearchMetadata>> SearchAsync(string searchTerm, NuGet.Protocol.Core.Types.SearchFilter filter, int skip, int take, NuGet.Common.ILogger log, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class PackageSearchResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public PackageSearchResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class PackageUpdateResourceV2Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public PackageUpdateResourceV2Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class PackageUpdateResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public PackageUpdateResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class ProxyAuthenticationHandler : System.Net.Http.DelegatingHandler
    {
        public static readonly int MaxAuthRetries;
        public ProxyAuthenticationHandler(System.Net.Http.HttpClientHandler clientHandler, NuGet.Configuration.ICredentialService credentialService, NuGet.Configuration.IProxyCredentialCache credentialCache) { }
        protected override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class RawSearchResourceV3 : NuGet.Protocol.Core.Types.INuGetResource
    {
        public RawSearchResourceV3(NuGet.Protocol.HttpSource client, System.Collections.Generic.IEnumerable<System.Uri> searchEndpoints) { }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JObject>> Search(string searchTerm, NuGet.Protocol.Core.Types.SearchFilter filters, int skip, int take, NuGet.Common.ILogger log, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JObject> SearchPage(string searchTerm, NuGet.Protocol.Core.Types.SearchFilter filters, int skip, int take, NuGet.Common.ILogger log, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class RawSearchResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public RawSearchResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class RegistrationResourceV3 : NuGet.Protocol.Core.Types.INuGetResource
    {
        public RegistrationResourceV3(NuGet.Protocol.HttpSource client, System.Uri baseUrl) { }
        public System.Uri BaseUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JObject>> GetPackageEntries(string packageId, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public virtual System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JObject> GetPackageMetadata(NuGet.Packaging.Core.PackageIdentity identity, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JObject>> GetPackageMetadata(string packageId, NuGet.Versioning.VersionRange range, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JObject>> GetPackageMetadata(string packageId, bool includePrerelease, bool includeUnlisted, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public virtual System.Uri GetUri(NuGet.Packaging.Core.PackageIdentity package) { throw null; }
        public virtual System.Uri GetUri(string packageId) { throw null; }
        public virtual System.Uri GetUri(string id, NuGet.Versioning.NuGetVersion version) { throw null; }
    }
    public partial class RegistrationResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public RegistrationResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class RemoteV2FindPackageByIdResource : NuGet.Protocol.Core.Types.FindPackageByIdResource
    {
        public RemoteV2FindPackageByIdResource(NuGet.Configuration.PackageSource packageSource, NuGet.Protocol.HttpSource httpSource) { }
        public override NuGet.Common.ILogger Logger { get { throw null; } set { } }
        public NuGet.Configuration.PackageSource PackageSource { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetAllVersionsAsync(string id, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.FindPackageByIdDependencyInfo> GetDependencyInfoAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> GetNupkgStreamAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Packaging.Core.PackageIdentity> GetOriginalIdentityAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class RemoteV2FindPackageByIdResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public RemoteV2FindPackageByIdResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository sourceRepository, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class RemoteV3FindPackageByIdResource : NuGet.Protocol.Core.Types.FindPackageByIdResource
    {
        public RemoteV3FindPackageByIdResource(NuGet.Protocol.Core.Types.SourceRepository sourceRepository, NuGet.Protocol.HttpSource httpSource) { }
        public override NuGet.Common.ILogger Logger { get { throw null; } set { } }
        public NuGet.Protocol.Core.Types.SourceRepository SourceRepository { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetAllVersionsAsync(string id, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.FindPackageByIdDependencyInfo> GetDependencyInfoAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> GetNupkgStreamAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<NuGet.Packaging.Core.PackageIdentity> GetOriginalIdentityAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class RemoteV3FindPackageByIdResourceProvider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public RemoteV3FindPackageByIdResourceProvider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository sourceRepository, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class ReportAbuseResourceV3 : NuGet.Protocol.Core.Types.INuGetResource
    {
        public ReportAbuseResourceV3(string uriTemplate) { }
        public System.Uri GetReportAbuseUrl(string id, NuGet.Versioning.NuGetVersion version) { throw null; }
    }
    public partial class ReportAbuseResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        public ReportAbuseResourceV3Provider() : base (default(System.Type)) { }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class SafeBoolConverter : Newtonsoft.Json.JsonConverter
    {
        public SafeBoolConverter() { }
        public override bool CanRead { get { throw null; } }
        public override bool CanWrite { get { throw null; } }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class SafeUriConverter : Newtonsoft.Json.JsonConverter
    {
        public SafeUriConverter() { }
        public override bool CanRead { get { throw null; } }
        public override bool CanWrite { get { throw null; } }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class SemaphoreSlimThrottle : NuGet.Protocol.IThrottle
    {
        public SemaphoreSlimThrottle(System.Threading.SemaphoreSlim semaphore) { }
        public static NuGet.Protocol.SemaphoreSlimThrottle CreateBinarySemaphore() { throw null; }
        public void Release() { }
        public System.Threading.Tasks.Task WaitAsync() { throw null; }
    }
    public partial class ServiceIndexResourceV3 : NuGet.Protocol.Core.Types.INuGetResource
    {
        public ServiceIndexResourceV3(Newtonsoft.Json.Linq.JObject index, System.DateTime requestTime) { }
        public virtual System.Collections.Generic.IReadOnlyList<System.Uri> this[string type] { get { throw null; } }
        public virtual System.Collections.Generic.IReadOnlyList<System.Uri> this[string[] types] { get { throw null; } }
        public virtual System.DateTime RequestTime { get { throw null; } }
    }
    public partial class ServiceIndexResourceV3Provider : NuGet.Protocol.Core.Types.ResourceProvider
    {
        protected readonly System.Collections.Concurrent.ConcurrentDictionary<string, NuGet.Protocol.ServiceIndexResourceV3Provider.ServiceIndexCacheInfo> _cache;
        public ServiceIndexResourceV3Provider() : base (default(System.Type)) { }
        public System.TimeSpan MaxCacheDuration { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]protected set { } }
        public override System.Threading.Tasks.Task<System.Tuple<bool, NuGet.Protocol.Core.Types.INuGetResource>> TryCreate(NuGet.Protocol.Core.Types.SourceRepository source, System.Threading.CancellationToken token) { throw null; }
        protected partial class ServiceIndexCacheInfo
        {
            public ServiceIndexCacheInfo() { }
            public System.DateTime CachedTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
            public NuGet.Protocol.ServiceIndexResourceV3 Index { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        }
    }
    public static partial class ServiceTypes
    {
        public static readonly string LegacyGallery;
        public static readonly string PackageBaseAddress;
        public static readonly string PackagePublish;
        public static readonly string[] RegistrationsBaseUrl;
        public static readonly string ReportAbuse;
        public static readonly string SearchAutocompleteService;
        public static readonly string[] SearchQueryService;
        public static readonly string Version200;
        public static readonly string Version300;
        public static readonly string Version300beta;
        public static readonly string Version340;
    }
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public partial class Strings
    {
        internal Strings() { }
        public static string ActionExecutor_RollingBack { get { throw null; } }
        public static string ActionResolver_UnsupportedAction { get { throw null; } }
        public static string ActionResolver_UnsupportedDependencyBehavior { get { throw null; } }
        public static string AddPackage_ExistingPackageInvalid { get { throw null; } }
        public static string AddPackage_PackageAlreadyExists { get { throw null; } }
        public static string AddPackage_SuccessfullyAdded { get { throw null; } }
        public static string ArgumentCannotBeNullOrEmpty { get { throw null; } }
        public static string Argument_Cannot_Be_Null_Or_Empty { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public static string DefaultSymbolServer { get { throw null; } }
        public static string DeleteCommandCanceled { get { throw null; } }
        public static string DeleteCommandConfirm { get { throw null; } }
        public static string DeleteCommandDeletedPackage { get { throw null; } }
        public static string DeleteCommandDeletingPackage { get { throw null; } }
        public static string DeletePackage_NotFound { get { throw null; } }
        public static string DownloadActionHandler_InvalidDownloadUrl { get { throw null; } }
        public static string DownloadActionHandler_NoDownloadUrl { get { throw null; } }
        public static string Error_DownloadTimeout { get { throw null; } }
        public static string Http_CredentialsForForbidden { get { throw null; } }
        public static string Http_CredentialsForProxy { get { throw null; } }
        public static string Http_CredentialsForUnauthorized { get { throw null; } }
        public static string Http_RequestLog { get { throw null; } }
        public static string Http_ResponseLog { get { throw null; } }
        public static string Http_Timeout { get { throw null; } }
        public static string InvalidVersionFolder { get { throw null; } }
        public static string LiveFeed { get { throw null; } }
        public static string Log_CanceledNupkgDownload { get { throw null; } }
        public static string Log_ErrorDownloading { get { throw null; } }
        public static string Log_FailedToDownloadPackage { get { throw null; } }
        public static string Log_FailedToFetchV2Feed { get { throw null; } }
        public static string Log_FailedToGetNupkgStream { get { throw null; } }
        public static string Log_FailedToGetNuspecStream { get { throw null; } }
        public static string Log_FailedToReadServiceIndex { get { throw null; } }
        public static string Log_FailedToRetrievePackage { get { throw null; } }
        public static string Log_FileIsCorrupt { get { throw null; } }
        public static string Log_InvalidCacheEntry { get { throw null; } }
        public static string Log_InvalidNupkgFromUrl { get { throw null; } }
        public static string Log_RetryingFindPackagesById { get { throw null; } }
        public static string Log_RetryingHttp { get { throw null; } }
        public static string Log_RetryingServiceIndex { get { throw null; } }
        public static string NoApiKeyFound { get { throw null; } }
        public static string NuGetRepository_CannotCreateAggregateRepo { get { throw null; } }
        public static string NuGetServiceProvider_ServiceNotSupported { get { throw null; } }
        public static string NupkgPath_Invalid { get { throw null; } }
        public static string NupkgPath_InvalidEx { get { throw null; } }
        public static string OneOrMoreUrisMustBeSpecified { get { throw null; } }
        public static string PackageActionDescriptionWrapper_UnrecognizedAction { get { throw null; } }
        public static string PackageServerEndpoint_NotSupported { get { throw null; } }
        public static string Path_Invalid { get { throw null; } }
        public static string Path_Invalid_NotFileNotUnc { get { throw null; } }
        public static string ProjectInstallationTarget_ProjectIsNotTargetted { get { throw null; } }
        public static string Protocol_BadSource { get { throw null; } }
        public static string Protocol_duplicateUri { get { throw null; } }
        public static string Protocol_FlatContainerIndexVersionsNotArray { get { throw null; } }
        public static string Protocol_IndexMissingResourcesNode { get { throw null; } }
        public static string Protocol_InvalidJsonObject { get { throw null; } }
        public static string Protocol_InvalidServiceIndex { get { throw null; } }
        public static string Protocol_InvalidXml { get { throw null; } }
        public static string Protocol_MalformedMetadataError { get { throw null; } }
        public static string Protocol_MissingRegistrationBase { get { throw null; } }
        public static string Protocol_MissingSearchService { get { throw null; } }
        public static string Protocol_MissingVersion { get { throw null; } }
        public static string Protocol_PackageMetadataError { get { throw null; } }
        public static string Protocol_Search_LocalSourceNotFound { get { throw null; } }
        public static string Protocol_UnsupportedVersion { get { throw null; } }
        public static string PushCommandPackagePushed { get { throw null; } }
        public static string PushCommandPushingPackage { get { throw null; } }
        public static string RequiredFeatureUnsupportedException_DefaultMessageWithFeature { get { throw null; } }
        public static string RequiredFeatureUnsupportedException_DefaultMessageWithoutFeature { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Resources.ResourceManager ResourceManager { get { throw null; } }
        public static string UnableToFindFile { get { throw null; } }
        public static string UnableToParseFolderV3Version { get { throw null; } }
        public static string Warning_SymbolServerNotConfigured { get { throw null; } }
    }
    public static partial class TimeoutUtility
    {
        public static System.Threading.Tasks.Task StartWithTimeout(System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task> getTask, System.TimeSpan timeout, string timeoutMessage, System.Threading.CancellationToken token) { throw null; }
        public static System.Threading.Tasks.Task<T> StartWithTimeout<T>(System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<T>> getTask, System.TimeSpan timeout, string timeoutMessage, System.Threading.CancellationToken token) { throw null; }
    }
    public partial class TokenStore
    {
        public TokenStore() { }
        public static NuGet.Protocol.TokenStore Instance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Guid Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public void AddToken(System.Uri sourceUri, string token) { }
        public string GetToken(System.Uri sourceUri) { throw null; }
    }
    public partial class V2FeedPackageInfo : NuGet.Packaging.Core.PackageIdentity
    {
        public V2FeedPackageInfo(NuGet.Packaging.Core.PackageIdentity identity, string title, string summary, string description, System.Collections.Generic.IEnumerable<string> authors, System.Collections.Generic.IEnumerable<string> owners, string iconUrl, string licenseUrl, string projectUrl, string reportAbuseUrl, string tags, System.Nullable<System.DateTimeOffset> published, string dependencies, bool requireLicenseAccept, string downloadUrl, string downloadCount, string packageHash, string packageHashAlgorithm, NuGet.Versioning.NuGetVersion minClientVersion) : base (default(string), default(NuGet.Versioning.NuGetVersion)) { }
        public System.Collections.Generic.IEnumerable<string> Authors { get { throw null; } }
        public string Dependencies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<NuGet.Packaging.PackageDependencyGroup> DependencySets { get { throw null; } }
        public string Description { get { throw null; } }
        public string DownloadCount { get { throw null; } }
        public int DownloadCountAsInt { get { throw null; } }
        public string DownloadUrl { get { throw null; } }
        public string IconUrl { get { throw null; } }
        public bool IsListed { get { throw null; } }
        public string LicenseUrl { get { throw null; } }
        public NuGet.Versioning.NuGetVersion MinClientVersion { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Owners { get { throw null; } }
        public string PackageHash { get { throw null; } }
        public string PackageHashAlgorithm { get { throw null; } }
        public string ProjectUrl { get { throw null; } }
        public System.Nullable<System.DateTimeOffset> Published { get { throw null; } }
        public string ReportAbuseUrl { get { throw null; } }
        public bool RequireLicenseAcceptance { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Tags { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public sealed partial class V2FeedParser
    {
        public V2FeedParser(NuGet.Protocol.HttpSource httpSource, string baseAddress) { }
        public V2FeedParser(NuGet.Protocol.HttpSource httpSource, string baseAddress, NuGet.Configuration.PackageSource source) { }
        public NuGet.Configuration.PackageSource Source { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.DownloadResourceResult> DownloadFromIdentity(NuGet.Packaging.Core.PackageIdentity package, NuGet.Configuration.ISettings settings, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.DownloadResourceResult> DownloadFromUrl(NuGet.Packaging.Core.PackageIdentity package, System.Uri downloadUri, NuGet.Configuration.ISettings settings, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<NuGet.Protocol.V2FeedPackageInfo>> FindPackagesByIdAsync(string id, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<NuGet.Protocol.V2FeedPackageInfo>> FindPackagesByIdAsync(string id, bool includeUnlisted, bool includePrerelease, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public static string GetBaseAddress(System.IO.Stream stream) { throw null; }
        public System.Threading.Tasks.Task<NuGet.Protocol.V2FeedPackageInfo> GetPackage(NuGet.Packaging.Core.PackageIdentity package, NuGet.Common.ILogger log, System.Threading.CancellationToken token) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<NuGet.Protocol.V2FeedPackageInfo>> Search(string searchTerm, NuGet.Protocol.Core.Types.SearchFilter filters, int skip, int take, NuGet.Common.ILogger log, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class VersionInfoConverter : Newtonsoft.Json.JsonConverter
    {
        public VersionInfoConverter() { }
        public override bool CanWrite { get { throw null; } }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
}
namespace NuGet.Protocol.Core.Types
{
    public partial class FindPackageByIdDependencyInfo
    {
        public FindPackageByIdDependencyInfo(System.Collections.Generic.IEnumerable<NuGet.Packaging.PackageDependencyGroup> dependencyGroups, System.Collections.Generic.IEnumerable<NuGet.Packaging.FrameworkSpecificGroup> frameworkReferenceGroups) { }
        public System.Collections.Generic.IReadOnlyList<NuGet.Packaging.PackageDependencyGroup> DependencyGroups { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<NuGet.Packaging.FrameworkSpecificGroup> FrameworkReferenceGroups { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public abstract partial class FindPackageByIdResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        protected FindPackageByIdResource() { }
        public virtual NuGet.Protocol.Core.Types.SourceCacheContext CacheContext { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public virtual NuGet.Common.ILogger Logger { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        protected NuGet.Protocol.Core.Types.HttpSourceCacheContext CreateCacheContext(int retryCount) { throw null; }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion>> GetAllVersionsAsync(string id, System.Threading.CancellationToken token);
        protected static NuGet.Protocol.Core.Types.FindPackageByIdDependencyInfo GetDependencyInfo(NuGet.Packaging.NuspecReader reader) { throw null; }
        public abstract System.Threading.Tasks.Task<NuGet.Protocol.Core.Types.FindPackageByIdDependencyInfo> GetDependencyInfoAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken token);
        public abstract System.Threading.Tasks.Task<System.IO.Stream> GetNupkgStreamAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken token);
        public abstract System.Threading.Tasks.Task<NuGet.Packaging.Core.PackageIdentity> GetOriginalIdentityAsync(string id, NuGet.Versioning.NuGetVersion version, System.Threading.CancellationToken token);
    }
    public partial class OfflineFeedAddContext
    {
        public OfflineFeedAddContext(string packagePath, string source, NuGet.Common.ILogger logger, bool throwIfSourcePackageIsInvalid, bool throwIfPackageExistsAndInvalid, bool throwIfPackageExists, bool expand) { }
        public bool Expand { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Common.ILogger Logger { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string PackagePath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Source { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool ThrowIfPackageExists { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool ThrowIfPackageExistsAndInvalid { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool ThrowIfSourcePackageIsInvalid { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public static partial class OfflineFeedUtility
    {
        public static System.Threading.Tasks.Task AddPackageToSource(NuGet.Protocol.Core.Types.OfflineFeedAddContext offlineFeedAddContext, System.Threading.CancellationToken token) { throw null; }
        public static string GetPackageDirectory(NuGet.Packaging.Core.PackageIdentity packageIdentity, string offlineFeed) { throw null; }
        public static bool PackageExists(NuGet.Packaging.Core.PackageIdentity packageIdentity, string offlineFeed, out bool isValidPackage) { isValidPackage = default(bool); throw null; }
        public static void ThrowIfInvalid(string path) { }
        public static void ThrowIfInvalidOrNotFound(string path, bool isDirectory, string resourceString) { }
    }
    public partial class PackageUpdateResource : NuGet.Protocol.Core.Types.INuGetResource
    {
        public PackageUpdateResource(string source, NuGet.Protocol.HttpSource httpSource) { }
        public System.Uri SourceUri { get { throw null; } }
        public System.Threading.Tasks.Task Delete(string packageId, string packageVersion, System.Func<string, string> getApiKey, System.Func<string, bool> confirm, NuGet.Common.ILogger log) { throw null; }
        public static void ForceDeleteDirectory(string path) { }
        public System.Threading.Tasks.Task Push(string packagePath, string symbolSource, int timeoutInSecond, bool disableBuffering, System.Func<string, string> getApiKey, System.Func<string, string> getSymbolApiKey, NuGet.Common.ILogger log) { throw null; }
    }
}
