using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class EmployeeDetailsWindow : Form
    {
        IEmployeeStorage employeeStorage;
        IDepartmentStorage departmentStorage;
        IFunctionStorage functionStorage;

        private Employee employee, loggedInUser;
        private Boolean editing = false;
        private int editId, currentUser;
        string preferredHours = "000000000000000000000", workingDepartments = "";
        List<Department> allDepartments = new List<Department>();
        PreferredHours ph;
        WorkingDepartments wd;

        public EmployeeDetailsWindow(Employee loggedInUser)
        {
            InitializeComponent();
            employeeStorage = new EmployeeMySQL();
            departmentStorage = new DepartmentMySQL();
            functionStorage = new FunctionMySQL();
            currentUser = loggedInUser.Id;
            this.loggedInUser = loggedInUser;
            LoadDepartments();
            CheckPermissions();
        }

        public Employee Employee
        {
            get { return employee; }
        }

        /// <summary>
        /// Checks the permissions of the loggedInUser and disables functions accordingly.
        /// </summary>
        private void CheckPermissions()
        {
            if (!loggedInUser.Permissions.Contains("employee_change_active"))
                checkBoxActive.Enabled = false;
        }

        #region Logic
        /// <summary>
        /// Asks the employeeStorage to create a new employee based on the parameters the user entered in the form.
        /// </summary>
        /// <param name="active"></param>
        /// <param name="firstName"></param>
        /// <param name="surName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="bsn"></param>
        /// <param name="spouseName"></param>
        /// <param name="spousePhone"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="preferredHours"></param>
        /// <returns></returns>
        private bool CreateEmployee(bool active, string firstName, string surName, string userName, string password, string email, string phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, string spousePhone, string postalCode, string city, string preferredHours, string workingDepartments, int contractHours)
        {
            employee = new Employee(0, active, firstName, surName, userName, password, email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone, 0, postalCode, city, preferredHours, workingDepartments, contractHours);
            return employeeStorage.Create(employee);
        }

        /// <summary>
        /// Asks the employeeStorage to update the employee with the supplied id. The updated details will be those entered by the user in the form.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="active"></param>
        /// <param name="firstName"></param>
        /// <param name="surName"></param>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="bsn"></param>
        /// <param name="spouseName"></param>
        /// <param name="spousePhone"></param>
        /// <param name="function"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="preferredHours"></param>
        /// <returns></returns>
        private bool UpdateEmployee(int id, bool active, string firstName, string surName, string userName, string email, string phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, string spousePhone, int function, string postalCode, string city, string preferredHours, string workingDepartments, int contractHours)
        {
            employee = new Employee(id, active, firstName, surName, userName, "", email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone, function, postalCode, city, preferredHours, workingDepartments, contractHours);
            return employeeStorage.Update(employee);
        }

        /// <summary>
        /// Logic for the confirm button
        /// <para>Resets the error-colouring of all inputs, then proceeds to run regex expressions on all inputs, colouring the inputs that don't pass it red.</para>
        /// <para>When all inputs have passed the regex, it either creates or updates an employee, based on the way the form was instantiated.</para>
        /// </summary>
        private void Confirm()
        {
            // Resets the visual indicator for when a regex expression turns out not to pass.
            ResetBoxColors();

            // Assigns the values entered by the user to their respective variables.
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
            int function = -1;
            Boolean active = checkBoxActive.Checked;
            Boolean allCorrect = true;

            // This wall of if statements checks each input against its regex expression (where applicable)
            //If something's wrong, makes sure to highlight the input & prevents the incorrect data from being passed to the employeeStorage.
            if (!CheckValidity.Name(firstName))
            {
                allCorrect = false;
                textBoxFirstName.BackColor = Color.LightCoral;
            }
            if (!CheckValidity.Name(lastName))
            {
                allCorrect = false;
                textBoxLastName.BackColor = Color.LightCoral;
            }
            if (!CheckValidity.Username(username))
            {
                allCorrect = false;
                textBoxUsername.BackColor = Color.LightCoral;
            }
            if (!CheckValidity.Password(password) && !editing)
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
            if (!CheckValidity.PhoneNumber(textBoxPhoneNumber.Text))
            {
                allCorrect = false;
                textBoxPhoneNumber.BackColor = Color.LightCoral;
            }
            if (!CheckValidity.Address(address))
            {
                allCorrect = false;
                textBoxAddress.BackColor = Color.LightCoral;
            }
            if (!CheckValidity.Email(email))
            {
                allCorrect = false;
                textBoxEmail.BackColor = Color.LightCoral;
            }
            if (!CheckValidity.BSN(textBoxBsn.Text))
            {
                allCorrect = false;
                textBoxBsn.BackColor = Color.LightCoral;
            }
            if (!CheckValidity.Name(spouseName))
            {
                allCorrect = false;
                textBoxSpouseName.BackColor = Color.LightCoral;
            }
            if (!CheckValidity.PhoneNumber(textBoxSpousePhone.Text))
            {
                allCorrect = false;
                textBoxSpousePhone.BackColor = Color.LightCoral;
            }
            if (cmbFunctions.SelectedIndex > -1)
                function = Convert.ToInt32((cmbFunctions.SelectedItem as ComboboxItem).Value.ToString());
            if (!CheckValidity.Name(textBoxCity.Text))
            {
                allCorrect = false;
                textBoxCity.BackColor = Color.LightCoral;
            }
            if (!CheckValidity.PostalCode(textBoxPostalCode.Text))
            {
                allCorrect = false;
                textBoxPostalCode.BackColor = Color.LightCoral;
            }
            // If all regex expressions have successfully passed, this runs
            if (allCorrect)
            {
                bool success;

                // This conversion seems sketchy, but because it was checked by the regex before, it should not pose a problem.
                int bsn = Convert.ToInt32(textBoxBsn.Text);
                int contractHours = Convert.ToInt32(numericUpDownEmployeeHours.Value);
                if (contractHours == 0)
                {
                    contractHours = Globals.zeroHourContract;
                }

                // Checks whether the form was opened in editing mode or not. If it was, it updates the employee. If not, it creates a new one.
                if (editing)
                {
                    // Update to use new stuff
                    success = UpdateEmployee(editId, active, firstName, lastName, username, email, phonenumber, address, dateOfBirth, bsn, spouseName, spousePhone, function, postalCode, city, preferredHours, workingDepartments, contractHours);
                }
                else
                {
                    // Update to use new stuff
                    success = CreateEmployee(active, firstName, lastName, username, password, email, phonenumber, address, dateOfBirth, bsn, spouseName, spousePhone, postalCode, city, preferredHours, "", contractHours);
                }

                // If the CreateEmployee command was executed successfully, the form closes.
                // This is so that the user doesn't have to re-enter all the data in case something (temporarily) went wrong with the CreateEmployee command.
                if (success)
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// Pre-fills the form with data of an employee for when it is opened with the intention of editing an employee.
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployeeData(Employee employee)
        {
            int index = 0;

            // Changes the form title to reflect which employee is being edited.
            Text = "Viewing/editing " + employee.FirstName + "'s details";

            // Sets some editing-specific variables to their correct values. This aides with sending the employeeStorage the right details later on.
            editing = true;
            editId = employee.Id;

            // Changes the visibility/enabled status of some of the controls, as we don't want certain things to be edited.
            textBoxPassword.Enabled = false;
            textBoxPasswordConfirm.Enabled = false;
            labelPassword.Enabled = false;
            labelPasswordc.Enabled = false;
            employeeSpecificsGroup.Visible = true;

            // Pre-fills all the form controls with the data present in the Employee object that was passed along in the parameters of this function.
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
            textBoxPostalCode.Text = employee.PostalCode;
            textBoxCity.Text = employee.City;
            preferredHours = employee.PreferredHours;
            workingDepartments = employee.WorkingDepartments;
            ComboboxItem x = new ComboboxItem();
            int cid = 0;
            Dictionary<int, string> items = new Dictionary<int, string>();
            items = functionStorage.GetFunctions();
            foreach (int cindex in items.Keys)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = items[cindex];
                item.Value = cindex;
                if (cindex == employee.Function) { x = item; cid = cindex; }
                cmbFunctions.Items.Add(item);
            }
            if (cid >= 0) cmbFunctions.SelectedItem = x;
            else cmbFunctions.SelectedItem = -1;
            if (employee.ContractHours == Globals.zeroHourContract)
            {
                numericUpDownEmployeeHours.Value = 0;
            }
            else
            {
                numericUpDownEmployeeHours.Value = employee.ContractHours;
            }

            PreventUserLockout();
        }

        /// <summary>
        /// Resets the background colours of all inputs. This is to prevent the warning colours from sticking around despite the data entered having been corrected by the user.
        /// </summary>
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
            numericUpDownEmployeeHours.BackColor = Color.FromName("Window");
        }

        // Loads all of the departmenst from the departmentStorage and sets them into the combobox
        private void LoadDepartments()
        {
            allDepartments = departmentStorage.GetAll();
        }

        private void PreventUserLockout()
        {
            if (currentUser == editId)
            {
                checkBoxActive.Checked = true;
                checkBoxActive.Enabled = false;
            }
        }
        #endregion

        #region Button handlers
        private void buttonEDWConfirm_Click(object sender, System.EventArgs e)
        {
            Confirm();
        }

        private void buttonEDWCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonPreferredShifts_Click(object sender, EventArgs e)
        {
            // Creates and shows the PreferredHours form so the user can select the preferred working hours of the employee being created/edited.
            ph = new PreferredHours(preferredHours);
            if (ph.ShowDialog() == DialogResult.OK)
            {
                preferredHours = ph.PreferredHoursString;
            }
        }

        private void buttonWorkingDepartments_Click(object sender, EventArgs e)
        {
            //Creates and shows the WorkingDepartments form so the user can select the department on which the employee will be working.
            wd = new WorkingDepartments(workingDepartments, allDepartments);
            if (wd.ShowDialog() == DialogResult.OK)
            {
                workingDepartments = wd.WorkingDepartmentsString;
            }
        }
        #endregion
    }
}
