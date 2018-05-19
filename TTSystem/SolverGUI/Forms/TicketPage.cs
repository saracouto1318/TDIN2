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
    public partial class TicketPage : MaterialForm
    {
        public Client client;

        public User user;
        public Ticket ticketInfo;
        public int ticketID;
        public TicketPage(User user, int ticketID)
        {
            client = Client.Instance;
            InitializeComponent();

            this.user = user;
            this.ticketID = ticketID;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            GetTicketInfo();
        }

        public void GetTicketInfo()
        {
            this.ticketInfo = client.Proxy.GetTicket(this.ticketID);
            ticketLabel.Text = "Ticket #" + this.ticketInfo.ID.ToString();
            title.Text = this.ticketInfo.Title;
            date.Text = this.ticketInfo.Date.ToString();
            description.Text = this.ticketInfo.Description;
            status.Text = this.ticketInfo.Status.ToString();

            if (this.ticketInfo.Status == TicketStatus.CLOSED)
            {
                this.assignBtn.Visible = false;
                this.solveBtn.Visible = false;
                this.redirectBtn.Visible = false;
            }
            else if (this.ticketInfo.Status == TicketStatus.ASSIGNED)
                this.assignBtn.Visible = false;
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
            client.SolverProxy.Unsubscribe();
            client.Proxy.Logout(user.ID);
            new MainPage().ShowDialog();
            Show();
        }

        private void SolveBtn_Click(object sender, EventArgs e)
        {
            Hide();
            client.SolverProxy.AssignTicket(ticketInfo.ID, user.ID);
            new SolvePage(user, ticketInfo).ShowDialog();
            Show();
        }

        private void RedirectBtn_Click(object sender, EventArgs e)
        {
            redirectBtn.Visible = false;
            Hide();
            client.SolverProxy.AssignTicket(ticketInfo.ID, user.ID);
            new RedirectPage(user, ticketInfo).ShowDialog();
            Show();
        }

        private void AssignBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                client.SolverProxy.AssignTicket(ticketInfo.ID, user.ID);
            });
            //MessageBox.Show("Ticket " + ticketInfo.ID.ToString() + " was assigned to you");
        }

        private void TicketPage_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
