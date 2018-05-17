using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TTService.Database;
using TTService.Models;

namespace TTService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TTSolverSvc : ITTSolverSvc
    {
        public static List<ITTUpdateCallback> Subscribers = new List<ITTUpdateCallback>();

        #region SolverGUI
        public String Hello()
        {
            return "Hello solver";
        }

        public void Subscribe()
        {
            ITTUpdateCallback callback = OperationContext.Current.GetCallbackChannel<ITTUpdateCallback>();
            if (!Subscribers.Contains(callback))
            {
                Subscribers.Add(callback);
            }
        }
        public void Unsubscribe()
        {
            ITTUpdateCallback callback = OperationContext.Current.GetCallbackChannel<ITTUpdateCallback>();
            Subscribers.Remove(callback);
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
            bool success = UserDao.AssignTicket(idTicket, idSolver);
            List<ITTUpdateCallback> subscribers = TTSolverSvc.Subscribers;
            if (success && subscribers != null)
            {
                foreach(ITTUpdateCallback sub in subscribers)
                {
                    // TODO send ticket id
                    sub.AssignedTT(idTicket, idSolver);
                }
            }
            return success;
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

            if (id <= 0)
            {
                UserDao.AddDepartment(department);
                id = UserDao.GetDepartmentID(department);
            }
            if (sender == null)
            {
                sender = MessageQueueManager.Instance.AddMessageQueue(department);
            }

            sender.Send(new SerializedSecondaryQuestion()
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

    }
}
