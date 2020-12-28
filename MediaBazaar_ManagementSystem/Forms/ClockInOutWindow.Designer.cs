namespace MediaBazaar_ManagementSystem.Forms
{
    partial class ClockInOutWindow
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
            this.lblCI = new System.Windows.Forms.Label();
            this.lblCO = new System.Windows.Forms.Label();
            this.dtpClockIn = new System.Windows.Forms.DateTimePicker();
            this.dtpClockOut = new System.Windows.Forms.DateTimePicker();
            this.lbl = new System.Windows.Forms.Label();
            this.cmbxEmployee = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClockIn = new System.Windows.Forms.Button();
            this.btnClockOut = new System.Windows.Forms.Button();
            this.chbxForceShift = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbxDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCI
            // 
            this.lblCI.AutoSize = true;
            this.lblCI.Location = new System.Drawing.Point(10, 111);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(48, 13);
            this.lblCI.TabIndex = 2;
            this.lblCI.Text = "Clock in:";
            // 
            // lblCO
            // 
            this.lblCO.AutoSize = true;
            this.lblCO.Location = new System.Drawing.Point(237, 114);
            this.lblCO.Name = "lblCO";
            this.lblCO.Size = new System.Drawing.Size(55, 13);
            this.lblCO.TabIndex = 4;
            this.lblCO.Text = "Clock out:";
            // 
            // dtpClockIn
            // 
            this.dtpClockIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpClockIn.Location = new System.Drawing.Point(64, 108);
            this.dtpClockIn.Name = "dtpClockIn";
            this.dtpClockIn.Size = new System.Drawing.Size(152, 20);
            this.dtpClockIn.TabIndex = 5;
            this.dtpClockIn.Value = new System.DateTime(2020, 12, 27, 21, 48, 31, 0);
            // 
            // dtpClockOut
            // 
            this.dtpClockOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpClockOut.Location = new System.Drawing.Point(290, 111);
            this.dtpClockOut.Name = "dtpClockOut";
            this.dtpClockOut.Size = new System.Drawing.Size(149, 20);
            this.dtpClockOut.TabIndex = 6;
            this.dtpClockOut.Value = new System.DateTime(2020, 12, 27, 21, 48, 46, 0);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(2, 15);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(56, 13);
            this.lbl.TabIndex = 7;
            this.lbl.Text = "Employee:";
            // 
            // cmbxEmployee
            // 
            this.cmbxEmployee.FormattingEnabled = true;
            this.cmbxEmployee.Location = new System.Drawing.Point(64, 12);
            this.cmbxEmployee.Name = "cmbxEmployee";
            this.cmbxEmployee.Size = new System.Drawing.Size(152, 21);
            this.cmbxEmployee.TabIndex = 8;
            this.cmbxEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbxEmployee_SelectedIndexChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(290, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(149, 20);
            this.dtpDate.TabIndex = 10;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Date:";
            // 
            // cmbShift
            // 
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(41, 57);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(112, 21);
            this.cmbShift.TabIndex = 12;
            this.cmbShift.SelectedIndexChanged += new System.EventHandler(this.cmbShift_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Shift:";
            // 
            // btnClockIn
            // 
            this.btnClockIn.Location = new System.Drawing.Point(89, 144);
            this.btnClockIn.Name = "btnClockIn";
            this.btnClockIn.Size = new System.Drawing.Size(75, 23);
            this.btnClockIn.TabIndex = 13;
            this.btnClockIn.Text = "Clock in";
            this.btnClockIn.UseVisualStyleBackColor = true;
            this.btnClockIn.Click += new System.EventHandler(this.btnClockIn_Click);
            // 
            // btnClockOut
            // 
            this.btnClockOut.Location = new System.Drawing.Point(315, 147);
            this.btnClockOut.Name = "btnClockOut";
            this.btnClockOut.Size = new System.Drawing.Size(75, 23);
            this.btnClockOut.TabIndex = 14;
            this.btnClockOut.Text = "Clock out";
            this.btnClockOut.UseVisualStyleBackColor = true;
            this.btnClockOut.Click += new System.EventHandler(this.btnClockOut_Click);
            // 
            // chbxForceShift
            // 
            this.chbxForceShift.AutoSize = true;
            this.chbxForceShift.Location = new System.Drawing.Point(159, 61);
            this.chbxForceShift.Name = "chbxForceShift";
            this.chbxForceShift.Size = new System.Drawing.Size(84, 17);
            this.chbxForceShift.TabIndex = 15;
            this.chbxForceShift.Text = "Force a shift";
            this.chbxForceShift.UseVisualStyleBackColor = true;
            this.chbxForceShift.CheckedChanged += new System.EventHandler(this.chbxForceShift_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(364, 179);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 34;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // cmbxDepartment
            // 
            this.cmbxDepartment.FormattingEnabled = true;
            this.cmbxDepartment.Location = new System.Drawing.Point(318, 58);
            this.cmbxDepartment.Name = "cmbxDepartment";
            this.cmbxDepartment.Size = new System.Drawing.Size(121, 21);
            this.cmbxDepartment.TabIndex = 35;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(253, 62);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 13);
            this.lblDepartment.TabIndex = 36;
            this.lblDepartment.Text = "Department:";
            // 
            // ClockInOutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 210);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbxDepartment);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.chbxForceShift);
            this.Controls.Add(this.btnClockOut);
            this.Controls.Add(this.btnClockIn);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxEmployee);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dtpClockOut);
            this.Controls.Add(this.dtpClockIn);
            this.Controls.Add(this.lblCO);
            this.Controls.Add(this.lblCI);
            this.Name = "ClockInOutWindow";
            this.Text = "Clock in/out";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCI;
        private System.Windows.Forms.Label lblCO;
        private System.Windows.Forms.DateTimePicker dtpClockIn;
        private System.Windows.Forms.DateTimePicker dtpClockOut;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cmbxEmployee;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClockIn;
        private System.Windows.Forms.Button btnClockOut;
        private System.Windows.Forms.CheckBox chbxForceShift;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbxDepartment;
        private System.Windows.Forms.Label lblDepartment;
    }
}