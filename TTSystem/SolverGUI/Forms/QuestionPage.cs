﻿using MaterialSkin;
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
using TTService;

namespace GUI.Forms
{
    public partial class QuestionPage : MaterialForm
    {
        public Client client;
        public int idUser;
        public User user;
        public int idQuestion;
        public SecondaryQuestion secQuestion;
        public QuestionPage(int idUser, int idQuestion)
        {
            client = Client.Instance;

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
            this.user = client.Proxy.GetUser(idUser);
        }

        public void GetQuestionInfo()
        {
            this.secQuestion = client.Proxy.GetQuestion(idQuestion);
            status.Text = (secQuestion.Response == null) ? "Open" : "Closed";
            ticketID.Text = "Ticket #" + secQuestion.TicketID.ToString();
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
            client.Proxy.Logout(user.ID);
            Hide();
            new MainPage().ShowDialog();
            Show();
        }

        private void QuestionPage_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
