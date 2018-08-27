﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RaceManager.Client.DriverService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DriverDTO", Namespace="http://schemas.datacontract.org/2004/07/RaceManager.Server.Service.Core.DataTrans" +
        "ferObjects")]
    [System.SerializableAttribute()]
    public partial class DriverDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UMCNField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UMCN {
            get {
                return this.UMCNField;
            }
            set {
                if ((object.ReferenceEquals(this.UMCNField, value) != true)) {
                    this.UMCNField = value;
                    this.RaisePropertyChanged("UMCN");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DriverService.IDriverService")]
    public interface IDriverService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/Get", ReplyAction="http://tempuri.org/IDriverService/GetResponse")]
        RaceManager.Client.DriverService.DriverDTO Get(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/Get", ReplyAction="http://tempuri.org/IDriverService/GetResponse")]
        System.Threading.Tasks.Task<RaceManager.Client.DriverService.DriverDTO> GetAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/GetAll", ReplyAction="http://tempuri.org/IDriverService/GetAllResponse")]
        RaceManager.Client.DriverService.DriverDTO[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/GetAll", ReplyAction="http://tempuri.org/IDriverService/GetAllResponse")]
        System.Threading.Tasks.Task<RaceManager.Client.DriverService.DriverDTO[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/Add", ReplyAction="http://tempuri.org/IDriverService/AddResponse")]
        void Add(RaceManager.Client.DriverService.DriverDTO dto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/Add", ReplyAction="http://tempuri.org/IDriverService/AddResponse")]
        System.Threading.Tasks.Task AddAsync(RaceManager.Client.DriverService.DriverDTO dto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/Update", ReplyAction="http://tempuri.org/IDriverService/UpdateResponse")]
        void Update(RaceManager.Client.DriverService.DriverDTO dto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/Update", ReplyAction="http://tempuri.org/IDriverService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(RaceManager.Client.DriverService.DriverDTO dto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/Remove", ReplyAction="http://tempuri.org/IDriverService/RemoveResponse")]
        void Remove(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverService/Remove", ReplyAction="http://tempuri.org/IDriverService/RemoveResponse")]
        System.Threading.Tasks.Task RemoveAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDriverServiceChannel : RaceManager.Client.DriverService.IDriverService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DriverServiceClient : System.ServiceModel.ClientBase<RaceManager.Client.DriverService.IDriverService>, RaceManager.Client.DriverService.IDriverService {
        
        public DriverServiceClient() {
        }
        
        public DriverServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DriverServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DriverServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DriverServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RaceManager.Client.DriverService.DriverDTO Get(int id) {
            return base.Channel.Get(id);
        }
        
        public System.Threading.Tasks.Task<RaceManager.Client.DriverService.DriverDTO> GetAsync(int id) {
            return base.Channel.GetAsync(id);
        }
        
        public RaceManager.Client.DriverService.DriverDTO[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<RaceManager.Client.DriverService.DriverDTO[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void Add(RaceManager.Client.DriverService.DriverDTO dto) {
            base.Channel.Add(dto);
        }
        
        public System.Threading.Tasks.Task AddAsync(RaceManager.Client.DriverService.DriverDTO dto) {
            return base.Channel.AddAsync(dto);
        }
        
        public void Update(RaceManager.Client.DriverService.DriverDTO dto) {
            base.Channel.Update(dto);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(RaceManager.Client.DriverService.DriverDTO dto) {
            return base.Channel.UpdateAsync(dto);
        }
        
        public void Remove(int id) {
            base.Channel.Remove(id);
        }
        
        public System.Threading.Tasks.Task RemoveAsync(int id) {
            return base.Channel.RemoveAsync(id);
        }
    }
}