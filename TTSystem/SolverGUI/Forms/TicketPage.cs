using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTService;

namespace SolverGUI
{
    public partial class TicketPage : MaterialForm
    {
        public Client ClientInstance;
        public Ticket TicketInfo;

        public TicketPage(Ticket ticket)
        {
            ClientInstance = Client.Instance;
            InitializeComponent();
            
            TicketInfo = ticket;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            LoadTicketInfo();
        }

        public void LoadTicketInfo()
        {
            ticketLabel.Text = "Ticket #" + this.TicketInfo.ID.ToString();
            title.Text = this.TicketInfo.Title;
            date.Text = this.TicketInfo.Date.ToString();
            description.Text = this.TicketInfo.Description;
            status.Text = this.TicketInfo.Status.ToString();

            if (TicketInfo.Status == TicketStatus.CLOSED)
            {
                this.assignBtn.Visible = false;
                this.solveBtn.Visible = false;
                this.redirectBtn.Visible = false;
            }
            else if (TicketInfo.Status == TicketStatus.ASSIGNED)
                this.assignBtn.Visible = false;
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

        private void SolveBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new SolvePage(TicketInfo).ShowDialog();
            Show();
        }

        private void RedirectBtn_Click(object sender, EventArgs e)
        {
            redirectBtn.Visible = false;
            Hide();
            new RedirectPage(TicketInfo).ShowDialog();
            Show();
        }

        private void AssignBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if(ClientInstance.SolverProxy.AssignTicket(TicketInfo.ID, ClientInstance.Solver.ID))
                {
                    MessageBox.Show("Ticket " + TicketInfo.Title + " was assigned to you");
                }
            });
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
