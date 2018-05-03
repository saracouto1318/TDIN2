using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace TTService {
  [ServiceContract]
  public interface ITTServ {
        [OperationContract]
        int AddUser(User user);

        [OperationContract]
        bool CheckUser(string email);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        bool UpdateUser(User user);

        [OperationContract]
        int AddTicket(Ticket ticket);

        [OperationContract]
        List<Ticket> GetTickets(int author);

        [OperationContract]
        List<Ticket> GetTicketsByType(int author, string type);

        [OperationContract]
        Ticket GetTicket(int id);
    }
}