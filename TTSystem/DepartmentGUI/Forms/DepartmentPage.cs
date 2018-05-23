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
using TTService.Models;

namespace DepartmentGUI
{
    public partial class DepartmentPage : MaterialForm
    {
        public TTServClient proxy;
        public string name;
        public int departmentID;

        private MessageQueueReceiver mqr;
        private TableLayoutPanel panel = new TableLayoutPanel();
        
        public DepartmentPage(string name)
        {
            this.name = name;

            proxy = new TTServClient();
            mqr = MessageQueueReceiver.InitializeInstance(name);

            InitializeComponent();

            departmentName.Text = "Department " + this.name;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            CheckQuestions();

            this.VisibleChanged += OnVisibleChange;
        }
        
        private void CheckQuestions()
        {
            departmentID = proxy.GetDepartmentID(name);
            SecondaryQuestion[] questions = proxy.GetQuestions(departmentID);
            if (questions.Length != 0)
                CreateTable(questions);
            else
            {
                label1.Visible = true;
            }
        }

        private void CreateTable(SecondaryQuestion[] questions)
        {
            label1.Visible = false;
            panel.Visible = true;

            float value = 100 / (questions.Length + 1);
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));

            CreatePanel();
            panel.Controls.Add(new Label()
            {
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 0, 0);
            panel.Controls.Add(new Label()
            {
                Text = "Ticket ID",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 1, 0);

            int index = 0;
            foreach (SecondaryQuestion question in questions)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));

                Label labelTmp = new Label()
                {
                    Text = question.Date.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Gray,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };
                panel.Controls.Add(labelTmp, 0, index + 1);
                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    FormController.ChangeForm(this, new TicketQuestion(question.ID, this.name));
                };

                labelTmp = new Label()
                {
                    Text = question.TicketID.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Gray,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };
                panel.Controls.Add(labelTmp, 1, index + 1);
                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    FormController.ChangeForm(this, new TicketQuestion(question.ID, this.name));
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
                ColumnCount = 2
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, (0));
            panel.Location = new Point(300, 228);
            panel.Name = "tableLayoutPanel1";
            panel.Size = new Size(100, 40);
            panel.AutoSize = true;

            Controls.Add(panel);
        }

        private void DepartmentPage_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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
            mqr.OnNewSecondaryQuestion += OnNewSecondaryQuestion;
        }

        private void UnsubscribeEvents()
        {
            mqr.OnNewSecondaryQuestion -= OnNewSecondaryQuestion;
        }

        private void OnNewSecondaryQuestion(SerializedSecondaryQuestion secondaryQuestion)
        {
            Task.Run(async () =>
            {
                await Task.Delay(500);
                bool tryAgain = true;
                SecondaryQuestion[] questions = null;
                while (tryAgain)
                {
                    tryAgain = false;
                    try
                    {
                        questions = proxy.GetQuestions(departmentID);
                    }
                    catch
                    {
                        tryAgain = true;
                    }

                    if(!tryAgain)
                    {
                        MethodInvoker PanelInvoker = (delegate
                        {
                            CreateTable(questions);
                            label1.Visible = false;
                        });
                        this.Invoke(PanelInvoker);
                    }
                    else
                        await Task.Delay(1000);
                }
            });
        }
    }
}
