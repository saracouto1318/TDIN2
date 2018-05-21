using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.ServiceModel;
using TTService.Database;
using TTService.Models;

namespace TTService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TTServ : ITTServ {
        
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
        }
        public User GetUserByEmail(string email)
        {
            User userInfo = UserDao.SelectUserByEmail(email);
            List<Ticket> tickets = GetTickets(userInfo);
            userInfo.Tickets = tickets;
            return userInfo;
        }
        public bool UpdateUser(string name, string email, string password, int idUser)
        {
            return UserDao.UpdateUser(name, email, password, idUser);
        }

        public bool AddTicket(int idUser, string title, string description)
        {
            bool success = UserDao.AddTicket(idUser, title, description);
            Ticket tticket = UserDao.GetUserLastTicket(idUser);
            Dictionary<int, ITTUpdateCallback> subscribers = TTSolverSvc.Subscribers;
            List<int> rmSubs = new List<int>();

            if (success && subscribers != null)
            {
                foreach (KeyValuePair<int, ITTUpdateCallback> sub in subscribers)
                {
                    try
                    {
                        sub.Value.NewTT(tticket);
                    }
                    catch (Exception)
                    {
                        rmSubs.Add(sub.Key);
                    }
                }
            }

            TTSolverSvc.Unsubscribe(rmSubs);
            return success;
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

        #region DepartmentGUI
        public bool CheckDepartment(string name)
        {
            return UserDao.SelectDepartment(name);
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

        public string GetDepartment(int id)
        {
            return UserDao.GetDepartment(id);
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
            question.Department = GetDepartmentID(department);
            question.Response = responseMessage;
            // Update question in the database
            if (UserDao.UpdateQuestion(question))
            {
                // Get callback interface from subscribed solver 
                Dictionary<int, ITTUpdateCallback> subs = TTSolverSvc.Subscribers;
                if (subs.TryGetValue(question.SenderID, out ITTUpdateCallback callback))
                {
                    try
                    {
                        // Notify answered ticket
                        callback.AnsweredTicket(question);
                    }
                    catch (Exception)
                    {
                        // Remove solver from subscribed users
                        TTSolverSvc.StaticUnsubscribe(question.SenderID);
                    }
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
