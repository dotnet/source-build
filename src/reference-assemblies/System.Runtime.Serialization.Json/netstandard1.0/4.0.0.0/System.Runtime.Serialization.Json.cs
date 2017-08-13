[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Runtime.Serialization.Json")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Runtime.Serialization.Json")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Runtime.Serialization.Json")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Runtime.Serialization
{
    public partial class DateTimeFormat
    {
        public DateTimeFormat(string formatString) { }
        public DateTimeFormat(string formatString, System.IFormatProvider formatProvider) { }
        public System.Globalization.DateTimeStyles DateTimeStyles { get { throw null; } set { } }
        public System.IFormatProvider FormatProvider { get { throw null; } }
        public string FormatString { get { throw null; } }
    }
    public enum EmitTypeInformation
    {
        Always = 1,
        AsNeeded = 0,
        Never = 2,
    }
}
namespace System.Runtime.Serialization.Json
{
    public sealed partial class DataContractJsonSerializer
    {
        public DataContractJsonSerializer(System.Type type) { }
        public DataContractJsonSerializer(System.Type type, System.Collections.Generic.IEnumerable<System.Type> knownTypes) { }
        public DataContractJsonSerializer(System.Type type, System.Runtime.Serialization.Json.DataContractJsonSerializerSettings settings) { }
        public System.Runtime.Serialization.DateTimeFormat DateTimeFormat { get { throw null; } }
        public System.Runtime.Serialization.EmitTypeInformation EmitTypeInformation { get { throw null; } }
        public System.Collections.ObjectModel.ReadOnlyCollection<System.Type> KnownTypes { get { throw null; } }
        public bool SerializeReadOnlyTypes { get { throw null; } }
        public bool UseSimpleDictionaryFormat { get { throw null; } }
        public object ReadObject(System.IO.Stream stream) { throw null; }
        public void WriteObject(System.IO.Stream stream, object graph) { }
    }
    public partial class DataContractJsonSerializerSettings
    {
        public DataContractJsonSerializerSettings() { }
        public System.Runtime.Serialization.DateTimeFormat DateTimeFormat { get { throw null; } set { } }
        public System.Runtime.Serialization.EmitTypeInformation EmitTypeInformation { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<System.Type> KnownTypes { get { throw null; } set { } }
        public int MaxItemsInObjectGraph { get { throw null; } set { } }
        public string RootName { get { throw null; } set { } }
        public bool SerializeReadOnlyTypes { get { throw null; } set { } }
        public bool UseSimpleDictionaryFormat { get { throw null; } set { } }
    }
}
