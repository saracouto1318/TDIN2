using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using TTService;

namespace TTService {
  [ServiceContract]
  public interface ITTServ {
        #region WebApp
        [OperationContract]
        bool AddUser(string name, string email, string password);

        [OperationContract]
        bool CheckUser(string email, string password);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        bool UpdateUser(string name, string email, string password, int idUser);

        [OperationContract]
        bool AddTicket(int idUser, string title, string description);

        [OperationContract]
        List<Ticket> GetTickets(User user);

        [OperationContract]
        List<Ticket> GetTicketsByType(User user, TicketStatus status);

        [OperationContract]
        Ticket GetTicket(User user, int id);

        [OperationContract]
        bool LoginApp(int idUser);

        [OperationContract]
        void LogoutApp(int idUser);

        [OperationContract]
        User GetUserLogged(string session);

        #endregion

        #region SolverGUI
        [OperationContract]
        bool AddSolver(string name, string email, string password);

        [OperationContract]
        bool CheckSolver(string email, string password);

        [OperationContract]
        User GetSolver(int id);

        [OperationContract]
        List<Ticket> GetTicketsSolver(User solver);

        [OperationContract]
        List<Ticket> GetTicketsByTypeSolver(User solver, TicketStatus status);

        [OperationContract]
        bool AssignTicket(int idTicket, int idSolver);
 
        [OperationContract]
        bool AnswerTicket(int solver, int senderTicket, int ticket, string email);

        [OperationContract]
        bool RedirectTicket(int ticket, int solver, string redirectMessage);

        [OperationContract]
        bool LoginSolver(int idUser);

        [OperationContract]
        void LogoutSolver(int idUser);

        #endregion

        #region DepartmentGUI
        [OperationContract]
        bool AddDepartment(string name);

        [OperationContract]
        bool CheckDepartment(string name);

        [OperationContract]
        List<SecondaryQuestion> GetQuestions();

        [OperationContract]
        SecondaryQuestion GetQuestion(int id);

        [OperationContract]
        bool AnswerQuestion(SecondaryQuestion question, string department, string responseMessage);
        #endregion
    }
}