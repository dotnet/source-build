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
namespace NuGet.DependencyResolver
{
    public partial class AnalyzeResult<TItem>
    {
        public AnalyzeResult() { }
        public System.Collections.Generic.List<NuGet.DependencyResolver.GraphNode<TItem>> Cycles { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.List<NuGet.DependencyResolver.DowngradeResult<TItem>> Downgrades { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.List<NuGet.DependencyResolver.VersionConflictResult<TItem>> VersionConflicts { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public void Combine(NuGet.DependencyResolver.AnalyzeResult<TItem> result) { }
    }
    public enum Disposition
    {
        Acceptable = 0,
        Accepted = 2,
        Cycle = 4,
        PotentiallyDowngraded = 3,
        Rejected = 1,
    }
    public partial class DowngradeResult<TItem>
    {
        public DowngradeResult() { }
        public NuGet.DependencyResolver.GraphNode<TItem> DowngradedFrom { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.DependencyResolver.GraphNode<TItem> DowngradedTo { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class GraphEdge<TItem>
    {
        public GraphEdge(NuGet.DependencyResolver.GraphEdge<TItem> outerEdge, NuGet.DependencyResolver.GraphItem<TItem> item, NuGet.LibraryModel.LibraryDependency edge) { }
        public NuGet.LibraryModel.LibraryDependency Edge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.DependencyResolver.GraphItem<TItem> Item { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.DependencyResolver.GraphEdge<TItem> OuterEdge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{Key}")]
    public partial class GraphItem<TItem> : System.IEquatable<NuGet.DependencyResolver.GraphItem<TItem>>
    {
        public GraphItem(NuGet.LibraryModel.LibraryIdentity key) { }
        public TItem Data { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryIdentity Key { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.DependencyResolver.GraphItem<TItem> other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class GraphNode<TItem>
    {
        public GraphNode(NuGet.LibraryModel.LibraryRange key) { }
        public NuGet.DependencyResolver.Disposition Disposition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.DependencyResolver.GraphNode<TItem>> InnerNodes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.DependencyResolver.GraphItem<TItem> Item { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryRange Key { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.DependencyResolver.GraphNode<TItem> OuterNode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override string ToString() { throw null; }
    }
    public static partial class GraphOperations
    {
        public static NuGet.DependencyResolver.AnalyzeResult<NuGet.DependencyResolver.RemoteResolveResult> Analyze(this NuGet.DependencyResolver.GraphNode<NuGet.DependencyResolver.RemoteResolveResult> root) { throw null; }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Dump<TItem>(this NuGet.DependencyResolver.GraphNode<TItem> root, System.Action<string> write) { }
        public static void ForEach<TItem>(this NuGet.DependencyResolver.GraphNode<TItem> root, System.Action<NuGet.DependencyResolver.GraphNode<TItem>> visitor) { }
        public static void ForEach<TItem>(this System.Collections.Generic.IEnumerable<NuGet.DependencyResolver.GraphNode<TItem>> roots, System.Action<NuGet.DependencyResolver.GraphNode<TItem>> visitor) { }
        public static void ForEach<TItem, TState>(this NuGet.DependencyResolver.GraphNode<TItem> root, TState state, System.Func<NuGet.DependencyResolver.GraphNode<TItem>, TState, TState> visitor) { }
        public static string GetPath<TItem>(this NuGet.DependencyResolver.GraphNode<TItem> node) { throw null; }
        public static NuGet.DependencyResolver.GraphNode<TItem> Path<TItem>(this NuGet.DependencyResolver.GraphNode<TItem> node, params string[] path) { throw null; }
    }
    public partial interface IDependencyProvider
    {
        NuGet.LibraryModel.Library GetLibrary(NuGet.LibraryModel.LibraryRange libraryRange, NuGet.Frameworks.NuGetFramework targetFramework);
        bool SupportsType(NuGet.LibraryModel.LibraryDependencyTarget libraryTypeFlag);
    }
    public partial interface IRemoteDependencyProvider
    {
        bool IsHttp { get; }
        System.Threading.Tasks.Task CopyToAsync(NuGet.LibraryModel.LibraryIdentity match, System.IO.Stream stream, NuGet.Protocol.Core.Types.SourceCacheContext cacheContext, NuGet.Common.ILogger logger, System.Threading.CancellationToken cancellationToken);
        System.Threading.Tasks.Task<NuGet.LibraryModel.LibraryIdentity> FindLibraryAsync(NuGet.LibraryModel.LibraryRange libraryRange, NuGet.Frameworks.NuGetFramework targetFramework, NuGet.Protocol.Core.Types.SourceCacheContext cacheContext, NuGet.Common.ILogger logger, System.Threading.CancellationToken cancellationToken);
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.LibraryModel.LibraryDependency>> GetDependenciesAsync(NuGet.LibraryModel.LibraryIdentity match, NuGet.Frameworks.NuGetFramework targetFramework, NuGet.Protocol.Core.Types.SourceCacheContext cacheContext, NuGet.Common.ILogger logger, System.Threading.CancellationToken cancellationToken);
    }
    public partial class LibraryRangeCacheKey : System.IEquatable<NuGet.DependencyResolver.LibraryRangeCacheKey>
    {
        public LibraryRangeCacheKey(NuGet.LibraryModel.LibraryRange range, NuGet.Frameworks.NuGetFramework framework) { }
        public NuGet.Frameworks.NuGetFramework Framework { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.LibraryModel.LibraryRange LibraryRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Equals(NuGet.DependencyResolver.LibraryRangeCacheKey other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocalDependencyProvider : NuGet.DependencyResolver.IRemoteDependencyProvider
    {
        public LocalDependencyProvider(NuGet.DependencyResolver.IDependencyProvider dependencyProvider) { }
        public bool IsHttp { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Threading.Tasks.Task CopyToAsync(NuGet.LibraryModel.LibraryIdentity match, System.IO.Stream stream, NuGet.Protocol.Core.Types.SourceCacheContext cacheContext, NuGet.Common.ILogger logger, System.Threading.CancellationToken cancellationToken) { throw null; }
        public System.Threading.Tasks.Task<NuGet.LibraryModel.LibraryIdentity> FindLibraryAsync(NuGet.LibraryModel.LibraryRange libraryRange, NuGet.Frameworks.NuGetFramework targetFramework, NuGet.Protocol.Core.Types.SourceCacheContext cacheContext, NuGet.Common.ILogger logger, System.Threading.CancellationToken cancellationToken) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<NuGet.LibraryModel.LibraryDependency>> GetDependenciesAsync(NuGet.LibraryModel.LibraryIdentity library, NuGet.Frameworks.NuGetFramework targetFramework, NuGet.Protocol.Core.Types.SourceCacheContext cacheContext, NuGet.Common.ILogger logger, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class LocalMatch : NuGet.DependencyResolver.RemoteMatch
    {
        public LocalMatch() { }
        public NuGet.LibraryModel.Library LocalLibrary { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.DependencyResolver.IDependencyProvider LocalProvider { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public static partial class PackagingUtility
    {
        public static NuGet.LibraryModel.LibraryDependency GetLibraryDependencyFromNuspec(NuGet.Packaging.Core.PackageDependency dependency) { throw null; }
    }
    public partial class RemoteDependencyWalker
    {
        public RemoteDependencyWalker(NuGet.DependencyResolver.RemoteWalkContext context) { }
        public static bool IsGreaterThanOrEqualTo(NuGet.Versioning.VersionRange nearVersion, NuGet.Versioning.VersionRange farVersion) { throw null; }
        public System.Threading.Tasks.Task<NuGet.DependencyResolver.GraphNode<NuGet.DependencyResolver.RemoteResolveResult>> WalkAsync(NuGet.LibraryModel.LibraryRange library, NuGet.Frameworks.NuGetFramework framework, string runtimeIdentifier, NuGet.RuntimeModel.RuntimeGraph runtimeGraph, bool recursive) { throw null; }
    }
    public partial class RemoteMatch : System.IEquatable<NuGet.DependencyResolver.RemoteMatch>
    {
        public RemoteMatch() { }
        public NuGet.LibraryModel.LibraryIdentity Library { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.DependencyResolver.IRemoteDependencyProvider Provider { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.DependencyResolver.RemoteMatch other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class RemoteResolveResult
    {
        public RemoteResolveResult() { }
        public System.Collections.Generic.IEnumerable<NuGet.LibraryModel.LibraryDependency> Dependencies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.DependencyResolver.RemoteMatch Match { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class RemoteWalkContext
    {
        public RemoteWalkContext(NuGet.Protocol.Core.Types.SourceCacheContext cacheContext, NuGet.Common.ILogger logger) { }
        public NuGet.Protocol.Core.Types.SourceCacheContext CacheContext { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Concurrent.ConcurrentDictionary<NuGet.DependencyResolver.LibraryRangeCacheKey, System.Threading.Tasks.Task<NuGet.DependencyResolver.GraphItem<NuGet.DependencyResolver.RemoteResolveResult>>> FindLibraryEntryCache { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool IsMsBuildBased { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<NuGet.DependencyResolver.IRemoteDependencyProvider> LocalLibraryProviders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Common.ILogger Logger { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Concurrent.ConcurrentDictionary<NuGet.Packaging.Core.PackageIdentity, System.Collections.Generic.IList<string>> PackageFileCache { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IList<NuGet.DependencyResolver.IDependencyProvider> ProjectLibraryProviders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IList<NuGet.DependencyResolver.IRemoteDependencyProvider> RemoteLibraryProviders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class Tracker<TItem>
    {
        public Tracker() { }
        public System.Collections.Generic.IEnumerable<NuGet.DependencyResolver.GraphItem<TItem>> GetDisputes(NuGet.DependencyResolver.GraphItem<TItem> item) { throw null; }
        public bool IsAmbiguous(NuGet.DependencyResolver.GraphItem<TItem> item) { throw null; }
        public bool IsBestVersion(NuGet.DependencyResolver.GraphItem<TItem> item) { throw null; }
        public bool IsDisputed(NuGet.DependencyResolver.GraphItem<TItem> item) { throw null; }
        public void MarkAmbiguous(NuGet.DependencyResolver.GraphItem<TItem> item) { }
        public void Track(NuGet.DependencyResolver.GraphItem<TItem> item) { }
    }
    public partial class VersionConflictResult<TItem>
    {
        public VersionConflictResult() { }
        public NuGet.DependencyResolver.GraphNode<TItem> Conflicting { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.DependencyResolver.GraphNode<TItem> Selected { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
}
