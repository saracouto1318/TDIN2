using System;
using System.Collections.Generic;
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
        public TableLayoutPanel Panel = new TableLayoutPanel();
        private TicketStatus PanelStatus = TicketStatus.ASSIGNED;
        private IStatusPanel StatusPanelController;

        public Tickets()
        {
            ClientInstance = Client.Instance;

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            LoadUserInfo();

            StatusPanelController = StatusPanelFactory.GetStatusPanelController(PanelStatus);
            CreateTable(PanelStatus);

            this.VisibleChanged += OnVisibleChange;
        }

        #region Form        
        public void LoadUserInfo()
        {
            this.name.Text = ClientInstance.Solver.Name;
            this.email.Text = ClientInstance.Solver.Email;
        }

        private void OnVisibleChange(object sender, EventArgs e)
        {
            if(!Visible)
            {
                UnsubscribeEvents();
}
            else
            {
                SubscribeEvents();
}
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            UpdatePanelStatus(TicketStatus.UNASSIGNED);

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

            UpdatePanelStatus(TicketStatus.ASSIGNED);

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

            UpdatePanelStatus(TicketStatus.CLOSED);

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

        private void QuestionsOpen_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            UpdatePanelStatus(TicketStatus.WAITING);

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

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            ClientInstance.UnitializeSolverSession();
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID);
            Hide();
            new MainPage().ShowDialog();
            Show();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new PersonalPage().ShowDialog();
            Show();
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        #endregion

        #region Panel
        private void UpdatePanelStatus(TicketStatus status)
        {
            PanelStatus = status;
            StatusPanelController = StatusPanelFactory.GetStatusPanelController(PanelStatus);
        }

        public void TicketClickAction(Ticket t)
        {
            Hide();
            new TicketPage(t).ShowDialog();
            Show();
        }

        public void CreateTable(TicketStatus status)
        {
            List<Ticket> tickets = ClientInstance.TroubleTickets.GetTicketsByStatus(status);
            if (tickets.Count <= 0)
                return;
            LoadTable(tickets);
        }

        public void LoadTable(List<Ticket> tickets)
        {
            IPanelRow panelRow = new TitlePanelRowImpl();

            Panel.Visible = true;
            float value = 100 / (tickets.Count + 1);

            CreatePanel();
            Panel.SuspendLayout();

            panelRow.AddPanelRow(Panel, value, null, () => { });

            panelRow = new TicketPanelRowImpl();
            foreach (Ticket t in tickets)
            {
                panelRow.AddPanelRow(Panel, value, t, () => { TicketClickAction(t); });
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
        #endregion

        #region Events
        private void SubscribeEvents()
        {
            ClientInstance.TroubleTickets.OnNewTroubleTicket += OnNewTT;
            ClientInstance.TroubleTickets.OnMyAssignedTroubleTicket += OnAssignedMyTT;
            ClientInstance.TroubleTickets.OnOtherAssignedTroubleTicket += OnAssignedOthTT;
        }

        private void UnsubscribeEvents()
        {
            ClientInstance.TroubleTickets.OnNewTroubleTicket -= OnNewTT;
            ClientInstance.TroubleTickets.OnMyAssignedTroubleTicket -= OnAssignedMyTT;
            ClientInstance.TroubleTickets.OnOtherAssignedTroubleTicket -= OnAssignedOthTT;
        }

        private void OnNewTT(Ticket ticket)
        {
            if(StatusPanelController != null)
            {
                StatusPanelController.NewTT(this, ticket);
            }
        }

        private void OnAssignedMyTT(Ticket ticket)
        {
            if (StatusPanelController != null)
            {
                StatusPanelController.AssignedMyTT(this, ticket);
            }
        }

        private void OnAssignedOthTT(Ticket ticket)
        {
            if (StatusPanelController != null)
            {
                StatusPanelController.AssignedOthTT(this, ticket);
            }
        }
        #endregion

        #region Service
        private bool CheckExist(TicketStatus status)
        {
            return ClientInstance.TroubleTickets.GetTicketsByStatus(status).Count > 0;
        }
        #endregion
    }

    interface IPanelRow
    {
        void AddPanelRow(TableLayoutPanel panel, float value, object obj, Action action);
    }

    class TicketPanelRowImpl : IPanelRow
    {
        public void AddPanelRow(TableLayoutPanel panel, float value, object obj, Action action)
        {
            if (!(obj is Ticket))
                return;

            Ticket ticket = (Ticket)obj;
            int count = panel.Controls.Count;

            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));
            Label labelTmp = new Label()
            {
                Text = ticket.ID.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 0, count);

            labelTmp = new Label()
            {
                Text = ticket.Title,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 1, count);

            labelTmp = new Label()
            {
                Text = ticket.Date.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };

            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };

            panel.Controls.Add(labelTmp, 2, count);
        }
    }

    class TitlePanelRowImpl : IPanelRow
    {
        public void AddPanelRow(TableLayoutPanel panel, float value, object obj, Action action)
        {
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));
            Label labelTmp = new Label()
            {
                Text = "Ticket ID",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };
            panel.Controls.Add(labelTmp, 0, 0);

            labelTmp = new Label()
            {
                Text = "Title",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };
            panel.Controls.Add(labelTmp, 1, 0);

            labelTmp = new Label()
            {
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            labelTmp.Click += (object sender, EventArgs e) =>
            {
                action();
            };
            panel.Controls.Add(labelTmp, 2, 0);
        }
    }

    interface IStatusPanel
    {
        void AssignedMyTT(Tickets form, Ticket ticket);
        void AssignedOthTT(Tickets form, Ticket ticket);
        void NewTT(Tickets form, Ticket ticket);
    }

    class StatusPanelFactory
    {
        public static IStatusPanel GetStatusPanelController(TicketStatus status)
        {
            switch(status)
            {
                case TicketStatus.UNASSIGNED:
                    return new UnassignedStautsPanel();
                case TicketStatus.ASSIGNED:
                case TicketStatus.WAITING:
                case TicketStatus.CLOSED:
                    return new DoNothingStatusPanel();
            }
            return null;
        }
    }

    class UnassignedStautsPanel : IStatusPanel
    {
        // Reload current panel
        public void AssignedMyTT(Tickets form, Ticket ticket)
        {
            form.CreateTable(TicketStatus.UNASSIGNED);
        }

        // Reload current panel
        public void AssignedOthTT(Tickets form, Ticket ticket)
        {
            form.CreateTable(TicketStatus.UNASSIGNED);
        }
        
        // Add new ticket to current panel or load new panel
        public void NewTT(Tickets form, Ticket ticket)
        {
            if(form.Panel == null || form.Panel.RowCount == 0)
            {
                form.CreateTable(TicketStatus.UNASSIGNED);
            }
            else
            {
                IPanelRow panelRow = new TicketPanelRowImpl();
                float value = 100 / (form.ClientInstance.TroubleTickets.UnassignedTroubleTickets.Count + 1);
                panelRow.AddPanelRow(form.Panel, value, ticket, () => { form.TicketClickAction(ticket); });
            }
        }
    }

    class DoNothingStatusPanel : IStatusPanel
    {
        // Do nothing
        public void AssignedMyTT(Tickets form, Ticket ticket)
        { }

        // Do nothing
        public void AssignedOthTT(Tickets form, Ticket ticket)
        { }

        // Do nothing
        public void NewTT(Tickets form, Ticket ticket)
        { }
    }
}
