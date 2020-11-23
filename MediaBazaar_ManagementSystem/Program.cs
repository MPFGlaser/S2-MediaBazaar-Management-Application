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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EmployeeMySQL esqlhandler = new EmployeeMySQL();
            esqlhandler.CheckFunctions();
            createLogin();
        }

        public static void createLogin()
        {
            bool loggedin = false;
            LoginWindow login;

            if (!loggedin)
            {
                login = new LoginWindow();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainWindow(login.LoggedInUser));
                }
                else
                {
                    login.Close();
                }
            }
        }
    }
}
