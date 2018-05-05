using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SolverGUI
{
    public partial class PersonalPage : MaterialForm
    {
        private TableLayoutPanel panel = new TableLayoutPanel();
        public PersonalPage()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl;
        }

        private void myTicketsBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private bool CheckExist(string type)
        {
            /**
             * Verifica se existem tickets daquele tipo*/
            return false;
        }

        private void CreateTable(string type)
        {
            panel.Visible = true;
            
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 5));

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
            }, 1, 0);
            panel.Controls.Add(new Label()
            {
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            }, 2, 0);

            /*
            int index = 0;
            foreach (Transaction t in transactions)
            {
                int quantity = t.quantity;
                string buyer = t.buyer;
                string seller = t.seller;
                DateTime date = t.date;
                float quotation = t.quotation;

                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, value));

                Label labelTmp = new Label()
                {
                    Text = quantity.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = (buyer == null || seller == null) ? Color.DarkGray : Color.DarkBlue,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (buyer == null || seller == null)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Program.context.ChangeForm(this, new EditOrder(t.ID, quantity, GetTransactionType(t)));
                    };

                panel.Controls.Add(labelTmp, 0, index + 1);

                labelTmp = new Label()
                {
                    Text = (quotation == -1f ? cQuote : quotation).ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = (buyer == null || seller == null) ? Color.DarkGray : Color.DarkBlue,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (buyer == null || seller == null)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Program.context.ChangeForm(this, new EditOrder(t.ID, quantity, GetTransactionType(t)));
                    };

                panel.Controls.Add(labelTmp, 1, index + 1);

                labelTmp = new Label()
                {
                    Text = ((quotation == -1f ? cQuote : quotation) * quantity).ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = (buyer == null || seller == null) ? Color.DarkGray : Color.DarkBlue,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (buyer == null || seller == null)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Program.context.ChangeForm(this, new EditOrder(t.ID, quantity, GetTransactionType(t)));
                    };

                panel.Controls.Add(labelTmp, 2, index + 1);

                labelTmp = new Label()
                {
                    Text = date.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = (buyer == null || seller == null) ? Color.DarkGray : Color.DarkBlue,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (buyer == null || seller == null)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Program.context.ChangeForm(this, new EditOrder(t.ID, quantity, GetTransactionType(t)));
                    };

                panel.Controls.Add(labelTmp, 3, index + 1);

                labelTmp = new Label()
                {
                    Text = (buyer == null || seller == null) ? "Open" : "Closed",
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = (buyer == null || seller == null) ? Color.DarkGray : Color.DarkBlue,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };

                if (buyer == null || seller == null)
                    labelTmp.Click += (object sender, EventArgs e) =>
                    {
                        Program.context.ChangeForm(this, new EditOrder(t.ID, quantity, GetTransactionType(t)));
                    };

                panel.Controls.Add(labelTmp, 4, index + 1);

                index++;
            }*/
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

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, (0));
            panel.Location = new Point(150, 221);
            panel.Name = "tableLayoutPanel1";
            panel.Size = new Size(100, 40);
            panel.AutoSize = true;

            Controls.Add(panel);
        }
    }
}
