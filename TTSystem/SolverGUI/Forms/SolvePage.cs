using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTService;

namespace SolverGUI
{
    public partial class SolvePage : MaterialForm
    {
        public Client ClientInstance;
        public Ticket TTicket;

        public SolvePage(Ticket ticket)
        {
            ClientInstance = Client.Instance;

            InitializeComponent();

            this.TTicket = ticket;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            GetTicketInfo();
        }
        public void GetTicketInfo()
        {
            ticketID.Text = "Ticket #" + this.TTicket.ID.ToString();
            title.Text = this.TTicket.Title;
        }

        private void TicketBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new TicketPage(TTicket).ShowDialog();
            Show();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new PersonalPage().ShowDialog();
            Show();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Hide();
            ClientInstance.UnitializeSolverSession();
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID);
            new MainPage().ShowDialog();
            Show();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            string emailText = email.Text;
            ClientInstance.SolverProxy.AnswerTicket(ClientInstance.Solver.ID, TTicket.Author.ID, TTicket.ID, emailText);
            new TicketPage(TTicket).ShowDialog();
            Show();
        }
    }
}
