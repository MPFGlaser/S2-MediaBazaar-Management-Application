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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelWelcomeText = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.buttonReloadDatabaseEntries = new System.Windows.Forms.Button();
            this.toolTipReloadDb = new System.Windows.Forms.ToolTip(this.components);
            this.tabPageScheduling = new System.Windows.Forms.TabPage();
            this.splitContainerScheduling1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSchedulingDepartment = new System.Windows.Forms.ComboBox();
            this.buttonSchedulingNext = new System.Windows.Forms.Button();
            this.buttonSchedulingPrevious = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSetWeekShiftsCapacity = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSchedulingWeek = new System.Windows.Forms.NumericUpDown();
            this.progressBarSchedulingTime = new System.Windows.Forms.ProgressBar();
            this.buttonAutomaticScheduling = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageStatistics = new System.Windows.Forms.TabPage();
            this.splitContainerStatistics1 = new System.Windows.Forms.SplitContainer();
            this.StatisticChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonStatisticsEmployee = new System.Windows.Forms.Button();
            this.comboBoxStatisticsEmployee = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStatisticsDepartment = new System.Windows.Forms.Button();
            this.comboBoxStatisticsDepartment = new System.Windows.Forms.ComboBox();
            this.tabPageStock = new System.Windows.Forms.TabPage();
            this.splitContainerStockPrimary = new System.Windows.Forms.SplitContainer();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock_request = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerStockSecondary = new System.Windows.Forms.SplitContainer();
            this.comboBoxStockCategory = new System.Windows.Forms.ComboBox();
            this.buttonStockCategoryRemove = new System.Windows.Forms.Button();
            this.buttonStockCategoryAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlDepotWorker = new System.Windows.Forms.Panel();
            this.btnAcceptRestockRequest = new System.Windows.Forms.Button();
            this.pnlSalesRepresentative = new System.Windows.Forms.Panel();
            this.btnSendRestockRequest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxShowInactiveItems = new System.Windows.Forms.CheckBox();
            this.buttonStockEditProduct = new System.Windows.Forms.Button();
            this.buttonStockAdd = new System.Windows.Forms.Button();
            this.tabPageEmployees = new System.Windows.Forms.TabPage();
            this.splitContainerEmployeesPrimary = new System.Windows.Forms.SplitContainer();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerEmployeesSecondary = new System.Windows.Forms.SplitContainer();
            this.comboBoxAllDepartments = new System.Windows.Forms.ComboBox();
            this.buttonEmployeesDepartmentRemove = new System.Windows.Forms.Button();
            this.buttonEmployeesDepartmentAdd = new System.Windows.Forms.Button();
            this.labelEmployeesDepartmentName = new System.Windows.Forms.Label();
            this.gbManagement = new System.Windows.Forms.GroupBox();
            this.btnClockinOut = new System.Windows.Forms.Button();
            this.labelEmployeesSelected = new System.Windows.Forms.Label();
            this.buttonEmployeesAdd = new System.Windows.Forms.Button();
            this.buttonEmployeesRemove = new System.Windows.Forms.Button();
            this.buttonEmployeeModify = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRequests = new System.Windows.Forms.TabPage();
            this.btnPermit = new System.Windows.Forms.Button();
            this.btnTurnDown = new System.Windows.Forms.Button();
            this.lbxRequests = new System.Windows.Forms.ListBox();
            this.buttonEditFunctionPermissions = new System.Windows.Forms.Button();
            this.checkBoxShowInactive = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxExportData = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbxWeekNumber = new System.Windows.Forms.ComboBox();
            this.btnExportData = new System.Windows.Forms.Button();
            this.calendarDayControlMonday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlTuesday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlWednesday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlThursday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlFriday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlSaturday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.calendarDayControlSunday = new MediaBazaar_ManagementSystem.CalendarDayControl();
            this.tabPageScheduling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScheduling1)).BeginInit();
            this.splitContainerScheduling1.Panel1.SuspendLayout();
            this.splitContainerScheduling1.Panel2.SuspendLayout();
            this.splitContainerScheduling1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSchedulingWeek)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPageStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatistics1)).BeginInit();
            this.splitContainerStatistics1.Panel1.SuspendLayout();
            this.splitContainerStatistics1.Panel2.SuspendLayout();
            this.splitContainerStatistics1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatisticChart)).BeginInit();
            this.tabPageStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStockPrimary)).BeginInit();
            this.splitContainerStockPrimary.Panel1.SuspendLayout();
            this.splitContainerStockPrimary.Panel2.SuspendLayout();
            this.splitContainerStockPrimary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStockSecondary)).BeginInit();
            this.splitContainerStockSecondary.Panel1.SuspendLayout();
            this.splitContainerStockSecondary.Panel2.SuspendLayout();
            this.splitContainerStockSecondary.SuspendLayout();
            this.pnlDepotWorker.SuspendLayout();
            this.pnlSalesRepresentative.SuspendLayout();
            this.tabPageEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEmployeesPrimary)).BeginInit();
            this.splitContainerEmployeesPrimary.Panel1.SuspendLayout();
            this.splitContainerEmployeesPrimary.Panel2.SuspendLayout();
            this.splitContainerEmployeesPrimary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEmployeesSecondary)).BeginInit();
            this.splitContainerEmployeesSecondary.Panel1.SuspendLayout();
            this.splitContainerEmployeesSecondary.Panel2.SuspendLayout();
            this.splitContainerEmployeesSecondary.SuspendLayout();
            this.gbManagement.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageRequests.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBoxExportData.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
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
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelWelcomeText
            // 
            this.labelWelcomeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWelcomeText.Location = new System.Drawing.Point(944, 10);
            this.labelWelcomeText.Name = "labelWelcomeText";
            this.labelWelcomeText.Size = new System.Drawing.Size(125, 13);
            this.labelWelcomeText.TabIndex = 2;
            this.labelWelcomeText.Text = "Welcome";
            this.labelWelcomeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonReloadDatabaseEntries
            // 
            this.buttonReloadDatabaseEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReloadDatabaseEntries.BackgroundImage = global::MediaBazaar_ManagementSystem.Properties.Resources.reload1;
            this.buttonReloadDatabaseEntries.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReloadDatabaseEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.buttonReloadDatabaseEntries.Location = new System.Drawing.Point(905, 4);
            this.buttonReloadDatabaseEntries.Name = "buttonReloadDatabaseEntries";
            this.buttonReloadDatabaseEntries.Size = new System.Drawing.Size(25, 25);
            this.buttonReloadDatabaseEntries.TabIndex = 5;
            this.buttonReloadDatabaseEntries.UseVisualStyleBackColor = true;
            this.buttonReloadDatabaseEntries.Click += new System.EventHandler(this.buttonReloadDatabaseEntries_Click);
            // 
            // tabPageScheduling
            // 
            this.tabPageScheduling.Controls.Add(this.splitContainerScheduling1);
            this.tabPageScheduling.Location = new System.Drawing.Point(4, 22);
            this.tabPageScheduling.Name = "tabPageScheduling";
            this.tabPageScheduling.Size = new System.Drawing.Size(1131, 411);
            this.tabPageScheduling.TabIndex = 3;
            this.tabPageScheduling.Text = "Scheduling";
            this.tabPageScheduling.UseVisualStyleBackColor = true;
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
            this.splitContainerScheduling1.Panel1.Controls.Add(this.comboBoxSchedulingDepartment);
            this.splitContainerScheduling1.Panel1.Controls.Add(this.buttonSchedulingNext);
            this.splitContainerScheduling1.Panel1.Controls.Add(this.buttonSchedulingPrevious);
            this.splitContainerScheduling1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerScheduling1.Panel2
            // 
            this.splitContainerScheduling1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerScheduling1.Panel2.Controls.Add(this.progressBarSchedulingTime);
            this.splitContainerScheduling1.Panel2.Controls.Add(this.buttonAutomaticScheduling);
            this.splitContainerScheduling1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainerScheduling1.Size = new System.Drawing.Size(1131, 411);
            this.splitContainerScheduling1.SplitterDistance = 106;
            this.splitContainerScheduling1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(931, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Department:";
            // 
            // comboBoxSchedulingDepartment
            // 
            this.comboBoxSchedulingDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSchedulingDepartment.FormattingEnabled = true;
            this.comboBoxSchedulingDepartment.Location = new System.Drawing.Point(1002, 4);
            this.comboBoxSchedulingDepartment.Name = "comboBoxSchedulingDepartment";
            this.comboBoxSchedulingDepartment.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSchedulingDepartment.TabIndex = 5;
            this.comboBoxSchedulingDepartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxSchedulingDepartment_SelectedIndexChanged);
            // 
            // buttonSchedulingNext
            // 
            this.buttonSchedulingNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonSchedulingNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.buttonSchedulingNext.Location = new System.Drawing.Point(735, 4);
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
            this.groupBox1.Controls.Add(this.buttonSetWeekShiftsCapacity);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownSchedulingWeek);
            this.groupBox1.Location = new System.Drawing.Point(399, 3);
            this.groupBox1.MaximumSize = new System.Drawing.Size(330, 100);
            this.groupBox1.MinimumSize = new System.Drawing.Size(330, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // buttonSetWeekShiftsCapacity
            // 
            this.buttonSetWeekShiftsCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSetWeekShiftsCapacity.Location = new System.Drawing.Point(6, 67);
            this.buttonSetWeekShiftsCapacity.Name = "buttonSetWeekShiftsCapacity";
            this.buttonSetWeekShiftsCapacity.Size = new System.Drawing.Size(318, 27);
            this.buttonSetWeekShiftsCapacity.TabIndex = 7;
            this.buttonSetWeekShiftsCapacity.Text = "Edit capacity for all shifts this week";
            this.buttonSetWeekShiftsCapacity.UseVisualStyleBackColor = true;
            this.buttonSetWeekShiftsCapacity.Click += new System.EventHandler(this.buttonSetWeekShiftsCapacity_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Week number:";
            // 
            // numericUpDownSchedulingWeek
            // 
            this.numericUpDownSchedulingWeek.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericUpDownSchedulingWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.numericUpDownSchedulingWeek.Location = new System.Drawing.Point(261, 16);
            this.numericUpDownSchedulingWeek.Maximum = new decimal(new int[] {
            54,
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
            // progressBarSchedulingTime
            // 
            this.progressBarSchedulingTime.Location = new System.Drawing.Point(486, 275);
            this.progressBarSchedulingTime.Name = "progressBarSchedulingTime";
            this.progressBarSchedulingTime.Size = new System.Drawing.Size(155, 23);
            this.progressBarSchedulingTime.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarSchedulingTime.TabIndex = 8;
            this.progressBarSchedulingTime.Visible = false;
            // 
            // buttonAutomaticScheduling
            // 
            this.buttonAutomaticScheduling.Location = new System.Drawing.Point(486, 246);
            this.buttonAutomaticScheduling.Name = "buttonAutomaticScheduling";
            this.buttonAutomaticScheduling.Size = new System.Drawing.Size(155, 23);
            this.buttonAutomaticScheduling.TabIndex = 7;
            this.buttonAutomaticScheduling.Text = "Schedule Automatically";
            this.buttonAutomaticScheduling.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAutomaticScheduling.UseVisualStyleBackColor = true;
            this.buttonAutomaticScheduling.Click += new System.EventHandler(this.buttonAutomaticScheduling_Click);
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
            // tabPageStatistics
            // 
            this.tabPageStatistics.Controls.Add(this.splitContainerStatistics1);
            this.tabPageStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatistics.Name = "tabPageStatistics";
            this.tabPageStatistics.Size = new System.Drawing.Size(1131, 411);
            this.tabPageStatistics.TabIndex = 2;
            this.tabPageStatistics.Text = "Statistics";
            this.tabPageStatistics.UseVisualStyleBackColor = true;
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
            this.splitContainerStatistics1.Panel2.Controls.Add(this.groupBoxExportData);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.label4);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.buttonStatisticsEmployee);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.comboBoxStatisticsEmployee);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.label3);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.buttonStatisticsDepartment);
            this.splitContainerStatistics1.Panel2.Controls.Add(this.comboBoxStatisticsDepartment);
            this.splitContainerStatistics1.Panel2MinSize = 125;
            this.splitContainerStatistics1.Size = new System.Drawing.Size(1131, 411);
            this.splitContainerStatistics1.SplitterDistance = 937;
            this.splitContainerStatistics1.TabIndex = 2;
            // 
            // StatisticChart
            // 
            chartArea1.Name = "ChartArea1";
            this.StatisticChart.ChartAreas.Add(chartArea1);
            this.StatisticChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatisticChart.Enabled = false;
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
            this.StatisticChart.Size = new System.Drawing.Size(937, 411);
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
            this.buttonStatisticsEmployee.Size = new System.Drawing.Size(179, 23);
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
            this.comboBoxStatisticsEmployee.Size = new System.Drawing.Size(179, 21);
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
            this.buttonStatisticsDepartment.Size = new System.Drawing.Size(179, 23);
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
            this.comboBoxStatisticsDepartment.Size = new System.Drawing.Size(179, 21);
            this.comboBoxStatisticsDepartment.TabIndex = 2;
            // 
            // tabPageStock
            // 
            this.tabPageStock.Controls.Add(this.splitContainerStockPrimary);
            this.tabPageStock.Location = new System.Drawing.Point(4, 22);
            this.tabPageStock.Name = "tabPageStock";
            this.tabPageStock.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageStock.Size = new System.Drawing.Size(1131, 411);
            this.tabPageStock.TabIndex = 1;
            this.tabPageStock.Text = "Stock";
            this.tabPageStock.UseVisualStyleBackColor = true;
            // 
            // splitContainerStockPrimary
            // 
            this.splitContainerStockPrimary.BackColor = System.Drawing.Color.LightGray;
            this.splitContainerStockPrimary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStockPrimary.Location = new System.Drawing.Point(3, 3);
            this.splitContainerStockPrimary.Name = "splitContainerStockPrimary";
            // 
            // splitContainerStockPrimary.Panel1
            // 
            this.splitContainerStockPrimary.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerStockPrimary.Panel1.Controls.Add(this.dataGridViewStock);
            // 
            // splitContainerStockPrimary.Panel2
            // 
            this.splitContainerStockPrimary.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerStockPrimary.Panel2.Controls.Add(this.splitContainerStockSecondary);
            this.splitContainerStockPrimary.Panel2MinSize = 298;
            this.splitContainerStockPrimary.Size = new System.Drawing.Size(1125, 405);
            this.splitContainerStockPrimary.SplitterDistance = 822;
            this.splitContainerStockPrimary.TabIndex = 6;
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.AllowUserToAddRows = false;
            this.dataGridViewStock.AllowUserToDeleteRows = false;
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productId,
            this.name,
            this.brand,
            this.code,
            this.category,
            this.quantity,
            this.Stock_request,
            this.price,
            this.productActive,
            this.description});
            this.dataGridViewStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStock.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStock.MultiSelect = false;
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.RowHeadersVisible = false;
            this.dataGridViewStock.RowHeadersWidth = 21;
            this.dataGridViewStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStock.Size = new System.Drawing.Size(822, 405);
            this.dataGridViewStock.TabIndex = 0;
            // 
            // productId
            // 
            this.productId.HeaderText = "ID";
            this.productId.MinimumWidth = 6;
            this.productId.Name = "productId";
            this.productId.ReadOnly = true;
            this.productId.Width = 30;
            // 
            // name
            // 
            this.name.HeaderText = "Product Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 120;
            // 
            // brand
            // 
            this.brand.HeaderText = "Brand";
            this.brand.MinimumWidth = 6;
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            this.brand.Width = 120;
            // 
            // code
            // 
            this.code.HeaderText = "Code";
            this.code.MinimumWidth = 6;
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 60;
            // 
            // category
            // 
            this.category.HeaderText = "Category";
            this.category.MinimumWidth = 6;
            this.category.Name = "category";
            this.category.ReadOnly = true;
            this.category.Width = 125;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 50;
            // 
            // Stock_request
            // 
            this.Stock_request.HeaderText = "Stock Request";
            this.Stock_request.MinimumWidth = 6;
            this.Stock_request.Name = "Stock_request";
            this.Stock_request.ReadOnly = true;
            this.Stock_request.Width = 50;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 40;
            // 
            // productActive
            // 
            this.productActive.HeaderText = "Active";
            this.productActive.MinimumWidth = 6;
            this.productActive.Name = "productActive";
            this.productActive.ReadOnly = true;
            this.productActive.Width = 40;
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.description.HeaderText = "Description";
            this.description.MinimumWidth = 50;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // splitContainerStockSecondary
            // 
            this.splitContainerStockSecondary.BackColor = System.Drawing.Color.Snow;
            this.splitContainerStockSecondary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStockSecondary.Location = new System.Drawing.Point(0, 0);
            this.splitContainerStockSecondary.Name = "splitContainerStockSecondary";
            this.splitContainerStockSecondary.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerStockSecondary.Panel1
            // 
            this.splitContainerStockSecondary.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerStockSecondary.Panel1.Controls.Add(this.comboBoxStockCategory);
            this.splitContainerStockSecondary.Panel1.Controls.Add(this.buttonStockCategoryRemove);
            this.splitContainerStockSecondary.Panel1.Controls.Add(this.buttonStockCategoryAdd);
            this.splitContainerStockSecondary.Panel1.Controls.Add(this.label6);
            this.splitContainerStockSecondary.Panel1MinSize = 85;
            // 
            // splitContainerStockSecondary.Panel2
            // 
            this.splitContainerStockSecondary.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerStockSecondary.Panel2.Controls.Add(this.pnlDepotWorker);
            this.splitContainerStockSecondary.Panel2.Controls.Add(this.pnlSalesRepresentative);
            this.splitContainerStockSecondary.Panel2.Controls.Add(this.label5);
            this.splitContainerStockSecondary.Panel2.Controls.Add(this.checkBoxShowInactiveItems);
            this.splitContainerStockSecondary.Panel2.Controls.Add(this.buttonStockEditProduct);
            this.splitContainerStockSecondary.Panel2.Controls.Add(this.buttonStockAdd);
            this.splitContainerStockSecondary.Size = new System.Drawing.Size(299, 405);
            this.splitContainerStockSecondary.SplitterDistance = 85;
            this.splitContainerStockSecondary.TabIndex = 0;
            // 
            // comboBoxStockCategory
            // 
            this.comboBoxStockCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStockCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockCategory.Enabled = false;
            this.comboBoxStockCategory.FormattingEnabled = true;
            this.comboBoxStockCategory.Location = new System.Drawing.Point(6, 19);
            this.comboBoxStockCategory.Name = "comboBoxStockCategory";
            this.comboBoxStockCategory.Size = new System.Drawing.Size(288, 21);
            this.comboBoxStockCategory.TabIndex = 9;
            // 
            // buttonStockCategoryRemove
            // 
            this.buttonStockCategoryRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStockCategoryRemove.Enabled = false;
            this.buttonStockCategoryRemove.Location = new System.Drawing.Point(218, 45);
            this.buttonStockCategoryRemove.Name = "buttonStockCategoryRemove";
            this.buttonStockCategoryRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonStockCategoryRemove.TabIndex = 8;
            this.buttonStockCategoryRemove.Text = "Remove";
            this.buttonStockCategoryRemove.UseVisualStyleBackColor = true;
            // 
            // buttonStockCategoryAdd
            // 
            this.buttonStockCategoryAdd.Enabled = false;
            this.buttonStockCategoryAdd.Location = new System.Drawing.Point(6, 45);
            this.buttonStockCategoryAdd.Name = "buttonStockCategoryAdd";
            this.buttonStockCategoryAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonStockCategoryAdd.TabIndex = 7;
            this.buttonStockCategoryAdd.Text = "Add";
            this.buttonStockCategoryAdd.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Category name";
            // 
            // pnlDepotWorker
            // 
            this.pnlDepotWorker.Controls.Add(this.btnAcceptRestockRequest);
            this.pnlDepotWorker.Location = new System.Drawing.Point(149, 85);
            this.pnlDepotWorker.Name = "pnlDepotWorker";
            this.pnlDepotWorker.Size = new System.Drawing.Size(149, 44);
            this.pnlDepotWorker.TabIndex = 9;
            this.pnlDepotWorker.Visible = false;
            // 
            // btnAcceptRestockRequest
            // 
            this.btnAcceptRestockRequest.Location = new System.Drawing.Point(7, 7);
            this.btnAcceptRestockRequest.Name = "btnAcceptRestockRequest";
            this.btnAcceptRestockRequest.Size = new System.Drawing.Size(139, 24);
            this.btnAcceptRestockRequest.TabIndex = 0;
            this.btnAcceptRestockRequest.Text = "Accept restock request";
            this.btnAcceptRestockRequest.UseVisualStyleBackColor = true;
            this.btnAcceptRestockRequest.Click += new System.EventHandler(this.btnAcceptRestockRequest_Click);
            // 
            // pnlSalesRepresentative
            // 
            this.pnlSalesRepresentative.Controls.Add(this.btnSendRestockRequest);
            this.pnlSalesRepresentative.Location = new System.Drawing.Point(0, 85);
            this.pnlSalesRepresentative.Name = "pnlSalesRepresentative";
            this.pnlSalesRepresentative.Size = new System.Drawing.Size(147, 44);
            this.pnlSalesRepresentative.TabIndex = 8;
            this.pnlSalesRepresentative.Visible = false;
            // 
            // btnSendRestockRequest
            // 
            this.btnSendRestockRequest.Location = new System.Drawing.Point(2, 7);
            this.btnSendRestockRequest.Name = "btnSendRestockRequest";
            this.btnSendRestockRequest.Size = new System.Drawing.Size(141, 24);
            this.btnSendRestockRequest.TabIndex = 0;
            this.btnSendRestockRequest.Text = "File restock request";
            this.btnSendRestockRequest.UseVisualStyleBackColor = true;
            this.btnSendRestockRequest.Click += new System.EventHandler(this.btnSendRestockRequest_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Selected Product";
            // 
            // checkBoxShowInactiveItems
            // 
            this.checkBoxShowInactiveItems.AutoSize = true;
            this.checkBoxShowInactiveItems.Location = new System.Drawing.Point(6, 50);
            this.checkBoxShowInactiveItems.Name = "checkBoxShowInactiveItems";
            this.checkBoxShowInactiveItems.Size = new System.Drawing.Size(137, 17);
            this.checkBoxShowInactiveItems.TabIndex = 5;
            this.checkBoxShowInactiveItems.Text = "Show inactive products";
            this.checkBoxShowInactiveItems.UseVisualStyleBackColor = true;
            this.checkBoxShowInactiveItems.CheckedChanged += new System.EventHandler(this.checkBoxShowInactiveItems_CheckedChanged);
            // 
            // buttonStockEditProduct
            // 
            this.buttonStockEditProduct.Location = new System.Drawing.Point(2, 21);
            this.buttonStockEditProduct.Name = "buttonStockEditProduct";
            this.buttonStockEditProduct.Size = new System.Drawing.Size(141, 23);
            this.buttonStockEditProduct.TabIndex = 1;
            this.buttonStockEditProduct.Text = "View/Edit selected";
            this.buttonStockEditProduct.UseVisualStyleBackColor = true;
            this.buttonStockEditProduct.Click += new System.EventHandler(this.buttonStockEditProduct_Click);
            // 
            // buttonStockAdd
            // 
            this.buttonStockAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStockAdd.Location = new System.Drawing.Point(154, 21);
            this.buttonStockAdd.Name = "buttonStockAdd";
            this.buttonStockAdd.Size = new System.Drawing.Size(142, 23);
            this.buttonStockAdd.TabIndex = 2;
            this.buttonStockAdd.Text = "Add Product";
            this.buttonStockAdd.UseVisualStyleBackColor = true;
            this.buttonStockAdd.Click += new System.EventHandler(this.buttonStockAdd_Click);
            // 
            // tabPageEmployees
            // 
            this.tabPageEmployees.Controls.Add(this.splitContainerEmployeesPrimary);
            this.tabPageEmployees.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageEmployees.Size = new System.Drawing.Size(1131, 411);
            this.tabPageEmployees.TabIndex = 0;
            this.tabPageEmployees.Text = "Employees";
            this.tabPageEmployees.UseVisualStyleBackColor = true;
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
            this.splitContainerEmployeesPrimary.SplitterDistance = 822;
            this.splitContainerEmployeesPrimary.TabIndex = 0;
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.AllowUserToDeleteRows = false;
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.active,
            this.Function,
            this.firstName,
            this.surName,
            this.username,
            this.phoneNumber,
            this.emailAddress});
            this.dataGridViewEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.RowHeadersVisible = false;
            this.dataGridViewEmployees.RowHeadersWidth = 21;
            this.dataGridViewEmployees.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(822, 405);
            this.dataGridViewEmployees.TabIndex = 0;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // active
            // 
            this.active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.active.HeaderText = "Active";
            this.active.MinimumWidth = 6;
            this.active.Name = "active";
            this.active.ReadOnly = true;
            this.active.Width = 40;
            // 
            // Function
            // 
            this.Function.HeaderText = "Function";
            this.Function.MinimumWidth = 6;
            this.Function.Name = "Function";
            this.Function.ReadOnly = true;
            this.Function.Width = 105;
            // 
            // firstName
            // 
            this.firstName.HeaderText = "First Name";
            this.firstName.MinimumWidth = 6;
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            this.firstName.Width = 125;
            // 
            // surName
            // 
            this.surName.HeaderText = "Surname";
            this.surName.MinimumWidth = 6;
            this.surName.Name = "surName";
            this.surName.ReadOnly = true;
            this.surName.Width = 160;
            // 
            // username
            // 
            this.username.HeaderText = "Username";
            this.username.MinimumWidth = 6;
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 130;
            // 
            // phoneNumber
            // 
            this.phoneNumber.HeaderText = "Phone Number";
            this.phoneNumber.MinimumWidth = 6;
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.ReadOnly = true;
            this.phoneNumber.Width = 125;
            // 
            // emailAddress
            // 
            this.emailAddress.HeaderText = "Email";
            this.emailAddress.MinimumWidth = 6;
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.ReadOnly = true;
            this.emailAddress.Width = 129;
            // 
            // splitContainerEmployeesSecondary
            // 
            this.splitContainerEmployeesSecondary.BackColor = System.Drawing.Color.Snow;
            this.splitContainerEmployeesSecondary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEmployeesSecondary.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerEmployeesSecondary.IsSplitterFixed = true;
            this.splitContainerEmployeesSecondary.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEmployeesSecondary.Name = "splitContainerEmployeesSecondary";
            this.splitContainerEmployeesSecondary.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEmployeesSecondary.Panel1
            // 
            this.splitContainerEmployeesSecondary.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerEmployeesSecondary.Panel1.Controls.Add(this.comboBoxAllDepartments);
            this.splitContainerEmployeesSecondary.Panel1.Controls.Add(this.buttonEmployeesDepartmentRemove);
            this.splitContainerEmployeesSecondary.Panel1.Controls.Add(this.buttonEmployeesDepartmentAdd);
            this.splitContainerEmployeesSecondary.Panel1.Controls.Add(this.labelEmployeesDepartmentName);
            this.splitContainerEmployeesSecondary.Panel1MinSize = 85;
            // 
            // splitContainerEmployeesSecondary.Panel2
            // 
            this.splitContainerEmployeesSecondary.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.gbManagement);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.btnClockinOut);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.labelEmployeesSelected);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.buttonEmployeesAdd);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.buttonEmployeesRemove);
            this.splitContainerEmployeesSecondary.Panel2.Controls.Add(this.buttonEmployeeModify);
            this.splitContainerEmployeesSecondary.Size = new System.Drawing.Size(299, 405);
            this.splitContainerEmployeesSecondary.SplitterDistance = 85;
            this.splitContainerEmployeesSecondary.TabIndex = 0;
            // 
            // comboBoxAllDepartments
            // 
            this.comboBoxAllDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAllDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAllDepartments.FormattingEnabled = true;
            this.comboBoxAllDepartments.Location = new System.Drawing.Point(6, 19);
            this.comboBoxAllDepartments.Name = "comboBoxAllDepartments";
            this.comboBoxAllDepartments.Size = new System.Drawing.Size(288, 21);
            this.comboBoxAllDepartments.TabIndex = 5;
            // 
            // buttonEmployeesDepartmentRemove
            // 
            this.buttonEmployeesDepartmentRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployeesDepartmentRemove.Location = new System.Drawing.Point(218, 45);
            this.buttonEmployeesDepartmentRemove.Name = "buttonEmployeesDepartmentRemove";
            this.buttonEmployeesDepartmentRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonEmployeesDepartmentRemove.TabIndex = 3;
            this.buttonEmployeesDepartmentRemove.Text = "Remove";
            this.buttonEmployeesDepartmentRemove.UseVisualStyleBackColor = true;
            this.buttonEmployeesDepartmentRemove.Click += new System.EventHandler(this.buttonEmployeesDepartmentRemove_Click);
            // 
            // buttonEmployeesDepartmentAdd
            // 
            this.buttonEmployeesDepartmentAdd.Location = new System.Drawing.Point(6, 45);
            this.buttonEmployeesDepartmentAdd.Name = "buttonEmployeesDepartmentAdd";
            this.buttonEmployeesDepartmentAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonEmployeesDepartmentAdd.TabIndex = 2;
            this.buttonEmployeesDepartmentAdd.Text = "Add";
            this.buttonEmployeesDepartmentAdd.UseVisualStyleBackColor = true;
            this.buttonEmployeesDepartmentAdd.Click += new System.EventHandler(this.buttonEmployeesDepartmentAdd_Click);
            // 
            // labelEmployeesDepartmentName
            // 
            this.labelEmployeesDepartmentName.AutoSize = true;
            this.labelEmployeesDepartmentName.Location = new System.Drawing.Point(6, 3);
            this.labelEmployeesDepartmentName.Name = "labelEmployeesDepartmentName";
            this.labelEmployeesDepartmentName.Size = new System.Drawing.Size(91, 13);
            this.labelEmployeesDepartmentName.TabIndex = 0;
            this.labelEmployeesDepartmentName.Text = "Department name";
            // 
            // gbManagement
            // 
            this.gbManagement.Controls.Add(this.flowLayoutPanel2);
            this.gbManagement.Location = new System.Drawing.Point(9, 98);
            this.gbManagement.Name = "gbManagement";
            this.gbManagement.Size = new System.Drawing.Size(178, 96);
            this.gbManagement.TabIndex = 8;
            this.gbManagement.TabStop = false;
            this.gbManagement.Text = "Management";
            // 
            // btnClockinOut
            // 
            this.btnClockinOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClockinOut.Location = new System.Drawing.Point(9, 50);
            this.btnClockinOut.Name = "btnClockinOut";
            this.btnClockinOut.Size = new System.Drawing.Size(95, 24);
            this.btnClockinOut.TabIndex = 6;
            this.btnClockinOut.Text = "Clock in/out";
            this.btnClockinOut.UseVisualStyleBackColor = true;
            this.btnClockinOut.Click += new System.EventHandler(this.btnClockinOut_Click);
            // 
            // labelEmployeesSelected
            // 
            this.labelEmployeesSelected.AutoSize = true;
            this.labelEmployeesSelected.Location = new System.Drawing.Point(6, 5);
            this.labelEmployeesSelected.Name = "labelEmployeesSelected";
            this.labelEmployeesSelected.Size = new System.Drawing.Size(98, 13);
            this.labelEmployeesSelected.TabIndex = 3;
            this.labelEmployeesSelected.Text = "Selected Employee";
            // 
            // buttonEmployeesAdd
            // 
            this.buttonEmployeesAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployeesAdd.Location = new System.Drawing.Point(154, 21);
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
            this.buttonEmployeesRemove.Location = new System.Drawing.Point(3, 309);
            this.buttonEmployeesRemove.Name = "buttonEmployeesRemove";
            this.buttonEmployeesRemove.Size = new System.Drawing.Size(290, 23);
            this.buttonEmployeesRemove.TabIndex = 1;
            this.buttonEmployeesRemove.Text = "Remove selected employee";
            this.buttonEmployeesRemove.UseVisualStyleBackColor = true;
            // 
            // buttonEmployeeModify
            // 
            this.buttonEmployeeModify.Location = new System.Drawing.Point(8, 21);
            this.buttonEmployeeModify.Name = "buttonEmployeeModify";
            this.buttonEmployeeModify.Size = new System.Drawing.Size(141, 23);
            this.buttonEmployeeModify.TabIndex = 0;
            this.buttonEmployeeModify.Text = "View/Edit selected employee";
            this.buttonEmployeeModify.UseVisualStyleBackColor = true;
            this.buttonEmployeeModify.Click += new System.EventHandler(this.buttonEmployeeModify_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageEmployees);
            this.tabControl1.Controls.Add(this.tabPageStock);
            this.tabControl1.Controls.Add(this.tabPageStatistics);
            this.tabControl1.Controls.Add(this.tabPageScheduling);
            this.tabControl1.Controls.Add(this.tabPageRequests);
            this.tabControl1.Location = new System.Drawing.Point(10, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1139, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageRequests
            // 
            this.tabPageRequests.Controls.Add(this.btnPermit);
            this.tabPageRequests.Controls.Add(this.btnTurnDown);
            this.tabPageRequests.Controls.Add(this.lbxRequests);
            this.tabPageRequests.Location = new System.Drawing.Point(4, 22);
            this.tabPageRequests.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageRequests.Name = "tabPageRequests";
            this.tabPageRequests.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageRequests.Size = new System.Drawing.Size(1131, 411);
            this.tabPageRequests.TabIndex = 4;
            this.tabPageRequests.Text = "Requests";
            this.tabPageRequests.UseVisualStyleBackColor = true;
            // 
            // btnPermit
            // 
            this.btnPermit.BackColor = System.Drawing.SystemColors.Control;
            this.btnPermit.Location = new System.Drawing.Point(933, 65);
            this.btnPermit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPermit.Name = "btnPermit";
            this.btnPermit.Size = new System.Drawing.Size(82, 29);
            this.btnPermit.TabIndex = 0;
            this.btnPermit.Text = "Approve";
            this.btnPermit.UseVisualStyleBackColor = false;
            this.btnPermit.Click += new System.EventHandler(this.btnPermit_Click);
            // 
            // btnTurnDown
            // 
            this.btnTurnDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnTurnDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTurnDown.Location = new System.Drawing.Point(933, 161);
            this.btnTurnDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTurnDown.Name = "btnTurnDown";
            this.btnTurnDown.Size = new System.Drawing.Size(82, 29);
            this.btnTurnDown.TabIndex = 0;
            this.btnTurnDown.Text = "Deny";
            this.btnTurnDown.UseVisualStyleBackColor = false;
            this.btnTurnDown.Click += new System.EventHandler(this.btnTurnDown_Click);
            // 
            // lbxRequests
            // 
            this.lbxRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxRequests.FormattingEnabled = true;
            this.lbxRequests.ItemHeight = 18;
            this.lbxRequests.Location = new System.Drawing.Point(3, 3);
            this.lbxRequests.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbxRequests.Name = "lbxRequests";
            this.lbxRequests.Size = new System.Drawing.Size(825, 400);
            this.lbxRequests.TabIndex = 0;
            // 
            // buttonEditFunctionPermissions
            // 
            this.buttonEditFunctionPermissions.Location = new System.Drawing.Point(4, 27);
            this.buttonEditFunctionPermissions.Name = "buttonEditFunctionPermissions";
            this.buttonEditFunctionPermissions.Size = new System.Drawing.Size(141, 23);
            this.buttonEditFunctionPermissions.TabIndex = 5;
            this.buttonEditFunctionPermissions.Text = "Edit function permissions";
            this.buttonEditFunctionPermissions.UseVisualStyleBackColor = true;
            this.buttonEditFunctionPermissions.Click += new System.EventHandler(this.buttonEditFunctionPermissions_Click);
            // 
            // checkBoxShowInactive
            // 
            this.checkBoxShowInactive.AutoSize = true;
            this.checkBoxShowInactive.Location = new System.Drawing.Point(4, 4);
            this.checkBoxShowInactive.Name = "checkBoxShowInactive";
            this.checkBoxShowInactive.Size = new System.Drawing.Size(146, 17);
            this.checkBoxShowInactive.TabIndex = 4;
            this.checkBoxShowInactive.Text = "Show inactive employees";
            this.checkBoxShowInactive.UseVisualStyleBackColor = true;
            this.checkBoxShowInactive.CheckedChanged += new System.EventHandler(this.checkBoxShowInactive_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.checkBoxShowInactive);
            this.flowLayoutPanel2.Controls.Add(this.buttonEditFunctionPermissions);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(159, 68);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // groupBoxExportData
            // 
            this.groupBoxExportData.Controls.Add(this.flowLayoutPanel3);
            this.groupBoxExportData.Location = new System.Drawing.Point(5, 193);
            this.groupBoxExportData.Name = "groupBoxExportData";
            this.groupBoxExportData.Size = new System.Drawing.Size(178, 81);
            this.groupBoxExportData.TabIndex = 15;
            this.groupBoxExportData.TabStop = false;
            this.groupBoxExportData.Text = "Export Data";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label7);
            this.flowLayoutPanel3.Controls.Add(this.cmbxWeekNumber);
            this.flowLayoutPanel3.Controls.Add(this.btnExportData);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(172, 62);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 4);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Select week number:";
            // 
            // cmbxWeekNumber
            // 
            this.cmbxWeekNumber.FormattingEnabled = true;
            this.cmbxWeekNumber.Location = new System.Drawing.Point(117, 6);
            this.cmbxWeekNumber.Margin = new System.Windows.Forms.Padding(2);
            this.cmbxWeekNumber.Name = "cmbxWeekNumber";
            this.cmbxWeekNumber.Size = new System.Drawing.Size(38, 21);
            this.cmbxWeekNumber.TabIndex = 10;
            // 
            // btnExportData
            // 
            this.btnExportData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportData.Location = new System.Drawing.Point(6, 31);
            this.btnExportData.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(71, 20);
            this.btnExportData.TabIndex = 9;
            this.btnExportData.Text = "Export data";
            this.btnExportData.UseVisualStyleBackColor = true;
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1159, 461);
            this.Controls.Add(this.buttonReloadDatabaseEntries);
            this.Controls.Add(this.labelWelcomeText);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Media Bazaar Management System";
            this.tabPageScheduling.ResumeLayout(false);
            this.splitContainerScheduling1.Panel1.ResumeLayout(false);
            this.splitContainerScheduling1.Panel1.PerformLayout();
            this.splitContainerScheduling1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScheduling1)).EndInit();
            this.splitContainerScheduling1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSchedulingWeek)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabPageStatistics.ResumeLayout(false);
            this.splitContainerStatistics1.Panel1.ResumeLayout(false);
            this.splitContainerStatistics1.Panel2.ResumeLayout(false);
            this.splitContainerStatistics1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatistics1)).EndInit();
            this.splitContainerStatistics1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatisticChart)).EndInit();
            this.tabPageStock.ResumeLayout(false);
            this.splitContainerStockPrimary.Panel1.ResumeLayout(false);
            this.splitContainerStockPrimary.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStockPrimary)).EndInit();
            this.splitContainerStockPrimary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            this.splitContainerStockSecondary.Panel1.ResumeLayout(false);
            this.splitContainerStockSecondary.Panel1.PerformLayout();
            this.splitContainerStockSecondary.Panel2.ResumeLayout(false);
            this.splitContainerStockSecondary.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStockSecondary)).EndInit();
            this.splitContainerStockSecondary.ResumeLayout(false);
            this.pnlDepotWorker.ResumeLayout(false);
            this.pnlSalesRepresentative.ResumeLayout(false);
            this.tabPageEmployees.ResumeLayout(false);
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
            this.gbManagement.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRequests.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBoxExportData.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelWelcomeText;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn bsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn spousePhoneNumber;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Button buttonReloadDatabaseEntries;
        private System.Windows.Forms.ToolTip toolTipReloadDb;
        private System.Windows.Forms.TabPage tabPageScheduling;
        private System.Windows.Forms.SplitContainer splitContainerScheduling1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSchedulingDepartment;
        private System.Windows.Forms.Button buttonSchedulingNext;
        private System.Windows.Forms.Button buttonSchedulingPrevious;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSetWeekShiftsCapacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSchedulingWeek;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CalendarDayControl calendarDayControlMonday;
        private CalendarDayControl calendarDayControlTuesday;
        private CalendarDayControl calendarDayControlWednesday;
        private CalendarDayControl calendarDayControlThursday;
        private CalendarDayControl calendarDayControlFriday;
        private CalendarDayControl calendarDayControlSaturday;
        private CalendarDayControl calendarDayControlSunday;
        private System.Windows.Forms.TabPage tabPageStatistics;
        private System.Windows.Forms.SplitContainer splitContainerStatistics1;
        private System.Windows.Forms.DataVisualization.Charting.Chart StatisticChart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStatisticsEmployee;
        private System.Windows.Forms.ComboBox comboBoxStatisticsEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStatisticsDepartment;
        private System.Windows.Forms.ComboBox comboBoxStatisticsDepartment;
        private System.Windows.Forms.TabPage tabPageStock;
        private System.Windows.Forms.SplitContainer splitContainerStockPrimary;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock_request;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn productActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.SplitContainer splitContainerStockSecondary;
        private System.Windows.Forms.ComboBox comboBoxStockCategory;
        private System.Windows.Forms.Button buttonStockCategoryRemove;
        private System.Windows.Forms.Button buttonStockCategoryAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlDepotWorker;
        private System.Windows.Forms.Button btnAcceptRestockRequest;
        private System.Windows.Forms.Panel pnlSalesRepresentative;
        private System.Windows.Forms.Button btnSendRestockRequest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxShowInactiveItems;
        private System.Windows.Forms.Button buttonStockEditProduct;
        private System.Windows.Forms.Button buttonStockAdd;
        private System.Windows.Forms.TabPage tabPageEmployees;
        private System.Windows.Forms.SplitContainer splitContainerEmployeesPrimary;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.SplitContainer splitContainerEmployeesSecondary;
        private System.Windows.Forms.ComboBox comboBoxAllDepartments;
        private System.Windows.Forms.Button buttonEmployeesDepartmentRemove;
        private System.Windows.Forms.Button buttonEmployeesDepartmentAdd;
        private System.Windows.Forms.Label labelEmployeesDepartmentName;
        private System.Windows.Forms.GroupBox gbManagement;
        private System.Windows.Forms.Button btnClockinOut;
        private System.Windows.Forms.Label labelEmployeesSelected;
        private System.Windows.Forms.Button buttonEmployeesAdd;
        private System.Windows.Forms.Button buttonEmployeesRemove;
        private System.Windows.Forms.Button buttonEmployeeModify;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonAutomaticScheduling;
        private System.Windows.Forms.ProgressBar progressBarSchedulingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
        private System.Windows.Forms.DataGridViewTextBoxColumn Function;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn surName;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAddress;
        private System.Windows.Forms.TabPage tabPageRequests;
        private System.Windows.Forms.ListBox lbxRequests;
        private System.Windows.Forms.Button btnTurnDown;
        private System.Windows.Forms.Button btnPermit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBoxShowInactive;
        private System.Windows.Forms.Button buttonEditFunctionPermissions;
        private System.Windows.Forms.GroupBox groupBoxExportData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbxWeekNumber;
        private System.Windows.Forms.Button btnExportData;
    }
}

