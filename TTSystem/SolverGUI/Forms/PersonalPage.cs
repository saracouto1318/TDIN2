﻿using System;
using GUI.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SolverGUI
{
    public partial class PersonalPage : MaterialForm
    {
        public Client ClientInstance;

        public PersonalPage()
        {
            ClientInstance = Client.Instance;

            InitializeComponent();
            
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            GetUserInfo();
        }

        public void GetUserInfo()
        {
            name.Text = ClientInstance.Solver.Name;
            email.Text = ClientInstance.Solver.Email;
            ticketsOpen.Text = 
                ClientInstance.SolverProxy.GetUnassignedTT().Length.ToString();
            tickets.Text = 
                ClientInstance.SolverProxy.GetSolverTT(ClientInstance.Solver).Length.ToString();
            questionsOpen.Text = 
                ((ClientInstance.SolverProxy.MyQuestions(ClientInstance.Solver.ID, true).Length) + 
                (ClientInstance.SolverProxy.MyQuestions(ClientInstance.Solver.ID, false).Length)).ToString();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Hide();
            ClientInstance.UnitializeSolverSession();
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID); 
            new MainPage().ShowDialog();
            Show();
        }

        private void TtBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new Tickets().ShowDialog();
            Show();
        }

        private void QuestionBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new Questions().ShowDialog();
            Show();
        }
    }
}
