using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using TTService;

namespace SolverGUI
{
    public partial class PersonalPage : MaterialForm
    {
        public Client client;
        public int idUser;
        public User user;
        public PersonalPage(int idUser)
        {
            client = Client.Instance;

            InitializeComponent();

            this.user = new User();
            this.idUser = idUser;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            GetUserInfo();
        }

        public void GetUserInfo()
        {
            this.user = client.Proxy.GetUser(idUser);
            name.Text = this.user.Name;
            email.Text = this.user.Email;
            ticketsOpen.Text = client.SolverProxy.GetUnassignedTT().Length.ToString();
            tickets.Text = client.SolverProxy.GetSolverTT(this.user).Length.ToString();
            questionsOpen.Text = ((client.SolverProxy.MyQuestions(this.user.ID, true).Length) + (client.SolverProxy.MyQuestions(this.user.ID, false).Length)).ToString();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Hide();
            client.SolverProxy.Unsubscribe();
            client.Proxy.Logout(user.ID); 
            new MainPage().ShowDialog();
            Show();
        }

        private void TtBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new Tickets(this.user.ID).ShowDialog();
            Show();
        }

        private void QuestionBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new Questions(this.user.ID).ShowDialog();
            Show();
        }
    }
}
