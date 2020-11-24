namespace MediaBazaar_ManagementSystem.Forms
{
    partial class ProductRestockDetailsWindow
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
            this.lblID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProductCategory = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSendrequest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudqRestockQuantity = new System.Windows.Forms.NumericUpDown();
            this.tbCurrentStock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudqRestockQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(196, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(29, 13);
            this.lblID.TabIndex = 36;
            this.lblID.Text = "TBD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Quantity to restock:";
            // 
            // lblProductCategory
            // 
            this.lblProductCategory.AutoSize = true;
            this.lblProductCategory.Location = new System.Drawing.Point(49, 35);
            this.lblProductCategory.Name = "lblProductCategory";
            this.lblProductCategory.Size = new System.Drawing.Size(29, 13);
            this.lblProductCategory.TabIndex = 34;
            this.lblProductCategory.Text = "TBD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Category:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(73, 9);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(29, 13);
            this.lblProductName.TabIndex = 32;
            this.lblProductName.Text = "TBD";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(2, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(76, 13);
            this.lbl1.TabIndex = 31;
            this.lbl1.Text = "Product name:";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(178, 35);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(29, 13);
            this.lblProductCode.TabIndex = 30;
            this.lblProductCode.Text = "TBD";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "ID:";
            // 
            // btnSendrequest
            // 
            this.btnSendrequest.Location = new System.Drawing.Point(51, 218);
            this.btnSendrequest.Name = "btnSendrequest";
            this.btnSendrequest.Size = new System.Drawing.Size(111, 23);
            this.btnSendrequest.TabIndex = 28;
            this.btnSendrequest.Text = "File restock request";
            this.btnSendrequest.UseVisualStyleBackColor = true;
            this.btnSendrequest.Click += new System.EventHandler(this.btnSendrequest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Product code:";
            // 
            // nudqRestockQuantity
            // 
            this.nudqRestockQuantity.Location = new System.Drawing.Point(52, 157);
            this.nudqRestockQuantity.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudqRestockQuantity.Name = "nudqRestockQuantity";
            this.nudqRestockQuantity.Size = new System.Drawing.Size(110, 20);
            this.nudqRestockQuantity.TabIndex = 26;
            // 
            // tbCurrentStock
            // 
            this.tbCurrentStock.Enabled = false;
            this.tbCurrentStock.Location = new System.Drawing.Point(51, 86);
            this.tbCurrentStock.Name = "tbCurrentStock";
            this.tbCurrentStock.Size = new System.Drawing.Size(111, 20);
            this.tbCurrentStock.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Current stock quantity:";
            // 
            // ProductRestockDetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 270);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblProductCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSendrequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudqRestockQuantity);
            this.Controls.Add(this.tbCurrentStock);
            this.Controls.Add(this.label1);
            this.Name = "ProductRestockDetailsWindow";
            this.Text = "ProductRestockDetailsWindow";
            ((System.ComponentModel.ISupportInitialize)(this.nudqRestockQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProductCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSendrequest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudqRestockQuantity;
        private System.Windows.Forms.TextBox tbCurrentStock;
        private System.Windows.Forms.Label label1;
    }
}