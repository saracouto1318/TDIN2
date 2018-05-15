using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.ServiceModel;
using System.Configuration;
using TTService.Database;
using System.Data.SqlClient;

namespace TTService {
    public class TTServ : ITTServ {

        public static List<ITTChanged> subscribers = new List<ITTChanged>();
        
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
        
        /* #region SolverGUI
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
            if (AddUser(name, email, password))
            {
                User user = GetUserByEmail(email);
                using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
                {
                    try
                    {
                        c.Open();
                        string sql = "INSERT INTO Solver(idSolver) VALUES (" + user.ID + ")";
                        SqlCommand cmd = new SqlCommand(sql, c);
                        int rowCount = cmd.ExecuteNonQuery();
                        return rowCount >= 1;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                    finally
                    {
                        c.Close();
                    }
                }
            }
            return false;
        }
        public bool LoginSolver(string email, string password)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT idSolver FROM Solver WHERE idSolver IN (SELECT idUser FROM Users WHERE email = '" + email + "' AND password = '" + password + "')";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    bool exists = reader.Read();
                    reader.Close();
                    return exists;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public User GetSolver(int id)
        {
            return GetUser(id);
        }
        public List<Ticket> GetUnassignedTT()
        {
            List<Ticket> tickets = new List<Ticket>();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Ticket WHERE idSolver IS NULL";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket();
                        ticket.ID = reader.GetInt32(0);
                        ticket.Date = reader.GetDateTime(5);
                        ticket.Description = reader.GetString(4);
                        ticket.Author = null;
                        ticket.Title = reader.GetString(3);
                        ticket.Status = TicketStatus.UNASSIGNED;
                        tickets.Add(ticket);
                    }

                    reader.Close();
                }
                catch (SqlException)
                {
                }
                finally
                {
                    c.Close();
                }

                return tickets;
            }
        }
        public List<Ticket> GetSolverTT(User solver)
        {
            List<Ticket> tickets = new List<Ticket>();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Ticket WHERE idSolver = " + solver.ID;
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket();
                        ticket.ID = reader.GetInt32(0);
                        ticket.Date = reader.GetDateTime(5);
                        ticket.Description = reader.GetString(4);
                        ticket.Author = solver;
                        ticket.Title = reader.GetString(3);

                        string status = reader.GetString(6);

                        switch (status)
                        {
                            case "assigned":
                                ticket.Status = TicketStatus.ASSIGNED;
                                break;
                            case "closed":
                                ticket.Status = TicketStatus.CLOSED;
                                break;
                        }

                        tickets.Add(ticket);
                    }

                    reader.Close();
                }
                catch (SqlException)
                {
                }
                finally
                {
                    c.Close();
                }

                return tickets;
            }
        }
        public List<Ticket> GetSolverTTByType(User solver, TicketStatus status)
        {
            List<Ticket> tickets = new List<Ticket>();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Ticket WHERE idSolver =" + solver.ID + " AND status = ";

                    if (status == TicketStatus.ASSIGNED)
                        sql += "'assigned'";
                    else if (status == TicketStatus.CLOSED)
                        sql += "'closed'";

                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket();
                        ticket.ID = reader.GetInt32(0);
                        ticket.Date = reader.GetDateTime(5);
                        ticket.Description = reader.GetString(4);
                        ticket.Title = reader.GetString(3);
                        ticket.Author = solver;
                        ticket.Status = status;

                        tickets.Add(ticket);
                    }

                    reader.Close();
                }
                catch (SqlException)
                {
                }
                finally
                {
                    c.Close();
                }

                return tickets;
            }
        }
        public bool AssignTicket(int idTicket, int idSolver)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "UPDATE Ticket SET status='assigned', idSolver=" + idSolver + " WHERE idTicket=" + idTicket;
                    SqlCommand cmd = new SqlCommand(sql, c);
                    int rowCount = cmd.ExecuteNonQuery();
                    return rowCount >= 1;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public bool SolveTicket(int ticket)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "UPDATE Ticket SET status='closed' WHERE idTicket=" + ticket;
                    SqlCommand cmd = new SqlCommand(sql, c);
                    int rowCount = cmd.ExecuteNonQuery();
                    return rowCount >= 1;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public bool AnswerTicket(int solver, int senderTicket, int ticket, string email)
        {
            if (SolveTicket(ticket))
            {
                User to = GetUser(senderTicket);
                Ticket ticketInfo = GetTicket(ticket);

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

                using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
                {
                    try
                    {
                        c.Open();
                        string sql = "INSERT INTO User(idSender, idReceiver, idTicket, content, dateTime) VALUES (" + solver + "," + senderTicket + "," + ticket + ",'" + email + "', GetDate()";
                        SqlCommand cmd = new SqlCommand(sql, c);
                        int rowCount = cmd.ExecuteNonQuery();
                        return rowCount >= 1;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                    finally
                    {
                        c.Close();
                    }
                }
            }

            return false;
        }
        public bool RedirectTicket(int ticket, int solver, string redirectMessage, string department)
        {
            int id = GetDepartmentID(department);
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "INSERT INTO SecondaryQuestions(idTicket, idSender, idDepartment, question, response, dateTime) VALUES (" + ticket + ", " + solver + ", " + id + ", '" + redirectMessage + "', null, GetDate())";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    int rowCount = cmd.ExecuteNonQuery();
                    return rowCount >= 1;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public List<SecondaryQuestion> MyQuestions(int idSolver, bool type)
        {
            List<SecondaryQuestion> questions = new List<SecondaryQuestion>();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "";
                    if (type)
                        sql += "SELECT * FROM SecondaryQuestions WHERE idSender = " + idSolver + "AND idDepartment IS NULL";
                    else
                        sql += "SELECT * FROM SecondaryQuestions WHERE idSender = " + idSolver + "AND idDepartment IS NOT NULL";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SecondaryQuestion question = new SecondaryQuestion();
                        question.ID = reader.GetInt32(0);
                        question.Date = reader.GetDateTime(6);
                        question.SenderID = reader.GetInt32(2);
                        question.TicketID = reader.GetInt32(1);
                        question.Question = reader.GetString(4);

                        questions.Add(question);
                    }

                    reader.Close();
                }
                catch (SqlException)
                {
                }
                finally
                {
                    c.Close();
                }

                return questions;
            }
        }
        #endregion
        */
        
        #region DepartmentGUI
        public bool CheckDepartment(string name)
        {
            return UserDao.SelectDepartment(name);
        }
        public bool AddDepartment(string name)
        {
            return UserDao.AddDepartment(name);
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
