[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ServiceModel.Duplex")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ServiceModel.Duplex")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.6.24702.02")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.6.24702.02 built by: dlab-DDVSOWINAGE015. Commit Hash: c544ce29b87bec34deeb5a6e86b9b0b493723d30")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ServiceModel.Duplex")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.ServiceModel
{
    [System.AttributeUsageAttribute((System.AttributeTargets)(4))]
    public sealed partial class CallbackBehaviorAttribute : System.Attribute, System.ServiceModel.Description.IEndpointBehavior
    {
        public CallbackBehaviorAttribute() { }
        public bool AutomaticSessionShutdown { get { throw null; } set { } }
        public bool UseSynchronizationContext { get { throw null; } set { } }
        void System.ServiceModel.Description.IEndpointBehavior.AddBindingParameters(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection parameters) { }
        void System.ServiceModel.Description.IEndpointBehavior.ApplyClientBehavior(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime) { }
        void System.ServiceModel.Description.IEndpointBehavior.ApplyDispatchBehavior(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher) { }
        void System.ServiceModel.Description.IEndpointBehavior.Validate(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint) { }
    }
    public partial class DuplexChannelFactory<TChannel> : System.ServiceModel.ChannelFactory<TChannel>
    {
        public DuplexChannelFactory(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding) : base (default(System.ServiceModel.Channels.Binding), default(System.ServiceModel.EndpointAddress)) { }
        public DuplexChannelFactory(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : base (default(System.ServiceModel.Channels.Binding), default(System.ServiceModel.EndpointAddress)) { }
        public DuplexChannelFactory(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, string remoteAddress) : base (default(System.ServiceModel.Channels.Binding), default(System.ServiceModel.EndpointAddress)) { }
        public DuplexChannelFactory(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : base (default(System.ServiceModel.Channels.Binding), default(System.ServiceModel.EndpointAddress)) { }
        public DuplexChannelFactory(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : base (default(System.ServiceModel.Channels.Binding), default(System.ServiceModel.EndpointAddress)) { }
        public override TChannel CreateChannel(System.ServiceModel.EndpointAddress address, System.Uri via) { throw null; }
        public TChannel CreateChannel(System.ServiceModel.InstanceContext callbackInstance) { throw null; }
        public TChannel CreateChannel(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.EndpointAddress address) { throw null; }
        public virtual TChannel CreateChannel(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.EndpointAddress address, System.Uri via) { throw null; }
    }
    public abstract partial class DuplexClientBase<TChannel> : System.ServiceModel.ClientBase<TChannel> where TChannel : class
    {
        protected DuplexClientBase(System.ServiceModel.InstanceContext callbackInstance) { }
        protected DuplexClientBase(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) { }
        protected DuplexClientBase(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) { }
        protected DuplexClientBase(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) { }
        protected DuplexClientBase(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) { }
    }
    public sealed partial class InstanceContext : System.ServiceModel.Channels.CommunicationObject, System.ServiceModel.IExtensibleObject<System.ServiceModel.InstanceContext>
    {
        public InstanceContext(object implementation) { }
        protected override System.TimeSpan DefaultCloseTimeout { get { throw null; } }
        protected override System.TimeSpan DefaultOpenTimeout { get { throw null; } }
        public System.Threading.SynchronizationContext SynchronizationContext { get { throw null; } set { } }
        System.ServiceModel.IExtensionCollection<System.ServiceModel.InstanceContext> System.ServiceModel.IExtensibleObject<System.ServiceModel.InstanceContext>.Extensions { get { throw null; } }
        public object GetServiceInstance(System.ServiceModel.Channels.Message message) { throw null; }
        protected override void OnAbort() { }
        protected override System.IAsyncResult OnBeginClose(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        protected override System.IAsyncResult OnBeginOpen(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        protected override void OnClose(System.TimeSpan timeout) { }
        protected override void OnClosed() { }
        protected override void OnEndClose(System.IAsyncResult result) { }
        protected override void OnEndOpen(System.IAsyncResult result) { }
        protected override void OnFaulted() { }
        protected override void OnOpen(System.TimeSpan timeout) { }
        protected override void OnOpened() { }
        protected override void OnOpening() { }
    }
}
