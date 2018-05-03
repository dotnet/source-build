[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Xml.XmlSerializer")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Xml.XmlSerializer")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Xml.XmlSerializer")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Xml.Serialization
{
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624), AllowMultiple=false)]
    public partial class XmlAnyAttributeAttribute : System.Attribute
    {
        public XmlAnyAttributeAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624), AllowMultiple=true)]
    public partial class XmlAnyElementAttribute : System.Attribute
    {
        public XmlAnyElementAttribute() { }
        public XmlAnyElementAttribute(string name) { }
        public XmlAnyElementAttribute(string name, string ns) { }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public int Order { get { throw null; } set { } }
    }
    public partial class XmlAnyElementAttributes : System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
    {
        public XmlAnyElementAttributes() { }
        public int Count { get { throw null; } }
        public System.Xml.Serialization.XmlAnyElementAttribute this[int index] { get { throw null; } set { } }
        bool System.Collections.ICollection.IsSynchronized { get { throw null; } }
        object System.Collections.ICollection.SyncRoot { get { throw null; } }
        bool System.Collections.IList.IsFixedSize { get { throw null; } }
        bool System.Collections.IList.IsReadOnly { get { throw null; } }
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
        public int Add(System.Xml.Serialization.XmlAnyElementAttribute attribute) { throw null; }
        public void Clear() { }
        public bool Contains(System.Xml.Serialization.XmlAnyElementAttribute attribute) { throw null; }
        public void CopyTo(System.Xml.Serialization.XmlAnyElementAttribute[] array, int index) { }
        public System.Collections.IEnumerator GetEnumerator() { throw null; }
        public int IndexOf(System.Xml.Serialization.XmlAnyElementAttribute attribute) { throw null; }
        public void Insert(int index, System.Xml.Serialization.XmlAnyElementAttribute attribute) { }
        public void Remove(System.Xml.Serialization.XmlAnyElementAttribute attribute) { }
        public void RemoveAt(int index) { }
        void System.Collections.ICollection.CopyTo(System.Array array, int index) { }
        int System.Collections.IList.Add(object value) { throw null; }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        void System.Collections.IList.Remove(object value) { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624), AllowMultiple=false)]
    public partial class XmlArrayAttribute : System.Attribute
    {
        public XmlArrayAttribute() { }
        public XmlArrayAttribute(string elementName) { }
        public string ElementName { get { throw null; } set { } }
        public System.Xml.Schema.XmlSchemaForm Form { get { throw null; } set { } }
        public bool IsNullable { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public int Order { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624), AllowMultiple=true)]
    public partial class XmlArrayItemAttribute : System.Attribute
    {
        public XmlArrayItemAttribute() { }
        public XmlArrayItemAttribute(string elementName) { }
        public XmlArrayItemAttribute(string elementName, System.Type type) { }
        public XmlArrayItemAttribute(System.Type type) { }
        public string DataType { get { throw null; } set { } }
        public string ElementName { get { throw null; } set { } }
        public System.Xml.Schema.XmlSchemaForm Form { get { throw null; } set { } }
        public bool IsNullable { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public int NestingLevel { get { throw null; } set { } }
        public System.Type Type { get { throw null; } set { } }
    }
    public partial class XmlArrayItemAttributes : System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
    {
        public XmlArrayItemAttributes() { }
        public int Count { get { throw null; } }
        public System.Xml.Serialization.XmlArrayItemAttribute this[int index] { get { throw null; } set { } }
        bool System.Collections.ICollection.IsSynchronized { get { throw null; } }
        object System.Collections.ICollection.SyncRoot { get { throw null; } }
        bool System.Collections.IList.IsFixedSize { get { throw null; } }
        bool System.Collections.IList.IsReadOnly { get { throw null; } }
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
        public int Add(System.Xml.Serialization.XmlArrayItemAttribute attribute) { throw null; }
        public void Clear() { }
        public bool Contains(System.Xml.Serialization.XmlArrayItemAttribute attribute) { throw null; }
        public void CopyTo(System.Xml.Serialization.XmlArrayItemAttribute[] array, int index) { }
        public System.Collections.IEnumerator GetEnumerator() { throw null; }
        public int IndexOf(System.Xml.Serialization.XmlArrayItemAttribute attribute) { throw null; }
        public void Insert(int index, System.Xml.Serialization.XmlArrayItemAttribute attribute) { }
        public void Remove(System.Xml.Serialization.XmlArrayItemAttribute attribute) { }
        public void RemoveAt(int index) { }
        void System.Collections.ICollection.CopyTo(System.Array array, int index) { }
        int System.Collections.IList.Add(object value) { throw null; }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        void System.Collections.IList.Remove(object value) { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624))]
    public partial class XmlAttributeAttribute : System.Attribute
    {
        public XmlAttributeAttribute() { }
        public XmlAttributeAttribute(string attributeName) { }
        public XmlAttributeAttribute(string attributeName, System.Type type) { }
        public XmlAttributeAttribute(System.Type type) { }
        public string AttributeName { get { throw null; } set { } }
        public string DataType { get { throw null; } set { } }
        public System.Xml.Schema.XmlSchemaForm Form { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public System.Type Type { get { throw null; } set { } }
    }
    public partial class XmlAttributeOverrides
    {
        public XmlAttributeOverrides() { }
        public System.Xml.Serialization.XmlAttributes this[System.Type type] { get { throw null; } }
        public System.Xml.Serialization.XmlAttributes this[System.Type type, string member] { get { throw null; } }
        public void Add(System.Type type, string member, System.Xml.Serialization.XmlAttributes attributes) { }
        public void Add(System.Type type, System.Xml.Serialization.XmlAttributes attributes) { }
    }
    public partial class XmlAttributes
    {
        public XmlAttributes() { }
        public System.Xml.Serialization.XmlAnyAttributeAttribute XmlAnyAttribute { get { throw null; } set { } }
        public System.Xml.Serialization.XmlAnyElementAttributes XmlAnyElements { get { throw null; } }
        public System.Xml.Serialization.XmlArrayAttribute XmlArray { get { throw null; } set { } }
        public System.Xml.Serialization.XmlArrayItemAttributes XmlArrayItems { get { throw null; } }
        public System.Xml.Serialization.XmlAttributeAttribute XmlAttribute { get { throw null; } set { } }
        public System.Xml.Serialization.XmlChoiceIdentifierAttribute XmlChoiceIdentifier { get { throw null; } }
        public object XmlDefaultValue { get { throw null; } set { } }
        public System.Xml.Serialization.XmlElementAttributes XmlElements { get { throw null; } }
        public System.Xml.Serialization.XmlEnumAttribute XmlEnum { get { throw null; } set { } }
        public bool XmlIgnore { get { throw null; } set { } }
        public bool Xmlns { get { throw null; } set { } }
        public System.Xml.Serialization.XmlRootAttribute XmlRoot { get { throw null; } set { } }
        public System.Xml.Serialization.XmlTextAttribute XmlText { get { throw null; } set { } }
        public System.Xml.Serialization.XmlTypeAttribute XmlType { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624), AllowMultiple=false)]
    public partial class XmlChoiceIdentifierAttribute : System.Attribute
    {
        public XmlChoiceIdentifierAttribute() { }
        public XmlChoiceIdentifierAttribute(string name) { }
        public string MemberName { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624), AllowMultiple=true)]
    public partial class XmlElementAttribute : System.Attribute
    {
        public XmlElementAttribute() { }
        public XmlElementAttribute(string elementName) { }
        public XmlElementAttribute(string elementName, System.Type type) { }
        public XmlElementAttribute(System.Type type) { }
        public string DataType { get { throw null; } set { } }
        public string ElementName { get { throw null; } set { } }
        public System.Xml.Schema.XmlSchemaForm Form { get { throw null; } set { } }
        public bool IsNullable { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public int Order { get { throw null; } set { } }
        public System.Type Type { get { throw null; } set { } }
    }
    public partial class XmlElementAttributes : System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
    {
        public XmlElementAttributes() { }
        public int Count { get { throw null; } }
        public System.Xml.Serialization.XmlElementAttribute this[int index] { get { throw null; } set { } }
        bool System.Collections.ICollection.IsSynchronized { get { throw null; } }
        object System.Collections.ICollection.SyncRoot { get { throw null; } }
        bool System.Collections.IList.IsFixedSize { get { throw null; } }
        bool System.Collections.IList.IsReadOnly { get { throw null; } }
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
        public int Add(System.Xml.Serialization.XmlElementAttribute attribute) { throw null; }
        public void Clear() { }
        public bool Contains(System.Xml.Serialization.XmlElementAttribute attribute) { throw null; }
        public void CopyTo(System.Xml.Serialization.XmlElementAttribute[] array, int index) { }
        public System.Collections.IEnumerator GetEnumerator() { throw null; }
        public int IndexOf(System.Xml.Serialization.XmlElementAttribute attribute) { throw null; }
        public void Insert(int index, System.Xml.Serialization.XmlElementAttribute attribute) { }
        public void Remove(System.Xml.Serialization.XmlElementAttribute attribute) { }
        public void RemoveAt(int index) { }
        void System.Collections.ICollection.CopyTo(System.Array array, int index) { }
        int System.Collections.IList.Add(object value) { throw null; }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        void System.Collections.IList.Remove(object value) { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(256))]
    public partial class XmlEnumAttribute : System.Attribute
    {
        public XmlEnumAttribute() { }
        public XmlEnumAttribute(string name) { }
        public string Name { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624))]
    public partial class XmlIgnoreAttribute : System.Attribute
    {
        public XmlIgnoreAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1100), AllowMultiple=true)]
    public partial class XmlIncludeAttribute : System.Attribute
    {
        public XmlIncludeAttribute(System.Type type) { }
        public System.Type Type { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624), AllowMultiple=false)]
    public partial class XmlNamespaceDeclarationsAttribute : System.Attribute
    {
        public XmlNamespaceDeclarationsAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(9244))]
    public partial class XmlRootAttribute : System.Attribute
    {
        public XmlRootAttribute() { }
        public XmlRootAttribute(string elementName) { }
        public string DataType { get { throw null; } set { } }
        public string ElementName { get { throw null; } set { } }
        public bool IsNullable { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
    }
    public partial class XmlSerializer
    {
        protected XmlSerializer() { }
        public XmlSerializer(System.Type type) { }
        public XmlSerializer(System.Type type, string defaultNamespace) { }
        public XmlSerializer(System.Type type, System.Type[] extraTypes) { }
        public XmlSerializer(System.Type type, System.Xml.Serialization.XmlAttributeOverrides overrides) { }
        public XmlSerializer(System.Type type, System.Xml.Serialization.XmlAttributeOverrides overrides, System.Type[] extraTypes, System.Xml.Serialization.XmlRootAttribute root, string defaultNamespace) { }
        public XmlSerializer(System.Type type, System.Xml.Serialization.XmlRootAttribute root) { }
        public virtual bool CanDeserialize(System.Xml.XmlReader xmlReader) { throw null; }
        public object Deserialize(System.IO.Stream stream) { throw null; }
        public object Deserialize(System.IO.TextReader textReader) { throw null; }
        public object Deserialize(System.Xml.XmlReader xmlReader) { throw null; }
        public static System.Xml.Serialization.XmlSerializer[] FromTypes(System.Type[] types) { throw null; }
        public void Serialize(System.IO.Stream stream, object o) { }
        public void Serialize(System.IO.Stream stream, object o, System.Xml.Serialization.XmlSerializerNamespaces namespaces) { }
        public void Serialize(System.IO.TextWriter textWriter, object o) { }
        public void Serialize(System.IO.TextWriter textWriter, object o, System.Xml.Serialization.XmlSerializerNamespaces namespaces) { }
        public void Serialize(System.Xml.XmlWriter xmlWriter, object o) { }
        public void Serialize(System.Xml.XmlWriter xmlWriter, object o, System.Xml.Serialization.XmlSerializerNamespaces namespaces) { }
    }
    public partial class XmlSerializerNamespaces
    {
        public XmlSerializerNamespaces() { }
        public XmlSerializerNamespaces(System.Xml.Serialization.XmlSerializerNamespaces namespaces) { }
        public XmlSerializerNamespaces(System.Xml.XmlQualifiedName[] namespaces) { }
        public int Count { get { throw null; } }
        public void Add(string prefix, string ns) { }
        public System.Xml.XmlQualifiedName[] ToArray() { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10624))]
    public partial class XmlTextAttribute : System.Attribute
    {
        public XmlTextAttribute() { }
        public XmlTextAttribute(System.Type type) { }
        public string DataType { get { throw null; } set { } }
        public System.Type Type { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1052))]
    public partial class XmlTypeAttribute : System.Attribute
    {
        public XmlTypeAttribute() { }
        public XmlTypeAttribute(string typeName) { }
        public bool AnonymousType { get { throw null; } set { } }
        public bool IncludeInSchema { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
    }
}
