﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações a este ficheiro poderão provocar um comportamento incorrecto e perder-se-ão se
//     o código for regenerado.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUI.TTSolverSvcClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TTSolverSvcClient.ITTSolverSvc")]
    public interface ITTSolverSvc {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/Subscribe", ReplyAction="http://tempuri.org/ITTSolverSvc/SubscribeResponse")]
        void Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/Subscribe", ReplyAction="http://tempuri.org/ITTSolverSvc/SubscribeResponse")]
        System.Threading.Tasks.Task SubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/Unsubscribe", ReplyAction="http://tempuri.org/ITTSolverSvc/UnsubscribeResponse")]
        void Unsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/Unsubscribe", ReplyAction="http://tempuri.org/ITTSolverSvc/UnsubscribeResponse")]
        System.Threading.Tasks.Task UnsubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/RegisterSolver", ReplyAction="http://tempuri.org/ITTSolverSvc/RegisterSolverResponse")]
        bool RegisterSolver(string name, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/RegisterSolver", ReplyAction="http://tempuri.org/ITTSolverSvc/RegisterSolverResponse")]
        System.Threading.Tasks.Task<bool> RegisterSolverAsync(string name, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/LoginSolver", ReplyAction="http://tempuri.org/ITTSolverSvc/LoginSolverResponse")]
        bool LoginSolver(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/LoginSolver", ReplyAction="http://tempuri.org/ITTSolverSvc/LoginSolverResponse")]
        System.Threading.Tasks.Task<bool> LoginSolverAsync(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/GetSolver", ReplyAction="http://tempuri.org/ITTSolverSvc/GetSolverResponse")]
        TTService.User GetSolver(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/GetSolver", ReplyAction="http://tempuri.org/ITTSolverSvc/GetSolverResponse")]
        System.Threading.Tasks.Task<TTService.User> GetSolverAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/GetUnassignedTT", ReplyAction="http://tempuri.org/ITTSolverSvc/GetUnassignedTTResponse")]
        TTService.Ticket[] GetUnassignedTT();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/GetUnassignedTT", ReplyAction="http://tempuri.org/ITTSolverSvc/GetUnassignedTTResponse")]
        System.Threading.Tasks.Task<TTService.Ticket[]> GetUnassignedTTAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/GetSolverTT", ReplyAction="http://tempuri.org/ITTSolverSvc/GetSolverTTResponse")]
        TTService.Ticket[] GetSolverTT(TTService.User solver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/GetSolverTT", ReplyAction="http://tempuri.org/ITTSolverSvc/GetSolverTTResponse")]
        System.Threading.Tasks.Task<TTService.Ticket[]> GetSolverTTAsync(TTService.User solver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/GetSolverTTByType", ReplyAction="http://tempuri.org/ITTSolverSvc/GetSolverTTByTypeResponse")]
        TTService.Ticket[] GetSolverTTByType(TTService.User solver, TTService.TicketStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/GetSolverTTByType", ReplyAction="http://tempuri.org/ITTSolverSvc/GetSolverTTByTypeResponse")]
        System.Threading.Tasks.Task<TTService.Ticket[]> GetSolverTTByTypeAsync(TTService.User solver, TTService.TicketStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/AssignTicket", ReplyAction="http://tempuri.org/ITTSolverSvc/AssignTicketResponse")]
        bool AssignTicket(int idTicket, int idSolver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/AssignTicket", ReplyAction="http://tempuri.org/ITTSolverSvc/AssignTicketResponse")]
        System.Threading.Tasks.Task<bool> AssignTicketAsync(int idTicket, int idSolver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/AnswerTicket", ReplyAction="http://tempuri.org/ITTSolverSvc/AnswerTicketResponse")]
        bool AnswerTicket(int solver, int senderTicket, int ticket, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/AnswerTicket", ReplyAction="http://tempuri.org/ITTSolverSvc/AnswerTicketResponse")]
        System.Threading.Tasks.Task<bool> AnswerTicketAsync(int solver, int senderTicket, int ticket, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/RedirectTicket", ReplyAction="http://tempuri.org/ITTSolverSvc/RedirectTicketResponse")]
        bool RedirectTicket(int ticket, int solver, string redirectMessage, string department);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/RedirectTicket", ReplyAction="http://tempuri.org/ITTSolverSvc/RedirectTicketResponse")]
        System.Threading.Tasks.Task<bool> RedirectTicketAsync(int ticket, int solver, string redirectMessage, string department);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/MyQuestions", ReplyAction="http://tempuri.org/ITTSolverSvc/MyQuestionsResponse")]
        TTService.SecondaryQuestion[] MyQuestions(int idSolver, bool type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITTSolverSvc/MyQuestions", ReplyAction="http://tempuri.org/ITTSolverSvc/MyQuestionsResponse")]
        System.Threading.Tasks.Task<TTService.SecondaryQuestion[]> MyQuestionsAsync(int idSolver, bool type);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITTSolverSvcChannel : GUI.TTSolverSvcClient.ITTSolverSvc, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TTSolverSvcClient : System.ServiceModel.ClientBase<GUI.TTSolverSvcClient.ITTSolverSvc>, GUI.TTSolverSvcClient.ITTSolverSvc {
        
        public TTSolverSvcClient() {
        }
        
        public TTSolverSvcClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TTSolverSvcClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TTSolverSvcClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TTSolverSvcClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Subscribe() {
            base.Channel.Subscribe();
        }
        
        public System.Threading.Tasks.Task SubscribeAsync() {
            return base.Channel.SubscribeAsync();
        }
        
        public void Unsubscribe() {
            base.Channel.Unsubscribe();
        }
        
        public System.Threading.Tasks.Task UnsubscribeAsync() {
            return base.Channel.UnsubscribeAsync();
        }
        
        public bool RegisterSolver(string name, string email, string password) {
            return base.Channel.RegisterSolver(name, email, password);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterSolverAsync(string name, string email, string password) {
            return base.Channel.RegisterSolverAsync(name, email, password);
        }
        
        public bool LoginSolver(string email, string password) {
            return base.Channel.LoginSolver(email, password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginSolverAsync(string email, string password) {
            return base.Channel.LoginSolverAsync(email, password);
        }
        
        public TTService.User GetSolver(int id) {
            return base.Channel.GetSolver(id);
        }
        
        public System.Threading.Tasks.Task<TTService.User> GetSolverAsync(int id) {
            return base.Channel.GetSolverAsync(id);
        }
        
        public TTService.Ticket[] GetUnassignedTT() {
            return base.Channel.GetUnassignedTT();
        }
        
        public System.Threading.Tasks.Task<TTService.Ticket[]> GetUnassignedTTAsync() {
            return base.Channel.GetUnassignedTTAsync();
        }
        
        public TTService.Ticket[] GetSolverTT(TTService.User solver) {
            return base.Channel.GetSolverTT(solver);
        }
        
        public System.Threading.Tasks.Task<TTService.Ticket[]> GetSolverTTAsync(TTService.User solver) {
            return base.Channel.GetSolverTTAsync(solver);
        }
        
        public TTService.Ticket[] GetSolverTTByType(TTService.User solver, TTService.TicketStatus status) {
            return base.Channel.GetSolverTTByType(solver, status);
        }
        
        public System.Threading.Tasks.Task<TTService.Ticket[]> GetSolverTTByTypeAsync(TTService.User solver, TTService.TicketStatus status) {
            return base.Channel.GetSolverTTByTypeAsync(solver, status);
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
        
        public bool RedirectTicket(int ticket, int solver, string redirectMessage, string department) {
            return base.Channel.RedirectTicket(ticket, solver, redirectMessage, department);
        }
        
        public System.Threading.Tasks.Task<bool> RedirectTicketAsync(int ticket, int solver, string redirectMessage, string department) {
            return base.Channel.RedirectTicketAsync(ticket, solver, redirectMessage, department);
        }
        
        public TTService.SecondaryQuestion[] MyQuestions(int idSolver, bool type) {
            return base.Channel.MyQuestions(idSolver, type);
        }
        
        public System.Threading.Tasks.Task<TTService.SecondaryQuestion[]> MyQuestionsAsync(int idSolver, bool type) {
            return base.Channel.MyQuestionsAsync(idSolver, type);
        }
    }
}
