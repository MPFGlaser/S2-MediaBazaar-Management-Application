namespace MediaBazaar_ManagementSystem
{
    partial class CalendarDayControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxCalendarDate = new System.Windows.Forms.TextBox();
            this.textBoxCalendarDay = new System.Windows.Forms.TextBox();
            this.textBoxCapacityEvening = new System.Windows.Forms.TextBox();
            this.textBoxCapacityAfternoon = new System.Windows.Forms.TextBox();
            this.textBoxCapacityMorning = new System.Windows.Forms.TextBox();
            this.buttonEvening = new System.Windows.Forms.Button();
            this.buttonAfternoon = new System.Windows.Forms.Button();
            this.buttonMorning = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxCalendarDate);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxCalendarDay);
            this.splitContainer1.Panel1MinSize = 90;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxCapacityEvening);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxCapacityAfternoon);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxCapacityMorning);
            this.splitContainer1.Panel2.Controls.Add(this.buttonEvening);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAfternoon);
            this.splitContainer1.Panel2.Controls.Add(this.buttonMorning);
            this.splitContainer1.Size = new System.Drawing.Size(264, 228);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBoxCalendarDate
            // 
            this.textBoxCalendarDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCalendarDate.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCalendarDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCalendarDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxCalendarDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCalendarDate.Location = new System.Drawing.Point(3, 46);
            this.textBoxCalendarDate.Name = "textBoxCalendarDate";
            this.textBoxCalendarDate.ReadOnly = true;
            this.textBoxCalendarDate.Size = new System.Drawing.Size(258, 37);
            this.textBoxCalendarDate.TabIndex = 2;
            this.textBoxCalendarDate.Text = "September 2";
            this.textBoxCalendarDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCalendarDay
            // 
            this.textBoxCalendarDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCalendarDay.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCalendarDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCalendarDay.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxCalendarDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCalendarDay.Location = new System.Drawing.Point(3, 3);
            this.textBoxCalendarDay.Name = "textBoxCalendarDay";
            this.textBoxCalendarDay.ReadOnly = true;
            this.textBoxCalendarDay.Size = new System.Drawing.Size(258, 37);
            this.textBoxCalendarDay.TabIndex = 1;
            this.textBoxCalendarDay.Text = "Wednesday";
            this.textBoxCalendarDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCapacityEvening
            // 
            this.textBoxCapacityEvening.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCapacityEvening.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCapacityEvening.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCapacityEvening.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxCapacityEvening.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxCapacityEvening.Location = new System.Drawing.Point(196, 104);
            this.textBoxCapacityEvening.Name = "textBoxCapacityEvening";
            this.textBoxCapacityEvening.ReadOnly = true;
            this.textBoxCapacityEvening.Size = new System.Drawing.Size(65, 16);
            this.textBoxCapacityEvening.TabIndex = 5;
            this.textBoxCapacityEvening.Text = "11/15";
            this.textBoxCapacityEvening.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCapacityAfternoon
            // 
            this.textBoxCapacityAfternoon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCapacityAfternoon.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCapacityAfternoon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCapacityAfternoon.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxCapacityAfternoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxCapacityAfternoon.Location = new System.Drawing.Point(196, 59);
            this.textBoxCapacityAfternoon.Name = "textBoxCapacityAfternoon";
            this.textBoxCapacityAfternoon.ReadOnly = true;
            this.textBoxCapacityAfternoon.Size = new System.Drawing.Size(65, 16);
            this.textBoxCapacityAfternoon.TabIndex = 4;
            this.textBoxCapacityAfternoon.Text = "20/20";
            this.textBoxCapacityAfternoon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCapacityMorning
            // 
            this.textBoxCapacityMorning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCapacityMorning.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCapacityMorning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCapacityMorning.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxCapacityMorning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxCapacityMorning.Location = new System.Drawing.Point(196, 14);
            this.textBoxCapacityMorning.Name = "textBoxCapacityMorning";
            this.textBoxCapacityMorning.ReadOnly = true;
            this.textBoxCapacityMorning.Size = new System.Drawing.Size(65, 16);
            this.textBoxCapacityMorning.TabIndex = 3;
            this.textBoxCapacityMorning.Text = "09/15";
            this.textBoxCapacityMorning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonEvening
            // 
            this.buttonEvening.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonEvening.Location = new System.Drawing.Point(3, 93);
            this.buttonEvening.Name = "buttonEvening";
            this.buttonEvening.Size = new System.Drawing.Size(187, 39);
            this.buttonEvening.TabIndex = 2;
            this.buttonEvening.Text = "Evening (17:00 - 21:30)";
            this.buttonEvening.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEvening.UseVisualStyleBackColor = true;
            // 
            // buttonAfternoon
            // 
            this.buttonAfternoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAfternoon.Location = new System.Drawing.Point(3, 48);
            this.buttonAfternoon.Name = "buttonAfternoon";
            this.buttonAfternoon.Size = new System.Drawing.Size(187, 39);
            this.buttonAfternoon.TabIndex = 1;
            this.buttonAfternoon.Text = "Afternoon (12:30 - 17:00)";
            this.buttonAfternoon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAfternoon.UseVisualStyleBackColor = true;
            // 
            // buttonMorning
            // 
            this.buttonMorning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonMorning.Location = new System.Drawing.Point(3, 3);
            this.buttonMorning.Name = "buttonMorning";
            this.buttonMorning.Size = new System.Drawing.Size(187, 39);
            this.buttonMorning.TabIndex = 0;
            this.buttonMorning.Text = "Morning (8:00 - 12:30)";
            this.buttonMorning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMorning.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // CalendarDayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CalendarDayControl";
            this.Size = new System.Drawing.Size(264, 228);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxCalendarDate;
        private System.Windows.Forms.TextBox textBoxCalendarDay;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonEvening;
        private System.Windows.Forms.Button buttonAfternoon;
        private System.Windows.Forms.Button buttonMorning;
        private System.Windows.Forms.TextBox textBoxCapacityEvening;
        private System.Windows.Forms.TextBox textBoxCapacityAfternoon;
        private System.Windows.Forms.TextBox textBoxCapacityMorning;
    }
}
