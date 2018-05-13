﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.TTSvc;
using MaterialSkin;
using MaterialSkin.Controls;
using SolverGUI;

namespace GUI.Forms
{
    public partial class Tickets : MaterialForm
    {
        public TTServClient proxy;
        public int idUser;
        public User user;
        private TableLayoutPanel panel = new TableLayoutPanel();
        public Tickets(int idUser)
        {
            InitializeComponent();

            proxy = new TTServClient();

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
            this.user = proxy.GetUser(idUser);
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;

            if (!CheckExist(TicketStatus.UNASSIGNED))
            {
                label1.Visible = true;
                panel.Visible = false;
            }
            else
            {
                label1.Visible = false;
                CreateTable(TicketStatus.UNASSIGNED);
                panel.Visible = true;
            }
        }

        private void MyTicketsBtn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label3.Visible = false;

            if (!CheckExist(TicketStatus.ASSIGNED))
            {
                label2.Visible = true;
                panel.Visible = false;
            }
            else
            {
                label2.Visible = false;
                CreateTable(TicketStatus.ASSIGNED);
                panel.Visible = true;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;

            if (!CheckExist(TicketStatus.CLOSED))
            {
                label3.Visible = true;
                panel.Visible = false;
            }
            else
            {
                label3.Visible = false;
                CreateTable(TicketStatus.CLOSED);
                panel.Visible = true;
            }
        }

        private bool CheckExist(TicketStatus status)
        {
            if (status == TicketStatus.UNASSIGNED)
            {
                if (proxy.GetUnassignedTT().Length > 0)
                    return true;
            }
            else
                if (proxy.GetSolverTTByType(this.user, status).Length > 0)
                    return true;
            return false;
        }

        private void CreateTable(TicketStatus status)
        {
            Ticket[] tickets;

            if (status == TicketStatus.UNASSIGNED)
                tickets = proxy.GetUnassignedTT();
            else
                tickets = proxy.GetSolverTTByType(this.user, status);


            panel.Visible = true;
            float value = 100 / (tickets.Length + 1);
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));

            CreatePanel();
            panel.Controls.Add(new Label()
            {
                Text = "Ticket ID",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 0, 0);
            panel.Controls.Add(new Label()
            {
                Text = "Title",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 1, 0);
            panel.Controls.Add(new Label()
            {
                Text = "Description",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 2, 0);
            panel.Controls.Add(new Label()
            {
                Text = "Status",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 3, 0);
            panel.Controls.Add(new Label()
            {
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 4, 0);

            int index = 0;
            foreach (Ticket t in tickets)
            {

                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));
                Label labelTmp = new Label()
                {
                    Text = t.ID.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (t.Status != TicketStatus.CLOSED)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Hide();
                        new TicketPage(user, t.ID).ShowDialog();
                        Show();
                    };

                panel.Controls.Add(labelTmp, 0, index + 1);

                labelTmp = new Label()
                {
                    Text = t.Title,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (t.Status != TicketStatus.CLOSED)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Hide();
                        new TicketPage(user, t.ID).ShowDialog();
                        Show();
                    };

                panel.Controls.Add(labelTmp, 1, index + 1);

                labelTmp = new Label()
                {
                    Text = t.Description,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (t.Status != TicketStatus.CLOSED)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Hide();
                        new TicketPage(user, t.ID).ShowDialog();
                        Show();
                    };

                panel.Controls.Add(labelTmp, 2, index + 1);

                labelTmp = new Label()
                {
                    Text = t.Status.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = (t.Status != TicketStatus.CLOSED) ? Color.DarkGray : Color.DarkBlue,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (t.Status != TicketStatus.CLOSED)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Hide();
                        new TicketPage(user, t.ID).ShowDialog();
                        Show();
                    };

                panel.Controls.Add(labelTmp, 3, index + 1);

                labelTmp = new Label()
                {
                    Text = t.Date.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (t.Status != TicketStatus.CLOSED)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Hide();
                        new TicketPage(user, t.ID).ShowDialog();
                        Show();
                    };

                panel.Controls.Add(labelTmp, 4, index + 1);

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
                ColumnCount = 5
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 10F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 30F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, (0));
            panel.Location = new Point(100, 221);
            panel.Name = "tableLayoutPanel1";
            panel.Size = new Size(100, 40);
            panel.AutoSize = true;

            Controls.Add(panel);
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            proxy.Logout(user.ID);
            Hide();
            new MainPage().ShowDialog();
            Show();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new PersonalPage(this.user.ID).ShowDialog();
            Show();
        }
    }
}