using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTService.Database
{
    public class UserDao
    {
        #region SessionTable
        public static bool AddSession(int idUser)
        {
            string userSession = Guid.NewGuid().ToString();
            SqlConnection c = AccessDao.Instance.Conn;
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
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        public static void DeleteSession(int idUser)
        {
            SqlConnection c = AccessDao.Instance.Conn;
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
                if (c != null)
                    c.Close();
            }
        }
        public static int SelectUserIDBySession(string session)
        {
            int ID = 0;
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT userID FROM Session WHERE session = '" + session + "'";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    ID = reader.GetInt32(0);
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }
            return ID;

        }
        #endregion

        #region UserTable
        public static bool CheckUser(string email, string password)
        {
            //using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTdatabase"].ConnectionString))
            //{
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM Users WHERE email='" + email + "' AND password='" + password + "'";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                bool exists = reader.Read();
                return exists;
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }
            return false;
            //}
        }
        public static bool AddUser(string name, string email, string password)
        {
            SqlConnection c = AccessDao.Instance.Conn;
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
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        public static User SelectUser(int id)
        {
            User userInfo = new User();
            
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM Users WHERE idUser =" + id;
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userInfo.Name = reader.GetString(1);
                    userInfo.ID = reader.GetInt32(0);
                    userInfo.Email = reader.GetString(2);
                    userInfo.Password = reader.GetString(3);
                }
            }
            catch (SqlException)
            {
                return userInfo;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

            return userInfo;
        }
        public static User SelectUserByEmail(string email)
        {
            User userInfo = new User();

            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM Users WHERE email = '" + email + "'";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userInfo.Name = reader.GetString(1);
                    userInfo.ID = reader.GetInt32(0);
                    userInfo.Email = reader.GetString(2);
                    userInfo.Password = reader.GetString(3);
                }
            }
            catch (SqlException)
            {
                return userInfo;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }
            return userInfo;
        }
        public static bool UpdateUser(string name, string email, string password, int idUser)
        {
            SqlConnection c = AccessDao.Instance.Conn;
            try
            {
                c.Open();
                string sql = "UPDATE Users SET " +
                    "name ='" + name +  "', " +
                    "password = '" + password + "', " +
                    "email = '" + email + "' " +
                    "WHERE idUser = " + idUser;
                SqlCommand cmd = new SqlCommand(sql, c);
                int rowCount = cmd.ExecuteNonQuery();
                return rowCount >= 1;
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        #endregion

        #region SolverTable
        public static bool AddSolver(int ID)
        {
            SqlConnection c = AccessDao.Instance.Conn;
            try
            {
                c.Open();
                string sql = "INSERT INTO Solver(idSolver) VALUES (" + ID + ")";
                SqlCommand cmd = new SqlCommand(sql, c);
                int rowCount = cmd.ExecuteNonQuery();
                return rowCount >= 1;
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        public static int ValidateSolver(string email, string password)
        {
            int ID = 0;
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try { 
                c.Open();
                string sql = "SELECT idSolver " +
                    "FROM Solver " +
                    "WHERE idSolver IN " +
                    "(SELECT idUser " +
                    "FROM Users " +
                    "WHERE email = '" + email + "' " +
                    "AND password = '" + password + "')";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();
                if(reader.Read())
                    return reader.GetInt32(0);
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }
            return ID;
        }
        #endregion

        #region TTTable
        public static bool AddTicket(int idUser, string title, string description)
        {
            SqlConnection c = AccessDao.Instance.Conn;
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
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        public static List<Ticket> GetTickets(User user)
        {
            List<Ticket> tickets = new List<Ticket>();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM Ticket WHERE idSender = " + user.ID;
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket
                    {
                        ID = reader.GetInt32(0),
                        Date = reader.GetDateTime(5),
                        Description = reader.GetString(4),
                        Title = reader.GetString(3)
                    };

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
                        case "wait":
                            ticket.Status = TicketStatus.WAITING;
                            break;
                    }

                    tickets.Add(ticket);
                }
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

            return tickets;
        }
        public static Ticket GetUserLastTicket(int user)
        {
            Ticket ticket = null;
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * " +
                    "FROM Ticket " +
                    "WHERE idSender = " + user + " " +
                    "ORDER BY idTicket DESC " +
                    "OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY;";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ticket = new Ticket
                    {
                        ID = reader.GetInt32(0),
                        Date = reader.GetDateTime(5),
                        Description = reader.GetString(4),
                        Title = reader.GetString(3)
                    };
                }
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

            return ticket;
        }
        public static List<Ticket> GetTicketsByType(User user, TicketStatus status)
        {
            List<Ticket> tickets = new List<Ticket>();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
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
                else if (status == TicketStatus.WAITING)
                    sql += "'wait'";

                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket
                    {
                        ID = reader.GetInt32(0),
                        Date = reader.GetDateTime(5),
                        Description = reader.GetString(4),
                        Title = reader.GetString(3),
                        Status = status
                    };

                    tickets.Add(ticket);
                }
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

            return tickets;
        }
        public static Ticket GetTicket(int id)
        {
            Ticket ticket = new Ticket();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM Ticket WHERE idTicket = " + id;
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ticket.ID = reader.GetInt32(0);
                    ticket.AuthorID = reader.GetInt32(1);
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
                        case "wait":
                            ticket.Status = TicketStatus.WAITING;
                            break;
                    }
                }
                return ticket;
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }
            return ticket;
        }
        public static List<Ticket> GetUnassignedTT()
        {
            List<Ticket> tickets = new List<Ticket>();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM Ticket WHERE status = 'unassigned'";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

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
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

            return tickets;
        }
        public static List<Ticket> GetSolverTT(User solver)
        {
            List<Ticket> tickets = new List<Ticket>();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM Ticket WHERE idSolver = " + solver.ID;
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

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
                        case "wait":
                            ticket.Status = TicketStatus.WAITING;
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
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

            return tickets;
        }
        public static List<Ticket> GetSolverTTByType(User solver, TicketStatus status)
        {
            List<Ticket> tickets = new List<Ticket>();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM Ticket WHERE idSolver =" + solver.ID + " AND status = ";

                if (status == TicketStatus.ASSIGNED)
                    sql += "'assigned'";
                else if (status == TicketStatus.CLOSED)
                    sql += "'closed'";
                else if (status == TicketStatus.WAITING)
                    sql += "'wait'";

                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

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
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

                return tickets;
        }
        public static bool AssignTicket(int idTicket, int idSolver)
        {
            SqlConnection c = AccessDao.Instance.Conn;
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
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        public static bool SolveTicket(int ticket)
        {
            SqlConnection c = AccessDao.Instance.Conn;
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
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        public static bool AddAnswerTicket(int solver, int senderTicket, int ticket, string email)
        {
            SqlConnection c = AccessDao.Instance.Conn;
            try
            {
                c.Open();
                string sql = "INSERT INTO Ticket(idSender, idReceiver, idTicket, content, dateTime) " +
                    "VALUES (" + solver + "," + senderTicket + "," + ticket + ",'" + email + "', GetDate()";
                SqlCommand cmd = new SqlCommand(sql, c);
                int rowCount = cmd.ExecuteNonQuery();
                return rowCount >= 1;
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        #endregion

        #region Department
        public static bool SelectDepartment(string name)
        {
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM Department WHERE name='" + name + "'";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();
                return reader.Read();
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }
            return false;
        }
        public static bool AddDepartment(string name)
        {
            SqlConnection c = AccessDao.Instance.Conn;
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
                if (c != null)
                    c.Close();
            }
        }
        public static List<string> GetDepartments()
        {
            List<string> departments = new List<string>();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT name FROM Department";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string department = reader.GetString(0);
                    departments.Add(department);
                }
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

            return departments;
        }
        public static int GetDepartmentID(string departmentName)
        {
            int ID = 0;
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT idDepartment FROM Department WHERE name='" + departmentName + "'";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                    ID = reader.GetInt32(0);
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }
            return ID;
        }

        public static string GetDepartment(int id)
        {
            string name = "";
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT name FROM Department WHERE idDepartment=" + id;
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                    name = reader.GetString(0);
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }
            return name;
        }
        #endregion

        #region SecondaryQuestionTable        
        public static bool AddQuestion(int ticket, int solver, string redirectMessage, int id)
        {
            SqlConnection c = AccessDao.Instance.Conn;
            try
            {
                c.Open();
                string sql = "" +
                    "INSERT INTO SecondaryQuestions(idTicket, idSender, idDepartment, question, response, dateTime) " +
                    "VALUES (" + ticket + ", " + solver + ", " + id + ", '" + redirectMessage + "', null, GetDate()); UPDATE Ticket SET status='wait' WHERE idTicket=" + ticket;
                SqlCommand cmd = new SqlCommand(sql, c);
                int rowCount = cmd.ExecuteNonQuery();
                return rowCount >= 1;
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        public static List<SecondaryQuestion> GetQuestions(int idDepartment)
        {
            List<SecondaryQuestion> questions = new List<SecondaryQuestion>();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM SecondaryQuestions WHERE idDepartment =" + idDepartment + " AND response IS NULL";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SecondaryQuestion question = new SecondaryQuestion
                    {
                        ID = reader.GetInt32(0),
                        Date = reader.GetDateTime(6),
                        SenderID = reader.GetInt32(2),
                        TicketID = reader.GetInt32(1),
                        Question = reader.GetString(4),
                        Department = reader.GetInt32(3)
                    };

                    questions.Add(question);
                }
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

            return questions;
        }
        public static SecondaryQuestion GetQuestion(int id)
        {
            SecondaryQuestion question = new SecondaryQuestion();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "SELECT * FROM SecondaryQuestions WHERE idQuestion=" + id;
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    question.ID = id;
                    question.TicketID = reader.GetInt32(1);
                    question.SenderID = reader.GetInt32(2);
                    question.Department = reader.GetInt32(3);
                    question.Question = reader.GetString(4);
                    if (!reader.IsDBNull(5))
                        question.Response = reader.GetString(5);
                    question.Date = reader.GetDateTime(6);
                }
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }
            return question;
        }
        public static bool UpdateQuestion(SecondaryQuestion question)
        {
            SqlConnection c = AccessDao.Instance.Conn;
            try
            {
                c.Open();
                string sql = "UPDATE SecondaryQuestions " +
                    "SET idDepartment = " + question.Department + ", " +
                    "response = '" + question.Response + "' " +
                    "WHERE idQuestion = " + question.ID + "; UPDATE Ticket SET status='assigned' WHERE idTicket=" + question.TicketID;
                SqlCommand cmd = new SqlCommand(sql, c);
                int rowCount = cmd.ExecuteNonQuery();
                return rowCount >= 1;
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (c != null)
                    c.Close();
            }
            return false;
        }
        public static List<SecondaryQuestion> SelectSolverQuestions(int idSolver, bool type)
        {
            List<SecondaryQuestion> questions = new List<SecondaryQuestion>();
            SqlConnection c = AccessDao.Instance.Conn;
            SqlDataReader reader = null;
            try
            {
                c.Open();
                string sql = "";
                if (type)
                    sql += "SELECT * FROM SecondaryQuestions WHERE idSender = " + idSolver + "AND idDepartment IS NULL";
                else
                    sql += "SELECT * FROM SecondaryQuestions WHERE idSender = " + idSolver + "AND idDepartment IS NOT NULL";
                SqlCommand cmd = new SqlCommand(sql, c);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SecondaryQuestion question = new SecondaryQuestion();
                    question.ID = reader.GetInt32(0);
                    question.Date = reader.GetDateTime(6);
                    question.SenderID = reader.GetInt32(2);
                    question.TicketID = reader.GetInt32(1);
                    question.Question = reader.GetString(4);
                    question.Department = reader.GetInt32(3);

                    questions.Add(question);
                }
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (c != null)
                    c.Close();
            }

            return questions;
        }
        #endregion
    }
}
