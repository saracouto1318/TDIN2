using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTService
{
    public enum Status
    {
        unassigned, assigned, closed
    }
    public class Ticket
    {
        public string ID { get; set; }
        public User owner { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Status status { get; set; }
        public DateTime date { get; set; }
    }
}