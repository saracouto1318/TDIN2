using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GUI.TTSolverSvcClient;
using TTService;

namespace SolverGUI
{
    public class Client
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

        public TTSolverSvcClient Proxy { get; }

        private Client()
        {
            Proxy = new TTSolverSvcClient(/*new InstanceContext(this)*/);
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
