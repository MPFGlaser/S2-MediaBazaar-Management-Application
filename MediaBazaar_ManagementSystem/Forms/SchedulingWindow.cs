using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem
{
    public partial class SchedulingWindow : Form
    {
        IEmployeeStorage employeeStorage;
        IDepartmentStorage departmentStorage;
        IShiftStorage shiftStorage;

        private Shift currentShift;
        private DateTime date;
        private ShiftTime shiftTime;
        List<int> workingEmployeeIds = new List<int>();
        List<Department> allDepartments = new List<Department>();
        List<Employee> allActiveEmployees = new List<Employee>();
        private bool isEditing;
        private int oldId, capacity;
        private Department previousSelectedDepartment;
        private Dictionary<int, int> departmentCapacity = new Dictionary<int, int>();

        /// <summary>
        /// A form in which the user can schedule and unschedule employees for a certain shift.
        /// </summary>
        /// <param name="dateAndMonth"></param>
        /// <param name="weekDay"></param>
        /// <param name="shiftTime"></param>
        /// <param name="date"></param>
        /// <param name="working"></param>
        /// <param name="editing"></param>
        /// <param name="oldShiftId"></param>
        public SchedulingWindow(string dateAndMonth, string weekDay, ShiftTime shiftTime, DateTime date, List<Employee> working, bool editing, int oldShiftId, int capacity, List<Employee> allEmployees, Department previousSelectedDepartment)
        {
            InitializeComponent();
            InitializeComboBoxShiftTime();
            LoadEmployees(working, allEmployees);
            this.date = date;
            this.shiftTime = shiftTime;
            this.comboBoxShiftTime.SelectedItem = shiftTime;
            textBoxWeekDay.Text = weekDay;
            textBoxCalendarDate.Text = dateAndMonth;
            this.isEditing = editing;
            this.oldId = oldShiftId;
            this.capacity = capacity;
            this.previousSelectedDepartment = previousSelectedDepartment;

            numericUpDownCapacity.Value = capacity;
            AddEmployeeListToShift(working);
            LoadDepartments();
        }

        public List<int> WorkingEmployeeIds
        {
            get { return workingEmployeeIds; }
        }

        #region Logic
        /// <summary>
        /// Loads the employees which are working that shift
        /// </summary>
        /// <param name="working"></param>
        private void LoadEmployees(List<Employee> working, List<Employee> allEmployees)
        {
            //employeeStorage = new EmployeeMySQL();
            //allActiveEmployees = employeeStorage.GetAll(true);
            allActiveEmployees = allEmployees;

            foreach (Employee e in working)
            {
                workingEmployeeIds.Add(e.Id);
            }

            foreach (Employee e in allActiveEmployees)
            {
                if (!workingEmployeeIds.Contains(e.Id))
                {
                    comboBoxSelectEmployees.DisplayMember = "Text";
                    comboBoxSelectEmployees.ValueMember = "Employee";
                    comboBoxSelectEmployees.Items.Add(new { Text = e.FirstName + " " + e.SurName, Employee = e });
                }
            }
        }

        // Loads all of the department from the departmentStorage and sets them into the combobox
        private void LoadDepartments()
        {
            departmentStorage = new DepartmentMySQL();
            shiftStorage = new ShiftMySQL();
            allDepartments = departmentStorage.GetAll();

            if (isEditing)
            {
                this.departmentCapacity = shiftStorage.GetCapacityPerDepartment(oldId);
            }

            foreach (Department d in allDepartments)
            {
                if (isEditing)
                {
                    d.Employees = shiftStorage.GetDepartmentEmployees(oldId, d.Id);
                    if (departmentCapacity.ContainsKey(d.Id))
                    {
                        d.Capacity = departmentCapacity[d.Id];
                    }
                    else
                    {
                        d.Capacity = 0;
                    }
                }

                comboBoxSelectDepartments.DisplayMember = "Text";
                comboBoxSelectDepartments.ValueMember = "Department";
                comboBoxSelectDepartments.Items.Add(new { Text = d.Name, Department = d });
            }

            if(previousSelectedDepartment != null)
            {
                foreach(dynamic depDynamic in comboBoxSelectDepartments.Items)
                {
                    Department d = (depDynamic).Department;
                    if(d.Name == previousSelectedDepartment.Name)
                    {
                        comboBoxSelectDepartments.SelectedItem = depDynamic;
                        numericUpDownCapacity.Value = d.Capacity;
                        break;
                    }
                }
            }
        }

        // Updates the items in the select departments combobox so they have the correct data.
        private void UpdateDepartmentsComboBox(List<Department> allDepartments)
        {
            comboBoxSelectDepartments.Items.Clear();
            foreach (Department d in allDepartments)
            {
                comboBoxSelectDepartments.DisplayMember = "Text";
                comboBoxSelectDepartments.ValueMember = "Department";
                comboBoxSelectDepartments.Items.Add(new { Text = d.Name, Department = d });
            }
        }

        // Pre-fills the combobox for the shift time with all defined shift times. (Morning, afternoon, evening at the time of writing)
        private void InitializeComboBoxShiftTime()
        {
            this.comboBoxShiftTime.SelectedIndexChanged += new System.EventHandler(comboBoxShiftTime_SelectedIndexChanged);
            this.comboBoxShiftTime.DataSource = Enum.GetValues(typeof(ShiftTime));
        }

        /// <summary>
        /// Fills the listbox with employees that are currently scheduled for that shift.
        /// </summary>
        /// <param name="toAddToShift"></param>
        private void AddEmployeeListToShift(List<Employee> toAddToShift)
        {
            listBoxCurrentEmployees.Items.Clear();
            foreach (Employee e in toAddToShift)
            {
                listBoxCurrentEmployees.DisplayMember = "Text";
                listBoxCurrentEmployees.ValueMember = "Employee";
                listBoxCurrentEmployees.Items.Add(new { Text = e.FirstName + " " + e.SurName, Employee = e });
            }
        }

        /// <summary>
        /// Logic for the confirm button. Adds each employee in the scheduled listbox to the shift in the shiftStorage.
        /// </summary>
        private void Confirm()
        {
            // Makes sure everything is set up correctly.
            shiftStorage = new ShiftMySQL();
            workingEmployeeIds = new List<int>();
            int capacityNew = Convert.ToInt32(numericUpDownCapacity.Value);
            int shiftId = 0;

            // Checks if the shift is in editing mode and chooses whether to edit or create a shift in the shiftStorage
            if (isEditing)
            {
                // Creates a new shift object and sets the list of employeeIds to the one we just created.
                currentShift = new Shift(oldId, date, shiftTime, capacityNew);
                // Removes all information about the shift in the shiftStorage to prevent duplication of entries
                shiftStorage.Clear(oldId);
                shiftId = oldId;

                if(capacityNew != capacity)
                {
                    shiftStorage.Update(currentShift);
                }
            }
            else
            {
                // Creates a new shift object and sets the list of employeeIds to the one we just created.
                currentShift = new Shift(0, date, shiftTime, capacityNew);
                shiftId = shiftStorage.Create(currentShift);
            }


            foreach (dynamic depDynamic in comboBoxSelectDepartments.Items)
            {
                Department dep = (depDynamic).Department;

                // Makes a list of all ids of the employees scheduled for that shift
                foreach (Employee emp in dep.Employees)
                {
                    //workingEmployeeIds.Add(emp.Id);
                    shiftStorage.Assign(shiftId, emp.Id, dep.Id);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Adds the selected employee to the shift and removes it from the list of employees you can add to the shift.
        /// </summary>
        private void AddEmployeeToShift()
        {
            // Checks if there's actually an employee selected to be added
            if (comboBoxSelectEmployees.SelectedIndex != -1 && comboBoxSelectDepartments.SelectedIndex != -1)
            {
                // Ensures the right employee object is used
                Employee selectedEmployee = (comboBoxSelectEmployees.SelectedItem as dynamic).Employee;

                // Displays a message when the amount of hours an employee has in their contract is gone over
                if(selectedEmployee.WorkingHours + 4.5f > selectedEmployee.ContractHours)
                {
                    //BLINK RED ON TIMER!
                    labelEmployeeOverScheduled.Text = "Employee " + selectedEmployee.FirstName + " has exceded their weekly hours";
                    labelEmployeeOverScheduled.BackColor = Color.LightCoral;
                    labelEmployeeOverScheduled.Visible = true;
                    Blink();
                }

                List<Department> allDepartments = GetDepartmentListFromComboBox();
                int selectedIndex = comboBoxSelectDepartments.SelectedIndex;

                // Adds 4.5 hours to the selected employees current hours
                selectedEmployee.WorkingHours += 4.5f;

                // Adds the selected employee to the list of employees in the department
                allDepartments[selectedIndex].Employees.Add(selectedEmployee);

                // Adds the selected employee to the listbox with currently scheduled employees.
                listBoxCurrentEmployees.DisplayMember = "Text";
                listBoxCurrentEmployees.ValueMember = "Employee";
                listBoxCurrentEmployees.Items.Add(new { Text = selectedEmployee.FirstName + " " + selectedEmployee.SurName, Employee = selectedEmployee });

                // Removes the employee from the list of available employees and resets the selection index.
                comboBoxSelectEmployees.Items.Remove(comboBoxSelectEmployees.SelectedItem);
                comboBoxSelectEmployees.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Removes the selected employee from the shift and re-adds it to the list of employees you can add to the shift.
        /// </summary>
        private void RemoveEmployeeFromShift()
        {
            // Checks if there's actually an employee selected to be removed
            if (listBoxCurrentEmployees.SelectedIndex != -1)
            {
                List<Department> allDepartments = GetDepartmentListFromComboBox();

                // Ensures the right employee object is used
                Employee selectedEmployee = (listBoxCurrentEmployees.SelectedItem as dynamic).Employee;

                // Removes 4.5 hours from the selected employees hours
                selectedEmployee.WorkingHours -= 4.5f;

                if (comboBoxSelectDepartments.SelectedIndex != -1)
                {
                    // Selects the correct index from the combobox
                    Department dep = (comboBoxSelectDepartments.SelectedItem as dynamic).Department;
                    int selectedIndex = dep.Id - 1;

                    RemoveSelectedEmployee(selectedEmployee, selectedIndex);
                }
                else
                {
                    /*foreach (Department d in allDepartments)
                    {
                        List<Employee> employeesInDepartment = d.Employees;
                        foreach (Employee e in d.Employees)
                        {
                            if (e.Equals(selectedEmployee))
                            {
                                RemoveSelectedEmployee(selectedEmployee, d.Id - 1);
                            }
                        }
                    }*/
                    MessageBox.Show("Please select a department first");
                }
            }
        }

        /// <summary>
        /// Removes the selected employee at the department at which it is working.
        /// </summary>
        private void RemoveSelectedEmployee(Employee selectedEmployee, int selectedIndex)
        {
            allDepartments[selectedIndex].Employees.Remove(selectedEmployee);

            // Adds the selected employee to the combobox of available employees.
            comboBoxSelectEmployees.DisplayMember = "Text";
            comboBoxSelectEmployees.ValueMember = "Employee";
            comboBoxSelectEmployees.Items.Add(new { Text = selectedEmployee.FirstName + " " + selectedEmployee.SurName, Employee = selectedEmployee });

            // Removes the employee from the listbox of currently scheduled employee.
            listBoxCurrentEmployees.Items.Remove(listBoxCurrentEmployees.SelectedItem);
        }

        /// <summary>
        /// Returns all of the departments within the select department combobox.
        /// </summary>
        private List<Department> GetDepartmentListFromComboBox()
        {
            List<Department> allDepartments = new List<Department>();

            foreach (dynamic depDynamic in comboBoxSelectDepartments.Items)
            {
                Department dep = (depDynamic).Department;
                allDepartments.Add(dep);
            }

            return allDepartments;
        }

        /// <summary>
        /// Updates the combobox to only show employees who can work in a certain department.
        /// </summary>
        private void ShowValidEmployees(int id)
        {
            comboBoxSelectEmployees.Items.Clear();
            List<Department> allDepartmentInfo = GetDepartmentListFromComboBox();

            foreach (Employee e in allActiveEmployees)
            {
                List<int> allowedDepartments = new List<int>();
                if(e.WorkingDepartments != string.Empty)
                {
                    allowedDepartments = e.WorkingDepartments.Split(',').Select(int.Parse).ToList();
                }

                if (allowedDepartments.Contains(id))
                {
                    bool allowed = true;
                    foreach(Department d in allDepartmentInfo)
                    {
                        List<Employee> employeesInDepartment = d.Employees;

                        foreach (Employee emp in d.Employees)
                        {
                            if (e.Id == emp.Id)
                            {
                                allowed = false;
                            }
                        }
                    }
                    if (allowed)
                    {
                        comboBoxSelectEmployees.DisplayMember = "Text";
                        comboBoxSelectEmployees.ValueMember = "Employee";
                        comboBoxSelectEmployees.Items.Add(new { Text = e.FirstName + " " + e.SurName, Employee = e });
                    }
                }
            }

            comboBoxSelectEmployees.SelectedIndex = 0;
        }
        #endregion

        #region Control event handlers
        private void comboBoxShiftTime_SelectedIndexChanged(Object sender, EventArgs e)
        {
            this.shiftTime = (ShiftTime)comboBoxShiftTime.SelectedItem;
        }

        private void buttonAddEmployeeToShift_Click(object sender, EventArgs e)
        {
            AddEmployeeToShift();
        }

        private void buttonRemoveEmployeeFromShift_Click(object sender, EventArgs e)
        {
            RemoveEmployeeFromShift();
        }

        private void buttonScheduleConfirm_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void buttonScheduleCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonNextDay_Click(object sender, EventArgs e)
        {
            date.AddDays(1);
        }

        private void buttonPreviousDay_Click(object sender, EventArgs e)
        {
            date.AddDays(-1);
        }

        private void comboBoxSelectDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department selectedDepartment = (comboBoxSelectDepartments.SelectedItem as dynamic).Department;
            ShowValidEmployees(selectedDepartment.Id);
            AddEmployeeListToShift(selectedDepartment.Employees);
            numericUpDownCapacity.Value = selectedDepartment.Capacity;
        }

        private async void Blink()
        {
            int i = 0;
            while (i < 6)
            {
                await Task.Delay(500);
                labelEmployeeOverScheduled.BackColor = labelEmployeeOverScheduled.BackColor == Color.LightCoral ? Color.FromName("Window") : Color.LightCoral;
                i++;
            }
            labelEmployeeOverScheduled.Text = "";
            labelEmployeeOverScheduled.Visible = false;
        }
        #endregion

        public List<Employee> AllActiveEmployees
        {
            get { return allActiveEmployees; }
        }
    }
}