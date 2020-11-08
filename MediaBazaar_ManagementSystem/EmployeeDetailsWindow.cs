using MediaBazaar_ManagementSystem.classes;
using MediaBazaar_ManagementSystem.Classes;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace MediaBazaar_ManagementSystem
{
    public partial class EmployeeDetailsWindow : Form
    {
        DatabaseHandler dbhandler;
        private Employee employee;
        private Boolean editing = false;
        private int editId;
        string preferredHours = "000000000000000000000";
        PreferredHours ph;

        public EmployeeDetailsWindow()
        {
            InitializeComponent();
        }

        public Employee Employee
        {
            get { return this.employee; }
        }

        private bool CreateEmployee(bool active, string firstName, string surName, string userName, string password, string email, string phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, string spousePhone, string postalCode, string city, string preferredHours)
        {
            dbhandler = new Classes.DatabaseHandler();
            employee = new Employee(0, active, firstName, surName, userName, password, email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone, 1337, postalCode, city, preferredHours);
            return dbhandler.CreateEmployee(employee);
        }

        private bool UpdateEmployee(int id, bool active, string firstName, string surName, string userName, string email, string phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, string spousePhone, int function, string postalCode, string city, string preferredHours)
        {
            dbhandler = new Classes.DatabaseHandler();
            employee = new Employee(id, active, firstName, surName, userName, "", email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone, function, postalCode, city, preferredHours);
            return dbhandler.UpdateEmployee(employee);
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
            Regex checkNumbers = new Regex(@"^[0-9]+$");
            Regex checkPostalCode = new Regex(@"^[0-9]{4}[ ]?[a-zA-Z]{2}$");

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
            string postalCode = textBoxPostalCode.Text;
            string city = textBoxCity.Text;
            Boolean active = checkBoxActive.Checked;
            Boolean allCorrect = true;

            if (!checkName.IsMatch(firstName))
            {
                allCorrect = false;
                textBoxFirstName.BackColor = Color.LightCoral;
            }
            if (!checkName.IsMatch(lastName))
            {
                allCorrect = false;
                textBoxLastName.BackColor = Color.LightCoral;
            }
            if (!checkUserName.IsMatch(username))
            {
                allCorrect = false;
                textBoxUsername.BackColor = Color.LightCoral;
            }
            if (!checkPassword.IsMatch(password) && !editing)
            {
                allCorrect = false;
                textBoxPassword.BackColor = Color.LightCoral;
            }
            if ((password != passwordConfirm || passwordConfirm == "") && !editing)
            {
                allCorrect = false;
                textBoxPassword.BackColor = Color.LightCoral;
                textBoxPasswordConfirm.BackColor = Color.LightCoral;
            }
            if (!checkPhoneNumber.IsMatch(textBoxPhoneNumber.Text))
            {
                allCorrect = false;
                textBoxPhoneNumber.BackColor = Color.LightCoral;
            }
            if (!checkAddress.IsMatch(address))
            {
                allCorrect = false;
                textBoxAddress.BackColor = Color.LightCoral;
            }
            if (!checkEmail.IsMatch(email))
            {
                allCorrect = false;
                textBoxEmail.BackColor = Color.LightCoral;
            }
            if (!checkBSN.IsMatch(textBoxBsn.Text))
            {
                allCorrect = false;
                textBoxBsn.BackColor = Color.LightCoral;
            }
            if (!checkName.IsMatch(spouseName))
            {
                allCorrect = false;
                textBoxSpouseName.BackColor = Color.LightCoral;
            }
            if (!checkPhoneNumber.IsMatch(textBoxSpousePhone.Text))
            {
                allCorrect = false;
                textBoxSpousePhone.BackColor = Color.LightCoral;
            }
            if (!checkNumbers.IsMatch(textBoxFunctions.Text) && editing)
            {
                allCorrect = false;
                textBoxFunctions.BackColor = Color.LightCoral;
            }
            if (!checkName.IsMatch(textBoxCity.Text))
            {
                allCorrect = false;
                textBoxCity.BackColor = Color.LightCoral;
            }
            if (!checkPostalCode.IsMatch(textBoxPostalCode.Text))
            {
                allCorrect = false;
                textBoxPostalCode.BackColor = Color.LightCoral;
            }

            if (allCorrect)
            {
                bool succesfulExecution;
                int bsn = Convert.ToInt32(textBoxBsn.Text);
                if (editing)
                {
                    int function = Convert.ToInt32(textBoxFunctions.Text);
                    succesfulExecution = UpdateEmployee(editId, active, firstName, lastName, username, email, phonenumber, address, dateOfBirth, bsn, spouseName, spousePhone, function, postalCode, city, preferredHours);
                }
                else
                {
                    succesfulExecution = CreateEmployee(active, firstName, lastName, username, password, email, phonenumber, address, dateOfBirth, bsn, spouseName, spousePhone, postalCode, city, preferredHours);
                }
                if (succesfulExecution)
                {
                    this.DialogResult = DialogResult.OK;
                }
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
            textBoxFunctions.Text = employee.Function.ToString();
            textBoxPostalCode.Text = employee.PostalCode;
            textBoxCity.Text = employee.City;
            preferredHours = employee.PreferredHours;
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
            textBoxPostalCode.BackColor = Color.FromName("Window");
            textBoxCity.BackColor = Color.FromName("Window");
        }

        private void buttonEDWCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonPreferredShifts_Click(object sender, EventArgs e)
        {
            ph = new PreferredHours(preferredHours);
            if (ph.ShowDialog() == DialogResult.OK)
            {
                preferredHours = ph.PreferredHoursString;
            }
        }
    }
}
