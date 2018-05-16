using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTService
{
    public enum TicketStatus
    {
        UNASSIGNED, ASSIGNED, CLOSED
    }

    [Serializable]
    public class Ticket
    {
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime Date { get; set; }
    }
}