[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Runtime.InteropServices.WindowsRuntime")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Runtime.InteropServices.WindowsRuntime")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Runtime.InteropServices.WindowsRuntime")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Runtime.InteropServices.WindowsRuntime
{
    [System.AttributeUsageAttribute((System.AttributeTargets)(1028), AllowMultiple=false, Inherited=false)]
    public sealed partial class DefaultInterfaceAttribute : System.Attribute
    {
        public DefaultInterfaceAttribute(System.Type defaultInterface) { }
        public System.Type DefaultInterface { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct EventRegistrationToken
    {
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken left, System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken right) { throw null; }
        public static bool operator !=(System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken left, System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken right) { throw null; }
    }
    public sealed partial class EventRegistrationTokenTable<T> where T : class
    {
        public EventRegistrationTokenTable() { }
        public T InvocationList { get { throw null; } set { } }
        public System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken AddEventHandler(T handler) { throw null; }
        public static System.Runtime.InteropServices.WindowsRuntime.EventRegistrationTokenTable<T> GetOrCreateEventRegistrationTokenTable(ref System.Runtime.InteropServices.WindowsRuntime.EventRegistrationTokenTable<T> refEventTable) { throw null; }
        public void RemoveEventHandler(System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken token) { }
        public void RemoveEventHandler(T handler) { }
    }
    public partial interface IActivationFactory
    {
        object ActivateInstance();
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1028), Inherited=false, AllowMultiple=true)]
    public sealed partial class InterfaceImplementedInVersionAttribute : System.Attribute
    {
        public InterfaceImplementedInVersionAttribute(System.Type interfaceType, byte majorVersion, byte minorVersion, byte buildVersion, byte revisionVersion) { }
        public byte BuildVersion { get { throw null; } }
        public System.Type InterfaceType { get { throw null; } }
        public byte MajorVersion { get { throw null; } }
        public byte MinorVersion { get { throw null; } }
        public byte RevisionVersion { get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2048), Inherited=false, AllowMultiple=false)]
    public sealed partial class ReadOnlyArrayAttribute : System.Attribute
    {
        public ReadOnlyArrayAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(12288), AllowMultiple=false, Inherited=false)]
    public sealed partial class ReturnValueNameAttribute : System.Attribute
    {
        public ReturnValueNameAttribute(string name) { }
        public string Name { get { throw null; } }
    }
    public static partial class WindowsRuntimeMarshal
    {
        [System.Security.SecurityCriticalAttribute]
        public static void AddEventHandler<T>(System.Func<T, System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken> addMethod, System.Action<System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken> removeMethod, T handler) { }
        [System.Security.SecurityCriticalAttribute]
        public static void FreeHString(System.IntPtr ptr) { }
        [System.Security.SecurityCriticalAttribute]
        public static System.Runtime.InteropServices.WindowsRuntime.IActivationFactory GetActivationFactory(System.Type type) { throw null; }
        [System.Security.SecurityCriticalAttribute]
        public static string PtrToStringHString(System.IntPtr ptr) { throw null; }
        [System.Security.SecurityCriticalAttribute]
        public static void RemoveAllEventHandlers(System.Action<System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken> removeMethod) { }
        [System.Security.SecurityCriticalAttribute]
        public static void RemoveEventHandler<T>(System.Action<System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken> removeMethod, T handler) { }
        [System.Security.SecurityCriticalAttribute]
        public static System.IntPtr StringToHString(string s) { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2048), Inherited=false, AllowMultiple=false)]
    public sealed partial class WriteOnlyArrayAttribute : System.Attribute
    {
        public WriteOnlyArrayAttribute() { }
    }
}
