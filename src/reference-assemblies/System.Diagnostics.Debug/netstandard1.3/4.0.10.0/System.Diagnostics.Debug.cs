[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Diagnostics.Debug")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Diagnostics.Debug")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Diagnostics.Debug")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Diagnostics
{
    public static partial class Debug
    {
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Assert(bool condition) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Assert(bool condition, string message) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Assert(bool condition, string message, string detailMessage) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Assert(bool condition, string message, string detailMessageFormat, params object[] args) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Fail(string message) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Fail(string message, string detailMessage) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Write(object value) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Write(object value, string category) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Write(string message) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void Write(string message, string category) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteIf(bool condition, object value) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteIf(bool condition, object value, string category) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteIf(bool condition, string message) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteIf(bool condition, string message, string category) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteLine(object value) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteLine(object value, string category) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteLine(string message) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteLine(string format, params object[] args) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteLine(string message, string category) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteLineIf(bool condition, object value) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteLineIf(bool condition, object value, string category) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteLineIf(bool condition, string message) { }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void WriteLineIf(bool condition, string message, string category) { }
    }
    public static partial class Debugger
    {
        public static bool IsAttached { get { throw null; } }
        public static void Break() { }
        public static bool Launch() { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false)]
    public sealed partial class DebuggerBrowsableAttribute : System.Attribute
    {
        public DebuggerBrowsableAttribute(System.Diagnostics.DebuggerBrowsableState state) { }
        public System.Diagnostics.DebuggerBrowsableState State { get { throw null; } }
    }
    public enum DebuggerBrowsableState
    {
        Collapsed = 2,
        Never = 0,
        RootHidden = 3,
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(4509), AllowMultiple=true)]
    public sealed partial class DebuggerDisplayAttribute : System.Attribute
    {
        public DebuggerDisplayAttribute(string value) { }
        public string Name { get { throw null; } set { } }
        public System.Type Target { get { throw null; } set { } }
        public string TargetTypeName { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string Value { get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(224), Inherited=false)]
    public sealed partial class DebuggerHiddenAttribute : System.Attribute
    {
        public DebuggerHiddenAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(236), Inherited=false)]
    public sealed partial class DebuggerNonUserCodeAttribute : System.Attribute
    {
        public DebuggerNonUserCodeAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(108), Inherited=false)]
    public sealed partial class DebuggerStepThroughAttribute : System.Attribute
    {
        public DebuggerStepThroughAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(13), AllowMultiple=true)]
    public sealed partial class DebuggerTypeProxyAttribute : System.Attribute
    {
        public DebuggerTypeProxyAttribute(string typeName) { }
        public DebuggerTypeProxyAttribute(System.Type type) { }
        public string ProxyTypeName { get { throw null; } }
        public System.Type Target { get { throw null; } set { } }
        public string TargetTypeName { get { throw null; } set { } }
    }
}
