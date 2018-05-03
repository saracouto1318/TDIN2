using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TTService {
  public class TTServ : ITTServ {

        private Database.Database _db = Database.Database.Initialize();

        public int AddTicket(User author, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public int AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public int AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool CheckUser(string email)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsByType(int author, string type)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTickets(int author)
        {
            throw new NotImplementedException();
        }
    }
}
