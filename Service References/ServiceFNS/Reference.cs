﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParametricDesignWFC.ServiceFNS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ws.unisoft", ConfigurationName="ServiceFNS.FNSNDSCAWS2_Port")]
    public interface FNSNDSCAWS2_Port {
        
        // CODEGEN: Generating message contract since the operation NdsRequest2 is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="NdsRequest2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ParametricDesignWFC.ServiceFNS.NdsRequest2Response NdsRequest2(ParametricDesignWFC.ServiceFNS.NdsRequest2Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="NdsRequest2", ReplyAction="*")]
        System.Threading.Tasks.Task<ParametricDesignWFC.ServiceFNS.NdsRequest2Response> NdsRequest2Async(ParametricDesignWFC.ServiceFNS.NdsRequest2Request request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://ws.unisoft/FNSNDSCAWS2/Request")]
    public partial class NdsRequest2NP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iNNField;
        
        private string kPPField;
        
        private string dtField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string INN {
            get {
                return this.iNNField;
            }
            set {
                this.iNNField = value;
                this.RaisePropertyChanged("INN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string KPP {
            get {
                return this.kPPField;
            }
            set {
                this.kPPField = value;
                this.RaisePropertyChanged("KPP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DT {
            get {
                return this.dtField;
            }
            set {
                this.dtField = value;
                this.RaisePropertyChanged("DT");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://ws.unisoft/FNSNDSCAWS2/Response")]
    public partial class NdsResponse2 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private NdsResponse2NP[] npField;
        
        private string dTActULField;
        
        private string dTActFLField;
        
        private string errMsgField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NP", Order=0)]
        public NdsResponse2NP[] NP {
            get {
                return this.npField;
            }
            set {
                this.npField = value;
                this.RaisePropertyChanged("NP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DTActUL {
            get {
                return this.dTActULField;
            }
            set {
                this.dTActULField = value;
                this.RaisePropertyChanged("DTActUL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DTActFL {
            get {
                return this.dTActFLField;
            }
            set {
                this.dTActFLField = value;
                this.RaisePropertyChanged("DTActFL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string errMsg {
            get {
                return this.errMsgField;
            }
            set {
                this.errMsgField = value;
                this.RaisePropertyChanged("errMsg");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://ws.unisoft/FNSNDSCAWS2/Response")]
    public partial class NdsResponse2NP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iNNField;
        
        private string kPPField;
        
        private string dtField;
        
        private NdsResponse2NPState stateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string INN {
            get {
                return this.iNNField;
            }
            set {
                this.iNNField = value;
                this.RaisePropertyChanged("INN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string KPP {
            get {
                return this.kPPField;
            }
            set {
                this.kPPField = value;
                this.RaisePropertyChanged("KPP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DT {
            get {
                return this.dtField;
            }
            set {
                this.dtField = value;
                this.RaisePropertyChanged("DT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public NdsResponse2NPState State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
                this.RaisePropertyChanged("State");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://ws.unisoft/FNSNDSCAWS2/Response")]
    public enum NdsResponse2NPState {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Item4,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("6")]
        Item6,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("7")]
        Item7,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("8")]
        Item8,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("9")]
        Item9,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class NdsRequest2Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.unisoft/FNSNDSCAWS2/Request", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("NP", IsNullable=false)]
        public ParametricDesignWFC.ServiceFNS.NdsRequest2NP[] NdsRequest2;
        
        public NdsRequest2Request() {
        }
        
        public NdsRequest2Request(ParametricDesignWFC.ServiceFNS.NdsRequest2NP[] NdsRequest2) {
            this.NdsRequest2 = NdsRequest2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class NdsRequest2Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.unisoft/FNSNDSCAWS2/Response", Order=0)]
        public ParametricDesignWFC.ServiceFNS.NdsResponse2 NdsResponse2;
        
        public NdsRequest2Response() {
        }
        
        public NdsRequest2Response(ParametricDesignWFC.ServiceFNS.NdsResponse2 NdsResponse2) {
            this.NdsResponse2 = NdsResponse2;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FNSNDSCAWS2_PortChannel : ParametricDesignWFC.ServiceFNS.FNSNDSCAWS2_Port, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FNSNDSCAWS2_PortClient : System.ServiceModel.ClientBase<ParametricDesignWFC.ServiceFNS.FNSNDSCAWS2_Port>, ParametricDesignWFC.ServiceFNS.FNSNDSCAWS2_Port {
        
        public FNSNDSCAWS2_PortClient() {
        }
        
        public FNSNDSCAWS2_PortClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FNSNDSCAWS2_PortClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FNSNDSCAWS2_PortClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FNSNDSCAWS2_PortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ParametricDesignWFC.ServiceFNS.NdsRequest2Response ParametricDesignWFC.ServiceFNS.FNSNDSCAWS2_Port.NdsRequest2(ParametricDesignWFC.ServiceFNS.NdsRequest2Request request) {
            return base.Channel.NdsRequest2(request);
        }
        
        public ParametricDesignWFC.ServiceFNS.NdsResponse2 NdsRequest2(ParametricDesignWFC.ServiceFNS.NdsRequest2NP[] NdsRequest21) {
            ParametricDesignWFC.ServiceFNS.NdsRequest2Request inValue = new ParametricDesignWFC.ServiceFNS.NdsRequest2Request();
            inValue.NdsRequest2 = NdsRequest21;
            ParametricDesignWFC.ServiceFNS.NdsRequest2Response retVal = ((ParametricDesignWFC.ServiceFNS.FNSNDSCAWS2_Port)(this)).NdsRequest2(inValue);
            return retVal.NdsResponse2;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ParametricDesignWFC.ServiceFNS.NdsRequest2Response> ParametricDesignWFC.ServiceFNS.FNSNDSCAWS2_Port.NdsRequest2Async(ParametricDesignWFC.ServiceFNS.NdsRequest2Request request) {
            return base.Channel.NdsRequest2Async(request);
        }
        
        public System.Threading.Tasks.Task<ParametricDesignWFC.ServiceFNS.NdsRequest2Response> NdsRequest2Async(ParametricDesignWFC.ServiceFNS.NdsRequest2NP[] NdsRequest2) {
            ParametricDesignWFC.ServiceFNS.NdsRequest2Request inValue = new ParametricDesignWFC.ServiceFNS.NdsRequest2Request();
            inValue.NdsRequest2 = NdsRequest2;
            return ((ParametricDesignWFC.ServiceFNS.FNSNDSCAWS2_Port)(this)).NdsRequest2Async(inValue);
        }
    }
}
