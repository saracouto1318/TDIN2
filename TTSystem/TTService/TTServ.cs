using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TTService {
  public class TTServ : ITTServ {

        private Database.Database _db = Database.Database.Initialize();

        #region WebApp
        public int AddTicket(User author, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public int AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public int AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool CheckUser(string email)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsByType(int author, string type)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTickets(int author)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SolverGUI
        public int AddSolver(User user)
        {
            throw new NotImplementedException();
        }

        public bool CheckSolver(string email)
        {
            throw new NotImplementedException();
        }

        public User GetSolver(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsSolver(int solver)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsByTypeSolver(int solver, string type)
        {
            throw new NotImplementedException();
        }

        public bool AnswerTicket(Ticket ticket, int solver, string email)
        {
            throw new NotImplementedException();
        }

        public bool RedirectTicket(Ticket ticket, int solver, string redirectMessage)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region DepartmentGUI

        public int AddDepartment(string name)
        {
            throw new NotImplementedException();
        }

        public bool CheckDepartment(string name)
        {
            throw new NotImplementedException();
        }

        public User GetDepartment(string name)
        {
            throw new NotImplementedException();
        }

        public List<SecondaryQuestion> GetQuestions(string name)
        {
            throw new NotImplementedException();
        }

        public bool AnswerQuestion(string name, Ticket ticket, string responseMessage)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
