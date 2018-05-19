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
using TTService;

namespace DepartmentGUI
{
    public partial class TicketQuestion : MaterialForm
    {
        public TTServClient proxy;
        public int idQuestion;
        public SecondaryQuestion secQuestion;
        public string name;
        public TicketQuestion(int idQuestion, string name)
        {
            proxy = new TTServClient();

            InitializeComponent();

            this.idQuestion = idQuestion;
            this.name = name;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            GetQuestionInfo();
        }

        public void GetQuestionInfo()
        {
            this.secQuestion = proxy.GetQuestion(this.idQuestion);
            ticketID.Text = "Ticket #" + this.secQuestion.TicketID.ToString();
            question.Text = this.secQuestion.Question;
        }

        private void AnswerBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new ResponseTicket(this.idQuestion, this.name).ShowDialog();
            Show();
        }

        private void DepartmentBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new DepartmentPage(this.name).ShowDialog();
            Show();
        }
    }
}
