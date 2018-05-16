using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTService
{
    [Serializable]
    public class SecondaryQuestion
    {
        public int ID { get; set; }
        public int TicketID { get; set; }
        public int SenderID { get; set; }
        public DateTime Date { get; set; }
        public int Department { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
    }
}
