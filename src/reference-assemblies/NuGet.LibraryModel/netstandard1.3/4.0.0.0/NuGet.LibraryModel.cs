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
namespace NuGet.LibraryModel
{
    public static partial class KnownLibraryProperties
    {
        public static readonly string AssemblyPath;
        public static readonly string FrameworkAssemblies;
        public static readonly string LockFileLibrary;
        public static readonly string LockFileTargetLibrary;
        public static readonly string MSBuildProjectPath;
        public static readonly string PackageSpec;
        public static readonly string ProjectFrameworks;
        public static readonly string ProjectRestoreMetadataFiles;
        public static readonly string ProjectStyle;
        public static readonly string TargetFrameworkInformation;
    }
    public partial class Library
    {
        public static readonly System.Collections.Generic.IEqualityComparer<NuGet.LibraryModel.Library> IdentityComparer;
        public Library() { }
        public System.Collections.Generic.IEnumerable<NuGet.LibraryModel.LibraryDependency> Dependencies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryIdentity Identity { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Items { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryRange LibraryRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Resolved { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override string ToString() { throw null; }
    }
    public partial class LibraryDependency : System.IEquatable<NuGet.LibraryModel.LibraryDependency>
    {
        public LibraryDependency() { }
        public bool AutoReferenced { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryIncludeFlags IncludeType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryRange LibraryRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Name { get { throw null; } }
        public NuGet.LibraryModel.LibraryIncludeFlags SuppressParent { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryDependencyType Type { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryDependency Clone() { throw null; }
        public bool Equals(NuGet.LibraryModel.LibraryDependency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public bool HasFlag(NuGet.LibraryModel.LibraryDependencyTypeFlag flag) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum LibraryDependencyTarget : ushort
    {
        All = (ushort)63,
        Assembly = (ushort)8,
        ExternalProject = (ushort)4,
        None = (ushort)0,
        Package = (ushort)1,
        PackageProjectExternal = (ushort)7,
        Project = (ushort)2,
        Reference = (ushort)16,
        WinMD = (ushort)32,
    }
    public partial class LibraryDependencyTargetUtils
    {
        public LibraryDependencyTargetUtils() { }
        public static string GetFlagString(NuGet.LibraryModel.LibraryDependencyTarget flags) { throw null; }
        public static NuGet.LibraryModel.LibraryDependencyTarget Parse(string flag) { throw null; }
    }
    public partial class LibraryDependencyType : System.IEquatable<NuGet.LibraryModel.LibraryDependencyType>
    {
        public static NuGet.LibraryModel.LibraryDependencyType Build;
        public static NuGet.LibraryModel.LibraryDependencyType Default;
        public static NuGet.LibraryModel.LibraryDependencyType Platform;
        public LibraryDependencyType() { }
        public NuGet.LibraryModel.LibraryDependencyType Combine(System.Collections.Generic.IEnumerable<NuGet.LibraryModel.LibraryDependencyTypeFlag> add, System.Collections.Generic.IEnumerable<NuGet.LibraryModel.LibraryDependencyTypeFlag> remove) { throw null; }
        public bool Contains(NuGet.LibraryModel.LibraryDependencyTypeFlag flag) { throw null; }
        public bool Equals(NuGet.LibraryModel.LibraryDependencyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static NuGet.LibraryModel.LibraryDependencyType Parse(System.Collections.Generic.IEnumerable<string> keywords) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LibraryDependencyTypeFlag
    {
        internal LibraryDependencyTypeFlag() { }
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeFlag BecomesNupkgDependency;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeFlag DevComponent;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeFlag MainExport;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeFlag MainReference;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeFlag MainSource;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeFlag PreprocessComponent;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeFlag PreprocessReference;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeFlag RuntimeComponent;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeFlag SharedFramework;
        public static NuGet.LibraryModel.LibraryDependencyTypeFlag Declare(string keyword) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LibraryDependencyTypeKeyword
    {
        internal LibraryDependencyTypeKeyword() { }
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeKeyword Build;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeKeyword Default;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeKeyword Dev;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeKeyword Platform;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeKeyword Preprocess;
        public static readonly NuGet.LibraryModel.LibraryDependencyTypeKeyword Private;
        public System.Collections.Generic.IEnumerable<NuGet.LibraryModel.LibraryDependencyTypeFlag> FlagsToAdd { get { throw null; } }
        public System.Collections.Generic.IEnumerable<NuGet.LibraryModel.LibraryDependencyTypeFlag> FlagsToRemove { get { throw null; } }
        public NuGet.LibraryModel.LibraryDependencyType CreateType() { throw null; }
    }
    public static partial class LibraryExtensions
    {
        public static T GetItem<T>(this NuGet.LibraryModel.Library library, string key) { throw null; }
        public static T GetRequiredItem<T>(this NuGet.LibraryModel.Library library, string key) { throw null; }
        public static bool IsEclipsedBy(this NuGet.LibraryModel.LibraryRange library, NuGet.LibraryModel.LibraryRange other) { throw null; }
    }
    public partial class LibraryIdentity : System.IComparable<NuGet.LibraryModel.LibraryIdentity>, System.IEquatable<NuGet.LibraryModel.LibraryIdentity>
    {
        public LibraryIdentity() { }
        public LibraryIdentity(string name, NuGet.Versioning.NuGetVersion version, NuGet.LibraryModel.LibraryType type) { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryType Type { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Versioning.NuGetVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public int CompareTo(NuGet.LibraryModel.LibraryIdentity other) { throw null; }
        public bool Equals(NuGet.LibraryModel.LibraryIdentity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(NuGet.LibraryModel.LibraryIdentity left, NuGet.LibraryModel.LibraryIdentity right) { throw null; }
        public static implicit operator NuGet.LibraryModel.LibraryRange (NuGet.LibraryModel.LibraryIdentity library) { throw null; }
        public static bool operator !=(NuGet.LibraryModel.LibraryIdentity left, NuGet.LibraryModel.LibraryIdentity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum LibraryIncludeFlags : ushort
    {
        All = (ushort)63,
        Analyzers = (ushort)32,
        Build = (ushort)4,
        Compile = (ushort)2,
        ContentFiles = (ushort)16,
        Native = (ushort)8,
        None = (ushort)0,
        Runtime = (ushort)1,
    }
    public partial class LibraryIncludeFlagUtils
    {
        public static readonly NuGet.LibraryModel.LibraryIncludeFlags DefaultSuppressParent;
        public static readonly NuGet.LibraryModel.LibraryIncludeFlags NoContent;
        public LibraryIncludeFlagUtils() { }
        public static NuGet.LibraryModel.LibraryIncludeFlags GetFlags(System.Collections.Generic.IEnumerable<string> flags) { throw null; }
        public static NuGet.LibraryModel.LibraryIncludeFlags GetFlags(string flags, NuGet.LibraryModel.LibraryIncludeFlags defaultFlags) { throw null; }
        public static string GetFlagString(NuGet.LibraryModel.LibraryIncludeFlags flags) { throw null; }
    }
    public partial class LibraryRange : System.IEquatable<NuGet.LibraryModel.LibraryRange>
    {
        public LibraryRange() { }
        public LibraryRange(string name, NuGet.LibraryModel.LibraryDependencyTarget typeConstraint) { }
        public LibraryRange(string name, NuGet.Versioning.VersionRange versionRange, NuGet.LibraryModel.LibraryDependencyTarget typeConstraint) { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.LibraryModel.LibraryDependencyTarget TypeConstraint { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public NuGet.Versioning.VersionRange VersionRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Equals(NuGet.LibraryModel.LibraryRange other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(NuGet.LibraryModel.LibraryRange left, NuGet.LibraryModel.LibraryRange right) { throw null; }
        public static bool operator !=(NuGet.LibraryModel.LibraryRange left, NuGet.LibraryModel.LibraryRange right) { throw null; }
        public string ToLockFileDependencyGroupString() { throw null; }
        public override string ToString() { throw null; }
        public bool TypeConstraintAllows(NuGet.LibraryModel.LibraryDependencyTarget flag) { throw null; }
        public bool TypeConstraintAllowsAnyOf(NuGet.LibraryModel.LibraryDependencyTarget flag) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct LibraryType : System.IEquatable<NuGet.LibraryModel.LibraryType>
    {
        public static readonly NuGet.LibraryModel.LibraryType Assembly;
        public static readonly NuGet.LibraryModel.LibraryType ExternalProject;
        public static readonly NuGet.LibraryModel.LibraryType Package;
        public static readonly NuGet.LibraryModel.LibraryType Project;
        public static readonly NuGet.LibraryModel.LibraryType Reference;
        public static readonly NuGet.LibraryModel.LibraryType Unresolved;
        public static readonly NuGet.LibraryModel.LibraryType WinMD;
        public bool IsKnown { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Value { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Equals(NuGet.LibraryModel.LibraryType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(NuGet.LibraryModel.LibraryType left, NuGet.LibraryModel.LibraryType right) { throw null; }
        public static implicit operator string (NuGet.LibraryModel.LibraryType libraryType) { throw null; }
        public static bool operator !=(NuGet.LibraryModel.LibraryType left, NuGet.LibraryModel.LibraryType right) { throw null; }
        public static NuGet.LibraryModel.LibraryType Parse(string value) { throw null; }
        public override string ToString() { throw null; }
    }
}
