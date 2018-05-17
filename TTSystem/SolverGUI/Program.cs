using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolverGUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPage());

            Application.ApplicationExit += new EventHandler(OnAppClose);
        }

        private static void OnAppClose(object sender, EventArgs e)
        {
            if(Client.Instance.SolverProxy != null)
            {
                Client.Instance.SolverProxy.Unsubscribe();
            }
        }
    }
}
