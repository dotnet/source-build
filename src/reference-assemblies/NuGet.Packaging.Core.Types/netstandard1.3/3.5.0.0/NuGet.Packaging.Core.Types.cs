[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("NuGet v3 core library.")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("3.5.0.1996")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("3.5.0-rtm-1996")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("NuGet")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.3")]
namespace NuGet.Packaging
{
    public partial class FrameworkSpecificGroup : NuGet.Frameworks.IFrameworkSpecific, System.IEquatable<NuGet.Packaging.FrameworkSpecificGroup>
    {
        public FrameworkSpecificGroup(NuGet.Frameworks.NuGetFramework targetFramework, System.Collections.Generic.IEnumerable<string> items) { }
        public bool HasEmptyFolder { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Items { get { throw null; } }
        public NuGet.Frameworks.NuGetFramework TargetFramework { get { throw null; } }
        public bool Equals(NuGet.Packaging.FrameworkSpecificGroup other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class PackageDependencyGroup : NuGet.Frameworks.IFrameworkSpecific, System.IEquatable<NuGet.Packaging.PackageDependencyGroup>
    {
        public PackageDependencyGroup(NuGet.Frameworks.NuGetFramework targetFramework, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependency> packages) { }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependency> Packages { get { throw null; } }
        public NuGet.Frameworks.NuGetFramework TargetFramework { get { throw null; } }
        public bool Equals(NuGet.Packaging.PackageDependencyGroup other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace NuGet.Packaging.Core
{
    public partial class ContentFilesEntry
    {
        public ContentFilesEntry(string include, string exclude, string buildAction, System.Nullable<bool> copyToOutput, System.Nullable<bool> flatten) { }
        public string BuildAction { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<bool> CopyToOutput { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Exclude { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Nullable<bool> Flatten { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Include { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial interface IPackageIdentityComparer : System.Collections.Generic.IComparer<NuGet.Packaging.Core.PackageIdentity>, System.Collections.Generic.IEqualityComparer<NuGet.Packaging.Core.PackageIdentity>
    {
    }
    public partial class PackageDependency : System.IEquatable<NuGet.Packaging.Core.PackageDependency>
    {
        public PackageDependency(string id) { }
        public PackageDependency(string id, NuGet.Versioning.VersionRange versionRange) { }
        public PackageDependency(string id, NuGet.Versioning.VersionRange versionRange, System.Collections.Generic.IReadOnlyList<string> include, System.Collections.Generic.IReadOnlyList<string> exclude) { }
        public System.Collections.Generic.IReadOnlyList<string> Exclude { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Include { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Versioning.VersionRange VersionRange { get { throw null; } }
        public bool Equals(NuGet.Packaging.Core.PackageDependency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PackageDependencyComparer : System.Collections.Generic.IEqualityComparer<NuGet.Packaging.Core.PackageDependency>
    {
        public static readonly NuGet.Packaging.Core.PackageDependencyComparer Default;
        public PackageDependencyComparer() { }
        public PackageDependencyComparer(NuGet.Versioning.IVersionRangeComparer versionRangeComparer) { }
        public bool Equals(NuGet.Packaging.Core.PackageDependency x, NuGet.Packaging.Core.PackageDependency y) { throw null; }
        public int GetHashCode(NuGet.Packaging.Core.PackageDependency obj) { throw null; }
    }
    public partial class PackageDependencyInfo : NuGet.Packaging.Core.PackageIdentity, System.IEquatable<NuGet.Packaging.Core.PackageDependencyInfo>
    {
        public PackageDependencyInfo(NuGet.Packaging.Core.PackageIdentity identity, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependency> dependencies) : base (default(string), default(NuGet.Versioning.NuGetVersion)) { }
        public PackageDependencyInfo(string id, NuGet.Versioning.NuGetVersion version) : base (default(string), default(NuGet.Versioning.NuGetVersion)) { }
        public PackageDependencyInfo(string id, NuGet.Versioning.NuGetVersion version, System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependency> dependencies) : base (default(string), default(NuGet.Versioning.NuGetVersion)) { }
        public System.Collections.Generic.IEnumerable<NuGet.Packaging.Core.PackageDependency> Dependencies { get { throw null; } }
        public bool Equals(NuGet.Packaging.Core.PackageDependencyInfo other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PackageDependencyInfoComparer : System.Collections.Generic.IEqualityComparer<NuGet.Packaging.Core.PackageDependencyInfo>
    {
        public PackageDependencyInfoComparer() { }
        public PackageDependencyInfoComparer(NuGet.Packaging.Core.IPackageIdentityComparer identityComparer, NuGet.Packaging.Core.PackageDependencyComparer dependencyComparer) { }
        public static NuGet.Packaging.Core.PackageDependencyInfoComparer Default { get { throw null; } }
        public bool Equals(NuGet.Packaging.Core.PackageDependencyInfo x, NuGet.Packaging.Core.PackageDependencyInfo y) { throw null; }
        public int GetHashCode(NuGet.Packaging.Core.PackageDependencyInfo obj) { throw null; }
    }
    public partial class PackageIdentity : System.IComparable<NuGet.Packaging.Core.PackageIdentity>, System.IEquatable<NuGet.Packaging.Core.PackageIdentity>
    {
        public PackageIdentity(string id, NuGet.Versioning.NuGetVersion version) { }
        public static NuGet.Packaging.Core.PackageIdentityComparer Comparer { get { throw null; } }
        public bool HasVersion { get { throw null; } }
        public string Id { get { throw null; } }
        public NuGet.Versioning.NuGetVersion Version { get { throw null; } }
        public int CompareTo(NuGet.Packaging.Core.PackageIdentity other) { throw null; }
        public bool Equals(NuGet.Packaging.Core.PackageIdentity other) { throw null; }
        public virtual bool Equals(NuGet.Packaging.Core.PackageIdentity other, NuGet.Versioning.VersionComparison versionComparison) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PackageIdentityComparer : NuGet.Packaging.Core.IPackageIdentityComparer, System.Collections.Generic.IComparer<NuGet.Packaging.Core.PackageIdentity>, System.Collections.Generic.IEqualityComparer<NuGet.Packaging.Core.PackageIdentity>
    {
        public PackageIdentityComparer() { }
        public PackageIdentityComparer(NuGet.Versioning.IVersionComparer versionComparer) { }
        public PackageIdentityComparer(NuGet.Versioning.VersionComparison versionComparison) { }
        public static NuGet.Packaging.Core.PackageIdentityComparer Default { get { throw null; } }
        public int Compare(NuGet.Packaging.Core.PackageIdentity x, NuGet.Packaging.Core.PackageIdentity y) { throw null; }
        public bool Equals(NuGet.Packaging.Core.PackageIdentity x, NuGet.Packaging.Core.PackageIdentity y) { throw null; }
        public int GetHashCode(NuGet.Packaging.Core.PackageIdentity obj) { throw null; }
    }
    public static partial class PackagingCoreConstants
    {
        public static readonly string EmptyFolder;
        public static readonly string ForwardSlashEmptyFolder;
        public static readonly string NupkgExtension;
        public static readonly string NuspecExtension;
    }
}
