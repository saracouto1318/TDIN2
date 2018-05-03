using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTService
{
    public class User
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Ticket> tickets { get; set; }
    }
}