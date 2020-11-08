using MediaBazaar_ManagementSystem.classes;
using MediaBazaar_ManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class LoginWindow : Form
    {
        DatabaseHandler dbhandler;
        private Employee loggedInUser;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            dbhandler = new DatabaseHandler();
            //List<string> loginData = dbhandler.LoginUser(textBoxLoginUsername.Text, textBoxLoginPassword.Text);
            this.loggedInUser = dbhandler.LoginUser(textBoxLoginUsername.Text, textBoxLoginPassword.Text);
            if (loggedInUser != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }

        public Employee LoggedInUser
        {
            get { return loggedInUser; }
        }
    }
}
