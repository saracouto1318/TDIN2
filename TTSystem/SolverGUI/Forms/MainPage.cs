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
    public partial class MainPage : MaterialForm
    {
        public TTServClient proxy;
        public MainPage()
        {
            proxy = new TTServClient();
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = emailLogin.Text;
            string password = passwordLogin.Text;

            if (proxy.CheckSolver(email, password))
            {
                User user = proxy.GetUserByEmail(email);
                proxy.Login(user.ID);
                Hide();
                new PersonalPage(user.ID).ShowDialog();
                Show();
            }
            else
                labelLogin.Visible = true;

        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string name = nameRegister.Text;
            string email = emailRegister.Text;
            string password = passwordRegister.Text;

            if (!proxy.AddSolver(name, email, password))
                labelRegister.Visible = true;
            else
            {
                User user = proxy.GetUserByEmail(email);
                proxy.Login(user.ID);
                Hide();
                new PersonalPage(user.ID).ShowDialog();
                Show();
            }
        }
    }
}
