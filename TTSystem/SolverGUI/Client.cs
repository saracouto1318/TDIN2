using GUI.TTSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SolverGUI
{
    public class Client : ITTServCallback
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

        public TTServClient Proxy { get; }

        private Client()
        {
            Proxy = new TTServClient(new InstanceContext(this));
        }

        public void AssignedTT(Ticket ticket)
        {
            // TODO: Remove tt from list
        }

        public void NewTT(Ticket ticket)
        {
            // TODO: Add tt to list
        }
    }
}
