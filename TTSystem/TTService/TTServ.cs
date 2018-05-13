using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.ServiceModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TTService {
    public class TTServ : ITTServ {

        public static List<ITTChanged> subscribers = new List<ITTChanged>();
        
        #region WebApp
        public bool AddUser(string name, string email, string password)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "INSERT INTO Users (name, email, password) VALUES ('" + name + "', '" + email + "', '" + password + "')";
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
        public bool CheckUser(string email, string password)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Users WHERE email='" + email + "' AND password='" + password + "'";
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
        public User GetUser(int id)
        {
            User userInfo = new User();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Users WHERE idUser =" + id;
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        userInfo.Name = reader.GetString(1);
                        userInfo.ID = reader.GetInt32(0);
                        userInfo.Email = reader.GetString(2);
                        userInfo.Password = reader.GetString(3);
                    }

                    List<Ticket> tickets = GetTickets(userInfo);
                    userInfo.Tickets = tickets;

                    reader.Close();
                    return userInfo;
                }
                catch (SqlException)
                {
                    return userInfo;
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public User GetUserByEmail(string email)
        {
            User userInfo = new User();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Users WHERE email = '" + email + "'";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        userInfo.Name = reader.GetString(1);
                        userInfo.ID = reader.GetInt32(0);
                        userInfo.Email = reader.GetString(2);
                        userInfo.Password = reader.GetString(3);
                    }

                    List<Ticket> tickets = GetTickets(userInfo);
                    userInfo.Tickets = tickets;

                    reader.Close();
                    return userInfo;
                }
                catch (SqlException)
                {
                    return userInfo;
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public bool UpdateUser(string name, string email, string password, int idUser)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "UPDATE Users SET name ='" + name + "', password = '" + password + "', email = '" + email + "' WHERE idUser = " + idUser;
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
        public bool AddTicket(int idUser, string title, string description)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "INSERT INTO Ticket(idSender, idSolver, title, description, dateTime, status) VALUES (" + idUser + ", null, '" + title + "', '" + description + "', GetDate(), 'unassigned')";
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
        public List<Ticket> GetTickets(User user)
        {
            List<Ticket> tickets = new List<Ticket>();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Ticket WHERE idSender = " + user.ID;
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket();
                        ticket.ID = reader.GetInt32(0);
                        ticket.Date = reader.GetDateTime(5);
                        ticket.Description = reader.GetString(4);
                        ticket.Title = reader.GetString(3);

                        string status = reader.GetString(6);

                        switch (status)
                        {
                            case "unassigned":
                                ticket.Status = TicketStatus.UNASSIGNED;
                                break;
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
        public List<Ticket> GetTicketsByType(User user, TicketStatus status)
        {
            List<Ticket> tickets = new List<Ticket>();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Ticket WHERE idSender = " + user.ID + "AND status = ";

                    if (status == TicketStatus.UNASSIGNED)
                        sql += "'unassigned'";
                    else if (status == TicketStatus.ASSIGNED)
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
        public Ticket GetTicket(int id)
        {
            Ticket ticket = new Ticket();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Ticket WHERE idTicket = " + id;
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ticket.ID = reader.GetInt32(0);
                        ticket.Author = GetUser(reader.GetInt32(1));
                        ticket.Title = reader.GetString(3);
                        ticket.Description = reader.GetString(4);
                        ticket.Date = reader.GetDateTime(5);

                        string status = reader.GetString(6);

                        switch (status)
                        {
                            case "unassigned":
                                ticket.Status = TicketStatus.UNASSIGNED;
                                break;
                            case "assigned":
                                ticket.Status = TicketStatus.ASSIGNED;
                                break;
                            case "closed":
                                ticket.Status = TicketStatus.CLOSED;
                                break;
                        }
                    }

                    reader.Close();
                    return ticket;
                }
                catch (SqlException)
                {
                    return ticket;
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public bool Login(int idUser)
        {
            string userSession = System.Guid.NewGuid().ToString();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "INSERT INTO Session(userID, session) VALUES (" + idUser + ",'" + userSession + "')";
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
     public void Logout(int idUser)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "DELETE FROM Session WHERE userID=" + idUser;
                    SqlCommand cmd = new SqlCommand(sql, c);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public User GetUserLogged(string session)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT userID FROM Session WHERE session = '" + session + "'";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int ID = 0;

                    if (reader.Read())
                        ID = reader.GetInt32(0);

                    reader.Close();

                    if (ID != 0)
                        return GetUser(ID);
                    return new User();
                }
                catch (SqlException)
                {
                    return new User();
                }
                finally
                {
                    c.Close();
                }
            }
            
        }
        #endregion

        #region SolverGUI
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
        public bool RedirectTicket(int ticket, int solver, string redirectMessage)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "INSERT INTO SecondaryQuestions(idTicket, idSender, idDepartment, question, response, dateTime) VALUES (" + ticket + ", " + solver + ", null, '" + redirectMessage + "', null, GetDate())";
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

        #region DepartmentGUI
        public bool AddDepartment(string name)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "INSERT INTO Department(name) VALUES ('" + name + "')";
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
        public bool CheckDepartment(string name)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM Department WHERE name='" + name + "'";
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
        public List<SecondaryQuestion> GetQuestions()
        {
            List<SecondaryQuestion> questions = new List<SecondaryQuestion>();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM SecondaryQuestions WHERE idDepartment IS NULL AND response IS NULL";
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
        public SecondaryQuestion GetQuestion(int id)
        {
            SecondaryQuestion question = new SecondaryQuestion();

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT * FROM SecondaryQuestions WHERE idQuestion=" + id;
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        question.ID = id;
                        question.TicketID = reader.GetInt32(1);
                        question.SenderID = reader.GetInt32(2);
                        question.Department = reader.GetInt32(3);
                        question.Question = reader.GetString(4);
                        question.Response = reader.GetString(5);
                        question.Date = reader.GetDateTime(6);
                    }

                    reader.Close();
                    return question;
                }
                catch (SqlException)
                {
                    return question;
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public int GetDepartmentID(string departmentName)
        {
            int id = 0;
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "SELECT idDepartment FROM Department WHERE name='" + departmentName + "'";
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                        id = reader.GetInt32(0);

                    reader.Close();
                    return id;
                }
                catch (SqlException)
                {
                    return id;
                }
                finally
                {
                    c.Close();
                }
            }
        }
        public bool AnswerQuestion(SecondaryQuestion question, string department, string responseMessage)
        {
            int id = GetDepartmentID(department);
            question.Department = id;
            question.Response = responseMessage;

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "UPDATE SecondaryQuestions SET idDepartment = " + id + ", response = '" + responseMessage + "' WHERE idQuestion = " + question.ID;
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
        #endregion
    }
    /*
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
                User to = _db.GetUser(senderTicket);
                Ticket ticketInfo = _db.GetTicket(ticket);

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
    */
}
