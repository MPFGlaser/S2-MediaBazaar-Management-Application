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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 66D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 85D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 45D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 58D);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainerEmployeesPrimary = new System.Windows.Forms.SplitContainer();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerEmployeesSecondary = new System.Windows.Forms.SplitContainer();
            this.buttonEmployeesDepartmentRemove = new System.Windows.Forms.Button();
            this.buttonEmployeesDepartmentAdd = new System.Windows.Forms.Button();
            this.textBoxEmployeesDepartmentName = new System.Windows.Forms.TextBox();
            this.labelEmployeesDepartmentName = new System.Windows.Forms.Label();
            this.checkBoxShowInactive = new System.Windows.Forms.CheckBox();
            this.labelEmployeesSelected = new System.Windows.Forms.Label();
            this.buttonEmployeesAdd = new System.Windows.Forms.Button();
            this.buttonEmployeesRemove = new System.Windows.Forms.Button();
            this.buttonEmployeeModify = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxShowInactiveItems = new System.Windows.Forms.CheckBox();
            this.buttonStockAdd = new System.Windows.Forms.Button();
            this.buttonStockEditProduct = new System.Windows.Forms.Button();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainerStatistics1 = new System.Windows.Forms.SplitContainer();
            this.StatisticChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonStatisticsEmployee = new System.Windows.Forms.Button();
            this.comboBoxStatisticsEmployee = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStatisticsDepartment = new System.Windows.Forms.Button();
            this.comboBoxStatisticsDepartment = new System.Windows.Forms.ComboBox();
            this.DataButton = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainerScheduling1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSchedulingFunction = new System.Windows.Forms.ComboBox();
            this.buttonSchedulingNext = new System.Windows.Forms.Button();
            this.buttonSchedulingPrevious = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSchedulingWeek = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.calendarDayControlMonday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlTuesday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlWednesday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlThursday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlFriday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlSaturday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlSunday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelWelcomeText = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.buttonReloadDatabaseEntries = new System.Windows.Forms.Button();
            this.toolTipReloadDb = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEmployeesPrimary)).BeginInit();
            this.splitContainerEmployeesPrimary.Panel1.SuspendLayout();
            this.splitContainerEmployeesPrimary.Panel2.SuspendLayout();
            this.splitContainerEmployeesPrimary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEmployeesSecondary)).BeginInit();
            this.splitContainerEmployeesSecondary.Panel1.SuspendLayout();
            this.splitContainerEmployeesSecondary.Panel2.SuspendLayout();
            this.splitContainerEmployeesSecondary.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatistics1)).BeginInit();
            this.splitContainerStatistics1.Panel1.SuspendLayout();
            this.splitContainerStatistics1.Panel2.SuspendLayout();
            this.splitContainerStatistics1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatisticChart)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScheduling1)).BeginInit();
            this.splitContainerScheduling1.Panel1.SuspendLayout();
            this.splitContainerScheduling1.Panel2.SuspendLayout();
            this.splitContainerScheduling1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSchedulingWeek)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(1139, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainerEmployeesPrimary);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1131, 411);
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
            this.splitContainerEmployeesPrimary.Panel1.Controls.Add(this.dataGridViewEmployees);
            // 
            // splitContainerEmployeesPrimary.Panel2
            // 
            this.splitContainerEmployeesPrimary.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerEmployeesPrimary.Panel2.Controls.Add(this.splitContainerEmployeesSecondary);
            this.splitContainerEmployeesPrimary.Panel2MinSize = 298;
            this.splitContainerEmployeesPrimary.Size = new System.Drawing.Size(1125, 405);
            this.splitContainerEmployeesPrimary.SplitterDistance = 823;
            this.splitContainerEmployeesPrimary.TabIndex = 0;
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.AllowUserToDeleteRows = false;
            this.dataGridViewEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.active,
            this.firstName,
            this.surName,
            this.username,
            this.phoneNumber,
            this.emailAddress});
            this.dataGridViewEmployees.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.RowHeadersWidth = 21;
            this.dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(817, 399);
            this.dataGridViewEmployees.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // active
            // 
            this.active.HeaderText = "Active";
            this.active.Name = "active";
            this.active.ReadOnly = true;
            this.active.Width = 50;
            // 
            // firstName
            // 
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            this.firstName.Width = 150;
            // 
            // surName
            // 
            this.surName.HeaderText = "Surname";
            this.surName.Name = "surName";
            this.surName.ReadOnly = true;
            this.surName.Width = 160;
            // 
            // username
            // 
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 130;
            // 
            // phoneNumber
            // 
            this.phoneNumber.HeaderText = "Phone Number";
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.ReadOnly = true;
            this.phoneNumber.Width = 125;
            // 
            // emailAddress
            // 
            this.emailAddress.HeaderText = "Email";
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.ReadOnly = true;
            this.emailAddress.Width = 129;
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
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.checkBoxShowInactive);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.labelEmployeesSelected);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.buttonEmployeesAdd);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.buttonEmployeesRemove);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.buttonEmployeeModify);
            this.splitContainerEmployeesSecondary.Size = new System.Drawing.Size(295, 431);
            this.splitContainerEmployeesSecondary.SplitterDistance = 85;
            this.splitContainerEmployeesSecondary.TabIndex = 0;
            // 
            // buttonEmployeesDepartmentRemove
            // 
            this.buttonEmployeesDepartmentRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployeesDepartmentRemove.Enabled = false;
            this.buttonEmployeesDepartmentRemove.Location = new System.Drawing.Point(214, 45);
            this.buttonEmployeesDepartmentRemove.Name = "buttonEmployeesDepartmentRemove";
            this.buttonEmployeesDepartmentRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonEmployeesDepartmentRemove.TabIndex = 3;
            this.buttonEmployeesDepartmentRemove.Text = "Remove";
            this.buttonEmployeesDepartmentRemove.UseVisualStyleBackColor = true;
            // 
            // buttonEmployeesDepartmentAdd
            // 
            this.buttonEmployeesDepartmentAdd.Enabled = false;
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
            this.textBoxEmployeesDepartmentName.Enabled = false;
            this.textBoxEmployeesDepartmentName.Location = new System.Drawing.Point(3, 19);
            this.textBoxEmployeesDepartmentName.Name = "textBoxEmployeesDepartmentName";
            this.textBoxEmployeesDepartmentName.Size = new System.Drawing.Size(286, 20);
            this.textBoxEmployeesDepartmentName.TabIndex = 1;
            // 
            // labelEmployeesDepartmentName
            // 
            this.labelEmployeesDepartmentName.AutoSize = true;
            this.labelEmployeesDepartmentName.Enabled = false;
            this.labelEmployeesDepartmentName.Location = new System.Drawing.Point(0, 3);
            this.labelEmployeesDepartmentName.Name = "labelEmployeesDepartmentName";
            this.labelEmployeesDepartmentName.Size = new System.Drawing.Size(91, 13);
            this.labelEmployeesDepartmentName.TabIndex = 0;
            this.labelEmployeesDepartmentName.Text = "Department name";
            // 
            // checkBoxShowInactive
            // 
            this.checkBoxShowInactive.AutoSize = true;
            this.checkBoxShowInactive.Location = new System.Drawing.Point(6, 50);
            this.checkBoxShowInactive.Name = "checkBoxShowInactive";
            this.checkBoxShowInactive.Size = new System.Drawing.Size(146, 17);
            this.checkBoxShowInactive.TabIndex = 4;
            this.checkBoxShowInactive.Text = "Show inactive employees";
            this.checkBoxShowInactive.UseVisualStyleBackColor = true;
            this.checkBoxShowInactive.CheckedChanged += new System.EventHandler(this.checkBoxShowInactive_CheckedChanged);
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
            this.buttonEmployeesAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployeesAdd.Location = new System.Drawing.Point(150, 20);
            this.buttonEmployeesAdd.Name = "buttonEmployeesAdd";
            this.buttonEmployeesAdd.Size = new System.Drawing.Size(142, 23);
            this.buttonEmployeesAdd.TabIndex = 2;
            this.buttonEmployeesAdd.Text = "Add new employee";
            this.buttonEmployeesAdd.UseVisualStyleBackColor = true;
            this.buttonEmployeesAdd.Click += new System.EventHandler(this.buttonEmployeesAdd_Click);
            // 
            // buttonEmployeesRemove
            // 
            this.buttonEmployeesRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployeesRemove.Location = new System.Drawing.Point(3, 339);
            this.buttonEmployeesRemove.Name = "buttonEmployeesRemove";
            this.buttonEmployeesRemove.Size = new System.Drawing.Size(286, 23);
            this.buttonEmployeesRemove.TabIndex = 1;
            this.buttonEmployeesRemove.Text = "Remove selected employee";
            this.buttonEmployeesRemove.UseVisualStyleBackColor = true;
            // 
            // buttonEmployeeModify
            // 
            this.buttonEmployeeModify.Location = new System.Drawing.Point(3, 20);
            this.buttonEmployeeModify.Name = "buttonEmployeeModify";
            this.buttonEmployeeModify.Size = new System.Drawing.Size(141, 23);
            this.buttonEmployeeModify.TabIndex = 0;
            this.buttonEmployeeModify.Text = "View/Edit selected employee";
            this.buttonEmployeeModify.UseVisualStyleBackColor = true;
            this.buttonEmployeeModify.Click += new System.EventHandler(this.buttonEmployeeModify_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBoxShowInactiveItems);
            this.tabPage2.Controls.Add(this.buttonStockAdd);
            this.tabPage2.Controls.Add(this.buttonStockEditProduct);
            this.tabPage2.Controls.Add(this.dataGridViewStock);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1131, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stock";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowInactiveItems
            // 
            this.checkBoxShowInactiveItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowInactiveItems.AutoSize = true;
            this.checkBoxShowInactiveItems.Location = new System.Drawing.Point(984, 386);
            this.checkBoxShowInactiveItems.Name = "checkBoxShowInactiveItems";
            this.checkBoxShowInactiveItems.Size = new System.Drawing.Size(137, 17);
            this.checkBoxShowInactiveItems.TabIndex = 5;
            this.checkBoxShowInactiveItems.Text = "Show inactive products";
            this.checkBoxShowInactiveItems.UseVisualStyleBackColor = true;
            this.checkBoxShowInactiveItems.CheckedChanged += new System.EventHandler(this.checkBoxShowInactiveItems_CheckedChanged);
            // 
            // buttonStockAdd
            // 
            this.buttonStockAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockAdd.Location = new System.Drawing.Point(6, 382);
            this.buttonStockAdd.Name = "buttonStockAdd";
            this.buttonStockAdd.Size = new System.Drawing.Size(124, 23);
            this.buttonStockAdd.TabIndex = 2;
            this.buttonStockAdd.Text = "Add Product";
            this.buttonStockAdd.UseVisualStyleBackColor = true;
            this.buttonStockAdd.Click += new System.EventHandler(this.buttonStockAdd_Click);
            // 
            // buttonStockEditProduct
            // 
            this.buttonStockEditProduct.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonStockEditProduct.Location = new System.Drawing.Point(503, 382);
            this.buttonStockEditProduct.Name = "buttonStockEditProduct";
            this.buttonStockEditProduct.Size = new System.Drawing.Size(124, 23);
            this.buttonStockEditProduct.TabIndex = 1;
            this.buttonStockEditProduct.Text = "Edit Product";
            this.buttonStockEditProduct.UseVisualStyleBackColor = true;
            this.buttonStockEditProduct.Click += new System.EventHandler(this.buttonStockEditProduct_Click);
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.AllowUserToAddRows = false;
            this.dataGridViewStock.AllowUserToDeleteRows = false;
            this.dataGridViewStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productId,
            this.name,
            this.brand,
            this.code,
            this.category,
            this.quantity,
            this.price,
            this.productActive,
            this.description});
            this.dataGridViewStock.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewStock.MultiSelect = false;
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.RowHeadersWidth = 21;
            this.dataGridViewStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStock.Size = new System.Drawing.Size(1115, 370);
            this.dataGridViewStock.TabIndex = 0;
            // 
            // productId
            // 
            this.productId.HeaderText = "ID";
            this.productId.Name = "productId";
            this.productId.ReadOnly = true;
            this.productId.Width = 50;
            // 
            // name
            // 
            this.name.HeaderText = "Product Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // brand
            // 
            this.brand.HeaderText = "Brand";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            // 
            // code
            // 
            this.code.HeaderText = "Code";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // category
            // 
            this.category.HeaderText = "Category";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // productActive
            // 
            this.productActive.HeaderText = "Active";
            this.productActive.Name = "productActive";
            this.productActive.ReadOnly = true;
            this.productActive.Width = 50;
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.description.HeaderText = "Description";
            this.description.MinimumWidth = 50;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainerStatistics1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1131, 411);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainerStatistics1
            // 
            this.splitContainerStatistics1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainerStatistics1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStatistics1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerStatistics1.Name = "splitContainerStatistics1";
            // 
            // splitContainerStatistics1.Panel1
            // 
            this.splitContainerStatistics1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerStatistics1.Panel1.Controls.Add(this.StatisticChart);
            // 
            // splitContainerStatistics1.Panel2
            // 
            this.splitContainerStatistics1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerStatistics1.Panel2.Controls.Add(this.label4);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.buttonStatisticsEmployee);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.comboBoxStatisticsEmployee);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.label3);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.buttonStatisticsDepartment);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.comboBoxStatisticsDepartment);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.DataButton);
            this.splitContainerStatistics1.Panel2MinSize = 125;
            this.splitContainerStatistics1.Size = new System.Drawing.Size(1131, 411);
            this.splitContainerStatistics1.SplitterDistance = 1002;
            this.splitContainerStatistics1.TabIndex = 2;
            // 
            // StatisticChart
            // 
            chartArea1.Name = "ChartArea1";
            this.StatisticChart.ChartAreas.Add(chartArea1);
            this.StatisticChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.StatisticChart.Legends.Add(legend1);
            this.StatisticChart.Location = new System.Drawing.Point(0, 0);
            this.StatisticChart.Name = "StatisticChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "TestData";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            this.StatisticChart.Series.Add(series1);
            this.StatisticChart.Size = new System.Drawing.Size(1002, 411);
            this.StatisticChart.TabIndex = 0;
            this.StatisticChart.Text = "chart1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Select an employee";
            // 
            // buttonStatisticsEmployee
            // 
            this.buttonStatisticsEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStatisticsEmployee.Location = new System.Drawing.Point(5, 145);
            this.buttonStatisticsEmployee.Name = "buttonStatisticsEmployee";
            this.buttonStatisticsEmployee.Size = new System.Drawing.Size(117, 23);
            this.buttonStatisticsEmployee.TabIndex = 7;
            this.buttonStatisticsEmployee.Text = "Get statistics";
            this.buttonStatisticsEmployee.UseVisualStyleBackColor = true;
            // 
            // comboBoxStatisticsEmployee
            // 
            this.comboBoxStatisticsEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStatisticsEmployee.FormattingEnabled = true;
            this.comboBoxStatisticsEmployee.Location = new System.Drawing.Point(5, 117);
            this.comboBoxStatisticsEmployee.Name = "comboBoxStatisticsEmployee";
            this.comboBoxStatisticsEmployee.Size = new System.Drawing.Size(117, 21);
            this.comboBoxStatisticsEmployee.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select a department";
            // 
            // buttonStatisticsDepartment
            // 
            this.buttonStatisticsDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStatisticsDepartment.Location = new System.Drawing.Point(5, 56);
            this.buttonStatisticsDepartment.Name = "buttonStatisticsDepartment";
            this.buttonStatisticsDepartment.Size = new System.Drawing.Size(117, 23);
            this.buttonStatisticsDepartment.TabIndex = 4;
            this.buttonStatisticsDepartment.Text = "Get statistics";
            this.buttonStatisticsDepartment.UseVisualStyleBackColor = true;
            // 
            // comboBoxStatisticsDepartment
            // 
            this.comboBoxStatisticsDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStatisticsDepartment.FormattingEnabled = true;
            this.comboBoxStatisticsDepartment.Location = new System.Drawing.Point(5, 28);
            this.comboBoxStatisticsDepartment.Name = "comboBoxStatisticsDepartment";
            this.comboBoxStatisticsDepartment.Size = new System.Drawing.Size(117, 21);
            this.comboBoxStatisticsDepartment.TabIndex = 2;
            // 
            // DataButton
            // 
            this.DataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataButton.Location = new System.Drawing.Point(47, 368);
            this.DataButton.Name = "DataButton";
            this.DataButton.Size = new System.Drawing.Size(75, 40);
            this.DataButton.TabIndex = 1;
            this.DataButton.Text = "Generate Some Data";
            this.DataButton.UseVisualStyleBackColor = true;
            this.DataButton.Click += new System.EventHandler(this.DataButton_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainerScheduling1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1131, 411);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Scheduling";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainerScheduling1
            // 
            this.splitContainerScheduling1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainerScheduling1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerScheduling1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerScheduling1.IsSplitterFixed = true;
            this.splitContainerScheduling1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerScheduling1.Name = "splitContainerScheduling1";
            this.splitContainerScheduling1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerScheduling1.Panel1
            // 
            this.splitContainerScheduling1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerScheduling1.Panel1.Controls.Add(this.label2);
            this.splitContainerScheduling1.Panel1.Controls.Add(this.comboBoxSchedulingFunction);
            this.splitContainerScheduling1.Panel1.Controls.Add(this.buttonSchedulingNext);
            this.splitContainerScheduling1.Panel1.Controls.Add(this.buttonSchedulingPrevious);
            this.splitContainerScheduling1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerScheduling1.Panel2
            // 
            this.splitContainerScheduling1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerScheduling1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainerScheduling1.Size = new System.Drawing.Size(1131, 411);
            this.splitContainerScheduling1.SplitterDistance = 106;
            this.splitContainerScheduling1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(948, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Function";
            // 
            // comboBoxSchedulingFunction
            // 
            this.comboBoxSchedulingFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSchedulingFunction.FormattingEnabled = true;
            this.comboBoxSchedulingFunction.Location = new System.Drawing.Point(1002, 4);
            this.comboBoxSchedulingFunction.Name = "comboBoxSchedulingFunction";
            this.comboBoxSchedulingFunction.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSchedulingFunction.TabIndex = 5;
            // 
            // buttonSchedulingNext
            // 
            this.buttonSchedulingNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonSchedulingNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.buttonSchedulingNext.Location = new System.Drawing.Point(736, 4);
            this.buttonSchedulingNext.Name = "buttonSchedulingNext";
            this.buttonSchedulingNext.Size = new System.Drawing.Size(100, 100);
            this.buttonSchedulingNext.TabIndex = 4;
            this.buttonSchedulingNext.Text = ">";
            this.buttonSchedulingNext.UseVisualStyleBackColor = true;
            this.buttonSchedulingNext.Click += new System.EventHandler(this.buttonSchedulingNext_Click);
            // 
            // buttonSchedulingPrevious
            // 
            this.buttonSchedulingPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonSchedulingPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.buttonSchedulingPrevious.Location = new System.Drawing.Point(294, 3);
            this.buttonSchedulingPrevious.Name = "buttonSchedulingPrevious";
            this.buttonSchedulingPrevious.Size = new System.Drawing.Size(100, 100);
            this.buttonSchedulingPrevious.TabIndex = 3;
            this.buttonSchedulingPrevious.Text = "<";
            this.buttonSchedulingPrevious.UseVisualStyleBackColor = true;
            this.buttonSchedulingPrevious.Click += new System.EventHandler(this.buttonSchedulingPrevious_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownSchedulingWeek);
            this.groupBox1.Location = new System.Drawing.Point(400, 3);
            this.groupBox1.MaximumSize = new System.Drawing.Size(330, 100);
            this.groupBox1.MinimumSize = new System.Drawing.Size(330, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Week number:";
            // 
            // numericUpDownSchedulingWeek
            // 
            this.numericUpDownSchedulingWeek.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericUpDownSchedulingWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.numericUpDownSchedulingWeek.Location = new System.Drawing.Point(261, 30);
            this.numericUpDownSchedulingWeek.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.numericUpDownSchedulingWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSchedulingWeek.Name = "numericUpDownSchedulingWeek";
            this.numericUpDownSchedulingWeek.Size = new System.Drawing.Size(63, 45);
            this.numericUpDownSchedulingWeek.TabIndex = 0;
            this.numericUpDownSchedulingWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.calendarDayControlMonday);
            this.flowLayoutPanel1.Controls.Add(this.calendarDayControlTuesday);
            this.flowLayoutPanel1.Controls.Add(this.calendarDayControlWednesday);
            this.flowLayoutPanel1.Controls.Add(this.calendarDayControlThursday);
            this.flowLayoutPanel1.Controls.Add(this.calendarDayControlFriday);
            this.flowLayoutPanel1.Controls.Add(this.calendarDayControlSaturday);
            this.flowLayoutPanel1.Controls.Add(this.calendarDayControlSunday);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1131, 289);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // calendarDayControlMonday
            // 
            this.calendarDayControlMonday.BackColor = System.Drawing.SystemColors.Window;
            this.calendarDayControlMonday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarDayControlMonday.Location = new System.Drawing.Point(3, 3);
            this.calendarDayControlMonday.MinimumSize = new System.Drawing.Size(155, 230);
            this.calendarDayControlMonday.Name = "calendarDayControlMonday";
            this.calendarDayControlMonday.Size = new System.Drawing.Size(155, 230);
            this.calendarDayControlMonday.TabIndex = 0;
            // 
            // calendarDayControlTuesday
            // 
            this.calendarDayControlTuesday.BackColor = System.Drawing.SystemColors.Window;
            this.calendarDayControlTuesday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarDayControlTuesday.Location = new System.Drawing.Point(164, 3);
            this.calendarDayControlTuesday.MinimumSize = new System.Drawing.Size(155, 230);
            this.calendarDayControlTuesday.Name = "calendarDayControlTuesday";
            this.calendarDayControlTuesday.Size = new System.Drawing.Size(155, 230);
            this.calendarDayControlTuesday.TabIndex = 1;
            // 
            // calendarDayControlWednesday
            // 
            this.calendarDayControlWednesday.BackColor = System.Drawing.SystemColors.Window;
            this.calendarDayControlWednesday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarDayControlWednesday.Location = new System.Drawing.Point(325, 3);
            this.calendarDayControlWednesday.MinimumSize = new System.Drawing.Size(155, 230);
            this.calendarDayControlWednesday.Name = "calendarDayControlWednesday";
            this.calendarDayControlWednesday.Size = new System.Drawing.Size(155, 230);
            this.calendarDayControlWednesday.TabIndex = 2;
            // 
            // calendarDayControlThursday
            // 
            this.calendarDayControlThursday.BackColor = System.Drawing.SystemColors.Window;
            this.calendarDayControlThursday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarDayControlThursday.Location = new System.Drawing.Point(486, 3);
            this.calendarDayControlThursday.MinimumSize = new System.Drawing.Size(155, 230);
            this.calendarDayControlThursday.Name = "calendarDayControlThursday";
            this.calendarDayControlThursday.Size = new System.Drawing.Size(155, 230);
            this.calendarDayControlThursday.TabIndex = 3;
            // 
            // calendarDayControlFriday
            // 
            this.calendarDayControlFriday.BackColor = System.Drawing.SystemColors.Window;
            this.calendarDayControlFriday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarDayControlFriday.Location = new System.Drawing.Point(647, 3);
            this.calendarDayControlFriday.MinimumSize = new System.Drawing.Size(155, 230);
            this.calendarDayControlFriday.Name = "calendarDayControlFriday";
            this.calendarDayControlFriday.Size = new System.Drawing.Size(155, 230);
            this.calendarDayControlFriday.TabIndex = 4;
            // 
            // calendarDayControlSaturday
            // 
            this.calendarDayControlSaturday.BackColor = System.Drawing.SystemColors.Window;
            this.calendarDayControlSaturday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarDayControlSaturday.Location = new System.Drawing.Point(808, 3);
            this.calendarDayControlSaturday.MinimumSize = new System.Drawing.Size(155, 230);
            this.calendarDayControlSaturday.Name = "calendarDayControlSaturday";
            this.calendarDayControlSaturday.Size = new System.Drawing.Size(155, 230);
            this.calendarDayControlSaturday.TabIndex = 5;
            // 
            // calendarDayControlSunday
            // 
            this.calendarDayControlSunday.BackColor = System.Drawing.SystemColors.Window;
            this.calendarDayControlSunday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarDayControlSunday.Location = new System.Drawing.Point(969, 3);
            this.calendarDayControlSunday.MinimumSize = new System.Drawing.Size(155, 230);
            this.calendarDayControlSunday.Name = "calendarDayControlSunday";
            this.calendarDayControlSunday.Size = new System.Drawing.Size(155, 230);
            this.calendarDayControlSunday.TabIndex = 6;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogin.Location = new System.Drawing.Point(1071, 5);
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
            this.labelWelcomeText.Location = new System.Drawing.Point(946, 10);
            this.labelWelcomeText.Name = "labelWelcomeText";
            this.labelWelcomeText.Size = new System.Drawing.Size(119, 13);
            this.labelWelcomeText.TabIndex = 2;
            this.labelWelcomeText.Text = "Welcome, USERNAME";
            this.labelWelcomeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonReloadDatabaseEntries
            // 
            this.buttonReloadDatabaseEntries.BackgroundImage = global::MediaBazaar_ManagementSystem.Properties.Resources.reload1;
            this.buttonReloadDatabaseEntries.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReloadDatabaseEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.buttonReloadDatabaseEntries.Location = new System.Drawing.Point(815, 4);
            this.buttonReloadDatabaseEntries.Name = "buttonReloadDatabaseEntries";
            this.buttonReloadDatabaseEntries.Size = new System.Drawing.Size(25, 25);
            this.buttonReloadDatabaseEntries.TabIndex = 5;
            this.buttonReloadDatabaseEntries.UseVisualStyleBackColor = true;
            this.buttonReloadDatabaseEntries.Click += new System.EventHandler(this.buttonReloadDatabaseEntries_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 461);
            this.Controls.Add(this.buttonReloadDatabaseEntries);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.splitContainerEmployeesSecondary.Panel1.ResumeLayout(false);
            this.splitContainerEmployeesSecondary.Panel1.PerformLayout();
            this.splitContainerEmployeesSecondary.Panel2.ResumeLayout(false);
            this.splitContainerEmployeesSecondary.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEmployeesSecondary)).EndInit();
            this.splitContainerEmployeesSecondary.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainerStatistics1.Panel1.ResumeLayout(false);
            this.splitContainerStatistics1.Panel2.ResumeLayout(false);
            this.splitContainerStatistics1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatistics1)).EndInit();
            this.splitContainerStatistics1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatisticChart)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.splitContainerScheduling1.Panel1.ResumeLayout(false);
            this.splitContainerScheduling1.Panel1.PerformLayout();
            this.splitContainerScheduling1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScheduling1)).EndInit();
            this.splitContainerScheduling1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSchedulingWeek)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonStockAdd;
        private System.Windows.Forms.Button buttonStockEditProduct;
        private System.Windows.Forms.SplitContainer splitContainerEmployeesPrimary;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.SplitContainer splitContainerEmployeesSecondary;
        private System.Windows.Forms.TextBox textBoxEmployeesDepartmentName;
        private System.Windows.Forms.Label labelEmployeesDepartmentName;
        private System.Windows.Forms.Button buttonEmployeesDepartmentRemove;
        private System.Windows.Forms.Button buttonEmployeesDepartmentAdd;
        private System.Windows.Forms.Label labelEmployeesSelected;
        private System.Windows.Forms.Button buttonEmployeesAdd;
        private System.Windows.Forms.Button buttonEmployeesRemove;
        private System.Windows.Forms.Button buttonEmployeeModify;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelWelcomeText;
        private System.Windows.Forms.DataVisualization.Charting.Chart StatisticChart;
        private System.Windows.Forms.Button DataButton;
        private System.Windows.Forms.SplitContainer splitContainerScheduling1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CalendarDayControl calendarDayControlMonday;
        private CalendarDayControl calendarDayControlTuesday;
        private CalendarDayControl calendarDayControlWednesday;
        private CalendarDayControl calendarDayControlThursday;
        private CalendarDayControl calendarDayControlFriday;
        private CalendarDayControl calendarDayControlSaturday;
        private CalendarDayControl calendarDayControlSunday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSchedulingWeek;
        private System.Windows.Forms.Button buttonSchedulingNext;
        private System.Windows.Forms.Button buttonSchedulingPrevious;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSchedulingFunction;
        private System.Windows.Forms.SplitContainer splitContainerStatistics1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStatisticsEmployee;
        private System.Windows.Forms.ComboBox comboBoxStatisticsEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStatisticsDepartment;
        private System.Windows.Forms.ComboBox comboBoxStatisticsDepartment;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn surName;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn bsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn spousePhoneNumber;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.CheckBox checkBoxShowInactive;
        private System.Windows.Forms.CheckBox checkBoxShowInactiveItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn productActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.Button buttonReloadDatabaseEntries;
        private System.Windows.Forms.ToolTip toolTipReloadDb;
    }
}

