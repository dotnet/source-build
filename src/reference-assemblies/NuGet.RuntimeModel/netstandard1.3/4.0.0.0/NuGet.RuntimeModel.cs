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
namespace NuGet.RuntimeModel
{
    public partial class CompatibilityProfile : System.IEquatable<NuGet.RuntimeModel.CompatibilityProfile>
    {
        public CompatibilityProfile(string name) { }
        public CompatibilityProfile(string name, System.Collections.Generic.IEnumerable<NuGet.Frameworks.FrameworkRuntimePair> restoreContexts) { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IList<NuGet.Frameworks.FrameworkRuntimePair> RestoreContexts { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Equals(NuGet.RuntimeModel.CompatibilityProfile other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial interface IObjectWriter
    {
        void WriteNameArray(string name, System.Collections.Generic.IEnumerable<string> values);
        void WriteNameValue(string name, bool value);
        void WriteNameValue(string name, int value);
        void WriteNameValue(string name, string value);
        void WriteObjectEnd();
        void WriteObjectStart(string name);
    }
    public sealed partial class JsonObjectWriter : NuGet.RuntimeModel.IObjectWriter
    {
        public JsonObjectWriter() { }
        public Newtonsoft.Json.Linq.JObject GetJObject() { throw null; }
        public string GetJson() { throw null; }
        public void WriteNameArray(string name, System.Collections.Generic.IEnumerable<string> values) { }
        public void WriteNameValue(string name, bool value) { }
        public void WriteNameValue(string name, int value) { }
        public void WriteNameValue(string name, string value) { }
        public void WriteObjectEnd() { }
        public void WriteObjectStart(string name) { }
        public void WriteTo(Newtonsoft.Json.JsonTextWriter writer) { }
    }
    public static partial class JsonRuntimeFormat
    {
        public static NuGet.RuntimeModel.RuntimeGraph ReadRuntimeGraph(Newtonsoft.Json.Linq.JToken json) { throw null; }
        public static NuGet.RuntimeModel.RuntimeGraph ReadRuntimeGraph(System.IO.Stream stream) { throw null; }
        public static NuGet.RuntimeModel.RuntimeGraph ReadRuntimeGraph(System.IO.TextReader textReader) { throw null; }
        public static NuGet.RuntimeModel.RuntimeGraph ReadRuntimeGraph(string filePath) { throw null; }
        public static void WriteRuntimeGraph(NuGet.RuntimeModel.IObjectWriter writer, NuGet.RuntimeModel.RuntimeGraph runtimeGraph) { }
        public static void WriteRuntimeGraph(string filePath, NuGet.RuntimeModel.RuntimeGraph runtimeGraph) { }
    }
    public partial class RuntimeDependencySet : System.IEquatable<NuGet.RuntimeModel.RuntimeDependencySet>
    {
        public RuntimeDependencySet(string id) { }
        public RuntimeDependencySet(string id, System.Collections.Generic.IEnumerable<NuGet.RuntimeModel.RuntimePackageDependency> dependencies) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, NuGet.RuntimeModel.RuntimePackageDependency> Dependencies { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.RuntimeModel.RuntimeDependencySet Clone() { throw null; }
        public bool Equals(NuGet.RuntimeModel.RuntimeDependencySet other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RuntimeDescription : System.IEquatable<NuGet.RuntimeModel.RuntimeDescription>
    {
        public RuntimeDescription(string runtimeIdentifier) { }
        public RuntimeDescription(string runtimeIdentifier, System.Collections.Generic.IEnumerable<NuGet.RuntimeModel.RuntimeDependencySet> runtimeDependencySets) { }
        public RuntimeDescription(string runtimeIdentifier, System.Collections.Generic.IEnumerable<string> inheritedRuntimes) { }
        public RuntimeDescription(string runtimeIdentifier, System.Collections.Generic.IEnumerable<string> inheritedRuntimes, System.Collections.Generic.IEnumerable<NuGet.RuntimeModel.RuntimeDependencySet> runtimeDependencySets) { }
        public System.Collections.Generic.IReadOnlyList<string> InheritedRuntimes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, NuGet.RuntimeModel.RuntimeDependencySet> RuntimeDependencySets { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string RuntimeIdentifier { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.RuntimeModel.RuntimeDescription Clone() { throw null; }
        public bool Equals(NuGet.RuntimeModel.RuntimeDescription other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static NuGet.RuntimeModel.RuntimeDescription Merge(NuGet.RuntimeModel.RuntimeDescription left, NuGet.RuntimeModel.RuntimeDescription right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RuntimeGraph : System.IEquatable<NuGet.RuntimeModel.RuntimeGraph>
    {
        public static readonly NuGet.RuntimeModel.RuntimeGraph Empty;
        public static readonly string RuntimeGraphFileName;
        public RuntimeGraph() { }
        public RuntimeGraph(System.Collections.Generic.IEnumerable<NuGet.RuntimeModel.CompatibilityProfile> supports) { }
        public RuntimeGraph(System.Collections.Generic.IEnumerable<NuGet.RuntimeModel.RuntimeDescription> runtimes) { }
        public RuntimeGraph(System.Collections.Generic.IEnumerable<NuGet.RuntimeModel.RuntimeDescription> runtimes, System.Collections.Generic.IEnumerable<NuGet.RuntimeModel.CompatibilityProfile> supports) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, NuGet.RuntimeModel.RuntimeDescription> Runtimes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, NuGet.RuntimeModel.CompatibilityProfile> Supports { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool AreCompatible(string criteria, string provided) { throw null; }
        public NuGet.RuntimeModel.RuntimeGraph Clone() { throw null; }
        public bool Equals(NuGet.RuntimeModel.RuntimeGraph other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public System.Collections.Generic.IEnumerable<string> ExpandRuntime(string runtime) { throw null; }
        public System.Collections.Generic.IEnumerable<NuGet.RuntimeModel.RuntimePackageDependency> FindRuntimeDependencies(string runtimeName, string packageId) { throw null; }
        public override int GetHashCode() { throw null; }
        public static NuGet.RuntimeModel.RuntimeGraph Merge(NuGet.RuntimeModel.RuntimeGraph left, NuGet.RuntimeModel.RuntimeGraph right) { throw null; }
    }
    public partial class RuntimePackageDependency : System.IEquatable<NuGet.RuntimeModel.RuntimePackageDependency>
    {
        public RuntimePackageDependency(string id, NuGet.Versioning.VersionRange versionRange) { }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.Versioning.VersionRange VersionRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public NuGet.RuntimeModel.RuntimePackageDependency Clone() { throw null; }
        public bool Equals(NuGet.RuntimeModel.RuntimePackageDependency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
}
