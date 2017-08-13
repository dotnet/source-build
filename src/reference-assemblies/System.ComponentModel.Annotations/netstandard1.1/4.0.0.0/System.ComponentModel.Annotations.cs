[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ComponentModel.Annotations.dll")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ComponentModel.Annotations.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.30319.17929")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ComponentModel.Annotations.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.ComponentModel.DataAnnotations
{
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false, Inherited=true)]
    public sealed partial class AssociationAttribute : System.Attribute
    {
        public AssociationAttribute(string name, string thisKey, string otherKey) { }
        public bool IsForeignKey { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string OtherKey { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> OtherKeyMembers { get { throw null; } }
        public string ThisKey { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> ThisKeyMembers { get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false, Inherited=true)]
    public sealed partial class ConcurrencyCheckAttribute : System.Attribute
    {
        public ConcurrencyCheckAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2500), AllowMultiple=true)]
    public sealed partial class CustomValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public CustomValidationAttribute(System.Type validatorType, string method) { }
        public string Method { get { throw null; } }
        public System.Type ValidatorType { get { throw null; } }
        public override string FormatErrorMessage(string name) { throw null; }
        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext) { throw null; }
    }
    public enum DataType
    {
        Currency = 6,
        Custom = 0,
        Date = 2,
        DateTime = 1,
        Duration = 4,
        EmailAddress = 10,
        Html = 8,
        ImageUrl = 13,
        MultilineText = 9,
        Password = 11,
        PhoneNumber = 5,
        Text = 7,
        Time = 3,
        Url = 12,
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2496), AllowMultiple=false)]
    public partial class DataTypeAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public DataTypeAttribute(System.ComponentModel.DataAnnotations.DataType dataType) { }
        public DataTypeAttribute(string customDataType) { }
        public string CustomDataType { get { throw null; } }
        public System.ComponentModel.DataAnnotations.DataType DataType { get { throw null; } }
        public System.ComponentModel.DataAnnotations.DisplayFormatAttribute DisplayFormat { get { throw null; } protected set { } }
        public virtual string GetDataTypeName() { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2496), AllowMultiple=false)]
    public sealed partial class DisplayAttribute : System.Attribute
    {
        public DisplayAttribute() { }
        public bool AutoGenerateField { get { throw null; } set { } }
        public bool AutoGenerateFilter { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string GroupName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Order { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        public System.Type ResourceType { get { throw null; } set { } }
        public string ShortName { get { throw null; } set { } }
        public System.Nullable<bool> GetAutoGenerateField() { throw null; }
        public System.Nullable<bool> GetAutoGenerateFilter() { throw null; }
        public string GetDescription() { throw null; }
        public string GetGroupName() { throw null; }
        public string GetName() { throw null; }
        public System.Nullable<int> GetOrder() { throw null; }
        public string GetPrompt() { throw null; }
        public string GetShortName() { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(4), Inherited=true, AllowMultiple=false)]
    public partial class DisplayColumnAttribute : System.Attribute
    {
        public DisplayColumnAttribute(string displayColumn) { }
        public DisplayColumnAttribute(string displayColumn, string sortColumn) { }
        public DisplayColumnAttribute(string displayColumn, string sortColumn, bool sortDescending) { }
        public string DisplayColumn { get { throw null; } }
        public string SortColumn { get { throw null; } }
        public bool SortDescending { get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false)]
    public partial class DisplayFormatAttribute : System.Attribute
    {
        public DisplayFormatAttribute() { }
        public bool ApplyFormatInEditMode { get { throw null; } set { } }
        public bool ConvertEmptyStringToNull { get { throw null; } set { } }
        public string DataFormatString { get { throw null; } set { } }
        public string NullDisplayText { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false, Inherited=true)]
    public sealed partial class EditableAttribute : System.Attribute
    {
        public EditableAttribute(bool allowEdit) { }
        public bool AllowEdit { get { throw null; } }
        public bool AllowInitialValue { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2496), AllowMultiple=false)]
    public sealed partial class EnumDataTypeAttribute : System.ComponentModel.DataAnnotations.DataTypeAttribute
    {
        public EnumDataTypeAttribute(System.Type enumType) : base (default(System.ComponentModel.DataAnnotations.DataType)) { }
        public System.Type EnumType { get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false)]
    public sealed partial class FilterUIHintAttribute : System.Attribute
    {
        public FilterUIHintAttribute(string filterUIHint) { }
        public FilterUIHintAttribute(string filterUIHint, string presentationLayer) { }
        public FilterUIHintAttribute(string filterUIHint, string presentationLayer, params object[] controlParameters) { }
        public System.Collections.Generic.IDictionary<string, object> ControlParameters { get { throw null; } }
        public string FilterUIHint { get { throw null; } }
        public string PresentationLayer { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false, Inherited=true)]
    public sealed partial class KeyAttribute : System.Attribute
    {
        public KeyAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2432), AllowMultiple=false)]
    public partial class RangeAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public RangeAttribute(double minimum, double maximum) { }
        public RangeAttribute(int minimum, int maximum) { }
        public RangeAttribute(System.Type type, string minimum, string maximum) { }
        public object Maximum { get { throw null; } }
        public object Minimum { get { throw null; } }
        public System.Type OperandType { get { throw null; } }
        public override string FormatErrorMessage(string name) { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2432), AllowMultiple=false)]
    public partial class RegularExpressionAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public RegularExpressionAttribute(string pattern) { }
        public string Pattern { get { throw null; } }
        public override string FormatErrorMessage(string name) { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2432), AllowMultiple=false)]
    public partial class RequiredAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public RequiredAttribute() { }
        public bool AllowEmptyStrings { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(2432), AllowMultiple=false)]
    public partial class StringLengthAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public StringLengthAttribute(int maximumLength) { }
        public int MaximumLength { get { throw null; } }
        public int MinimumLength { get { throw null; } set { } }
        public override string FormatErrorMessage(string name) { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false, Inherited=true)]
    public sealed partial class TimestampAttribute : System.Attribute
    {
        public TimestampAttribute() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=true)]
    public partial class UIHintAttribute : System.Attribute
    {
        public UIHintAttribute(string uiHint) { }
        public UIHintAttribute(string uiHint, string presentationLayer) { }
        public UIHintAttribute(string uiHint, string presentationLayer, params object[] controlParameters) { }
        public System.Collections.Generic.IDictionary<string, object> ControlParameters { get { throw null; } }
        public string PresentationLayer { get { throw null; } }
        public string UIHint { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public abstract partial class ValidationAttribute : System.Attribute
    {
        protected ValidationAttribute() { }
        protected ValidationAttribute(System.Func<string> errorMessageAccessor) { }
        protected ValidationAttribute(string errorMessage) { }
        public string ErrorMessage { get { throw null; } set { } }
        public string ErrorMessageResourceName { get { throw null; } set { } }
        public System.Type ErrorMessageResourceType { get { throw null; } set { } }
        protected string ErrorMessageString { get { throw null; } }
        public virtual string FormatErrorMessage(string name) { throw null; }
        public System.ComponentModel.DataAnnotations.ValidationResult GetValidationResult(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext) { throw null; }
        protected virtual System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext) { throw null; }
        public void Validate(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext) { }
    }
    public sealed partial class ValidationContext
    {
        public ValidationContext(object instance) { }
        public ValidationContext(object instance, System.Collections.Generic.IDictionary<object, object> items) { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<object, object> Items { get { throw null; } }
        public string MemberName { get { throw null; } set { } }
        public object ObjectInstance { get { throw null; } }
        public System.Type ObjectType { get { throw null; } }
        public object GetService(System.Type serviceType) { throw null; }
        public void InitializeServiceProvider(System.Func<System.Type, object> serviceProvider) { }
    }
    public partial class ValidationException : System.Exception
    {
        public ValidationException() { }
        public ValidationException(System.ComponentModel.DataAnnotations.ValidationResult validationResult, System.ComponentModel.DataAnnotations.ValidationAttribute validatingAttribute, object value) { }
        public ValidationException(string message) { }
        public ValidationException(string errorMessage, System.ComponentModel.DataAnnotations.ValidationAttribute validatingAttribute, object value) { }
        public ValidationException(string message, System.Exception innerException) { }
        public System.ComponentModel.DataAnnotations.ValidationAttribute ValidationAttribute { get { throw null; } }
        public System.ComponentModel.DataAnnotations.ValidationResult ValidationResult { get { throw null; } }
        public object Value { get { throw null; } }
    }
    public partial class ValidationResult
    {
        public static readonly System.ComponentModel.DataAnnotations.ValidationResult Success;
        public ValidationResult(string errorMessage) { }
        public ValidationResult(string errorMessage, System.Collections.Generic.IEnumerable<string> memberNames) { }
        public string ErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> MemberNames { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public static partial class Validator
    {
        public static bool TryValidateObject(object instance, System.ComponentModel.DataAnnotations.ValidationContext validationContext, System.Collections.Generic.ICollection<System.ComponentModel.DataAnnotations.ValidationResult> validationResults) { throw null; }
        public static bool TryValidateObject(object instance, System.ComponentModel.DataAnnotations.ValidationContext validationContext, System.Collections.Generic.ICollection<System.ComponentModel.DataAnnotations.ValidationResult> validationResults, bool validateAllProperties) { throw null; }
        public static bool TryValidateProperty(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext, System.Collections.Generic.ICollection<System.ComponentModel.DataAnnotations.ValidationResult> validationResults) { throw null; }
        public static bool TryValidateValue(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext, System.Collections.Generic.ICollection<System.ComponentModel.DataAnnotations.ValidationResult> validationResults, System.Collections.Generic.IEnumerable<System.ComponentModel.DataAnnotations.ValidationAttribute> validationAttributes) { throw null; }
        public static void ValidateObject(object instance, System.ComponentModel.DataAnnotations.ValidationContext validationContext) { }
        public static void ValidateObject(object instance, System.ComponentModel.DataAnnotations.ValidationContext validationContext, bool validateAllProperties) { }
        public static void ValidateProperty(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext) { }
        public static void ValidateValue(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext, System.Collections.Generic.IEnumerable<System.ComponentModel.DataAnnotations.ValidationAttribute> validationAttributes) { }
    }
}
namespace System.ComponentModel.DataAnnotations.Schema
{
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false)]
    public partial class DatabaseGeneratedAttribute : System.Attribute
    {
        public DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption databaseGeneratedOption) { }
        public System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption DatabaseGeneratedOption { get { throw null; } }
    }
    public enum DatabaseGeneratedOption
    {
        Computed = 2,
        Identity = 1,
        None = 0,
    }
}
