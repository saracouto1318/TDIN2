using System.Windows.Forms;

namespace SolverGUI
{
    public class FormsManager
    {
        public MainPage MainPage { get; set; }

        public PersonalPage PersonalPage { get; set; }

        public RedirectPage RedirectPage { get; set; }

        public SolvePage SolvePage { get; set; }

        public TicketPage TicketPage { get; set; }

        public FormsManager()
        {
            MainPage = new MainPage();
            PersonalPage = new PersonalPage();
            RedirectPage = new RedirectPage();
            SolvePage = new SolvePage();
            TicketPage = new TicketPage();

            MainPage.FormClosing += (s, e) => { Application.Exit(); };
            PersonalPage.FormClosing += (s, e) => { Application.Exit(); };
            RedirectPage.FormClosing += (s, e) => { Application.Exit(); };
            SolvePage.FormClosing += (s, e) => { Application.Exit(); };
            TicketPage.FormClosing += (s, e) => { Application.Exit(); };
        }
    }
}
