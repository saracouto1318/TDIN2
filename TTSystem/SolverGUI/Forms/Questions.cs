using GUI.TTSvc;
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
using SolverGUI;

namespace GUI.Forms
{
    public partial class Questions : MaterialForm
    {
        public Client client;
        public int idUser;
        public User user;
        private TableLayoutPanel panel = new TableLayoutPanel();
        public Questions(int idUser)
        {
            client = Client.Instance;

            InitializeComponent();

            this.user = new User();
            this.idUser = idUser;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            GetUserInfo();
        }

        public void GetUserInfo()
        {
            this.user = client.Proxy.GetUser(idUser);
        }

        private bool CheckExist(bool value)
        {
            return client.Proxy.MyQuestions(this.user.ID, value).Length > 0;
        }

        private void CreateTable(bool value)
        {
            SecondaryQuestion[] questions;

            questions = client.Proxy.MyQuestions(this.user.ID, value);


            panel.Visible = true;
            float rows = 100 / (questions.Length + 1);
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, rows));

            CreatePanel();
            panel.Controls.Add(new Label()
            {
                Text = "Question ID",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 0, 0);
            panel.Controls.Add(new Label()
            {
                Text = "Question",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 1, 0);
            panel.Controls.Add(new Label()
            {
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 1, 0);
            panel.Controls.Add(new Label()
            {
                Text = "Status",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 2, 0);

            int index = 0;
            foreach (SecondaryQuestion q in questions)
            {

                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, rows));
                Label labelTmp = new Label()
                {
                    Text = q.ID.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    Hide();
                    new QuestionPage(user.ID, q.ID).ShowDialog();
                    Show();
                };

                panel.Controls.Add(labelTmp, 0, index + 1);

                labelTmp = new Label()
                {
                    Text = q.Question,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    Hide();
                    new QuestionPage(user.ID, q.ID).ShowDialog();
                    Show();
                };

                panel.Controls.Add(labelTmp, 1, index + 1);

                labelTmp = new Label()
                {
                    Text = q.Date.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    Hide();
                    new QuestionPage(user.ID, q.ID).ShowDialog();
                    Show();
                };

                panel.Controls.Add(labelTmp, 2, index + 1);

                labelTmp = new Label()
                {
                    Text = (q.Response == null) ? "Open" : "Closed",
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = (q.Response == null) ? Color.DarkGray : Color.DarkBlue,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    Hide();
                    new QuestionPage(user.ID, q.ID).ShowDialog();
                    Show();
                };

                index++;
            }
        }

        private void CreatePanel()
        {
            panel.Dispose();
            panel = new TableLayoutPanel
            {
                BackColor = SystemColors.ButtonHighlight,
                BackgroundImageLayout = ImageLayout.Center,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                ColumnCount = 4
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 25F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 25F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 25F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 25F));
            panel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, (0));
            panel.Location = new Point(150, 221);
            panel.Name = "tableLayoutPanel1";
            panel.Size = new Size(100, 40);
            panel.AutoSize = true;

            Controls.Add(panel);
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            client.Proxy.Logout(user.ID);
            Hide();
            new MainPage().ShowDialog();
            Show();
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            if (!CheckExist(false))
            {
                label1.Visible = true;
                panel.Visible = false;
            }
            else
            {
                label1.Visible = false;
                panel.Visible = true;
                CreateTable(false);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            if (!CheckExist(true))
            {
                label2.Visible = true;
                panel.Visible = false;
            }
            else
            {
                label2.Visible = false;
                panel.Visible = true;
                CreateTable(true);
            }
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new PersonalPage(user.ID).ShowDialog();
            Show();
        }
    }
}
