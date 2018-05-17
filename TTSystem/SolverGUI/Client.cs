using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TTService;
using GUI.TTSvc;
using GUI.TTSolver;

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

        private Client()
        {
            SolverProxy = new TTSolverSvcClient(new InstanceContext(this));
            SolverProxy.Subscribe();
            Proxy = new TTServClient();
        }
        
        public void NewTT(int idTicket)
        {
            // TODO: Add tt to list
            Console.WriteLine("Hello");
        }

        public void AssignedTT(int idTicket, int idSolver)
        {
            // TODO: Remove tt from list
            Console.WriteLine("Hello");
        }
    }
}
