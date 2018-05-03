[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ComponentModel.Primitives")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ComponentModel.Primitives")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("1.0.24212.01")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("1.0.24212.01. Commit Hash: 9688ddbb62c04189cac4c4a06e31e93377dccd41")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ComponentModel.Primitives")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.ComponentModel
{
    public sealed partial class BrowsableAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.BrowsableAttribute Default;
        public static readonly System.ComponentModel.BrowsableAttribute No;
        public static readonly System.ComponentModel.BrowsableAttribute Yes;
        public BrowsableAttribute(bool browsable) { }
        public bool Browsable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class CategoryAttribute : System.Attribute
    {
        public CategoryAttribute() { }
        public CategoryAttribute(string category) { }
        public static System.ComponentModel.CategoryAttribute Action { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Appearance { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Asynchronous { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Behavior { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public string Category { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Data { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Default { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Design { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute DragDrop { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Focus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Format { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Key { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Layout { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute Mouse { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public static System.ComponentModel.CategoryAttribute WindowStyle { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected virtual string GetLocalizedString(string value) { throw null; }
    }
    public partial class ComponentCollection
    {
        internal ComponentCollection() { }
    }
    public partial class DescriptionAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.DescriptionAttribute Default;
        public DescriptionAttribute() { }
        public DescriptionAttribute(string description) { }
        public virtual string Description { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        protected string DescriptionValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class DesignerCategoryAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.DesignerCategoryAttribute Component;
        public static readonly System.ComponentModel.DesignerCategoryAttribute Default;
        public static readonly System.ComponentModel.DesignerCategoryAttribute Form;
        public static readonly System.ComponentModel.DesignerCategoryAttribute Generic;
        public DesignerCategoryAttribute() { }
        public DesignerCategoryAttribute(string category) { }
        public string Category { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public enum DesignerSerializationVisibility
    {
        Content = 2,
        Hidden = 0,
        Visible = 1,
    }
    public sealed partial class DesignerSerializationVisibilityAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.DesignerSerializationVisibilityAttribute Content;
        public static readonly System.ComponentModel.DesignerSerializationVisibilityAttribute Default;
        public static readonly System.ComponentModel.DesignerSerializationVisibilityAttribute Hidden;
        public static readonly System.ComponentModel.DesignerSerializationVisibilityAttribute Visible;
        public DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility visibility) { }
        public System.ComponentModel.DesignerSerializationVisibility Visibility { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class DesignOnlyAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.DesignOnlyAttribute Default;
        public static readonly System.ComponentModel.DesignOnlyAttribute No;
        public static readonly System.ComponentModel.DesignOnlyAttribute Yes;
        public DesignOnlyAttribute(bool isDesignOnly) { }
        public bool IsDesignOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class DisplayNameAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.DisplayNameAttribute Default;
        public DisplayNameAttribute() { }
        public DisplayNameAttribute(string displayName) { }
        public virtual string DisplayName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        protected string DisplayNameValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class EventHandlerList : System.IDisposable
    {
        public EventHandlerList() { }
        public System.Delegate this[object key] { get { throw null; } set { } }
        public void AddHandler(object key, System.Delegate value) { }
        public void AddHandlers(System.ComponentModel.EventHandlerList listToAddFrom) { }
        public void Dispose() { }
        public void RemoveHandler(object key, System.Delegate value) { }
    }
    public partial interface IComponent : System.IDisposable
    {
        System.ComponentModel.ISite Site { get; set; }
        event System.EventHandler Disposed;
    }
    public partial interface IContainer : System.IDisposable
    {
        System.ComponentModel.ComponentCollection Components { get; }
        void Add(System.ComponentModel.IComponent component);
        void Add(System.ComponentModel.IComponent component, string name);
        void Remove(System.ComponentModel.IComponent component);
    }
    public sealed partial class ImmutableObjectAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.ImmutableObjectAttribute Default;
        public static readonly System.ComponentModel.ImmutableObjectAttribute No;
        public static readonly System.ComponentModel.ImmutableObjectAttribute Yes;
        public ImmutableObjectAttribute(bool immutable) { }
        public bool Immutable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class InitializationEventAttribute : System.Attribute
    {
        public InitializationEventAttribute(string eventName) { }
        public string EventName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
    }
    public partial interface ISite : System.IServiceProvider
    {
        System.ComponentModel.IComponent Component { get; }
        System.ComponentModel.IContainer Container { get; }
        bool DesignMode { get; }
        string Name { get; set; }
    }
    public sealed partial class LocalizableAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.LocalizableAttribute Default;
        public static readonly System.ComponentModel.LocalizableAttribute No;
        public static readonly System.ComponentModel.LocalizableAttribute Yes;
        public LocalizableAttribute(bool isLocalizable) { }
        public bool IsLocalizable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class MergablePropertyAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.MergablePropertyAttribute Default;
        public static readonly System.ComponentModel.MergablePropertyAttribute No;
        public static readonly System.ComponentModel.MergablePropertyAttribute Yes;
        public MergablePropertyAttribute(bool allowMerge) { }
        public bool AllowMerge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class NotifyParentPropertyAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.NotifyParentPropertyAttribute Default;
        public static readonly System.ComponentModel.NotifyParentPropertyAttribute No;
        public static readonly System.ComponentModel.NotifyParentPropertyAttribute Yes;
        public NotifyParentPropertyAttribute(bool notifyParent) { }
        public bool NotifyParent { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class ParenthesizePropertyNameAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.ParenthesizePropertyNameAttribute Default;
        public ParenthesizePropertyNameAttribute() { }
        public ParenthesizePropertyNameAttribute(bool needParenthesis) { }
        public bool NeedParenthesis { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object o) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class ReadOnlyAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.ReadOnlyAttribute Default;
        public static readonly System.ComponentModel.ReadOnlyAttribute No;
        public static readonly System.ComponentModel.ReadOnlyAttribute Yes;
        public ReadOnlyAttribute(bool isReadOnly) { }
        public bool IsReadOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object value) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public enum RefreshProperties
    {
        All = 1,
        None = 0,
        Repaint = 2,
    }
    public sealed partial class RefreshPropertiesAttribute : System.Attribute
    {
        public static readonly System.ComponentModel.RefreshPropertiesAttribute All;
        public static readonly System.ComponentModel.RefreshPropertiesAttribute Default;
        public static readonly System.ComponentModel.RefreshPropertiesAttribute Repaint;
        public RefreshPropertiesAttribute(System.ComponentModel.RefreshProperties refresh) { }
        public System.ComponentModel.RefreshProperties RefreshProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } }
        public override bool Equals(object value) { throw null; }
        public override int GetHashCode() { throw null; }
    }
}
