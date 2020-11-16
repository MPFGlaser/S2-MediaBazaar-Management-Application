using MediaBazaar_ManagementSystem.classes;
using MediaBazaar_ManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazaar_ManagementSystem.Models;

namespace MediaBazaar_ManagementSystem
{
    public partial class SchedulingWindow : Form
    {
        DatabaseHandler dbhandler;
        private Shift currentShift;
        private DateTime date;
        private ShiftTime shiftTime;
        List<int> workingEmployeeIds = new List<int>(), tempEmployeeList = new List<int>();
        private bool isEditing;
        private int oldId;

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
        public SchedulingWindow(string dateAndMonth, string weekDay, ShiftTime shiftTime, DateTime date, List<Employee> working, bool editing, int oldShiftId)
        {
            InitializeComponent();
            InitializeComboBoxShiftTime();
            LoadEmployees(working);
            LoadDepartments();
            this.date = date;
            this.shiftTime = shiftTime;
            this.comboBoxShiftTime.SelectedItem = shiftTime;
            textBoxWeekDay.Text = weekDay;
            textBoxCalendarDate.Text = dateAndMonth;
            this.isEditing = editing;
            this.oldId = oldShiftId;

            AddEmployeeListToShift(working);
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
        private void LoadEmployees(List<Employee> working)
        {
            dbhandler = new DatabaseHandler();
            List<Employee> allActiveEmployees = dbhandler.GetActiveEmployeesFromDB();

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

        //Loads all of the departmenst from the database
        private void LoadDepartments()
        {
            dbhandler = new DatabaseHandler();
            List<Department> allDepartments = dbhandler.GetAllDepartments();

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
        /// Logic for the confirm button. Adds each employee in the scheduled listbox to the shift in the database.
        /// </summary>
        private void Confirm()
        {
            // Makes sure everything is set up correctly.
            dbhandler = new DatabaseHandler();
            workingEmployeeIds = new List<int>();

            // Makes a list of all ids of the employees scheduled for that shift
            foreach (dynamic emp in listBoxCurrentEmployees.Items)
            {
                workingEmployeeIds.Add((emp).Employee.Id);
            }

            foreach(int id in tempEmployeeList)
            {
                workingEmployeeIds.Add(id);
            }

            // Creates a new shift object and sets the list of employeeIds to the one we just created.
            currentShift = new Shift(0, date, shiftTime);
            currentShift.EmployeeIds = workingEmployeeIds;

            // Checks if the shift is in editing mode and chooses whether to edit or create a shift in the database
            if (isEditing)
            {
                // Removes all information about the shift in the database to prevent duplication of entries
                dbhandler.ClearShift(oldId);

                // Adds each employee id to the database with the correct shift id
                foreach (int i in workingEmployeeIds)
                {
                    dbhandler.AddIdToShift(oldId, i);
                }
            }
            else
            {
                // Adds each employee id to the database with the correct shift id
                dbhandler.AddShiftToDb(currentShift);
            }
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Adds the selected employee to the shift and removes it from the list of employees you can add to the shift.
        /// </summary>
        private void AddEmployeeToShift()
        {
            // Checks if there's actually an employee selected to be added
            if (comboBoxSelectEmployees.SelectedIndex != -1)
            {
                // Ensures the right employee object is used
                Employee selected = (comboBoxSelectEmployees.SelectedItem as dynamic).Employee;

                // Adds the selected employee to the listbox with currently scheduled employees.
                listBoxCurrentEmployees.DisplayMember = "Text";
                listBoxCurrentEmployees.ValueMember = "Employee";
                listBoxCurrentEmployees.Items.Add(new { Text = selected.FirstName + " " + selected.SurName, Employee = selected });

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
                // Ensures the right employee object is used
                Employee selected = (listBoxCurrentEmployees.SelectedItem as dynamic).Employee;

                // Adds the selected employee to the combobox of available employees.
                comboBoxSelectEmployees.DisplayMember = "Text";
                comboBoxSelectEmployees.ValueMember = "Employee";
                comboBoxSelectEmployees.Items.Add(new { Text = selected.FirstName + " " + selected.SurName, Employee = selected });

                // Removes the employee from the listbox of currently scheduled employee.
                listBoxCurrentEmployees.Items.Remove(listBoxCurrentEmployees.SelectedItem);
            }
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
            if(selectedDepartment != null)
            {
                if (isEditing)
                {
                    if (selectedDepartment.Employees != null && selectedDepartment.Employees.Count() > 0)
                    {
                        Console.WriteLine("Has employees");
                        AddEmployeeListToShift(selectedDepartment.Employees);
                    }
                    else
                    {
                        Console.WriteLine("No employees");
                        dbhandler = new DatabaseHandler();
                        List<Employee> employeesInDepartment = dbhandler.GetEmployeesPerDepartment(oldId, selectedDepartment.Id);

                        AddEmployeeListToShift(employeesInDepartment);
                    }
                }

                selectedDepartment.Employees = new List<Employee>();
                foreach (dynamic emp in listBoxCurrentEmployees.Items)
                {
                    Employee currentEmployee = (emp as dynamic).Employee;
                    selectedDepartment.Employees.Add(currentEmployee);
                }
            }
        }

        #endregion
    }
}
