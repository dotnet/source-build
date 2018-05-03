[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Newtonsoft")]
[assembly:System.Reflection.AssemblyConfigurationAttribute("")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("Copyright © James Newton-King 2008")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("Json.NET is a popular high-performance JSON framework for .NET")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("9.0.1.19813")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("9.0.1")]
[assembly:System.Reflection.AssemblyProductAttribute("Json.NET")]
[assembly:System.Reflection.AssemblyTitleAttribute("Json.NET .NET Standard 1.0")]
[assembly:System.Reflection.AssemblyTrademarkAttribute("")]
[assembly:System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Newtonsoft.Json.Dynamic, PublicKey=0024000004800000940000000602000000240000525341310004000001000100cbd8d53b9d7de30f1f1278f636ec462cf9c254991291e66ebb157a885638a517887633b898ccbcf0d5c5ff7be85a6abe9e765d0ac7cd33c68dac67e7e64530e8222101109f154ab14a941c490ac155cd1d4fcba0fabb49016b4ef28593b015cab5937da31172f03f67d09edda404b88a60023f062ae71d0b2e4438b74cc11dc9")]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Newtonsoft.Json.Schema, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f561df277c6c0b497d629032b410cdcf286e537c054724f7ffa0164345f62b3e642029d7a80cc351918955328c4adc8a048823ef90b0cf38ea7db0d729caf2b633c3babe08b0310198c1081995c19029bc675193744eab9d7345b8a67258ec17d112cebdbbb2a281487dceeafb9d83aa930f32103fbe1d2911425bc5744002c7")]
[assembly:System.Runtime.CompilerServices.InternalsVisibleToAttribute("Newtonsoft.Json.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f561df277c6c0b497d629032b410cdcf286e537c054724f7ffa0164345f62b3e642029d7a80cc351918955328c4adc8a048823ef90b0cf38ea7db0d729caf2b633c3babe08b0310198c1081995c19029bc675193744eab9d7345b8a67258ec17d112cebdbbb2a281487dceeafb9d83aa930f32103fbe1d2911425bc5744002c7")]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v1.0")]
namespace Newtonsoft.Json
{
    public enum ConstructorHandling
    {
        AllowNonPublicDefaultConstructor = 1,
        Default = 0,
    }
    public enum DateFormatHandling
    {
        IsoDateFormat = 0,
        MicrosoftDateFormat = 1,
    }
    public enum DateParseHandling
    {
        DateTime = 1,
        DateTimeOffset = 2,
        None = 0,
    }
    public enum DateTimeZoneHandling
    {
        Local = 0,
        RoundtripKind = 3,
        Unspecified = 2,
        Utc = 1,
    }
    [System.FlagsAttribute]
    public enum DefaultValueHandling
    {
        Ignore = 1,
        IgnoreAndPopulate = 3,
        Include = 0,
        Populate = 2,
    }
    public enum FloatFormatHandling
    {
        DefaultValue = 2,
        String = 0,
        Symbol = 1,
    }
    public enum FloatParseHandling
    {
        Decimal = 1,
        Double = 0,
    }
    public enum Formatting
    {
        Indented = 1,
        None = 0,
    }
    public partial interface IArrayPool<T>
    {
        T[] Rent(int minimumLength);
        void Return(T[] array);
    }
    public partial interface IJsonLineInfo
    {
        int LineNumber { get; }
        int LinePosition { get; }
        bool HasLineInfo();
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1028), AllowMultiple=false)]
    public sealed partial class JsonArrayAttribute : Newtonsoft.Json.JsonContainerAttribute
    {
        public JsonArrayAttribute() { }
        public JsonArrayAttribute(bool allowNullItems) { }
        public JsonArrayAttribute(string id) { }
        public bool AllowNullItems { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(32), AllowMultiple=false)]
    public sealed partial class JsonConstructorAttribute : System.Attribute
    {
        public JsonConstructorAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1028), AllowMultiple=false)]
    public abstract partial class JsonContainerAttribute : System.Attribute
    {
        protected JsonContainerAttribute() { }
        protected JsonContainerAttribute(string id) { }
        public string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IsReference { get { throw null; } set { } }
        public object[] ItemConverterParameters { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Type ItemConverterType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool ItemIsReference { get { throw null; } set { } }
        public Newtonsoft.Json.ReferenceLoopHandling ItemReferenceLoopHandling { get { throw null; } set { } }
        public Newtonsoft.Json.TypeNameHandling ItemTypeNameHandling { get { throw null; } set { } }
        public object[] NamingStrategyParameters { get { throw null; } set { } }
        public System.Type NamingStrategyType { get { throw null; } set { } }
        public string Title { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public static partial class JsonConvert
    {
        public static readonly string False;
        public static readonly string NaN;
        public static readonly string NegativeInfinity;
        public static readonly string Null;
        public static readonly string PositiveInfinity;
        public static readonly string True;
        public static readonly string Undefined;
        public static System.Func<Newtonsoft.Json.JsonSerializerSettings> DefaultSettings { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject) { throw null; }
        public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static object DeserializeObject(string value) { throw null; }
        public static object DeserializeObject(string value, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static object DeserializeObject(string value, System.Type type) { throw null; }
        public static object DeserializeObject(string value, System.Type type, params Newtonsoft.Json.JsonConverter[] converters) { throw null; }
        public static object DeserializeObject(string value, System.Type type, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        [System.ObsoleteAttribute("DeserializeObjectAsync is obsolete. Use the Task.Factory.StartNew method to deserialize JSON asynchronously: Task.Factory.StartNew(() => JsonConvert.DeserializeObject(value))")]
        public static System.Threading.Tasks.Task<object> DeserializeObjectAsync(string value) { throw null; }
        [System.ObsoleteAttribute("DeserializeObjectAsync is obsolete. Use the Task.Factory.StartNew method to deserialize JSON asynchronously: Task.Factory.StartNew(() => JsonConvert.DeserializeObject(value, type, settings))")]
        public static System.Threading.Tasks.Task<object> DeserializeObjectAsync(string value, System.Type type, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        [System.ObsoleteAttribute("DeserializeObjectAsync is obsolete. Use the Task.Factory.StartNew method to deserialize JSON asynchronously: Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(value))")]
        public static System.Threading.Tasks.Task<T> DeserializeObjectAsync<T>(string value) { throw null; }
        [System.ObsoleteAttribute("DeserializeObjectAsync is obsolete. Use the Task.Factory.StartNew method to deserialize JSON asynchronously: Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(value, settings))")]
        public static System.Threading.Tasks.Task<T> DeserializeObjectAsync<T>(string value, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static T DeserializeObject<T>(string value) { throw null; }
        public static T DeserializeObject<T>(string value, params Newtonsoft.Json.JsonConverter[] converters) { throw null; }
        public static T DeserializeObject<T>(string value, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static System.Xml.Linq.XDocument DeserializeXNode(string value) { throw null; }
        public static System.Xml.Linq.XDocument DeserializeXNode(string value, string deserializeRootElementName) { throw null; }
        public static System.Xml.Linq.XDocument DeserializeXNode(string value, string deserializeRootElementName, bool writeArrayAttribute) { throw null; }
        public static void PopulateObject(string value, object target) { }
        public static void PopulateObject(string value, object target, Newtonsoft.Json.JsonSerializerSettings settings) { }
        [System.ObsoleteAttribute("PopulateObjectAsync is obsolete. Use the Task.Factory.StartNew method to populate an object with JSON values asynchronously: Task.Factory.StartNew(() => JsonConvert.PopulateObject(value, target, settings))")]
        public static System.Threading.Tasks.Task PopulateObjectAsync(string value, object target, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static string SerializeObject(object value) { throw null; }
        public static string SerializeObject(object value, Newtonsoft.Json.Formatting formatting) { throw null; }
        public static string SerializeObject(object value, Newtonsoft.Json.Formatting formatting, params Newtonsoft.Json.JsonConverter[] converters) { throw null; }
        public static string SerializeObject(object value, Newtonsoft.Json.Formatting formatting, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static string SerializeObject(object value, params Newtonsoft.Json.JsonConverter[] converters) { throw null; }
        public static string SerializeObject(object value, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static string SerializeObject(object value, System.Type type, Newtonsoft.Json.Formatting formatting, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static string SerializeObject(object value, System.Type type, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        [System.ObsoleteAttribute("SerializeObjectAsync is obsolete. Use the Task.Factory.StartNew method to serialize JSON asynchronously: Task.Factory.StartNew(() => JsonConvert.SerializeObject(value))")]
        public static System.Threading.Tasks.Task<string> SerializeObjectAsync(object value) { throw null; }
        [System.ObsoleteAttribute("SerializeObjectAsync is obsolete. Use the Task.Factory.StartNew method to serialize JSON asynchronously: Task.Factory.StartNew(() => JsonConvert.SerializeObject(value, formatting))")]
        public static System.Threading.Tasks.Task<string> SerializeObjectAsync(object value, Newtonsoft.Json.Formatting formatting) { throw null; }
        [System.ObsoleteAttribute("SerializeObjectAsync is obsolete. Use the Task.Factory.StartNew method to serialize JSON asynchronously: Task.Factory.StartNew(() => JsonConvert.SerializeObject(value, formatting, settings))")]
        public static System.Threading.Tasks.Task<string> SerializeObjectAsync(object value, Newtonsoft.Json.Formatting formatting, Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static string SerializeXNode(System.Xml.Linq.XObject node) { throw null; }
        public static string SerializeXNode(System.Xml.Linq.XObject node, Newtonsoft.Json.Formatting formatting) { throw null; }
        public static string SerializeXNode(System.Xml.Linq.XObject node, Newtonsoft.Json.Formatting formatting, bool omitRootObject) { throw null; }
        public static string ToString(bool value) { throw null; }
        public static string ToString(byte value) { throw null; }
        public static string ToString(char value) { throw null; }
        public static string ToString(System.DateTime value) { throw null; }
        public static string ToString(System.DateTime value, Newtonsoft.Json.DateFormatHandling format, Newtonsoft.Json.DateTimeZoneHandling timeZoneHandling) { throw null; }
        public static string ToString(System.DateTimeOffset value) { throw null; }
        public static string ToString(System.DateTimeOffset value, Newtonsoft.Json.DateFormatHandling format) { throw null; }
        public static string ToString(decimal value) { throw null; }
        public static string ToString(double value) { throw null; }
        public static string ToString(System.Enum value) { throw null; }
        public static string ToString(System.Guid value) { throw null; }
        public static string ToString(short value) { throw null; }
        public static string ToString(int value) { throw null; }
        public static string ToString(long value) { throw null; }
        public static string ToString(object value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static string ToString(sbyte value) { throw null; }
        public static string ToString(float value) { throw null; }
        public static string ToString(string value) { throw null; }
        public static string ToString(string value, char delimiter) { throw null; }
        public static string ToString(string value, char delimiter, Newtonsoft.Json.StringEscapeHandling stringEscapeHandling) { throw null; }
        public static string ToString(System.TimeSpan value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static string ToString(ushort value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static string ToString(uint value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static string ToString(ulong value) { throw null; }
        public static string ToString(System.Uri value) { throw null; }
    }
    public abstract partial class JsonConverter
    {
        protected JsonConverter() { }
        public virtual bool CanRead { get { throw null; } }
        public virtual bool CanWrite { get { throw null; } }
        public abstract bool CanConvert(System.Type objectType);
        [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. It is strongly recommended that you do not override GetSchema() in your own converter. It is not used by Json.NET and will be removed at some point in the future. Converter's that override GetSchema() will stop working when it is removed.")]
        public virtual Newtonsoft.Json.Schema.JsonSchema GetSchema() { throw null; }
        public abstract object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer);
        public abstract void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer);
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(3484), AllowMultiple=false)]
    public sealed partial class JsonConverterAttribute : System.Attribute
    {
        public JsonConverterAttribute(System.Type converterType) { }
        public JsonConverterAttribute(System.Type converterType, params object[] converterParameters) { }
        public object[] ConverterParameters { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Type ConverterType { get { throw null; } }
    }
    public partial class JsonConverterCollection : System.Collections.ObjectModel.Collection<Newtonsoft.Json.JsonConverter>
    {
        public JsonConverterCollection() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1028), AllowMultiple=false)]
    public sealed partial class JsonDictionaryAttribute : Newtonsoft.Json.JsonContainerAttribute
    {
        public JsonDictionaryAttribute() { }
        public JsonDictionaryAttribute(string id) { }
    }
    public partial class JsonException : System.Exception
    {
        public JsonException() { }
        public JsonException(string message) { }
        public JsonException(string message, System.Exception innerException) { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false)]
    public partial class JsonExtensionDataAttribute : System.Attribute
    {
        public JsonExtensionDataAttribute() { }
        public bool ReadData { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool WriteData { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false)]
    public sealed partial class JsonIgnoreAttribute : System.Attribute
    {
        public JsonIgnoreAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1036), AllowMultiple=false)]
    public sealed partial class JsonObjectAttribute : Newtonsoft.Json.JsonContainerAttribute
    {
        public JsonObjectAttribute() { }
        public JsonObjectAttribute(Newtonsoft.Json.MemberSerialization memberSerialization) { }
        public JsonObjectAttribute(string id) { }
        public Newtonsoft.Json.Required ItemRequired { get { throw null; } set { } }
        public Newtonsoft.Json.MemberSerialization MemberSerialization { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2432), AllowMultiple=false)]
    public sealed partial class JsonPropertyAttribute : System.Attribute
    {
        public JsonPropertyAttribute() { }
        public JsonPropertyAttribute(string propertyName) { }
        public Newtonsoft.Json.DefaultValueHandling DefaultValueHandling { get { throw null; } set { } }
        public bool IsReference { get { throw null; } set { } }
        public object[] ItemConverterParameters { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Type ItemConverterType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool ItemIsReference { get { throw null; } set { } }
        public Newtonsoft.Json.ReferenceLoopHandling ItemReferenceLoopHandling { get { throw null; } set { } }
        public Newtonsoft.Json.TypeNameHandling ItemTypeNameHandling { get { throw null; } set { } }
        public object[] NamingStrategyParameters { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Type NamingStrategyType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.NullValueHandling NullValueHandling { get { throw null; } set { } }
        public Newtonsoft.Json.ObjectCreationHandling ObjectCreationHandling { get { throw null; } set { } }
        public int Order { get { throw null; } set { } }
        public string PropertyName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.ReferenceLoopHandling ReferenceLoopHandling { get { throw null; } set { } }
        public Newtonsoft.Json.Required Required { get { throw null; } set { } }
        public Newtonsoft.Json.TypeNameHandling TypeNameHandling { get { throw null; } set { } }
    }
    public abstract partial class JsonReader : System.IDisposable
    {
        protected JsonReader() { }
        public bool CloseInput { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        protected Newtonsoft.Json.JsonReader.State CurrentState { get { throw null; } }
        public string DateFormatString { get { throw null; } set { } }
        public Newtonsoft.Json.DateParseHandling DateParseHandling { get { throw null; } set { } }
        public Newtonsoft.Json.DateTimeZoneHandling DateTimeZoneHandling { get { throw null; } set { } }
        public virtual int Depth { get { throw null; } }
        public Newtonsoft.Json.FloatParseHandling FloatParseHandling { get { throw null; } set { } }
        public System.Nullable<int> MaxDepth { get { throw null; } set { } }
        public virtual string Path { get { throw null; } }
        public virtual char QuoteChar { get { throw null; } protected internal set { } }
        public bool SupportMultipleContent { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public virtual Newtonsoft.Json.JsonToken TokenType { get { throw null; } }
        public virtual object Value { get { throw null; } }
        public virtual System.Type ValueType { get { throw null; } }
        public virtual void Close() { }
        protected virtual void Dispose(bool disposing) { }
        public abstract bool Read();
        public virtual System.Nullable<bool> ReadAsBoolean() { throw null; }
        public virtual byte[] ReadAsBytes() { throw null; }
        public virtual System.Nullable<System.DateTime> ReadAsDateTime() { throw null; }
        public virtual System.Nullable<System.DateTimeOffset> ReadAsDateTimeOffset() { throw null; }
        public virtual System.Nullable<decimal> ReadAsDecimal() { throw null; }
        public virtual System.Nullable<double> ReadAsDouble() { throw null; }
        public virtual System.Nullable<int> ReadAsInt32() { throw null; }
        public virtual string ReadAsString() { throw null; }
        protected void SetStateBasedOnCurrent() { }
        protected void SetToken(Newtonsoft.Json.JsonToken newToken) { }
        protected void SetToken(Newtonsoft.Json.JsonToken newToken, object value) { }
        public void Skip() { }
        void System.IDisposable.Dispose() { }
        protected internal enum State
        {
            Array = 6,
            ArrayStart = 5,
            Closed = 7,
            Complete = 1,
            Constructor = 10,
            ConstructorStart = 9,
            Error = 11,
            Finished = 12,
            Object = 4,
            ObjectStart = 3,
            PostValue = 8,
            Property = 2,
            Start = 0,
        }
    }
    public partial class JsonReaderException : Newtonsoft.Json.JsonException
    {
        public JsonReaderException() { }
        public JsonReaderException(string message) { }
        public JsonReaderException(string message, System.Exception innerException) { }
        public int LineNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public int LinePosition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false)]
    public sealed partial class JsonRequiredAttribute : System.Attribute
    {
        public JsonRequiredAttribute() { }
    }
    public partial class JsonSerializationException : Newtonsoft.Json.JsonException
    {
        public JsonSerializationException() { }
        public JsonSerializationException(string message) { }
        public JsonSerializationException(string message, System.Exception innerException) { }
    }
    public partial class JsonSerializer
    {
        public JsonSerializer() { }
        public virtual Newtonsoft.Json.SerializationBinder Binder { get { throw null; } set { } }
        public virtual bool CheckAdditionalContent { get { throw null; } set { } }
        public virtual Newtonsoft.Json.ConstructorHandling ConstructorHandling { get { throw null; } set { } }
        public virtual System.Runtime.Serialization.StreamingContext Context { get { throw null; } set { } }
        public virtual Newtonsoft.Json.Serialization.IContractResolver ContractResolver { get { throw null; } set { } }
        public virtual Newtonsoft.Json.JsonConverterCollection Converters { get { throw null; } }
        public virtual System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public virtual Newtonsoft.Json.DateFormatHandling DateFormatHandling { get { throw null; } set { } }
        public virtual string DateFormatString { get { throw null; } set { } }
        public virtual Newtonsoft.Json.DateParseHandling DateParseHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.DateTimeZoneHandling DateTimeZoneHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.DefaultValueHandling DefaultValueHandling { get { throw null; } set { } }
        public virtual System.Collections.IEqualityComparer EqualityComparer { get { throw null; } set { } }
        public virtual Newtonsoft.Json.FloatFormatHandling FloatFormatHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.FloatParseHandling FloatParseHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.Formatting Formatting { get { throw null; } set { } }
        public virtual System.Nullable<int> MaxDepth { get { throw null; } set { } }
        public virtual Newtonsoft.Json.MetadataPropertyHandling MetadataPropertyHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.MissingMemberHandling MissingMemberHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.NullValueHandling NullValueHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.ObjectCreationHandling ObjectCreationHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.PreserveReferencesHandling PreserveReferencesHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.ReferenceLoopHandling ReferenceLoopHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.Serialization.IReferenceResolver ReferenceResolver { get { throw null; } set { } }
        public virtual Newtonsoft.Json.StringEscapeHandling StringEscapeHandling { get { throw null; } set { } }
        public virtual Newtonsoft.Json.Serialization.ITraceWriter TraceWriter { get { throw null; } set { } }
        public virtual System.Runtime.Serialization.Formatters.FormatterAssemblyStyle TypeNameAssemblyFormat { get { throw null; } set { } }
        public virtual Newtonsoft.Json.TypeNameHandling TypeNameHandling { get { throw null; } set { } }
        public virtual event System.EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs> Error { add { } remove { } }
        public static Newtonsoft.Json.JsonSerializer Create() { throw null; }
        public static Newtonsoft.Json.JsonSerializer Create(Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public static Newtonsoft.Json.JsonSerializer CreateDefault() { throw null; }
        public static Newtonsoft.Json.JsonSerializer CreateDefault(Newtonsoft.Json.JsonSerializerSettings settings) { throw null; }
        public object Deserialize(Newtonsoft.Json.JsonReader reader) { throw null; }
        public object Deserialize(Newtonsoft.Json.JsonReader reader, System.Type objectType) { throw null; }
        public object Deserialize(System.IO.TextReader reader, System.Type objectType) { throw null; }
        public T Deserialize<T>(Newtonsoft.Json.JsonReader reader) { throw null; }
        public void Populate(Newtonsoft.Json.JsonReader reader, object target) { }
        public void Populate(System.IO.TextReader reader, object target) { }
        public void Serialize(Newtonsoft.Json.JsonWriter jsonWriter, object value) { }
        public void Serialize(Newtonsoft.Json.JsonWriter jsonWriter, object value, System.Type objectType) { }
        public void Serialize(System.IO.TextWriter textWriter, object value) { }
        public void Serialize(System.IO.TextWriter textWriter, object value, System.Type objectType) { }
    }
    public partial class JsonSerializerSettings
    {
        public JsonSerializerSettings() { }
        public Newtonsoft.Json.SerializationBinder Binder { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool CheckAdditionalContent { get { throw null; } set { } }
        public Newtonsoft.Json.ConstructorHandling ConstructorHandling { get { throw null; } set { } }
        public System.Runtime.Serialization.StreamingContext Context { get { throw null; } set { } }
        public Newtonsoft.Json.Serialization.IContractResolver ContractResolver { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<Newtonsoft.Json.JsonConverter> Converters { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public Newtonsoft.Json.DateFormatHandling DateFormatHandling { get { throw null; } set { } }
        public string DateFormatString { get { throw null; } set { } }
        public Newtonsoft.Json.DateParseHandling DateParseHandling { get { throw null; } set { } }
        public Newtonsoft.Json.DateTimeZoneHandling DateTimeZoneHandling { get { throw null; } set { } }
        public Newtonsoft.Json.DefaultValueHandling DefaultValueHandling { get { throw null; } set { } }
        public System.Collections.IEqualityComparer EqualityComparer { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs> Error { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.FloatFormatHandling FloatFormatHandling { get { throw null; } set { } }
        public Newtonsoft.Json.FloatParseHandling FloatParseHandling { get { throw null; } set { } }
        public Newtonsoft.Json.Formatting Formatting { get { throw null; } set { } }
        public System.Nullable<int> MaxDepth { get { throw null; } set { } }
        public Newtonsoft.Json.MetadataPropertyHandling MetadataPropertyHandling { get { throw null; } set { } }
        public Newtonsoft.Json.MissingMemberHandling MissingMemberHandling { get { throw null; } set { } }
        public Newtonsoft.Json.NullValueHandling NullValueHandling { get { throw null; } set { } }
        public Newtonsoft.Json.ObjectCreationHandling ObjectCreationHandling { get { throw null; } set { } }
        public Newtonsoft.Json.PreserveReferencesHandling PreserveReferencesHandling { get { throw null; } set { } }
        public Newtonsoft.Json.ReferenceLoopHandling ReferenceLoopHandling { get { throw null; } set { } }
        [System.ObsoleteAttribute("ReferenceResolver property is obsolete. Use the ReferenceResolverProvider property to set the IReferenceResolver: settings.ReferenceResolverProvider = () => resolver")]
        public Newtonsoft.Json.Serialization.IReferenceResolver ReferenceResolver { get { throw null; } set { } }
        public System.Func<Newtonsoft.Json.Serialization.IReferenceResolver> ReferenceResolverProvider { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.StringEscapeHandling StringEscapeHandling { get { throw null; } set { } }
        public Newtonsoft.Json.Serialization.ITraceWriter TraceWriter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Runtime.Serialization.Formatters.FormatterAssemblyStyle TypeNameAssemblyFormat { get { throw null; } set { } }
        public Newtonsoft.Json.TypeNameHandling TypeNameHandling { get { throw null; } set { } }
    }
    public partial class JsonTextReader : Newtonsoft.Json.JsonReader, Newtonsoft.Json.IJsonLineInfo
    {
        public JsonTextReader(System.IO.TextReader reader) { }
        public Newtonsoft.Json.IArrayPool<char> ArrayPool { get { throw null; } set { } }
        public int LineNumber { get { throw null; } }
        public int LinePosition { get { throw null; } }
        public override void Close() { }
        public bool HasLineInfo() { throw null; }
        public override bool Read() { throw null; }
        public override System.Nullable<bool> ReadAsBoolean() { throw null; }
        public override byte[] ReadAsBytes() { throw null; }
        public override System.Nullable<System.DateTime> ReadAsDateTime() { throw null; }
        public override System.Nullable<System.DateTimeOffset> ReadAsDateTimeOffset() { throw null; }
        public override System.Nullable<decimal> ReadAsDecimal() { throw null; }
        public override System.Nullable<double> ReadAsDouble() { throw null; }
        public override System.Nullable<int> ReadAsInt32() { throw null; }
        public override string ReadAsString() { throw null; }
    }
    public partial class JsonTextWriter : Newtonsoft.Json.JsonWriter
    {
        public JsonTextWriter(System.IO.TextWriter textWriter) { }
        public Newtonsoft.Json.IArrayPool<char> ArrayPool { get { throw null; } set { } }
        public int Indentation { get { throw null; } set { } }
        public char IndentChar { get { throw null; } set { } }
        public char QuoteChar { get { throw null; } set { } }
        public bool QuoteName { get { throw null; } set { } }
        public override void Close() { }
        public override void Flush() { }
        public override void WriteComment(string text) { }
        protected override void WriteEnd(Newtonsoft.Json.JsonToken token) { }
        protected override void WriteIndent() { }
        protected override void WriteIndentSpace() { }
        public override void WriteNull() { }
        public override void WritePropertyName(string name) { }
        public override void WritePropertyName(string name, bool escape) { }
        public override void WriteRaw(string json) { }
        public override void WriteStartArray() { }
        public override void WriteStartConstructor(string name) { }
        public override void WriteStartObject() { }
        public override void WriteUndefined() { }
        public override void WriteValue(bool value) { }
        public override void WriteValue(byte value) { }
        public override void WriteValue(byte[] value) { }
        public override void WriteValue(char value) { }
        public override void WriteValue(System.DateTime value) { }
        public override void WriteValue(System.DateTimeOffset value) { }
        public override void WriteValue(decimal value) { }
        public override void WriteValue(double value) { }
        public override void WriteValue(System.Guid value) { }
        public override void WriteValue(short value) { }
        public override void WriteValue(int value) { }
        public override void WriteValue(long value) { }
        public override void WriteValue(System.Nullable<double> value) { }
        public override void WriteValue(System.Nullable<float> value) { }
        public override void WriteValue(object value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(sbyte value) { }
        public override void WriteValue(float value) { }
        public override void WriteValue(string value) { }
        public override void WriteValue(System.TimeSpan value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(ushort value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(uint value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(ulong value) { }
        public override void WriteValue(System.Uri value) { }
        protected override void WriteValueDelimiter() { }
        public override void WriteWhitespace(string ws) { }
    }
    public enum JsonToken
    {
        Boolean = 10,
        Bytes = 17,
        Comment = 5,
        Date = 16,
        EndArray = 14,
        EndConstructor = 15,
        EndObject = 13,
        Float = 8,
        Integer = 7,
        None = 0,
        Null = 11,
        PropertyName = 4,
        Raw = 6,
        StartArray = 2,
        StartConstructor = 3,
        StartObject = 1,
        String = 9,
        Undefined = 12,
    }
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public partial class JsonValidatingReader : Newtonsoft.Json.JsonReader, Newtonsoft.Json.IJsonLineInfo
    {
        public JsonValidatingReader(Newtonsoft.Json.JsonReader reader) { }
        public override int Depth { get { throw null; } }
        int Newtonsoft.Json.IJsonLineInfo.LineNumber { get { throw null; } }
        int Newtonsoft.Json.IJsonLineInfo.LinePosition { get { throw null; } }
        public override string Path { get { throw null; } }
        public override char QuoteChar { get { throw null; } protected internal set { } }
        public Newtonsoft.Json.JsonReader Reader { get { throw null; } }
        public Newtonsoft.Json.Schema.JsonSchema Schema { get { throw null; } set { } }
        public override Newtonsoft.Json.JsonToken TokenType { get { throw null; } }
        public override object Value { get { throw null; } }
        public override System.Type ValueType { get { throw null; } }
        public event Newtonsoft.Json.Schema.ValidationEventHandler ValidationEventHandler { add { } remove { } }
        bool Newtonsoft.Json.IJsonLineInfo.HasLineInfo() { throw null; }
        public override bool Read() { throw null; }
        public override System.Nullable<bool> ReadAsBoolean() { throw null; }
        public override byte[] ReadAsBytes() { throw null; }
        public override System.Nullable<System.DateTime> ReadAsDateTime() { throw null; }
        public override System.Nullable<System.DateTimeOffset> ReadAsDateTimeOffset() { throw null; }
        public override System.Nullable<decimal> ReadAsDecimal() { throw null; }
        public override System.Nullable<double> ReadAsDouble() { throw null; }
        public override System.Nullable<int> ReadAsInt32() { throw null; }
        public override string ReadAsString() { throw null; }
    }
    public abstract partial class JsonWriter : System.IDisposable
    {
        protected JsonWriter() { }
        public bool CloseOutput { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public Newtonsoft.Json.DateFormatHandling DateFormatHandling { get { throw null; } set { } }
        public string DateFormatString { get { throw null; } set { } }
        public Newtonsoft.Json.DateTimeZoneHandling DateTimeZoneHandling { get { throw null; } set { } }
        public Newtonsoft.Json.FloatFormatHandling FloatFormatHandling { get { throw null; } set { } }
        public Newtonsoft.Json.Formatting Formatting { get { throw null; } set { } }
        public string Path { get { throw null; } }
        public Newtonsoft.Json.StringEscapeHandling StringEscapeHandling { get { throw null; } set { } }
        protected internal int Top { get { throw null; } }
        public Newtonsoft.Json.WriteState WriteState { get { throw null; } }
        public virtual void Close() { }
        protected virtual void Dispose(bool disposing) { }
        public abstract void Flush();
        protected void SetWriteState(Newtonsoft.Json.JsonToken token, object value) { }
        void System.IDisposable.Dispose() { }
        public virtual void WriteComment(string text) { }
        public virtual void WriteEnd() { }
        protected virtual void WriteEnd(Newtonsoft.Json.JsonToken token) { }
        public virtual void WriteEndArray() { }
        public virtual void WriteEndConstructor() { }
        public virtual void WriteEndObject() { }
        protected virtual void WriteIndent() { }
        protected virtual void WriteIndentSpace() { }
        public virtual void WriteNull() { }
        public virtual void WritePropertyName(string name) { }
        public virtual void WritePropertyName(string name, bool escape) { }
        public virtual void WriteRaw(string json) { }
        public virtual void WriteRawValue(string json) { }
        public virtual void WriteStartArray() { }
        public virtual void WriteStartConstructor(string name) { }
        public virtual void WriteStartObject() { }
        public void WriteToken(Newtonsoft.Json.JsonReader reader) { }
        public void WriteToken(Newtonsoft.Json.JsonReader reader, bool writeChildren) { }
        public void WriteToken(Newtonsoft.Json.JsonToken token) { }
        public void WriteToken(Newtonsoft.Json.JsonToken token, object value) { }
        public virtual void WriteUndefined() { }
        public virtual void WriteValue(bool value) { }
        public virtual void WriteValue(byte value) { }
        public virtual void WriteValue(byte[] value) { }
        public virtual void WriteValue(char value) { }
        public virtual void WriteValue(System.DateTime value) { }
        public virtual void WriteValue(System.DateTimeOffset value) { }
        public virtual void WriteValue(decimal value) { }
        public virtual void WriteValue(double value) { }
        public virtual void WriteValue(System.Guid value) { }
        public virtual void WriteValue(short value) { }
        public virtual void WriteValue(int value) { }
        public virtual void WriteValue(long value) { }
        public virtual void WriteValue(System.Nullable<bool> value) { }
        public virtual void WriteValue(System.Nullable<byte> value) { }
        public virtual void WriteValue(System.Nullable<char> value) { }
        public virtual void WriteValue(System.Nullable<System.DateTimeOffset> value) { }
        public virtual void WriteValue(System.Nullable<System.DateTime> value) { }
        public virtual void WriteValue(System.Nullable<decimal> value) { }
        public virtual void WriteValue(System.Nullable<double> value) { }
        public virtual void WriteValue(System.Nullable<System.Guid> value) { }
        public virtual void WriteValue(System.Nullable<short> value) { }
        public virtual void WriteValue(System.Nullable<int> value) { }
        public virtual void WriteValue(System.Nullable<long> value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteValue(System.Nullable<sbyte> value) { }
        public virtual void WriteValue(System.Nullable<float> value) { }
        public virtual void WriteValue(System.Nullable<System.TimeSpan> value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteValue(System.Nullable<ushort> value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteValue(System.Nullable<uint> value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteValue(System.Nullable<ulong> value) { }
        public virtual void WriteValue(object value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteValue(sbyte value) { }
        public virtual void WriteValue(float value) { }
        public virtual void WriteValue(string value) { }
        public virtual void WriteValue(System.TimeSpan value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteValue(ushort value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteValue(uint value) { }
        [System.CLSCompliantAttribute(false)]
        public virtual void WriteValue(ulong value) { }
        public virtual void WriteValue(System.Uri value) { }
        protected virtual void WriteValueDelimiter() { }
        public virtual void WriteWhitespace(string ws) { }
    }
    public partial class JsonWriterException : Newtonsoft.Json.JsonException
    {
        public JsonWriterException() { }
        public JsonWriterException(string message) { }
        public JsonWriterException(string message, System.Exception innerException) { }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public enum MemberSerialization
    {
        Fields = 2,
        OptIn = 1,
        OptOut = 0,
    }
    public enum MetadataPropertyHandling
    {
        Default = 0,
        Ignore = 2,
        ReadAhead = 1,
    }
    public enum MissingMemberHandling
    {
        Error = 1,
        Ignore = 0,
    }
    public enum NullValueHandling
    {
        Ignore = 1,
        Include = 0,
    }
    public enum ObjectCreationHandling
    {
        Auto = 0,
        Replace = 2,
        Reuse = 1,
    }
    [System.FlagsAttribute]
    public enum PreserveReferencesHandling
    {
        All = 3,
        Arrays = 2,
        None = 0,
        Objects = 1,
    }
    public enum ReferenceLoopHandling
    {
        Error = 0,
        Ignore = 1,
        Serialize = 2,
    }
    public enum Required
    {
        AllowNull = 1,
        Always = 2,
        Default = 0,
        DisallowNull = 3,
    }
    public abstract partial class SerializationBinder
    {
        protected SerializationBinder() { }
        public virtual void BindToName(System.Type serializedType, out string assemblyName, out string typeName) { assemblyName = default(string); typeName = default(string); }
        public abstract System.Type BindToType(string assemblyName, string typeName);
    }
    public enum StringEscapeHandling
    {
        Default = 0,
        EscapeHtml = 2,
        EscapeNonAscii = 1,
    }
    public enum TraceLevel
    {
        Error = 1,
        Info = 3,
        Off = 0,
        Verbose = 4,
        Warning = 2,
    }
    [System.FlagsAttribute]
    public enum TypeNameHandling
    {
        All = 3,
        Arrays = 2,
        Auto = 4,
        None = 0,
        Objects = 1,
    }
    public enum WriteState
    {
        Array = 3,
        Closed = 1,
        Constructor = 4,
        Error = 0,
        Object = 2,
        Property = 5,
        Start = 6,
    }
}
namespace Newtonsoft.Json.Bson
{
    public partial class BsonObjectId
    {
        public BsonObjectId(byte[] value) { }
        public byte[] Value { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class BsonReader : Newtonsoft.Json.JsonReader
    {
        public BsonReader(System.IO.BinaryReader reader) { }
        public BsonReader(System.IO.BinaryReader reader, bool readRootValueAsArray, System.DateTimeKind dateTimeKindHandling) { }
        public BsonReader(System.IO.Stream stream) { }
        public BsonReader(System.IO.Stream stream, bool readRootValueAsArray, System.DateTimeKind dateTimeKindHandling) { }
        public System.DateTimeKind DateTimeKindHandling { get { throw null; } set { } }
        [System.ObsoleteAttribute("JsonNet35BinaryCompatibility will be removed in a future version of Json.NET.")]
        public bool JsonNet35BinaryCompatibility { get { throw null; } set { } }
        public bool ReadRootValueAsArray { get { throw null; } set { } }
        public override void Close() { }
        public override bool Read() { throw null; }
    }
    public partial class BsonWriter : Newtonsoft.Json.JsonWriter
    {
        public BsonWriter(System.IO.BinaryWriter writer) { }
        public BsonWriter(System.IO.Stream stream) { }
        public System.DateTimeKind DateTimeKindHandling { get { throw null; } set { } }
        public override void Close() { }
        public override void Flush() { }
        public override void WriteComment(string text) { }
        protected override void WriteEnd(Newtonsoft.Json.JsonToken token) { }
        public override void WriteNull() { }
        public void WriteObjectId(byte[] value) { }
        public override void WritePropertyName(string name) { }
        public override void WriteRaw(string json) { }
        public override void WriteRawValue(string json) { }
        public void WriteRegex(string pattern, string options) { }
        public override void WriteStartArray() { }
        public override void WriteStartConstructor(string name) { }
        public override void WriteStartObject() { }
        public override void WriteUndefined() { }
        public override void WriteValue(bool value) { }
        public override void WriteValue(byte value) { }
        public override void WriteValue(byte[] value) { }
        public override void WriteValue(char value) { }
        public override void WriteValue(System.DateTime value) { }
        public override void WriteValue(System.DateTimeOffset value) { }
        public override void WriteValue(decimal value) { }
        public override void WriteValue(double value) { }
        public override void WriteValue(System.Guid value) { }
        public override void WriteValue(short value) { }
        public override void WriteValue(int value) { }
        public override void WriteValue(long value) { }
        public override void WriteValue(object value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(sbyte value) { }
        public override void WriteValue(float value) { }
        public override void WriteValue(string value) { }
        public override void WriteValue(System.TimeSpan value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(ushort value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(uint value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(ulong value) { }
        public override void WriteValue(System.Uri value) { }
    }
}
namespace Newtonsoft.Json.Converters
{
    public partial class BsonObjectIdConverter : Newtonsoft.Json.JsonConverter
    {
        public BsonObjectIdConverter() { }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public abstract partial class CustomCreationConverter<T> : Newtonsoft.Json.JsonConverter
    {
        protected CustomCreationConverter() { }
        public override bool CanWrite { get { throw null; } }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public abstract T Create(System.Type objectType);
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public abstract partial class DateTimeConverterBase : Newtonsoft.Json.JsonConverter
    {
        protected DateTimeConverterBase() { }
        public override bool CanConvert(System.Type objectType) { throw null; }
    }
    public partial class DiscriminatedUnionConverter : Newtonsoft.Json.JsonConverter
    {
        public DiscriminatedUnionConverter() { }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class ExpandoObjectConverter : Newtonsoft.Json.JsonConverter
    {
        public ExpandoObjectConverter() { }
        public override bool CanWrite { get { throw null; } }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class IsoDateTimeConverter : Newtonsoft.Json.Converters.DateTimeConverterBase
    {
        public IsoDateTimeConverter() { }
        public System.Globalization.CultureInfo Culture { get { throw null; } set { } }
        public string DateTimeFormat { get { throw null; } set { } }
        public System.Globalization.DateTimeStyles DateTimeStyles { get { throw null; } set { } }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class JavaScriptDateTimeConverter : Newtonsoft.Json.Converters.DateTimeConverterBase
    {
        public JavaScriptDateTimeConverter() { }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class KeyValuePairConverter : Newtonsoft.Json.JsonConverter
    {
        public KeyValuePairConverter() { }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class RegexConverter : Newtonsoft.Json.JsonConverter
    {
        public RegexConverter() { }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class StringEnumConverter : Newtonsoft.Json.JsonConverter
    {
        public StringEnumConverter() { }
        public StringEnumConverter(bool camelCaseText) { }
        public bool AllowIntegerValues { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool CamelCaseText { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class VersionConverter : Newtonsoft.Json.JsonConverter
    {
        public VersionConverter() { }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class XmlNodeConverter : Newtonsoft.Json.JsonConverter
    {
        public XmlNodeConverter() { }
        public string DeserializeRootElementName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool OmitRootObject { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool WriteArrayAttribute { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool CanConvert(System.Type valueType) { throw null; }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
}
namespace Newtonsoft.Json.Linq
{
    public enum CommentHandling
    {
        Ignore = 0,
        Load = 1,
    }
    public static partial class Extensions
    {
        public static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> AncestorsAndSelf<T>(this System.Collections.Generic.IEnumerable<T> source) where T : Newtonsoft.Json.Linq.JToken { throw null; }
        public static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Ancestors<T>(this System.Collections.Generic.IEnumerable<T> source) where T : Newtonsoft.Json.Linq.JToken { throw null; }
        public static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> AsJEnumerable(this System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> source) { throw null; }
        public static Newtonsoft.Json.Linq.IJEnumerable<T> AsJEnumerable<T>(this System.Collections.Generic.IEnumerable<T> source) where T : Newtonsoft.Json.Linq.JToken { throw null; }
        public static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Children<T>(this System.Collections.Generic.IEnumerable<T> source) where T : Newtonsoft.Json.Linq.JToken { throw null; }
        public static System.Collections.Generic.IEnumerable<U> Children<T, U>(this System.Collections.Generic.IEnumerable<T> source) where T : Newtonsoft.Json.Linq.JToken { throw null; }
        public static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> DescendantsAndSelf<T>(this System.Collections.Generic.IEnumerable<T> source) where T : Newtonsoft.Json.Linq.JContainer { throw null; }
        public static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Descendants<T>(this System.Collections.Generic.IEnumerable<T> source) where T : Newtonsoft.Json.Linq.JContainer { throw null; }
        public static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JProperty> Properties(this System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JObject> source) { throw null; }
        public static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Values(this System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> source) { throw null; }
        public static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Values(this System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> source, object key) { throw null; }
        public static System.Collections.Generic.IEnumerable<U> Values<U>(this System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> source) { throw null; }
        public static System.Collections.Generic.IEnumerable<U> Values<U>(this System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> source, object key) { throw null; }
        public static U Value<U>(this System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> value) { throw null; }
        public static U Value<T, U>(this System.Collections.Generic.IEnumerable<T> value) where T : Newtonsoft.Json.Linq.JToken { throw null; }
    }
    public partial interface IJEnumerable<out T> : System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable where T : Newtonsoft.Json.Linq.JToken
    {
        Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> this[object key] { get; }
    }
    public partial class JArray : Newtonsoft.Json.Linq.JContainer, System.Collections.Generic.ICollection<Newtonsoft.Json.Linq.JToken>, System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken>, System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>, System.Collections.IEnumerable
    {
        public JArray() { }
        public JArray(Newtonsoft.Json.Linq.JArray other) { }
        public JArray(object content) { }
        public JArray(params object[] content) { }
        protected override System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> ChildrenTokens { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public Newtonsoft.Json.Linq.JToken this[int index] { get { throw null; } set { } }
        public override Newtonsoft.Json.Linq.JToken this[object key] { get { throw null; } set { } }
        public override Newtonsoft.Json.Linq.JTokenType Type { get { throw null; } }
        public void Add(Newtonsoft.Json.Linq.JToken item) { }
        public void Clear() { }
        public bool Contains(Newtonsoft.Json.Linq.JToken item) { throw null; }
        public void CopyTo(Newtonsoft.Json.Linq.JToken[] array, int arrayIndex) { }
        public static new Newtonsoft.Json.Linq.JArray FromObject(object o) { throw null; }
        public static new Newtonsoft.Json.Linq.JArray FromObject(object o, Newtonsoft.Json.JsonSerializer jsonSerializer) { throw null; }
        public System.Collections.Generic.IEnumerator<Newtonsoft.Json.Linq.JToken> GetEnumerator() { throw null; }
        public int IndexOf(Newtonsoft.Json.Linq.JToken item) { throw null; }
        public void Insert(int index, Newtonsoft.Json.Linq.JToken item) { }
        public static new Newtonsoft.Json.Linq.JArray Load(Newtonsoft.Json.JsonReader reader) { throw null; }
        public static new Newtonsoft.Json.Linq.JArray Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings) { throw null; }
        public static new Newtonsoft.Json.Linq.JArray Parse(string json) { throw null; }
        public static new Newtonsoft.Json.Linq.JArray Parse(string json, Newtonsoft.Json.Linq.JsonLoadSettings settings) { throw null; }
        public bool Remove(Newtonsoft.Json.Linq.JToken item) { throw null; }
        public void RemoveAt(int index) { }
        public override void WriteTo(Newtonsoft.Json.JsonWriter writer, params Newtonsoft.Json.JsonConverter[] converters) { }
    }
    public partial class JConstructor : Newtonsoft.Json.Linq.JContainer
    {
        public JConstructor() { }
        public JConstructor(Newtonsoft.Json.Linq.JConstructor other) { }
        public JConstructor(string name) { }
        public JConstructor(string name, object content) { }
        public JConstructor(string name, params object[] content) { }
        protected override System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> ChildrenTokens { get { throw null; } }
        public override Newtonsoft.Json.Linq.JToken this[object key] { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public override Newtonsoft.Json.Linq.JTokenType Type { get { throw null; } }
        public static new Newtonsoft.Json.Linq.JConstructor Load(Newtonsoft.Json.JsonReader reader) { throw null; }
        public static new Newtonsoft.Json.Linq.JConstructor Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings) { throw null; }
        public override void WriteTo(Newtonsoft.Json.JsonWriter writer, params Newtonsoft.Json.JsonConverter[] converters) { }
    }
    public abstract partial class JContainer : Newtonsoft.Json.Linq.JToken, System.Collections.Generic.ICollection<Newtonsoft.Json.Linq.JToken>, System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken>, System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList, System.Collections.Specialized.INotifyCollectionChanged
    {
        internal JContainer() { }
        protected abstract System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> ChildrenTokens { get; }
        public int Count { get { throw null; } }
        public override Newtonsoft.Json.Linq.JToken First { get { throw null; } }
        public override bool HasValues { get { throw null; } }
        public override Newtonsoft.Json.Linq.JToken Last { get { throw null; } }
        bool System.Collections.Generic.ICollection<Newtonsoft.Json.Linq.JToken>.IsReadOnly { get { throw null; } }
        Newtonsoft.Json.Linq.JToken System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>.this[int index] { get { throw null; } set { } }
        bool System.Collections.ICollection.IsSynchronized { get { throw null; } }
        object System.Collections.ICollection.SyncRoot { get { throw null; } }
        bool System.Collections.IList.IsFixedSize { get { throw null; } }
        bool System.Collections.IList.IsReadOnly { get { throw null; } }
        object System.Collections.IList.this[int index] { get { throw null; } set { } }
        public event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged { add { } remove { } }
        public virtual void Add(object content) { }
        public void AddFirst(object content) { }
        public override Newtonsoft.Json.Linq.JEnumerable<Newtonsoft.Json.Linq.JToken> Children() { throw null; }
        public Newtonsoft.Json.JsonWriter CreateWriter() { throw null; }
        public System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> Descendants() { throw null; }
        public System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> DescendantsAndSelf() { throw null; }
        public void Merge(object content) { }
        public void Merge(object content, Newtonsoft.Json.Linq.JsonMergeSettings settings) { }
        protected virtual void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e) { }
        public void RemoveAll() { }
        public void ReplaceAll(object content) { }
        void System.Collections.Generic.ICollection<Newtonsoft.Json.Linq.JToken>.Add(Newtonsoft.Json.Linq.JToken item) { }
        void System.Collections.Generic.ICollection<Newtonsoft.Json.Linq.JToken>.Clear() { }
        bool System.Collections.Generic.ICollection<Newtonsoft.Json.Linq.JToken>.Contains(Newtonsoft.Json.Linq.JToken item) { throw null; }
        void System.Collections.Generic.ICollection<Newtonsoft.Json.Linq.JToken>.CopyTo(Newtonsoft.Json.Linq.JToken[] array, int arrayIndex) { }
        bool System.Collections.Generic.ICollection<Newtonsoft.Json.Linq.JToken>.Remove(Newtonsoft.Json.Linq.JToken item) { throw null; }
        int System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>.IndexOf(Newtonsoft.Json.Linq.JToken item) { throw null; }
        void System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>.Insert(int index, Newtonsoft.Json.Linq.JToken item) { }
        void System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>.RemoveAt(int index) { }
        void System.Collections.ICollection.CopyTo(System.Array array, int index) { }
        int System.Collections.IList.Add(object value) { throw null; }
        void System.Collections.IList.Clear() { }
        bool System.Collections.IList.Contains(object value) { throw null; }
        int System.Collections.IList.IndexOf(object value) { throw null; }
        void System.Collections.IList.Insert(int index, object value) { }
        void System.Collections.IList.Remove(object value) { }
        void System.Collections.IList.RemoveAt(int index) { }
        public override System.Collections.Generic.IEnumerable<T> Values<T>() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct JEnumerable<T> : Newtonsoft.Json.Linq.IJEnumerable<T>, System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable, System.IEquatable<Newtonsoft.Json.Linq.JEnumerable<T>> where T : Newtonsoft.Json.Linq.JToken
    {
        public static readonly Newtonsoft.Json.Linq.JEnumerable<T> Empty;
        public JEnumerable(System.Collections.Generic.IEnumerable<T> enumerable) { throw null;}
        public Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> this[object key] { get { throw null; } }
        public bool Equals(Newtonsoft.Json.Linq.JEnumerable<T> other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator() { throw null; }
        public override int GetHashCode() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JObject : Newtonsoft.Json.Linq.JContainer, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>>, System.Collections.Generic.IDictionary<string, Newtonsoft.Json.Linq.JToken>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>>, System.Collections.IEnumerable, System.ComponentModel.INotifyPropertyChanged
    {
        public JObject() { }
        public JObject(Newtonsoft.Json.Linq.JObject other) { }
        public JObject(object content) { }
        public JObject(params object[] content) { }
        protected override System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> ChildrenTokens { get { throw null; } }
        public override Newtonsoft.Json.Linq.JToken this[object key] { get { throw null; } set { } }
        public Newtonsoft.Json.Linq.JToken this[string propertyName] { get { throw null; } set { } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,Newtonsoft.Json.Linq.JToken>>.IsReadOnly { get { throw null; } }
        System.Collections.Generic.ICollection<string> System.Collections.Generic.IDictionary<System.String,Newtonsoft.Json.Linq.JToken>.Keys { get { throw null; } }
        System.Collections.Generic.ICollection<Newtonsoft.Json.Linq.JToken> System.Collections.Generic.IDictionary<System.String,Newtonsoft.Json.Linq.JToken>.Values { get { throw null; } }
        public override Newtonsoft.Json.Linq.JTokenType Type { get { throw null; } }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged { add { } remove { } }
        public void Add(string propertyName, Newtonsoft.Json.Linq.JToken value) { }
        public static new Newtonsoft.Json.Linq.JObject FromObject(object o) { throw null; }
        public static new Newtonsoft.Json.Linq.JObject FromObject(object o, Newtonsoft.Json.JsonSerializer jsonSerializer) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>> GetEnumerator() { throw null; }
        protected override System.Dynamic.DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public Newtonsoft.Json.Linq.JToken GetValue(string propertyName) { throw null; }
        public Newtonsoft.Json.Linq.JToken GetValue(string propertyName, System.StringComparison comparison) { throw null; }
        public static new Newtonsoft.Json.Linq.JObject Load(Newtonsoft.Json.JsonReader reader) { throw null; }
        public static new Newtonsoft.Json.Linq.JObject Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings) { throw null; }
        protected virtual void OnPropertyChanged(string propertyName) { }
        public static new Newtonsoft.Json.Linq.JObject Parse(string json) { throw null; }
        public static new Newtonsoft.Json.Linq.JObject Parse(string json, Newtonsoft.Json.Linq.JsonLoadSettings settings) { throw null; }
        public System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JProperty> Properties() { throw null; }
        public Newtonsoft.Json.Linq.JProperty Property(string name) { throw null; }
        public Newtonsoft.Json.Linq.JEnumerable<Newtonsoft.Json.Linq.JToken> PropertyValues() { throw null; }
        public bool Remove(string propertyName) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,Newtonsoft.Json.Linq.JToken>>.Add(System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken> item) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,Newtonsoft.Json.Linq.JToken>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,Newtonsoft.Json.Linq.JToken>>.Contains(System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken> item) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,Newtonsoft.Json.Linq.JToken>>.CopyTo(System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>[] array, int arrayIndex) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,Newtonsoft.Json.Linq.JToken>>.Remove(System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken> item) { throw null; }
        bool System.Collections.Generic.IDictionary<System.String,Newtonsoft.Json.Linq.JToken>.ContainsKey(string key) { throw null; }
        public bool TryGetValue(string propertyName, out Newtonsoft.Json.Linq.JToken value) { value = default(Newtonsoft.Json.Linq.JToken); throw null; }
        public bool TryGetValue(string propertyName, System.StringComparison comparison, out Newtonsoft.Json.Linq.JToken value) { value = default(Newtonsoft.Json.Linq.JToken); throw null; }
        public override void WriteTo(Newtonsoft.Json.JsonWriter writer, params Newtonsoft.Json.JsonConverter[] converters) { }
    }
    public partial class JProperty : Newtonsoft.Json.Linq.JContainer
    {
        public JProperty(Newtonsoft.Json.Linq.JProperty other) { }
        public JProperty(string name, object content) { }
        public JProperty(string name, params object[] content) { }
        protected override System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> ChildrenTokens { get { throw null; } }
        public string Name { [System.Diagnostics.DebuggerStepThroughAttribute]get { throw null; } }
        public override Newtonsoft.Json.Linq.JTokenType Type { [System.Diagnostics.DebuggerStepThroughAttribute]get { throw null; } }
        public Newtonsoft.Json.Linq.JToken Value { [System.Diagnostics.DebuggerStepThroughAttribute]get { throw null; } set { } }
        public static new Newtonsoft.Json.Linq.JProperty Load(Newtonsoft.Json.JsonReader reader) { throw null; }
        public static new Newtonsoft.Json.Linq.JProperty Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings) { throw null; }
        public override void WriteTo(Newtonsoft.Json.JsonWriter writer, params Newtonsoft.Json.JsonConverter[] converters) { }
    }
    public partial class JRaw : Newtonsoft.Json.Linq.JValue
    {
        public JRaw(Newtonsoft.Json.Linq.JRaw other) : base (default(Newtonsoft.Json.Linq.JValue)) { }
        public JRaw(object rawJson) : base (default(Newtonsoft.Json.Linq.JValue)) { }
        public static Newtonsoft.Json.Linq.JRaw Create(Newtonsoft.Json.JsonReader reader) { throw null; }
    }
    public partial class JsonLoadSettings
    {
        public JsonLoadSettings() { }
        public Newtonsoft.Json.Linq.CommentHandling CommentHandling { get { throw null; } set { } }
        public Newtonsoft.Json.Linq.LineInfoHandling LineInfoHandling { get { throw null; } set { } }
    }
    public partial class JsonMergeSettings
    {
        public JsonMergeSettings() { }
        public Newtonsoft.Json.Linq.MergeArrayHandling MergeArrayHandling { get { throw null; } set { } }
        public Newtonsoft.Json.Linq.MergeNullValueHandling MergeNullValueHandling { get { throw null; } set { } }
    }
    public abstract partial class JToken : Newtonsoft.Json.IJsonLineInfo, Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken>, System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken>, System.Collections.IEnumerable, System.Dynamic.IDynamicMetaObjectProvider
    {
        internal JToken() { }
        public static Newtonsoft.Json.Linq.JTokenEqualityComparer EqualityComparer { get { throw null; } }
        public virtual Newtonsoft.Json.Linq.JToken First { get { throw null; } }
        public abstract bool HasValues { get; }
        public virtual Newtonsoft.Json.Linq.JToken this[object key] { get { throw null; } set { } }
        public virtual Newtonsoft.Json.Linq.JToken Last { get { throw null; } }
        int Newtonsoft.Json.IJsonLineInfo.LineNumber { get { throw null; } }
        int Newtonsoft.Json.IJsonLineInfo.LinePosition { get { throw null; } }
        Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken>.this[object key] { get { throw null; } }
        public Newtonsoft.Json.Linq.JToken Next { get { throw null; } }
        public Newtonsoft.Json.Linq.JContainer Parent { [System.Diagnostics.DebuggerStepThroughAttribute]get { throw null; } }
        public string Path { get { throw null; } }
        public Newtonsoft.Json.Linq.JToken Previous { get { throw null; } }
        public Newtonsoft.Json.Linq.JToken Root { get { throw null; } }
        public abstract Newtonsoft.Json.Linq.JTokenType Type { get; }
        public void AddAfterSelf(object content) { }
        public void AddAnnotation(object annotation) { }
        public void AddBeforeSelf(object content) { }
        public System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> AfterSelf() { throw null; }
        public System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> Ancestors() { throw null; }
        public System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> AncestorsAndSelf() { throw null; }
        public object Annotation(System.Type type) { throw null; }
        public System.Collections.Generic.IEnumerable<object> Annotations(System.Type type) { throw null; }
        public System.Collections.Generic.IEnumerable<T> Annotations<T>() where T : class { throw null; }
        public T Annotation<T>() where T : class { throw null; }
        public System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> BeforeSelf() { throw null; }
        public virtual Newtonsoft.Json.Linq.JEnumerable<Newtonsoft.Json.Linq.JToken> Children() { throw null; }
        public Newtonsoft.Json.Linq.JEnumerable<T> Children<T>() where T : Newtonsoft.Json.Linq.JToken { throw null; }
        public Newtonsoft.Json.JsonReader CreateReader() { throw null; }
        public Newtonsoft.Json.Linq.JToken DeepClone() { throw null; }
        public static bool DeepEquals(Newtonsoft.Json.Linq.JToken t1, Newtonsoft.Json.Linq.JToken t2) { throw null; }
        public static Newtonsoft.Json.Linq.JToken FromObject(object o) { throw null; }
        public static Newtonsoft.Json.Linq.JToken FromObject(object o, Newtonsoft.Json.JsonSerializer jsonSerializer) { throw null; }
        protected virtual System.Dynamic.DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public static Newtonsoft.Json.Linq.JToken Load(Newtonsoft.Json.JsonReader reader) { throw null; }
        public static Newtonsoft.Json.Linq.JToken Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings) { throw null; }
        bool Newtonsoft.Json.IJsonLineInfo.HasLineInfo() { throw null; }
        public static explicit operator bool (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator byte (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator byte[] (Newtonsoft.Json.Linq.JToken value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static explicit operator char (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.DateTime (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.DateTimeOffset (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator decimal (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator double (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Guid (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator short (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator int (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator long (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<bool> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<byte> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<char> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<System.DateTimeOffset> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<System.DateTime> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<decimal> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<double> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<System.Guid> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<short> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<int> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<long> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static explicit operator System.Nullable<sbyte> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<float> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Nullable<System.TimeSpan> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static explicit operator System.Nullable<ushort> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static explicit operator System.Nullable<uint> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static explicit operator System.Nullable<ulong> (Newtonsoft.Json.Linq.JToken value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static explicit operator sbyte (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator float (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator string (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.TimeSpan (Newtonsoft.Json.Linq.JToken value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static explicit operator ushort (Newtonsoft.Json.Linq.JToken value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static explicit operator uint (Newtonsoft.Json.Linq.JToken value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static explicit operator ulong (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static explicit operator System.Uri (Newtonsoft.Json.Linq.JToken value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (bool value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (byte value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (byte[] value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.DateTime value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.DateTimeOffset value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (decimal value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (double value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Guid value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (short value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (int value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (long value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<bool> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<byte> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<System.DateTimeOffset> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<System.DateTime> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<decimal> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<double> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<System.Guid> value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<short> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<int> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<long> value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<sbyte> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<float> value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<System.TimeSpan> value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<ushort> value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<uint> value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Nullable<ulong> value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (sbyte value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (float value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (string value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.TimeSpan value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (ushort value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (uint value) { throw null; }
        [System.CLSCompliantAttribute(false)]
        public static implicit operator Newtonsoft.Json.Linq.JToken (ulong value) { throw null; }
        public static implicit operator Newtonsoft.Json.Linq.JToken (System.Uri value) { throw null; }
        public static Newtonsoft.Json.Linq.JToken Parse(string json) { throw null; }
        public static Newtonsoft.Json.Linq.JToken Parse(string json, Newtonsoft.Json.Linq.JsonLoadSettings settings) { throw null; }
        public static Newtonsoft.Json.Linq.JToken ReadFrom(Newtonsoft.Json.JsonReader reader) { throw null; }
        public static Newtonsoft.Json.Linq.JToken ReadFrom(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings) { throw null; }
        public void Remove() { }
        public void RemoveAnnotations(System.Type type) { }
        public void RemoveAnnotations<T>() where T : class { }
        public void Replace(Newtonsoft.Json.Linq.JToken value) { }
        public Newtonsoft.Json.Linq.JToken SelectToken(string path) { throw null; }
        public Newtonsoft.Json.Linq.JToken SelectToken(string path, bool errorWhenNoMatch) { throw null; }
        public System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> SelectTokens(string path) { throw null; }
        public System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> SelectTokens(string path, bool errorWhenNoMatch) { throw null; }
        System.Collections.Generic.IEnumerator<Newtonsoft.Json.Linq.JToken> System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public object ToObject(System.Type objectType) { throw null; }
        public object ToObject(System.Type objectType, Newtonsoft.Json.JsonSerializer jsonSerializer) { throw null; }
        public T ToObject<T>() { throw null; }
        public T ToObject<T>(Newtonsoft.Json.JsonSerializer jsonSerializer) { throw null; }
        public override string ToString() { throw null; }
        public string ToString(Newtonsoft.Json.Formatting formatting, params Newtonsoft.Json.JsonConverter[] converters) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<T> Values<T>() { throw null; }
        public virtual T Value<T>(object key) { throw null; }
        public abstract void WriteTo(Newtonsoft.Json.JsonWriter writer, params Newtonsoft.Json.JsonConverter[] converters);
    }
    public partial class JTokenEqualityComparer : System.Collections.Generic.IEqualityComparer<Newtonsoft.Json.Linq.JToken>
    {
        public JTokenEqualityComparer() { }
        public bool Equals(Newtonsoft.Json.Linq.JToken x, Newtonsoft.Json.Linq.JToken y) { throw null; }
        public int GetHashCode(Newtonsoft.Json.Linq.JToken obj) { throw null; }
    }
    public partial class JTokenReader : Newtonsoft.Json.JsonReader, Newtonsoft.Json.IJsonLineInfo
    {
        public JTokenReader(Newtonsoft.Json.Linq.JToken token) { }
        public Newtonsoft.Json.Linq.JToken CurrentToken { get { throw null; } }
        int Newtonsoft.Json.IJsonLineInfo.LineNumber { get { throw null; } }
        int Newtonsoft.Json.IJsonLineInfo.LinePosition { get { throw null; } }
        public override string Path { get { throw null; } }
        bool Newtonsoft.Json.IJsonLineInfo.HasLineInfo() { throw null; }
        public override bool Read() { throw null; }
    }
    public enum JTokenType
    {
        Array = 2,
        Boolean = 9,
        Bytes = 14,
        Comment = 5,
        Constructor = 3,
        Date = 12,
        Float = 7,
        Guid = 15,
        Integer = 6,
        None = 0,
        Null = 10,
        Object = 1,
        Property = 4,
        Raw = 13,
        String = 8,
        TimeSpan = 17,
        Undefined = 11,
        Uri = 16,
    }
    public partial class JTokenWriter : Newtonsoft.Json.JsonWriter
    {
        public JTokenWriter() { }
        public JTokenWriter(Newtonsoft.Json.Linq.JContainer container) { }
        public Newtonsoft.Json.Linq.JToken CurrentToken { get { throw null; } }
        public Newtonsoft.Json.Linq.JToken Token { get { throw null; } }
        public override void Close() { }
        public override void Flush() { }
        public override void WriteComment(string text) { }
        protected override void WriteEnd(Newtonsoft.Json.JsonToken token) { }
        public override void WriteNull() { }
        public override void WritePropertyName(string name) { }
        public override void WriteRaw(string json) { }
        public override void WriteStartArray() { }
        public override void WriteStartConstructor(string name) { }
        public override void WriteStartObject() { }
        public override void WriteUndefined() { }
        public override void WriteValue(bool value) { }
        public override void WriteValue(byte value) { }
        public override void WriteValue(byte[] value) { }
        public override void WriteValue(char value) { }
        public override void WriteValue(System.DateTime value) { }
        public override void WriteValue(System.DateTimeOffset value) { }
        public override void WriteValue(decimal value) { }
        public override void WriteValue(double value) { }
        public override void WriteValue(System.Guid value) { }
        public override void WriteValue(short value) { }
        public override void WriteValue(int value) { }
        public override void WriteValue(long value) { }
        public override void WriteValue(object value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(sbyte value) { }
        public override void WriteValue(float value) { }
        public override void WriteValue(string value) { }
        public override void WriteValue(System.TimeSpan value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(ushort value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(uint value) { }
        [System.CLSCompliantAttribute(false)]
        public override void WriteValue(ulong value) { }
        public override void WriteValue(System.Uri value) { }
    }
    public partial class JValue : Newtonsoft.Json.Linq.JToken, System.IComparable, System.IComparable<Newtonsoft.Json.Linq.JValue>, System.IEquatable<Newtonsoft.Json.Linq.JValue>, System.IFormattable
    {
        public JValue(Newtonsoft.Json.Linq.JValue other) { }
        public JValue(bool value) { }
        public JValue(char value) { }
        public JValue(System.DateTime value) { }
        public JValue(System.DateTimeOffset value) { }
        public JValue(decimal value) { }
        public JValue(double value) { }
        public JValue(System.Guid value) { }
        public JValue(long value) { }
        public JValue(object value) { }
        public JValue(float value) { }
        public JValue(string value) { }
        public JValue(System.TimeSpan value) { }
        [System.CLSCompliantAttribute(false)]
        public JValue(ulong value) { }
        public JValue(System.Uri value) { }
        public override bool HasValues { get { throw null; } }
        public override Newtonsoft.Json.Linq.JTokenType Type { get { throw null; } }
        public object Value { get { throw null; } set { } }
        public int CompareTo(Newtonsoft.Json.Linq.JValue obj) { throw null; }
        public static Newtonsoft.Json.Linq.JValue CreateComment(string value) { throw null; }
        public static Newtonsoft.Json.Linq.JValue CreateNull() { throw null; }
        public static Newtonsoft.Json.Linq.JValue CreateString(string value) { throw null; }
        public static Newtonsoft.Json.Linq.JValue CreateUndefined() { throw null; }
        public bool Equals(Newtonsoft.Json.Linq.JValue other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override System.Dynamic.DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        int System.IComparable.CompareTo(object obj) { throw null; }
        public override string ToString() { throw null; }
        public string ToString(System.IFormatProvider formatProvider) { throw null; }
        public string ToString(string format) { throw null; }
        public string ToString(string format, System.IFormatProvider formatProvider) { throw null; }
        public override void WriteTo(Newtonsoft.Json.JsonWriter writer, params Newtonsoft.Json.JsonConverter[] converters) { }
    }
    public enum LineInfoHandling
    {
        Ignore = 0,
        Load = 1,
    }
    public enum MergeArrayHandling
    {
        Concat = 0,
        Merge = 3,
        Replace = 2,
        Union = 1,
    }
    [System.FlagsAttribute]
    public enum MergeNullValueHandling
    {
        Ignore = 0,
        Merge = 1,
    }
}
namespace Newtonsoft.Json.Schema
{
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public static partial class Extensions
    {
        [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
        public static bool IsValid(this Newtonsoft.Json.Linq.JToken source, Newtonsoft.Json.Schema.JsonSchema schema) { throw null; }
        [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
        public static bool IsValid(this Newtonsoft.Json.Linq.JToken source, Newtonsoft.Json.Schema.JsonSchema schema, out System.Collections.Generic.IList<string> errorMessages) { errorMessages = default(System.Collections.Generic.IList<string>); throw null; }
        [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
        public static void Validate(this Newtonsoft.Json.Linq.JToken source, Newtonsoft.Json.Schema.JsonSchema schema) { }
        [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
        public static void Validate(this Newtonsoft.Json.Linq.JToken source, Newtonsoft.Json.Schema.JsonSchema schema, Newtonsoft.Json.Schema.ValidationEventHandler validationEventHandler) { }
    }
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public partial class JsonSchema
    {
        public JsonSchema() { }
        public Newtonsoft.Json.Schema.JsonSchema AdditionalItems { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.Schema.JsonSchema AdditionalProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool AllowAdditionalItems { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool AllowAdditionalProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.Linq.JToken Default { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.Schema.JsonSchemaType> Disallow { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<double> DivisibleBy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> Enum { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> ExclusiveMaximum { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> ExclusiveMinimum { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema> Extends { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Format { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> Hidden { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema> Items { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<double> Maximum { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<int> MaximumItems { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<int> MaximumLength { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<double> Minimum { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<int> MinimumItems { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<int> MinimumLength { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Pattern { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IDictionary<string, Newtonsoft.Json.Schema.JsonSchema> PatternProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool PositionalItemsValidation { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IDictionary<string, Newtonsoft.Json.Schema.JsonSchema> Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> ReadOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> Required { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Requires { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string Title { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> Transient { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.Schema.JsonSchemaType> Type { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool UniqueItems { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public static Newtonsoft.Json.Schema.JsonSchema Parse(string json) { throw null; }
        public static Newtonsoft.Json.Schema.JsonSchema Parse(string json, Newtonsoft.Json.Schema.JsonSchemaResolver resolver) { throw null; }
        public static Newtonsoft.Json.Schema.JsonSchema Read(Newtonsoft.Json.JsonReader reader) { throw null; }
        public static Newtonsoft.Json.Schema.JsonSchema Read(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Schema.JsonSchemaResolver resolver) { throw null; }
        public override string ToString() { throw null; }
        public void WriteTo(Newtonsoft.Json.JsonWriter writer) { }
        public void WriteTo(Newtonsoft.Json.JsonWriter writer, Newtonsoft.Json.Schema.JsonSchemaResolver resolver) { }
    }
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public partial class JsonSchemaException : Newtonsoft.Json.JsonException
    {
        public JsonSchemaException() { }
        public JsonSchemaException(string message) { }
        public JsonSchemaException(string message, System.Exception innerException) { }
        public int LineNumber { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public int LinePosition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public partial class JsonSchemaGenerator
    {
        public JsonSchemaGenerator() { }
        public Newtonsoft.Json.Serialization.IContractResolver ContractResolver { get { throw null; } set { } }
        public Newtonsoft.Json.Schema.UndefinedSchemaIdHandling UndefinedSchemaIdHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.Schema.JsonSchema Generate(System.Type type) { throw null; }
        public Newtonsoft.Json.Schema.JsonSchema Generate(System.Type type, Newtonsoft.Json.Schema.JsonSchemaResolver resolver) { throw null; }
        public Newtonsoft.Json.Schema.JsonSchema Generate(System.Type type, Newtonsoft.Json.Schema.JsonSchemaResolver resolver, bool rootSchemaNullable) { throw null; }
        public Newtonsoft.Json.Schema.JsonSchema Generate(System.Type type, bool rootSchemaNullable) { throw null; }
    }
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public partial class JsonSchemaResolver
    {
        public JsonSchemaResolver() { }
        public System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema> LoadedSchemas { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]protected set { } }
        public virtual Newtonsoft.Json.Schema.JsonSchema GetSchema(string reference) { throw null; }
    }
    [System.FlagsAttribute]
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public enum JsonSchemaType
    {
        Any = 127,
        Array = 32,
        Boolean = 8,
        Float = 2,
        Integer = 4,
        None = 0,
        Null = 64,
        Object = 16,
        String = 1,
    }
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public enum UndefinedSchemaIdHandling
    {
        None = 0,
        UseAssemblyQualifiedName = 2,
        UseTypeName = 1,
    }
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public partial class ValidationEventArgs : System.EventArgs
    {
        internal ValidationEventArgs() { }
        public Newtonsoft.Json.Schema.JsonSchemaException Exception { get { throw null; } }
        public string Message { get { throw null; } }
        public string Path { get { throw null; } }
    }
    [System.ObsoleteAttribute("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
    public delegate void ValidationEventHandler(object sender, Newtonsoft.Json.Schema.ValidationEventArgs e);
}
namespace Newtonsoft.Json.Serialization
{
    public partial class CamelCaseNamingStrategy : Newtonsoft.Json.Serialization.NamingStrategy
    {
        public CamelCaseNamingStrategy() { }
        public CamelCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames) { }
        protected override string ResolvePropertyName(string name) { throw null; }
    }
    public partial class CamelCasePropertyNamesContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        public CamelCasePropertyNamesContractResolver() { }
    }
    public partial class DefaultContractResolver : Newtonsoft.Json.Serialization.IContractResolver
    {
        public DefaultContractResolver() { }
        [System.ObsoleteAttribute("DefaultContractResolver(bool) is obsolete. Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance.")]
        public DefaultContractResolver(bool shareCache) { }
        public bool DynamicCodeGeneration { get { throw null; } }
        public Newtonsoft.Json.Serialization.NamingStrategy NamingStrategy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool SerializeCompilerGeneratedMembers { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        protected virtual Newtonsoft.Json.Serialization.JsonArrayContract CreateArrayContract(System.Type objectType) { throw null; }
        protected virtual System.Collections.Generic.IList<Newtonsoft.Json.Serialization.JsonProperty> CreateConstructorParameters(System.Reflection.ConstructorInfo constructor, Newtonsoft.Json.Serialization.JsonPropertyCollection memberProperties) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.JsonContract CreateContract(System.Type objectType) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.JsonDictionaryContract CreateDictionaryContract(System.Type objectType) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.JsonDynamicContract CreateDynamicContract(System.Type objectType) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.JsonLinqContract CreateLinqContract(System.Type objectType) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.IValueProvider CreateMemberValueProvider(System.Reflection.MemberInfo member) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.JsonObjectContract CreateObjectContract(System.Type objectType) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.JsonPrimitiveContract CreatePrimitiveContract(System.Type objectType) { throw null; }
        protected virtual System.Collections.Generic.IList<Newtonsoft.Json.Serialization.JsonProperty> CreateProperties(System.Type type, Newtonsoft.Json.MemberSerialization memberSerialization) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.JsonProperty CreateProperty(System.Reflection.MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.JsonProperty CreatePropertyFromConstructorParameter(Newtonsoft.Json.Serialization.JsonProperty matchingMemberProperty, System.Reflection.ParameterInfo parameterInfo) { throw null; }
        protected virtual Newtonsoft.Json.Serialization.JsonStringContract CreateStringContract(System.Type objectType) { throw null; }
        public string GetResolvedPropertyName(string propertyName) { throw null; }
        protected virtual System.Collections.Generic.List<System.Reflection.MemberInfo> GetSerializableMembers(System.Type objectType) { throw null; }
        public virtual Newtonsoft.Json.Serialization.JsonContract ResolveContract(System.Type type) { throw null; }
        protected virtual Newtonsoft.Json.JsonConverter ResolveContractConverter(System.Type objectType) { throw null; }
        protected virtual string ResolveDictionaryKey(string dictionaryKey) { throw null; }
        protected virtual string ResolvePropertyName(string propertyName) { throw null; }
    }
    public partial class DefaultNamingStrategy : Newtonsoft.Json.Serialization.NamingStrategy
    {
        public DefaultNamingStrategy() { }
        protected override string ResolvePropertyName(string name) { throw null; }
    }
    public partial class DefaultSerializationBinder : Newtonsoft.Json.SerializationBinder
    {
        public DefaultSerializationBinder() { }
        public override void BindToName(System.Type serializedType, out string assemblyName, out string typeName) { assemblyName = default(string); typeName = default(string); }
        public override System.Type BindToType(string assemblyName, string typeName) { throw null; }
    }
    public partial class ErrorContext
    {
        internal ErrorContext() { }
        public System.Exception Error { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool Handled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public object Member { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public object OriginalObject { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class ErrorEventArgs : System.EventArgs
    {
        public ErrorEventArgs(object currentObject, Newtonsoft.Json.Serialization.ErrorContext errorContext) { }
        public object CurrentObject { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Newtonsoft.Json.Serialization.ErrorContext ErrorContext { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class ExpressionValueProvider : Newtonsoft.Json.Serialization.IValueProvider
    {
        public ExpressionValueProvider(System.Reflection.MemberInfo memberInfo) { }
        public object GetValue(object target) { throw null; }
        public void SetValue(object target, object value) { }
    }
    public delegate System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object, object>> ExtensionDataGetter(object o);
    public delegate void ExtensionDataSetter(object o, string key, object value);
    public partial interface IAttributeProvider
    {
        System.Collections.Generic.IList<System.Attribute> GetAttributes(bool inherit);
        System.Collections.Generic.IList<System.Attribute> GetAttributes(System.Type attributeType, bool inherit);
    }
    public partial interface IContractResolver
    {
        Newtonsoft.Json.Serialization.JsonContract ResolveContract(System.Type type);
    }
    public partial interface IReferenceResolver
    {
        void AddReference(object context, string reference, object value);
        string GetReference(object context, object value);
        bool IsReferenced(object context, object value);
        object ResolveReference(object context, string reference);
    }
    public partial interface ITraceWriter
    {
        Newtonsoft.Json.TraceLevel LevelFilter { get; }
        void Trace(Newtonsoft.Json.TraceLevel level, string message, System.Exception ex);
    }
    public partial interface IValueProvider
    {
        object GetValue(object target);
        void SetValue(object target, object value);
    }
    public partial class JsonArrayContract : Newtonsoft.Json.Serialization.JsonContainerContract
    {
        public JsonArrayContract(System.Type underlyingType) { }
        public System.Type CollectionItemType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool HasParameterizedCreator { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool IsMultidimensionalArray { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public Newtonsoft.Json.Serialization.ObjectConstructor<object> OverrideCreator { get { throw null; } set { } }
    }
    public partial class JsonContainerContract : Newtonsoft.Json.Serialization.JsonContract
    {
        internal JsonContainerContract() { }
        public Newtonsoft.Json.JsonConverter ItemConverter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> ItemIsReference { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.ReferenceLoopHandling> ItemReferenceLoopHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.TypeNameHandling> ItemTypeNameHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public abstract partial class JsonContract
    {
        internal JsonContract() { }
        public Newtonsoft.Json.JsonConverter Converter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Type CreatedType { get { throw null; } set { } }
        public System.Func<object> DefaultCreator { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool DefaultCreatorNonPublic { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> IsReference { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [System.ObsoleteAttribute("This property is obsolete and has been replaced by the OnDeserializedCallbacks collection.")]
        public System.Reflection.MethodInfo OnDeserialized { get { throw null; } set { } }
        public System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback> OnDeserializedCallbacks { get { throw null; } }
        [System.ObsoleteAttribute("This property is obsolete and has been replaced by the OnDeserializingCallbacks collection.")]
        public System.Reflection.MethodInfo OnDeserializing { get { throw null; } set { } }
        public System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback> OnDeserializingCallbacks { get { throw null; } }
        [System.ObsoleteAttribute("This property is obsolete and has been replaced by the OnErrorCallbacks collection.")]
        public System.Reflection.MethodInfo OnError { get { throw null; } set { } }
        public System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationErrorCallback> OnErrorCallbacks { get { throw null; } }
        [System.ObsoleteAttribute("This property is obsolete and has been replaced by the OnSerializedCallbacks collection.")]
        public System.Reflection.MethodInfo OnSerialized { get { throw null; } set { } }
        public System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback> OnSerializedCallbacks { get { throw null; } }
        [System.ObsoleteAttribute("This property is obsolete and has been replaced by the OnSerializingCallbacks collection.")]
        public System.Reflection.MethodInfo OnSerializing { get { throw null; } set { } }
        public System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback> OnSerializingCallbacks { get { throw null; } }
        public System.Type UnderlyingType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class JsonDictionaryContract : Newtonsoft.Json.Serialization.JsonContainerContract
    {
        public JsonDictionaryContract(System.Type underlyingType) { }
        public System.Func<string, string> DictionaryKeyResolver { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Type DictionaryKeyType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Type DictionaryValueType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public bool HasParameterizedCreator { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.Serialization.ObjectConstructor<object> OverrideCreator { get { throw null; } set { } }
        [System.ObsoleteAttribute("PropertyNameResolver is obsolete. Use DictionaryKeyResolver instead.")]
        public System.Func<string, string> PropertyNameResolver { get { throw null; } set { } }
    }
    public partial class JsonDynamicContract : Newtonsoft.Json.Serialization.JsonContainerContract
    {
        public JsonDynamicContract(System.Type underlyingType) { }
        public Newtonsoft.Json.Serialization.JsonPropertyCollection Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public System.Func<string, string> PropertyNameResolver { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
    public partial class JsonLinqContract : Newtonsoft.Json.Serialization.JsonContract
    {
        public JsonLinqContract(System.Type underlyingType) { }
    }
    public partial class JsonObjectContract : Newtonsoft.Json.Serialization.JsonContainerContract
    {
        public JsonObjectContract(System.Type underlyingType) { }
        [System.ObsoleteAttribute("ConstructorParameters is obsolete. Use CreatorParameters instead.")]
        public Newtonsoft.Json.Serialization.JsonPropertyCollection ConstructorParameters { get { throw null; } }
        public Newtonsoft.Json.Serialization.JsonPropertyCollection CreatorParameters { get { throw null; } }
        public Newtonsoft.Json.Serialization.ExtensionDataGetter ExtensionDataGetter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.Serialization.ExtensionDataSetter ExtensionDataSetter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Type ExtensionDataValueType { get { throw null; } set { } }
        public System.Nullable<Newtonsoft.Json.Required> ItemRequired { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.MemberSerialization MemberSerialization { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        [System.ObsoleteAttribute("OverrideConstructor is obsolete. Use OverrideCreator instead.")]
        public System.Reflection.ConstructorInfo OverrideConstructor { get { throw null; } set { } }
        public Newtonsoft.Json.Serialization.ObjectConstructor<object> OverrideCreator { get { throw null; } set { } }
        [System.ObsoleteAttribute("ParametrizedConstructor is obsolete. Use OverrideCreator instead.")]
        public System.Reflection.ConstructorInfo ParametrizedConstructor { get { throw null; } set { } }
        public Newtonsoft.Json.Serialization.JsonPropertyCollection Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial class JsonPrimitiveContract : Newtonsoft.Json.Serialization.JsonContract
    {
        public JsonPrimitiveContract(System.Type underlyingType) { }
    }
    public partial class JsonProperty
    {
        public JsonProperty() { }
        public Newtonsoft.Json.Serialization.IAttributeProvider AttributeProvider { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.JsonConverter Converter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Type DeclaringType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public object DefaultValue { get { throw null; } set { } }
        public System.Nullable<Newtonsoft.Json.DefaultValueHandling> DefaultValueHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Predicate<object> GetIsSpecified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool HasMemberAttribute { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Ignored { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> IsReference { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.JsonConverter ItemConverter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<bool> ItemIsReference { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.ReferenceLoopHandling> ItemReferenceLoopHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.TypeNameHandling> ItemTypeNameHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.JsonConverter MemberConverter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.NullValueHandling> NullValueHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.ObjectCreationHandling> ObjectCreationHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<int> Order { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string PropertyName { get { throw null; } set { } }
        public System.Type PropertyType { get { throw null; } set { } }
        public bool Readable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.ReferenceLoopHandling> ReferenceLoopHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.Required Required { get { throw null; } set { } }
        public System.Action<object, object> SetIsSpecified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Predicate<object> ShouldDeserialize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Predicate<object> ShouldSerialize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Nullable<Newtonsoft.Json.TypeNameHandling> TypeNameHandling { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public string UnderlyingName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public Newtonsoft.Json.Serialization.IValueProvider ValueProvider { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool Writable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override string ToString() { throw null; }
    }
    public partial class JsonPropertyCollection : System.Collections.ObjectModel.KeyedCollection<string, Newtonsoft.Json.Serialization.JsonProperty>
    {
        public JsonPropertyCollection(System.Type type) { }
        public void AddProperty(Newtonsoft.Json.Serialization.JsonProperty property) { }
        public Newtonsoft.Json.Serialization.JsonProperty GetClosestMatchProperty(string propertyName) { throw null; }
        protected override string GetKeyForItem(Newtonsoft.Json.Serialization.JsonProperty item) { throw null; }
        public Newtonsoft.Json.Serialization.JsonProperty GetProperty(string propertyName, System.StringComparison comparisonType) { throw null; }
    }
    public partial class JsonStringContract : Newtonsoft.Json.Serialization.JsonPrimitiveContract
    {
        public JsonStringContract(System.Type underlyingType) : base (default(System.Type)) { }
    }
    public partial class MemoryTraceWriter : Newtonsoft.Json.Serialization.ITraceWriter
    {
        public MemoryTraceWriter() { }
        public Newtonsoft.Json.TraceLevel LevelFilter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public System.Collections.Generic.IEnumerable<string> GetTraceMessages() { throw null; }
        public override string ToString() { throw null; }
        public void Trace(Newtonsoft.Json.TraceLevel level, string message, System.Exception ex) { }
    }
    public abstract partial class NamingStrategy
    {
        protected NamingStrategy() { }
        public bool OverrideSpecifiedNames { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public bool ProcessDictionaryKeys { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public virtual string GetDictionaryKey(string key) { throw null; }
        public virtual string GetPropertyName(string name, bool hasSpecifiedName) { throw null; }
        protected abstract string ResolvePropertyName(string name);
    }
    public delegate object ObjectConstructor<T>(params object[] args);
    [System.AttributeUsageAttribute((System.AttributeTargets)(64), Inherited=false)]
    public sealed partial class OnErrorAttribute : System.Attribute
    {
        public OnErrorAttribute() { }
    }
    public partial class ReflectionAttributeProvider : Newtonsoft.Json.Serialization.IAttributeProvider
    {
        public ReflectionAttributeProvider(object attributeProvider) { }
        public System.Collections.Generic.IList<System.Attribute> GetAttributes(bool inherit) { throw null; }
        public System.Collections.Generic.IList<System.Attribute> GetAttributes(System.Type attributeType, bool inherit) { throw null; }
    }
    public partial class ReflectionValueProvider : Newtonsoft.Json.Serialization.IValueProvider
    {
        public ReflectionValueProvider(System.Reflection.MemberInfo memberInfo) { }
        public object GetValue(object target) { throw null; }
        public void SetValue(object target, object value) { }
    }
    public delegate void SerializationCallback(object o, System.Runtime.Serialization.StreamingContext context);
    public delegate void SerializationErrorCallback(object o, System.Runtime.Serialization.StreamingContext context, Newtonsoft.Json.Serialization.ErrorContext errorContext);
    public partial class SnakeCaseNamingStrategy : Newtonsoft.Json.Serialization.NamingStrategy
    {
        public SnakeCaseNamingStrategy() { }
        public SnakeCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames) { }
        protected override string ResolvePropertyName(string name) { throw null; }
    }
}
namespace System.Runtime.Serialization.Formatters
{
    public enum FormatterAssemblyStyle
    {
        Full = 1,
        Simple = 0,
    }
}
