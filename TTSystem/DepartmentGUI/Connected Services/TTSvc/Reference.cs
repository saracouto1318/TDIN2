﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações a este ficheiro poderão provocar um comportamento incorrecto e perder-se-ão se
//     o código for regenerado.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DepartmentGUI.TTSvc {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/TTService")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DepartmentGUI.TTSvc.Ticket[] TicketsField;
        
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
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DepartmentGUI.TTSvc.Ticket[] Tickets {
            get {
                return this.TicketsField;
            }
            set {
                if ((object.ReferenceEquals(this.TicketsField, value) != true)) {
                    this.TicketsField = value;
                    this.RaisePropertyChanged("Tickets");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Ticket", Namespace="http://schemas.datacontract.org/2004/07/TTService")]
    [System.SerializableAttribute()]
    public partial class Ticket : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DepartmentGUI.TTSvc.User AuthorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DepartmentGUI.TTSvc.TicketStatus StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
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
        public DepartmentGUI.TTSvc.User Author {
            get {
                return this.AuthorField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorField, value) != true)) {
                    this.AuthorField = value;
                    this.RaisePropertyChanged("Author");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DepartmentGUI.TTSvc.TicketStatus Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TicketStatus", Namespace="http://schemas.datacontract.org/2004/07/TTService")]
    public enum TicketStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UNASSIGNED = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ASSIGNED = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CLOSED = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SecondaryQuestion", Namespace="http://schemas.datacontract.org/2004/07/TTService")]
    [System.SerializableAttribute()]
    public partial class SecondaryQuestion : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DepartmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string QuestionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResponseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SenderIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TicketIDField;
        
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
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Department {
            get {
                return this.DepartmentField;
            }
            set {
                if ((this.DepartmentField.Equals(value) != true)) {
                    this.DepartmentField = value;
                    this.RaisePropertyChanged("Department");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Question {
            get {
                return this.QuestionField;
            }
            set {
                if ((object.ReferenceEquals(this.QuestionField, value) != true)) {
                    this.QuestionField = value;
                    this.RaisePropertyChanged("Question");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Response {
            get {
                return this.ResponseField;
            }
            set {
                if ((object.ReferenceEquals(this.ResponseField, value) != true)) {
                    this.ResponseField = value;
                    this.RaisePropertyChanged("Response");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SenderID {
            get {
                return this.SenderIDField;
            }
            set {
                if ((this.SenderIDField.Equals(value) != true)) {
                    this.SenderIDField = value;
                    this.RaisePropertyChanged("SenderID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TicketID {
            get {
                return this.TicketIDField;
            }
            set {
                if ((this.TicketIDField.Equals(value) != true)) {
                    this.TicketIDField = value;
                    this.RaisePropertyChanged("TicketID");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TTSvc.ITTServ")]
    public interface ITTServ {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddUser", ReplyAction="http://tempuri.org/ITTServ/AddUserResponse")]
        bool AddUser(string name, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddUser", ReplyAction="http://tempuri.org/ITTServ/AddUserResponse")]
        System.Threading.Tasks.Task<bool> AddUserAsync(string name, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/CheckUser", ReplyAction="http://tempuri.org/ITTServ/CheckUserResponse")]
        bool CheckUser(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/CheckUser", ReplyAction="http://tempuri.org/ITTServ/CheckUserResponse")]
        System.Threading.Tasks.Task<bool> CheckUserAsync(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUser", ReplyAction="http://tempuri.org/ITTServ/GetUserResponse")]
        DepartmentGUI.TTSvc.User GetUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUser", ReplyAction="http://tempuri.org/ITTServ/GetUserResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.User> GetUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUserByEmail", ReplyAction="http://tempuri.org/ITTServ/GetUserByEmailResponse")]
        DepartmentGUI.TTSvc.User GetUserByEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUserByEmail", ReplyAction="http://tempuri.org/ITTServ/GetUserByEmailResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.User> GetUserByEmailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/UpdateUser", ReplyAction="http://tempuri.org/ITTServ/UpdateUserResponse")]
        bool UpdateUser(string name, string email, string password, int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/UpdateUser", ReplyAction="http://tempuri.org/ITTServ/UpdateUserResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserAsync(string name, string email, string password, int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddTicket", ReplyAction="http://tempuri.org/ITTServ/AddTicketResponse")]
        bool AddTicket(int idUser, string title, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddTicket", ReplyAction="http://tempuri.org/ITTServ/AddTicketResponse")]
        System.Threading.Tasks.Task<bool> AddTicketAsync(int idUser, string title, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTickets", ReplyAction="http://tempuri.org/ITTServ/GetTicketsResponse")]
        DepartmentGUI.TTSvc.Ticket[] GetTickets(DepartmentGUI.TTSvc.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTickets", ReplyAction="http://tempuri.org/ITTServ/GetTicketsResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsAsync(DepartmentGUI.TTSvc.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsByType", ReplyAction="http://tempuri.org/ITTServ/GetTicketsByTypeResponse")]
        DepartmentGUI.TTSvc.Ticket[] GetTicketsByType(DepartmentGUI.TTSvc.User user, DepartmentGUI.TTSvc.TicketStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsByType", ReplyAction="http://tempuri.org/ITTServ/GetTicketsByTypeResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsByTypeAsync(DepartmentGUI.TTSvc.User user, DepartmentGUI.TTSvc.TicketStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicket", ReplyAction="http://tempuri.org/ITTServ/GetTicketResponse")]
        DepartmentGUI.TTSvc.Ticket GetTicket(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicket", ReplyAction="http://tempuri.org/ITTServ/GetTicketResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket> GetTicketAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/Login", ReplyAction="http://tempuri.org/ITTServ/LoginResponse")]
        bool Login(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/Login", ReplyAction="http://tempuri.org/ITTServ/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/Logout", ReplyAction="http://tempuri.org/ITTServ/LogoutResponse")]
        void Logout(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/Logout", ReplyAction="http://tempuri.org/ITTServ/LogoutResponse")]
        System.Threading.Tasks.Task LogoutAsync(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUserLogged", ReplyAction="http://tempuri.org/ITTServ/GetUserLoggedResponse")]
        DepartmentGUI.TTSvc.User GetUserLogged(string session);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUserLogged", ReplyAction="http://tempuri.org/ITTServ/GetUserLoggedResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.User> GetUserLoggedAsync(string session);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddSolver", ReplyAction="http://tempuri.org/ITTServ/AddSolverResponse")]
        bool AddSolver(string name, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddSolver", ReplyAction="http://tempuri.org/ITTServ/AddSolverResponse")]
        System.Threading.Tasks.Task<bool> AddSolverAsync(string name, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/CheckSolver", ReplyAction="http://tempuri.org/ITTServ/CheckSolverResponse")]
        bool CheckSolver(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/CheckSolver", ReplyAction="http://tempuri.org/ITTServ/CheckSolverResponse")]
        System.Threading.Tasks.Task<bool> CheckSolverAsync(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetSolver", ReplyAction="http://tempuri.org/ITTServ/GetSolverResponse")]
        DepartmentGUI.TTSvc.User GetSolver(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetSolver", ReplyAction="http://tempuri.org/ITTServ/GetSolverResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.User> GetSolverAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsUnassigned", ReplyAction="http://tempuri.org/ITTServ/GetTicketsUnassignedResponse")]
        DepartmentGUI.TTSvc.Ticket[] GetTicketsUnassigned();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsUnassigned", ReplyAction="http://tempuri.org/ITTServ/GetTicketsUnassignedResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsUnassignedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsSolver", ReplyAction="http://tempuri.org/ITTServ/GetTicketsSolverResponse")]
        DepartmentGUI.TTSvc.Ticket[] GetTicketsSolver(DepartmentGUI.TTSvc.User solver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsSolver", ReplyAction="http://tempuri.org/ITTServ/GetTicketsSolverResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsSolverAsync(DepartmentGUI.TTSvc.User solver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsByTypeSolver", ReplyAction="http://tempuri.org/ITTServ/GetTicketsByTypeSolverResponse")]
        DepartmentGUI.TTSvc.Ticket[] GetTicketsByTypeSolver(DepartmentGUI.TTSvc.User solver, DepartmentGUI.TTSvc.TicketStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsByTypeSolver", ReplyAction="http://tempuri.org/ITTServ/GetTicketsByTypeSolverResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsByTypeSolverAsync(DepartmentGUI.TTSvc.User solver, DepartmentGUI.TTSvc.TicketStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AssignTicket", ReplyAction="http://tempuri.org/ITTServ/AssignTicketResponse")]
        bool AssignTicket(int idTicket, int idSolver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AssignTicket", ReplyAction="http://tempuri.org/ITTServ/AssignTicketResponse")]
        System.Threading.Tasks.Task<bool> AssignTicketAsync(int idTicket, int idSolver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AnswerTicket", ReplyAction="http://tempuri.org/ITTServ/AnswerTicketResponse")]
        bool AnswerTicket(int solver, int senderTicket, int ticket, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AnswerTicket", ReplyAction="http://tempuri.org/ITTServ/AnswerTicketResponse")]
        System.Threading.Tasks.Task<bool> AnswerTicketAsync(int solver, int senderTicket, int ticket, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/RedirectTicket", ReplyAction="http://tempuri.org/ITTServ/RedirectTicketResponse")]
        bool RedirectTicket(int ticket, int solver, string redirectMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/RedirectTicket", ReplyAction="http://tempuri.org/ITTServ/RedirectTicketResponse")]
        System.Threading.Tasks.Task<bool> RedirectTicketAsync(int ticket, int solver, string redirectMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddDepartment", ReplyAction="http://tempuri.org/ITTServ/AddDepartmentResponse")]
        bool AddDepartment(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddDepartment", ReplyAction="http://tempuri.org/ITTServ/AddDepartmentResponse")]
        System.Threading.Tasks.Task<bool> AddDepartmentAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/CheckDepartment", ReplyAction="http://tempuri.org/ITTServ/CheckDepartmentResponse")]
        bool CheckDepartment(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/CheckDepartment", ReplyAction="http://tempuri.org/ITTServ/CheckDepartmentResponse")]
        System.Threading.Tasks.Task<bool> CheckDepartmentAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetQuestions", ReplyAction="http://tempuri.org/ITTServ/GetQuestionsResponse")]
        DepartmentGUI.TTSvc.SecondaryQuestion[] GetQuestions();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetQuestions", ReplyAction="http://tempuri.org/ITTServ/GetQuestionsResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.SecondaryQuestion[]> GetQuestionsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetQuestion", ReplyAction="http://tempuri.org/ITTServ/GetQuestionResponse")]
        DepartmentGUI.TTSvc.SecondaryQuestion GetQuestion(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetQuestion", ReplyAction="http://tempuri.org/ITTServ/GetQuestionResponse")]
        System.Threading.Tasks.Task<DepartmentGUI.TTSvc.SecondaryQuestion> GetQuestionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AnswerQuestion", ReplyAction="http://tempuri.org/ITTServ/AnswerQuestionResponse")]
        bool AnswerQuestion(DepartmentGUI.TTSvc.SecondaryQuestion question, string department, string responseMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AnswerQuestion", ReplyAction="http://tempuri.org/ITTServ/AnswerQuestionResponse")]
        System.Threading.Tasks.Task<bool> AnswerQuestionAsync(DepartmentGUI.TTSvc.SecondaryQuestion question, string department, string responseMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITTServChannel : DepartmentGUI.TTSvc.ITTServ, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TTServClient : System.ServiceModel.ClientBase<DepartmentGUI.TTSvc.ITTServ>, DepartmentGUI.TTSvc.ITTServ {
        
        public TTServClient() {
        }
        
        public TTServClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TTServClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TTServClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TTServClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddUser(string name, string email, string password) {
            return base.Channel.AddUser(name, email, password);
        }
        
        public System.Threading.Tasks.Task<bool> AddUserAsync(string name, string email, string password) {
            return base.Channel.AddUserAsync(name, email, password);
        }
        
        public bool CheckUser(string email, string password) {
            return base.Channel.CheckUser(email, password);
        }
        
        public System.Threading.Tasks.Task<bool> CheckUserAsync(string email, string password) {
            return base.Channel.CheckUserAsync(email, password);
        }
        
        public DepartmentGUI.TTSvc.User GetUser(int id) {
            return base.Channel.GetUser(id);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.User> GetUserAsync(int id) {
            return base.Channel.GetUserAsync(id);
        }
        
        public DepartmentGUI.TTSvc.User GetUserByEmail(string email) {
            return base.Channel.GetUserByEmail(email);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.User> GetUserByEmailAsync(string email) {
            return base.Channel.GetUserByEmailAsync(email);
        }
        
        public bool UpdateUser(string name, string email, string password, int idUser) {
            return base.Channel.UpdateUser(name, email, password, idUser);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserAsync(string name, string email, string password, int idUser) {
            return base.Channel.UpdateUserAsync(name, email, password, idUser);
        }
        
        public bool AddTicket(int idUser, string title, string description) {
            return base.Channel.AddTicket(idUser, title, description);
        }
        
        public System.Threading.Tasks.Task<bool> AddTicketAsync(int idUser, string title, string description) {
            return base.Channel.AddTicketAsync(idUser, title, description);
        }
        
        public DepartmentGUI.TTSvc.Ticket[] GetTickets(DepartmentGUI.TTSvc.User user) {
            return base.Channel.GetTickets(user);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsAsync(DepartmentGUI.TTSvc.User user) {
            return base.Channel.GetTicketsAsync(user);
        }
        
        public DepartmentGUI.TTSvc.Ticket[] GetTicketsByType(DepartmentGUI.TTSvc.User user, DepartmentGUI.TTSvc.TicketStatus status) {
            return base.Channel.GetTicketsByType(user, status);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsByTypeAsync(DepartmentGUI.TTSvc.User user, DepartmentGUI.TTSvc.TicketStatus status) {
            return base.Channel.GetTicketsByTypeAsync(user, status);
        }
        
        public DepartmentGUI.TTSvc.Ticket GetTicket(int id) {
            return base.Channel.GetTicket(id);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket> GetTicketAsync(int id) {
            return base.Channel.GetTicketAsync(id);
        }
        
        public bool Login(int idUser) {
            return base.Channel.Login(idUser);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(int idUser) {
            return base.Channel.LoginAsync(idUser);
        }
        
        public void Logout(int idUser) {
            base.Channel.Logout(idUser);
        }
        
        public System.Threading.Tasks.Task LogoutAsync(int idUser) {
            return base.Channel.LogoutAsync(idUser);
        }
        
        public DepartmentGUI.TTSvc.User GetUserLogged(string session) {
            return base.Channel.GetUserLogged(session);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.User> GetUserLoggedAsync(string session) {
            return base.Channel.GetUserLoggedAsync(session);
        }
        
        public bool AddSolver(string name, string email, string password) {
            return base.Channel.AddSolver(name, email, password);
        }
        
        public System.Threading.Tasks.Task<bool> AddSolverAsync(string name, string email, string password) {
            return base.Channel.AddSolverAsync(name, email, password);
        }
        
        public bool CheckSolver(string email, string password) {
            return base.Channel.CheckSolver(email, password);
        }
        
        public System.Threading.Tasks.Task<bool> CheckSolverAsync(string email, string password) {
            return base.Channel.CheckSolverAsync(email, password);
        }
        
        public DepartmentGUI.TTSvc.User GetSolver(int id) {
            return base.Channel.GetSolver(id);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.User> GetSolverAsync(int id) {
            return base.Channel.GetSolverAsync(id);
        }
        
        public DepartmentGUI.TTSvc.Ticket[] GetTicketsUnassigned() {
            return base.Channel.GetTicketsUnassigned();
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsUnassignedAsync() {
            return base.Channel.GetTicketsUnassignedAsync();
        }
        
        public DepartmentGUI.TTSvc.Ticket[] GetTicketsSolver(DepartmentGUI.TTSvc.User solver) {
            return base.Channel.GetTicketsSolver(solver);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsSolverAsync(DepartmentGUI.TTSvc.User solver) {
            return base.Channel.GetTicketsSolverAsync(solver);
        }
        
        public DepartmentGUI.TTSvc.Ticket[] GetTicketsByTypeSolver(DepartmentGUI.TTSvc.User solver, DepartmentGUI.TTSvc.TicketStatus status) {
            return base.Channel.GetTicketsByTypeSolver(solver, status);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.Ticket[]> GetTicketsByTypeSolverAsync(DepartmentGUI.TTSvc.User solver, DepartmentGUI.TTSvc.TicketStatus status) {
            return base.Channel.GetTicketsByTypeSolverAsync(solver, status);
        }
        
        public bool AssignTicket(int idTicket, int idSolver) {
            return base.Channel.AssignTicket(idTicket, idSolver);
        }
        
        public System.Threading.Tasks.Task<bool> AssignTicketAsync(int idTicket, int idSolver) {
            return base.Channel.AssignTicketAsync(idTicket, idSolver);
        }
        
        public bool AnswerTicket(int solver, int senderTicket, int ticket, string email) {
            return base.Channel.AnswerTicket(solver, senderTicket, ticket, email);
        }
        
        public System.Threading.Tasks.Task<bool> AnswerTicketAsync(int solver, int senderTicket, int ticket, string email) {
            return base.Channel.AnswerTicketAsync(solver, senderTicket, ticket, email);
        }
        
        public bool RedirectTicket(int ticket, int solver, string redirectMessage) {
            return base.Channel.RedirectTicket(ticket, solver, redirectMessage);
        }
        
        public System.Threading.Tasks.Task<bool> RedirectTicketAsync(int ticket, int solver, string redirectMessage) {
            return base.Channel.RedirectTicketAsync(ticket, solver, redirectMessage);
        }
        
        public bool AddDepartment(string name) {
            return base.Channel.AddDepartment(name);
        }
        
        public System.Threading.Tasks.Task<bool> AddDepartmentAsync(string name) {
            return base.Channel.AddDepartmentAsync(name);
        }
        
        public bool CheckDepartment(string name) {
            return base.Channel.CheckDepartment(name);
        }
        
        public System.Threading.Tasks.Task<bool> CheckDepartmentAsync(string name) {
            return base.Channel.CheckDepartmentAsync(name);
        }
        
        public DepartmentGUI.TTSvc.SecondaryQuestion[] GetQuestions() {
            return base.Channel.GetQuestions();
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.SecondaryQuestion[]> GetQuestionsAsync() {
            return base.Channel.GetQuestionsAsync();
        }
        
        public DepartmentGUI.TTSvc.SecondaryQuestion GetQuestion(int id) {
            return base.Channel.GetQuestion(id);
        }
        
        public System.Threading.Tasks.Task<DepartmentGUI.TTSvc.SecondaryQuestion> GetQuestionAsync(int id) {
            return base.Channel.GetQuestionAsync(id);
        }
        
        public bool AnswerQuestion(DepartmentGUI.TTSvc.SecondaryQuestion question, string department, string responseMessage) {
            return base.Channel.AnswerQuestion(question, department, responseMessage);
        }
        
        public System.Threading.Tasks.Task<bool> AnswerQuestionAsync(DepartmentGUI.TTSvc.SecondaryQuestion question, string department, string responseMessage) {
            return base.Channel.AnswerQuestionAsync(question, department, responseMessage);
        }
    }
}
