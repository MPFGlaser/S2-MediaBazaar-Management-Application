using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class WorkingDepartments : Form
    {
        private string workingDepartments = "";
        public WorkingDepartments()
        {
            InitializeComponent();
        }

        public WorkingDepartments(string input, List<Department> allDepartments)
        {
            List<int> selectedDepartments = new List<int>();
            if(input != String.Empty)
                selectedDepartments = input.Split(',').Select(int.Parse).ToList();
            InitializeComponent();
            InitializeDepartments(allDepartments, selectedDepartments);
        }

        public string WorkingDepartmentsString
        {
            get { return workingDepartments; }
        }

        #region Logic
        /// <summary>
        /// Loads all of the departments into the correct boxes, if it is already selected it is added to the
        /// working departments, if it is not it is added to the selection box.
        /// </summary>
        private void InitializeDepartments(List<Department> allDepartments, List<int> selectedDepartments)
        {
            foreach (Department d in allDepartments)
            {
                if (selectedDepartments.Contains(d.Id))
                {
                    listBoxCurrentWorkingDepartments.DisplayMember = "Text";
                    listBoxCurrentWorkingDepartments.ValueMember = "Department";
                    listBoxCurrentWorkingDepartments.Items.Add(new { Text = d.Name, Department = d });
                }
                else
                {
                    comboBoxSelectDepartments.DisplayMember = "Text";
                    comboBoxSelectDepartments.ValueMember = "Department";
                    comboBoxSelectDepartments.Items.Add(new { Text = d.Name, Department = d });
                }
            }
        }

        /// <summary>
        /// Saves the departments at which the employee can work in a string seperated by commas's.
        /// </summary>
        private void Confirm()
        {
            bool first = true;
            foreach (dynamic depDynamic in listBoxCurrentWorkingDepartments.Items)
            {
                Department dep = (depDynamic).Department;
                if (first)
                {
                    first = false;
                    workingDepartments += dep.Id.ToString();
                }
                else
                {
                    workingDepartments += "," + dep.Id.ToString();
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Adds the department to the list in which the employee can work.
        /// </summary>
        private void AddDepartmentToWorkable()
        {
            // Checks if there's actually a department selected to be added
            if (comboBoxSelectDepartments.SelectedIndex != -1)
            {
                // Ensures the right department object is used
                Department selectedDepartment = (comboBoxSelectDepartments.SelectedItem as dynamic).Department;

                // Adds the selected department to the listbox with currently selected departments.
                listBoxCurrentWorkingDepartments.DisplayMember = "Text";
                listBoxCurrentWorkingDepartments.ValueMember = "Department";
                listBoxCurrentWorkingDepartments.Items.Add(new { Text = selectedDepartment.Name, Department = selectedDepartment });

                // Removes the employee from the list of available employees and resets the selection index.
                comboBoxSelectDepartments.Items.Remove(comboBoxSelectDepartments.SelectedItem);
                comboBoxSelectDepartments.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Removes the department from the list in which the employee can work.
        /// </summary>
        private void RemoveDepartmentFromWorkable()
        {
            // Checks if there's actually an employee selected to be removed
            if (listBoxCurrentWorkingDepartments.SelectedIndex != -1)
            {
                // Ensures the right department object is used
                Department selectedDepartment = (listBoxCurrentWorkingDepartments.SelectedItem as dynamic).Department;

                // Adds the selected employee to the combobox of available employees.
                comboBoxSelectDepartments.DisplayMember = "Text";
                comboBoxSelectDepartments.ValueMember = "Department";
                comboBoxSelectDepartments.Items.Add(new { Text = selectedDepartment.Name, Department = selectedDepartment });

                // Removes the employee from the listbox of currently scheduled employee.
                listBoxCurrentWorkingDepartments.Items.Remove(listBoxCurrentWorkingDepartments.SelectedItem);
            }
        }

        #endregion

        #region Button handlers
        private void buttonWorkingDepartmentsConfirm_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void buttonAddDepartmentToEmployee_Click(object sender, EventArgs e)
        {
            AddDepartmentToWorkable();
        }

        private void buttonRemoveDepartmentFromEmployee_Click(object sender, EventArgs e)
        {
            RemoveDepartmentFromWorkable();
        }
        #endregion
    }
}
