﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using TTService;

namespace Database
{
    public class Database
    {
        public static Database instance;

        private SQLiteConnection _conn;

        public const string DB_PATH = "database.sqlite";
        public const string SQL_PATH = "database.sql";

        private Database()
        {
            StartDB();
        }

        public static Database Initialize()
        {
            if (instance == null)
            {
                instance = new Database();
                return instance;
            }
            return null;
        }

        private void StartDB()
        {
            bool justCreated = false;
            if (!File.Exists(DB_PATH))
            {
                justCreated = true;
                SQLiteConnection.CreateFile(DB_PATH);
            }

            _conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;;foreign keys=true;");
            _conn.Open();

            if (justCreated)
            {
                CreateDB();
            }
        }

        private void CreateDB()
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteTransaction transaction = null;
            command.CommandText = File.ReadAllText(SQL_PATH);

            try
            {
                transaction = _conn.BeginTransaction();
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                try
                {
                    File.Delete(SQL_PATH);
                }
                catch (Exception) { }

                if (transaction != null)
                    transaction.Rollback();
            }
        }

        private void ConnectDB()
        {
            _conn.Open();
        }

        private void CloseDB()
        {
            _conn.Close();
        }

        public bool DeleteDB()
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteTransaction transaction = null;

            command.CommandText =
                "DELETE FROM User; " +
                "DELETE FROM Department; " +
                "DELETE FROM Solver; " +
                "DELETE FROM Ticket; " +
                "DELETE FROM SecondaryQuestions; " +
                "DELETE FROM Email; " +
                "DELETE FROM Session";

            try
            {
                transaction = _conn.BeginTransaction();
                command.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (SQLiteException)
            {
                if (transaction != null)
                    transaction.Rollback();
                return false;
            }
        }

        public static string SafeGetString(SQLiteDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return null;
        }

        public static float SafeGetFloat(SQLiteDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetFloat(colIndex);
            return -1f;
        }

        #region User
        public bool ValidateUser(string email, string password)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT * FROM User WHERE email = @email AND password = @pass ";
            command.Parameters.Add(new SQLiteParameter("@email", email));
            command.Parameters.Add(new SQLiteParameter("@pass", password));

