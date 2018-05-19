﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações a este ficheiro poderão provocar um comportamento incorrecto e perder-se-ão se
//     o código for regenerado.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUI.TTSvc {
    
    
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
        TTService.User GetUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUser", ReplyAction="http://tempuri.org/ITTServ/GetUserResponse")]
        System.Threading.Tasks.Task<TTService.User> GetUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUserByEmail", ReplyAction="http://tempuri.org/ITTServ/GetUserByEmailResponse")]
        TTService.User GetUserByEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUserByEmail", ReplyAction="http://tempuri.org/ITTServ/GetUserByEmailResponse")]
        System.Threading.Tasks.Task<TTService.User> GetUserByEmailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/UpdateUser", ReplyAction="http://tempuri.org/ITTServ/UpdateUserResponse")]
        bool UpdateUser(string name, string email, string password, int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/UpdateUser", ReplyAction="http://tempuri.org/ITTServ/UpdateUserResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserAsync(string name, string email, string password, int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddTicket", ReplyAction="http://tempuri.org/ITTServ/AddTicketResponse")]
        bool AddTicket(int idUser, string title, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddTicket", ReplyAction="http://tempuri.org/ITTServ/AddTicketResponse")]
        System.Threading.Tasks.Task<bool> AddTicketAsync(int idUser, string title, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTickets", ReplyAction="http://tempuri.org/ITTServ/GetTicketsResponse")]
        TTService.Ticket[] GetTickets(TTService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTickets", ReplyAction="http://tempuri.org/ITTServ/GetTicketsResponse")]
        System.Threading.Tasks.Task<TTService.Ticket[]> GetTicketsAsync(TTService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsByType", ReplyAction="http://tempuri.org/ITTServ/GetTicketsByTypeResponse")]
        TTService.Ticket[] GetTicketsByType(TTService.User user, TTService.TicketStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicketsByType", ReplyAction="http://tempuri.org/ITTServ/GetTicketsByTypeResponse")]
        System.Threading.Tasks.Task<TTService.Ticket[]> GetTicketsByTypeAsync(TTService.User user, TTService.TicketStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicket", ReplyAction="http://tempuri.org/ITTServ/GetTicketResponse")]
        TTService.Ticket GetTicket(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetTicket", ReplyAction="http://tempuri.org/ITTServ/GetTicketResponse")]
        System.Threading.Tasks.Task<TTService.Ticket> GetTicketAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/Login", ReplyAction="http://tempuri.org/ITTServ/LoginResponse")]
        bool Login(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/Login", ReplyAction="http://tempuri.org/ITTServ/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/Logout", ReplyAction="http://tempuri.org/ITTServ/LogoutResponse")]
        void Logout(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/Logout", ReplyAction="http://tempuri.org/ITTServ/LogoutResponse")]
        System.Threading.Tasks.Task LogoutAsync(int idUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUserLogged", ReplyAction="http://tempuri.org/ITTServ/GetUserLoggedResponse")]
        TTService.User GetUserLogged(string session);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetUserLogged", ReplyAction="http://tempuri.org/ITTServ/GetUserLoggedResponse")]
        System.Threading.Tasks.Task<TTService.User> GetUserLoggedAsync(string session);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddDepartment", ReplyAction="http://tempuri.org/ITTServ/AddDepartmentResponse")]
        bool AddDepartment(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AddDepartment", ReplyAction="http://tempuri.org/ITTServ/AddDepartmentResponse")]
        System.Threading.Tasks.Task<bool> AddDepartmentAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/CheckDepartment", ReplyAction="http://tempuri.org/ITTServ/CheckDepartmentResponse")]
        bool CheckDepartment(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/CheckDepartment", ReplyAction="http://tempuri.org/ITTServ/CheckDepartmentResponse")]
        System.Threading.Tasks.Task<bool> CheckDepartmentAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetDepartments", ReplyAction="http://tempuri.org/ITTServ/GetDepartmentsResponse")]
        string[] GetDepartments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetDepartments", ReplyAction="http://tempuri.org/ITTServ/GetDepartmentsResponse")]
        System.Threading.Tasks.Task<string[]> GetDepartmentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetQuestions", ReplyAction="http://tempuri.org/ITTServ/GetQuestionsResponse")]
        TTService.SecondaryQuestion[] GetQuestions(int idDepartment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetQuestions", ReplyAction="http://tempuri.org/ITTServ/GetQuestionsResponse")]
        System.Threading.Tasks.Task<TTService.SecondaryQuestion[]> GetQuestionsAsync(int idDepartment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetQuestion", ReplyAction="http://tempuri.org/ITTServ/GetQuestionResponse")]
        TTService.SecondaryQuestion GetQuestion(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetQuestion", ReplyAction="http://tempuri.org/ITTServ/GetQuestionResponse")]
        System.Threading.Tasks.Task<TTService.SecondaryQuestion> GetQuestionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetDepartmentID", ReplyAction="http://tempuri.org/ITTServ/GetDepartmentIDResponse")]
        int GetDepartmentID(string departmentName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetDepartmentID", ReplyAction="http://tempuri.org/ITTServ/GetDepartmentIDResponse")]
        System.Threading.Tasks.Task<int> GetDepartmentIDAsync(string departmentName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetDepartment", ReplyAction="http://tempuri.org/ITTServ/GetDepartmentResponse")]
        string GetDepartment(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/GetDepartment", ReplyAction="http://tempuri.org/ITTServ/GetDepartmentResponse")]
        System.Threading.Tasks.Task<string> GetDepartmentAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AnswerQuestion", ReplyAction="http://tempuri.org/ITTServ/AnswerQuestionResponse")]
        bool AnswerQuestion(TTService.SecondaryQuestion question, string department, string responseMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTServ/AnswerQuestion", ReplyAction="http://tempuri.org/ITTServ/AnswerQuestionResponse")]
        System.Threading.Tasks.Task<bool> AnswerQuestionAsync(TTService.SecondaryQuestion question, string department, string responseMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITTServChannel : GUI.TTSvc.ITTServ, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TTServClient : System.ServiceModel.ClientBase<GUI.TTSvc.ITTServ>, GUI.TTSvc.ITTServ {
        
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
        
        public TTService.User GetUser(int id) {
            return base.Channel.GetUser(id);
        }
        
        public System.Threading.Tasks.Task<TTService.User> GetUserAsync(int id) {
            return base.Channel.GetUserAsync(id);
        }
        
        public TTService.User GetUserByEmail(string email) {
            return base.Channel.GetUserByEmail(email);
        }
        
        public System.Threading.Tasks.Task<TTService.User> GetUserByEmailAsync(string email) {
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
        
        public TTService.Ticket[] GetTickets(TTService.User user) {
            return base.Channel.GetTickets(user);
        }
        
        public System.Threading.Tasks.Task<TTService.Ticket[]> GetTicketsAsync(TTService.User user) {
            return base.Channel.GetTicketsAsync(user);
        }
        
        public TTService.Ticket[] GetTicketsByType(TTService.User user, TTService.TicketStatus status) {
            return base.Channel.GetTicketsByType(user, status);
        }
        
        public System.Threading.Tasks.Task<TTService.Ticket[]> GetTicketsByTypeAsync(TTService.User user, TTService.TicketStatus status) {
            return base.Channel.GetTicketsByTypeAsync(user, status);
        }
        
        public TTService.Ticket GetTicket(int id) {
            return base.Channel.GetTicket(id);
        }
        
        public System.Threading.Tasks.Task<TTService.Ticket> GetTicketAsync(int id) {
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
        
        public TTService.User GetUserLogged(string session) {
            return base.Channel.GetUserLogged(session);
        }
        
        public System.Threading.Tasks.Task<TTService.User> GetUserLoggedAsync(string session) {
            return base.Channel.GetUserLoggedAsync(session);
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
        
        public string[] GetDepartments() {
            return base.Channel.GetDepartments();
        }
        
        public System.Threading.Tasks.Task<string[]> GetDepartmentsAsync() {
            return base.Channel.GetDepartmentsAsync();
        }
        
        public TTService.SecondaryQuestion[] GetQuestions(int idDepartment) {
            return base.Channel.GetQuestions(idDepartment);
        }
        
        public System.Threading.Tasks.Task<TTService.SecondaryQuestion[]> GetQuestionsAsync(int idDepartment) {
            return base.Channel.GetQuestionsAsync(idDepartment);
        }
        
        public TTService.SecondaryQuestion GetQuestion(int id) {
            return base.Channel.GetQuestion(id);
        }
        
        public System.Threading.Tasks.Task<TTService.SecondaryQuestion> GetQuestionAsync(int id) {
            return base.Channel.GetQuestionAsync(id);
        }
        
        public int GetDepartmentID(string departmentName) {
            return base.Channel.GetDepartmentID(departmentName);
        }
        
        public System.Threading.Tasks.Task<int> GetDepartmentIDAsync(string departmentName) {
            return base.Channel.GetDepartmentIDAsync(departmentName);
        }
        
        public string GetDepartment(int id) {
            return base.Channel.GetDepartment(id);
        }
        
        public System.Threading.Tasks.Task<string> GetDepartmentAsync(int id) {
            return base.Channel.GetDepartmentAsync(id);
        }
        
        public bool AnswerQuestion(TTService.SecondaryQuestion question, string department, string responseMessage) {
            return base.Channel.AnswerQuestion(question, department, responseMessage);
        }
        
        public System.Threading.Tasks.Task<bool> AnswerQuestionAsync(TTService.SecondaryQuestion question, string department, string responseMessage) {
            return base.Channel.AnswerQuestionAsync(question, department, responseMessage);
        }
    }
}
