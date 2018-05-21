using MaterialSkin;
using MaterialSkin.Controls;
using System;
using TTService;

namespace SolverGUI
{
    public partial class MainPage : MaterialForm
    {
        private Client ClientInstance;

        public MainPage()
        {
            ClientInstance = Client.Instance;

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

            if(ClientInstance.LoginUser(email,password))
            {
                Hide();
                new PersonalPage().ShowDialog();
                Show();
            }
            else
            {
                labelLogin.Visible = true;
            }
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string name = nameRegister.Text;
            string email = emailRegister.Text;
            string password = passwordRegister.Text;

            if(ClientInstance.RegisterSolver(email, name, password))
            {
                Hide();
                new PersonalPage().ShowDialog();
                Show();
            }
            else
            {
                labelRegister.Visible = true;
            }
        }
    }
}
