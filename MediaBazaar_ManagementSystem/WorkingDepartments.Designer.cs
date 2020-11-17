
namespace MediaBazaar_ManagementSystem
{
    partial class WorkingDepartments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSelectDepartments = new System.Windows.Forms.ComboBox();
            this.buttonWorkingDepartmentsConfirm = new System.Windows.Forms.Button();
            this.buttonWorkingDepartmentsCancel = new System.Windows.Forms.Button();
            this.listBoxCurrentWorkingDepartments = new System.Windows.Forms.ListBox();
            this.buttonRemoveDepartmentFromEmployee = new System.Windows.Forms.Button();
            this.buttonAddDepartmentToEmployee = new System.Windows.Forms.Button();
            this.comboBoxShiftTime = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxSelectDepartments
            // 
            this.comboBoxSelectDepartments.FormattingEnabled = true;
            this.comboBoxSelectDepartments.Location = new System.Drawing.Point(23, 12);
            this.comboBoxSelectDepartments.Name = "comboBoxSelectDepartments";
            this.comboBoxSelectDepartments.Size = new System.Drawing.Size(186, 21);
            this.comboBoxSelectDepartments.Sorted = true;
            this.comboBoxSelectDepartments.TabIndex = 52;
            this.comboBoxSelectDepartments.Text = "Select a department";
            // 
            // buttonWorkingDepartmentsConfirm
            // 
            this.buttonWorkingDepartmentsConfirm.Location = new System.Drawing.Point(459, 213);
            this.buttonWorkingDepartmentsConfirm.Name = "buttonWorkingDepartmentsConfirm";
            this.buttonWorkingDepartmentsConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonWorkingDepartmentsConfirm.TabIndex = 51;
            this.buttonWorkingDepartmentsConfirm.Text = "Confirm";
            this.buttonWorkingDepartmentsConfirm.UseVisualStyleBackColor = true;
            // 
            // buttonWorkingDepartmentsCancel
            // 
            this.buttonWorkingDepartmentsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonWorkingDepartmentsCancel.Location = new System.Drawing.Point(23, 213);
            this.buttonWorkingDepartmentsCancel.Name = "buttonWorkingDepartmentsCancel";
            this.buttonWorkingDepartmentsCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonWorkingDepartmentsCancel.TabIndex = 50;
            this.buttonWorkingDepartmentsCancel.Text = "Cancel";
            this.buttonWorkingDepartmentsCancel.UseVisualStyleBackColor = true;
            // 
            // listBoxCurrentWorkingDepartments
            // 
            this.listBoxCurrentWorkingDepartments.FormattingEnabled = true;
            this.listBoxCurrentWorkingDepartments.Location = new System.Drawing.Point(244, 12);
            this.listBoxCurrentWorkingDepartments.Name = "listBoxCurrentWorkingDepartments";
            this.listBoxCurrentWorkingDepartments.Size = new System.Drawing.Size(290, 186);
            this.listBoxCurrentWorkingDepartments.Sorted = true;
            this.listBoxCurrentWorkingDepartments.TabIndex = 47;
            // 
            // buttonRemoveDepartmentFromEmployee
            // 
            this.buttonRemoveDepartmentFromEmployee.Location = new System.Drawing.Point(92, 77);
            this.buttonRemoveDepartmentFromEmployee.Name = "buttonRemoveDepartmentFromEmployee";
            this.buttonRemoveDepartmentFromEmployee.Size = new System.Drawing.Size(117, 23);
            this.buttonRemoveDepartmentFromEmployee.TabIndex = 46;
            this.buttonRemoveDepartmentFromEmployee.Text = "Remove Department";
            this.buttonRemoveDepartmentFromEmployee.UseVisualStyleBackColor = true;
            this.buttonRemoveDepartmentFromEmployee.Click += new System.EventHandler(this.buttonRemoveDepartmentFromEmployee_Click);
            // 
            // buttonAddDepartmentToEmployee
            // 
            this.buttonAddDepartmentToEmployee.Location = new System.Drawing.Point(92, 48);
            this.buttonAddDepartmentToEmployee.Name = "buttonAddDepartmentToEmployee";
            this.buttonAddDepartmentToEmployee.Size = new System.Drawing.Size(117, 23);
            this.buttonAddDepartmentToEmployee.TabIndex = 45;
            this.buttonAddDepartmentToEmployee.Text = "Add Department";
            this.buttonAddDepartmentToEmployee.UseVisualStyleBackColor = true;
            this.buttonAddDepartmentToEmployee.Click += new System.EventHandler(this.buttonAddDepartmentToEmployee_Click);
            // 
            // comboBoxShiftTime
            // 
            this.comboBoxShiftTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShiftTime.FormattingEnabled = true;
            this.comboBoxShiftTime.Location = new System.Drawing.Point(457, -32);
            this.comboBoxShiftTime.Name = "comboBoxShiftTime";
            this.comboBoxShiftTime.Size = new System.Drawing.Size(108, 21);
            this.comboBoxShiftTime.TabIndex = 44;
            // 
            // WorkingDepartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 268);
            this.Controls.Add(this.comboBoxSelectDepartments);
            this.Controls.Add(this.buttonWorkingDepartmentsConfirm);
            this.Controls.Add(this.buttonWorkingDepartmentsCancel);
            this.Controls.Add(this.listBoxCurrentWorkingDepartments);
            this.Controls.Add(this.buttonRemoveDepartmentFromEmployee);
            this.Controls.Add(this.buttonAddDepartmentToEmployee);
            this.Controls.Add(this.comboBoxShiftTime);
            this.Name = "WorkingDepartments";
            this.Text = "WorkingDepartments";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelectDepartments;
        private System.Windows.Forms.Button buttonWorkingDepartmentsConfirm;
        private System.Windows.Forms.Button buttonWorkingDepartmentsCancel;
        private System.Windows.Forms.ListBox listBoxCurrentWorkingDepartments;
        private System.Windows.Forms.Button buttonRemoveDepartmentFromEmployee;
        private System.Windows.Forms.Button buttonAddDepartmentToEmployee;
        private System.Windows.Forms.ComboBox comboBoxShiftTime;
    }
}