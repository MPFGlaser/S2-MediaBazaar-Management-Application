using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool loggedin = false;
            LoginWindow login;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!loggedin)
            {
                login = new LoginWindow();
                if (login.ShowDialog() == DialogResult.OK)
                {

                    Application.Run(new MainWindow(true, login.Name));
                }
                else
                {
                    login.Close();
                }
            }
        }
    }
}
