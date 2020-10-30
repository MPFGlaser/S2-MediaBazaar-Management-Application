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
        private int function;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            dbhandler = new DatabaseHandler();
            List<string> loginData = dbhandler.LoginUser(textBoxLoginUsername.Text, textBoxLoginPassword.Text);
            if(loginData.Any())
            {
                this.userName = loginData[0];
                this.function = Convert.ToInt32(loginData[1]);
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

        public int Function
        {
            get { return function;  }
        }
    }
}
