﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dixit_Client.DixitService1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JoinGameResult", Namespace="http://schemas.datacontract.org/2004/07/Dixit_ServiceLibrary.DataContracts")]
    [System.SerializableAttribute()]
    public partial class JoinGameResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccessField;
        
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
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Card", Namespace="http://schemas.datacontract.org/2004/07/Dixit_Service.DataContracts")]
    [System.SerializableAttribute()]
    public partial class Card : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GameState", Namespace="http://schemas.datacontract.org/2004/07/Dixit_ServiceLibrary.DataContracts")]
    [System.SerializableAttribute()]
    public partial class GameState : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Dixit_Client.DixitService1.Player ActualPlayerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Dixit_Client.DixitService1.Deck BoardDeckField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CardAssociationTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool GameIsRunningField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<Dixit_Client.DixitService1.Player, Dixit_Client.DixitService1.Card> GuessesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<Dixit_Client.DixitService1.Player, Dixit_Client.DixitService1.Deck> HandsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Dixit_Client.DixitService1.Deck MainDeckField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<Dixit_Client.DixitService1.Player> PlayersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<Dixit_Client.DixitService1.Player, int> PointsField;
        
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
        public Dixit_Client.DixitService1.Player ActualPlayer {
            get {
                return this.ActualPlayerField;
            }
            set {
                if ((object.ReferenceEquals(this.ActualPlayerField, value) != true)) {
                    this.ActualPlayerField = value;
                    this.RaisePropertyChanged("ActualPlayer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Dixit_Client.DixitService1.Deck BoardDeck {
            get {
                return this.BoardDeckField;
            }
            set {
                if ((object.ReferenceEquals(this.BoardDeckField, value) != true)) {
                    this.BoardDeckField = value;
                    this.RaisePropertyChanged("BoardDeck");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CardAssociationText {
            get {
                return this.CardAssociationTextField;
            }
            set {
                if ((object.ReferenceEquals(this.CardAssociationTextField, value) != true)) {
                    this.CardAssociationTextField = value;
                    this.RaisePropertyChanged("CardAssociationText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool GameIsRunning {
            get {
                return this.GameIsRunningField;
            }
            set {
                if ((this.GameIsRunningField.Equals(value) != true)) {
                    this.GameIsRunningField = value;
                    this.RaisePropertyChanged("GameIsRunning");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<Dixit_Client.DixitService1.Player, Dixit_Client.DixitService1.Card> Guesses {
            get {
                return this.GuessesField;
            }
            set {
                if ((object.ReferenceEquals(this.GuessesField, value) != true)) {
                    this.GuessesField = value;
                    this.RaisePropertyChanged("Guesses");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<Dixit_Client.DixitService1.Player, Dixit_Client.DixitService1.Deck> Hands {
            get {
                return this.HandsField;
            }
            set {
                if ((object.ReferenceEquals(this.HandsField, value) != true)) {
                    this.HandsField = value;
                    this.RaisePropertyChanged("Hands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Dixit_Client.DixitService1.Deck MainDeck {
            get {
                return this.MainDeckField;
            }
            set {
                if ((object.ReferenceEquals(this.MainDeckField, value) != true)) {
                    this.MainDeckField = value;
                    this.RaisePropertyChanged("MainDeck");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<Dixit_Client.DixitService1.Player> Players {
            get {
                return this.PlayersField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayersField, value) != true)) {
                    this.PlayersField = value;
                    this.RaisePropertyChanged("Players");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<Dixit_Client.DixitService1.Player, int> Points {
            get {
                return this.PointsField;
            }
            set {
                if ((object.ReferenceEquals(this.PointsField, value) != true)) {
                    this.PointsField = value;
                    this.RaisePropertyChanged("Points");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/Dixit_ServiceLibrary.DataContracts")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Deck", Namespace="http://schemas.datacontract.org/2004/07/Dixit_ServiceLibrary.DataContracts")]
    [System.SerializableAttribute()]
    public partial class Deck : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<Dixit_Client.DixitService1.Card> CardsField;
        
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
        public System.Collections.Generic.List<Dixit_Client.DixitService1.Card> Cards {
            get {
                return this.CardsField;
            }
            set {
                if ((object.ReferenceEquals(this.CardsField, value) != true)) {
                    this.CardsField = value;
                    this.RaisePropertyChanged("Cards");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DixitService1.IDixitService", CallbackContract=typeof(Dixit_Client.DixitService1.IDixitServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IDixitService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDixitService/Login", ReplyAction="http://tempuri.org/IDixitService/LoginResponse")]
        void Login();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDixitService/Login", ReplyAction="http://tempuri.org/IDixitService/LoginResponse")]
        System.Threading.Tasks.Task LoginAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IDixitService/Logout", ReplyAction="http://tempuri.org/IDixitService/LogoutResponse")]
        void Logout();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IDixitService/Logout", ReplyAction="http://tempuri.org/IDixitService/LogoutResponse")]
        System.Threading.Tasks.Task LogoutAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/JoinGame", ReplyAction="http://tempuri.org/IDixitService/JoinGameResponse")]
        Dixit_Client.DixitService1.JoinGameResult JoinGame();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/JoinGame", ReplyAction="http://tempuri.org/IDixitService/JoinGameResponse")]
        System.Threading.Tasks.Task<Dixit_Client.DixitService1.JoinGameResult> JoinGameAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/StartGame", ReplyAction="http://tempuri.org/IDixitService/StartGameResponse")]
        void StartGame();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/StartGame", ReplyAction="http://tempuri.org/IDixitService/StartGameResponse")]
        System.Threading.Tasks.Task StartGameAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/LeaveGame", ReplyAction="http://tempuri.org/IDixitService/LeaveGameResponse")]
        void LeaveGame();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/LeaveGame", ReplyAction="http://tempuri.org/IDixitService/LeaveGameResponse")]
        System.Threading.Tasks.Task LeaveGameAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/AddAssociationText", ReplyAction="http://tempuri.org/IDixitService/AddAssociationTextResponse")]
        void AddAssociationText(string story);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/AddAssociationText", ReplyAction="http://tempuri.org/IDixitService/AddAssociationTextResponse")]
        System.Threading.Tasks.Task AddAssociationTextAsync(string story);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/NewGuess", ReplyAction="http://tempuri.org/IDixitService/NewGuessResponse")]
        void NewGuess(Dixit_Client.DixitService1.Card card);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/NewGuess", ReplyAction="http://tempuri.org/IDixitService/NewGuessResponse")]
        System.Threading.Tasks.Task NewGuessAsync(Dixit_Client.DixitService1.Card card);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/PutCard", ReplyAction="http://tempuri.org/IDixitService/PutCardResponse")]
        void PutCard(Dixit_Client.DixitService1.Card card);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDixitService/PutCard", ReplyAction="http://tempuri.org/IDixitService/PutCardResponse")]
        System.Threading.Tasks.Task PutCardAsync(Dixit_Client.DixitService1.Card card);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDixitServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDixitService/GameStart")]
        void GameStart(Dixit_Client.DixitService1.GameState state);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDixitService/GameStateChanged")]
        void GameStateChanged(Dixit_Client.DixitService1.GameState state);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDixitService/GameEnd")]
        void GameEnd(Dixit_Client.DixitService1.GameState state);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDixitService/PuttingPhaseEnd")]
        void PuttingPhaseEnd();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDixitService/GuessPhaseEnd")]
        void GuessPhaseEnd();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDixitServiceChannel : Dixit_Client.DixitService1.IDixitService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DixitServiceClient : System.ServiceModel.DuplexClientBase<Dixit_Client.DixitService1.IDixitService>, Dixit_Client.DixitService1.IDixitService {
        
        public DixitServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public DixitServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public DixitServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DixitServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DixitServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Login() {
            base.Channel.Login();
        }
        
        public System.Threading.Tasks.Task LoginAsync() {
            return base.Channel.LoginAsync();
        }
        
        public void Logout() {
            base.Channel.Logout();
        }
        
        public System.Threading.Tasks.Task LogoutAsync() {
            return base.Channel.LogoutAsync();
        }
        
        public Dixit_Client.DixitService1.JoinGameResult JoinGame() {
            return base.Channel.JoinGame();
        }
        
        public System.Threading.Tasks.Task<Dixit_Client.DixitService1.JoinGameResult> JoinGameAsync() {
            return base.Channel.JoinGameAsync();
        }
        
        public void StartGame() {
            base.Channel.StartGame();
        }
        
        public System.Threading.Tasks.Task StartGameAsync() {
            return base.Channel.StartGameAsync();
        }
        
        public void LeaveGame() {
            base.Channel.LeaveGame();
        }
        
        public System.Threading.Tasks.Task LeaveGameAsync() {
            return base.Channel.LeaveGameAsync();
        }
        
        public void AddAssociationText(string story) {
            base.Channel.AddAssociationText(story);
        }
        
        public System.Threading.Tasks.Task AddAssociationTextAsync(string story) {
            return base.Channel.AddAssociationTextAsync(story);
        }
        
        public void NewGuess(Dixit_Client.DixitService1.Card card) {
            base.Channel.NewGuess(card);
        }
        
        public System.Threading.Tasks.Task NewGuessAsync(Dixit_Client.DixitService1.Card card) {
            return base.Channel.NewGuessAsync(card);
        }
        
        public void PutCard(Dixit_Client.DixitService1.Card card) {
            base.Channel.PutCard(card);
        }
        
        public System.Threading.Tasks.Task PutCardAsync(Dixit_Client.DixitService1.Card card) {
            return base.Channel.PutCardAsync(card);
        }
    }
}