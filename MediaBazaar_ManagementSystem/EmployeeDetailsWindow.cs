using MediaBazaar_ManagementSystem.classes;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace MediaBazaar_ManagementSystem
{
    public partial class EmployeeDetailsWindow : Form
    {
        private Employee employee;
        private Boolean editing = false;
        private int editId;
        private string function = "1337";

        public EmployeeDetailsWindow()
        {
            InitializeComponent();
        }

        public Employee Employee
        {
            get { return this.employee; }
        }

        private void CreateEmployee(bool active, string firstName, string surName, string userName, string password, string email, string phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, string spousePhone)
        {
            
            employee = new Employee(0, active, firstName, surName, userName, password, email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone);
        }

        private void UpdateEmployee(int id, bool active, string firstName, string surName, string userName, string email, string phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, string spousePhone)
        {
            employee = new Employee(id, active, firstName, surName, userName, "", email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone);
        }

        private void buttonEDWConfirm_Click(object sender, System.EventArgs e)
        {
            ResetBoxColors();

            Regex checkName = new Regex(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");
            Regex checkEmail = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            Regex checkPhoneNumber = new Regex(@"^((?=.{10}$)(\d{10}))|((?=.{12}$)([+316]{4}\d{8}))");
            Regex checkUserName = new Regex(@"^(?=.{1,64}$)[a-zA-Z0-9._]+$");
            Regex checkPassword = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Regex checkAddress = new Regex(@"^[A-Za-z]+(?:\s[A-Za-z0-9'_-]+)+$");
            Regex checkBSN = new Regex(@"^[0-9]*\d{9}$");

            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string passwordConfirm = textBoxPasswordConfirm.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;
            DateTime dateOfBirth = dateTimePickerDateOfBirth.Value;
            string spouseName = textBoxSpouseName.Text;
            string phonenumber = textBoxPhoneNumber.Text;
            string spousePhone = textBoxSpousePhone.Text;
            Boolean active = checkBoxActive.Checked;

            function = textBoxFunctions.Text;

            if (!checkName.IsMatch(firstName))
            {

                textBoxFirstName.BackColor = Color.LightCoral;
            }
            else if (!checkName.IsMatch(lastName))
            {
                textBoxLastName.BackColor = Color.LightCoral;
            }
            else if (!checkUserName.IsMatch(username))
            {
                textBoxUsername.BackColor = Color.LightCoral;
            }
            else if (!checkPassword.IsMatch(password) && !editing)
            {
                textBoxPassword.BackColor = Color.LightCoral;
            }
            else if (password != passwordConfirm)
            {
                textBoxPassword.BackColor = Color.LightCoral;
                textBoxPasswordConfirm.BackColor = Color.LightCoral;
            }
            else if (!checkPhoneNumber.IsMatch(textBoxPhoneNumber.Text))
            {
                textBoxPhoneNumber.BackColor = Color.LightCoral;
            }
            else if (!checkAddress.IsMatch(address))
            {
                textBoxAddress.BackColor = Color.LightCoral;
            }
            else if (!checkEmail.IsMatch(email))
            {
                textBoxEmail.BackColor = Color.LightCoral;
            }
            else if (!checkBSN.IsMatch(textBoxBsn.Text))
            {
                textBoxBsn.BackColor = Color.LightCoral;
            }
            else if (!checkName.IsMatch(spouseName))
            {
                textBoxSpouseName.BackColor = Color.LightCoral;
            }
            else if (!checkPhoneNumber.IsMatch(textBoxSpousePhone.Text))
            {
                textBoxSpousePhone.BackColor = Color.LightCoral;
            }
            else
            {
                int bsn = Convert.ToInt32(textBoxBsn.Text);
                if (editing)
                {
                    UpdateEmployee(editId, active, firstName, lastName, username, email, phonenumber, address, dateOfBirth, bsn, spouseName, spousePhone);
                }
                else
                {
                    CreateEmployee(active, firstName, lastName, username, password, email, phonenumber, address, dateOfBirth, bsn, spouseName, spousePhone);
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        public void AddEmployeeData(Employee employee)
        {
            this.Text = "Viewing/editing " + employee.FirstName + "'s details";
            employeeSpecificsGroup.Visible = true;
            editing = true;
            editId = employee.Id;

            textBoxPassword.Enabled = false;
            textBoxPasswordConfirm.Enabled = false;
            labelPassword.Enabled = false;
            labelPasswordc.Enabled = false;

            textBoxFirstName.Text = employee.FirstName;
            textBoxLastName.Text = employee.SurName;
            textBoxUsername.Text = employee.UserName;
            textBoxPassword.Text = "";
            textBoxPasswordConfirm.Text = "";
            textBoxEmail.Text = employee.Email;
            textBoxAddress.Text = employee.Address;
            dateTimePickerDateOfBirth.Value = employee.DateOfBirth;
            textBoxSpouseName.Text = employee.SpouseName;
            textBoxPhoneNumber.Text = employee.PhoneNumber;
            textBoxSpousePhone.Text = employee.SpousePhone;
            textBoxBsn.Text = employee.Bsn.ToString();
            checkBoxActive.Checked = employee.Active;
            textBoxFunctions.Text = function.ToString();
        }

        private void ResetBoxColors()
        {
            textBoxFirstName.BackColor = Color.FromName("Window");
            textBoxLastName.BackColor = Color.FromName("Window");
            textBoxUsername.BackColor = Color.FromName("Window");
            textBoxPassword.BackColor = Color.FromName("Window");
            textBoxPassword.BackColor = Color.FromName("Window");
            textBoxPasswordConfirm.BackColor = Color.FromName("Window");
            textBoxEmail.BackColor = Color.FromName("Window");
            textBoxPhoneNumber.BackColor = Color.FromName("Window");
            textBoxAddress.BackColor = Color.FromName("Window");
            textBoxBsn.BackColor = Color.FromName("Window");
            textBoxSpouseName.BackColor = Color.FromName("Window");
            textBoxSpousePhone.BackColor = Color.FromName("Window");
        }

        private void buttonEDWCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
