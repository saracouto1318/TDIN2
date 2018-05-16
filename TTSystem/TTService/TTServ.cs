using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.ServiceModel;
using System.Configuration;
using TTService.Database;
using System.Data.SqlClient;

namespace TTService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TTServ : ITTServ, ITTSolverSvc {

        public static List<ITTUpdateCallback> subscribers = new List<ITTUpdateCallback>();
        
        #region WebApp
        public bool AddUser(string name, string email, string password)
        {
            return UserDao.AddUser(name, email, password);
        }
        public bool CheckUser(string email, string password)
        {
            return UserDao.CheckUser(email, password);
        }
        public User GetUser(int id)
        {
            User userInfo = UserDao.SelectUser(id);
            List<Ticket> tickets = GetTickets(userInfo);
            userInfo.Tickets = tickets;
            return userInfo;
            //}
        }
        public User GetUserByEmail(string email)
        {
            User userInfo = UserDao.SelectUserByEmail(email);
            List<Ticket> tickets = GetTickets(userInfo);
            userInfo.Tickets = tickets;
            return userInfo;
            //}
        }
        public bool UpdateUser(string name, string email, string password, int idUser)
        {
            return UserDao.UpdateUser(name, email, password, idUser);
        }

        public bool AddTicket(int idUser, string title, string description)
        {
            return UserDao.AddTicket(idUser, title, description);
        }
        public List<Ticket> GetTickets(User user)
        {
            return UserDao.GetTickets(user);
        }
        public List<Ticket> GetTicketsByType(User user, TicketStatus status)
        {
            return UserDao.GetTicketsByType(user, status);
        }
        public Ticket GetTicket(int id)
        {
            Ticket ticket = UserDao.GetTicket(id);
            ticket.Author = GetUser(ticket.AuthorID);
            return ticket;
        }

        public bool Login(int idUser)
        {
            return UserDao.AddSession(idUser);
        }
        public void Logout(int idUser)
        {
            UserDao.DeleteSession(idUser);
        }
        public User GetUserLogged(string session)
        {
            int ID = UserDao.SelectUserIDBySession(session);
            return ID != 0 ? GetUser(ID) : new User();
        }
        #endregion

        #region SolverGUI
        public String Hello()
        {
            return "Hello solver";
        }
        public void Subscribe()
        {
            ITTUpdateCallback callback = OperationContext.Current.GetCallbackChannel<ITTUpdateCallback>();
            if (!subscribers.Contains(callback))
            {
                subscribers.Add(callback);
            }
        }
        public void Unsubscribe()
        {
            ITTUpdateCallback callback = OperationContext.Current.GetCallbackChannel<ITTUpdateCallback>();
            subscribers.Remove(callback);
        }
        public bool RegisterSolver(string name, string email, string password)
        {
            if (UserDao.AddUser(name, email, password))
            {
                User user = UserDao.SelectUserByEmail(email);
                return UserDao.AddSolver(user.ID);
            }

            return false;
        }
        public bool LoginSolver(string email, string password)
        {
            int ID = UserDao.ValidateSolver(email, password);
            return UserDao.AddSession(ID);
        }
        public User GetSolver(int id)
        {
            return UserDao.SelectUser(id);
        }
        public List<Ticket> GetUnassignedTT()
        {
            return UserDao.GetUnassignedTT();
        }
        public List<Ticket> GetSolverTT(User solver)
        {
            return UserDao.GetSolverTT(solver);
        }
        public List<Ticket> GetSolverTTByType(User solver, TicketStatus status)
        {
            return UserDao.GetSolverTTByType(solver, status);
        }
        public bool AssignTicket(int idTicket, int idSolver)
        {
            return UserDao.AssignTicket(idTicket, idSolver);
        }
        public bool SolveTicket(int ticket)
        {
            return UserDao.SolveTicket(ticket);
        }
        public bool AnswerTicket(int solver, int senderTicket, int ticket, string email)
        {
            if (SolveTicket(ticket))
            {
                User to = UserDao.SelectUser(senderTicket);
                Ticket ticketInfo = UserDao.GetTicket(ticket);

                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("trouble_tickets@gmail.com");
                mail.To.Add(to.Email.ToString());
                mail.Subject = "Ticket #" + ticketInfo.ID + " - " + ticketInfo.Title;
                mail.Body = email;

                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Send(mail);

                return UserDao.AddAnswerTicket(solver, senderTicket, ticket, email);
            }
            return false;
        }
        public bool RedirectTicket(int ticket, int solver, string redirectMessage, string department)
        {
            int id = UserDao.GetDepartmentID(department);
            MessageQueueSender sender = MessageQueueManager.Instance.GetMessageQueue(department);

            if(id <= 0)
            {
                UserDao.AddDepartment(department);
                id = UserDao.GetDepartmentID(department);
            }
            if (sender == null)
            {
                sender = MessageQueueManager.Instance.AddMessageQueue(department);
            }

            sender.Send(new SecondaryQuestion()
            {
                TicketID = ticket,
                SenderID = solver,
                Date = DateTime.Now,
                Department = id,
                Question = redirectMessage
            });

            return UserDao.AddQuestion(ticket, solver, redirectMessage, id);
        }

        public List<SecondaryQuestion> MyQuestions(int idSolver, bool type)
        {
            return UserDao.SelectSolverQuestions(idSolver, type);
        }
        #endregion

        #region DepartmentGUI
        public bool CheckDepartment(string name)
        {
            bool exists = UserDao.SelectDepartment(name);
            if(exists)
            {
                MessageQueueManager.Instance.AddMessageQueue(name);
            }
            return exists;
        }
        public bool AddDepartment(string name)
        {
            bool success = UserDao.AddDepartment(name);
            // If it fails to add to the database then it already exists
            // So try add it to the queue manager anyway
            MessageQueueManager.Instance.AddMessageQueue(name);
            return success;
        }
        public List<string> GetDepartments()
        {
            return UserDao.GetDepartments();
        }
        public int GetDepartmentID(string departmentName)
        {
            return UserDao.GetDepartmentID(departmentName);
        }

        public List<SecondaryQuestion> GetQuestions(int idDepartment)
        {
            return UserDao.GetQuestions(idDepartment);
        }
        public SecondaryQuestion GetQuestion(int id)
        {
            return UserDao.GetQuestion(id);
        }
        public bool AnswerQuestion(SecondaryQuestion question, string department, string responseMessage)
        {
            int id = GetDepartmentID(department);
            question.Department = id;
            question.Response = responseMessage;
            return UserDao.UpdateQuestion(question);
        }
        #endregion
    }
}
