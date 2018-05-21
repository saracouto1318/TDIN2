using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using SolverGUI;
using TTService;

namespace GUI.Forms
{
    public partial class Questions : MaterialForm
    {
        public Client ClientInstance;
        private TableLayoutPanel Panel = new TableLayoutPanel();

        public Questions()
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
            this.name.Text = ClientInstance.Solver.Name;
            this.email.Text = ClientInstance.Solver.Email;
        }

        private bool CheckExist(bool value)
        {
            return ClientInstance.SolverProxy.MyQuestions(ClientInstance.Solver.ID, value).Length > 0;
        }

        private void CreateTable(bool value)
        {
            SecondaryQuestion[] questions;

            questions = ClientInstance.SolverProxy.MyQuestions(ClientInstance.Solver.ID, value);


            Panel.Visible = true;
            float rows = 100 / (questions.Length + 1);
            Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, rows));

            CreatePanel();
            Panel.Controls.Add(new Label()
            {
                Text = "Question ID",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 0, 0);
            Panel.Controls.Add(new Label()
            {
                Text = "Department",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 1, 0);
            Panel.Controls.Add(new Label()
            {
                Text = "Ticket ID",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 2, 0);
            Panel.Controls.Add(new Label()
            {
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 3, 0);

            int index = 0;
            foreach (SecondaryQuestion q in questions)
            {

                Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, rows));
                Label labelTmp = new Label()
                {
                    Text = q.ID.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    Hide();
                    new QuestionPage(q.ID).ShowDialog();
                    Show();
                };

                Panel.Controls.Add(labelTmp, 0, index + 1);

                labelTmp = new Label()
                {
                    Text = q.TicketID.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    Hide();
                    new QuestionPage(q.ID).ShowDialog();
                    Show();
                };

                Panel.Controls.Add(labelTmp, 1, index + 1);

                labelTmp = new Label()
                {
                    Text = ClientInstance.Proxy.GetDepartment(q.Department),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    Hide();
                    new QuestionPage(q.ID).ShowDialog();
                    Show();
                };

                Panel.Controls.Add(labelTmp, 2, index + 1);

                labelTmp = new Label()
                {
                    Text = q.Date.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    Hide();
                    new QuestionPage(q.ID).ShowDialog();
                    Show();
                };

                Panel.Controls.Add(labelTmp, 3, index + 1);

                index++;
            }
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
            Panel.Location = new Point(120, 221);
            Panel.Name = "tableLayoutPanel1";
            Panel.Size = new Size(100, 40);
            Panel.AutoSize = true;

            Controls.Add(Panel);
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Hide();
            ClientInstance.SolverProxy.Unsubscribe();
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID);
            new MainPage().ShowDialog();
            Show();
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
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

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
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

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new PersonalPage().ShowDialog();
            Show();
        }

        private void Questions_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
