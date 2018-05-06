using System.Windows.Forms;

namespace DepartmentGUI
{
    public class FormsManager
    {
        public string name { get; set; }
        public int idQuestion { get; set; }
        public CheckDepartment CheckDepartment { get; set; }

        public DepartmentPage DepartmentPage { get; set; }

        public ResponseTicket ResponseTicket { get; set; }

        public TicketQuestion TicketQuestion { get; set; }

        public FormsManager()
        {
            CheckDepartment = new CheckDepartment();
            DepartmentPage = new DepartmentPage();
            ResponseTicket = new ResponseTicket(idQuestion);
            TicketQuestion = new TicketQuestion(idQuestion);

            CheckDepartment.FormClosing += (s, e) => { Application.Exit(); };
            DepartmentPage.FormClosing += (s, e) => { Application.Exit(); };
            ResponseTicket.FormClosing += (s, e) => { Application.Exit(); };
            TicketQuestion.FormClosing += (s, e) => { Application.Exit(); };
        }
    }
}