            try
            {
                reader = command.ExecuteReader();

                bool exists = reader.Read();
                reader.Close();
                return exists;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();

                return false;
            }
        }

        public bool InsertUser(string name, string email, string password)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);

            try
            {
                command.CommandText = "INSERT INTO User(name, email, password) VALUES (@name, @email, @password)";
                command.Parameters.Add(new SQLiteParameter("@name", name));
                command.Parameters.Add(new SQLiteParameter("@email", email));
                command.Parameters.Add(new SQLiteParameter("@password", password));

                int rowCount = command.ExecuteNonQuery();

                // If number of affected rows is lower than 1 return false
                return rowCount >= 1;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                return false;
            }
        }

        public User GetUser(int idUser)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;
            User userInfo = new User();

            command.CommandText = "SELECT * FROM User WHERE idUser = @user";
            command.Parameters.Add(new SQLiteParameter("@user", idUser));

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userInfo.Name = SafeGetString(reader, 1);
                    userInfo.ID = reader.GetInt32(0);
                    userInfo.Email = SafeGetString(reader, 2);
                    userInfo.Password = SafeGetString(reader, 3);
                }

                List<Ticket> tickets = GetUserTickets(userInfo);
                userInfo.Tickets = tickets;

                reader.Close();
                return userInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();

                return userInfo;
            }
        }

        public User GetUserByEmail(string email)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;
            User userInfo = new User();

            command.CommandText = "SELECT * FROM User WHERE email = @email";
            command.Parameters.Add(new SQLiteParameter("@email", email));

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userInfo.Name = SafeGetString(reader, 1);
                    userInfo.ID = reader.GetInt32(0);
                    userInfo.Email = SafeGetString(reader, 2);
                    userInfo.Password = SafeGetString(reader, 3);
                }

                List<Ticket> tickets = GetUserTickets(userInfo);
                userInfo.Tickets = tickets;

                reader.Close();
                return userInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();

                return userInfo;
            }
        }

        public List<Ticket> GetUserTickets(User user)
        {
            List<Ticket> tickets = new List<Ticket>();
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT * FROM Ticket WHERE idSender = @author";
            command.Parameters.Add(new SQLiteParameter("@author", user.ID));

            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.ID = reader.GetInt32(0);
                    ticket.Date = reader.GetDateTime(5);
                    ticket.Description = SafeGetString(reader, 4);
                    ticket.Title = SafeGetString(reader, 3);

                    string status = SafeGetString(reader, 6);

                    switch (status)
                    {
                        case "unassigned":
                            ticket.Status = TicketStatus.UNASSIGNED;
                            break;
                        case "assigned":
                            ticket.Status = TicketStatus.ASSIGNED;
                            break;
                        case "close":
                            ticket.Status = TicketStatus.CLOSED;
                            break;
                    }

                    tickets.Add(ticket);
                }

                reader.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();
            }

            return tickets;
        }

        public List<Ticket> GetUserTicketsPerType(User user, TicketStatus status)
        {
            List<Ticket> tickets = new List<Ticket>();
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT * FROM Ticket WHERE idSender = @author AND status = @status";
            command.Parameters.Add(new SQLiteParameter("@author", user.ID));

            if (status == TicketStatus.UNASSIGNED)
                command.Parameters.Add(new SQLiteParameter("@status", "unassigned"));
            else if (status == TicketStatus.ASSIGNED)
                command.Parameters.Add(new SQLiteParameter("@status", "assigned"));
            else if (status == TicketStatus.CLOSED)
                command.Parameters.Add(new SQLiteParameter("@status", "closed"));

            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.ID = reader.GetInt32(0);
                    ticket.Date = reader.GetDateTime(5);
                    ticket.Description = SafeGetString(reader, 4);
                    ticket.Title = SafeGetString(reader, 3);
                    ticket.Status = status;
                    
                    tickets.Add(ticket);
                }

                reader.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();
            }

            return tickets;
        }
        public bool UpdateUserInfo(string name, string email, string password, int id)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);

            command.CommandText = "UPDATE User SET name=@name, password=@pass, email=@email WHERE idUser=@id";
            command.Parameters.Add(new SQLiteParameter("@name", name));
            command.Parameters.Add(new SQLiteParameter("@email", email));
            command.Parameters.Add(new SQLiteParameter("@pass", password));
            command.Parameters.Add(new SQLiteParameter("@id", id));

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                return false;
            }
        }

        #endregion

        #region Solver

        public bool CheckSolver(string email, string password)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT idSolver FROM Solver WHERE idSolver IN (SELECT idUser FROM User WHERE email = @email AND password=@pass)";
            command.Parameters.Add(new SQLiteParameter("@email", email));
            command.Parameters.Add(new SQLiteParameter("@pass", password));

            try
            {
                reader = command.ExecuteReader();

                bool exists = reader.Read();
                reader.Close();
                return exists;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();

                return false;
            }
        }
        public int SelectLastUser()
        {
            int ID = 0;

            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;
            User userInfo = new User();

            command.CommandText = "SELECT idUser FROM User ORDER BY idUser DESC LIMIT 1";

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                    ID = reader.GetInt32(0);

                reader.Close();
                return ID;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();

                return ID;
            }
        }

        public bool InsertSolver(string name, string email, string password)
        {
            if(InsertUser(name, email, password))
            {
                int id = SelectLastUser();
                if (id != 0)
                {
                    SQLiteCommand command = new SQLiteCommand(_conn);

                    try
                    {
                        command.CommandText = "INSERT INTO Solver(idSolver) VALUES (@idSolver)";
                        command.Parameters.Add(new SQLiteParameter("@idSolver", id));

                        int rowCount = command.ExecuteNonQuery();

                        // If number of affected rows is lower than 1 return false
                        return rowCount >= 1;
                    }
                    catch (SQLiteException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);

                        return false;
                    }
                }

                return false;
            }
            return false;
        }

        public List<Ticket> GetTicketsUnassigned()
        {
            List<Ticket> tickets = new List<Ticket>();
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT * FROM Ticket WHERE idSolver IS NULL";

            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.ID = reader.GetInt32(0);
                    ticket.Date = reader.GetDateTime(5);
                    ticket.Description = SafeGetString(reader, 4);
                    ticket.Author = null;
                    ticket.Title = SafeGetString(reader, 3);
                    ticket.Status = TicketStatus.UNASSIGNED;
                    tickets.Add(ticket);
                }

                reader.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();
            }

            return tickets;
        }

        public List<Ticket> GetTicketsSolver(User solver)
        {
            List<Ticket> tickets = new List<Ticket>();
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT * FROM Ticket WHERE idSolver=@idSolver";
            command.Parameters.Add(new SQLiteParameter("@idSolver", solver.ID));

            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.ID = reader.GetInt32(0);
                    ticket.Date = reader.GetDateTime(5);
                    ticket.Description = SafeGetString(reader, 4);
                    ticket.Author = solver;
                    ticket.Title = SafeGetString(reader, 3);

                    string status = SafeGetString(reader, 6);

                    switch (status)
                    {
                        case "assigned":
                            ticket.Status = TicketStatus.ASSIGNED;
                            break;
                        case "close":
                            ticket.Status = TicketStatus.CLOSED;
                            break;
                    }

                    tickets.Add(ticket);
                }

                reader.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();
            }

            return tickets;
        }

        public List<Ticket> GetUserTicketsPerTypeSolver(User solver, TicketStatus status)
        {
            List<Ticket> tickets = new List<Ticket>();
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT * FROM Ticket WHERE idSolver = @solver AND status = @status";
            command.Parameters.Add(new SQLiteParameter("@solver", solver.ID));

            if (status == TicketStatus.ASSIGNED)
                command.Parameters.Add(new SQLiteParameter("@status", "assigned"));
            else if (status == TicketStatus.CLOSED)
                command.Parameters.Add(new SQLiteParameter("@status", "closed"));

            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.ID = reader.GetInt32(0);
                    ticket.Date = reader.GetDateTime(5);
                    ticket.Description = SafeGetString(reader, 4);
                    ticket.Title = SafeGetString(reader, 3);
                    ticket.Author = solver;
                    ticket.Status = status;

                    tickets.Add(ticket);
                }

                reader.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();
            }

            return tickets;
        }

        #endregion

        #region Department

        public int GetDepartmentByName(string name)
        {
            int id = 0;
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT idDepartment FROM Department WHERE name=@name";
            command.Parameters.Add(new SQLiteParameter("@name", name));

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                    id = reader.GetInt32(0);

                reader.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();
            }

            return id;
        }
        public bool CheckDepartment(string name)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT * FROM Department WHERE name=@name";
            command.Parameters.Add(new SQLiteParameter("@name", name));

            try
            {
                reader = command.ExecuteReader();

                bool exists = reader.Read();
                reader.Close();
                return exists;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();

                return false;
            }
        }

        public bool InsertDepartment(string name)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);

            try
            {
                command.CommandText = "INSERT INTO Department(name) VALUES (@name)";
                command.Parameters.Add(new SQLiteParameter("@name", name));

                int rowCount = command.ExecuteNonQuery();

                // If number of affected rows is lower than 1 return false
                return rowCount >= 1;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                return false;
            }
        }

        #endregion

        #region Session

        public bool InsertSession(int idUser, string session)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);

            command.CommandText = "INSERT INTO Session(sessionID, userID) VALUES (@session, @userID)";
            command.Parameters.Add(new SQLiteParameter("@session", session));
            command.Parameters.Add(new SQLiteParameter("@userID", idUser));

            try
            {
                int rowCount = command.ExecuteNonQuery();
                // If number of affected rows is lower than 1 return false
                return rowCount >= 1;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                return false;
            }
        }

        public int GetUserID(string session)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT userID FROM Session WHERE sessionID = @session";
            command.Parameters.Add(new SQLiteParameter("@session", session));

            try
            {
                reader = command.ExecuteReader();
                int ID = 0;

                if (reader.Read())
                {
                    ID = reader.GetInt32(0);
                }

                reader.Close();
                return ID;
            }
            catch (Exception)
            {
                if (reader != null)
                    reader.Close();
            }

            return 0;
        }

        public void DeleteSession(int idUser)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);

            command.CommandText = "DELETE FROM Session WHERE idUser=@user";
            command.Parameters.Add(new SQLiteParameter("@user", idUser));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SQLiteException)
            {
            }
        }
        
        #endregion

        #region Ticket

        public bool InsertTicket(int idUser, string title, string description)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);

            command.CommandText = "INSERT INTO Ticket(idSender, idSolver, title, description, dateTime, status) VALUES (@idSender, @idSolver, @title, @description, @date, @status)";
            command.Parameters.Add(new SQLiteParameter("@idSender", idUser));
            command.Parameters.Add(new SQLiteParameter("@idSolver", null));
            command.Parameters.Add(new SQLiteParameter("@title", title));
            command.Parameters.Add(new SQLiteParameter("@description", description));
            command.Parameters.Add(new SQLiteParameter("@date", DateTime.Now));
            command.Parameters.Add(new SQLiteParameter("@status", "unassigned"));

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public Ticket GetTicket(User user, int idTicket)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;
            Ticket ticket = new Ticket();

            command.CommandText = "SELECT * FROM Ticket WHERE idTicket = @ticket";
            command.Parameters.Add(new SQLiteParameter("@user", idTicket));

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ticket.ID = reader.GetInt32(0);
                    ticket.Author = user;
                    ticket.Title = SafeGetString(reader, 3);
                    ticket.Description = SafeGetString(reader, 4);
                    ticket.Date = reader.GetDateTime(5);

                    string status = SafeGetString(reader, 6);

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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();

                return ticket;
            }
        }
        public bool SolveTicket(int idTicket)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            command.CommandText = "UPDATE Ticket SET status='closed' WHERE idTicket=@ticket";
            command.Parameters.Add(new SQLiteParameter("@ticket", idTicket));

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                return false;
            }
        }

        public bool AssignTicket(int idTicket, int idSolver)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);
            command.CommandText = "UPDATE Ticket SET status='assigned', idSolver=@solver WHERE idTicket=@ticket";
            command.Parameters.Add(new SQLiteParameter("@solver", idSolver));
            command.Parameters.Add(new SQLiteParameter("@ticket", idTicket));

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                return false;
            }
        }

        #endregion

        #region SecondaryQuestion

        public bool InsertSecondaryQuestion(int idTicket, int idSender, string question)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);

            command.CommandText = "INSERT INTO SecondaryQuestions(idTicket, idSender, idDepartment, question, response, dateTime) VALUES (@idTicket, @idSender, @idDepartment, @response, @date)";
            command.Parameters.Add(new SQLiteParameter("@idTicket", idTicket));
            command.Parameters.Add(new SQLiteParameter("@idSender", idSender));
            command.Parameters.Add(new SQLiteParameter("@idDepartment", null));
            command.Parameters.Add(new SQLiteParameter("@question", question));
            command.Parameters.Add(new SQLiteParameter("@response", null));
            command.Parameters.Add(new SQLiteParameter("@date", DateTime.Now));

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool AnswerSecondaryQuestion(SecondaryQuestion question, string department, string response)
        {
            int id = GetDepartmentByName(department);
            question.Department = id;
            question.Response = response;

            SQLiteCommand command = new SQLiteCommand(_conn);
            command.CommandText = "UPDATE SecondaryQuestion SET idDepartment=@id, response=@response WHERE idQuestion=@question";
            command.Parameters.Add(new SQLiteParameter("@id", id));
            command.Parameters.Add(new SQLiteParameter("@response", response));
            command.Parameters.Add(new SQLiteParameter("@question", question.ID));

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                return false;
            }
        }

        public List<SecondaryQuestion> GetSecondaryQuestions()
        {
            List<SecondaryQuestion> questions = new List<SecondaryQuestion>();
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT * FROM SecondaryQuestions WHERE idDepartment IS NULL AND response IS NULL";

            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SecondaryQuestion question = new SecondaryQuestion();
                    question.ID = reader.GetInt32(0);
                    question.Date = reader.GetDateTime(6);
                    question.SenderID = reader.GetInt32(2);
                    question.TicketID = reader.GetInt32(1);
                    question.Question = SafeGetString(reader, 4);

                    questions.Add(question);
                }

                reader.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();
            }

            return questions;
        }

        public SecondaryQuestion GetSecondaryQuestion(int questionID)
        {
            SecondaryQuestion question = new SecondaryQuestion();
            SQLiteCommand command = new SQLiteCommand(_conn);
            SQLiteDataReader reader = null;

            command.CommandText = "SELECT * FROM SecondaryQuestions WHERE idQuestion=@ID";
            command.Parameters.Add(new SQLiteParameter("@ID", questionID));

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    question.ID = questionID;
                    question.TicketID = reader.GetInt32(1);
                    question.SenderID = reader.GetInt32(2);
                    question.Department = reader.GetInt32(3);
                    question.Question = SafeGetString(reader, 4);
                    question.Response = SafeGetString(reader, 5);
                    question.Date = reader.GetDateTime(6);
                }

                reader.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                if (reader != null)
                    reader.Close();
            }

            return question;
        }

        #endregion

        #region Email

        public bool InsertEmail(int idSolver, int idSender, int idTicket, string content)
        {
            SQLiteCommand command = new SQLiteCommand(_conn);

            try
            {
                command.CommandText = "INSERT INTO User(idSender, idReceiver, idTicket, content, dateTime) VALUES (@idSender, @idReceiver, @idTicket, @content, @date)";
                command.Parameters.Add(new SQLiteParameter("@idSender", idSolver));
                command.Parameters.Add(new SQLiteParameter("@idReceiver", idSender));
                command.Parameters.Add(new SQLiteParameter("@idTicket", idTicket));
                command.Parameters.Add(new SQLiteParameter("@content", content));
                command.Parameters.Add(new SQLiteParameter("@date", DateTime.Now));

                int rowCount = command.ExecuteNonQuery();

                // If number of affected rows is lower than 1 return false
                return rowCount >= 1;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                return false;
            }
        }

        #endregion
    }
}
