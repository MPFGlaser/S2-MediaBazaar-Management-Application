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
        private string userName;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            dbhandler = new DatabaseHandler();
            string loggedInUser = dbhandler.LoginUser(textBoxLoginUsername.Text, textBoxLoginPassword.Text);
            if (loggedInUser != string.Empty)
            {
                this.userName = loggedInUser;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }

        public string UserName
        {
            get { return userName; }
        }
    }
}
