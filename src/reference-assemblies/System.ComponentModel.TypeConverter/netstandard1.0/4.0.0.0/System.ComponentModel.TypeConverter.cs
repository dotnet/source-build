[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ComponentModel.TypeConverter")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ComponentModel.TypeConverter")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.6.23123.00")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.6.23123.00 built by: PROJECTKREL")]
[assembly:System.Reflection.AssemblyMetadataAttribute("", "")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ComponentModel.TypeConverter")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.ComponentModel
{
    public partial class ArrayConverter : System.ComponentModel.CollectionConverter
    {
        public ArrayConverter() { }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
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
    }
    public partial class ByteConverter : System.ComponentModel.BaseNumberConverter
    {
        public ByteConverter() { }
    }
    public partial class CharConverter : System.ComponentModel.TypeConverter
    {
        public CharConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
    public partial class CollectionConverter : System.ComponentModel.TypeConverter
    {
        public CollectionConverter() { }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
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
    public partial class DoubleConverter : System.ComponentModel.BaseNumberConverter
    {
        public DoubleConverter() { }
    }
    public partial class EnumConverter : System.ComponentModel.TypeConverter
    {
        public EnumConverter(System.Type type) { }
        protected System.Type EnumType { get { throw null; } }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
    }
    public partial class GuidConverter : System.ComponentModel.TypeConverter
    {
        public GuidConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
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
    public partial interface ITypeDescriptorContext : System.IServiceProvider
    {
        System.ComponentModel.IContainer Container { get; }
        object Instance { get; }
        System.ComponentModel.PropertyDescriptor PropertyDescriptor { get; }
        void OnComponentChanged();
        bool OnComponentChanging();
    }
    public partial class MultilineStringConverter : System.ComponentModel.TypeConverter
    {
        public MultilineStringConverter() { }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
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
    }
    public abstract partial class PropertyDescriptor
    {
        internal PropertyDescriptor() { }
    }
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
        public object ConvertFromInvariantString(string text) { throw null; }
        public object ConvertFromString(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, string text) { throw null; }
        public object ConvertFromString(string text) { throw null; }
        public virtual object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
        public object ConvertTo(object value, System.Type destinationType) { throw null; }
        public string ConvertToInvariantString(object value) { throw null; }
        public string ConvertToString(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public string ConvertToString(object value) { throw null; }
        protected System.Exception GetConvertFromException(object value) { throw null; }
        protected System.Exception GetConvertToException(object value, System.Type destinationType) { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(32767))]
    public sealed partial class TypeConverterAttribute : System.Attribute
    {
        public TypeConverterAttribute(string typeName) { }
        public TypeConverterAttribute(System.Type type) { }
        public string ConverterTypeName { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class TypeDescriptor
    {
        internal TypeDescriptor() { }
        public static System.ComponentModel.TypeConverter GetConverter(System.Type type) { throw null; }
    }
    public abstract partial class TypeListConverter : System.ComponentModel.TypeConverter
    {
        protected TypeListConverter(System.Type[] types) { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { throw null; }
        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) { throw null; }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { throw null; }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) { throw null; }
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
