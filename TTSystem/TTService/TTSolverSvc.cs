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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class TTSolverSvc : ITTSolverSvc
    {
        public static Dictionary<int, ITTUpdateCallback> Subscribers = new Dictionary<int, ITTUpdateCallback>();

        #region SolverGUI
        public String Hello()
        {
            return "Hello solver";
        }

        public void Subscribe(int idSolver)
        {
            ITTUpdateCallback callback = OperationContext.Current.GetCallbackChannel<ITTUpdateCallback>();
            if (!Subscribers.ContainsKey(idSolver))
            {
                Subscribers.Add(idSolver, callback);
            }
        }
        public static void StaticUnsubscribe(int idSolver)
        {
            Subscribers.Remove(idSolver);
        }
        public void Unsubscribe(int idSolver)
        {
            StaticUnsubscribe(idSolver);
        }
        public static void Unsubscribe(List<int> idSolvers)
        {
            idSolvers.ForEach(StaticUnsubscribe);
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
            if (Subscribers.ContainsKey(ID))
            {
                return false;
            }
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
            Dictionary<int, ITTUpdateCallback> subscribers = Subscribers;
            List<int> rmSubs = new List<int>();

            Ticket tticket = UserDao.GetTicket(idTicket);

            if (success && subscribers != null)
            {
                foreach (KeyValuePair<int, ITTUpdateCallback> sub in subscribers)
                {
                    try
                    {
                        sub.Value.AssignedTT(tticket);
                    }
                    catch (Exception)
                    {
                        rmSubs.Add(sub.Key);
                    }
                }
            }

            Unsubscribe(rmSubs);
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
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    //assigned credetial details to server
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("trouble.tickets.it@gmail.com", "troubletickets1234")
                };

                MailAddress from = new MailAddress("trouble.tickets.it@gmail.com", "Trouble Tickets");

                //create receiver address
                MailAddress receiver = new MailAddress(to.Email.Trim(), to.Name.ToString());

                MailMessage Mymessage = new MailMessage(from, receiver);
                Mymessage.Subject = "Ticket #" + ticketInfo.ID.ToString() + " - " + ticketInfo.Title.ToString();
                Mymessage.Body = email.Trim();

                client.Send(Mymessage);

                return UserDao.SolveTicket(ticket);
            }
            return false;
        }
        public SecondaryQuestion RedirectTicket(int ticket, int solver, string redirectMessage, string department)
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

            if(UserDao.AddQuestion(ticket, solver, redirectMessage, id))
            {
                return UserDao.GetSolverLastQuestion(solver);
            }
            return null;
        }

        public List<SecondaryQuestion> MyQuestions(int idSolver, bool isUnanswered)
        {
            return UserDao.SelectSolverQuestions(idSolver, isUnanswered);
        }
        #endregion

    }
}
