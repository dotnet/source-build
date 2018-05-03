[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Runtime.Serialization.Formatters")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Runtime.Serialization.Formatters")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.6.24705.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.6.24705.01. Commit Hash: 4d1af962ca0fede10beb01d197367c2f90e92c97")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Runtime.Serialization.Formatters")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System
{
    [System.AttributeUsageAttribute((System.AttributeTargets)(256), Inherited=false)]
    public sealed partial class NonSerializedAttribute : System.Attribute
    {
        public NonSerializedAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(4124), Inherited=false)]
    public sealed partial class SerializableAttribute : System.Attribute
    {
        public SerializableAttribute() { }
    }
}
namespace System.Runtime.Serialization
{
    public partial interface IDeserializationCallback
    {
        void OnDeserialization(object sender);
    }
    [System.CLSCompliantAttribute(false)]
    public partial interface IFormatterConverter
    {
        object Convert(object value, System.Type type);
        object Convert(object value, System.TypeCode typeCode);
        bool ToBoolean(object value);
        byte ToByte(object value);
        char ToChar(object value);
        System.DateTime ToDateTime(object value);
        decimal ToDecimal(object value);
        double ToDouble(object value);
        short ToInt16(object value);
        int ToInt32(object value);
        long ToInt64(object value);
        [System.CLSCompliantAttribute(false)]
        sbyte ToSByte(object value);
        float ToSingle(object value);
        string ToString(object value);
        [System.CLSCompliantAttribute(false)]
        ushort ToUInt16(object value);
        [System.CLSCompliantAttribute(false)]
        uint ToUInt32(object value);
        [System.CLSCompliantAttribute(false)]
        ulong ToUInt64(object value);
    }
    public partial interface ISerializable
    {
        void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct SerializationEntry
    {
        public string Name { get { throw null; } }
        public System.Type ObjectType { get { throw null; } }
        public object Value { get { throw null; } }
    }
    public sealed partial class SerializationInfo
    {
        [System.CLSCompliantAttribute(false)]
        public SerializationInfo(System.Type type, System.Runtime.Serialization.IFormatterConverter converter) { }
        public string AssemblyName { get { throw null; } set { } }
        public string FullTypeName { get { throw null; } set { } }
        public int MemberCount { get { throw null; } }
        public System.Type ObjectType { get { throw null; } }
        public void AddValue(string name, bool value) { }
        public void AddValue(string name, byte value) { }
        public void AddValue(string name, char value) { }
        public void AddValue(string name, System.DateTime value) { }
        public void AddValue(string name, decimal value) { }
        public void AddValue(string name, double value) { }
        public void AddValue(string name, short value) { }
        public void AddValue(string name, int value) { }
        public void AddValue(string name, long value) { }
        public void AddValue(string name, object value) { }
        public void AddValue(string name, object value, System.Type type) { }
        [System.CLSCompliantAttribute(false)]
        public void AddValue(string name, sbyte value) { }
        public void AddValue(string name, float value) { }
        [System.CLSCompliantAttribute(false)]
        public void AddValue(string name, ushort value) { }
        [System.CLSCompliantAttribute(false)]
        public void AddValue(string name, uint value) { }
        [System.CLSCompliantAttribute(false)]
        public void AddValue(string name, ulong value) { }
        public bool GetBoolean(string name) { throw null; }
        public byte GetByte(string name) { throw null; }
        public char GetChar(string name) { throw null; }
        public System.DateTime GetDateTime(string name) { throw null; }
        public decimal GetDecimal(string name) { throw null; }
        public double GetDouble(string name) { throw null; }
        public System.Runtime.Serialization.SerializationInfoEnumerator GetEnumerator() { throw null; }
        public short GetInt16(string name) { throw null; }
        public int GetInt32(string name) { throw null; }
        public long GetInt64(string name) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public sbyte GetSByte(string name) { throw null; }
        public float GetSingle(string name) { throw null; }
        public string GetString(string name) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public ushort GetUInt16(string name) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public uint GetUInt32(string name) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public ulong GetUInt64(string name) { throw null; }
        public object GetValue(string name, System.Type type) { throw null; }
        public void SetType(System.Type type) { }
    }
    public sealed partial class SerializationInfoEnumerator : System.Collections.IEnumerator
    {
        internal SerializationInfoEnumerator() { }
        public System.Runtime.Serialization.SerializationEntry Current { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Type ObjectType { get { throw null; } }
        object System.Collections.IEnumerator.Current { get { throw null; } }
        public object Value { get { throw null; } }
        public bool MoveNext() { throw null; }
        public void Reset() { }
    }
}
