[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Microsoft Corporation. All rights reserved.")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("NuGet's implementation of Semantic Versioning.")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.0.2283")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.0-rtm-2283")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("NuGet")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.0")]
namespace NuGet.Versioning
{
    public partial class FloatRange : System.IEquatable<NuGet.Versioning.FloatRange>
    {
        public FloatRange(NuGet.Versioning.NuGetVersionFloatBehavior floatBehavior) { }
        public FloatRange(NuGet.Versioning.NuGetVersionFloatBehavior floatBehavior, NuGet.Versioning.NuGetVersion minVersion) { }
        public FloatRange(NuGet.Versioning.NuGetVersionFloatBehavior floatBehavior, NuGet.Versioning.NuGetVersion minVersion, string releasePrefix) { }
        public NuGet.Versioning.NuGetVersionFloatBehavior FloatBehavior { get { throw null; } }
        public bool HasMinVersion { get { throw null; } }
        public NuGet.Versioning.NuGetVersion MinVersion { get { throw null; } }
        public bool Equals(NuGet.Versioning.FloatRange other) { throw null; }
        public override int GetHashCode() { throw null; }
        public static NuGet.Versioning.FloatRange Parse(string versionString) { throw null; }
        public bool Satisfies(NuGet.Versioning.NuGetVersion version) { throw null; }
        public override string ToString() { throw null; }
        public static bool TryParse(string versionString, out NuGet.Versioning.FloatRange range) { range = default(NuGet.Versioning.FloatRange); throw null; }
    }
    public partial interface INuGetVersionable
    {
        NuGet.Versioning.NuGetVersion Version { get; }
    }
    public partial interface IVersionComparer : System.Collections.Generic.IComparer<NuGet.Versioning.SemanticVersion>, System.Collections.Generic.IEqualityComparer<NuGet.Versioning.SemanticVersion>
    {
    }
    public partial interface IVersionRangeComparer : System.Collections.Generic.IEqualityComparer<NuGet.Versioning.VersionRangeBase>
    {
    }
    public partial class NuGetVersion : NuGet.Versioning.SemanticVersion
    {
        public NuGetVersion(NuGet.Versioning.NuGetVersion version) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(int major, int minor, int patch) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(int major, int minor, int patch, System.Collections.Generic.IEnumerable<string> releaseLabels, string metadata) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(int major, int minor, int patch, int revision) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(int major, int minor, int patch, int revision, System.Collections.Generic.IEnumerable<string> releaseLabels, string metadata) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(int major, int minor, int patch, int revision, string releaseLabel, string metadata) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(int major, int minor, int patch, string releaseLabel) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(int major, int minor, int patch, string releaseLabel, string metadata) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(string version) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(System.Version version, System.Collections.Generic.IEnumerable<string> releaseLabels, string metadata, string originalVersion) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public NuGetVersion(System.Version version, string releaseLabel=null, string metadata=null) : base (default(NuGet.Versioning.SemanticVersion)) { }
        public virtual bool IsLegacyVersion { get { throw null; } }
        public bool IsSemVer2 { get { throw null; } }
        public int Revision { get { throw null; } }
        public System.Version Version { get { throw null; } }
        public static new NuGet.Versioning.NuGetVersion Parse(string value) { throw null; }
        public override string ToString() { throw null; }
        public static bool TryParse(string value, out NuGet.Versioning.NuGetVersion version) { version = default(NuGet.Versioning.NuGetVersion); throw null; }
        public static bool TryParseStrict(string value, out NuGet.Versioning.NuGetVersion version) { version = default(NuGet.Versioning.NuGetVersion); throw null; }
    }
    public enum NuGetVersionFloatBehavior
    {
        AbsoluteLatest = 6,
        Major = 5,
        Minor = 4,
        None = 0,
        Patch = 3,
        Prerelease = 1,
        Revision = 2,
    }
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public partial class Resources
    {
        internal Resources() { }
        public static string Argument_Cannot_Be_Null_Or_Empty { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public static string Invalidvalue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(2))]
        public static System.Resources.ResourceManager ResourceManager { get { throw null; } }
    }
    public partial class SemanticVersion : System.IComparable, System.IComparable<NuGet.Versioning.SemanticVersion>, System.IEquatable<NuGet.Versioning.SemanticVersion>, System.IFormattable
    {
        public SemanticVersion(NuGet.Versioning.SemanticVersion version) { }
        public SemanticVersion(int major, int minor, int patch) { }
        public SemanticVersion(int major, int minor, int patch, System.Collections.Generic.IEnumerable<string> releaseLabels, string metadata) { }
        protected SemanticVersion(int major, int minor, int patch, int revision, System.Collections.Generic.IEnumerable<string> releaseLabels, string metadata) { }
        protected SemanticVersion(int major, int minor, int patch, int revision, string releaseLabel, string metadata) { }
        public SemanticVersion(int major, int minor, int patch, string releaseLabel) { }
        public SemanticVersion(int major, int minor, int patch, string releaseLabel, string metadata) { }
        protected SemanticVersion(System.Version version, System.Collections.Generic.IEnumerable<string> releaseLabels, string metadata) { }
        protected SemanticVersion(System.Version version, string releaseLabel=null, string metadata=null) { }
        public virtual bool HasMetadata { get { throw null; } }
        public virtual bool IsPrerelease { get { throw null; } }
        public int Major { get { throw null; } }
        public virtual string Metadata { get { throw null; } }
        public int Minor { get { throw null; } }
        public int Patch { get { throw null; } }
        public string Release { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> ReleaseLabels { get { throw null; } }
        public virtual int CompareTo(NuGet.Versioning.SemanticVersion other) { throw null; }
        public virtual int CompareTo(NuGet.Versioning.SemanticVersion other, NuGet.Versioning.VersionComparison versionComparison) { throw null; }
        public virtual int CompareTo(object obj) { throw null; }
        public virtual bool Equals(NuGet.Versioning.SemanticVersion other) { throw null; }
        public virtual bool Equals(NuGet.Versioning.SemanticVersion other, NuGet.Versioning.VersionComparison versionComparison) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(NuGet.Versioning.SemanticVersion version1, NuGet.Versioning.SemanticVersion version2) { throw null; }
        public static bool operator >(NuGet.Versioning.SemanticVersion version1, NuGet.Versioning.SemanticVersion version2) { throw null; }
        public static bool operator >=(NuGet.Versioning.SemanticVersion version1, NuGet.Versioning.SemanticVersion version2) { throw null; }
        public static bool operator !=(NuGet.Versioning.SemanticVersion version1, NuGet.Versioning.SemanticVersion version2) { throw null; }
        public static bool operator <(NuGet.Versioning.SemanticVersion version1, NuGet.Versioning.SemanticVersion version2) { throw null; }
        public static bool operator <=(NuGet.Versioning.SemanticVersion version1, NuGet.Versioning.SemanticVersion version2) { throw null; }
        public static NuGet.Versioning.SemanticVersion Parse(string value) { throw null; }
        public virtual string ToFullString() { throw null; }
        public virtual string ToNormalizedString() { throw null; }
        public override string ToString() { throw null; }
        public virtual string ToString(string format, System.IFormatProvider formatProvider) { throw null; }
        protected bool TryFormatter(string format, System.IFormatProvider formatProvider, out string formattedString) { formattedString = default(string); throw null; }
        public static bool TryParse(string value, out NuGet.Versioning.SemanticVersion version) { version = default(NuGet.Versioning.SemanticVersion); throw null; }
    }
    public sealed partial class VersionComparer : NuGet.Versioning.IVersionComparer, System.Collections.Generic.IComparer<NuGet.Versioning.SemanticVersion>, System.Collections.Generic.IEqualityComparer<NuGet.Versioning.SemanticVersion>
    {
        public static readonly NuGet.Versioning.IVersionComparer Default;
        public static readonly NuGet.Versioning.IVersionComparer Version;
        public static readonly NuGet.Versioning.IVersionComparer VersionRelease;
        public static NuGet.Versioning.IVersionComparer VersionReleaseMetadata;
        public VersionComparer() { }
        public VersionComparer(NuGet.Versioning.VersionComparison versionComparison) { }
        public int Compare(NuGet.Versioning.SemanticVersion x, NuGet.Versioning.SemanticVersion y) { throw null; }
        public static int Compare(NuGet.Versioning.SemanticVersion version1, NuGet.Versioning.SemanticVersion version2, NuGet.Versioning.VersionComparison versionComparison) { throw null; }
        public bool Equals(NuGet.Versioning.SemanticVersion x, NuGet.Versioning.SemanticVersion y) { throw null; }
        public int GetHashCode(NuGet.Versioning.SemanticVersion version) { throw null; }
    }
    public enum VersionComparison
    {
        Default = 0,
        Version = 1,
        VersionRelease = 2,
        VersionReleaseMetadata = 3,
    }
    public static partial class VersionExtensions
    {
        public static NuGet.Versioning.INuGetVersionable FindBestMatch(this System.Collections.Generic.IEnumerable<NuGet.Versioning.INuGetVersionable> items, NuGet.Versioning.VersionRange ideal) { throw null; }
        public static T FindBestMatch<T>(this System.Collections.Generic.IEnumerable<T> items, NuGet.Versioning.VersionRange ideal, System.Func<T, NuGet.Versioning.NuGetVersion> selector) where T : class { throw null; }
    }
    public partial class VersionFormatter : System.ICustomFormatter, System.IFormatProvider
    {
        public static readonly NuGet.Versioning.VersionFormatter Instance;
        public VersionFormatter() { }
        public string Format(string format, object arg, System.IFormatProvider formatProvider) { throw null; }
        public object GetFormat(System.Type formatType) { throw null; }
    }
    public partial class VersionRange : NuGet.Versioning.VersionRangeBase, System.IFormattable
    {
        public static readonly NuGet.Versioning.VersionRange All;
        public static readonly NuGet.Versioning.VersionRange AllFloating;
        public static readonly NuGet.Versioning.VersionRange AllStable;
        public static readonly NuGet.Versioning.VersionRange AllStableFloating;
        public static readonly NuGet.Versioning.VersionRange None;
        public VersionRange(NuGet.Versioning.NuGetVersion minVersion) : base (default(NuGet.Versioning.NuGetVersion), default(bool), default(NuGet.Versioning.NuGetVersion), default(bool)) { }
        public VersionRange(NuGet.Versioning.NuGetVersion minVersion, NuGet.Versioning.FloatRange floatRange) : base (default(NuGet.Versioning.NuGetVersion), default(bool), default(NuGet.Versioning.NuGetVersion), default(bool)) { }
        public VersionRange(NuGet.Versioning.NuGetVersion minVersion=null, bool includeMinVersion=true, NuGet.Versioning.NuGetVersion maxVersion=null, bool includeMaxVersion=false, NuGet.Versioning.FloatRange floatRange=null, string originalString=null) : base (default(NuGet.Versioning.NuGetVersion), default(bool), default(NuGet.Versioning.NuGetVersion), default(bool)) { }
        public VersionRange(NuGet.Versioning.VersionRange range, NuGet.Versioning.FloatRange floatRange) : base (default(NuGet.Versioning.NuGetVersion), default(bool), default(NuGet.Versioning.NuGetVersion), default(bool)) { }
        public NuGet.Versioning.FloatRange Float { get { throw null; } }
        public bool IsFloating { get { throw null; } }
        public string OriginalString { get { throw null; } }
        public static NuGet.Versioning.VersionRange Combine(System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion> versions) { throw null; }
        public static NuGet.Versioning.VersionRange Combine(System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion> versions, NuGet.Versioning.IVersionComparer comparer) { throw null; }
        public static NuGet.Versioning.VersionRange Combine(System.Collections.Generic.IEnumerable<NuGet.Versioning.VersionRange> ranges) { throw null; }
        public static NuGet.Versioning.VersionRange Combine(System.Collections.Generic.IEnumerable<NuGet.Versioning.VersionRange> ranges, NuGet.Versioning.IVersionComparer comparer) { throw null; }
        public static NuGet.Versioning.VersionRange CommonSubSet(System.Collections.Generic.IEnumerable<NuGet.Versioning.VersionRange> ranges) { throw null; }
        public static NuGet.Versioning.VersionRange CommonSubSet(System.Collections.Generic.IEnumerable<NuGet.Versioning.VersionRange> ranges, NuGet.Versioning.IVersionComparer comparer) { throw null; }
        public NuGet.Versioning.NuGetVersion FindBestMatch(System.Collections.Generic.IEnumerable<NuGet.Versioning.NuGetVersion> versions) { throw null; }
        public bool IsBetter(NuGet.Versioning.NuGetVersion current, NuGet.Versioning.NuGetVersion considering) { throw null; }
        public static NuGet.Versioning.VersionRange Parse(string value) { throw null; }
        public static NuGet.Versioning.VersionRange Parse(string value, bool allowFloating) { throw null; }
        public string PrettyPrint() { throw null; }
        public virtual string ToLegacyShortString() { throw null; }
        public virtual string ToLegacyString() { throw null; }
        public NuGet.Versioning.VersionRange ToNonSnapshotRange() { throw null; }
        public virtual string ToNormalizedString() { throw null; }
        public override string ToString() { throw null; }
        public string ToString(string format, System.IFormatProvider formatProvider) { throw null; }
        protected bool TryFormatter(string format, System.IFormatProvider formatProvider, out string formattedString) { formattedString = default(string); throw null; }
        public static bool TryParse(string value, out NuGet.Versioning.VersionRange versionRange) { versionRange = default(NuGet.Versioning.VersionRange); throw null; }
        public static bool TryParse(string value, bool allowFloating, out NuGet.Versioning.VersionRange versionRange) { versionRange = default(NuGet.Versioning.VersionRange); throw null; }
    }
    public abstract partial class VersionRangeBase : System.IEquatable<NuGet.Versioning.VersionRangeBase>
    {
        public VersionRangeBase(NuGet.Versioning.NuGetVersion minVersion=null, bool includeMinVersion=true, NuGet.Versioning.NuGetVersion maxVersion=null, bool includeMaxVersion=false) { }
        public bool HasLowerAndUpperBounds { get { throw null; } }
        public bool HasLowerBound { get { throw null; } }
        protected bool HasPrereleaseBounds { get { throw null; } }
        public bool HasUpperBound { get { throw null; } }
        public bool IsMaxInclusive { get { throw null; } }
        public bool IsMinInclusive { get { throw null; } }
        public NuGet.Versioning.NuGetVersion MaxVersion { get { throw null; } }
        public NuGet.Versioning.NuGetVersion MinVersion { get { throw null; } }
        public bool Equals(NuGet.Versioning.VersionRangeBase other) { throw null; }
        public bool Equals(NuGet.Versioning.VersionRangeBase other, NuGet.Versioning.IVersionComparer versionComparer) { throw null; }
        public bool Equals(NuGet.Versioning.VersionRangeBase other, NuGet.Versioning.IVersionRangeComparer comparer) { throw null; }
        public bool Equals(NuGet.Versioning.VersionRangeBase other, NuGet.Versioning.VersionComparison versionComparison) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public bool IsSubSetOrEqualTo(NuGet.Versioning.VersionRangeBase possibleSuperSet) { throw null; }
        public bool IsSubSetOrEqualTo(NuGet.Versioning.VersionRangeBase possibleSuperSet, NuGet.Versioning.IVersionComparer comparer) { throw null; }
        public bool Satisfies(NuGet.Versioning.NuGetVersion version) { throw null; }
        public bool Satisfies(NuGet.Versioning.NuGetVersion version, NuGet.Versioning.IVersionComparer comparer) { throw null; }
        public bool Satisfies(NuGet.Versioning.NuGetVersion version, NuGet.Versioning.VersionComparison versionComparison) { throw null; }
    }
    public partial class VersionRangeComparer : NuGet.Versioning.IVersionRangeComparer, System.Collections.Generic.IEqualityComparer<NuGet.Versioning.VersionRangeBase>
    {
        public VersionRangeComparer() { }
        public VersionRangeComparer(NuGet.Versioning.IVersionComparer versionComparer) { }
        public VersionRangeComparer(NuGet.Versioning.VersionComparison versionComparison) { }
        public static NuGet.Versioning.IVersionRangeComparer Default { get { throw null; } }
        public static NuGet.Versioning.IVersionRangeComparer VersionRelease { get { throw null; } }
        public bool Equals(NuGet.Versioning.VersionRangeBase x, NuGet.Versioning.VersionRangeBase y) { throw null; }
        public int GetHashCode(NuGet.Versioning.VersionRangeBase obj) { throw null; }
    }
    public partial class VersionRangeFormatter : System.ICustomFormatter, System.IFormatProvider
    {
        public VersionRangeFormatter() { }
        public string Format(string format, object arg, System.IFormatProvider formatProvider) { throw null; }
        public object GetFormat(System.Type formatType) { throw null; }
    }
}
