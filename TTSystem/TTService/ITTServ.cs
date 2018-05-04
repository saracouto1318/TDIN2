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
        int AddUser(User user);

        [OperationContract]
        bool CheckUser(string email);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        bool UpdateUser(User user);

        [OperationContract]
        int AddTicket(Ticket ticket);

        [OperationContract]
        List<Ticket> GetTickets(int author);

        [OperationContract]
        List<Ticket> GetTicketsByType(int author, string type);

        [OperationContract]
        Ticket GetTicket(int id);

        #endregion

        #region SolverGUI
        [OperationContract]
        int AddSolver(User user);

        [OperationContract]
        bool CheckSolver(string email);

        [OperationContract]
        User GetSolver(int id);

        [OperationContract]
        List<Ticket> GetTicketsSolver(int solver);

        [OperationContract]
        List<Ticket> GetTicketsByTypeSolver(int solver, string type);

        [OperationContract]
        bool AnswerTicket(Ticket ticket, int solver, string email);

        [OperationContract]
        bool RedirectTicket(Ticket ticket, int solver, string redirectMessage);

        #endregion

        #region DepartmentGUI
        int AddDepartment(string name);

        [OperationContract]
        bool CheckDepartment(string name);

        [OperationContract]
        User GetDepartment(string name);

        [OperationContract]
        List<SecondaryQuestion> GetQuestions(string name);

        [OperationContract]
        bool AnswerQuestion(string name, Ticket ticket, string responseMessage);
        #endregion
    }
}