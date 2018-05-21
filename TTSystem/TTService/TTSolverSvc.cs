using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            List<ITTUpdateCallback> subscribers = Subscribers;
            ITTUpdateCallback rmSub = null;

            Ticket tticket = UserDao.GetTicket(idTicket);

            if (success && subscribers != null)
            {
                foreach (ITTUpdateCallback sub in subscribers)
                {
                    if (rmSub != null)
                    {
                        subscribers.Remove(rmSub);
                    }

                    try
                    {
                        sub.AssignedTT(tticket);
                    }
                    catch (Exception)
                    {
                        rmSub = sub;
                    }
                }

                if (rmSub != null)
                {
                    subscribers.Remove(rmSub);
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
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                //Server Credentials
                NetworkCredential NC = new NetworkCredential();
                NC.UserName = "";
                NC.Password = "";
                //assigned credetial details to server
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = NC;

                MailAddress from = new MailAddress("trouble.tickets.it@gmail.com", "Trouble Tickets");

                //create receiver address
                MailAddress receiver = new MailAddress(to.Email.Trim(), to.Name.ToString());

                MailMessage Mymessage = new MailMessage(from, receiver);
                Mymessage.Subject = "Ticket #" + ticketInfo.ID.ToString() + " - " + ticketInfo.Title.ToString();
                Mymessage.Body = email.Trim();

                client.Send(Mymessage);

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
