using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_exam_sem1_Comments
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.FormClosed += CloseProgram;
            passwordForm.Show();
            Application.Run();
        }
        private static void CloseProgram(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= CloseProgram;

            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += CloseProgram;
            }
        }
    }
}
