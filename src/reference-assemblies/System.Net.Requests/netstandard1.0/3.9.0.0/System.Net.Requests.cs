[assembly:System.CLSCompliantAttribute(true)]
[assembly:System.Reflection.AssemblyCompanyAttribute("Microsoft Corporation")]
[assembly:System.Reflection.AssemblyCopyrightAttribute("© Microsoft Corporation.  All rights reserved.")]
[assembly:System.Reflection.AssemblyDefaultAliasAttribute("System.Net.Requests.dll")]
[assembly:System.Reflection.AssemblyDescriptionAttribute("System.Net.Requests.dll")]
[assembly:System.Reflection.AssemblyFileVersionAttribute("4.0.30319.17931")]
[assembly:System.Reflection.AssemblyInformationalVersionAttribute("4.0.30319.17931")]
[assembly:System.Reflection.AssemblyProductAttribute("Microsoft® .NET Framework")]
[assembly:System.Reflection.AssemblyTitleAttribute("System.Net.Requests.dll")]
[assembly:System.Runtime.CompilerServices.CompilationRelaxationsAttribute(8)]
[assembly:System.Runtime.CompilerServices.ReferenceAssemblyAttribute]
[assembly:System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows=true)]
namespace System.Net
{
    public enum HttpRequestHeader
    {
        Accept = 20,
        AcceptCharset = 21,
        AcceptEncoding = 22,
        AcceptLanguage = 23,
        Allow = 10,
        Authorization = 24,
        CacheControl = 0,
        Connection = 1,
        ContentEncoding = 13,
        ContentLanguage = 14,
        ContentLength = 11,
        ContentLocation = 15,
        ContentMd5 = 16,
        ContentRange = 17,
        ContentType = 12,
        Cookie = 25,
        Date = 2,
        Expect = 26,
        Expires = 18,
        From = 27,
        Host = 28,
        IfMatch = 29,
        IfModifiedSince = 30,
        IfNoneMatch = 31,
        IfRange = 32,
        IfUnmodifiedSince = 33,
        KeepAlive = 3,
        LastModified = 19,
        MaxForwards = 34,
        Pragma = 4,
        ProxyAuthorization = 35,
        Range = 37,
        Referer = 36,
        Te = 38,
        Trailer = 5,
        TransferEncoding = 6,
        Translate = 39,
        Upgrade = 7,
        UserAgent = 40,
        Via = 8,
        Warning = 9,
    }
    public partial class HttpWebRequest : System.Net.WebRequest
    {
        internal HttpWebRequest() { }
        public string Accept { get { throw null; } set { } }
        public virtual bool AllowReadStreamBuffering { get { throw null; } set { } }
        public override string ContentType { get { throw null; } set { } }
        public virtual System.Net.CookieContainer CookieContainer { get { throw null; } set { } }
        public override System.Net.ICredentials Credentials { get { throw null; } set { } }
        public virtual bool HaveResponse { get { throw null; } }
        public override System.Net.WebHeaderCollection Headers { get { throw null; } set { } }
        public override string Method { get { throw null; } set { } }
        public override System.Uri RequestUri { get { throw null; } }
        public virtual bool SupportsCookieContainer { get { throw null; } }
        public override void Abort() { }
        public override System.IAsyncResult BeginGetRequestStream(System.AsyncCallback callback, object state) { throw null; }
        public override System.IAsyncResult BeginGetResponse(System.AsyncCallback callback, object state) { throw null; }
        public override System.IO.Stream EndGetRequestStream(System.IAsyncResult asyncResult) { throw null; }
        public override System.Net.WebResponse EndGetResponse(System.IAsyncResult asyncResult) { throw null; }
        ~HttpWebRequest() { }
    }
    public partial class HttpWebResponse : System.Net.WebResponse, System.IDisposable
    {
        internal HttpWebResponse() { }
        public override long ContentLength { get { throw null; } }
        public override string ContentType { get { throw null; } }
        public virtual System.Net.CookieCollection Cookies { get { throw null; } }
        public override System.Net.WebHeaderCollection Headers { get { throw null; } }
        public virtual string Method { get { throw null; } }
        public override System.Uri ResponseUri { get { throw null; } }
        public virtual System.Net.HttpStatusCode StatusCode { get { throw null; } }
        public virtual string StatusDescription { get { throw null; } }
        protected virtual void Dispose(bool disposing) { }
        public override System.IO.Stream GetResponseStream() { throw null; }
        void System.IDisposable.Dispose() { }
    }
    public partial interface IWebRequestCreate
    {
        System.Net.WebRequest Create(System.Uri uri);
    }
    public partial class ProtocolViolationException : System.InvalidOperationException
    {
        public ProtocolViolationException() { }
        public ProtocolViolationException(string message) { }
    }
    public partial class WebException : System.InvalidOperationException
    {
        public WebException() { }
        public WebException(string message) { }
        public WebException(string message, System.Exception innerException) { }
        public WebException(string message, System.Exception inner, System.Net.WebExceptionStatus status, System.Net.WebResponse response) { }
        public WebException(string message, System.Net.WebExceptionStatus status) { }
        public System.Net.WebResponse Response { get { throw null; } }
        public System.Net.WebExceptionStatus Status { get { throw null; } }
    }
    public enum WebExceptionStatus
    {
        ConnectFailure = 2,
        MessageLengthLimitExceeded = 17,
        Pending = 13,
        RequestCanceled = 6,
        SendFailure = 4,
        Success = 0,
        UnknownError = 16,
    }
    public sealed partial class WebHeaderCollection : System.Collections.IEnumerable
    {
        public WebHeaderCollection() { }
        public string[] AllKeys { get { throw null; } }
        public int Count { get { throw null; } }
        public string this[System.Net.HttpRequestHeader header] { get { throw null; } set { } }
        public string this[string name] { get { throw null; } set { } }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class WebRequest
    {
        protected WebRequest() { }
        public abstract string ContentType { get; set; }
        public virtual System.Net.ICredentials Credentials { get { throw null; } set { } }
        public abstract System.Net.WebHeaderCollection Headers { get; set; }
        public abstract string Method { get; set; }
        public abstract System.Uri RequestUri { get; }
        public virtual bool UseDefaultCredentials { get { throw null; } set { } }
        public abstract void Abort();
        public abstract System.IAsyncResult BeginGetRequestStream(System.AsyncCallback callback, object state);
        public abstract System.IAsyncResult BeginGetResponse(System.AsyncCallback callback, object state);
        public static System.Net.WebRequest Create(string requestUriString) { throw null; }
        public static System.Net.WebRequest Create(System.Uri requestUri) { throw null; }
        public static System.Net.HttpWebRequest CreateHttp(string requestUriString) { throw null; }
        public static System.Net.HttpWebRequest CreateHttp(System.Uri requestUri) { throw null; }
        public abstract System.IO.Stream EndGetRequestStream(System.IAsyncResult asyncResult);
        public abstract System.Net.WebResponse EndGetResponse(System.IAsyncResult asyncResult);
        public static bool RegisterPrefix(string prefix, System.Net.IWebRequestCreate creator) { throw null; }
    }
    public abstract partial class WebResponse : System.IDisposable
    {
        protected WebResponse() { }
        public abstract long ContentLength { get; }
        public abstract string ContentType { get; }
        public virtual System.Net.WebHeaderCollection Headers { get { throw null; } }
        public abstract System.Uri ResponseUri { get; }
        public virtual bool SupportsHeaders { get { throw null; } }
        public void Dispose() { }
        public abstract System.IO.Stream GetResponseStream();
    }
}
