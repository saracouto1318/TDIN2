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
        public Client ClientInstance;
        public int IDQuestion;
        public SecondaryQuestion SecQuestion;

        public QuestionPage(int idQuestion)
        {
            ClientInstance = Client.Instance;

            InitializeComponent();
            
            this.SecQuestion = new SecondaryQuestion();
            this.IDQuestion = idQuestion;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            
            GetQuestionInfo();
        }

        public void GetQuestionInfo()
        {
            this.SecQuestion = ClientInstance.Proxy.GetQuestion(IDQuestion);
            status.Text = (SecQuestion.Response == null) ? "Open" : "Closed";
            ticketID.Text = "Ticket #" + SecQuestion.TicketID.ToString();
            date.Text = SecQuestion.Date.ToString();
            question.Text = SecQuestion.Question.ToString();

            if (SecQuestion.Response == null)
            {
                response.Visible = false;
                label1.Visible = false;
            }
            else
                response.Text = SecQuestion.Response.ToString();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new PersonalPage().ShowDialog();
            Show();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID);
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
