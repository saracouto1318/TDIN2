using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using SolverGUI;
using TTService;
using System.Collections.Generic;

namespace GUI.Forms
{
    public partial class Questions : MaterialForm
    {
        public Client ClientInstance;
        public TableLayoutPanel Panel = new TableLayoutPanel();
        private bool IsShowingOpen = false;
        private IQuestionStatusPanel StatusPanelController;

        public Questions()
        {
            ClientInstance = Client.Instance;

            InitializeComponent();
            
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            LoadUserInfo();

            StatusPanelController = QuestionStatusPanelFactory.GetStatusPanelController(IsShowingOpen);
            CreateTable(IsShowingOpen);

            this.VisibleChanged += OnVisibleChange;
        }

        private bool CheckExist(bool value)
        {
            return ClientInstance.SolverProxy.MyQuestions(ClientInstance.Solver.ID, value).Length > 0;
        }

        #region Panel
        public void QuestionClickAction(SecondaryQuestion secondaryQuestion)
        {
            FormController.ChangeForm(this, new QuestionPage(secondaryQuestion));
        }

        public void CreateTable(bool isOpen)
        {
            List<SecondaryQuestion> secondaryQuestions;
            if (isOpen)
                secondaryQuestions = ClientInstance.TroubleTickets.OpenSecondaryQuestion;
            else
                secondaryQuestions = ClientInstance.TroubleTickets.ClosedSecondaryQuestion;

            if (secondaryQuestions.Count <= 0)
            {
                Panel.Dispose();
                return;
            }

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            LoadTable(secondaryQuestions);
        }

        public void LoadTable(List<SecondaryQuestion> secondaryQuestions)
        {
            IPanelRow panelRow = new TitleQuestionPanelRowImpl();

            Panel.Visible = true;
            float value = 100 / (secondaryQuestions.Count + 1);

            CreatePanel();
            Panel.SuspendLayout();

            panelRow.AddPanelRow(Panel, value, null, () => { });

            panelRow = new QuestionPanelRowImpl();
            foreach (SecondaryQuestion q in secondaryQuestions)
            {
                panelRow.AddPanelRow(Panel, value, q, () => { QuestionClickAction(q); });
            }

            Panel.ResumeLayout();
        }

        private void CreatePanel()
        {
            Panel.Dispose();
            Panel = new TableLayoutPanel
            {
                BackColor = SystemColors.ButtonHighlight,
                BackgroundImageLayout = ImageLayout.Center,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                ColumnCount = 4
            };

            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 25F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 25F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 25F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 25F));
            Panel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, (0));
            Panel.Location = new Point(100, 221);
            Panel.Name = "tableLayoutPanel1";
            Panel.Size = new Size(260, 40);
            Panel.AutoSize = true;

            Controls.Add(Panel);
        }
        #endregion

        #region Form
        private void UpdatePanelStatus(bool isOpen)
        {
            IsShowingOpen = isOpen;
            StatusPanelController = QuestionStatusPanelFactory.GetStatusPanelController(IsShowingOpen);
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

        private void LoadUserInfo()
        {
            this.name.Text = ClientInstance.Solver.Name;
            this.email.Text = ClientInstance.Solver.Email;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            ClientInstance.UnitializeSolverSession();
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID);

            FormController.ChangeForm(this, new MainPage());
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            label2.Visible = false;

            UpdatePanelStatus(true);

            if (!CheckExist(true))
            {
                label2.Visible = true;
                Panel.Visible = false;
            }
            else
            {
                label2.Visible = false;
                Panel.Visible = true;
                CreateTable(true);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;

            UpdatePanelStatus(false);

            if (!CheckExist(false))
            {
                label1.Visible = true;
                Panel.Visible = false;
            }
            else
            {
                label1.Visible = false;
                Panel.Visible = true;
                CreateTable(false);
            }
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            FormController.ChangeForm(this, new PersonalPage());
        }

        private void Questions_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        #endregion

        #region Events
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
            if(StatusPanelController != null)
            {
                StatusPanelController.AnsweredQuestion(this, secondaryQuestion, ticket);
            }
        }
        #endregion
    }
}
