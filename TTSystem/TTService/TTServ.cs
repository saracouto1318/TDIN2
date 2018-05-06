using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TTService {
  public class TTServ : ITTServ {

        private Database.Database _db = Database.Database.Initialize();

        #region WebApp
        public bool AddUser(string name, string email, string password)
        {
            return _db.InsertUser(name, email, password);
        }
        public bool CheckUser(string email, string password)
        {
            return _db.ValidateUser(email, password);
        }
        public User GetUser(int id)
        {
            return _db.GetUser(id);
        }
        public bool UpdateUser(string name, string email, string password, int idUser)
        {
            return _db.UpdateUserInfo(name, email, password, idUser);
        }
        public bool AddTicket(int idUser, string title, string description)
        {
            return _db.InsertTicket(idUser, title, description);
        }
        public List<Ticket> GetTickets(User user)
        {
            return _db.GetUserTickets(user);
        }
        public List<Ticket> GetTicketsByType(User user, TicketStatus status)
        {
            return _db.GetUserTicketsPerType(user, status);
        }
        public Ticket GetTicket(User user, int id)
        {
            return _db.GetTicket(user, id);
        }
        public bool LoginApp(int idUser)
        {
            string userSession = System.Guid.NewGuid().ToString();
            _db.DeleteSessionApp(idUser);
            return _db.InsertSessionApp(idUser, userSession);
        }
        
        public void LogoutApp(int idUser)
        {
            _db.DeleteSessionApp(idUser);
        }

        public User GetUserLogged(string session)
        {
            int id = _db.GetUserID(session);
            if (id != 0)
                return _db.GetUser(id);
            return new User();
        }

        #endregion

        #region SolverGUI
        public bool AddSolver(string name, string email, string password)
        {
            return _db.InsertSolver(name, email, password);
        }
        public bool CheckSolver(string email, string password)
        {
            return _db.CheckSolver(email, password);
        }
        public User GetSolver(int id)
        {
            return _db.GetUser(id);
        }
        public List<Ticket> GetTicketsSolver(User solver)
        {
            return _db.GetTicketsSolver(solver);
        }
        public List<Ticket> GetTicketsByTypeSolver(User solver, TicketStatus status)
        {
            return _db.GetUserTicketsPerTypeSolver(solver, status);
        }
        public bool AssignTicket(int idTicket, int idSolver)
        {
            return _db.AssignTicket(idTicket, idSolver);
        }
        public bool AnswerTicket(int solver, int senderTicket, int ticket, string email)
        {
            if(_db.SolveTicket(ticket))
                return _db.InsertEmail(solver, senderTicket, ticket, email);
            return false;
        }
        public bool RedirectTicket(int ticket, int solver, string redirectMessage)
        {
            return _db.InsertSecondaryQuestion(ticket, solver, redirectMessage);
        }
        public bool LoginSolver(int idUser)
        {
            string userSession = System.Guid.NewGuid().ToString();
            _db.DeleteSessionApp(idUser);
            return _db.InsertSessionSolver(idUser, userSession);
        }

        public void LogoutSolver(int idUser)
        {
            _db.DeleteSessionSolver(idUser);
        }
        #endregion

        #region DepartmentGUI
        public bool AddDepartment(string name)
        {
            return _db.InsertDepartment(name);
        }
        public bool CheckDepartment(string name)
        {
            return _db.CheckDepartment(name);
        }
        public List<SecondaryQuestion> GetQuestions()
        {
            return _db.GetSecondaryQuestions();
        }
        public SecondaryQuestion GetQuestion(int id)
        {
            return _db.GetSecondaryQuestion(id);
        }
        public bool AnswerQuestion(SecondaryQuestion question, string department, string responseMessage)
        {
            return _db.AnswerSecondaryQuestion(question, department, responseMessage);
        }
        #endregion
    }
}
