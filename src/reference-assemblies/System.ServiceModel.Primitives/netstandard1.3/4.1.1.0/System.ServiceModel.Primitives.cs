[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Diagnostics.DebuggableAttribute((System.Diagnostics.DebuggableAttribute.DebuggingModes)(2))]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.ServiceModel.Primitives")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.ServiceModel.Primitives")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.6.24702.02")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.6.24702.02. Commit Hash: c544ce29b87bec34deeb5a6e86b9b0b493723d30")]
[assembly:System.Reflection.AssemblyMetadataAttribute(".NETFrameworkAssembly", "")]
[assembly:System.Reflection.AssemblyMetadataAttribute("Serviceable", "True")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.ServiceModel.Primitives")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
[assembly:System.Security.AllowPartiallyTrustedCallersAttribute]
namespace System.IdentityModel.Selectors
{
    public abstract partial class X509CertificateValidator
    {
        protected X509CertificateValidator() { }
        public abstract void Validate(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate);
    }
}
namespace System.ServiceModel
{
    public partial class ActionNotSupportedException : System.ServiceModel.CommunicationException
    {
        public ActionNotSupportedException() { }
        public ActionNotSupportedException(string message) { }
        public ActionNotSupportedException(string message, System.Exception innerException) { }
    }
    public abstract partial class ChannelFactory : System.ServiceModel.Channels.CommunicationObject, System.IDisposable, System.ServiceModel.Channels.IChannelFactory, System.ServiceModel.ICommunicationObject
    {
        protected ChannelFactory() { }
        public System.ServiceModel.Description.ClientCredentials Credentials { get { throw null; } }
        protected override System.TimeSpan DefaultCloseTimeout { get { throw null; } }
        protected override System.TimeSpan DefaultOpenTimeout { get { throw null; } }
        public System.ServiceModel.Description.ServiceEndpoint Endpoint { get { throw null; } }
        protected virtual void ApplyConfiguration(string configurationName) { }
        protected abstract System.ServiceModel.Description.ServiceEndpoint CreateDescription();
        protected virtual System.ServiceModel.Channels.IChannelFactory CreateFactory() { throw null; }
        protected internal void EnsureOpened() { }
        public T GetProperty<T>() where T : class { throw null; }
        protected void InitializeEndpoint(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress address) { }
        protected void InitializeEndpoint(System.ServiceModel.Description.ServiceEndpoint endpoint) { }
        protected void InitializeEndpoint(string configurationName, System.ServiceModel.EndpointAddress address) { }
        protected override void OnAbort() { }
        protected override System.IAsyncResult OnBeginClose(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        protected override System.IAsyncResult OnBeginOpen(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        protected override void OnClose(System.TimeSpan timeout) { }
        protected override void OnEndClose(System.IAsyncResult result) { }
        protected override void OnEndOpen(System.IAsyncResult result) { }
        protected override void OnOpen(System.TimeSpan timeout) { }
        protected override void OnOpened() { }
        protected override void OnOpening() { }
        void System.IDisposable.Dispose() { }
    }
    public partial class ChannelFactory<TChannel> : System.ServiceModel.ChannelFactory, System.ServiceModel.Channels.IChannelFactory, System.ServiceModel.Channels.IChannelFactory<TChannel>, System.ServiceModel.ICommunicationObject
    {
        public ChannelFactory(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) { }
        public ChannelFactory(string endpointConfigurationName) { }
        public ChannelFactory(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) { }
        protected ChannelFactory(System.Type channelType) { }
        public TChannel CreateChannel() { throw null; }
        public TChannel CreateChannel(System.ServiceModel.EndpointAddress address) { throw null; }
        public virtual TChannel CreateChannel(System.ServiceModel.EndpointAddress address, System.Uri via) { throw null; }
        protected override System.ServiceModel.Description.ServiceEndpoint CreateDescription() { throw null; }
    }
    public abstract partial class ClientBase<TChannel> : System.ServiceModel.ICommunicationObject where TChannel : class
    {
        protected ClientBase() { }
        protected ClientBase(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) { }
        protected ClientBase(string endpointConfigurationName) { }
        protected ClientBase(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) { }
        protected ClientBase(string endpointConfigurationName, string remoteAddress) { }
        protected TChannel Channel { get { throw null; } }
        public System.ServiceModel.ChannelFactory<TChannel> ChannelFactory { get { throw null; } }
        public System.ServiceModel.Description.ClientCredentials ClientCredentials { get { throw null; } }
        public System.ServiceModel.Description.ServiceEndpoint Endpoint { get { throw null; } }
        public System.ServiceModel.IClientChannel InnerChannel { get { throw null; } }
        public System.ServiceModel.CommunicationState State { get { throw null; } }
        event System.EventHandler System.ServiceModel.ICommunicationObject.Closed { add { } remove { } }
        event System.EventHandler System.ServiceModel.ICommunicationObject.Closing { add { } remove { } }
        event System.EventHandler System.ServiceModel.ICommunicationObject.Faulted { add { } remove { } }
        event System.EventHandler System.ServiceModel.ICommunicationObject.Opened { add { } remove { } }
        event System.EventHandler System.ServiceModel.ICommunicationObject.Opening { add { } remove { } }
        public void Abort() { }
        protected virtual TChannel CreateChannel() { throw null; }
        protected T GetDefaultValueForInitialization<T>() { throw null; }
        protected void InvokeAsync(System.ServiceModel.ClientBase<TChannel>.BeginOperationDelegate beginOperationDelegate, object[] inValues, System.ServiceModel.ClientBase<TChannel>.EndOperationDelegate endOperationDelegate, System.Threading.SendOrPostCallback operationCompletedCallback, object userState) { }
        System.IAsyncResult System.ServiceModel.ICommunicationObject.BeginClose(System.AsyncCallback callback, object state) { throw null; }
        System.IAsyncResult System.ServiceModel.ICommunicationObject.BeginClose(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        System.IAsyncResult System.ServiceModel.ICommunicationObject.BeginOpen(System.AsyncCallback callback, object state) { throw null; }
        System.IAsyncResult System.ServiceModel.ICommunicationObject.BeginOpen(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        void System.ServiceModel.ICommunicationObject.Close() { }
        void System.ServiceModel.ICommunicationObject.Close(System.TimeSpan timeout) { }
        void System.ServiceModel.ICommunicationObject.EndClose(System.IAsyncResult result) { }
        void System.ServiceModel.ICommunicationObject.EndOpen(System.IAsyncResult result) { }
        void System.ServiceModel.ICommunicationObject.Open() { }
        void System.ServiceModel.ICommunicationObject.Open(System.TimeSpan timeout) { }
        protected delegate System.IAsyncResult BeginOperationDelegate(object[] inValues, System.AsyncCallback asyncCallback, object state);
        protected partial class ChannelBase<T> : System.IDisposable, System.ServiceModel.Channels.IChannel, System.ServiceModel.Channels.IOutputChannel, System.ServiceModel.Channels.IRequestChannel, System.ServiceModel.IClientChannel, System.ServiceModel.ICommunicationObject, System.ServiceModel.IContextChannel, System.ServiceModel.IExtensibleObject<System.ServiceModel.IContextChannel> where T : class
        {
            protected ChannelBase(System.ServiceModel.ClientBase<T> client) { }
            System.ServiceModel.EndpointAddress System.ServiceModel.Channels.IOutputChannel.RemoteAddress { get { throw null; } }
            System.Uri System.ServiceModel.Channels.IOutputChannel.Via { get { throw null; } }
            System.ServiceModel.EndpointAddress System.ServiceModel.Channels.IRequestChannel.RemoteAddress { get { throw null; } }
            System.Uri System.ServiceModel.Channels.IRequestChannel.Via { get { throw null; } }
            bool System.ServiceModel.IClientChannel.AllowInitializationUI { get { throw null; } set { } }
            bool System.ServiceModel.IClientChannel.DidInteractiveInitialization { get { throw null; } }
            System.Uri System.ServiceModel.IClientChannel.Via { get { throw null; } }
            System.ServiceModel.CommunicationState System.ServiceModel.ICommunicationObject.State { get { throw null; } }
            bool System.ServiceModel.IContextChannel.AllowOutputBatching { get { throw null; } set { } }
            System.ServiceModel.Channels.IInputSession System.ServiceModel.IContextChannel.InputSession { get { throw null; } }
            System.ServiceModel.EndpointAddress System.ServiceModel.IContextChannel.LocalAddress { get { throw null; } }
            System.TimeSpan System.ServiceModel.IContextChannel.OperationTimeout { get { throw null; } set { } }
            System.ServiceModel.Channels.IOutputSession System.ServiceModel.IContextChannel.OutputSession { get { throw null; } }
            System.ServiceModel.EndpointAddress System.ServiceModel.IContextChannel.RemoteAddress { get { throw null; } }
            string System.ServiceModel.IContextChannel.SessionId { get { throw null; } }
            System.ServiceModel.IExtensionCollection<System.ServiceModel.IContextChannel> System.ServiceModel.IExtensibleObject<System.ServiceModel.IContextChannel>.Extensions { get { throw null; } }
            event System.EventHandler<System.ServiceModel.UnknownMessageReceivedEventArgs> System.ServiceModel.IClientChannel.UnknownMessageReceived { add { } remove { } }
            event System.EventHandler System.ServiceModel.ICommunicationObject.Closed { add { } remove { } }
            event System.EventHandler System.ServiceModel.ICommunicationObject.Closing { add { } remove { } }
            event System.EventHandler System.ServiceModel.ICommunicationObject.Faulted { add { } remove { } }
            event System.EventHandler System.ServiceModel.ICommunicationObject.Opened { add { } remove { } }
            event System.EventHandler System.ServiceModel.ICommunicationObject.Opening { add { } remove { } }
            [System.Security.SecuritySafeCriticalAttribute]
            protected System.IAsyncResult BeginInvoke(string methodName, object[] args, System.AsyncCallback callback, object state) { throw null; }
            [System.Security.SecuritySafeCriticalAttribute]
            protected object EndInvoke(string methodName, object[] args, System.IAsyncResult result) { throw null; }
            void System.IDisposable.Dispose() { }
            TProperty System.ServiceModel.Channels.IChannel.GetProperty<TProperty>() { throw null; }
            System.IAsyncResult System.ServiceModel.Channels.IOutputChannel.BeginSend(System.ServiceModel.Channels.Message message, System.AsyncCallback callback, object state) { throw null; }
            System.IAsyncResult System.ServiceModel.Channels.IOutputChannel.BeginSend(System.ServiceModel.Channels.Message message, System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
            void System.ServiceModel.Channels.IOutputChannel.EndSend(System.IAsyncResult result) { }
            void System.ServiceModel.Channels.IOutputChannel.Send(System.ServiceModel.Channels.Message message) { }
            void System.ServiceModel.Channels.IOutputChannel.Send(System.ServiceModel.Channels.Message message, System.TimeSpan timeout) { }
            System.IAsyncResult System.ServiceModel.Channels.IRequestChannel.BeginRequest(System.ServiceModel.Channels.Message message, System.AsyncCallback callback, object state) { throw null; }
            System.IAsyncResult System.ServiceModel.Channels.IRequestChannel.BeginRequest(System.ServiceModel.Channels.Message message, System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
            System.ServiceModel.Channels.Message System.ServiceModel.Channels.IRequestChannel.EndRequest(System.IAsyncResult result) { throw null; }
            System.ServiceModel.Channels.Message System.ServiceModel.Channels.IRequestChannel.Request(System.ServiceModel.Channels.Message message) { throw null; }
            System.ServiceModel.Channels.Message System.ServiceModel.Channels.IRequestChannel.Request(System.ServiceModel.Channels.Message message, System.TimeSpan timeout) { throw null; }
            System.IAsyncResult System.ServiceModel.IClientChannel.BeginDisplayInitializationUI(System.AsyncCallback callback, object state) { throw null; }
            void System.ServiceModel.IClientChannel.DisplayInitializationUI() { }
            void System.ServiceModel.IClientChannel.EndDisplayInitializationUI(System.IAsyncResult result) { }
            void System.ServiceModel.ICommunicationObject.Abort() { }
            System.IAsyncResult System.ServiceModel.ICommunicationObject.BeginClose(System.AsyncCallback callback, object state) { throw null; }
            System.IAsyncResult System.ServiceModel.ICommunicationObject.BeginClose(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
            System.IAsyncResult System.ServiceModel.ICommunicationObject.BeginOpen(System.AsyncCallback callback, object state) { throw null; }
            System.IAsyncResult System.ServiceModel.ICommunicationObject.BeginOpen(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
            void System.ServiceModel.ICommunicationObject.Close() { }
            void System.ServiceModel.ICommunicationObject.Close(System.TimeSpan timeout) { }
            void System.ServiceModel.ICommunicationObject.EndClose(System.IAsyncResult result) { }
            void System.ServiceModel.ICommunicationObject.EndOpen(System.IAsyncResult result) { }
            void System.ServiceModel.ICommunicationObject.Open() { }
            void System.ServiceModel.ICommunicationObject.Open(System.TimeSpan timeout) { }
        }
        protected delegate object[] EndOperationDelegate(System.IAsyncResult result);
        protected partial class InvokeAsyncCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {
            internal InvokeAsyncCompletedEventArgs() : base (default(System.Exception), default(bool), default(object)) { }
            public object[] Results { get { throw null; } }
        }
    }
    public partial class CommunicationException : System.Exception
    {
        public CommunicationException() { }
        public CommunicationException(string message) { }
        public CommunicationException(string message, System.Exception innerException) { }
    }
    public partial class CommunicationObjectAbortedException : System.ServiceModel.CommunicationException
    {
        public CommunicationObjectAbortedException() { }
        public CommunicationObjectAbortedException(string message) { }
        public CommunicationObjectAbortedException(string message, System.Exception innerException) { }
    }
    public partial class CommunicationObjectFaultedException : System.ServiceModel.CommunicationException
    {
        public CommunicationObjectFaultedException() { }
        public CommunicationObjectFaultedException(string message) { }
        public CommunicationObjectFaultedException(string message, System.Exception innerException) { }
    }
    public enum CommunicationState
    {
        Closed = 4,
        Closing = 3,
        Created = 0,
        Faulted = 5,
        Opened = 2,
        Opening = 1,
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1092), Inherited=false, AllowMultiple=false)]
    public sealed partial class DataContractFormatAttribute : System.Attribute
    {
        public DataContractFormatAttribute() { }
        public System.ServiceModel.OperationFormatStyle Style { get { throw null; } set { } }
    }
    public partial class EndpointAddress
    {
        public EndpointAddress(string uri) { }
        public EndpointAddress(System.Uri uri, params System.ServiceModel.Channels.AddressHeader[] addressHeaders) { }
        public EndpointAddress(System.Uri uri, System.ServiceModel.EndpointIdentity identity, params System.ServiceModel.Channels.AddressHeader[] addressHeaders) { }
        public static System.Uri AnonymousUri { get { throw null; } }
        public System.ServiceModel.Channels.AddressHeaderCollection Headers { get { throw null; } }
        public System.ServiceModel.EndpointIdentity Identity { get { throw null; } }
        public bool IsAnonymous { get { throw null; } }
        public bool IsNone { get { throw null; } }
        public static System.Uri NoneUri { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public void ApplyTo(System.ServiceModel.Channels.Message message) { }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(System.ServiceModel.EndpointAddress address1, System.ServiceModel.EndpointAddress address2) { throw null; }
        public static bool operator !=(System.ServiceModel.EndpointAddress address1, System.ServiceModel.EndpointAddress address2) { throw null; }
        public static System.ServiceModel.EndpointAddress ReadFrom(System.ServiceModel.Channels.AddressingVersion addressingVersion, System.Xml.XmlDictionaryReader reader) { throw null; }
        public override string ToString() { throw null; }
        public void WriteContentsTo(System.ServiceModel.Channels.AddressingVersion addressingVersion, System.Xml.XmlDictionaryWriter writer) { }
    }
    public partial class EndpointAddressBuilder
    {
        public EndpointAddressBuilder() { }
        public EndpointAddressBuilder(System.ServiceModel.EndpointAddress address) { }
        public System.Collections.ObjectModel.Collection<System.ServiceModel.Channels.AddressHeader> Headers { get { throw null; } }
        public System.ServiceModel.EndpointIdentity Identity { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public System.ServiceModel.EndpointAddress ToEndpointAddress() { throw null; }
    }
    public abstract partial class EndpointIdentity
    {
        protected EndpointIdentity() { }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointNotFoundException : System.ServiceModel.CommunicationException
    {
        public EndpointNotFoundException(string message) { }
        public EndpointNotFoundException(string message, System.Exception innerException) { }
    }
    public sealed partial class EnvelopeVersion
    {
        internal EnvelopeVersion() { }
        public string NextDestinationActorValue { get { throw null; } }
        public static System.ServiceModel.EnvelopeVersion None { get { throw null; } }
        public static System.ServiceModel.EnvelopeVersion Soap11 { get { throw null; } }
        public static System.ServiceModel.EnvelopeVersion Soap12 { get { throw null; } }
        public string[] GetUltimateDestinationActorValues() { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class ExceptionDetail
    {
        public ExceptionDetail(System.Exception exception) { }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string HelpLink { get { throw null; } set { } }
        [System.Runtime.Serialization.DataMemberAttribute]
        public System.ServiceModel.ExceptionDetail InnerException { get { throw null; } set { } }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Message { get { throw null; } set { } }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string StackTrace { get { throw null; } set { } }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Type { get { throw null; } set { } }
        public override string ToString() { throw null; }
    }
    public partial class FaultCode
    {
        public FaultCode(string name) { }
        public FaultCode(string name, System.ServiceModel.FaultCode subCode) { }
        public FaultCode(string name, string ns) { }
        public FaultCode(string name, string ns, System.ServiceModel.FaultCode subCode) { }
        public bool IsPredefinedFault { get { throw null; } }
        public bool IsReceiverFault { get { throw null; } }
        public bool IsSenderFault { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public System.ServiceModel.FaultCode SubCode { get { throw null; } }
        public static System.ServiceModel.FaultCode CreateSenderFaultCode(System.ServiceModel.FaultCode subCode) { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(64), AllowMultiple=true, Inherited=false)]
    public sealed partial class FaultContractAttribute : System.Attribute
    {
        public FaultContractAttribute(System.Type detailType) { }
        public string Action { get { throw null; } set { } }
        public System.Type DetailType { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
    }
    public partial class FaultException : System.ServiceModel.CommunicationException
    {
        public FaultException() { }
        public FaultException(System.ServiceModel.Channels.MessageFault fault, string action) { }
        public FaultException(System.ServiceModel.FaultReason reason, System.ServiceModel.FaultCode code, string action) { }
        public string Action { get { throw null; } }
        public System.ServiceModel.FaultCode Code { get { throw null; } }
        public override string Message { get { throw null; } }
        public System.ServiceModel.FaultReason Reason { get { throw null; } }
        public static System.ServiceModel.FaultException CreateFault(System.ServiceModel.Channels.MessageFault messageFault, string action, params System.Type[] faultDetailTypes) { throw null; }
        public static System.ServiceModel.FaultException CreateFault(System.ServiceModel.Channels.MessageFault messageFault, params System.Type[] faultDetailTypes) { throw null; }
        public virtual System.ServiceModel.Channels.MessageFault CreateMessageFault() { throw null; }
    }
    public partial class FaultException<TDetail> : System.ServiceModel.FaultException
    {
        public FaultException(TDetail detail, System.ServiceModel.FaultReason reason, System.ServiceModel.FaultCode code, string action) { }
        public TDetail Detail { get { throw null; } }
        public override System.ServiceModel.Channels.MessageFault CreateMessageFault() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FaultReason
    {
        public FaultReason(System.Collections.Generic.IEnumerable<System.ServiceModel.FaultReasonText> translations) { }
        public FaultReason(System.ServiceModel.FaultReasonText translation) { }
        public FaultReason(string text) { }
        public System.ServiceModel.FaultReasonText GetMatchingTranslation() { throw null; }
        public System.ServiceModel.FaultReasonText GetMatchingTranslation(System.Globalization.CultureInfo cultureInfo) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FaultReasonText
    {
        public FaultReasonText(string text) { }
        public FaultReasonText(string text, string xmlLang) { }
        public string Text { get { throw null; } }
        public string XmlLang { get { throw null; } }
        public bool Matches(System.Globalization.CultureInfo cultureInfo) { throw null; }
    }
    public partial interface IClientChannel : System.IDisposable, System.ServiceModel.Channels.IChannel, System.ServiceModel.ICommunicationObject, System.ServiceModel.IContextChannel, System.ServiceModel.IExtensibleObject<System.ServiceModel.IContextChannel>
    {
        bool AllowInitializationUI { get; set; }
        bool DidInteractiveInitialization { get; }
        System.Uri Via { get; }
        event System.EventHandler<System.ServiceModel.UnknownMessageReceivedEventArgs> UnknownMessageReceived;
        System.IAsyncResult BeginDisplayInitializationUI(System.AsyncCallback callback, object state);
        void DisplayInitializationUI();
        void EndDisplayInitializationUI(System.IAsyncResult result);
    }
    public partial interface ICommunicationObject
    {
        System.ServiceModel.CommunicationState State { get; }
        event System.EventHandler Closed;
        event System.EventHandler Closing;
        event System.EventHandler Faulted;
        event System.EventHandler Opened;
        event System.EventHandler Opening;
        void Abort();
        System.IAsyncResult BeginClose(System.AsyncCallback callback, object state);
        System.IAsyncResult BeginClose(System.TimeSpan timeout, System.AsyncCallback callback, object state);
        System.IAsyncResult BeginOpen(System.AsyncCallback callback, object state);
        System.IAsyncResult BeginOpen(System.TimeSpan timeout, System.AsyncCallback callback, object state);
        void Close();
        void Close(System.TimeSpan timeout);
        void EndClose(System.IAsyncResult result);
        void EndOpen(System.IAsyncResult result);
        void Open();
        void Open(System.TimeSpan timeout);
    }
    public partial interface IContextChannel : System.ServiceModel.Channels.IChannel, System.ServiceModel.ICommunicationObject, System.ServiceModel.IExtensibleObject<System.ServiceModel.IContextChannel>
    {
        bool AllowOutputBatching { get; set; }
        System.ServiceModel.Channels.IInputSession InputSession { get; }
        System.ServiceModel.EndpointAddress LocalAddress { get; }
        System.TimeSpan OperationTimeout { get; set; }
        System.ServiceModel.Channels.IOutputSession OutputSession { get; }
        System.ServiceModel.EndpointAddress RemoteAddress { get; }
        string SessionId { get; }
    }
    public partial interface IDefaultCommunicationTimeouts
    {
        System.TimeSpan CloseTimeout { get; }
        System.TimeSpan OpenTimeout { get; }
        System.TimeSpan ReceiveTimeout { get; }
        System.TimeSpan SendTimeout { get; }
    }
    public partial interface IExtensibleObject<T> where T : System.ServiceModel.IExtensibleObject<T>
    {
        System.ServiceModel.IExtensionCollection<T> Extensions { get; }
    }
    public partial interface IExtensionCollection<T> : System.Collections.Generic.ICollection<System.ServiceModel.IExtension<T>>, System.Collections.Generic.IEnumerable<System.ServiceModel.IExtension<T>>, System.Collections.IEnumerable where T : System.ServiceModel.IExtensibleObject<T>
    {
        System.Collections.ObjectModel.Collection<E> FindAll<E>();
        E Find<E>();
    }
    public partial interface IExtension<T> where T : System.ServiceModel.IExtensibleObject<T>
    {
        void Attach(T owner);
        void Detach(T owner);
    }
    public partial class InvalidMessageContractException : System.Exception
    {
        public InvalidMessageContractException() { }
        public InvalidMessageContractException(string message) { }
        public InvalidMessageContractException(string message, System.Exception innerException) { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), Inherited=false)]
    public partial class MessageBodyMemberAttribute : System.ServiceModel.MessageContractMemberAttribute
    {
        public MessageBodyMemberAttribute() { }
        public int Order { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(12), AllowMultiple=false)]
    public sealed partial class MessageContractAttribute : System.Attribute
    {
        public MessageContractAttribute() { }
        public bool IsWrapped { get { throw null; } set { } }
        public string WrapperName { get { throw null; } set { } }
        public string WrapperNamespace { get { throw null; } set { } }
    }
    public abstract partial class MessageContractMemberAttribute : System.Attribute
    {
        protected MessageContractMemberAttribute() { }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
    }
    public enum MessageCredentialType
    {
        Certificate = 3,
        IssuedToken = 4,
        None = 0,
        UserName = 2,
        Windows = 1,
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(384), AllowMultiple=false, Inherited=false)]
    public partial class MessageHeaderAttribute : System.ServiceModel.MessageContractMemberAttribute
    {
        public MessageHeaderAttribute() { }
        public bool MustUnderstand { get { throw null; } set { } }
    }
    public partial class MessageHeaderException : System.ServiceModel.ProtocolException
    {
        public MessageHeaderException(string message) : base (default(string)) { }
        public MessageHeaderException(string message, bool isDuplicate) : base (default(string)) { }
        public MessageHeaderException(string message, System.Exception innerException) : base (default(string)) { }
        public MessageHeaderException(string message, string headerName, string ns) : base (default(string)) { }
        public MessageHeaderException(string message, string headerName, string ns, bool isDuplicate) : base (default(string)) { }
        public MessageHeaderException(string message, string headerName, string ns, bool isDuplicate, System.Exception innerException) : base (default(string)) { }
        public MessageHeaderException(string message, string headerName, string ns, System.Exception innerException) : base (default(string)) { }
        public string HeaderName { get { throw null; } }
        public string HeaderNamespace { get { throw null; } }
        public bool IsDuplicate { get { throw null; } }
    }
    public partial class MessageHeader<T>
    {
        public MessageHeader() { }
        public MessageHeader(T content) { }
        public MessageHeader(T content, bool mustUnderstand, string actor, bool relay) { }
        public string Actor { get { throw null; } set { } }
        public T Content { get { throw null; } set { } }
        public bool MustUnderstand { get { throw null; } set { } }
        public bool Relay { get { throw null; } set { } }
        public System.ServiceModel.Channels.MessageHeader GetUntypedHeader(string name, string ns) { throw null; }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(10240), Inherited=false)]
    public sealed partial class MessageParameterAttribute : System.Attribute
    {
        public MessageParameterAttribute() { }
        public string Name { get { throw null; } set { } }
    }
    public sealed partial class OperationContext : System.ServiceModel.IExtensibleObject<System.ServiceModel.OperationContext>
    {
        public OperationContext(System.ServiceModel.IContextChannel channel) { }
        public static System.ServiceModel.OperationContext Current { get { throw null; } set { } }
        public System.ServiceModel.IExtensionCollection<System.ServiceModel.OperationContext> Extensions { get { throw null; } }
        public System.ServiceModel.Channels.MessageHeaders IncomingMessageHeaders { get { throw null; } }
        public System.ServiceModel.Channels.MessageProperties IncomingMessageProperties { get { throw null; } }
        public System.ServiceModel.Channels.MessageVersion IncomingMessageVersion { get { throw null; } }
        public bool IsUserContext { get { throw null; } }
        public System.ServiceModel.Channels.MessageHeaders OutgoingMessageHeaders { get { throw null; } }
        public System.ServiceModel.Channels.MessageProperties OutgoingMessageProperties { get { throw null; } }
        public System.ServiceModel.Channels.RequestContext RequestContext { get { throw null; } set { } }
        public event System.EventHandler OperationCompleted { add { } remove { } }
    }
    public sealed partial class OperationContextScope : System.IDisposable
    {
        public OperationContextScope(System.ServiceModel.IContextChannel channel) { }
        public OperationContextScope(System.ServiceModel.OperationContext context) { }
        public void Dispose() { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(64))]
    public sealed partial class OperationContractAttribute : System.Attribute
    {
        public OperationContractAttribute() { }
        public string Action { get { throw null; } set { } }
        public bool AsyncPattern { get { throw null; } set { } }
        public bool IsOneWay { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ReplyAction { get { throw null; } set { } }
    }
    public enum OperationFormatStyle
    {
        Document = 0,
        Rpc = 1,
    }
    public partial class ProtocolException : System.ServiceModel.CommunicationException
    {
        public ProtocolException(string message) { }
        public ProtocolException(string message, System.Exception innerException) { }
    }
    public partial class QuotaExceededException : System.Exception
    {
        public QuotaExceededException(string message) { }
        public QuotaExceededException(string message, System.Exception innerException) { }
    }
    public enum SecurityMode
    {
        Message = 2,
        None = 0,
        Transport = 1,
        TransportWithMessageCredential = 3,
    }
    public partial class ServerTooBusyException : System.ServiceModel.CommunicationException
    {
        public ServerTooBusyException(string message) { }
        public ServerTooBusyException(string message, System.Exception innerException) { }
    }
    public partial class ServiceActivationException : System.ServiceModel.CommunicationException
    {
        public ServiceActivationException(string message) { }
        public ServiceActivationException(string message, System.Exception innerException) { }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1028), Inherited=false, AllowMultiple=false)]
    public sealed partial class ServiceContractAttribute : System.Attribute
    {
        public ServiceContractAttribute() { }
        public System.Type CallbackContract { get { throw null; } set { } }
        public string ConfigurationName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1092), Inherited=true, AllowMultiple=true)]
    public sealed partial class ServiceKnownTypeAttribute : System.Attribute
    {
        public ServiceKnownTypeAttribute(string methodName) { }
        public ServiceKnownTypeAttribute(string methodName, System.Type declaringType) { }
        public ServiceKnownTypeAttribute(System.Type type) { }
        public System.Type DeclaringType { get { throw null; } }
        public string MethodName { get { throw null; } }
        public System.Type Type { get { throw null; } }
    }
    public enum TransferMode
    {
        Buffered = 0,
        Streamed = 1,
        StreamedRequest = 2,
        StreamedResponse = 3,
    }
    public sealed partial class UnknownMessageReceivedEventArgs : System.EventArgs
    {
        internal UnknownMessageReceivedEventArgs() { }
        public System.ServiceModel.Channels.Message Message { get { throw null; } }
    }
    [System.AttributeUsageAttribute((System.AttributeTargets)(1092), Inherited=false, AllowMultiple=false)]
    public sealed partial class XmlSerializerFormatAttribute : System.Attribute
    {
        public XmlSerializerFormatAttribute() { }
        public System.ServiceModel.OperationFormatStyle Style { get { throw null; } set { } }
        public bool SupportFaults { get { throw null; } set { } }
    }
}
namespace System.ServiceModel.Channels
{
    public abstract partial class AddressHeader
    {
        protected AddressHeader() { }
        public abstract string Name { get; }
        public abstract string Namespace { get; }
        public static System.ServiceModel.Channels.AddressHeader CreateAddressHeader(string name, string ns, object value) { throw null; }
        public static System.ServiceModel.Channels.AddressHeader CreateAddressHeader(string name, string ns, object value, System.Runtime.Serialization.XmlObjectSerializer serializer) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public virtual System.Xml.XmlDictionaryReader GetAddressHeaderReader() { throw null; }
        public override int GetHashCode() { throw null; }
        public T GetValue<T>() { throw null; }
        public T GetValue<T>(System.Runtime.Serialization.XmlObjectSerializer serializer) { throw null; }
        protected abstract void OnWriteAddressHeaderContents(System.Xml.XmlDictionaryWriter writer);
        protected virtual void OnWriteStartAddressHeader(System.Xml.XmlDictionaryWriter writer) { }
        public System.ServiceModel.Channels.MessageHeader ToMessageHeader() { throw null; }
        public void WriteAddressHeader(System.Xml.XmlDictionaryWriter writer) { }
        public void WriteAddressHeader(System.Xml.XmlWriter writer) { }
        public void WriteAddressHeaderContents(System.Xml.XmlDictionaryWriter writer) { }
        public void WriteStartAddressHeader(System.Xml.XmlDictionaryWriter writer) { }
    }
    public sealed partial class AddressHeaderCollection : System.Collections.ObjectModel.ReadOnlyCollection<System.ServiceModel.Channels.AddressHeader>
    {
        public AddressHeaderCollection() : base (default(System.Collections.Generic.IList<System.ServiceModel.Channels.AddressHeader>)) { }
        public AddressHeaderCollection(System.Collections.Generic.IEnumerable<System.ServiceModel.Channels.AddressHeader> addressHeaders) : base (default(System.Collections.Generic.IList<System.ServiceModel.Channels.AddressHeader>)) { }
        public void AddHeadersTo(System.ServiceModel.Channels.Message message) { }
        public System.ServiceModel.Channels.AddressHeader[] FindAll(string name, string ns) { throw null; }
        public System.ServiceModel.Channels.AddressHeader FindHeader(string name, string ns) { throw null; }
    }
    public sealed partial class AddressingVersion
    {
        internal AddressingVersion() { }
        public static System.ServiceModel.Channels.AddressingVersion None { get { throw null; } }
        public static System.ServiceModel.Channels.AddressingVersion WSAddressing10 { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public sealed partial class BinaryMessageEncodingBindingElement : System.ServiceModel.Channels.MessageEncodingBindingElement
    {
        public BinaryMessageEncodingBindingElement() { }
        [System.ComponentModel.DefaultValueAttribute((System.ServiceModel.Channels.CompressionFormat)(0))]
        public System.ServiceModel.Channels.CompressionFormat CompressionFormat { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(2048)]
        public int MaxSessionSize { get { throw null; } set { } }
        public override System.ServiceModel.Channels.MessageVersion MessageVersion { get { throw null; } set { } }
        public System.Xml.XmlDictionaryReaderQuotas ReaderQuotas { get { throw null; } set { } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override System.ServiceModel.Channels.MessageEncoderFactory CreateMessageEncoderFactory() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public abstract partial class Binding : System.ServiceModel.IDefaultCommunicationTimeouts
    {
        protected Binding() { }
        protected Binding(string name, string ns) { }
        [System.ComponentModel.DefaultValueAttribute(typeof(System.TimeSpan), "00:01:00")]
        public System.TimeSpan CloseTimeout { get { throw null; } set { } }
        public System.ServiceModel.Channels.MessageVersion MessageVersion { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(typeof(System.TimeSpan), "00:01:00")]
        public System.TimeSpan OpenTimeout { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(typeof(System.TimeSpan), "00:10:00")]
        public System.TimeSpan ReceiveTimeout { get { throw null; } set { } }
        public abstract string Scheme { get; }
        [System.ComponentModel.DefaultValueAttribute(typeof(System.TimeSpan), "00:01:00")]
        public System.TimeSpan SendTimeout { get { throw null; } set { } }
        public System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(params object[] parameters) { throw null; }
        public virtual System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingParameterCollection parameters) { throw null; }
        public bool CanBuildChannelFactory<TChannel>(params object[] parameters) { throw null; }
        public virtual bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingParameterCollection parameters) { throw null; }
        public abstract System.ServiceModel.Channels.BindingElementCollection CreateBindingElements();
        public T GetProperty<T>(System.ServiceModel.Channels.BindingParameterCollection parameters) where T : class { throw null; }
    }
    public partial class BindingContext
    {
        public BindingContext(System.ServiceModel.Channels.CustomBinding binding, System.ServiceModel.Channels.BindingParameterCollection parameters) { }
        public System.ServiceModel.Channels.CustomBinding Binding { get { throw null; } }
        public System.ServiceModel.Channels.BindingParameterCollection BindingParameters { get { throw null; } }
        public System.ServiceModel.Channels.BindingElementCollection RemainingBindingElements { get { throw null; } }
        public System.ServiceModel.Channels.IChannelFactory<TChannel> BuildInnerChannelFactory<TChannel>() { throw null; }
        public bool CanBuildInnerChannelFactory<TChannel>() { throw null; }
        public System.ServiceModel.Channels.BindingContext Clone() { throw null; }
        public T GetInnerProperty<T>() where T : class { throw null; }
    }
    public abstract partial class BindingElement
    {
        protected BindingElement() { }
        protected BindingElement(System.ServiceModel.Channels.BindingElement elementToBeCloned) { }
        public virtual System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public virtual bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public abstract System.ServiceModel.Channels.BindingElement Clone();
        public abstract T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) where T : class;
    }
    public partial class BindingElementCollection : System.Collections.ObjectModel.Collection<System.ServiceModel.Channels.BindingElement>
    {
        public BindingElementCollection() { }
        public BindingElementCollection(System.Collections.Generic.IEnumerable<System.ServiceModel.Channels.BindingElement> elements) { }
        public BindingElementCollection(System.ServiceModel.Channels.BindingElement[] elements) { }
        public void AddRange(params System.ServiceModel.Channels.BindingElement[] elements) { }
        public System.ServiceModel.Channels.BindingElementCollection Clone() { throw null; }
        public bool Contains(System.Type bindingElementType) { throw null; }
        public System.Collections.ObjectModel.Collection<T> FindAll<T>() { throw null; }
        public T Find<T>() { throw null; }
        protected override void InsertItem(int index, System.ServiceModel.Channels.BindingElement item) { }
        public System.Collections.ObjectModel.Collection<T> RemoveAll<T>() { throw null; }
        public T Remove<T>() { throw null; }
        protected override void SetItem(int index, System.ServiceModel.Channels.BindingElement item) { }
    }
    public partial class BindingParameterCollection : System.Collections.ObjectModel.KeyedCollection<System.Type, object>
    {
        public BindingParameterCollection() { }
        protected override System.Type GetKeyForItem(object item) { throw null; }
        protected override void InsertItem(int index, object item) { }
        protected override void SetItem(int index, object item) { }
    }
    public abstract partial class BodyWriter
    {
        protected BodyWriter(bool isBuffered) { }
        public bool IsBuffered { get { throw null; } }
        public System.ServiceModel.Channels.BodyWriter CreateBufferedCopy(int maxBufferSize) { throw null; }
        protected virtual System.ServiceModel.Channels.BodyWriter OnCreateBufferedCopy(int maxBufferSize) { throw null; }
        protected abstract void OnWriteBodyContents(System.Xml.XmlDictionaryWriter writer);
        public void WriteBodyContents(System.Xml.XmlDictionaryWriter writer) { }
    }
    public abstract partial class BufferManager
    {
        protected BufferManager() { }
        public abstract void Clear();
        public static System.ServiceModel.Channels.BufferManager CreateBufferManager(long maxBufferPoolSize, int maxBufferSize) { throw null; }
        public abstract void ReturnBuffer(byte[] buffer);
        public abstract byte[] TakeBuffer(int bufferSize);
    }
    public abstract partial class ChannelBase : System.ServiceModel.Channels.CommunicationObject, System.ServiceModel.Channels.IChannel, System.ServiceModel.ICommunicationObject, System.ServiceModel.IDefaultCommunicationTimeouts
    {
        protected ChannelBase(System.ServiceModel.Channels.ChannelManagerBase channelManager) { }
        protected override System.TimeSpan DefaultCloseTimeout { get { throw null; } }
        protected override System.TimeSpan DefaultOpenTimeout { get { throw null; } }
        protected System.TimeSpan DefaultReceiveTimeout { get { throw null; } }
        protected System.TimeSpan DefaultSendTimeout { get { throw null; } }
        protected System.ServiceModel.Channels.ChannelManagerBase Manager { get { throw null; } }
        System.TimeSpan System.ServiceModel.IDefaultCommunicationTimeouts.CloseTimeout { get { throw null; } }
        System.TimeSpan System.ServiceModel.IDefaultCommunicationTimeouts.OpenTimeout { get { throw null; } }
        System.TimeSpan System.ServiceModel.IDefaultCommunicationTimeouts.ReceiveTimeout { get { throw null; } }
        System.TimeSpan System.ServiceModel.IDefaultCommunicationTimeouts.SendTimeout { get { throw null; } }
        public virtual T GetProperty<T>() where T : class { throw null; }
        protected override void OnClosed() { }
    }
    public abstract partial class ChannelFactoryBase : System.ServiceModel.Channels.ChannelManagerBase, System.ServiceModel.Channels.IChannelFactory, System.ServiceModel.ICommunicationObject
    {
        protected ChannelFactoryBase() { }
        protected ChannelFactoryBase(System.ServiceModel.IDefaultCommunicationTimeouts timeouts) { }
        protected override System.TimeSpan DefaultCloseTimeout { get { throw null; } }
        protected override System.TimeSpan DefaultOpenTimeout { get { throw null; } }
        protected override System.TimeSpan DefaultReceiveTimeout { get { throw null; } }
        protected override System.TimeSpan DefaultSendTimeout { get { throw null; } }
        public virtual T GetProperty<T>() where T : class { throw null; }
        protected override void OnAbort() { }
        protected override System.IAsyncResult OnBeginClose(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        protected override void OnClose(System.TimeSpan timeout) { }
        protected override void OnEndClose(System.IAsyncResult result) { }
    }
    public abstract partial class ChannelFactoryBase<TChannel> : System.ServiceModel.Channels.ChannelFactoryBase, System.ServiceModel.Channels.IChannelFactory, System.ServiceModel.Channels.IChannelFactory<TChannel>, System.ServiceModel.ICommunicationObject
    {
        protected ChannelFactoryBase() { }
        protected ChannelFactoryBase(System.ServiceModel.IDefaultCommunicationTimeouts timeouts) { }
        public TChannel CreateChannel(System.ServiceModel.EndpointAddress address) { throw null; }
        public TChannel CreateChannel(System.ServiceModel.EndpointAddress address, System.Uri via) { throw null; }
        protected override void OnAbort() { }
        protected override System.IAsyncResult OnBeginClose(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        protected override void OnClose(System.TimeSpan timeout) { }
        protected abstract TChannel OnCreateChannel(System.ServiceModel.EndpointAddress address, System.Uri via);
        protected override void OnEndClose(System.IAsyncResult result) { }
        protected void ValidateCreateChannel() { }
    }
    public abstract partial class ChannelManagerBase : System.ServiceModel.Channels.CommunicationObject, System.ServiceModel.IDefaultCommunicationTimeouts
    {
        protected ChannelManagerBase() { }
        protected abstract System.TimeSpan DefaultReceiveTimeout { get; }
        protected abstract System.TimeSpan DefaultSendTimeout { get; }
        System.TimeSpan System.ServiceModel.IDefaultCommunicationTimeouts.CloseTimeout { get { throw null; } }
        System.TimeSpan System.ServiceModel.IDefaultCommunicationTimeouts.OpenTimeout { get { throw null; } }
        System.TimeSpan System.ServiceModel.IDefaultCommunicationTimeouts.ReceiveTimeout { get { throw null; } }
        System.TimeSpan System.ServiceModel.IDefaultCommunicationTimeouts.SendTimeout { get { throw null; } }
    }
    public partial class ChannelParameterCollection : System.Collections.ObjectModel.Collection<object>
    {
        public ChannelParameterCollection() { }
        public ChannelParameterCollection(System.ServiceModel.Channels.IChannel channel) { }
        protected virtual System.ServiceModel.Channels.IChannel Channel { get { throw null; } }
        protected override void ClearItems() { }
        protected override void InsertItem(int index, object item) { }
        public void PropagateChannelParameters(System.ServiceModel.Channels.IChannel innerChannel) { }
        protected override void RemoveItem(int index) { }
        protected override void SetItem(int index, object item) { }
    }
    public abstract partial class CommunicationObject : System.ServiceModel.ICommunicationObject
    {
        protected CommunicationObject() { }
        protected CommunicationObject(object mutex) { }
        protected abstract System.TimeSpan DefaultCloseTimeout { get; }
        protected abstract System.TimeSpan DefaultOpenTimeout { get; }
        protected bool IsDisposed { get { throw null; } }
        public System.ServiceModel.CommunicationState State { get { throw null; } }
        protected object ThisLock { get { throw null; } }
        public event System.EventHandler Closed { add { } remove { } }
        public event System.EventHandler Closing { add { } remove { } }
        public event System.EventHandler Faulted { add { } remove { } }
        public event System.EventHandler Opened { add { } remove { } }
        public event System.EventHandler Opening { add { } remove { } }
        public void Abort() { }
        public System.IAsyncResult BeginClose(System.AsyncCallback callback, object state) { throw null; }
        public System.IAsyncResult BeginClose(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        public System.IAsyncResult BeginOpen(System.AsyncCallback callback, object state) { throw null; }
        public System.IAsyncResult BeginOpen(System.TimeSpan timeout, System.AsyncCallback callback, object state) { throw null; }
        public void Close() { }
        public void Close(System.TimeSpan timeout) { }
        public void EndClose(System.IAsyncResult result) { }
        public void EndOpen(System.IAsyncResult result) { }
        protected void Fault() { }
        protected virtual System.Type GetCommunicationObjectType() { throw null; }
        protected abstract void OnAbort();
        protected abstract System.IAsyncResult OnBeginClose(System.TimeSpan timeout, System.AsyncCallback callback, object state);
        protected abstract System.IAsyncResult OnBeginOpen(System.TimeSpan timeout, System.AsyncCallback callback, object state);
        protected abstract void OnClose(System.TimeSpan timeout);
        protected virtual void OnClosed() { }
        protected virtual void OnClosing() { }
        protected abstract void OnEndClose(System.IAsyncResult result);
        protected abstract void OnEndOpen(System.IAsyncResult result);
        protected virtual void OnFaulted() { }
        protected abstract void OnOpen(System.TimeSpan timeout);
        protected virtual void OnOpened() { }
        protected virtual void OnOpening() { }
        public void Open() { }
        public void Open(System.TimeSpan timeout) { }
    }
    public enum CompressionFormat
    {
        Deflate = 2,
        GZip = 1,
        None = 0,
    }
    public partial class CustomBinding : System.ServiceModel.Channels.Binding
    {
        public CustomBinding() { }
        public CustomBinding(System.Collections.Generic.IEnumerable<System.ServiceModel.Channels.BindingElement> bindingElementsInTopDownChannelStackOrder) { }
        public CustomBinding(System.ServiceModel.Channels.Binding binding) { }
        public CustomBinding(params System.ServiceModel.Channels.BindingElement[] bindingElementsInTopDownChannelStackOrder) { }
        public CustomBinding(string name, string ns, params System.ServiceModel.Channels.BindingElement[] bindingElementsInTopDownChannelStackOrder) { }
        public System.ServiceModel.Channels.BindingElementCollection Elements { get { throw null; } }
        public override string Scheme { get { throw null; } }
        public override System.ServiceModel.Channels.BindingElementCollection CreateBindingElements() { throw null; }
    }
    public abstract partial class FaultConverter
    {
        protected FaultConverter() { }
        public static System.ServiceModel.Channels.FaultConverter GetDefaultFaultConverter(System.ServiceModel.Channels.MessageVersion version) { throw null; }
        protected abstract bool OnTryCreateException(System.ServiceModel.Channels.Message message, System.ServiceModel.Channels.MessageFault fault, out System.Exception exception);
        protected abstract bool OnTryCreateFaultMessage(System.Exception exception, out System.ServiceModel.Channels.Message message);
        public bool TryCreateException(System.ServiceModel.Channels.Message message, System.ServiceModel.Channels.MessageFault fault, out System.Exception exception) { exception = default(System.Exception); throw null; }
    }
    public partial interface IChannel : System.ServiceModel.ICommunicationObject
    {
        T GetProperty<T>() where T : class;
    }
    public partial interface IChannelFactory : System.ServiceModel.ICommunicationObject
    {
        T GetProperty<T>() where T : class;
    }
    public partial interface IChannelFactory<TChannel> : System.ServiceModel.Channels.IChannelFactory, System.ServiceModel.ICommunicationObject
    {
        TChannel CreateChannel(System.ServiceModel.EndpointAddress to);
        TChannel CreateChannel(System.ServiceModel.EndpointAddress to, System.Uri via);
    }
    public partial interface IDuplexChannel : System.ServiceModel.Channels.IChannel, System.ServiceModel.Channels.IInputChannel, System.ServiceModel.Channels.IOutputChannel, System.ServiceModel.ICommunicationObject
    {
    }
    public partial interface IDuplexSession : System.ServiceModel.Channels.IInputSession, System.ServiceModel.Channels.IOutputSession, System.ServiceModel.Channels.ISession
    {
        System.IAsyncResult BeginCloseOutputSession(System.AsyncCallback callback, object state);
        System.IAsyncResult BeginCloseOutputSession(System.TimeSpan timeout, System.AsyncCallback callback, object state);
        void CloseOutputSession();
        void CloseOutputSession(System.TimeSpan timeout);
        void EndCloseOutputSession(System.IAsyncResult result);
    }
    public partial interface IDuplexSessionChannel : System.ServiceModel.Channels.IChannel, System.ServiceModel.Channels.IDuplexChannel, System.ServiceModel.Channels.IInputChannel, System.ServiceModel.Channels.IOutputChannel, System.ServiceModel.Channels.ISessionChannel<System.ServiceModel.Channels.IDuplexSession>, System.ServiceModel.ICommunicationObject
    {
    }
    public partial interface IInputChannel : System.ServiceModel.Channels.IChannel, System.ServiceModel.ICommunicationObject
    {
        System.ServiceModel.EndpointAddress LocalAddress { get; }
        System.IAsyncResult BeginReceive(System.AsyncCallback callback, object state);
        System.IAsyncResult BeginReceive(System.TimeSpan timeout, System.AsyncCallback callback, object state);
        System.IAsyncResult BeginTryReceive(System.TimeSpan timeout, System.AsyncCallback callback, object state);
        System.IAsyncResult BeginWaitForMessage(System.TimeSpan timeout, System.AsyncCallback callback, object state);
        System.ServiceModel.Channels.Message EndReceive(System.IAsyncResult result);
        bool EndTryReceive(System.IAsyncResult result, out System.ServiceModel.Channels.Message message);
        bool EndWaitForMessage(System.IAsyncResult result);
        System.ServiceModel.Channels.Message Receive();
        System.ServiceModel.Channels.Message Receive(System.TimeSpan timeout);
        bool TryReceive(System.TimeSpan timeout, out System.ServiceModel.Channels.Message message);
        bool WaitForMessage(System.TimeSpan timeout);
    }
    public partial interface IInputSession : System.ServiceModel.Channels.ISession
    {
    }
    public partial interface IInputSessionChannel : System.ServiceModel.Channels.IChannel, System.ServiceModel.Channels.IInputChannel, System.ServiceModel.Channels.ISessionChannel<System.ServiceModel.Channels.IInputSession>, System.ServiceModel.ICommunicationObject
    {
    }
    public partial interface IMessageProperty
    {
        System.ServiceModel.Channels.IMessageProperty CreateCopy();
    }
    public partial interface IOutputChannel : System.ServiceModel.Channels.IChannel, System.ServiceModel.ICommunicationObject
    {
        System.ServiceModel.EndpointAddress RemoteAddress { get; }
        System.Uri Via { get; }
        System.IAsyncResult BeginSend(System.ServiceModel.Channels.Message message, System.AsyncCallback callback, object state);
        System.IAsyncResult BeginSend(System.ServiceModel.Channels.Message message, System.TimeSpan timeout, System.AsyncCallback callback, object state);
        void EndSend(System.IAsyncResult result);
        void Send(System.ServiceModel.Channels.Message message);
        void Send(System.ServiceModel.Channels.Message message, System.TimeSpan timeout);
    }
    public partial interface IOutputSession : System.ServiceModel.Channels.ISession
    {
    }
    public partial interface IOutputSessionChannel : System.ServiceModel.Channels.IChannel, System.ServiceModel.Channels.IOutputChannel, System.ServiceModel.Channels.ISessionChannel<System.ServiceModel.Channels.IOutputSession>, System.ServiceModel.ICommunicationObject
    {
    }
    public partial interface IRequestChannel : System.ServiceModel.Channels.IChannel, System.ServiceModel.ICommunicationObject
    {
        System.ServiceModel.EndpointAddress RemoteAddress { get; }
        System.Uri Via { get; }
        System.IAsyncResult BeginRequest(System.ServiceModel.Channels.Message message, System.AsyncCallback callback, object state);
        System.IAsyncResult BeginRequest(System.ServiceModel.Channels.Message message, System.TimeSpan timeout, System.AsyncCallback callback, object state);
        System.ServiceModel.Channels.Message EndRequest(System.IAsyncResult result);
        System.ServiceModel.Channels.Message Request(System.ServiceModel.Channels.Message message);
        System.ServiceModel.Channels.Message Request(System.ServiceModel.Channels.Message message, System.TimeSpan timeout);
    }
    public partial interface IRequestSessionChannel : System.ServiceModel.Channels.IChannel, System.ServiceModel.Channels.IRequestChannel, System.ServiceModel.Channels.ISessionChannel<System.ServiceModel.Channels.IOutputSession>, System.ServiceModel.ICommunicationObject
    {
    }
    public partial interface ISession
    {
        string Id { get; }
    }
    public partial interface ISessionChannel<TSession> where TSession : System.ServiceModel.Channels.ISession
    {
        TSession Session { get; }
    }
    public abstract partial class Message : System.IDisposable
    {
        protected Message() { }
        public abstract System.ServiceModel.Channels.MessageHeaders Headers { get; }
        protected bool IsDisposed { get { throw null; } }
        public virtual bool IsEmpty { get { throw null; } }
        public virtual bool IsFault { get { throw null; } }
        public abstract System.ServiceModel.Channels.MessageProperties Properties { get; }
        public System.ServiceModel.Channels.MessageState State { get { throw null; } }
        public abstract System.ServiceModel.Channels.MessageVersion Version { get; }
        public void Close() { }
        public System.ServiceModel.Channels.MessageBuffer CreateBufferedCopy(int maxBufferSize) { throw null; }
        public static System.ServiceModel.Channels.Message CreateMessage(System.ServiceModel.Channels.MessageVersion version, string action) { throw null; }
        public static System.ServiceModel.Channels.Message CreateMessage(System.ServiceModel.Channels.MessageVersion version, string action, object body) { throw null; }
        public static System.ServiceModel.Channels.Message CreateMessage(System.ServiceModel.Channels.MessageVersion version, string action, object body, System.Runtime.Serialization.XmlObjectSerializer serializer) { throw null; }
        public static System.ServiceModel.Channels.Message CreateMessage(System.ServiceModel.Channels.MessageVersion version, string action, System.ServiceModel.Channels.BodyWriter body) { throw null; }
        public static System.ServiceModel.Channels.Message CreateMessage(System.ServiceModel.Channels.MessageVersion version, string action, System.Xml.XmlDictionaryReader body) { throw null; }
        public static System.ServiceModel.Channels.Message CreateMessage(System.ServiceModel.Channels.MessageVersion version, string action, System.Xml.XmlReader body) { throw null; }
        public static System.ServiceModel.Channels.Message CreateMessage(System.Xml.XmlDictionaryReader envelopeReader, int maxSizeOfHeaders, System.ServiceModel.Channels.MessageVersion version) { throw null; }
        public static System.ServiceModel.Channels.Message CreateMessage(System.Xml.XmlReader envelopeReader, int maxSizeOfHeaders, System.ServiceModel.Channels.MessageVersion version) { throw null; }
        public string GetBodyAttribute(string localName, string ns) { throw null; }
        public T GetBody<T>() { throw null; }
        public T GetBody<T>(System.Runtime.Serialization.XmlObjectSerializer serializer) { throw null; }
        public System.Xml.XmlDictionaryReader GetReaderAtBodyContents() { throw null; }
        protected virtual void OnBodyToString(System.Xml.XmlDictionaryWriter writer) { }
        protected virtual void OnClose() { }
        protected virtual System.ServiceModel.Channels.MessageBuffer OnCreateBufferedCopy(int maxBufferSize) { throw null; }
        protected virtual string OnGetBodyAttribute(string localName, string ns) { throw null; }
        protected virtual T OnGetBody<T>(System.Xml.XmlDictionaryReader reader) { throw null; }
        protected virtual System.Xml.XmlDictionaryReader OnGetReaderAtBodyContents() { throw null; }
        protected abstract void OnWriteBodyContents(System.Xml.XmlDictionaryWriter writer);
        protected virtual void OnWriteMessage(System.Xml.XmlDictionaryWriter writer) { }
        protected virtual void OnWriteStartBody(System.Xml.XmlDictionaryWriter writer) { }
        protected virtual void OnWriteStartEnvelope(System.Xml.XmlDictionaryWriter writer) { }
        protected virtual void OnWriteStartHeaders(System.Xml.XmlDictionaryWriter writer) { }
        void System.IDisposable.Dispose() { }
        public override string ToString() { throw null; }
        public void WriteBody(System.Xml.XmlDictionaryWriter writer) { }
        public void WriteBody(System.Xml.XmlWriter writer) { }
        public void WriteBodyContents(System.Xml.XmlDictionaryWriter writer) { }
        public void WriteMessage(System.Xml.XmlDictionaryWriter writer) { }
        public void WriteMessage(System.Xml.XmlWriter writer) { }
        public void WriteStartBody(System.Xml.XmlDictionaryWriter writer) { }
        public void WriteStartBody(System.Xml.XmlWriter writer) { }
        public void WriteStartEnvelope(System.Xml.XmlDictionaryWriter writer) { }
    }
    public abstract partial class MessageBuffer : System.IDisposable
    {
        protected MessageBuffer() { }
        public abstract int BufferSize { get; }
        public virtual string MessageContentType { get { throw null; } }
        public abstract void Close();
        public abstract System.ServiceModel.Channels.Message CreateMessage();
        void System.IDisposable.Dispose() { }
        public virtual void WriteMessage(System.IO.Stream stream) { }
    }
    public abstract partial class MessageEncoder
    {
        protected MessageEncoder() { }
        public abstract string ContentType { get; }
        public abstract string MediaType { get; }
        public abstract System.ServiceModel.Channels.MessageVersion MessageVersion { get; }
        public virtual T GetProperty<T>() where T : class { throw null; }
        public virtual bool IsContentTypeSupported(string contentType) { throw null; }
        public System.ServiceModel.Channels.Message ReadMessage(System.ArraySegment<byte> buffer, System.ServiceModel.Channels.BufferManager bufferManager) { throw null; }
        public abstract System.ServiceModel.Channels.Message ReadMessage(System.ArraySegment<byte> buffer, System.ServiceModel.Channels.BufferManager bufferManager, string contentType);
        public System.ServiceModel.Channels.Message ReadMessage(System.IO.Stream stream, int maxSizeOfHeaders) { throw null; }
        public abstract System.ServiceModel.Channels.Message ReadMessage(System.IO.Stream stream, int maxSizeOfHeaders, string contentType);
        public override string ToString() { throw null; }
        public System.ArraySegment<byte> WriteMessage(System.ServiceModel.Channels.Message message, int maxMessageSize, System.ServiceModel.Channels.BufferManager bufferManager) { throw null; }
        public abstract System.ArraySegment<byte> WriteMessage(System.ServiceModel.Channels.Message message, int maxMessageSize, System.ServiceModel.Channels.BufferManager bufferManager, int messageOffset);
        public abstract void WriteMessage(System.ServiceModel.Channels.Message message, System.IO.Stream stream);
    }
    public abstract partial class MessageEncoderFactory
    {
        protected MessageEncoderFactory() { }
        public abstract System.ServiceModel.Channels.MessageEncoder Encoder { get; }
        public abstract System.ServiceModel.Channels.MessageVersion MessageVersion { get; }
        public virtual System.ServiceModel.Channels.MessageEncoder CreateSessionEncoder() { throw null; }
    }
    public abstract partial class MessageEncodingBindingElement : System.ServiceModel.Channels.BindingElement
    {
        protected MessageEncodingBindingElement() { }
        protected MessageEncodingBindingElement(System.ServiceModel.Channels.MessageEncodingBindingElement elementToBeCloned) { }
        public abstract System.ServiceModel.Channels.MessageVersion MessageVersion { get; set; }
        public abstract System.ServiceModel.Channels.MessageEncoderFactory CreateMessageEncoderFactory();
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public abstract partial class MessageFault
    {
        protected MessageFault() { }
        public virtual string Actor { get { throw null; } }
        public abstract System.ServiceModel.FaultCode Code { get; }
        public abstract bool HasDetail { get; }
        public virtual string Node { get { throw null; } }
        public abstract System.ServiceModel.FaultReason Reason { get; }
        public static System.ServiceModel.Channels.MessageFault CreateFault(System.ServiceModel.Channels.Message message, int maxBufferSize) { throw null; }
        public T GetDetail<T>() { throw null; }
        public T GetDetail<T>(System.Runtime.Serialization.XmlObjectSerializer serializer) { throw null; }
        public System.Xml.XmlDictionaryReader GetReaderAtDetailContents() { throw null; }
        protected virtual System.Xml.XmlDictionaryReader OnGetReaderAtDetailContents() { throw null; }
        protected virtual void OnWriteDetail(System.Xml.XmlDictionaryWriter writer, System.ServiceModel.EnvelopeVersion version) { }
        protected abstract void OnWriteDetailContents(System.Xml.XmlDictionaryWriter writer);
        protected virtual void OnWriteStartDetail(System.Xml.XmlDictionaryWriter writer, System.ServiceModel.EnvelopeVersion version) { }
    }
    public abstract partial class MessageHeader : System.ServiceModel.Channels.MessageHeaderInfo
    {
        protected MessageHeader() { }
        public override string Actor { get { throw null; } }
        public override bool IsReferenceParameter { get { throw null; } }
        public override bool MustUnderstand { get { throw null; } }
        public override bool Relay { get { throw null; } }
        public static System.ServiceModel.Channels.MessageHeader CreateHeader(string name, string ns, object value) { throw null; }
        public static System.ServiceModel.Channels.MessageHeader CreateHeader(string name, string ns, object value, bool mustUnderstand) { throw null; }
        public static System.ServiceModel.Channels.MessageHeader CreateHeader(string name, string ns, object value, bool mustUnderstand, string actor) { throw null; }
        public static System.ServiceModel.Channels.MessageHeader CreateHeader(string name, string ns, object value, bool mustUnderstand, string actor, bool relay) { throw null; }
        public static System.ServiceModel.Channels.MessageHeader CreateHeader(string name, string ns, object value, System.Runtime.Serialization.XmlObjectSerializer serializer) { throw null; }
        public static System.ServiceModel.Channels.MessageHeader CreateHeader(string name, string ns, object value, System.Runtime.Serialization.XmlObjectSerializer serializer, bool mustUnderstand) { throw null; }
        public static System.ServiceModel.Channels.MessageHeader CreateHeader(string name, string ns, object value, System.Runtime.Serialization.XmlObjectSerializer serializer, bool mustUnderstand, string actor) { throw null; }
        public static System.ServiceModel.Channels.MessageHeader CreateHeader(string name, string ns, object value, System.Runtime.Serialization.XmlObjectSerializer serializer, bool mustUnderstand, string actor, bool relay) { throw null; }
        public virtual bool IsMessageVersionSupported(System.ServiceModel.Channels.MessageVersion messageVersion) { throw null; }
        protected abstract void OnWriteHeaderContents(System.Xml.XmlDictionaryWriter writer, System.ServiceModel.Channels.MessageVersion messageVersion);
        protected virtual void OnWriteStartHeader(System.Xml.XmlDictionaryWriter writer, System.ServiceModel.Channels.MessageVersion messageVersion) { }
        public override string ToString() { throw null; }
        public void WriteHeader(System.Xml.XmlDictionaryWriter writer, System.ServiceModel.Channels.MessageVersion messageVersion) { }
        public void WriteHeader(System.Xml.XmlWriter writer, System.ServiceModel.Channels.MessageVersion messageVersion) { }
        protected void WriteHeaderAttributes(System.Xml.XmlDictionaryWriter writer, System.ServiceModel.Channels.MessageVersion messageVersion) { }
        public void WriteHeaderContents(System.Xml.XmlDictionaryWriter writer, System.ServiceModel.Channels.MessageVersion messageVersion) { }
        public void WriteStartHeader(System.Xml.XmlDictionaryWriter writer, System.ServiceModel.Channels.MessageVersion messageVersion) { }
    }
    public abstract partial class MessageHeaderInfo
    {
        protected MessageHeaderInfo() { }
        public abstract string Actor { get; }
        public abstract bool IsReferenceParameter { get; }
        public abstract bool MustUnderstand { get; }
        public abstract string Name { get; }
        public abstract string Namespace { get; }
        public abstract bool Relay { get; }
    }
    public sealed partial class MessageHeaders : System.Collections.Generic.IEnumerable<System.ServiceModel.Channels.MessageHeaderInfo>, System.Collections.IEnumerable
    {
        public MessageHeaders(System.ServiceModel.Channels.MessageHeaders collection) { }
        public MessageHeaders(System.ServiceModel.Channels.MessageVersion version) { }
        public MessageHeaders(System.ServiceModel.Channels.MessageVersion version, int initialSize) { }
        public string Action { get { throw null; } set { } }
        public int Count { get { throw null; } }
        public System.ServiceModel.EndpointAddress FaultTo { get { throw null; } set { } }
        public System.ServiceModel.EndpointAddress From { get { throw null; } set { } }
        public System.ServiceModel.Channels.MessageHeaderInfo this[int index] { get { throw null; } }
        public System.Xml.UniqueId MessageId { get { throw null; } set { } }
        public System.ServiceModel.Channels.MessageVersion MessageVersion { get { throw null; } }
        public System.Xml.UniqueId RelatesTo { get { throw null; } set { } }
        public System.ServiceModel.EndpointAddress ReplyTo { get { throw null; } set { } }
        public System.Uri To { get { throw null; } set { } }
        public void Add(System.ServiceModel.Channels.MessageHeader header) { }
        public void Clear() { }
        public void CopyHeaderFrom(System.ServiceModel.Channels.Message message, int headerIndex) { }
        public void CopyHeaderFrom(System.ServiceModel.Channels.MessageHeaders collection, int headerIndex) { }
        public void CopyHeadersFrom(System.ServiceModel.Channels.Message message) { }
        public void CopyHeadersFrom(System.ServiceModel.Channels.MessageHeaders collection) { }
        public void CopyTo(System.ServiceModel.Channels.MessageHeaderInfo[] array, int index) { }
        public int FindHeader(string name, string ns) { throw null; }
        public int FindHeader(string name, string ns, params string[] actors) { throw null; }
        public System.Collections.Generic.IEnumerator<System.ServiceModel.Channels.MessageHeaderInfo> GetEnumerator() { throw null; }
        public T GetHeader<T>(int index) { throw null; }
        public T GetHeader<T>(int index, System.Runtime.Serialization.XmlObjectSerializer serializer) { throw null; }
        public T GetHeader<T>(string name, string ns) { throw null; }
        public T GetHeader<T>(string name, string ns, System.Runtime.Serialization.XmlObjectSerializer serializer) { throw null; }
        public T GetHeader<T>(string name, string ns, params string[] actors) { throw null; }
        public System.Xml.XmlDictionaryReader GetReaderAtHeader(int headerIndex) { throw null; }
        public bool HaveMandatoryHeadersBeenUnderstood() { throw null; }
        public bool HaveMandatoryHeadersBeenUnderstood(params string[] actors) { throw null; }
        public void Insert(int headerIndex, System.ServiceModel.Channels.MessageHeader header) { }
        public void RemoveAll(string name, string ns) { }
        public void RemoveAt(int headerIndex) { }
        public void SetAction(System.Xml.XmlDictionaryString action) { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public void WriteHeader(int headerIndex, System.Xml.XmlDictionaryWriter writer) { }
        public void WriteHeader(int headerIndex, System.Xml.XmlWriter writer) { }
        public void WriteHeaderContents(int headerIndex, System.Xml.XmlDictionaryWriter writer) { }
        public void WriteHeaderContents(int headerIndex, System.Xml.XmlWriter writer) { }
        public void WriteStartHeader(int headerIndex, System.Xml.XmlDictionaryWriter writer) { }
        public void WriteStartHeader(int headerIndex, System.Xml.XmlWriter writer) { }
    }
    public sealed partial class MessageProperties : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable, System.IDisposable
    {
        public MessageProperties() { }
        public MessageProperties(System.ServiceModel.Channels.MessageProperties properties) { }
        public bool AllowOutputBatching { get { throw null; } set { } }
        public int Count { get { throw null; } }
        public System.ServiceModel.Channels.MessageEncoder Encoder { get { throw null; } set { } }
        public bool IsFixedSize { get { throw null; } }
        public object this[string name] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public System.Uri Via { get { throw null; } set { } }
        public void Add(string name, object property) { }
        public void Clear() { }
        public bool ContainsKey(string name) { throw null; }
        public void CopyProperties(System.ServiceModel.Channels.MessageProperties properties) { }
        public void Dispose() { }
        public bool Remove(string name) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> pair) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> pair) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] array, int index) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> pair) { throw null; }
        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string name, out object value) { value = default(object); throw null; }
    }
    public enum MessageState
    {
        Closed = 4,
        Copied = 3,
        Created = 0,
        Read = 1,
        Written = 2,
    }
    public sealed partial class MessageVersion
    {
        internal MessageVersion() { }
        public System.ServiceModel.Channels.AddressingVersion Addressing { get { throw null; } }
        public static System.ServiceModel.Channels.MessageVersion Default { get { throw null; } }
        public System.ServiceModel.EnvelopeVersion Envelope { get { throw null; } }
        public static System.ServiceModel.Channels.MessageVersion None { get { throw null; } }
        public static System.ServiceModel.Channels.MessageVersion Soap11 { get { throw null; } }
        public static System.ServiceModel.Channels.MessageVersion Soap12WSAddressing10 { get { throw null; } }
        public static System.ServiceModel.Channels.MessageVersion CreateVersion(System.ServiceModel.EnvelopeVersion envelopeVersion) { throw null; }
        public static System.ServiceModel.Channels.MessageVersion CreateVersion(System.ServiceModel.EnvelopeVersion envelopeVersion, System.ServiceModel.Channels.AddressingVersion addressingVersion) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RequestContext : System.IDisposable
    {
        protected RequestContext() { }
        public abstract System.ServiceModel.Channels.Message RequestMessage { get; }
        public abstract void Abort();
        public abstract System.IAsyncResult BeginReply(System.ServiceModel.Channels.Message message, System.AsyncCallback callback, object state);
        public abstract System.IAsyncResult BeginReply(System.ServiceModel.Channels.Message message, System.TimeSpan timeout, System.AsyncCallback callback, object state);
        public abstract void Close();
        public abstract void Close(System.TimeSpan timeout);
        protected virtual void Dispose(bool disposing) { }
        public abstract void EndReply(System.IAsyncResult result);
        public abstract void Reply(System.ServiceModel.Channels.Message message);
        public abstract void Reply(System.ServiceModel.Channels.Message message, System.TimeSpan timeout);
        void System.IDisposable.Dispose() { }
    }
    public sealed partial class TextMessageEncodingBindingElement : System.ServiceModel.Channels.MessageEncodingBindingElement
    {
        public TextMessageEncodingBindingElement() { }
        public TextMessageEncodingBindingElement(System.ServiceModel.Channels.MessageVersion messageVersion, System.Text.Encoding writeEncoding) { }
        public override System.ServiceModel.Channels.MessageVersion MessageVersion { get { throw null; } set { } }
        public System.Xml.XmlDictionaryReaderQuotas ReaderQuotas { get { throw null; } set { } }
        public System.Text.Encoding WriteEncoding { get { throw null; } set { } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override System.ServiceModel.Channels.MessageEncoderFactory CreateMessageEncoderFactory() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
    public abstract partial class TransportBindingElement : System.ServiceModel.Channels.BindingElement
    {
        protected TransportBindingElement() { }
        protected TransportBindingElement(System.ServiceModel.Channels.TransportBindingElement elementToBeCloned) { }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public virtual bool ManualAddressing { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute((long)65536)]
        public virtual long MaxReceivedMessageSize { get { throw null; } set { } }
        public abstract string Scheme { get; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
}
namespace System.ServiceModel.Description
{
    public partial class ClientCredentials : System.ServiceModel.Description.IEndpointBehavior
    {
        public ClientCredentials() { }
        protected ClientCredentials(System.ServiceModel.Description.ClientCredentials other) { }
        public System.ServiceModel.Security.X509CertificateInitiatorClientCredential ClientCertificate { get { throw null; } }
        public System.ServiceModel.Security.HttpDigestClientCredential HttpDigest { get { throw null; } }
        public System.ServiceModel.Security.X509CertificateRecipientClientCredential ServiceCertificate { get { throw null; } }
        public System.ServiceModel.Security.UserNamePasswordClientCredential UserName { get { throw null; } }
        public System.ServiceModel.Security.WindowsClientCredential Windows { get { throw null; } }
        public virtual void ApplyClientBehavior(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Dispatcher.ClientRuntime behavior) { }
        public System.ServiceModel.Description.ClientCredentials Clone() { throw null; }
        protected virtual System.ServiceModel.Description.ClientCredentials CloneCore() { throw null; }
        void System.ServiceModel.Description.IEndpointBehavior.AddBindingParameters(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters) { }
        void System.ServiceModel.Description.IEndpointBehavior.ApplyDispatchBehavior(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher) { }
        void System.ServiceModel.Description.IEndpointBehavior.Validate(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint) { }
    }
    public partial class ContractDescription
    {
        public ContractDescription(string name) { }
        public ContractDescription(string name, string ns) { }
        public System.Type CallbackContractType { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(null)]
        public string ConfigurationName { get { throw null; } set { } }
        public System.Collections.ObjectModel.KeyedCollection<System.Type, System.ServiceModel.Description.IContractBehavior> ContractBehaviors { get { throw null; } }
        public System.Type ContractType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public System.ServiceModel.Description.OperationDescriptionCollection Operations { get { throw null; } }
    }
    public partial class DataContractSerializerOperationBehavior : System.ServiceModel.Description.IOperationBehavior
    {
        public DataContractSerializerOperationBehavior(System.ServiceModel.Description.OperationDescription operation) { }
        public DataContractSerializerOperationBehavior(System.ServiceModel.Description.OperationDescription operation, System.ServiceModel.DataContractFormatAttribute dataContractFormatAttribute) { }
        public System.ServiceModel.DataContractFormatAttribute DataContractFormatAttribute { get { throw null; } }
        public System.Runtime.Serialization.DataContractResolver DataContractResolver { get { throw null; } set { } }
        public int MaxItemsInObjectGraph { get { throw null; } set { } }
        public virtual System.Runtime.Serialization.XmlObjectSerializer CreateSerializer(System.Type type, string name, string ns, System.Collections.Generic.IList<System.Type> knownTypes) { throw null; }
        public virtual System.Runtime.Serialization.XmlObjectSerializer CreateSerializer(System.Type type, System.Xml.XmlDictionaryString name, System.Xml.XmlDictionaryString ns, System.Collections.Generic.IList<System.Type> knownTypes) { throw null; }
        void System.ServiceModel.Description.IOperationBehavior.AddBindingParameters(System.ServiceModel.Description.OperationDescription description, System.ServiceModel.Channels.BindingParameterCollection parameters) { }
        void System.ServiceModel.Description.IOperationBehavior.ApplyClientBehavior(System.ServiceModel.Description.OperationDescription description, System.ServiceModel.Dispatcher.ClientOperation proxy) { }
        void System.ServiceModel.Description.IOperationBehavior.ApplyDispatchBehavior(System.ServiceModel.Description.OperationDescription description, System.ServiceModel.Dispatcher.DispatchOperation dispatch) { }
        void System.ServiceModel.Description.IOperationBehavior.Validate(System.ServiceModel.Description.OperationDescription description) { }
    }
    public partial class FaultDescription
    {
        public FaultDescription(string action) { }
        public string Action { get { throw null; } }
        public System.Type DetailType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
    }
    public partial class FaultDescriptionCollection : System.Collections.ObjectModel.Collection<System.ServiceModel.Description.FaultDescription>
    {
        internal FaultDescriptionCollection() { }
    }
    public partial interface IContractBehavior
    {
        void AddBindingParameters(System.ServiceModel.Description.ContractDescription contractDescription, System.ServiceModel.Description.ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters);
        void ApplyClientBehavior(System.ServiceModel.Description.ContractDescription contractDescription, System.ServiceModel.Description.ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime);
        void ApplyDispatchBehavior(System.ServiceModel.Description.ContractDescription contractDescription, System.ServiceModel.Description.ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime);
        void Validate(System.ServiceModel.Description.ContractDescription contractDescription, System.ServiceModel.Description.ServiceEndpoint endpoint);
    }
    public partial interface IEndpointBehavior
    {
        void AddBindingParameters(System.ServiceModel.Description.ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters);
        void ApplyClientBehavior(System.ServiceModel.Description.ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime);
        void ApplyDispatchBehavior(System.ServiceModel.Description.ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher);
        void Validate(System.ServiceModel.Description.ServiceEndpoint endpoint);
    }
    public partial interface IOperationBehavior
    {
        void AddBindingParameters(System.ServiceModel.Description.OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters);
        void ApplyClientBehavior(System.ServiceModel.Description.OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation);
        void ApplyDispatchBehavior(System.ServiceModel.Description.OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation);
        void Validate(System.ServiceModel.Description.OperationDescription operationDescription);
    }
    public partial class MessageBodyDescription
    {
        public MessageBodyDescription() { }
        public System.ServiceModel.Description.MessagePartDescriptionCollection Parts { get { throw null; } }
        [System.ComponentModel.DefaultValueAttribute(null)]
        public System.ServiceModel.Description.MessagePartDescription ReturnValue { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(null)]
        public string WrapperName { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(null)]
        public string WrapperNamespace { get { throw null; } set { } }
    }
    public partial class MessageDescription
    {
        public MessageDescription(string action, System.ServiceModel.Description.MessageDirection direction) { }
        public string Action { get { throw null; } }
        public System.ServiceModel.Description.MessageBodyDescription Body { get { throw null; } }
        public System.ServiceModel.Description.MessageDirection Direction { get { throw null; } }
        public System.ServiceModel.Description.MessageHeaderDescriptionCollection Headers { get { throw null; } }
        [System.ComponentModel.DefaultValueAttribute(null)]
        public System.Type MessageType { get { throw null; } set { } }
        public System.ServiceModel.Description.MessagePropertyDescriptionCollection Properties { get { throw null; } }
    }
    public partial class MessageDescriptionCollection : System.Collections.ObjectModel.Collection<System.ServiceModel.Description.MessageDescription>
    {
        internal MessageDescriptionCollection() { }
        public System.ServiceModel.Description.MessageDescription Find(string action) { throw null; }
        public System.Collections.ObjectModel.Collection<System.ServiceModel.Description.MessageDescription> FindAll(string action) { throw null; }
    }
    public enum MessageDirection
    {
        Input = 0,
        Output = 1,
    }
    public partial class MessageHeaderDescription : System.ServiceModel.Description.MessagePartDescription
    {
        public MessageHeaderDescription(string name, string ns) : base (default(string), default(string)) { }
        [System.ComponentModel.DefaultValueAttribute(null)]
        public string Actor { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool MustUnderstand { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Relay { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool TypedHeader { get { throw null; } set { } }
    }
    public partial class MessageHeaderDescriptionCollection : System.Collections.ObjectModel.KeyedCollection<System.Xml.XmlQualifiedName, System.ServiceModel.Description.MessageHeaderDescription>
    {
        internal MessageHeaderDescriptionCollection() { }
        protected override System.Xml.XmlQualifiedName GetKeyForItem(System.ServiceModel.Description.MessageHeaderDescription item) { throw null; }
    }
    public partial class MessagePartDescription
    {
        public MessagePartDescription(string name, string ns) { }
        public int Index { get { throw null; } set { } }
        public System.Reflection.MemberInfo MemberInfo { get { throw null; } set { } }
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Multiple { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public System.Type Type { get { throw null; } set { } }
    }
    public partial class MessagePartDescriptionCollection : System.Collections.ObjectModel.KeyedCollection<System.Xml.XmlQualifiedName, System.ServiceModel.Description.MessagePartDescription>
    {
        internal MessagePartDescriptionCollection() { }
        protected override System.Xml.XmlQualifiedName GetKeyForItem(System.ServiceModel.Description.MessagePartDescription item) { throw null; }
    }
    public partial class MessagePropertyDescription : System.ServiceModel.Description.MessagePartDescription
    {
        public MessagePropertyDescription(string name) : base (default(string), default(string)) { }
    }
    public partial class MessagePropertyDescriptionCollection : System.Collections.ObjectModel.KeyedCollection<string, System.ServiceModel.Description.MessagePropertyDescription>
    {
        internal MessagePropertyDescriptionCollection() { }
        protected override string GetKeyForItem(System.ServiceModel.Description.MessagePropertyDescription item) { throw null; }
    }
    public partial class OperationDescription
    {
        public OperationDescription(string name, System.ServiceModel.Description.ContractDescription declaringContract) { }
        public System.ServiceModel.Description.ContractDescription DeclaringContract { get { throw null; } set { } }
        public System.ServiceModel.Description.FaultDescriptionCollection Faults { get { throw null; } }
        public bool IsOneWay { get { throw null; } }
        public System.Collections.ObjectModel.Collection<System.Type> KnownTypes { get { throw null; } }
        public System.ServiceModel.Description.MessageDescriptionCollection Messages { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.ObjectModel.KeyedCollection<System.Type, System.ServiceModel.Description.IOperationBehavior> OperationBehaviors { get { throw null; } }
        public System.Reflection.MethodInfo TaskMethod { get { throw null; } set { } }
    }
    public partial class OperationDescriptionCollection : System.Collections.ObjectModel.Collection<System.ServiceModel.Description.OperationDescription>
    {
        internal OperationDescriptionCollection() { }
        public System.ServiceModel.Description.OperationDescription Find(string name) { throw null; }
        public System.Collections.ObjectModel.Collection<System.ServiceModel.Description.OperationDescription> FindAll(string name) { throw null; }
        protected override void InsertItem(int index, System.ServiceModel.Description.OperationDescription item) { }
        protected override void SetItem(int index, System.ServiceModel.Description.OperationDescription item) { }
    }
    public partial class ServiceEndpoint
    {
        public ServiceEndpoint(System.ServiceModel.Description.ContractDescription contract) { }
        public ServiceEndpoint(System.ServiceModel.Description.ContractDescription contract, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress address) { }
        public System.ServiceModel.EndpointAddress Address { get { throw null; } set { } }
        public System.ServiceModel.Channels.Binding Binding { get { throw null; } set { } }
        public System.ServiceModel.Description.ContractDescription Contract { get { throw null; } set { } }
        public System.Collections.ObjectModel.KeyedCollection<System.Type, System.ServiceModel.Description.IEndpointBehavior> EndpointBehaviors { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
}
namespace System.ServiceModel.Dispatcher
{
    public sealed partial class ClientOperation
    {
        public ClientOperation(System.ServiceModel.Dispatcher.ClientRuntime parent, string name, string action) { }
        public ClientOperation(System.ServiceModel.Dispatcher.ClientRuntime parent, string name, string action, string replyAction) { }
        public string Action { get { throw null; } }
        public System.Collections.Generic.ICollection<System.ServiceModel.Dispatcher.IParameterInspector> ClientParameterInspectors { get { throw null; } }
        public bool DeserializeReply { get { throw null; } set { } }
        public System.ServiceModel.Dispatcher.IClientMessageFormatter Formatter { get { throw null; } set { } }
        public bool IsOneWay { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.ServiceModel.Dispatcher.ClientRuntime Parent { get { throw null; } }
        public string ReplyAction { get { throw null; } }
        public bool SerializeRequest { get { throw null; } set { } }
        public System.Reflection.MethodInfo TaskMethod { get { throw null; } set { } }
        public System.Type TaskTResult { get { throw null; } set { } }
    }
    public sealed partial class ClientRuntime
    {
        internal ClientRuntime() { }
        public System.Collections.Generic.ICollection<System.ServiceModel.Dispatcher.IClientMessageInspector> ClientMessageInspectors { get { throw null; } }
        public System.Collections.Generic.ICollection<System.ServiceModel.Dispatcher.ClientOperation> ClientOperations { get { throw null; } }
        public System.Type ContractClientType { get { throw null; } set { } }
        public string ContractName { get { throw null; } }
        public string ContractNamespace { get { throw null; } }
        public bool ManualAddressing { get { throw null; } set { } }
        public int MaxFaultSize { get { throw null; } set { } }
        public System.ServiceModel.Dispatcher.IClientOperationSelector OperationSelector { get { throw null; } set { } }
        public System.ServiceModel.Dispatcher.ClientOperation UnhandledClientOperation { get { throw null; } }
        public System.Uri Via { get { throw null; } set { } }
    }
    public sealed partial class DispatchOperation
    {
        public DispatchOperation(System.ServiceModel.Dispatcher.DispatchRuntime parent, string name, string action) { }
        public string Action { get { throw null; } }
        public bool AutoDisposeParameters { get { throw null; } set { } }
        public bool DeserializeRequest { get { throw null; } set { } }
        public bool IsOneWay { get { throw null; } }
        public string Name { get { throw null; } }
        public System.ServiceModel.Dispatcher.DispatchRuntime Parent { get { throw null; } }
        public bool SerializeReply { get { throw null; } set { } }
    }
    public sealed partial class DispatchRuntime
    {
        internal DispatchRuntime() { }
    }
    public partial class EndpointDispatcher
    {
        internal EndpointDispatcher() { }
    }
    public partial interface IClientMessageFormatter
    {
        object DeserializeReply(System.ServiceModel.Channels.Message message, object[] parameters);
        System.ServiceModel.Channels.Message SerializeRequest(System.ServiceModel.Channels.MessageVersion messageVersion, object[] parameters);
    }
    public partial interface IClientMessageInspector
    {
        void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState);
        object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel);
    }
    public partial interface IClientOperationSelector
    {
        bool AreParametersRequiredForSelection { get; }
        string SelectOperation(System.Reflection.MethodBase method, object[] parameters);
    }
    public partial interface IParameterInspector
    {
        void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState);
        object BeforeCall(string operationName, object[] inputs);
    }
}
namespace System.ServiceModel.Security
{
    public sealed partial class HttpDigestClientCredential
    {
        internal HttpDigestClientCredential() { }
        public System.Net.NetworkCredential ClientCredential { get { throw null; } set { } }
    }
    public partial class MessageSecurityException : System.ServiceModel.CommunicationException
    {
        public MessageSecurityException(string message) { }
        public MessageSecurityException(string message, System.Exception innerException) { }
    }
    public partial class SecurityAccessDeniedException : System.ServiceModel.CommunicationException
    {
        public SecurityAccessDeniedException(string message) { }
        public SecurityAccessDeniedException(string message, System.Exception innerException) { }
    }
    public sealed partial class UserNamePasswordClientCredential
    {
        internal UserNamePasswordClientCredential() { }
        public string Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public sealed partial class WindowsClientCredential
    {
        internal WindowsClientCredential() { }
        public System.Security.Principal.TokenImpersonationLevel AllowedImpersonationLevel { get { throw null; } set { } }
        public System.Net.NetworkCredential ClientCredential { get { throw null; } set { } }
    }
    public sealed partial class X509CertificateInitiatorClientCredential
    {
        internal X509CertificateInitiatorClientCredential() { }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 Certificate { get { throw null; } set { } }
        public void SetCertificate(System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, System.Security.Cryptography.X509Certificates.StoreName storeName, System.Security.Cryptography.X509Certificates.X509FindType findType, object findValue) { }
        public void SetCertificate(string subjectName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, System.Security.Cryptography.X509Certificates.StoreName storeName) { }
    }
    public sealed partial class X509CertificateRecipientClientCredential
    {
        internal X509CertificateRecipientClientCredential() { }
        public System.ServiceModel.Security.X509ServiceCertificateAuthentication Authentication { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 DefaultCertificate { get { throw null; } set { } }
        public System.Collections.Generic.Dictionary<System.Uri, System.Security.Cryptography.X509Certificates.X509Certificate2> ScopedCertificates { get { throw null; } }
        public System.ServiceModel.Security.X509ServiceCertificateAuthentication SslCertificateAuthentication { get { throw null; } set { } }
        public void SetDefaultCertificate(System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, System.Security.Cryptography.X509Certificates.StoreName storeName, System.Security.Cryptography.X509Certificates.X509FindType findType, object findValue) { }
        public void SetDefaultCertificate(string subjectName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, System.Security.Cryptography.X509Certificates.StoreName storeName) { }
        public void SetScopedCertificate(System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, System.Security.Cryptography.X509Certificates.StoreName storeName, System.Security.Cryptography.X509Certificates.X509FindType findType, object findValue, System.Uri targetService) { }
        public void SetScopedCertificate(string subjectName, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation, System.Security.Cryptography.X509Certificates.StoreName storeName, System.Uri targetService) { }
    }
    public enum X509CertificateValidationMode
    {
        ChainTrust = 2,
        Custom = 4,
        None = 0,
        PeerOrChainTrust = 3,
        PeerTrust = 1,
    }
    public sealed partial class X509ServiceCertificateAuthentication
    {
        public X509ServiceCertificateAuthentication() { }
        public System.ServiceModel.Security.X509CertificateValidationMode CertificateValidationMode { get { throw null; } set { } }
        public System.IdentityModel.Selectors.X509CertificateValidator CustomCertificateValidator { get { throw null; } set { } }
        public System.Security.Cryptography.X509Certificates.X509RevocationMode RevocationMode { get { throw null; } set { } }
        public System.Security.Cryptography.X509Certificates.StoreLocation TrustedStoreLocation { get { throw null; } set { } }
    }
}
