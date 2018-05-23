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
using TTService;

namespace GUI.Forms
{
    public partial class QuestionPage : MaterialForm
    {
        public Client ClientInstance;
        public SecondaryQuestion SecQuestion;

        public QuestionPage(SecondaryQuestion secondaryQuestion)
        {
            ClientInstance = Client.Instance;

            InitializeComponent();
            
            this.SecQuestion = secondaryQuestion;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            
            LoadQuestionInfo();

            this.VisibleChanged += OnVisibleChange;
        }

        public void LoadQuestionInfo()
        {
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

        private void OnVisibleChange(object sender, EventArgs e)
        {
            if (!Visible)
            {
                UnsubscribeEvents();
            }
            else
            {
                SubscribeEvents();
            }
        }

        private void SubscribeEvents()
        {
            ClientInstance.TroubleTickets.OnAnsweredSecondaryQuestion += OnAnsweredQuestion;
        }

        private void UnsubscribeEvents()
        {
            ClientInstance.TroubleTickets.OnAnsweredSecondaryQuestion -= OnAnsweredQuestion;
        }

        private void OnAnsweredQuestion(Ticket ticket, SecondaryQuestion secondaryQuestion)
        {
            if(SecQuestion.ID == secondaryQuestion.ID)
            {
                SecQuestion = secondaryQuestion;
                status.Text = (SecQuestion.Response == null) ? "Open" : "Closed";
                response.Text = SecQuestion.Response.ToString();
                response.Visible = true;
                label1.Visible = true;
            }
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            FormController.ChangeForm(this, new PersonalPage());
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            ClientInstance.UnitializeSolverSession();
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID);

            FormController.ChangeForm(this, new MainPage());
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
