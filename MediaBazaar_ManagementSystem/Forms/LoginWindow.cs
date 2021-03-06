﻿using System;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class LoginWindow : Form
    {
        ILoginStorage loginStorage;
        IEmployeeStorage employeeStorage;
        IFunctionStorage functionStorage;
        private int userId = -1;
        private Employee loggedInUser;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login()
        {
            loginStorage = new LoginMySQL();
            employeeStorage = new EmployeeMySQL();
            functionStorage = new FunctionMySQL();

            //Asks the loginStorage to check if the entered details match those we have stored.
            userId = loginStorage.Check(textBoxLoginUsername.Text, textBoxLoginPassword.Text);

            if(userId > 0)
            {
                this.loggedInUser = employeeStorage.Get(userId);
                this.loggedInUser.Permissions = functionStorage.GetPermissions(loggedInUser.Function);
                this.DialogResult = DialogResult.OK;
            }
            else if(userId < 0)
            {
                MessageBox.Show("Invalid Credentials");
            }
            else
            {
                MessageBox.Show("Your account has been disabled");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        public Employee LoggedInUser
        {
            get { return loggedInUser; }
        }
    }
}
