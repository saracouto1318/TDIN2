using GUI.TTSvc;
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

namespace SolverGUI
{
    public partial class RedirectPage : MaterialForm
    {
        public TTServClient proxy;
        public User user;
        public Ticket ticket;
        public RedirectPage(User user, Ticket ticket)
        {
            proxy = new TTServClient();
            InitializeComponent();

            this.user = user;
            this.ticket = ticket;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            GetTicketInfo();
        }

        public void GetTicketInfo()
        {
            ticketLabel.Text = "Ticket #" + this.ticket.ID.ToString();
            title.Text = this.ticket.Title;
        }

        private void TicketBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new TicketPage(user, ticket.ID).ShowDialog();
            Show();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new PersonalPage(user.ID).ShowDialog();
            Show();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Hide();
            proxy.Logout(user.ID);
            new MainPage().ShowDialog();
            Show();
        }

        private void RedirectBtn_Click(object sender, EventArgs e)
        {
            Hide();
            string redirect = message.Text;
            proxy.RedirectTicket(ticket.ID, user.ID, redirect);
            new TicketPage(user, ticket.ID).ShowDialog();
            Show();
        }
    }
}
