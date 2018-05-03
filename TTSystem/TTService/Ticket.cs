using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTService
{
    public enum TicketStatus
    {
        UNASSINGNED, ASSIGNED, CLOSED
    }
    public class Ticket
    {
        public string ID { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime Date { get; set; }
    }
}