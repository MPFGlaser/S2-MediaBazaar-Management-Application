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
            this.labelCalendarDate = new System.Windows.Forms.Label();
            this.labelCalendarDay = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonEvening = new System.Windows.Forms.Button();
            this.buttonMorning = new System.Windows.Forms.Button();
            this.buttonAfternoon = new System.Windows.Forms.Button();
            this.labelCapacityEvening = new System.Windows.Forms.Label();
            this.labelCapacityAfternoon = new System.Windows.Forms.Label();
            this.labelCapacityMorning = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.labelCalendarDate);
            this.splitContainer1.Panel1.Controls.Add(this.labelCalendarDay);
            this.splitContainer1.Panel1MinSize = 90;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(155, 230);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 0;
            // 
            // labelCalendarDate
            // 
            this.labelCalendarDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelCalendarDate.Location = new System.Drawing.Point(-1, 51);
            this.labelCalendarDate.Name = "labelCalendarDate";
            this.labelCalendarDate.Size = new System.Drawing.Size(157, 39);
            this.labelCalendarDate.TabIndex = 4;
            this.labelCalendarDate.Text = "September 2";
            this.labelCalendarDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCalendarDay
            // 
            this.labelCalendarDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelCalendarDay.Location = new System.Drawing.Point(-1, 12);
            this.labelCalendarDay.Name = "labelCalendarDay";
            this.labelCalendarDay.Size = new System.Drawing.Size(157, 39);
            this.labelCalendarDay.TabIndex = 3;
            this.labelCalendarDay.Text = "Wednesday";
            this.labelCalendarDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.buttonEvening);
            this.splitContainer2.Panel1.Controls.Add(this.buttonMorning);
            this.splitContainer2.Panel1.Controls.Add(this.buttonAfternoon);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.labelCapacityEvening);
            this.splitContainer2.Panel2.Controls.Add(this.labelCapacityAfternoon);
            this.splitContainer2.Panel2.Controls.Add(this.labelCapacityMorning);
            this.splitContainer2.Panel2MinSize = 50;
            this.splitContainer2.Size = new System.Drawing.Size(155, 136);
            this.splitContainer2.SplitterDistance = 101;
            this.splitContainer2.TabIndex = 6;
            // 
            // buttonEvening
            // 
            this.buttonEvening.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEvening.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonEvening.Location = new System.Drawing.Point(3, 89);
            this.buttonEvening.Name = "buttonEvening";
            this.buttonEvening.Size = new System.Drawing.Size(99, 40);
            this.buttonEvening.TabIndex = 2;
            this.buttonEvening.Text = "Evening\r\n(17:00 - 21:30)";
            this.buttonEvening.UseVisualStyleBackColor = true;
            this.buttonEvening.Click += new System.EventHandler(this.buttonEvening_Click);
            // 
            // buttonMorning
            // 
            this.buttonMorning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMorning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonMorning.Location = new System.Drawing.Point(3, 3);
            this.buttonMorning.Name = "buttonMorning";
            this.buttonMorning.Size = new System.Drawing.Size(99, 40);
            this.buttonMorning.TabIndex = 0;
            this.buttonMorning.Text = "Morning\r\n(8:00 - 12:30)";
            this.buttonMorning.UseVisualStyleBackColor = true;
            this.buttonMorning.Click += new System.EventHandler(this.buttonMorning_Click);
            // 
            // buttonAfternoon
            // 
            this.buttonAfternoon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAfternoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonAfternoon.Location = new System.Drawing.Point(3, 46);
            this.buttonAfternoon.Name = "buttonAfternoon";
            this.buttonAfternoon.Size = new System.Drawing.Size(99, 40);
            this.buttonAfternoon.TabIndex = 1;
            this.buttonAfternoon.Text = "Afternoon\r\n(12:30 - 17:00)";
            this.buttonAfternoon.UseVisualStyleBackColor = true;
            this.buttonAfternoon.Click += new System.EventHandler(this.buttonAfternoon_Click);
            // 
            // labelCapacityEvening
            // 
            this.labelCapacityEvening.BackColor = System.Drawing.Color.LightCoral;
            this.labelCapacityEvening.Location = new System.Drawing.Point(3, 98);
            this.labelCapacityEvening.Name = "labelCapacityEvening";
            this.labelCapacityEvening.Size = new System.Drawing.Size(44, 24);
            this.labelCapacityEvening.TabIndex = 8;
            this.labelCapacityEvening.Text = "N/A";
            this.labelCapacityEvening.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCapacityAfternoon
            // 
            this.labelCapacityAfternoon.BackColor = System.Drawing.Color.LightCoral;
            this.labelCapacityAfternoon.Location = new System.Drawing.Point(3, 55);
            this.labelCapacityAfternoon.Name = "labelCapacityAfternoon";
            this.labelCapacityAfternoon.Size = new System.Drawing.Size(44, 24);
            this.labelCapacityAfternoon.TabIndex = 7;
            this.labelCapacityAfternoon.Text = "N/A";
            this.labelCapacityAfternoon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCapacityMorning
            // 
            this.labelCapacityMorning.BackColor = System.Drawing.Color.LightCoral;
            this.labelCapacityMorning.Location = new System.Drawing.Point(3, 12);
            this.labelCapacityMorning.Name = "labelCapacityMorning";
            this.labelCapacityMorning.Size = new System.Drawing.Size(44, 24);
            this.labelCapacityMorning.TabIndex = 6;
            this.labelCapacityMorning.Text = "N/A";
            this.labelCapacityMorning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(155, 230);
            this.Name = "CalendarDayControl";
            this.Size = new System.Drawing.Size(155, 230);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonEvening;
        private System.Windows.Forms.Button buttonAfternoon;
        private System.Windows.Forms.Button buttonMorning;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label labelCapacityEvening;
        private System.Windows.Forms.Label labelCapacityAfternoon;
        private System.Windows.Forms.Label labelCapacityMorning;
        private System.Windows.Forms.Label labelCalendarDate;
        private System.Windows.Forms.Label labelCalendarDay;
    }
}
