using GUI.TTSvc;
using MaterialSkin;
using MaterialSkin.Controls;
using SolverGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class QuestionPage : MaterialForm
    {
        public TTServClient proxy;
        public int idUser;
        public User user;
        public int idQuestion;
        public SecondaryQuestion secQuestion;
        public QuestionPage(int idUser, int idQuestion)
        {
            InitializeComponent();

            proxy = new TTServClient();

            InitializeComponent();

            this.user = new User();
            this.secQuestion = new SecondaryQuestion();
            this.idUser = idUser;
            this.idQuestion = idQuestion;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            GetUserInfo();
            GetQuestionInfo();
        }

        public void GetUserInfo()
        {
            this.user = proxy.GetUser(idUser);
        }

        public void GetQuestionInfo()
        {
            this.secQuestion = proxy.GetQuestion(idQuestion);
            status.Text = (secQuestion.Response == null) ? "Open" : "Closed";
            ticketID.Text = secQuestion.TicketID.ToString();
            date.Text = secQuestion.Date.ToString();
            question.Text = secQuestion.Question.ToString();

            if (secQuestion.Response == null)
            {
                response.Visible = false;
                label1.Visible = false;
            }
            else
                response.Text = secQuestion.Response.ToString();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Hide();
            Hide();
            new PersonalPage(user.ID).ShowDialog();
            Show();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            proxy.Logout(user.ID);
            Hide();
            new MainPage().ShowDialog();
            Show();
        }
    }
}
