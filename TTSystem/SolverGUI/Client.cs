using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TTService;
using GUI.TTSvc;
using GUI.TTSolverSvc;
using System.Windows.Forms;

namespace SolverGUI
{
    public class Client : ITTSolverSvcCallback
    {
        private static Client instance;
        
        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Client();
                }
                return instance;
            }
        }
        
        public TTSolverSvcClient SolverProxy { get; }

        public TTServClient Proxy { get; }

        public User Solver { get; set; }

        public TTList TroubleTickets { get; }


        private Client()
        {
            SolverProxy = new TTSolverSvcClient(new InstanceContext(this));
            Proxy = new TTServClient();
            TroubleTickets = new TTList();
        }

        private void UnitializeSolverSession()
        {
            SolverProxy.Unsubscribe();
        }

        private void InitializeSolverSession()
        {
            TroubleTickets.UpdateTT(SolverProxy, Solver);
            SolverProxy.Subscribe();
        }

        public bool LoginUser(
            string email, 
            string password)
        {
            if (SolverProxy.LoginSolver(email, password))
            {
                Solver = Proxy.GetUserByEmail(email);
                InitializeSolverSession();
                return true;
            }

            return false;
        }

        public bool RegisterSolver(
            string email, 
            string name,
            string password)
        {
            if (SolverProxy.RegisterSolver(name, email, password))
            {
                SolverProxy.LoginSolver(email, password);
                User user = Proxy.GetUserByEmail(email);
                InitializeSolverSession();
                return true;
            }

            return false;
        }

        private void ShowMessageBox(string message, string caption)
        {
            Task.Run(() =>
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
            });
        }
        
        public void NewTT(Ticket ticket)
        {
            TroubleTickets.OnNewTroubleTicket?.Invoke(ticket);
            ShowMessageBox("New trouble ticket arrived", "New trouble ticket");
        }

        public void AssignedTT(Ticket ticket)
        {
            if (ticket.IDSolver == Solver.ID)
            {
                TroubleTickets.OnMyAssignedTroubleTicket?.Invoke(ticket);
            }
            else
            {
                TroubleTickets.OnOtherAssignedTroubleTicket?.Invoke(ticket);
                ShowMessageBox("The trouble ticket " + ticket.Title + " has been assigned.", "Assigned trouble ticket");
            }
        }
    }
}
