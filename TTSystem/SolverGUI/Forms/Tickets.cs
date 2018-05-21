using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SolverGUI;
using TTService;

namespace GUI.Forms
{
    public partial class Tickets : MaterialForm
    {
        public Client ClientInstance;
        private TableLayoutPanel Panel = new TableLayoutPanel();

        public Tickets(int idUser)
        {
            ClientInstance = Client.Instance;
            ClientInstance.TroubleTickets.OnNewTroubleTicket += OnNewTT;

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

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            if (!CheckExist(TicketStatus.UNASSIGNED))
            {
                label1.Visible = true;
                Panel.Visible = false;
            }
            else
            {
                label1.Visible = false;
                CreateTable(TicketStatus.UNASSIGNED);
                Panel.Visible = true;
            }
        }

        private void MyTicketsBtn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            if (!CheckExist(TicketStatus.ASSIGNED))
            {
                label2.Visible = true;
                Panel.Visible = false;
            }
            else
            {
                label2.Visible = false;
                CreateTable(TicketStatus.ASSIGNED);
                Panel.Visible = true;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;

            if (!CheckExist(TicketStatus.CLOSED))
            {
                label3.Visible = true;
                Panel.Visible = false;
            }
            else
            {
                label3.Visible = false;
                CreateTable(TicketStatus.CLOSED);
                Panel.Visible = true;
            }
        }

        private bool CheckExist(TicketStatus status)
        {
            if (status == TicketStatus.UNASSIGNED)
            {
                if (ClientInstance.SolverProxy.GetUnassignedTT().Length > 0)
                    return true;
            }
            else
                if (ClientInstance.SolverProxy.GetSolverTTByType(ClientInstance.Solver, status).Length > 0)
                    return true;
            return false;
        }

        private void OnNewTT(Ticket ticket)
        {
            Task t = new Task(() => {
                MethodInvoker methodInvokerDelegate = delegate ()
                {
                    CreateTable(TicketStatus.UNASSIGNED);
                };

                this.Invoke(methodInvokerDelegate);
            });

            SendWithDelay(5000, t);
        }

        private async Task SendWithDelay(int delay, Task task)
        {
            await Task.Delay(delay);
            task.Start();
        }

        private void CreateTable(TicketStatus status)
        {
            Ticket[] tickets;

            if (status == TicketStatus.UNASSIGNED)
                tickets = ClientInstance.SolverProxy.GetUnassignedTT();
            else
                tickets = ClientInstance.SolverProxy.GetSolverTTByType(ClientInstance.Solver, status);


            Panel.Visible = true;
            float value = 100 / (tickets.Length + 1);
            Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));

            CreatePanel();
            Panel.Controls.Add(new Label()
            {
                Text = "Ticket ID",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 0, 0);
            Panel.Controls.Add(new Label()
            {
                Text = "Title",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 1, 0);
            Panel.Controls.Add(new Label()
            {
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 2, 0);

            int index = 0;
            foreach (Ticket t in tickets)
            {

                Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));
                Label labelTmp = new Label()
                {
                    Text = t.ID.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    OnHide();
                    Hide();
                    new TicketPage(t.ID).ShowDialog();
                    Show();
                };

                Panel.Controls.Add(labelTmp, 0, index + 1);

                labelTmp = new Label()
                {
                    Text = t.Title,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    OnHide();
                    Hide();
                    new TicketPage(t.ID).ShowDialog();
                    Show();
                };

                Panel.Controls.Add(labelTmp, 1, index + 1);

                labelTmp = new Label()
                {
                    Text = t.Date.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                labelTmp.Click += (object sender, EventArgs e) =>
                {
                    OnHide();
                    Hide();
                    new TicketPage(t.ID).ShowDialog();
                    Show();
                };

                Panel.Controls.Add(labelTmp, 2, index + 1);

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
                ColumnCount = 3
            };

            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 33F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 33F));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 33F));
            Panel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, (0));
            Panel.Location = new Point(130, 221);
            Panel.Name = "tableLayoutPanel1";
            Panel.Size = new Size(100, 40);
            Panel.AutoSize = true;

            Controls.Add(Panel);
        }

        private void OnHide()
        {
            ClientInstance.TroubleTickets.OnNewTroubleTicket -= OnNewTT;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            ClientInstance.SolverProxy.Unsubscribe();
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID);
            OnHide();
            Hide();
            new MainPage().ShowDialog();
            Show();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            OnHide();
            Hide();
            new PersonalPage().ShowDialog();
            Show();
        }

        private void QuestionsOpen_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            if (!CheckExist(TicketStatus.WAITING))
            {
                label4.Visible = true;
                Panel.Visible = false;
            }
            else
            {
                label4.Visible = false;
                CreateTable(TicketStatus.WAITING);
                Panel.Visible = true;
            }
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
