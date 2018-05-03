[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Runtime.Serialization.Primitives.dll")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Runtime.Serialization.Primitives.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Runtime.Serialization.Primitives.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Runtime.Serialization
{
    [System.AttributeUsageAttribute((System.AttributeTargets)(12), Inherited=false, AllowMultiple=false)]
    public sealed partial class CollectionDataContractAttribute : System.Attribute
    {
        public CollectionDataContractAttribute() { }
        public bool IsReference { get { throw null; } set { } }
        public string ItemName { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string ValueName { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(3), Inherited=false, AllowMultiple=true)]
    public sealed partial class ContractNamespaceAttribute : System.Attribute
    {
        public ContractNamespaceAttribute(string contractNamespace) { }
        public string ClrNamespace { get { throw null; } set { } }
        public string ContractNamespace { get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(28), Inherited=false, AllowMultiple=false)]
    public sealed partial class DataContractAttribute : System.Attribute
    {
        public DataContractAttribute() { }
        public bool IsReference { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), Inherited=false, AllowMultiple=false)]
    public sealed partial class DataMemberAttribute : System.Attribute
    {
        public DataMemberAttribute() { }
        public bool EmitDefaultValue { get { throw null; } set { } }
        public bool IsRequired { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Order { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(256), Inherited=false, AllowMultiple=false)]
    public sealed partial class EnumMemberAttribute : System.Attribute
    {
        public EnumMemberAttribute() { }
        public string Value { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), Inherited=false, AllowMultiple=false)]
    public sealed partial class IgnoreDataMemberAttribute : System.Attribute
    {
        public IgnoreDataMemberAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(12), Inherited=true, AllowMultiple=true)]
    public sealed partial class KnownTypeAttribute : System.Attribute
    {
        public KnownTypeAttribute(string methodName) { }
        public KnownTypeAttribute(System.Type type) { }
        public string MethodName { get { throw null; } }
        public System.Type Type { get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(64), Inherited=false)]
    public sealed partial class OnDeserializedAttribute : System.Attribute
    {
        public OnDeserializedAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(64), Inherited=false)]
    public sealed partial class OnDeserializingAttribute : System.Attribute
    {
        public OnDeserializingAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(64), Inherited=false)]
    public sealed partial class OnSerializedAttribute : System.Attribute
    {
        public OnSerializedAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(64), Inherited=false)]
    public sealed partial class OnSerializingAttribute : System.Attribute
    {
        public OnSerializingAttribute() { }
    }
    public partial class SerializationException : System.Exception
    {
        public SerializationException() { }
        public SerializationException(string message) { }
        public SerializationException(string message, System.Exception innerException) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct StreamingContext
    {
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
}
