namespace MediaBazaar_ManagementSystem
{
    partial class MainWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainerEmployeesPrimary = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.employeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeFunction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeePhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerEmployeesSecondary = new System.Windows.Forms.SplitContainer();
            this.buttonEmployeesDepartmentRemove = new System.Windows.Forms.Button();
            this.buttonEmployeesDepartmentAdd = new System.Windows.Forms.Button();
            this.textBoxEmployeesDepartmentName = new System.Windows.Forms.TextBox();
            this.labelEmployeesDepartmentName = new System.Windows.Forms.Label();
            this.listBoxEmployeesSelected = new System.Windows.Forms.ListBox();
            this.labelEmployeesSelected = new System.Windows.Forms.Label();
            this.buttonEmployeesAdd = new System.Windows.Forms.Button();
            this.buttonEmployeesRemove = new System.Windows.Forms.Button();
            this.buttonEmployeeModify = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonStockAdd = new System.Windows.Forms.Button();
            this.buttonStockEditProduct = new System.Windows.Forms.Button();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelWelcomeText = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEmployeesPrimary)).BeginInit();
            this.splitContainerEmployeesPrimary.Panel1.SuspendLayout();
            this.splitContainerEmployeesPrimary.Panel2.SuspendLayout();
            this.splitContainerEmployeesPrimary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEmployeesSecondary)).BeginInit();
            this.splitContainerEmployeesSecondary.Panel1.SuspendLayout();
            this.splitContainerEmployeesSecondary.Panel2.SuspendLayout();
            this.splitContainerEmployeesSecondary.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainerEmployeesPrimary);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainerEmployeesPrimary
            // 
            this.splitContainerEmployeesPrimary.BackColor = System.Drawing.Color.LightGray;
            this.splitContainerEmployeesPrimary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEmployeesPrimary.Location = new System.Drawing.Point(3, 3);
            this.splitContainerEmployeesPrimary.Name = "splitContainerEmployeesPrimary";
            // 
            // splitContainerEmployeesPrimary.Panel1
            // 
            this.splitContainerEmployeesPrimary.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerEmployeesPrimary.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainerEmployeesPrimary.Panel2
            // 
            this.splitContainerEmployeesPrimary.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerEmployeesPrimary.Panel2.Controls.Add(this.splitContainerEmployeesSecondary);
            this.splitContainerEmployeesPrimary.Panel2MinSize = 200;
            this.splitContainerEmployeesPrimary.Size = new System.Drawing.Size(762, 394);
            this.splitContainerEmployeesPrimary.SplitterDistance = 558;
            this.splitContainerEmployeesPrimary.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeID,
            this.employeeName,
            this.employeeDepartment,
            this.employeeFunction,
            this.employeeUsername,
            this.employeeEmail,
            this.employeePhoneNumber,
            this.employeeAddress,
            this.employeeDOB,
            this.employeeBSN});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(552, 388);
            this.dataGridView1.TabIndex = 0;
            // 
            // employeeID
            // 
            this.employeeID.HeaderText = "ID";
            this.employeeID.Name = "employeeID";
            this.employeeID.Width = 50;
            // 
            // employeeName
            // 
            this.employeeName.HeaderText = "Employee name";
            this.employeeName.Name = "employeeName";
            this.employeeName.Width = 150;
            // 
            // employeeDepartment
            // 
            this.employeeDepartment.HeaderText = "Department";
            this.employeeDepartment.Name = "employeeDepartment";
            this.employeeDepartment.Width = 75;
            // 
            // employeeFunction
            // 
            this.employeeFunction.HeaderText = "Function";
            this.employeeFunction.Name = "employeeFunction";
            // 
            // employeeUsername
            // 
            this.employeeUsername.HeaderText = "Username";
            this.employeeUsername.Name = "employeeUsername";
            // 
            // employeeEmail
            // 
            this.employeeEmail.HeaderText = "Email";
            this.employeeEmail.Name = "employeeEmail";
            // 
            // employeePhoneNumber
            // 
            this.employeePhoneNumber.HeaderText = "Phone number";
            this.employeePhoneNumber.Name = "employeePhoneNumber";
            // 
            // employeeAddress
            // 
            this.employeeAddress.HeaderText = "Address";
            this.employeeAddress.Name = "employeeAddress";
            // 
            // employeeDOB
            // 
            this.employeeDOB.HeaderText = "Date of birth";
            this.employeeDOB.Name = "employeeDOB";
            // 
            // employeeBSN
            // 
            this.employeeBSN.HeaderText = "BSN";
            this.employeeBSN.Name = "employeeBSN";
            // 
            // splitContainerEmployeesSecondary
            // 
            this.splitContainerEmployeesSecondary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerEmployeesSecondary.BackColor = System.Drawing.Color.Snow;
            this.splitContainerEmployeesSecondary.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerEmployeesSecondary.IsSplitterFixed = true;
            this.splitContainerEmployeesSecondary.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEmployeesSecondary.Name = "splitContainerEmployeesSecondary";
            this.splitContainerEmployeesSecondary.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEmployeesSecondary.Panel1
            // 
            this.splitContainerEmployeesSecondary.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerEmployeesSecondary.Panel1.Controls.Add(this.buttonEmployeesDepartmentRemove);
            this.splitContainerEmployeesSecondary.Panel1.Controls.Add(this.buttonEmployeesDepartmentAdd);
            this.splitContainerEmployeesSecondary.Panel1.Controls.Add(this.textBoxEmployeesDepartmentName);
            this.splitContainerEmployeesSecondary.Panel1.Controls.Add(this.labelEmployeesDepartmentName);
            this.splitContainerEmployeesSecondary.Panel1MinSize = 85;
            // 
            // splitContainerEmployeesSecondary.Panel2
            // 
            this.splitContainerEmployeesSecondary.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.listBoxEmployeesSelected);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.labelEmployeesSelected);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.buttonEmployeesAdd);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.buttonEmployeesRemove);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.buttonEmployeeModify);
            this.splitContainerEmployeesSecondary.Size = new System.Drawing.Size(197, 394);
            this.splitContainerEmployeesSecondary.SplitterDistance = 85;
            this.splitContainerEmployeesSecondary.TabIndex = 0;
            // 
            // buttonEmployeesDepartmentRemove
            // 
            this.buttonEmployeesDepartmentRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployeesDepartmentRemove.Location = new System.Drawing.Point(116, 45);
            this.buttonEmployeesDepartmentRemove.Name = "buttonEmployeesDepartmentRemove";
            this.buttonEmployeesDepartmentRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonEmployeesDepartmentRemove.TabIndex = 3;
            this.buttonEmployeesDepartmentRemove.Text = "Remove";
            this.buttonEmployeesDepartmentRemove.UseVisualStyleBackColor = true;
            // 
            // buttonEmployeesDepartmentAdd
            // 
            this.buttonEmployeesDepartmentAdd.Location = new System.Drawing.Point(3, 45);
            this.buttonEmployeesDepartmentAdd.Name = "buttonEmployeesDepartmentAdd";
            this.buttonEmployeesDepartmentAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonEmployeesDepartmentAdd.TabIndex = 2;
            this.buttonEmployeesDepartmentAdd.Text = "Add";
            this.buttonEmployeesDepartmentAdd.UseVisualStyleBackColor = true;
            // 
            // textBoxEmployeesDepartmentName
            // 
            this.textBoxEmployeesDepartmentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmployeesDepartmentName.Location = new System.Drawing.Point(3, 19);
            this.textBoxEmployeesDepartmentName.Name = "textBoxEmployeesDepartmentName";
            this.textBoxEmployeesDepartmentName.Size = new System.Drawing.Size(188, 20);
            this.textBoxEmployeesDepartmentName.TabIndex = 1;
            // 
            // labelEmployeesDepartmentName
            // 
            this.labelEmployeesDepartmentName.AutoSize = true;
            this.labelEmployeesDepartmentName.Location = new System.Drawing.Point(0, 3);
            this.labelEmployeesDepartmentName.Name = "labelEmployeesDepartmentName";
            this.labelEmployeesDepartmentName.Size = new System.Drawing.Size(91, 13);
            this.labelEmployeesDepartmentName.TabIndex = 0;
            this.labelEmployeesDepartmentName.Text = "Department name";
            // 
            // listBoxEmployeesSelected
            // 
            this.listBoxEmployeesSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxEmployeesSelected.FormattingEnabled = true;
            this.listBoxEmployeesSelected.Location = new System.Drawing.Point(3, 20);
            this.listBoxEmployeesSelected.Name = "listBoxEmployeesSelected";
            this.listBoxEmployeesSelected.Size = new System.Drawing.Size(194, 186);
            this.listBoxEmployeesSelected.TabIndex = 4;
            // 
            // labelEmployeesSelected
            // 
            this.labelEmployeesSelected.AutoSize = true;
            this.labelEmployeesSelected.Location = new System.Drawing.Point(3, 4);
            this.labelEmployeesSelected.Name = "labelEmployeesSelected";
            this.labelEmployeesSelected.Size = new System.Drawing.Size(98, 13);
            this.labelEmployeesSelected.TabIndex = 3;
            this.labelEmployeesSelected.Text = "Selected Employee";
            // 
            // buttonEmployeesAdd
            // 
            this.buttonEmployeesAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployeesAdd.Location = new System.Drawing.Point(3, 218);
            this.buttonEmployeesAdd.Name = "buttonEmployeesAdd";
            this.buttonEmployeesAdd.Size = new System.Drawing.Size(188, 23);
            this.buttonEmployeesAdd.TabIndex = 2;
            this.buttonEmployeesAdd.Text = "Add new employee";
            this.buttonEmployeesAdd.UseVisualStyleBackColor = true;
            // 
            // buttonEmployeesRemove
            // 
            this.buttonEmployeesRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployeesRemove.Location = new System.Drawing.Point(3, 276);
            this.buttonEmployeesRemove.Name = "buttonEmployeesRemove";
            this.buttonEmployeesRemove.Size = new System.Drawing.Size(188, 23);
            this.buttonEmployeesRemove.TabIndex = 1;
            this.buttonEmployeesRemove.Text = "Remove selected employee";
            this.buttonEmployeesRemove.UseVisualStyleBackColor = true;
            // 
            // buttonEmployeeModify
            // 
            this.buttonEmployeeModify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployeeModify.Location = new System.Drawing.Point(3, 247);
            this.buttonEmployeeModify.Name = "buttonEmployeeModify";
            this.buttonEmployeeModify.Size = new System.Drawing.Size(188, 23);
            this.buttonEmployeeModify.TabIndex = 0;
            this.buttonEmployeeModify.Text = "Modify selected employee";
            this.buttonEmployeeModify.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.buttonStockAdd);
            this.tabPage2.Controls.Add(this.buttonStockEditProduct);
            this.tabPage2.Controls.Add(this.dataGridViewStock);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stock";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(638, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Toggle Active/Inactive";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonStockAdd
            // 
            this.buttonStockAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockAdd.Location = new System.Drawing.Point(6, 371);
            this.buttonStockAdd.Name = "buttonStockAdd";
            this.buttonStockAdd.Size = new System.Drawing.Size(124, 23);
            this.buttonStockAdd.TabIndex = 2;
            this.buttonStockAdd.Text = "Add Product";
            this.buttonStockAdd.UseVisualStyleBackColor = true;
            // 
            // buttonStockEditProduct
            // 
            this.buttonStockEditProduct.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonStockEditProduct.Location = new System.Drawing.Point(324, 371);
            this.buttonStockEditProduct.Name = "buttonStockEditProduct";
            this.buttonStockEditProduct.Size = new System.Drawing.Size(124, 23);
            this.buttonStockEditProduct.TabIndex = 1;
            this.buttonStockEditProduct.Text = "Edit Product";
            this.buttonStockEditProduct.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productName,
            this.productBrand,
            this.productCode,
            this.productCategory,
            this.productQuantity,
            this.productPrice,
            this.productActive,
            this.productDescription});
            this.dataGridViewStock.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.Size = new System.Drawing.Size(756, 359);
            this.dataGridViewStock.TabIndex = 0;
            // 
            // productName
            // 
            this.productName.HeaderText = "Product Name";
            this.productName.Name = "productName";
            // 
            // productBrand
            // 
            this.productBrand.HeaderText = "Brand";
            this.productBrand.Name = "productBrand";
            // 
            // productCode
            // 
            this.productCode.HeaderText = "Code";
            this.productCode.Name = "productCode";
            // 
            // productCategory
            // 
            this.productCategory.HeaderText = "Category";
            this.productCategory.Name = "productCategory";
            // 
            // productQuantity
            // 
            this.productQuantity.HeaderText = "Quantity";
            this.productQuantity.Name = "productQuantity";
            // 
            // productPrice
            // 
            this.productPrice.HeaderText = "Price";
            this.productPrice.Name = "productPrice";
            // 
            // productActive
            // 
            this.productActive.HeaderText = "Active";
            this.productActive.Name = "productActive";
            this.productActive.Width = 50;
            // 
            // productDescription
            // 
            this.productDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productDescription.HeaderText = "Description";
            this.productDescription.MinimumWidth = 50;
            this.productDescription.Name = "productDescription";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(768, 400);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Scheduling";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogin.Location = new System.Drawing.Point(712, 5);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 1;
            this.buttonLogin.Text = "Log out";
            this.buttonLogin.UseVisualStyleBackColor = true;
            // 
            // labelWelcomeText
            // 
            this.labelWelcomeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWelcomeText.AutoSize = true;
            this.labelWelcomeText.Location = new System.Drawing.Point(587, 10);
            this.labelWelcomeText.Name = "labelWelcomeText";
            this.labelWelcomeText.Size = new System.Drawing.Size(119, 13);
            this.labelWelcomeText.TabIndex = 2;
            this.labelWelcomeText.Text = "Welcome, USERNAME";
            this.labelWelcomeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelWelcomeText);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainWindow";
            this.Text = "Media Bazaar Management System";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainerEmployeesPrimary.Panel1.ResumeLayout(false);
            this.splitContainerEmployeesPrimary.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEmployeesPrimary)).EndInit();
            this.splitContainerEmployeesPrimary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainerEmployeesSecondary.Panel1.ResumeLayout(false);
            this.splitContainerEmployeesSecondary.Panel1.PerformLayout();
            this.splitContainerEmployeesSecondary.Panel2.ResumeLayout(false);
            this.splitContainerEmployeesSecondary.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEmployeesSecondary)).EndInit();
            this.splitContainerEmployeesSecondary.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonStockAdd;
        private System.Windows.Forms.Button buttonStockEditProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn productBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn productQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn productPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn productActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDescription;
        private System.Windows.Forms.SplitContainer splitContainerEmployeesPrimary;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainerEmployeesSecondary;
        private System.Windows.Forms.TextBox textBoxEmployeesDepartmentName;
        private System.Windows.Forms.Label labelEmployeesDepartmentName;
        private System.Windows.Forms.Button buttonEmployeesDepartmentRemove;
        private System.Windows.Forms.Button buttonEmployeesDepartmentAdd;
        private System.Windows.Forms.Label labelEmployeesSelected;
        private System.Windows.Forms.Button buttonEmployeesAdd;
        private System.Windows.Forms.Button buttonEmployeesRemove;
        private System.Windows.Forms.Button buttonEmployeeModify;
        private System.Windows.Forms.ListBox listBoxEmployeesSelected;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelWelcomeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeFunction;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeePhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeBSN;
    }
}

