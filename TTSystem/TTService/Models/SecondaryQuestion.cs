using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTService
{
    public class SecondaryQuestion
    {
        public int ID { get; set; }
        public int TicketID { get; set; }
        public int SenderID { get; set; }
        public DateTime Date { get; set; }
        public int Department { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
        public override bool Equals(Object obj)
        {
            if (!(obj is SecondaryQuestion sqObj))
                return false;
            else
                return ID == sqObj.ID;
        }
        public override int GetHashCode()
        {
            return 1213502048 + ID.GetHashCode();
        }
    }
}
