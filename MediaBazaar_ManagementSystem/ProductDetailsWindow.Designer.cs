namespace MediaBazaar_ManagementSystem
{
    partial class ProductDetailsWindow
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
            this.buttonPDWCancel = new System.Windows.Forms.Button();
            this.buttonPDWConfirm = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPDWCancel
            // 
            this.buttonPDWCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonPDWCancel.Location = new System.Drawing.Point(12, 476);
            this.buttonPDWCancel.Name = "buttonPDWCancel";
            this.buttonPDWCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonPDWCancel.TabIndex = 10;
            this.buttonPDWCancel.Text = "Cancel";
            this.buttonPDWCancel.UseVisualStyleBackColor = true;
            this.buttonPDWCancel.Click += new System.EventHandler(this.buttonPDWCancel_Click);
            // 
            // buttonPDWConfirm
            // 
            this.buttonPDWConfirm.Location = new System.Drawing.Point(347, 476);
            this.buttonPDWConfirm.Name = "buttonPDWConfirm";
            this.buttonPDWConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonPDWConfirm.TabIndex = 9;
            this.buttonPDWConfirm.Text = "Confirm";
            this.buttonPDWConfirm.UseVisualStyleBackColor = true;
            this.buttonPDWConfirm.Click += new System.EventHandler(this.buttonPDWConfirm_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(11, 62);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(411, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Location = new System.Drawing.Point(11, 101);
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(411, 20);
            this.textBoxBrand.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Brand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Code";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(11, 140);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(411, 20);
            this.textBoxCode.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Category";
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(11, 179);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.PasswordChar = '•';
            this.textBoxCategory.Size = new System.Drawing.Size(411, 20);
            this.textBoxCategory.TabIndex = 7;
            this.textBoxCategory.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(367, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "ID";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(391, 7);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(31, 13);
            this.labelID.TabIndex = 15;
            this.labelID.Text = "1337";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Quantity in stock";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Description";
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.DecimalPlaces = 2;
            this.numericUpDownPrice.Location = new System.Drawing.Point(11, 23);
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPrice.TabIndex = 1;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(161, 23);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQuantity.TabIndex = 2;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.Location = new System.Drawing.Point(299, 26);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(62, 17);
            this.checkBoxActive.TabIndex = 3;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(11, 219);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(411, 251);
            this.richTextBoxDescription.TabIndex = 8;
            this.richTextBoxDescription.Text = "";
            // 
            // ProductDetailsWindow
            // 
            this.AcceptButton = this.buttonPDWConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonPDWCancel;
            this.ClientSize = new System.Drawing.Size(434, 511);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.numericUpDownPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxBrand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonPDWConfirm);
            this.Controls.Add(this.buttonPDWCancel);
            this.Name = "ProductDetailsWindow";
            this.Text = "Add a product";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPDWCancel;
        private System.Windows.Forms.Button buttonPDWConfirm;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
    }
}