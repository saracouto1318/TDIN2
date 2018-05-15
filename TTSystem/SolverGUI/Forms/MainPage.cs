using GUI.TTSvc;
using MaterialSkin;
using MaterialSkin.Controls;
using System;

namespace SolverGUI
{
    public partial class MainPage : MaterialForm
    {
        private Client client;

        public MainPage()
        {
            client = Client.Instance;

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

            if (client.Proxy.LoginSolver(email, password))
            {
                User user = client.Proxy.GetUserByEmail(email);
                client.Proxy.Login(user.ID);
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

            if (!client.Proxy.RegisterSolver(name, email, password))
                labelRegister.Visible = true;
            else
            {
                User user = client.Proxy.GetUserByEmail(email);
                client.Proxy.Login(user.ID);
                Hide();
                new PersonalPage(user.ID).ShowDialog();
                Show();
            }
        }
    }
}
