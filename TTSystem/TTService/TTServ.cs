using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.ServiceModel;

namespace TTService {
    public class TTService : ITTService {

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
        public User GetUserByEmail(string email)
        {
            return _db.GetUserByEmail(email);
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
        public Ticket GetTicket(int id)
        {
            return _db.GetTicket(id);
        }
        public bool Login(int idUser)
        {
            string userSession = System.Guid.NewGuid().ToString();
            _db.DeleteSession(idUser);
            return _db.InsertSession(idUser, userSession);
        }
        public void Logout(int idUser)
        {
            _db.DeleteSession(idUser);
        }
        public User GetUserLogged(string session)
        {
            int id = _db.GetUserID(session);
            if (id != 0)
                return _db.GetUser(id);
            return new User();
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

    public class SolverService : ISolverService
    {
        private Database.Database _db = Database.Database.Initialize();
        public static List<ITTChanged> subscribers = new List<ITTChanged>();

        public void Subscribe()
        {
            ITTChanged callback = OperationContext.Current.GetCallbackChannel<ITTChanged>();
            if (!subscribers.Contains(callback))
            {
                subscribers.Add(callback);
            }
        }
        public void Unsubscribe()
        {
            ITTChanged callback = OperationContext.Current.GetCallbackChannel<ITTChanged>();
            subscribers.Remove(callback);
        }
        public bool RegisterSolver(string name, string email, string password)
        {
            return _db.InsertSolver(name, email, password);
        }
        public bool LoginSolver(string email, string password)
        {
            return _db.CheckSolver(email, password);
        }
        public User GetSolver(int id)
        {
            return _db.GetUser(id);
        }
        public List<Ticket> GetUnassignedTT()
        {
            return _db.GetTicketsUnassigned();
        }
        public List<Ticket> GetSolverTT(User solver)
        {
            return _db.GetTicketsSolver(solver);
        }
        public List<Ticket> GetSolverTTByType(User solver, TicketStatus status)
        {
            return _db.GetUserTicketsPerTypeSolver(solver, status);
        }
        public bool AssignTicket(int idTicket, int idSolver)
        {
            return _db.AssignTicket(idTicket, idSolver);
        }
        public bool AnswerTicket(int solver, int senderTicket, int ticket, string email)
        {
            if (_db.SolveTicket(ticket))
            {
                User to = GetUser(senderTicket);
                Ticket ticketInfo = GetTicket(ticket);

                MailMessage mail = new MailMessage("trouble_tickets@gmail.com", to.Email);
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                mail.Subject = "Ticket #" + ticketInfo.ID + " - " + ticketInfo.Title;
                mail.Body = email;
                client.Send(mail);
                return _db.InsertEmail(solver, senderTicket, ticket, email);
            }

            return false;
        }
        public bool RedirectTicket(int ticket, int solver, string redirectMessage)
        {
            return _db.InsertSecondaryQuestion(ticket, solver, redirectMessage);
        }
    }
}
