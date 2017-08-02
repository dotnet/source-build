[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Xml.XPath")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Xml.XPath")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.6.23123.00")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.6.23123.00 built by: PROJECTKREL")]
[assembly:System.Reflection.AssemblyMetadataAttribute("", "")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Xml.XPath")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.Xml
{
    public enum XmlNodeOrder
    {
        After = 1,
        Before = 0,
        Same = 2,
        Unknown = 3,
    }
}
namespace System.Xml.XPath
{
    public partial interface IXPathNavigable
    {
        System.Xml.XPath.XPathNavigator CreateNavigator();
    }
    public enum XmlCaseOrder
    {
        LowerFirst = 2,
        None = 0,
        UpperFirst = 1,
    }
    public enum XmlDataType
    {
        Number = 2,
        Text = 1,
    }
    public enum XmlSortOrder
    {
        Ascending = 1,
        Descending = 2,
    }
    public partial class XPathDocument : System.Xml.XPath.IXPathNavigable
    {
        public XPathDocument(System.IO.Stream stream) { }
        public XPathDocument(System.IO.TextReader textReader) { }
        public XPathDocument(string uri) { }
        public XPathDocument(string uri, System.Xml.XmlSpace space) { }
        public XPathDocument(System.Xml.XmlReader reader) { }
        public XPathDocument(System.Xml.XmlReader reader, System.Xml.XmlSpace space) { }
        public System.Xml.XPath.XPathNavigator CreateNavigator() { throw null; }
    }
    public partial class XPathException : System.Exception
    {
        public XPathException() { }
        public XPathException(string message) { }
        public XPathException(string message, System.Exception innerException) { }
    }
    public abstract partial class XPathExpression
    {
        internal XPathExpression() { }
        public abstract string Expression { get; }
        public abstract System.Xml.XPath.XPathResultType ReturnType { get; }
        public abstract void AddSort(object expr, System.Collections.IComparer comparer);
        public abstract void AddSort(object expr, System.Xml.XPath.XmlSortOrder order, System.Xml.XPath.XmlCaseOrder caseOrder, string lang, System.Xml.XPath.XmlDataType dataType);
        public abstract System.Xml.XPath.XPathExpression Clone();
        public static System.Xml.XPath.XPathExpression Compile(string xpath) { throw null; }
        public static System.Xml.XPath.XPathExpression Compile(string xpath, System.Xml.IXmlNamespaceResolver nsResolver) { throw null; }
        public abstract void SetContext(System.Xml.IXmlNamespaceResolver nsResolver);
        public abstract void SetContext(System.Xml.XmlNamespaceManager nsManager);
    }
    public abstract partial class XPathItem
    {
        internal XPathItem() { }
        public abstract bool IsNode { get; }
        public abstract object TypedValue { get; }
        public abstract string Value { get; }
        public abstract bool ValueAsBoolean { get; }
        public abstract System.DateTime ValueAsDateTime { get; }
        public abstract double ValueAsDouble { get; }
        public abstract int ValueAsInt { get; }
        public abstract long ValueAsLong { get; }
        public abstract System.Type ValueType { get; }
        public virtual object ValueAs(System.Type returnType) { throw null; }
        public abstract object ValueAs(System.Type returnType, System.Xml.IXmlNamespaceResolver nsResolver);
    }
    public enum XPathNamespaceScope
    {
        All = 0,
        ExcludeXml = 1,
        Local = 2,
    }
    public abstract partial class XPathNavigator : System.Xml.XPath.XPathItem, System.Xml.IXmlNamespaceResolver, System.Xml.XPath.IXPathNavigable
    {
        protected XPathNavigator() { }
        public abstract string BaseURI { get; }
        public virtual bool CanEdit { get { throw null; } }
        public virtual bool HasAttributes { get { throw null; } }
        public virtual bool HasChildren { get { throw null; } }
        public virtual string InnerXml { get { throw null; } set { } }
        public abstract bool IsEmptyElement { get; }
        public sealed override bool IsNode { get { throw null; } }
        public abstract string LocalName { get; }
        public abstract string Name { get; }
        public abstract string NamespaceURI { get; }
        public abstract System.Xml.XmlNameTable NameTable { get; }
        public static System.Collections.IEqualityComparer NavigatorComparer { get { throw null; } }
        public abstract System.Xml.XPath.XPathNodeType NodeType { get; }
        public virtual string OuterXml { get { throw null; } set { } }
        public abstract string Prefix { get; }
        public override object TypedValue { get { throw null; } }
        public virtual object UnderlyingObject { get { throw null; } }
        public override bool ValueAsBoolean { get { throw null; } }
        public override System.DateTime ValueAsDateTime { get { throw null; } }
        public override double ValueAsDouble { get { throw null; } }
        public override int ValueAsInt { get { throw null; } }
        public override long ValueAsLong { get { throw null; } }
        public override System.Type ValueType { get { throw null; } }
        public virtual string XmlLang { get { throw null; } }
        public virtual System.Xml.XmlWriter AppendChild() { throw null; }
        public virtual void AppendChild(string newChild) { }
        public virtual void AppendChild(System.Xml.XmlReader newChild) { }
        public virtual void AppendChild(System.Xml.XPath.XPathNavigator newChild) { }
        public virtual void AppendChildElement(string prefix, string localName, string namespaceURI, string value) { }
        public abstract System.Xml.XPath.XPathNavigator Clone();
        public virtual System.Xml.XmlNodeOrder ComparePosition(System.Xml.XPath.XPathNavigator nav) { throw null; }
        public virtual System.Xml.XPath.XPathExpression Compile(string xpath) { throw null; }
        public virtual void CreateAttribute(string prefix, string localName, string namespaceURI, string value) { }
        public virtual System.Xml.XmlWriter CreateAttributes() { throw null; }
        public virtual System.Xml.XPath.XPathNavigator CreateNavigator() { throw null; }
        public virtual void DeleteRange(System.Xml.XPath.XPathNavigator lastSiblingToDelete) { }
        public virtual void DeleteSelf() { }
        public virtual object Evaluate(string xpath) { throw null; }
        public virtual object Evaluate(string xpath, System.Xml.IXmlNamespaceResolver resolver) { throw null; }
        public virtual object Evaluate(System.Xml.XPath.XPathExpression expr) { throw null; }
        public virtual object Evaluate(System.Xml.XPath.XPathExpression expr, System.Xml.XPath.XPathNodeIterator context) { throw null; }
        public virtual string GetAttribute(string localName, string namespaceURI) { throw null; }
        public virtual string GetNamespace(string name) { throw null; }
        public virtual System.Collections.Generic.IDictionary<string, string> GetNamespacesInScope(System.Xml.XmlNamespaceScope scope) { throw null; }
        public virtual System.Xml.XmlWriter InsertAfter() { throw null; }
        public virtual void InsertAfter(string newSibling) { }
        public virtual void InsertAfter(System.Xml.XmlReader newSibling) { }
        public virtual void InsertAfter(System.Xml.XPath.XPathNavigator newSibling) { }
        public virtual System.Xml.XmlWriter InsertBefore() { throw null; }
        public virtual void InsertBefore(string newSibling) { }
        public virtual void InsertBefore(System.Xml.XmlReader newSibling) { }
        public virtual void InsertBefore(System.Xml.XPath.XPathNavigator newSibling) { }
        public virtual void InsertElementAfter(string prefix, string localName, string namespaceURI, string value) { }
        public virtual void InsertElementBefore(string prefix, string localName, string namespaceURI, string value) { }
        public virtual bool IsDescendant(System.Xml.XPath.XPathNavigator nav) { throw null; }
        public abstract bool IsSamePosition(System.Xml.XPath.XPathNavigator other);
        public virtual string LookupNamespace(string prefix) { throw null; }
        public virtual string LookupPrefix(string namespaceURI) { throw null; }
        public virtual bool Matches(string xpath) { throw null; }
        public virtual bool Matches(System.Xml.XPath.XPathExpression expr) { throw null; }
        public abstract bool MoveTo(System.Xml.XPath.XPathNavigator other);
        public virtual bool MoveToAttribute(string localName, string namespaceURI) { throw null; }
        public virtual bool MoveToChild(string localName, string namespaceURI) { throw null; }
        public virtual bool MoveToChild(System.Xml.XPath.XPathNodeType type) { throw null; }
        public virtual bool MoveToFirst() { throw null; }
        public abstract bool MoveToFirstAttribute();
        public abstract bool MoveToFirstChild();
        public bool MoveToFirstNamespace() { throw null; }
        public abstract bool MoveToFirstNamespace(System.Xml.XPath.XPathNamespaceScope namespaceScope);
        public virtual bool MoveToFollowing(string localName, string namespaceURI) { throw null; }
        public virtual bool MoveToFollowing(string localName, string namespaceURI, System.Xml.XPath.XPathNavigator end) { throw null; }
        public virtual bool MoveToFollowing(System.Xml.XPath.XPathNodeType type) { throw null; }
        public virtual bool MoveToFollowing(System.Xml.XPath.XPathNodeType type, System.Xml.XPath.XPathNavigator end) { throw null; }
        public abstract bool MoveToId(string id);
        public virtual bool MoveToNamespace(string name) { throw null; }
        public abstract bool MoveToNext();
        public virtual bool MoveToNext(string localName, string namespaceURI) { throw null; }
        public virtual bool MoveToNext(System.Xml.XPath.XPathNodeType type) { throw null; }
        public abstract bool MoveToNextAttribute();
        public bool MoveToNextNamespace() { throw null; }
        public abstract bool MoveToNextNamespace(System.Xml.XPath.XPathNamespaceScope namespaceScope);
        public abstract bool MoveToParent();
        public abstract bool MoveToPrevious();
        public virtual void MoveToRoot() { }
        public virtual System.Xml.XmlWriter PrependChild() { throw null; }
        public virtual void PrependChild(string newChild) { }
        public virtual void PrependChild(System.Xml.XmlReader newChild) { }
        public virtual void PrependChild(System.Xml.XPath.XPathNavigator newChild) { }
        public virtual void PrependChildElement(string prefix, string localName, string namespaceURI, string value) { }
        public virtual System.Xml.XmlReader ReadSubtree() { throw null; }
        public virtual System.Xml.XmlWriter ReplaceRange(System.Xml.XPath.XPathNavigator lastSiblingToReplace) { throw null; }
        public virtual void ReplaceSelf(string newNode) { }
        public virtual void ReplaceSelf(System.Xml.XmlReader newNode) { }
        public virtual void ReplaceSelf(System.Xml.XPath.XPathNavigator newNode) { }
        public virtual System.Xml.XPath.XPathNodeIterator Select(string xpath) { throw null; }
        public virtual System.Xml.XPath.XPathNodeIterator Select(string xpath, System.Xml.IXmlNamespaceResolver resolver) { throw null; }
        public virtual System.Xml.XPath.XPathNodeIterator Select(System.Xml.XPath.XPathExpression expr) { throw null; }
        public virtual System.Xml.XPath.XPathNodeIterator SelectAncestors(string name, string namespaceURI, bool matchSelf) { throw null; }
        public virtual System.Xml.XPath.XPathNodeIterator SelectAncestors(System.Xml.XPath.XPathNodeType type, bool matchSelf) { throw null; }
        public virtual System.Xml.XPath.XPathNodeIterator SelectChildren(string name, string namespaceURI) { throw null; }
        public virtual System.Xml.XPath.XPathNodeIterator SelectChildren(System.Xml.XPath.XPathNodeType type) { throw null; }
        public virtual System.Xml.XPath.XPathNodeIterator SelectDescendants(string name, string namespaceURI, bool matchSelf) { throw null; }
        public virtual System.Xml.XPath.XPathNodeIterator SelectDescendants(System.Xml.XPath.XPathNodeType type, bool matchSelf) { throw null; }
        public virtual System.Xml.XPath.XPathNavigator SelectSingleNode(string xpath) { throw null; }
        public virtual System.Xml.XPath.XPathNavigator SelectSingleNode(string xpath, System.Xml.IXmlNamespaceResolver resolver) { throw null; }
        public virtual System.Xml.XPath.XPathNavigator SelectSingleNode(System.Xml.XPath.XPathExpression expression) { throw null; }
        public virtual void SetTypedValue(object typedValue) { }
        public virtual void SetValue(string value) { }
        public override string ToString() { throw null; }
        public override object ValueAs(System.Type returnType, System.Xml.IXmlNamespaceResolver nsResolver) { throw null; }
        public virtual void WriteSubtree(System.Xml.XmlWriter writer) { }
    }
    public abstract partial class XPathNodeIterator : System.Collections.IEnumerable
    {
        protected XPathNodeIterator() { }
        public virtual int Count { get { throw null; } }
        public abstract System.Xml.XPath.XPathNavigator Current { get; }
        public abstract int CurrentPosition { get; }
        public abstract System.Xml.XPath.XPathNodeIterator Clone();
        public virtual System.Collections.IEnumerator GetEnumerator() { throw null; }
        public abstract bool MoveNext();
    }
    public enum XPathNodeType
    {
        All = 9,
        Attribute = 2,
        Comment = 8,
        Element = 1,
        Namespace = 3,
        ProcessingInstruction = 7,
        Root = 0,
        SignificantWhitespace = 5,
        Text = 4,
        Whitespace = 6,
    }
    public enum XPathResultType
    {
        Any = 5,
        Boolean = 2,
        Error = 6,
        Navigator = 1,
        NodeSet = 3,
        Number = 0,
        String = 1,
    }
}
