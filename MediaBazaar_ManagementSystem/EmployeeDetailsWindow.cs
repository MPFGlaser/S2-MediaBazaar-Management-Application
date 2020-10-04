using MediaBazaar_ManagementSystem.classes;
using System;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class EmployeeDetailsWindow : Form
    {
        private Employee employee;

        public EmployeeDetailsWindow()
        {
            InitializeComponent();
        }

        public Employee Employee
        {
            get { return this.employee; }
        }

        private void CreateEmployee()
        {
            // Desperately needs validation...
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string email = textBoxEmail.Text;
            int phonenumber = Convert.ToInt32(textBoxPhoneNumber.Text);
            string address = textBoxAddress.Text;
            DateTime dateOfBirth = dateTimePickerDateOfBirth.Value;
            int bsn = Convert.ToInt32(textBoxBsn.Text);
            string spouseName = textBoxSpouseName.Text;
            int spousePhone = Convert.ToInt32(textBoxSpousePhone.Text);
            employee = new Employee(0, true, firstName, lastName, username, password, email, phonenumber, address, dateOfBirth, bsn, spouseName, spousePhone);
        }

        private void buttonEDWConfirm_Click(object sender, System.EventArgs e)
        {
            CreateEmployee();
            this.DialogResult = DialogResult.OK;
        }

        private void buttonEDWCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
