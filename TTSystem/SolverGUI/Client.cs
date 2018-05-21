using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TTService;
using GUI.TTSvc;
using GUI.TTSolver;
using System.Windows.Forms;

namespace SolverGUI
{
    public delegate void NewTTicket(int idTicket);

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

        public NewTTicket onNewTT;

        public TTSolverSvcClient SolverProxy { get; }

        public TTServClient Proxy { get; }

        private Client()
        {
            SolverProxy = new TTSolverSvcClient(new InstanceContext(this));
            SolverProxy.Subscribe();
            Proxy = new TTServClient();
        }
        
        public void NewTT(int idTicket)
        {
            if (onNewTT != null)
                onNewTT(idTicket);
            else
                ShowMessageBox();
        }

        private void ShowMessageBox()
        {
            Task.Run(() =>
            {
                String message = "New trouble ticket arrived";
                String caption = "New trouble ticket";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
            });
        }

        public void AssignedTT(int idTicket, int idSolver)
        {
            // TODO: Remove tt from list
        }
    }
}
