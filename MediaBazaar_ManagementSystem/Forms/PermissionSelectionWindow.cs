﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class PermissionSelectionWindow : Form
    {
        IFunctionStorage functionStorage;
        AddNewFunctionWindow addNewFunctionWindow;
        Dictionary<int, string> functions;
        List<string> permissionsGranted;
        int selectedFunctionId = -1;
        bool unsavedChanges = false;

        public PermissionSelectionWindow()
        {
            InitializeComponent();
            functionStorage = new FunctionMySQL();
            AreCheckboxesEnabled(false);
            SetUniformHeight();
            PopulateComboBox();
            CreateCheckBoxChangedEventHandlers();
        }

        /// <summary>
        /// Populates the ComboBox with all functions found in the database.
        /// </summary>
        private void PopulateComboBox()
        {
            comboBoxCurrentFunction.Items.Clear();
            functions = functionStorage.GetFunctions();
            foreach (KeyValuePair<int, string> i in functions)
            {
                comboBoxCurrentFunction.Items.Add(i.Value);
            }
        }

        /// <summary>
        /// Loads the permissions of the selected function from the database.
        /// </summary>
        private void LoadPermissions(int function)
        {
            permissionsGranted = functionStorage.GetPermissions(function);
        }

        /// <summary>
        /// Fills the checkboxes according to the permissions present in permissionsGranted.
        /// </summary>
        private void FillCheckboxes()
        {
            // General
            checkBoxGeneralLoginApplication.Checked = permissionsGranted.Contains("login_application");
            checkBoxGeneralLoginWebsite.Checked = permissionsGranted.Contains("login_website");
            checkBoxGeneralClockInOut.Checked = permissionsGranted.Contains("clock_in_out");

            // Employee management
            checkBoxEmployeesView.Checked = permissionsGranted.Contains("employee_view");
            checkBoxEmployeesEdit.Checked = permissionsGranted.Contains("employee_edit");
            checkBoxEmployeesAdd.Checked = permissionsGranted.Contains("employee_add");
            checkBoxEmployeesActive.Checked = permissionsGranted.Contains("employee_change_active");

            // Stock management
            checkBoxProductsView.Checked = permissionsGranted.Contains("product_view");
            checkBoxProductsEdit.Checked = permissionsGranted.Contains("product_edit");
            checkBoxProductsAdd.Checked = permissionsGranted.Contains("product_add");
            checkBoxProductsActive.Checked = permissionsGranted.Contains("product_change_active");
            checkBoxProductsRestockFile.Checked = permissionsGranted.Contains("product_restock_file");
            checkBoxProductsRestockAccept.Checked = permissionsGranted.Contains("product_restock_accept");

            // Department management
            checkBoxDepartmentsView.Checked = permissionsGranted.Contains("department_view");
            checkBoxDepartmentsEdit.Checked = permissionsGranted.Contains("department_edit");
            checkBoxDepartmentsAdd.Checked = permissionsGranted.Contains("department_add");
            checkBoxDepartmentsChangeActive.Checked = permissionsGranted.Contains("department_change_active");

            // Function management
            checkBoxFunctionsAdd.Checked = permissionsGranted.Contains("function_add");
            checkBoxFunctionsEdit.Checked = permissionsGranted.Contains("function_edit");

            // Scheduling
            checkBoxSchedulingScheduleEmployees.Checked = permissionsGranted.Contains("schedule_employee_add");
            checkBoxSchedulingUnscheduleEmployees.Checked = permissionsGranted.Contains("schedule_employee_remove");
            checkBoxSchedulingShiftCapacity.Checked = permissionsGranted.Contains("schedule_capacity_set");

            // Swapping
            checkBoxSwappingAccept.Checked = permissionsGranted.Contains("swapping_accept");
            checkBoxSwappingRequest.Checked = permissionsGranted.Contains("swapping_request");
            checkBoxSwappingApprove.Checked = permissionsGranted.Contains("swapping_approve");

            // Statistics
            checkBoxStatisticsView.Checked = permissionsGranted.Contains("statistics_view");
        }

        /// <summary>
        /// Saves the permission values.
        /// </summary>
        private void Save()
        {
            Dictionary<string, bool> updatedPermissions = new Dictionary<string, bool>();


            // General
            updatedPermissions.Add("login_application", checkBoxGeneralLoginApplication.Checked);
            updatedPermissions.Add("login_website", checkBoxGeneralLoginWebsite.Checked);
            updatedPermissions.Add("clock_in_out", checkBoxGeneralClockInOut.Checked);

            // Employee management
            updatedPermissions.Add("employee_view", checkBoxEmployeesView.Checked);
            updatedPermissions.Add("employee_edit", checkBoxEmployeesEdit.Checked);
            updatedPermissions.Add("employee_add", checkBoxEmployeesAdd.Checked);
            updatedPermissions.Add("employee_change_active", checkBoxEmployeesActive.Checked);

            // Stock management
            updatedPermissions.Add("product_view", checkBoxProductsView.Checked);
            updatedPermissions.Add("product_edit", checkBoxProductsEdit.Checked);
            updatedPermissions.Add("product_add", checkBoxProductsAdd.Checked);
            updatedPermissions.Add("product_change_active", checkBoxProductsActive.Checked);
            updatedPermissions.Add("product_restock_file", checkBoxProductsRestockFile.Checked);
            updatedPermissions.Add("product_restock_accept", checkBoxProductsRestockAccept.Checked);

            // Department management
            updatedPermissions.Add("department_view", checkBoxDepartmentsView.Checked);
            updatedPermissions.Add("department_edit", checkBoxDepartmentsEdit.Checked);
            updatedPermissions.Add("department_add", checkBoxDepartmentsAdd.Checked);
            updatedPermissions.Add("department_change_active", checkBoxDepartmentsChangeActive.Checked);

            // Function management
            updatedPermissions.Add("function_add", checkBoxFunctionsAdd.Checked);
            updatedPermissions.Add("function_edit", checkBoxFunctionsEdit.Checked);

            // Scheduling
            updatedPermissions.Add("schedule_employee_add", checkBoxSchedulingScheduleEmployees.Checked);
            updatedPermissions.Add("schedule_employee_remove", checkBoxSchedulingUnscheduleEmployees.Checked);
            updatedPermissions.Add("schedule_capacity_set", checkBoxSchedulingShiftCapacity.Checked);

            // Swapping
            updatedPermissions.Add("swapping_accept", checkBoxSwappingAccept.Checked);
            updatedPermissions.Add("swapping_request", checkBoxSwappingRequest.Checked);
            updatedPermissions.Add("swapping_approve", checkBoxSwappingApprove.Checked);

            // Statistics
            updatedPermissions.Add("statistics_view", checkBoxStatisticsView.Checked);


            bool success = functionStorage.Update(selectedFunctionId, updatedPermissions);

            if (success)
            {
                IndicateSuccessfulSave();
            }
            else
            {
                ErrorMessages.DatabaseSave();
            }
        }

        /// <summary>
        /// Can enable/disable all checkboxes in the form.
        /// </summary>
        /// <param name="isEnabled">if set to <c>true</c> [is enabled].</param>
        private void AreCheckboxesEnabled(bool isEnabled)
        {
            foreach (GroupBox gb in flowLayoutPanel.Controls)
            {
                gb.Enabled = isEnabled;

                foreach (FlowLayoutPanel flp in gb.Controls)
                {
                    foreach (CheckBox cb in flp.Controls)
                    {
                        cb.Enabled = isEnabled;
                    }
                }
            }
        }

        /// <summary>
        /// Prevents the manager from being locked out.
        /// </summary>
        /// <param name="isManager">if set to <c>true</c> [is manager].</param>
        private void PreventManagerLockout(bool isManager)
        {
            if (isManager)
            {
                checkBoxFunctionsEdit.Checked = true;
                checkBoxFunctionsEdit.Enabled = false;
                checkBoxFunctionsAdd.Checked = true;
                checkBoxFunctionsAdd.Enabled = false;
                checkBoxGeneralLoginApplication.Checked = true;
                checkBoxGeneralLoginApplication.Enabled = false;
                checkBoxEmployeesView.Checked = true;
                checkBoxEmployeesView.Enabled = false;
            }
            else
            {
                checkBoxFunctionsEdit.Enabled = true;
                checkBoxFunctionsAdd.Enabled = true;
                checkBoxGeneralLoginApplication.Enabled = true;
                checkBoxEmployeesView.Enabled = true;
            }
        }

        /// <summary>
        /// Sets the height of the groupboxes uniform to be the same as the greatest height found amongst all of them.
        /// <para>This is so it looks nice when tiled in more than 1 column.</para>
        /// </summary>
        private void SetUniformHeight()
        {
            int maxHeightFound = 0;

            foreach (Control c in flowLayoutPanel.Controls)
            {
                if (c is GroupBox && c.Height > maxHeightFound)
                {
                    maxHeightFound = c.Height;
                }
            }

            if (maxHeightFound != 0)
            {
                foreach (Control c in flowLayoutPanel.Controls)
                {
                    if (c is GroupBox)
                    {
                        ((GroupBox)c).AutoSize = false;
                        c.Height = maxHeightFound;
                    }
                }
            }
        }

        /// <summary>
        /// Indicates the successful save to the user.
        /// </summary>
        private async void IndicateSuccessfulSave()
        {
            labelSaveSuccessful.Visible = true;
            await Task.Delay(1500);
            labelSaveSuccessful.Visible = false;
        }

        /// <summary>
        /// Every time the size of the flowLayoutPanel is updated, it checks if the width is smaller than necessary for it to tile two controls next to each other.
        /// <para>When that's the case, the extra blank space in some controls is removed.</para>
        /// <para>When it's wide enough again to also tile horizontally, the blank space is added again.</para>
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            if (flowLayoutPanel.Width <= 478)
            {
                foreach (Control c in flowLayoutPanel.Controls)
                {
                    if (c is GroupBox)
                    {
                        ((GroupBox)c).AutoSize = true;
                    }
                }
            }
            else
            {
                foreach (Control c in flowLayoutPanel.Controls)
                {
                    if (c is GroupBox)
                    {
                        ((GroupBox)c).AutoSize = false;
                    }
                }
                SetUniformHeight();
            }
        }

        /// <summary>
        /// Creates the CheckBox changed event handlers.
        /// </summary>
        private void CreateCheckBoxChangedEventHandlers()
        {
            foreach (GroupBox gb in flowLayoutPanel.Controls)
            {
                foreach (FlowLayoutPanel flp in gb.Controls)
                {
                    foreach (CheckBox cb in flp.Controls)
                    {
                        cb.CheckedChanged += new System.EventHandler(ChangesMade);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the unsavedChanges bool once changes are made.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ChangesMade(object sender, EventArgs e)
        {
            unsavedChanges = true;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboBoxCurrentFunction control.
        /// 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboBoxCurrentFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Autosave permissions when function selection is changed
            if (unsavedChanges)
            {
                Save();
            }

            if (comboBoxCurrentFunction.SelectedIndex == -1)
            {
                AreCheckboxesEnabled(false);
            }
            else
            {
                AreCheckboxesEnabled(true);
            }

            foreach (KeyValuePair<int, string> i in functions)
            {
                if (comboBoxCurrentFunction.SelectedItem.ToString() == i.Value)
                {
                    selectedFunctionId = i.Key;
                }
            }

            Text = "Currently editing permissions for: " + comboBoxCurrentFunction.SelectedItem.ToString();
            LoadPermissions(selectedFunctionId);
            FillCheckboxes();

            if (comboBoxCurrentFunction.SelectedItem.ToString() == "Manager")
            {
                PreventManagerLockout(true);
            }
            else
            {
                PreventManagerLockout(false);
            }

            unsavedChanges = false;
        }

        private void buttonAddNewFunction_Click(object sender, EventArgs e)
        {
            addNewFunctionWindow = new AddNewFunctionWindow();

            if (addNewFunctionWindow.ShowDialog() == DialogResult.OK)
            {
                PopulateComboBox();
                comboBoxCurrentFunction.SelectedItem = addNewFunctionWindow.Title;
                foreach (KeyValuePair<int, string> i in functions)
                {
                    if (comboBoxCurrentFunction.SelectedItem.ToString() == i.Value)
                    {
                        selectedFunctionId = i.Key;
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
            if (checkBoxCloseOnSave.Checked)
            {
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (unsavedChanges)
            {
                DialogResult requestToSave = MessageBox.Show("Some changes you've made aren't saved yet.\nDo you want to save?", "Unsaved changes", MessageBoxButtons.YesNo);
                if (requestToSave == DialogResult.Yes)
                {
                    Save();
                }
            }
            Close();
        }
    }
}