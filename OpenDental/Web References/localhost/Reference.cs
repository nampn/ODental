﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.235.
// 
#pragma warning disable 1591

namespace OpenDental.localhost {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://open-dent.com/")]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback EstablishConnectionOperationCompleted;
        
        private System.Threading.SendOrPostCallback RequestUpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback FeatureRequestGetListOperationCompleted;
        
        private System.Threading.SendOrPostCallback FeatureRequestGetOneOperationCompleted;
        
        private System.Threading.SendOrPostCallback FeatureRequestSubmitChangesOperationCompleted;
        
        private System.Threading.SendOrPostCallback FeatureRequestDiscussSubmitOperationCompleted;
        
        private System.Threading.SendOrPostCallback FeatureRequestDiscussGetListOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service1() {
            this.Url = "http://localhost:3824/Service1.asmx";
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
        public event EstablishConnectionCompletedEventHandler EstablishConnectionCompleted;
        
        /// <remarks/>
        public event RequestUpdateCompletedEventHandler RequestUpdateCompleted;
        
        /// <remarks/>
        public event FeatureRequestGetListCompletedEventHandler FeatureRequestGetListCompleted;
        
        /// <remarks/>
        public event FeatureRequestGetOneCompletedEventHandler FeatureRequestGetOneCompleted;
        
        /// <remarks/>
        public event FeatureRequestSubmitChangesCompletedEventHandler FeatureRequestSubmitChangesCompleted;
        
        /// <remarks/>
        public event FeatureRequestDiscussSubmitCompletedEventHandler FeatureRequestDiscussSubmitCompleted;
        
        /// <remarks/>
        public event FeatureRequestDiscussGetListCompletedEventHandler FeatureRequestDiscussGetListCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://open-dent.com/EstablishConnection", RequestNamespace="http://open-dent.com/", ResponseNamespace="http://open-dent.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string EstablishConnection() {
            object[] results = this.Invoke("EstablishConnection", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void EstablishConnectionAsync() {
            this.EstablishConnectionAsync(null);
        }
        
        /// <remarks/>
        public void EstablishConnectionAsync(object userState) {
            if ((this.EstablishConnectionOperationCompleted == null)) {
                this.EstablishConnectionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEstablishConnectionOperationCompleted);
            }
            this.InvokeAsync("EstablishConnection", new object[0], this.EstablishConnectionOperationCompleted, userState);
        }
        
        private void OnEstablishConnectionOperationCompleted(object arg) {
            if ((this.EstablishConnectionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EstablishConnectionCompleted(this, new EstablishConnectionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://open-dent.com/RequestUpdate", RequestNamespace="http://open-dent.com/", ResponseNamespace="http://open-dent.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RequestUpdate(string officeData) {
            object[] results = this.Invoke("RequestUpdate", new object[] {
                        officeData});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RequestUpdateAsync(string officeData) {
            this.RequestUpdateAsync(officeData, null);
        }
        
        /// <remarks/>
        public void RequestUpdateAsync(string officeData, object userState) {
            if ((this.RequestUpdateOperationCompleted == null)) {
                this.RequestUpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRequestUpdateOperationCompleted);
            }
            this.InvokeAsync("RequestUpdate", new object[] {
                        officeData}, this.RequestUpdateOperationCompleted, userState);
        }
        
        private void OnRequestUpdateOperationCompleted(object arg) {
            if ((this.RequestUpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RequestUpdateCompleted(this, new RequestUpdateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://open-dent.com/FeatureRequestGetList", RequestNamespace="http://open-dent.com/", ResponseNamespace="http://open-dent.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string FeatureRequestGetList(string officeData) {
            object[] results = this.Invoke("FeatureRequestGetList", new object[] {
                        officeData});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void FeatureRequestGetListAsync(string officeData) {
            this.FeatureRequestGetListAsync(officeData, null);
        }
        
        /// <remarks/>
        public void FeatureRequestGetListAsync(string officeData, object userState) {
            if ((this.FeatureRequestGetListOperationCompleted == null)) {
                this.FeatureRequestGetListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFeatureRequestGetListOperationCompleted);
            }
            this.InvokeAsync("FeatureRequestGetList", new object[] {
                        officeData}, this.FeatureRequestGetListOperationCompleted, userState);
        }
        
        private void OnFeatureRequestGetListOperationCompleted(object arg) {
            if ((this.FeatureRequestGetListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FeatureRequestGetListCompleted(this, new FeatureRequestGetListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://open-dent.com/FeatureRequestGetOne", RequestNamespace="http://open-dent.com/", ResponseNamespace="http://open-dent.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string FeatureRequestGetOne(string officeData) {
            object[] results = this.Invoke("FeatureRequestGetOne", new object[] {
                        officeData});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void FeatureRequestGetOneAsync(string officeData) {
            this.FeatureRequestGetOneAsync(officeData, null);
        }
        
        /// <remarks/>
        public void FeatureRequestGetOneAsync(string officeData, object userState) {
            if ((this.FeatureRequestGetOneOperationCompleted == null)) {
                this.FeatureRequestGetOneOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFeatureRequestGetOneOperationCompleted);
            }
            this.InvokeAsync("FeatureRequestGetOne", new object[] {
                        officeData}, this.FeatureRequestGetOneOperationCompleted, userState);
        }
        
        private void OnFeatureRequestGetOneOperationCompleted(object arg) {
            if ((this.FeatureRequestGetOneCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FeatureRequestGetOneCompleted(this, new FeatureRequestGetOneCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://open-dent.com/FeatureRequestSubmitChanges", RequestNamespace="http://open-dent.com/", ResponseNamespace="http://open-dent.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string FeatureRequestSubmitChanges(string officeData) {
            object[] results = this.Invoke("FeatureRequestSubmitChanges", new object[] {
                        officeData});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void FeatureRequestSubmitChangesAsync(string officeData) {
            this.FeatureRequestSubmitChangesAsync(officeData, null);
        }
        
        /// <remarks/>
        public void FeatureRequestSubmitChangesAsync(string officeData, object userState) {
            if ((this.FeatureRequestSubmitChangesOperationCompleted == null)) {
                this.FeatureRequestSubmitChangesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFeatureRequestSubmitChangesOperationCompleted);
            }
            this.InvokeAsync("FeatureRequestSubmitChanges", new object[] {
                        officeData}, this.FeatureRequestSubmitChangesOperationCompleted, userState);
        }
        
        private void OnFeatureRequestSubmitChangesOperationCompleted(object arg) {
            if ((this.FeatureRequestSubmitChangesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FeatureRequestSubmitChangesCompleted(this, new FeatureRequestSubmitChangesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://open-dent.com/FeatureRequestDiscussSubmit", RequestNamespace="http://open-dent.com/", ResponseNamespace="http://open-dent.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string FeatureRequestDiscussSubmit(string officeData) {
            object[] results = this.Invoke("FeatureRequestDiscussSubmit", new object[] {
                        officeData});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void FeatureRequestDiscussSubmitAsync(string officeData) {
            this.FeatureRequestDiscussSubmitAsync(officeData, null);
        }
        
        /// <remarks/>
        public void FeatureRequestDiscussSubmitAsync(string officeData, object userState) {
            if ((this.FeatureRequestDiscussSubmitOperationCompleted == null)) {
                this.FeatureRequestDiscussSubmitOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFeatureRequestDiscussSubmitOperationCompleted);
            }
            this.InvokeAsync("FeatureRequestDiscussSubmit", new object[] {
                        officeData}, this.FeatureRequestDiscussSubmitOperationCompleted, userState);
        }
        
        private void OnFeatureRequestDiscussSubmitOperationCompleted(object arg) {
            if ((this.FeatureRequestDiscussSubmitCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FeatureRequestDiscussSubmitCompleted(this, new FeatureRequestDiscussSubmitCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://open-dent.com/FeatureRequestDiscussGetList", RequestNamespace="http://open-dent.com/", ResponseNamespace="http://open-dent.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string FeatureRequestDiscussGetList(string officeData) {
            object[] results = this.Invoke("FeatureRequestDiscussGetList", new object[] {
                        officeData});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void FeatureRequestDiscussGetListAsync(string officeData) {
            this.FeatureRequestDiscussGetListAsync(officeData, null);
        }
        
        /// <remarks/>
        public void FeatureRequestDiscussGetListAsync(string officeData, object userState) {
            if ((this.FeatureRequestDiscussGetListOperationCompleted == null)) {
                this.FeatureRequestDiscussGetListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFeatureRequestDiscussGetListOperationCompleted);
            }
            this.InvokeAsync("FeatureRequestDiscussGetList", new object[] {
                        officeData}, this.FeatureRequestDiscussGetListOperationCompleted, userState);
        }
        
        private void OnFeatureRequestDiscussGetListOperationCompleted(object arg) {
            if ((this.FeatureRequestDiscussGetListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FeatureRequestDiscussGetListCompleted(this, new FeatureRequestDiscussGetListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void EstablishConnectionCompletedEventHandler(object sender, EstablishConnectionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EstablishConnectionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EstablishConnectionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void RequestUpdateCompletedEventHandler(object sender, RequestUpdateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RequestUpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RequestUpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void FeatureRequestGetListCompletedEventHandler(object sender, FeatureRequestGetListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FeatureRequestGetListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FeatureRequestGetListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void FeatureRequestGetOneCompletedEventHandler(object sender, FeatureRequestGetOneCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FeatureRequestGetOneCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FeatureRequestGetOneCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void FeatureRequestSubmitChangesCompletedEventHandler(object sender, FeatureRequestSubmitChangesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FeatureRequestSubmitChangesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FeatureRequestSubmitChangesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void FeatureRequestDiscussSubmitCompletedEventHandler(object sender, FeatureRequestDiscussSubmitCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FeatureRequestDiscussSubmitCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FeatureRequestDiscussSubmitCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void FeatureRequestDiscussGetListCompletedEventHandler(object sender, FeatureRequestDiscussGetListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FeatureRequestDiscussGetListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FeatureRequestDiscussGetListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591