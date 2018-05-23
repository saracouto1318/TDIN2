using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTService;

namespace SolverGUI
{
    public delegate void ChangeButtonDelegate(bool visible);

    public partial class TicketPage : MaterialForm
    {
        public Client ClientInstance;
        public Ticket TTicket;

        public TicketPage(Ticket ticket)
        {
            ClientInstance = Client.Instance;
            InitializeComponent();
            
            TTicket = ticket;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            LoadTicketInfo();

            this.VisibleChanged += OnVisibleChange;
        }

        public void LoadTicketInfo()
        {
            this.assignBtn.Visible = false;
            this.solveBtn.Visible = false;
            this.redirectBtn.Visible = false;

            ticketLabel.Text = "Ticket #" + this.TTicket.ID.ToString();
            title.Text = this.TTicket.Title;
            date.Text = this.TTicket.Date.ToString();
            description.Text = this.TTicket.Description;
            status.Text = this.TTicket.Status.ToString();

            if (TTicket.Status == TicketStatus.CLOSED || TTicket.Status == TicketStatus.WAITING)
            {
                this.assignBtn.Visible = false;
                this.solveBtn.Visible = false;
                this.redirectBtn.Visible = false;
            }
            else if (TTicket.Status == TicketStatus.ASSIGNED)
            {
                this.assignBtn.Visible = false;
                this.solveBtn.Visible = true;
                this.redirectBtn.Visible = true;
            }
            else if (TTicket.Status == TicketStatus.UNASSIGNED)
            {
                this.assignBtn.Visible = true;
                this.solveBtn.Visible = false;
                this.redirectBtn.Visible = false;
            }
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            FormController.ChangeForm(this, new PersonalPage());
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            ClientInstance.UnitializeSolverSession();
            ClientInstance.Proxy.Logout(ClientInstance.Solver.ID);

            FormController.ChangeForm(this, new MainPage());
        }

        private void SolveBtn_Click(object sender, EventArgs e)
        {
            FormController.ChangeForm(this, new SolvePage(TTicket));
        }

        private void RedirectBtn_Click(object sender, EventArgs e)
        {
            redirectBtn.Visible = false;

            FormController.ChangeForm(this, new RedirectPage(TTicket));
        }

        private void AssignBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if(ClientInstance.SolverProxy.AssignTicket(TTicket.ID, ClientInstance.Solver.ID))
                {
                    MethodInvoker UpdateGUI = (delegate
                    {
                        assignBtn.Visible = false;
                    });
                    assignBtn.Invoke(UpdateGUI);
                    UpdateGUI = (delegate
                    {
                        solveBtn.Visible = true;
                    });
                    solveBtn.Invoke(UpdateGUI);
                    UpdateGUI = (delegate
                    {
                        redirectBtn.Visible = true;
                    });
                    redirectBtn.Invoke(UpdateGUI);
                    UpdateGUI = (delegate
                    {
                        status.Text = this.TTicket.Status.ToString();
                    });
                    status.Invoke(UpdateGUI);
                }
            });
        }

        private void TicketPage_Load(object sender, EventArgs e)
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
            ClientInstance.TroubleTickets.OnOtherAssignedTroubleTicket += OnAssignedOthTT;
        }

        private void UnsubscribeEvents()
        {
            ClientInstance.TroubleTickets.OnOtherAssignedTroubleTicket -= OnAssignedOthTT;
        }

        private void OnAssignedOthTT(Ticket ticket)
        {
            if(ticket.ID == TTicket.ID)
            {
                Task.Run(() =>
                {
                    MethodInvoker ButtonInvoker = (delegate
                    {
                        assignBtn.Visible = false;
                    });
                    assignBtn.Invoke(ButtonInvoker);
                    ButtonInvoker = (delegate
                    {
                        solveBtn.Visible = false;
                    });
                    solveBtn.Invoke(ButtonInvoker);
                    ButtonInvoker = (delegate
                    {
                        redirectBtn.Visible = false;
                    });
                    redirectBtn.Invoke(ButtonInvoker);
                });
            }
        }
    }
}
