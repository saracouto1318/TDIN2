using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DepartmentGUI.TTSvc;

namespace DepartmentGUI
{
    public partial class CheckDepartment : MaterialForm
    {
        public TTServClient proxy;
        public CheckDepartment()
        {
            proxy = new TTServClient();

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string department = departmentName.Text;
           
            if (!proxy.CheckDepartment(department))
                proxy.AddDepartment(department);

            Hide();
            new DepartmentPage(department).ShowDialog();
            Show();
        }
    }
}
