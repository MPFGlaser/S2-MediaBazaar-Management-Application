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

        public EmployeeDetailsWindow()
        {
            InitializeComponent();
        }

        public Employee Employee
        {
            get { return this.employee; }
        }

        private void CreateEmployee(bool active, string firstName, string surName, string userName, string password, string email, int phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, int spousePhone)
        {
            
            employee = new Employee(0, true, firstName, surName, userName, password, email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone);
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
            int phonenumber, spousePhone;

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
            else if (!checkPassword.IsMatch(password))
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

                if (textBoxPhoneNumber.Text.Length == 12)
                {
                    //phonenumber = Convert.ToInt32(textBoxPhoneNumber.Text.Substring(1)); -->Change phonenumber type to string
                    phonenumber = Convert.ToInt32(textBoxPhoneNumber.Text);
                }
                else
                {
                    phonenumber = Convert.ToInt32(textBoxPhoneNumber.Text);
                }

                if(textBoxSpousePhone.Text.Length == 12)
                {
                    //spousePhone = Convert.ToInt32(textBoxSpousePhone.Text.Substring(1)); -->Change spousePhone type to string
                    spousePhone = Convert.ToInt32(textBoxSpousePhone.Text);
                }
                else
                {
                    spousePhone = Convert.ToInt32(textBoxSpousePhone.Text);
                }

                CreateEmployee(true, firstName, lastName, username, password, email, phonenumber, address, dateOfBirth, bsn, spouseName, spousePhone);
                this.DialogResult = DialogResult.OK;
            }
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
