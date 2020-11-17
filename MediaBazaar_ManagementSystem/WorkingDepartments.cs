﻿using MediaBazaar_ManagementSystem.classes;
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
    public partial class WorkingDepartments : Form
    {
        private string workingDepartments = null;
        public WorkingDepartments()
        {
            InitializeComponent();
        }

        public WorkingDepartments(string input, List<Department> allDepartments)
        {
            List<int> selectedDepartments = getSelectedDepartments(input);
            InitializeComponent();
            InitializeDepartments(allDepartments, selectedDepartments);
        }
        #region Logic
        private List<int> getSelectedDepartments(string input)
        {
            return new List<int>();
        }

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
