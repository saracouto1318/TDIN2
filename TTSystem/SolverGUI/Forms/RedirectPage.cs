using GUI.Forms;
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
    public partial class RedirectPage : MaterialForm
    {
        public Client ClientInstance;
        public Ticket TTicket;

        public RedirectPage(Ticket ticket)
        {
            ClientInstance = Client.Instance;
            
            InitializeComponent();
            
            this.TTicket = ticket;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            LoadTicketInfo();
            GetDepartments();
        }

        public void LoadTicketInfo()
        {
            ticketLabel.Text = "Ticket #" + this.TTicket.ID.ToString();
            title.Text = this.TTicket.Title;
        }

        public void GetDepartments()
        {
            String[] departments = ClientInstance.Proxy.GetDepartments();
            foreach (string department in departments)
            {
                this.departments.Items.Add(department);
            }
        }

        private void TicketBtn_Click(object sender, EventArgs e)
        {
            FormController.ChangeForm(this, new TicketPage(TTicket));
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            FormController.ChangeForm(this, new PersonalPage());
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Hide();
            ClientInstance.UnitializeSolverSession();
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID);
            new MainPage().ShowDialog();
            Show();
        }

        private void RedirectBtn_Click(object sender, EventArgs e)
        {
            string department = this.departments.SelectedItem.ToString();

            if (department == "Other")
                department = this.textBox.Text;
            
            string redirect = message.Text;
            SecondaryQuestion sq = ClientInstance.SolverProxy.RedirectTicket(TTicket.ID, ClientInstance.Solver.ID, redirect, department);
            if (sq != null)
            {
                TTicket.Status = TicketStatus.WAITING;
                ClientInstance.TroubleTickets.OnWaitingSecondaryQuestion(TTicket, sq);

                FormController.ChangeForm(this, new QuestionPage(sq));
            }
            else
            {
                FormController.ChangeForm(this, new MainPage());
            }
        }

        private void Departments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.departments.SelectedItem.ToString() == "Other")
                this.textBox.Visible = true;
        }
    }
}
