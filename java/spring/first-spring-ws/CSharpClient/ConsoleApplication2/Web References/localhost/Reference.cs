﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.296 版自动生成。
// 
#pragma warning disable 1591

namespace ConsoleApplication2.localhost {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MyMathPortSoap11", Namespace="http://www.test.me/MyMath/")]
    public partial class MyMathServiceWse : Microsoft.Web.Services3.WebServicesClientProtocol {
        
        private System.Threading.SendOrPostCallback minusOperationCompleted;
        
        private System.Threading.SendOrPostCallback addOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MyMathServiceWse() {
            this.Url = global::ConsoleApplication2.Properties.Settings.Default.ConsoleApplication2_localhost_MyMathService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event minusCompletedEventHandler minusCompleted;
        
        /// <remarks/>
        public event addCompletedEventHandler addCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.test.me/MyMath/minus", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("minusResponse", Namespace="http://www.test.me/MyMath/")]
        public minusResponse minus([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.test.me/MyMath/")] minusRequest minusRequest) {
            object[] results = this.Invoke("minus", new object[] {
                        minusRequest});
            return ((minusResponse)(results[0]));
        }
        
        /// <remarks/>
        public void minusAsync(minusRequest minusRequest) {
            this.minusAsync(minusRequest, null);
        }
        
        /// <remarks/>
        public void minusAsync(minusRequest minusRequest, object userState) {
            if ((this.minusOperationCompleted == null)) {
                this.minusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnminusOperationCompleted);
            }
            this.InvokeAsync("minus", new object[] {
                        minusRequest}, this.minusOperationCompleted, userState);
        }
        
        private void OnminusOperationCompleted(object arg) {
            if ((this.minusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.minusCompleted(this, new minusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.test.me/MyMath/add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("addResponse", Namespace="http://www.test.me/MyMath/")]
        public addResponse add([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.test.me/MyMath/")] addRequest addRequest) {
            object[] results = this.Invoke("add", new object[] {
                        addRequest});
            return ((addResponse)(results[0]));
        }
        
        /// <remarks/>
        public void addAsync(addRequest addRequest) {
            this.addAsync(addRequest, null);
        }
        
        /// <remarks/>
        public void addAsync(addRequest addRequest, object userState) {
            if ((this.addOperationCompleted == null)) {
                this.addOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddOperationCompleted);
            }
            this.InvokeAsync("add", new object[] {
                        addRequest}, this.addOperationCompleted, userState);
        }
        
        private void OnaddOperationCompleted(object arg) {
            if ((this.addCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addCompleted(this, new addCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MyMathPortSoap11", Namespace="http://www.test.me/MyMath/")]
    public partial class MyMathService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback minusOperationCompleted;
        
        private System.Threading.SendOrPostCallback addOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MyMathService() {
            this.Url = global::ConsoleApplication2.Properties.Settings.Default.ConsoleApplication2_localhost_MyMathService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event minusCompletedEventHandler minusCompleted;
        
        /// <remarks/>
        public event addCompletedEventHandler addCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.test.me/MyMath/minus", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("minusResponse", Namespace="http://www.test.me/MyMath/")]
        public minusResponse minus([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.test.me/MyMath/")] minusRequest minusRequest) {
            object[] results = this.Invoke("minus", new object[] {
                        minusRequest});
            return ((minusResponse)(results[0]));
        }
        
        /// <remarks/>
        public void minusAsync(minusRequest minusRequest) {
            this.minusAsync(minusRequest, null);
        }
        
        /// <remarks/>
        public void minusAsync(minusRequest minusRequest, object userState) {
            if ((this.minusOperationCompleted == null)) {
                this.minusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnminusOperationCompleted);
            }
            this.InvokeAsync("minus", new object[] {
                        minusRequest}, this.minusOperationCompleted, userState);
        }
        
        private void OnminusOperationCompleted(object arg) {
            if ((this.minusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.minusCompleted(this, new minusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.test.me/MyMath/add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("addResponse", Namespace="http://www.test.me/MyMath/")]
        public addResponse add([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.test.me/MyMath/")] addRequest addRequest) {
            object[] results = this.Invoke("add", new object[] {
                        addRequest});
            return ((addResponse)(results[0]));
        }
        
        /// <remarks/>
        public void addAsync(addRequest addRequest) {
            this.addAsync(addRequest, null);
        }
        
        /// <remarks/>
        public void addAsync(addRequest addRequest, object userState) {
            if ((this.addOperationCompleted == null)) {
                this.addOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddOperationCompleted);
            }
            this.InvokeAsync("add", new object[] {
                        addRequest}, this.addOperationCompleted, userState);
        }
        
        private void OnaddOperationCompleted(object arg) {
            if ((this.addCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addCompleted(this, new addCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.test.me/MyMath/")]
    public partial class minusRequest {
        
        private int xField;
        
        private int yField;
        
        /// <remarks/>
        public int x {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }
        
        /// <remarks/>
        public int y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.test.me/MyMath/")]
    public partial class minusResponse {
        
        private int outField;
        
        /// <remarks/>
        public int @out {
            get {
                return this.outField;
            }
            set {
                this.outField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.test.me/MyMath/")]
    public partial class addRequest {
        
        private int xField;
        
        private int yField;
        
        /// <remarks/>
        public int x {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }
        
        /// <remarks/>
        public int y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.test.me/MyMath/")]
    public partial class addResponse {
        
        private int outField;
        
        /// <remarks/>
        public int @out {
            get {
                return this.outField;
            }
            set {
                this.outField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void minusCompletedEventHandler(object sender, minusCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class minusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal minusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public minusResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((minusResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void addCompletedEventHandler(object sender, addCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class addCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal addCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public addResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((addResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591