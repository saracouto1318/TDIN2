using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DepartmentGUI
{
    public class FormController
    {
        private static FormController instance = new FormController();

        public static void ChangeForm(MaterialForm fromForm, MaterialForm toForm)
        {
            fromForm.FormClosed -= instance.OnFormClosed;
            toForm.FormClosed += instance.OnFormClosed;

            fromForm.Hide();
            toForm.Show();
            if(!(fromForm is CheckDepartment))
            {
                fromForm.Close();
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}