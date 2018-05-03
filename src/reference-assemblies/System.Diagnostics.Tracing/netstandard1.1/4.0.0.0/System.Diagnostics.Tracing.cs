[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Diagnostics.Tracing.dll")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Diagnostics.Tracing.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Diagnostics.Tracing.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Diagnostics.Tracing
{
    [System.AttributeUsageAttribute((System.AttributeTargets)(64))]
    public sealed partial class EventAttribute : System.Attribute
    {
        public EventAttribute(int eventId) { }
        public int EventId { get { throw null; } }
        public System.Diagnostics.Tracing.EventKeywords Keywords { get { throw null; } set { } }
        public System.Diagnostics.Tracing.EventLevel Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.Diagnostics.Tracing.EventOpcode Opcode { get { throw null; } set { } }
        public System.Diagnostics.Tracing.EventTask Task { get { throw null; } set { } }
        public byte Version { get { throw null; } set { } }
    }
    public enum EventCommand
    {
        Disable = -3,
        Enable = -2,
        SendManifest = -1,
        Update = 0,
    }
    public partial class EventCommandEventArgs : System.EventArgs
    {
        internal EventCommandEventArgs() { }
        public System.Collections.Generic.IDictionary<string, string> Arguments { get { throw null; } }
        public System.Diagnostics.Tracing.EventCommand Command { get { throw null; } }
        public bool DisableEvent(int eventId) { throw null; }
        public bool EnableEvent(int eventId) { throw null; }
    }
    [System.FlagsAttribute]
    public enum EventKeywords : long
    {
        AuditFailure = (long)4503599627370496,
        AuditSuccess = (long)9007199254740992,
        CorrelationHint = (long)4503599627370496,
        EventLogClassic = (long)36028797018963968,
        None = (long)0,
        Sqm = (long)2251799813685248,
        WdiContext = (long)562949953421312,
        WdiDiagnostic = (long)1125899906842624,
    }
    public enum EventLevel
    {
        Critical = 1,
        Error = 2,
        Informational = 4,
        LogAlways = 0,
        Verbose = 5,
        Warning = 3,
    }
    public abstract partial class EventListener : System.IDisposable
    {
        protected EventListener() { }
        public void DisableEvents(System.Diagnostics.Tracing.EventSource eventSource) { }
        public virtual void Dispose() { }
        public void EnableEvents(System.Diagnostics.Tracing.EventSource eventSource, System.Diagnostics.Tracing.EventLevel level) { }
        public void EnableEvents(System.Diagnostics.Tracing.EventSource eventSource, System.Diagnostics.Tracing.EventLevel level, System.Diagnostics.Tracing.EventKeywords matchAnyKeyword) { }
        public void EnableEvents(System.Diagnostics.Tracing.EventSource eventSource, System.Diagnostics.Tracing.EventLevel level, System.Diagnostics.Tracing.EventKeywords matchAnyKeyword, System.Collections.Generic.IDictionary<string, string> arguments) { }
        protected static int EventSourceIndex(System.Diagnostics.Tracing.EventSource eventSource) { throw null; }
        protected internal virtual void OnEventSourceCreated(System.Diagnostics.Tracing.EventSource eventSource) { }
        protected internal abstract void OnEventWritten(System.Diagnostics.Tracing.EventWrittenEventArgs eventData);
    }
    public enum EventOpcode
    {
        DataCollectionStart = 3,
        DataCollectionStop = 4,
        Extension = 5,
        Info = 0,
        Receive = 240,
        Reply = 6,
        Resume = 7,
        Send = 9,
        Start = 1,
        Stop = 2,
        Suspend = 8,
    }
    public partial class EventSource : System.IDisposable
    {
        protected EventSource() { }
        protected EventSource(bool throwOnEventWriteErrors) { }
        public System.Guid Guid { get { throw null; } }
        public string Name { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        ~EventSource() { }
        public static string GenerateManifest(System.Type eventSourceType, string assemblyPathToIncludeInManifest) { throw null; }
        public static System.Guid GetGuid(System.Type eventSourceType) { throw null; }
        public static string GetName(System.Type eventSourceType) { throw null; }
        public static System.Collections.Generic.IEnumerable<System.Diagnostics.Tracing.EventSource> GetSources() { throw null; }
        public bool IsEnabled() { throw null; }
        public bool IsEnabled(System.Diagnostics.Tracing.EventLevel level, System.Diagnostics.Tracing.EventKeywords keywords) { throw null; }
        protected virtual void OnEventCommand(System.Diagnostics.Tracing.EventCommandEventArgs command) { }
        public static void SendCommand(System.Diagnostics.Tracing.EventSource eventSource, System.Diagnostics.Tracing.EventCommand command, System.Collections.Generic.IDictionary<string, string> commandArguments) { }
        public override string ToString() { throw null; }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, int arg1) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, int arg1, int arg2) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, int arg1, int arg2, int arg3) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, long arg1) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, long arg1, long arg2) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, long arg1, long arg2, long arg3) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, params object[] args) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, string arg1) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, string arg1, int arg2) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, string arg1, int arg2, int arg3) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, string arg1, long arg2) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, string arg1, string arg2) { }
        [System.Security.SecuritySafeCriticalAttribute]
        protected void WriteEvent(int eventId, string arg1, string arg2, string arg3) { }
        [System.CLSCompliantAttribute(false)]
        [System.Security.SecurityCriticalAttribute]
        protected unsafe void WriteEventCore(int eventId, int eventDataCount, System.Diagnostics.Tracing.EventSource.EventData* data) { }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        protected internal partial struct EventData
        {
            public System.IntPtr DataPointer { get { throw null; } set { } }
            public int Size { get { throw null; } set { } }
        }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(4))]
    public sealed partial class EventSourceAttribute : System.Attribute
    {
        public EventSourceAttribute() { }
        public string Guid { get { throw null; } set { } }
        public string LocalizationResources { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class EventSourceException : System.Exception
    {
        public EventSourceException() { }
        public EventSourceException(string message) { }
        public EventSourceException(string message, System.Exception innerException) { }
    }
    public enum EventTask
    {
        None = 0,
    }
    public partial class EventWrittenEventArgs : System.EventArgs
    {
        internal EventWrittenEventArgs() { }
        public int EventId { get { throw null; } }
        public System.Diagnostics.Tracing.EventSource EventSource { get { throw null; } }
        public System.Diagnostics.Tracing.EventKeywords Keywords { get { throw null; } }
        public System.Diagnostics.Tracing.EventLevel Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Diagnostics.Tracing.EventOpcode Opcode { get { throw null; } }
        public System.Collections.ObjectModel.ReadOnlyCollection<object> Payload { get { throw null; } }
        public System.Diagnostics.Tracing.EventTask Task { get { throw null; } }
        public byte Version { get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(64))]
    public sealed partial class NonEventAttribute : System.Attribute
    {
        public NonEventAttribute() { }
    }
}
