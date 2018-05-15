using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using TTService;

namespace TTService {
    [ServiceContract/*(Namespace = "http://fe.up.pt/apm", CallbackContract = typeof(ITTChanged))*/]
    public interface ITTServ {
        #region WebApp
        [OperationContract]
        bool AddUser(string name, string email, string password);

        [OperationContract]
        bool CheckUser(string email, string password);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        User GetUserByEmail(string email);

        [OperationContract]
        bool UpdateUser(string name, string email, string password, int idUser);

        [OperationContract]
        bool AddTicket(int idUser, string title, string description);

        [OperationContract]
        List<Ticket> GetTickets(User user);

        [OperationContract]
        List<Ticket> GetTicketsByType(User user, TicketStatus status);

        [OperationContract]
        Ticket GetTicket(int id);

        [OperationContract]
        bool Login(int idUser);

        [OperationContract]
        void Logout(int idUser);

        [OperationContract]
        User GetUserLogged(string session);

        #endregion
        /*
        #region SolverGUI
        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();

        [OperationContract]
        bool RegisterSolver(string name, string email, string password);

        [OperationContract]
        bool LoginSolver(string email, string password);

        [OperationContract]
        User GetSolver(int id);

        [OperationContract]
        List<Ticket> GetUnassignedTT();

        [OperationContract]
        List<Ticket> GetSolverTT(User solver);

        [OperationContract]
        List<Ticket> GetSolverTTByType(User solver, TicketStatus status);

        [OperationContract]
        bool AssignTicket(int idTicket, int idSolver);

        [OperationContract]
        bool AnswerTicket(int solver, int senderTicket, int ticket, string email);

        [OperationContract]
        bool RedirectTicket(int ticket, int solver, string redirectMessage, string department);

        [OperationContract]
        List<SecondaryQuestion> MyQuestions(int idSolver, bool type);
        #endregion
        */
        #region DepartmentGUI
        [OperationContract]
        bool AddDepartment(string name);

        [OperationContract]
        bool CheckDepartment(string name);

        [OperationContract]
        List<string> GetDepartments();

        [OperationContract]
        List<SecondaryQuestion> GetQuestions(int idDepartment);

        [OperationContract]
        SecondaryQuestion GetQuestion(int id);

        [OperationContract]
        bool AnswerQuestion(SecondaryQuestion question, string department, string responseMessage);
        #endregion
    }

    public interface ITTChanged
    {
        [OperationContract(IsOneWay = true)]
        void NewTT(Ticket ticket);

        [OperationContract(IsOneWay = true)]
        void AssignedTT(Ticket ticket);
    }
}