using DepartmentGUI.TTSvc;
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

namespace DepartmentGUI
{
    public partial class TicketQuestion : MaterialForm
    {
        public TTServClient proxy;
        public int idQuestion;
        public SecondaryQuestion secQuestion;
        public TicketQuestion(int idQuestion)
        {
            proxy = new TTServClient();

            InitializeComponent();

            this.idQuestion = idQuestion;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            GetQuestionInfo();
        }

        public void GetQuestionInfo()
        {
            this.secQuestion = proxy.GetQuestion(this.idQuestion);
            ticketID.Text = this.secQuestion.TicketID.ToString();
            question.Text = this.secQuestion.Question;
        }

        private void AnswerBtn_Click(object sender, EventArgs e)
        {
            Hide();
            Program.Forms.idQuestion = this.idQuestion;
            Program.Forms.ResponseTicket.Show();
        }
    }
}
