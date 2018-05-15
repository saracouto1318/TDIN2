using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GUI.TTSvcClient;
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

        public TTSolverSvcClient SolverProxy { get; }

        public TTServClient Proxy { get; }

        private Client()
        {
            SolverProxy = new TTSolverSvcClient(/*new InstanceContext(this)*/);
            String str = SolverProxy.Hello();
            Proxy = new TTServClient();
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
