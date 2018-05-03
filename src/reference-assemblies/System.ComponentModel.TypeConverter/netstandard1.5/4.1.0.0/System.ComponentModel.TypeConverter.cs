[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ComponentModel.TypeConverter")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ComponentModel.TypeConverter")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ComponentModel.TypeConverter")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System
{
    public partial class UriTypeConverter : System.ComponentModel.TypeConverter
    {
        public UriTypeConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
}
namespace System.ComponentModel
{
    public partial class ArrayConverter : System.ComponentModel.CollectionConverter
    {
        public ArrayConverter() { }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributes) { throw null; }
        public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
    }
    public partial class AttributeCollection : System.Collections.ICollection, System.Collections.IEnumerable
    {
        public static readonly System.ComponentModel.AttributeCollection Empty;
        protected AttributeCollection() { }
        public AttributeCollection(params System.Attribute[] attributes) { }
        protected virtual System.Attribute[] Attributes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public int Count { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual System.Attribute this[int index] { get { throw null; } }
        public virtual System.Attribute this[System.Type attributeType] { get { throw null; } }
        bool System.Collections.ICollection.IsSynchronized { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        object System.Collections.ICollection.SyncRoot { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Contains(System.Attribute attribute) { throw null; }
        public bool Contains(System.Attribute[] attributes) { throw null; }
        public void CopyTo(System.Array array, int index) { }
        public static System.ComponentModel.AttributeCollection FromExisting(System.ComponentModel.AttributeCollection existing, params System.Attribute[] newAttributes) { throw null; }
        protected System.Attribute GetDefaultAttribute(System.Type attributeType) { throw null; }
        public System.Collections.IEnumerator GetEnumerator() { throw null; }
        public bool Matches(System.Attribute attribute) { throw null; }
        public bool Matches(System.Attribute[] attributes) { throw null; }
    }
    public partial class AttributeProviderAttribute : System.Attribute
    {
        public AttributeProviderAttribute(string typeName) { }
        public AttributeProviderAttribute(string typeName, string propertyName) { }
        public AttributeProviderAttribute(System.Type type) { }
        public string PropertyName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string TypeName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public abstract partial class BaseNumberConverter : System.ComponentModel.TypeConverter
    {
        protected BaseNumberConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type t) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
    public partial class BooleanConverter : System.ComponentModel.TypeConverter
    {
        public BooleanConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
    }
    public partial class ByteConverter : System.ComponentModel.BaseNumberConverter
    {
        public ByteConverter() { }
    }
    public delegate void CancelEventHandler(object sender, System.ComponentModel.CancelEventArgs e);
    public partial class CharConverter : System.ComponentModel.TypeConverter
    {
        public CharConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
    public enum CollectionChangeAction
    {
        Add = 1,
        Refresh = 3,
        Remove = 2,
    }
    public partial class CollectionChangeEventArgs : System.EventArgs
    {
        public CollectionChangeEventArgs(System.ComponentModel.CollectionChangeAction action, object element) { }
        public virtual System.ComponentModel.CollectionChangeAction Action { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual object Element { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public delegate void CollectionChangeEventHandler(object sender, System.ComponentModel.CollectionChangeEventArgs e);
    public partial class CollectionConverter : System.ComponentModel.TypeConverter
    {
        public CollectionConverter() { }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributes) { throw null; }
        public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
    }
    public abstract partial class CustomTypeDescriptor : System.ComponentModel.ICustomTypeDescriptor
    {
        protected CustomTypeDescriptor() { }
        protected CustomTypeDescriptor(System.ComponentModel.ICustomTypeDescriptor parent) { }
        public virtual System.ComponentModel.AttributeCollection GetAttributes() { throw null; }
        public virtual string GetClassName() { throw null; }
        public virtual string GetComponentName() { throw null; }
        public virtual System.ComponentModel.TypeConverter GetConverter() { throw null; }
        public virtual System.ComponentModel.EventDescriptor GetDefaultEvent() { throw null; }
        public virtual System.ComponentModel.PropertyDescriptor GetDefaultProperty() { throw null; }
        public virtual object GetEditor(System.Type editorBaseType) { throw null; }
        public virtual System.ComponentModel.EventDescriptorCollection GetEvents() { throw null; }
        public virtual System.ComponentModel.EventDescriptorCollection GetEvents(System.Attribute[] attributes) { throw null; }
        public virtual System.ComponentModel.PropertyDescriptorCollection GetProperties() { throw null; }
        public virtual System.ComponentModel.PropertyDescriptorCollection GetProperties(System.Attribute[] attributes) { throw null; }
        public virtual object GetPropertyOwner(System.ComponentModel.PropertyDescriptor pd) { throw null; }
    }
    public partial class DateTimeConverter : System.ComponentModel.TypeConverter
    {
        public DateTimeConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
    public partial class DateTimeOffsetConverter : System.ComponentModel.TypeConverter
    {
        public DateTimeOffsetConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
    public partial class DecimalConverter : System.ComponentModel.BaseNumberConverter
    {
        public DecimalConverter() { }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
    public sealed partial class DefaultEventAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.DefaultEventAttribute Default;
        public DefaultEventAttribute(string name) { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class DefaultPropertyAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.DefaultPropertyAttribute Default;
        public DefaultPropertyAttribute(string name) { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class DoubleConverter : System.ComponentModel.BaseNumberConverter
    {
        public DoubleConverter() { }
    }
    public partial class EnumConverter : System.ComponentModel.TypeConverter
    {
        public EnumConverter(System.Type type) { }
        protected virtual System.Collections.IComparer Comparer { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        protected System.Type EnumType { get { throw null; } }
        protected System.ComponentModel.TypeConverter.StandardValuesCollection Values { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool IsValid(System.ComponentModel.ITypeDescriptorContext context, object value) { throw null; }
    }
    public abstract partial class EventDescriptor : System.ComponentModel.MemberDescriptor
    {
        protected EventDescriptor(System.ComponentModel.MemberDescriptor descr) : base (default(System.ComponentModel.MemberDescriptor)) { }
        protected EventDescriptor(System.ComponentModel.MemberDescriptor descr, System.Attribute[] attrs) : base (default(System.ComponentModel.MemberDescriptor)) { }
        protected EventDescriptor(string name, System.Attribute[] attrs) : base (default(System.ComponentModel.MemberDescriptor)) { }
        public abstract System.Type ComponentType { get; }
        public abstract System.Type EventType { get; }
        public abstract bool IsMulticast { get; }
        public abstract void AddEventHandler(object component, System.Delegate value);
        public abstract void RemoveEventHandler(object component, System.Delegate value);
    }
    public partial class EventDescriptorCollection : System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
    {
        public static readonly System.ComponentModel.EventDescriptorCollection Empty;
        public EventDescriptorCollection(System.ComponentModel.EventDescriptor[] events) { }
        public EventDescriptorCollection(System.ComponentModel.EventDescriptor[] events, bool readOnly) { }
        public int Count { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual System.ComponentModel.EventDescriptor this[int index] { get { throw null; } }
        public virtual System.ComponentModel.EventDescriptor this[string name] { get { throw null; } }
        bool System.Collections.ICollection.IsSynchronized { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        object System.Collections.ICollection.SyncRoot { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        bool System.Collections.IList.IsFixedSize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        bool System.Collections.IList.IsReadOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
        public int Add(System.ComponentModel.EventDescriptor value) { throw null; }
        public void Clear() { }
        public bool Contains(System.ComponentModel.EventDescriptor value) { throw null; }
        public virtual System.ComponentModel.EventDescriptor Find(string name, bool ignoreCase) { throw null; }
        public System.Collections.IEnumerator GetEnumerator() { throw null; }
        public int IndexOf(System.ComponentModel.EventDescriptor value) { throw null; }
        public void Insert(int index, System.ComponentModel.EventDescriptor value) { }
        protected void InternalSort(System.Collections.IComparer sorter) { }
        protected void InternalSort(string[] names) { }
        public void Remove(System.ComponentModel.EventDescriptor value) { }
        public void RemoveAt(int index) { }
        public virtual System.ComponentModel.EventDescriptorCollection Sort() { throw null; }
        public virtual System.ComponentModel.EventDescriptorCollection Sort(System.Collections.IComparer comparer) { throw null; }
        public virtual System.ComponentModel.EventDescriptorCollection Sort(string[] names) { throw null; }
        public virtual System.ComponentModel.EventDescriptorCollection Sort(string[] names, System.Collections.IComparer comparer) { throw null; }
        void System.Collections.ICollection.CopyTo(System.Array array, int index) { }
        int System.Collections.IList.Add(object value) { throw null; }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        void System.Collections.IList.Remove(object value) { }
    }
    public sealed partial class ExtenderProvidedPropertyAttribute : System.Attribute
    {
        public ExtenderProvidedPropertyAttribute() { }
        public System.ComponentModel.PropertyDescriptor ExtenderProperty { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.ComponentModel.IExtenderProvider Provider { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Type ReceiverType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class GuidConverter : System.ComponentModel.TypeConverter
    {
        public GuidConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
    public partial class HandledEventArgs : System.EventArgs
    {
        public HandledEventArgs() { }
        public HandledEventArgs(bool defaultHandledValue) { }
        public bool Handled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public delegate void HandledEventHandler(object sender, System.ComponentModel.HandledEventArgs e);
    public partial interface ICustomTypeDescriptor
    {
        System.ComponentModel.AttributeCollection GetAttributes();
        string GetClassName();
        string GetComponentName();
        System.ComponentModel.TypeConverter GetConverter();
        System.ComponentModel.EventDescriptor GetDefaultEvent();
        System.ComponentModel.PropertyDescriptor GetDefaultProperty();
        object GetEditor(System.Type editorBaseType);
        System.ComponentModel.EventDescriptorCollection GetEvents();
        System.ComponentModel.EventDescriptorCollection GetEvents(System.Attribute[] attributes);
        System.ComponentModel.PropertyDescriptorCollection GetProperties();
        System.ComponentModel.PropertyDescriptorCollection GetProperties(System.Attribute[] attributes);
        object GetPropertyOwner(System.ComponentModel.PropertyDescriptor pd);
    }
    public partial interface IExtenderProvider
    {
        bool CanExtend(object extendee);
    }
    public partial interface IListSource
    {
        bool ContainsListCollection { get; }
        System.Collections.IList GetList();
    }
    public partial class Int16Converter : System.ComponentModel.BaseNumberConverter
    {
        public Int16Converter() { }
    }
    public partial class Int32Converter : System.ComponentModel.BaseNumberConverter
    {
        public Int32Converter() { }
    }
    public partial class Int64Converter : System.ComponentModel.BaseNumberConverter
    {
        public Int64Converter() { }
    }
    public partial class InvalidAsynchronousStateException : System.ArgumentException
    {
        public InvalidAsynchronousStateException() { }
        public InvalidAsynchronousStateException(string message) { }
        public InvalidAsynchronousStateException(string message, System.Exception innerException) { }
    }
    public partial interface ITypeDescriptorContext : System.IServiceProvider
    {
        System.ComponentModel.IContainer Container { get; }
        object Instance { get; }
        System.ComponentModel.PropertyDescriptor PropertyDescriptor { get; }
        void OnComponentChanged();
        bool OnComponentChanging();
    }
    public partial interface ITypedList
    {
        System.ComponentModel.PropertyDescriptorCollection GetItemProperties(System.ComponentModel.PropertyDescriptor[] listAccessors);
        string GetListName(System.ComponentModel.PropertyDescriptor[] listAccessors);
    }
    public abstract partial class MemberDescriptor
    {
        protected MemberDescriptor(System.ComponentModel.MemberDescriptor descr) { }
        protected MemberDescriptor(System.ComponentModel.MemberDescriptor oldMemberDescriptor, System.Attribute[] newAttributes) { }
        protected MemberDescriptor(string name) { }
        protected MemberDescriptor(string name, System.Attribute[] attributes) { }
        protected virtual System.Attribute[] AttributeArray { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public virtual System.ComponentModel.AttributeCollection Attributes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual string Category { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual bool DesignTimeOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual string DisplayName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual bool IsBrowsable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        protected virtual int NameHashCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        protected virtual System.ComponentModel.AttributeCollection CreateAttributeCollection() { throw null; }
        public override bool Equals(object obj) { throw null; }
        protected virtual void FillAttributes(System.Collections.IList attributeList) { }
        protected static System.Reflection.MethodInfo FindMethod(System.Type componentClass, string name, System.Type[] args, System.Type returnType) { throw null; }
        protected static System.Reflection.MethodInfo FindMethod(System.Type componentClass, string name, System.Type[] args, System.Type returnType, bool publicOnly) { throw null; }
        public override int GetHashCode() { throw null; }
        protected virtual object GetInvocationTarget(System.Type type, object instance) { throw null; }
        protected static System.ComponentModel.ISite GetSite(object component) { throw null; }
    }
    public partial class MultilineStringConverter : System.ComponentModel.TypeConverter
    {
        public MultilineStringConverter() { }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributes) { throw null; }
        public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
    }
    public partial class NullableConverter : System.ComponentModel.TypeConverter
    {
        public NullableConverter(System.Type type) { }
        public System.Type NullableType { get { throw null; } }
        public System.Type UnderlyingType { get { throw null; } }
        public System.ComponentModel.TypeConverter UnderlyingTypeConverter { get { throw null; } }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
        public override object CreateInstance(System.ComponentModel.ITypeDescriptorContext context, System.Collections.IDictionary propertyValues) { throw null; }
        public override bool GetCreateInstanceSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override System.ComponentModel.PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributes) { throw null; }
        public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool IsValid(System.ComponentModel.ITypeDescriptorContext context, object value) { throw null; }
    }
    public abstract partial class PropertyDescriptor : System.ComponentModel.MemberDescriptor
    {
        protected PropertyDescriptor(System.ComponentModel.MemberDescriptor descr) : base (default(System.ComponentModel.MemberDescriptor)) { }
        protected PropertyDescriptor(System.ComponentModel.MemberDescriptor descr, System.Attribute[] attrs) : base (default(System.ComponentModel.MemberDescriptor)) { }
        protected PropertyDescriptor(string name, System.Attribute[] attrs) : base (default(System.ComponentModel.MemberDescriptor)) { }
        public abstract System.Type ComponentType { get; }
        public virtual System.ComponentModel.TypeConverter Converter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual bool IsLocalizable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public abstract bool IsReadOnly { get; }
        public abstract System.Type PropertyType { get; }
        public System.ComponentModel.DesignerSerializationVisibility SerializationVisibility { get { throw null; } }
        public virtual bool SupportsChangeEvents { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual void AddValueChanged(object component, System.EventHandler handler) { }
        public abstract bool CanResetValue(object component);
        protected object CreateInstance(System.Type type) { throw null; }
        public override bool Equals(object obj) { throw null; }
        protected override void FillAttributes(System.Collections.IList attributeList) { }
        public System.ComponentModel.PropertyDescriptorCollection GetChildProperties() { throw null; }
        public System.ComponentModel.PropertyDescriptorCollection GetChildProperties(System.Attribute[] filter) { throw null; }
        public System.ComponentModel.PropertyDescriptorCollection GetChildProperties(object instance) { throw null; }
        public virtual System.ComponentModel.PropertyDescriptorCollection GetChildProperties(object instance, System.Attribute[] filter) { throw null; }
        public virtual object GetEditor(System.Type editorBaseType) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override object GetInvocationTarget(System.Type type, object instance) { throw null; }
        protected System.Type GetTypeFromName(string typeName) { throw null; }
        public abstract object GetValue(object component);
        protected internal System.EventHandler GetValueChangedHandler(object component) { throw null; }
        protected virtual void OnValueChanged(object component, System.EventArgs e) { }
        public virtual void RemoveValueChanged(object component, System.EventHandler handler) { }
        public abstract void ResetValue(object component);
        public abstract void SetValue(object component, object value);
        public abstract bool ShouldSerializeValue(object component);
    }
    public partial class PropertyDescriptorCollection : System.Collections.ICollection, System.Collections.IDictionary, System.Collections.IEnumerable, System.Collections.IList
    {
        public static readonly System.ComponentModel.PropertyDescriptorCollection Empty;
        public PropertyDescriptorCollection(System.ComponentModel.PropertyDescriptor[] properties) { }
        public PropertyDescriptorCollection(System.ComponentModel.PropertyDescriptor[] properties, bool readOnly) { }
        public int Count { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public virtual System.ComponentModel.PropertyDescriptor this[int index] { get { throw null; } }
        public virtual System.ComponentModel.PropertyDescriptor this[string name] { get { throw null; } }
        bool System.Collections.ICollection.IsSynchronized { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        object System.Collections.ICollection.SyncRoot { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        bool System.Collections.IDictionary.IsFixedSize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        bool System.Collections.IDictionary.IsReadOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        object System.Collections.IDictionary.this[object key] { get { throw null; } set { } }
        System.Collections.ICollection System.Collections.IDictionary.Keys { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        System.Collections.ICollection System.Collections.IDictionary.Values { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        bool System.Collections.IList.IsFixedSize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        bool System.Collections.IList.IsReadOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
        public int Add(System.ComponentModel.PropertyDescriptor value) { throw null; }
        public void Clear() { }
        public bool Contains(System.ComponentModel.PropertyDescriptor value) { throw null; }
        public void CopyTo(System.Array array, int index) { }
        public virtual System.ComponentModel.PropertyDescriptor Find(string name, bool ignoreCase) { throw null; }
        public virtual System.Collections.IEnumerator GetEnumerator() { throw null; }
        public int IndexOf(System.ComponentModel.PropertyDescriptor value) { throw null; }
        public void Insert(int index, System.ComponentModel.PropertyDescriptor value) { }
        protected void InternalSort(System.Collections.IComparer sorter) { }
        protected void InternalSort(string[] names) { }
        public void Remove(System.ComponentModel.PropertyDescriptor value) { }
        public void RemoveAt(int index) { }
        public virtual System.ComponentModel.PropertyDescriptorCollection Sort() { throw null; }
        public virtual System.ComponentModel.PropertyDescriptorCollection Sort(System.Collections.IComparer comparer) { throw null; }
        public virtual System.ComponentModel.PropertyDescriptorCollection Sort(string[] names) { throw null; }
        public virtual System.ComponentModel.PropertyDescriptorCollection Sort(string[] names, System.Collections.IComparer comparer) { throw null; }
        void System.Collections.IDictionary.Add(object key, object value) { }
        bool System.Collections.IDictionary.Contains(object key) { throw null; }
        System.Collections.IDictionaryEnumerator System.Collections.IDictionary.GetEnumerator() { throw null; }
        void System.Collections.IDictionary.Remove(object key) { }
        int System.Collections.IList.Add(object value) { throw null; }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        void System.Collections.IList.Remove(object value) { }
    }
    public sealed partial class ProvidePropertyAttribute : System.Attribute
    {
        public ProvidePropertyAttribute(string propertyName, string receiverTypeName) { }
        public ProvidePropertyAttribute(string propertyName, System.Type receiverType) { }
        public string PropertyName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string ReceiverTypeName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class RefreshEventArgs : System.EventArgs
    {
        public RefreshEventArgs(object componentChanged) { }
        public RefreshEventArgs(System.Type typeChanged) { }
        public object ComponentChanged { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Type TypeChanged { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public delegate void RefreshEventHandler(System.ComponentModel.RefreshEventArgs e);
    public partial class SByteConverter : System.ComponentModel.BaseNumberConverter
    {
        public SByteConverter() { }
    }
    public partial class SingleConverter : System.ComponentModel.BaseNumberConverter
    {
        public SingleConverter() { }
    }
    public partial class StringConverter : System.ComponentModel.TypeConverter
    {
        public StringConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
    }
    public partial class TimeSpanConverter : System.ComponentModel.TypeConverter
    {
        public TimeSpanConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
    public partial class TypeConverter
    {
        public TypeConverter() { }
        public virtual bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public bool CanConvertFrom(System.Type sourceType) { throw null; }
        public virtual bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public bool CanConvertTo(System.Type destinationType) { throw null; }
        public virtual object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public object ConvertFrom(object value) { throw null; }
        public object ConvertFromInvariantString(System.ComponentModel.ITypeDescriptorContext context, string text) { throw null; }
        public object ConvertFromInvariantString(string text) { throw null; }
        public object ConvertFromString(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, string text) { throw null; }
        public object ConvertFromString(System.ComponentModel.ITypeDescriptorContext context, string text) { throw null; }
        public object ConvertFromString(string text) { throw null; }
        public virtual object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
        public object ConvertTo(object value, System.Type destinationType) { throw null; }
        public string ConvertToInvariantString(System.ComponentModel.ITypeDescriptorContext context, object value) { throw null; }
        public string ConvertToInvariantString(object value) { throw null; }
        public string ConvertToString(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public string ConvertToString(System.ComponentModel.ITypeDescriptorContext context, object value) { throw null; }
        public string ConvertToString(object value) { throw null; }
        public object CreateInstance(System.Collections.IDictionary propertyValues) { throw null; }
        public virtual object CreateInstance(System.ComponentModel.ITypeDescriptorContext context, System.Collections.IDictionary propertyValues) { throw null; }
        protected System.Exception GetConvertFromException(object value) { throw null; }
        protected System.Exception GetConvertToException(object value, System.Type destinationType) { throw null; }
        public bool GetCreateInstanceSupported() { throw null; }
        public virtual bool GetCreateInstanceSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public System.ComponentModel.PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value) { throw null; }
        public virtual System.ComponentModel.PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributes) { throw null; }
        public System.ComponentModel.PropertyDescriptorCollection GetProperties(object value) { throw null; }
        public bool GetPropertiesSupported() { throw null; }
        public virtual bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public System.Collections.ICollection GetStandardValues() { throw null; }
        public virtual System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public bool GetStandardValuesExclusive() { throw null; }
        public virtual bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public bool GetStandardValuesSupported() { throw null; }
        public virtual bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public virtual bool IsValid(System.ComponentModel.ITypeDescriptorContext context, object value) { throw null; }
        public bool IsValid(object value) { throw null; }
        protected System.ComponentModel.PropertyDescriptorCollection SortProperties(System.ComponentModel.PropertyDescriptorCollection props, string[] names) { throw null; }
        protected abstract partial class SimplePropertyDescriptor : System.ComponentModel.PropertyDescriptor
        {
            protected SimplePropertyDescriptor(System.Type componentType, string name, System.Type propertyType) : base (default(System.ComponentModel.MemberDescriptor)) { }
            protected SimplePropertyDescriptor(System.Type componentType, string name, System.Type propertyType, System.Attribute[] attributes) : base (default(System.ComponentModel.MemberDescriptor)) { }
            public override System.Type ComponentType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
            public override bool IsReadOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
            public override System.Type PropertyType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
            public override bool CanResetValue(object component) { throw null; }
            public override void ResetValue(object component) { }
            public override bool ShouldSerializeValue(object component) { throw null; }
        }
        public partial class StandardValuesCollection : System.Collections.ICollection, System.Collections.IEnumerable
        {
            public StandardValuesCollection(System.Collections.ICollection values) { }
            public int Count { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
            public object this[int index] { get { throw null; } }
            bool System.Collections.ICollection.IsSynchronized { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
            object System.Collections.ICollection.SyncRoot { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
            public void CopyTo(System.Array array, int index) { }
            public System.Collections.IEnumerator GetEnumerator() { throw null; }
        }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(32767))]
    public sealed partial class TypeConverterAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.TypeConverterAttribute Default;
        public TypeConverterAttribute() { }
        public TypeConverterAttribute(string typeName) { }
        public TypeConverterAttribute(System.Type type) { }
        public string ConverterTypeName { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public abstract partial class TypeDescriptionProvider
    {
        protected TypeDescriptionProvider() { }
        protected TypeDescriptionProvider(System.ComponentModel.TypeDescriptionProvider parent) { }
        public virtual object CreateInstance(System.IServiceProvider provider, System.Type objectType, System.Type[] argTypes, object[] args) { throw null; }
        public virtual System.Collections.IDictionary GetCache(object instance) { throw null; }
        public virtual System.ComponentModel.ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance) { throw null; }
        protected internal virtual System.ComponentModel.IExtenderProvider[] GetExtenderProviders(object instance) { throw null; }
        public virtual string GetFullComponentName(object component) { throw null; }
        public System.Type GetReflectionType(object instance) { throw null; }
        public System.Type GetReflectionType(System.Type objectType) { throw null; }
        public virtual System.Type GetReflectionType(System.Type objectType, object instance) { throw null; }
        public virtual System.Type GetRuntimeType(System.Type reflectionType) { throw null; }
        public System.ComponentModel.ICustomTypeDescriptor GetTypeDescriptor(object instance) { throw null; }
        public System.ComponentModel.ICustomTypeDescriptor GetTypeDescriptor(System.Type objectType) { throw null; }
        public virtual System.ComponentModel.ICustomTypeDescriptor GetTypeDescriptor(System.Type objectType, object instance) { throw null; }
        public virtual bool IsSupportedType(System.Type type) { throw null; }
    }
    public sealed partial class TypeDescriptionProviderAttribute : System.Attribute
    {
        public TypeDescriptionProviderAttribute(string typeName) { }
        public TypeDescriptionProviderAttribute(System.Type type) { }
        public string TypeName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public sealed partial class TypeDescriptor
    {
        internal TypeDescriptor() { }
        public static System.Type InterfaceType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static event System.ComponentModel.RefreshEventHandler Refreshed { add { } remove { } }
        public static System.ComponentModel.TypeDescriptionProvider AddAttributes(object instance, params System.Attribute[] attributes) { throw null; }
        public static System.ComponentModel.TypeDescriptionProvider AddAttributes(System.Type type, params System.Attribute[] attributes) { throw null; }
        public static void AddEditorTable(System.Type editorBaseType, System.Collections.Hashtable table) { }
        public static void AddProvider(System.ComponentModel.TypeDescriptionProvider provider, object instance) { }
        public static void AddProvider(System.ComponentModel.TypeDescriptionProvider provider, System.Type type) { }
        public static void AddProviderTransparent(System.ComponentModel.TypeDescriptionProvider provider, object instance) { }
        public static void AddProviderTransparent(System.ComponentModel.TypeDescriptionProvider provider, System.Type type) { }
        public static void CreateAssociation(object primary, object secondary) { }
        public static System.ComponentModel.EventDescriptor CreateEvent(System.Type componentType, System.ComponentModel.EventDescriptor oldEventDescriptor, params System.Attribute[] attributes) { throw null; }
        public static System.ComponentModel.EventDescriptor CreateEvent(System.Type componentType, string name, System.Type type, params System.Attribute[] attributes) { throw null; }
        public static object CreateInstance(System.IServiceProvider provider, System.Type objectType, System.Type[] argTypes, object[] args) { throw null; }
        public static System.ComponentModel.PropertyDescriptor CreateProperty(System.Type componentType, System.ComponentModel.PropertyDescriptor oldPropertyDescriptor, params System.Attribute[] attributes) { throw null; }
        public static System.ComponentModel.PropertyDescriptor CreateProperty(System.Type componentType, string name, System.Type type, params System.Attribute[] attributes) { throw null; }
        public static object GetAssociation(System.Type type, object primary) { throw null; }
        public static System.ComponentModel.AttributeCollection GetAttributes(object component) { throw null; }
        public static System.ComponentModel.AttributeCollection GetAttributes(object component, bool noCustomTypeDesc) { throw null; }
        public static System.ComponentModel.AttributeCollection GetAttributes(System.Type componentType) { throw null; }
        public static string GetClassName(object component) { throw null; }
        public static string GetClassName(object component, bool noCustomTypeDesc) { throw null; }
        public static string GetClassName(System.Type componentType) { throw null; }
        public static string GetComponentName(object component) { throw null; }
        public static string GetComponentName(object component, bool noCustomTypeDesc) { throw null; }
        public static System.ComponentModel.TypeConverter GetConverter(object component) { throw null; }
        public static System.ComponentModel.TypeConverter GetConverter(object component, bool noCustomTypeDesc) { throw null; }
        public static System.ComponentModel.TypeConverter GetConverter(System.Type type) { throw null; }
        public static System.ComponentModel.EventDescriptor GetDefaultEvent(object component) { throw null; }
        public static System.ComponentModel.EventDescriptor GetDefaultEvent(object component, bool noCustomTypeDesc) { throw null; }
        public static System.ComponentModel.EventDescriptor GetDefaultEvent(System.Type componentType) { throw null; }
        public static System.ComponentModel.PropertyDescriptor GetDefaultProperty(object component) { throw null; }
        public static System.ComponentModel.PropertyDescriptor GetDefaultProperty(object component, bool noCustomTypeDesc) { throw null; }
        public static System.ComponentModel.PropertyDescriptor GetDefaultProperty(System.Type componentType) { throw null; }
        public static object GetEditor(object component, System.Type editorBaseType) { throw null; }
        public static object GetEditor(object component, System.Type editorBaseType, bool noCustomTypeDesc) { throw null; }
        public static object GetEditor(System.Type type, System.Type editorBaseType) { throw null; }
        public static System.ComponentModel.EventDescriptorCollection GetEvents(object component) { throw null; }
        public static System.ComponentModel.EventDescriptorCollection GetEvents(object component, System.Attribute[] attributes) { throw null; }
        public static System.ComponentModel.EventDescriptorCollection GetEvents(object component, System.Attribute[] attributes, bool noCustomTypeDesc) { throw null; }
        public static System.ComponentModel.EventDescriptorCollection GetEvents(object component, bool noCustomTypeDesc) { throw null; }
        public static System.ComponentModel.EventDescriptorCollection GetEvents(System.Type componentType) { throw null; }
        public static System.ComponentModel.EventDescriptorCollection GetEvents(System.Type componentType, System.Attribute[] attributes) { throw null; }
        public static string GetFullComponentName(object component) { throw null; }
        public static System.ComponentModel.PropertyDescriptorCollection GetProperties(object component) { throw null; }
        public static System.ComponentModel.PropertyDescriptorCollection GetProperties(object component, System.Attribute[] attributes) { throw null; }
        public static System.ComponentModel.PropertyDescriptorCollection GetProperties(object component, System.Attribute[] attributes, bool noCustomTypeDesc) { throw null; }
        public static System.ComponentModel.PropertyDescriptorCollection GetProperties(object component, bool noCustomTypeDesc) { throw null; }
        public static System.ComponentModel.PropertyDescriptorCollection GetProperties(System.Type componentType) { throw null; }
        public static System.ComponentModel.PropertyDescriptorCollection GetProperties(System.Type componentType, System.Attribute[] attributes) { throw null; }
        public static System.ComponentModel.TypeDescriptionProvider GetProvider(object instance) { throw null; }
        public static System.ComponentModel.TypeDescriptionProvider GetProvider(System.Type type) { throw null; }
        public static System.Type GetReflectionType(object instance) { throw null; }
        public static System.Type GetReflectionType(System.Type type) { throw null; }
        public static void Refresh(object component) { }
        public static void Refresh(System.Reflection.Assembly assembly) { }
        public static void Refresh(System.Reflection.Module module) { }
        public static void Refresh(System.Type type) { }
        public static void RemoveAssociation(object primary, object secondary) { }
        public static void RemoveAssociations(object primary) { }
        public static void RemoveProvider(System.ComponentModel.TypeDescriptionProvider provider, object instance) { }
        public static void RemoveProvider(System.ComponentModel.TypeDescriptionProvider provider, System.Type type) { }
        public static void RemoveProviderTransparent(System.ComponentModel.TypeDescriptionProvider provider, object instance) { }
        public static void RemoveProviderTransparent(System.ComponentModel.TypeDescriptionProvider provider, System.Type type) { }
        public static void SortDescriptorArray(System.Collections.IList infos) { }
    }
    public abstract partial class TypeListConverter : System.ComponentModel.TypeConverter
    {
        protected TypeListConverter(System.Type[] types) { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context) { throw null; }
    }
    public partial class UInt16Converter : System.ComponentModel.BaseNumberConverter
    {
        public UInt16Converter() { }
    }
    public partial class UInt32Converter : System.ComponentModel.BaseNumberConverter
    {
        public UInt32Converter() { }
    }
    public partial class UInt64Converter : System.ComponentModel.BaseNumberConverter
    {
        public UInt64Converter() { }
    }
}
