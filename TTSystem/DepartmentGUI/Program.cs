using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartmentGUI
{
    static class Program
    {
        public static FormsManager Forms { get; private set; }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Forms = new FormsManager();
            Application.Run(Forms.CheckDepartment);
        }
    }
}
