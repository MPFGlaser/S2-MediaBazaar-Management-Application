﻿namespace MediaBazaar_ManagementSystem
{
    partial class SchedulingWindow
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
            this.textBoxCalendarDate = new System.Windows.Forms.TextBox();
            this.buttonPreviousDay = new System.Windows.Forms.Button();
            this.buttonNextDay = new System.Windows.Forms.Button();
            this.comboBoxShiftTime = new System.Windows.Forms.ComboBox();
            this.comboBoxSelectEmployees = new System.Windows.Forms.ComboBox();
            this.buttonAddEmployeeToShift = new System.Windows.Forms.Button();
            this.buttonRemoveEmployeeFromShift = new System.Windows.Forms.Button();
            this.listBoxCurrentEmployees = new System.Windows.Forms.ListBox();
            this.textBoxWeekDay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxCalendarDate
            // 
            this.textBoxCalendarDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCalendarDate.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCalendarDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCalendarDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxCalendarDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxCalendarDate.Location = new System.Drawing.Point(41, 67);
            this.textBoxCalendarDate.Name = "textBoxCalendarDate";
            this.textBoxCalendarDate.ReadOnly = true;
            this.textBoxCalendarDate.Size = new System.Drawing.Size(186, 23);
            this.textBoxCalendarDate.TabIndex = 36;
            this.textBoxCalendarDate.Text = "January 1";
            this.textBoxCalendarDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonPreviousDay
            // 
            this.buttonPreviousDay.Location = new System.Drawing.Point(41, 96);
            this.buttonPreviousDay.Name = "buttonPreviousDay";
            this.buttonPreviousDay.Size = new System.Drawing.Size(33, 23);
            this.buttonPreviousDay.TabIndex = 4;
            this.buttonPreviousDay.Text = "<";
            this.buttonPreviousDay.UseVisualStyleBackColor = true;
            // 
            // buttonNextDay
            // 
            this.buttonNextDay.Location = new System.Drawing.Point(194, 96);
            this.buttonNextDay.Name = "buttonNextDay";
            this.buttonNextDay.Size = new System.Drawing.Size(33, 23);
            this.buttonNextDay.TabIndex = 5;
            this.buttonNextDay.Text = ">";
            this.buttonNextDay.UseVisualStyleBackColor = true;
            // 
            // comboBoxShiftTime
            // 
            this.comboBoxShiftTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShiftTime.FormattingEnabled = true;
            this.comboBoxShiftTime.Items.AddRange(new object[] {
            "Morning",
            "Afternoon",
            "Evening"});
            this.comboBoxShiftTime.Location = new System.Drawing.Point(249, 38);
            this.comboBoxShiftTime.Name = "comboBoxShiftTime";
            this.comboBoxShiftTime.Size = new System.Drawing.Size(108, 21);
            this.comboBoxShiftTime.TabIndex = 6;
            // 
            // comboBoxSelectEmployees
            // 
            this.comboBoxSelectEmployees.FormattingEnabled = true;
            this.comboBoxSelectEmployees.Location = new System.Drawing.Point(41, 127);
            this.comboBoxSelectEmployees.Name = "comboBoxSelectEmployees";
            this.comboBoxSelectEmployees.Size = new System.Drawing.Size(186, 21);
            this.comboBoxSelectEmployees.Sorted = true;
            this.comboBoxSelectEmployees.TabIndex = 3;
            this.comboBoxSelectEmployees.Text = "Select an employee";
            // 
            // buttonAddEmployeeToShift
            // 
            this.buttonAddEmployeeToShift.Location = new System.Drawing.Point(249, 127);
            this.buttonAddEmployeeToShift.Name = "buttonAddEmployeeToShift";
            this.buttonAddEmployeeToShift.Size = new System.Drawing.Size(108, 23);
            this.buttonAddEmployeeToShift.TabIndex = 8;
            this.buttonAddEmployeeToShift.Text = "Add Employee";
            this.buttonAddEmployeeToShift.UseVisualStyleBackColor = true;
            this.buttonAddEmployeeToShift.Click += new System.EventHandler(this.buttonAddEmployeeToShift_Click);
            // 
            // buttonRemoveEmployeeFromShift
            // 
            this.buttonRemoveEmployeeFromShift.Location = new System.Drawing.Point(249, 170);
            this.buttonRemoveEmployeeFromShift.Name = "buttonRemoveEmployeeFromShift";
            this.buttonRemoveEmployeeFromShift.Size = new System.Drawing.Size(108, 23);
            this.buttonRemoveEmployeeFromShift.TabIndex = 9;
            this.buttonRemoveEmployeeFromShift.Text = "Remove Employee";
            this.buttonRemoveEmployeeFromShift.UseVisualStyleBackColor = true;
            this.buttonRemoveEmployeeFromShift.Click += new System.EventHandler(this.buttonRemoveEmployeeFromShift_Click);
            // 
            // listBoxCurrentEmployees
            // 
            this.listBoxCurrentEmployees.FormattingEnabled = true;
            this.listBoxCurrentEmployees.Location = new System.Drawing.Point(445, 127);
            this.listBoxCurrentEmployees.Name = "listBoxCurrentEmployees";
            this.listBoxCurrentEmployees.Size = new System.Drawing.Size(290, 251);
            this.listBoxCurrentEmployees.Sorted = true;
            this.listBoxCurrentEmployees.TabIndex = 10;
            // 
            // textBoxWeekDay
            // 
            this.textBoxWeekDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWeekDay.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxWeekDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWeekDay.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxWeekDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxWeekDay.Location = new System.Drawing.Point(41, 38);
            this.textBoxWeekDay.Name = "textBoxWeekDay";
            this.textBoxWeekDay.ReadOnly = true;
            this.textBoxWeekDay.Size = new System.Drawing.Size(186, 23);
            this.textBoxWeekDay.TabIndex = 37;
            this.textBoxWeekDay.Text = "Monday";
            this.textBoxWeekDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SchedulingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxWeekDay);
            this.Controls.Add(this.listBoxCurrentEmployees);
            this.Controls.Add(this.buttonRemoveEmployeeFromShift);
            this.Controls.Add(this.buttonAddEmployeeToShift);
            this.Controls.Add(this.comboBoxSelectEmployees);
            this.Controls.Add(this.comboBoxShiftTime);
            this.Controls.Add(this.buttonNextDay);
            this.Controls.Add(this.buttonPreviousDay);
            this.Controls.Add(this.textBoxCalendarDate);
            this.Name = "SchedulingWindow";
            this.Text = "SchedulingWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCalendarDate;
        private System.Windows.Forms.Button buttonPreviousDay;
        private System.Windows.Forms.Button buttonNextDay;
        private System.Windows.Forms.ComboBox comboBoxShiftTime;
        private System.Windows.Forms.ComboBox comboBoxSelectEmployees;
        private System.Windows.Forms.Button buttonAddEmployeeToShift;
        private System.Windows.Forms.Button buttonRemoveEmployeeFromShift;
        private System.Windows.Forms.ListBox listBoxCurrentEmployees;
        private System.Windows.Forms.TextBox textBoxWeekDay;
    }
}