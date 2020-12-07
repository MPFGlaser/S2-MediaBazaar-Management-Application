
namespace MediaBazaar_ManagementSystem
{
    partial class PermissionSelectionWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelGeneral = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxGeneralLoginApplication = new System.Windows.Forms.CheckBox();
            this.checkBoxGeneralLoginWebsite = new System.Windows.Forms.CheckBox();
            this.checkBoxGeneralClockInOut = new System.Windows.Forms.CheckBox();
            this.groupBoxEmployeeManagement = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelEmployeeManagement = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxEmployeesView = new System.Windows.Forms.CheckBox();
            this.checkBoxEmployeesEdit = new System.Windows.Forms.CheckBox();
            this.checkBoxEmployeesAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxEmployeesActive = new System.Windows.Forms.CheckBox();
            this.groupBoxStockManagement = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelStockManagement = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxProductsView = new System.Windows.Forms.CheckBox();
            this.checkBoxProductsEdit = new System.Windows.Forms.CheckBox();
            this.checkBoxProductsAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxProductsActive = new System.Windows.Forms.CheckBox();
            this.checkBoxProductsRestockFile = new System.Windows.Forms.CheckBox();
            this.checkBoxProductsRestockAccept = new System.Windows.Forms.CheckBox();
            this.groupBoxDepartmentManagement = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelDepartmentManagement = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxDepartmentsView = new System.Windows.Forms.CheckBox();
            this.checkBoxDepartmentsEdit = new System.Windows.Forms.CheckBox();
            this.checkBoxDepartmentsAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxDepartmentsChangeActive = new System.Windows.Forms.CheckBox();
            this.groupBoxFunctionManagement = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunctionManagement = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxFunctionsAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxFunctionsEdit = new System.Windows.Forms.CheckBox();
            this.groupBoxScheduling = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelScheduling = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxSchedulingScheduleEmployees = new System.Windows.Forms.CheckBox();
            this.checkBoxSchedulingUnscheduleEmployees = new System.Windows.Forms.CheckBox();
            this.checkBoxSchedulingShiftCapacity = new System.Windows.Forms.CheckBox();
            this.groupBoxSwapping = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelSwapping = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxSwappingAccept = new System.Windows.Forms.CheckBox();
            this.checkBoxSwappingRequest = new System.Windows.Forms.CheckBox();
            this.checkBoxSwappingApprove = new System.Windows.Forms.CheckBox();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelStatistics = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxStatisticsView = new System.Windows.Forms.CheckBox();
            this.comboBoxCurrentFunction = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel.SuspendLayout();
            this.groupBoxGeneral.SuspendLayout();
            this.flowLayoutPanelGeneral.SuspendLayout();
            this.groupBoxEmployeeManagement.SuspendLayout();
            this.flowLayoutPanelEmployeeManagement.SuspendLayout();
            this.groupBoxStockManagement.SuspendLayout();
            this.flowLayoutPanelStockManagement.SuspendLayout();
            this.groupBoxDepartmentManagement.SuspendLayout();
            this.flowLayoutPanelDepartmentManagement.SuspendLayout();
            this.groupBoxFunctionManagement.SuspendLayout();
            this.flowLayoutPanelFunctionManagement.SuspendLayout();
            this.groupBoxScheduling.SuspendLayout();
            this.flowLayoutPanelScheduling.SuspendLayout();
            this.groupBoxSwapping.SuspendLayout();
            this.flowLayoutPanelSwapping.SuspendLayout();
            this.groupBoxStatistics.SuspendLayout();
            this.flowLayoutPanelStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current function";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.groupBoxGeneral);
            this.flowLayoutPanel.Controls.Add(this.groupBoxEmployeeManagement);
            this.flowLayoutPanel.Controls.Add(this.groupBoxStockManagement);
            this.flowLayoutPanel.Controls.Add(this.groupBoxDepartmentManagement);
            this.flowLayoutPanel.Controls.Add(this.groupBoxFunctionManagement);
            this.flowLayoutPanel.Controls.Add(this.groupBoxScheduling);
            this.flowLayoutPanel.Controls.Add(this.groupBoxSwapping);
            this.flowLayoutPanel.Controls.Add(this.groupBoxStatistics);
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 33);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(715, 444);
            this.flowLayoutPanel.TabIndex = 3;
            this.flowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel_Paint);
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.AutoSize = true;
            this.groupBoxGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxGeneral.Controls.Add(this.flowLayoutPanelGeneral);
            this.groupBoxGeneral.Location = new System.Drawing.Point(3, 3);
            this.groupBoxGeneral.MinimumSize = new System.Drawing.Size(225, 0);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(225, 88);
            this.groupBoxGeneral.TabIndex = 0;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "General";
            // 
            // flowLayoutPanelGeneral
            // 
            this.flowLayoutPanelGeneral.AutoSize = true;
            this.flowLayoutPanelGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelGeneral.Controls.Add(this.checkBoxGeneralLoginApplication);
            this.flowLayoutPanelGeneral.Controls.Add(this.checkBoxGeneralLoginWebsite);
            this.flowLayoutPanelGeneral.Controls.Add(this.checkBoxGeneralClockInOut);
            this.flowLayoutPanelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelGeneral.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelGeneral.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelGeneral.Name = "flowLayoutPanelGeneral";
            this.flowLayoutPanelGeneral.Size = new System.Drawing.Size(219, 69);
            this.flowLayoutPanelGeneral.TabIndex = 3;
            // 
            // checkBoxGeneralLoginApplication
            // 
            this.checkBoxGeneralLoginApplication.AutoSize = true;
            this.checkBoxGeneralLoginApplication.Location = new System.Drawing.Point(3, 3);
            this.checkBoxGeneralLoginApplication.Name = "checkBoxGeneralLoginApplication";
            this.checkBoxGeneralLoginApplication.Size = new System.Drawing.Size(103, 17);
            this.checkBoxGeneralLoginApplication.TabIndex = 0;
            this.checkBoxGeneralLoginApplication.Text = "Application login";
            this.checkBoxGeneralLoginApplication.UseVisualStyleBackColor = true;
            // 
            // checkBoxGeneralLoginWebsite
            // 
            this.checkBoxGeneralLoginWebsite.AutoSize = true;
            this.checkBoxGeneralLoginWebsite.Location = new System.Drawing.Point(3, 26);
            this.checkBoxGeneralLoginWebsite.Name = "checkBoxGeneralLoginWebsite";
            this.checkBoxGeneralLoginWebsite.Size = new System.Drawing.Size(90, 17);
            this.checkBoxGeneralLoginWebsite.TabIndex = 1;
            this.checkBoxGeneralLoginWebsite.Text = "Website login";
            this.checkBoxGeneralLoginWebsite.UseVisualStyleBackColor = true;
            // 
            // checkBoxGeneralClockInOut
            // 
            this.checkBoxGeneralClockInOut.AutoSize = true;
            this.checkBoxGeneralClockInOut.Location = new System.Drawing.Point(3, 49);
            this.checkBoxGeneralClockInOut.Name = "checkBoxGeneralClockInOut";
            this.checkBoxGeneralClockInOut.Size = new System.Drawing.Size(84, 17);
            this.checkBoxGeneralClockInOut.TabIndex = 2;
            this.checkBoxGeneralClockInOut.Text = "Clock in/out";
            this.checkBoxGeneralClockInOut.UseVisualStyleBackColor = true;
            // 
            // groupBoxEmployeeManagement
            // 
            this.groupBoxEmployeeManagement.AutoSize = true;
            this.groupBoxEmployeeManagement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxEmployeeManagement.Controls.Add(this.flowLayoutPanelEmployeeManagement);
            this.groupBoxEmployeeManagement.Location = new System.Drawing.Point(234, 3);
            this.groupBoxEmployeeManagement.MinimumSize = new System.Drawing.Size(225, 0);
            this.groupBoxEmployeeManagement.Name = "groupBoxEmployeeManagement";
            this.groupBoxEmployeeManagement.Size = new System.Drawing.Size(225, 111);
            this.groupBoxEmployeeManagement.TabIndex = 1;
            this.groupBoxEmployeeManagement.TabStop = false;
            this.groupBoxEmployeeManagement.Text = "Employee management";
            // 
            // flowLayoutPanelEmployeeManagement
            // 
            this.flowLayoutPanelEmployeeManagement.AutoSize = true;
            this.flowLayoutPanelEmployeeManagement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelEmployeeManagement.Controls.Add(this.checkBoxEmployeesView);
            this.flowLayoutPanelEmployeeManagement.Controls.Add(this.checkBoxEmployeesEdit);
            this.flowLayoutPanelEmployeeManagement.Controls.Add(this.checkBoxEmployeesAdd);
            this.flowLayoutPanelEmployeeManagement.Controls.Add(this.checkBoxEmployeesActive);
            this.flowLayoutPanelEmployeeManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelEmployeeManagement.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelEmployeeManagement.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelEmployeeManagement.Name = "flowLayoutPanelEmployeeManagement";
            this.flowLayoutPanelEmployeeManagement.Size = new System.Drawing.Size(219, 92);
            this.flowLayoutPanelEmployeeManagement.TabIndex = 6;
            // 
            // checkBoxEmployeesView
            // 
            this.checkBoxEmployeesView.AutoSize = true;
            this.checkBoxEmployeesView.Location = new System.Drawing.Point(3, 3);
            this.checkBoxEmployeesView.Name = "checkBoxEmployeesView";
            this.checkBoxEmployeesView.Size = new System.Drawing.Size(102, 17);
            this.checkBoxEmployeesView.TabIndex = 2;
            this.checkBoxEmployeesView.Text = "View employees";
            this.checkBoxEmployeesView.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmployeesEdit
            // 
            this.checkBoxEmployeesEdit.AutoSize = true;
            this.checkBoxEmployeesEdit.Location = new System.Drawing.Point(3, 26);
            this.checkBoxEmployeesEdit.Name = "checkBoxEmployeesEdit";
            this.checkBoxEmployeesEdit.Size = new System.Drawing.Size(97, 17);
            this.checkBoxEmployeesEdit.TabIndex = 3;
            this.checkBoxEmployeesEdit.Text = "Edit employees";
            this.checkBoxEmployeesEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmployeesAdd
            // 
            this.checkBoxEmployeesAdd.AutoSize = true;
            this.checkBoxEmployeesAdd.Location = new System.Drawing.Point(3, 49);
            this.checkBoxEmployeesAdd.Name = "checkBoxEmployeesAdd";
            this.checkBoxEmployeesAdd.Size = new System.Drawing.Size(98, 17);
            this.checkBoxEmployeesAdd.TabIndex = 4;
            this.checkBoxEmployeesAdd.Text = "Add employees";
            this.checkBoxEmployeesAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmployeesActive
            // 
            this.checkBoxEmployeesActive.AutoSize = true;
            this.checkBoxEmployeesActive.Location = new System.Drawing.Point(3, 72);
            this.checkBoxEmployeesActive.Name = "checkBoxEmployeesActive";
            this.checkBoxEmployeesActive.Size = new System.Drawing.Size(191, 17);
            this.checkBoxEmployeesActive.TabIndex = 5;
            this.checkBoxEmployeesActive.Text = "Change employee\'s \"active\" status";
            this.checkBoxEmployeesActive.UseVisualStyleBackColor = true;
            // 
            // groupBoxStockManagement
            // 
            this.groupBoxStockManagement.AutoSize = true;
            this.groupBoxStockManagement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxStockManagement.Controls.Add(this.flowLayoutPanelStockManagement);
            this.groupBoxStockManagement.Location = new System.Drawing.Point(465, 3);
            this.groupBoxStockManagement.MinimumSize = new System.Drawing.Size(225, 0);
            this.groupBoxStockManagement.Name = "groupBoxStockManagement";
            this.groupBoxStockManagement.Size = new System.Drawing.Size(225, 157);
            this.groupBoxStockManagement.TabIndex = 2;
            this.groupBoxStockManagement.TabStop = false;
            this.groupBoxStockManagement.Text = "Stock management";
            // 
            // flowLayoutPanelStockManagement
            // 
            this.flowLayoutPanelStockManagement.AutoSize = true;
            this.flowLayoutPanelStockManagement.Controls.Add(this.checkBoxProductsView);
            this.flowLayoutPanelStockManagement.Controls.Add(this.checkBoxProductsEdit);
            this.flowLayoutPanelStockManagement.Controls.Add(this.checkBoxProductsAdd);
            this.flowLayoutPanelStockManagement.Controls.Add(this.checkBoxProductsActive);
            this.flowLayoutPanelStockManagement.Controls.Add(this.checkBoxProductsRestockFile);
            this.flowLayoutPanelStockManagement.Controls.Add(this.checkBoxProductsRestockAccept);
            this.flowLayoutPanelStockManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelStockManagement.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelStockManagement.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelStockManagement.Name = "flowLayoutPanelStockManagement";
            this.flowLayoutPanelStockManagement.Size = new System.Drawing.Size(219, 138);
            this.flowLayoutPanelStockManagement.TabIndex = 12;
            // 
            // checkBoxProductsView
            // 
            this.checkBoxProductsView.AutoSize = true;
            this.checkBoxProductsView.Location = new System.Drawing.Point(3, 3);
            this.checkBoxProductsView.Name = "checkBoxProductsView";
            this.checkBoxProductsView.Size = new System.Drawing.Size(93, 17);
            this.checkBoxProductsView.TabIndex = 6;
            this.checkBoxProductsView.Text = "View products";
            this.checkBoxProductsView.UseVisualStyleBackColor = true;
            // 
            // checkBoxProductsEdit
            // 
            this.checkBoxProductsEdit.AutoSize = true;
            this.checkBoxProductsEdit.Location = new System.Drawing.Point(3, 26);
            this.checkBoxProductsEdit.Name = "checkBoxProductsEdit";
            this.checkBoxProductsEdit.Size = new System.Drawing.Size(88, 17);
            this.checkBoxProductsEdit.TabIndex = 7;
            this.checkBoxProductsEdit.Text = "Edit products";
            this.checkBoxProductsEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxProductsAdd
            // 
            this.checkBoxProductsAdd.AutoSize = true;
            this.checkBoxProductsAdd.Location = new System.Drawing.Point(3, 49);
            this.checkBoxProductsAdd.Name = "checkBoxProductsAdd";
            this.checkBoxProductsAdd.Size = new System.Drawing.Size(89, 17);
            this.checkBoxProductsAdd.TabIndex = 8;
            this.checkBoxProductsAdd.Text = "Add products";
            this.checkBoxProductsAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxProductsActive
            // 
            this.checkBoxProductsActive.AutoSize = true;
            this.checkBoxProductsActive.Location = new System.Drawing.Point(3, 72);
            this.checkBoxProductsActive.Name = "checkBoxProductsActive";
            this.checkBoxProductsActive.Size = new System.Drawing.Size(182, 17);
            this.checkBoxProductsActive.TabIndex = 9;
            this.checkBoxProductsActive.Text = "Change product\'s \"active\" status";
            this.checkBoxProductsActive.UseVisualStyleBackColor = true;
            // 
            // checkBoxProductsRestockFile
            // 
            this.checkBoxProductsRestockFile.AutoSize = true;
            this.checkBoxProductsRestockFile.Location = new System.Drawing.Point(3, 95);
            this.checkBoxProductsRestockFile.Name = "checkBoxProductsRestockFile";
            this.checkBoxProductsRestockFile.Size = new System.Drawing.Size(118, 17);
            this.checkBoxProductsRestockFile.TabIndex = 10;
            this.checkBoxProductsRestockFile.Text = "File restock request";
            this.checkBoxProductsRestockFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxProductsRestockAccept
            // 
            this.checkBoxProductsRestockAccept.AutoSize = true;
            this.checkBoxProductsRestockAccept.Location = new System.Drawing.Point(3, 118);
            this.checkBoxProductsRestockAccept.Name = "checkBoxProductsRestockAccept";
            this.checkBoxProductsRestockAccept.Size = new System.Drawing.Size(136, 17);
            this.checkBoxProductsRestockAccept.TabIndex = 11;
            this.checkBoxProductsRestockAccept.Text = "Accept restock request";
            this.checkBoxProductsRestockAccept.UseVisualStyleBackColor = true;
            // 
            // groupBoxDepartmentManagement
            // 
            this.groupBoxDepartmentManagement.AutoSize = true;
            this.groupBoxDepartmentManagement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxDepartmentManagement.Controls.Add(this.flowLayoutPanelDepartmentManagement);
            this.groupBoxDepartmentManagement.Location = new System.Drawing.Point(3, 166);
            this.groupBoxDepartmentManagement.MinimumSize = new System.Drawing.Size(225, 0);
            this.groupBoxDepartmentManagement.Name = "groupBoxDepartmentManagement";
            this.groupBoxDepartmentManagement.Size = new System.Drawing.Size(225, 111);
            this.groupBoxDepartmentManagement.TabIndex = 3;
            this.groupBoxDepartmentManagement.TabStop = false;
            this.groupBoxDepartmentManagement.Text = "Department management";
            // 
            // flowLayoutPanelDepartmentManagement
            // 
            this.flowLayoutPanelDepartmentManagement.AutoSize = true;
            this.flowLayoutPanelDepartmentManagement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelDepartmentManagement.Controls.Add(this.checkBoxDepartmentsView);
            this.flowLayoutPanelDepartmentManagement.Controls.Add(this.checkBoxDepartmentsEdit);
            this.flowLayoutPanelDepartmentManagement.Controls.Add(this.checkBoxDepartmentsAdd);
            this.flowLayoutPanelDepartmentManagement.Controls.Add(this.checkBoxDepartmentsChangeActive);
            this.flowLayoutPanelDepartmentManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelDepartmentManagement.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelDepartmentManagement.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelDepartmentManagement.Name = "flowLayoutPanelDepartmentManagement";
            this.flowLayoutPanelDepartmentManagement.Size = new System.Drawing.Size(219, 92);
            this.flowLayoutPanelDepartmentManagement.TabIndex = 2;
            // 
            // checkBoxDepartmentsView
            // 
            this.checkBoxDepartmentsView.AutoSize = true;
            this.checkBoxDepartmentsView.Location = new System.Drawing.Point(3, 3);
            this.checkBoxDepartmentsView.Name = "checkBoxDepartmentsView";
            this.checkBoxDepartmentsView.Size = new System.Drawing.Size(110, 17);
            this.checkBoxDepartmentsView.TabIndex = 0;
            this.checkBoxDepartmentsView.Text = "View departments";
            this.checkBoxDepartmentsView.UseVisualStyleBackColor = true;
            // 
            // checkBoxDepartmentsEdit
            // 
            this.checkBoxDepartmentsEdit.AutoSize = true;
            this.checkBoxDepartmentsEdit.Location = new System.Drawing.Point(3, 26);
            this.checkBoxDepartmentsEdit.Name = "checkBoxDepartmentsEdit";
            this.checkBoxDepartmentsEdit.Size = new System.Drawing.Size(105, 17);
            this.checkBoxDepartmentsEdit.TabIndex = 1;
            this.checkBoxDepartmentsEdit.Text = "Edit departments";
            this.checkBoxDepartmentsEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxDepartmentsAdd
            // 
            this.checkBoxDepartmentsAdd.AutoSize = true;
            this.checkBoxDepartmentsAdd.Location = new System.Drawing.Point(3, 49);
            this.checkBoxDepartmentsAdd.Name = "checkBoxDepartmentsAdd";
            this.checkBoxDepartmentsAdd.Size = new System.Drawing.Size(106, 17);
            this.checkBoxDepartmentsAdd.TabIndex = 2;
            this.checkBoxDepartmentsAdd.Text = "Add departments";
            this.checkBoxDepartmentsAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxDepartmentsChangeActive
            // 
            this.checkBoxDepartmentsChangeActive.AutoSize = true;
            this.checkBoxDepartmentsChangeActive.Location = new System.Drawing.Point(3, 72);
            this.checkBoxDepartmentsChangeActive.Name = "checkBoxDepartmentsChangeActive";
            this.checkBoxDepartmentsChangeActive.Size = new System.Drawing.Size(199, 17);
            this.checkBoxDepartmentsChangeActive.TabIndex = 3;
            this.checkBoxDepartmentsChangeActive.Text = "Change department\'s \"active\" status";
            this.checkBoxDepartmentsChangeActive.UseVisualStyleBackColor = true;
            // 
            // groupBoxFunctionManagement
            // 
            this.groupBoxFunctionManagement.AutoSize = true;
            this.groupBoxFunctionManagement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFunctionManagement.Controls.Add(this.flowLayoutPanelFunctionManagement);
            this.groupBoxFunctionManagement.Location = new System.Drawing.Point(234, 166);
            this.groupBoxFunctionManagement.MinimumSize = new System.Drawing.Size(225, 0);
            this.groupBoxFunctionManagement.Name = "groupBoxFunctionManagement";
            this.groupBoxFunctionManagement.Size = new System.Drawing.Size(225, 65);
            this.groupBoxFunctionManagement.TabIndex = 4;
            this.groupBoxFunctionManagement.TabStop = false;
            this.groupBoxFunctionManagement.Text = "Function management";
            // 
            // flowLayoutPanelFunctionManagement
            // 
            this.flowLayoutPanelFunctionManagement.AutoSize = true;
            this.flowLayoutPanelFunctionManagement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelFunctionManagement.Controls.Add(this.checkBoxFunctionsAdd);
            this.flowLayoutPanelFunctionManagement.Controls.Add(this.checkBoxFunctionsEdit);
            this.flowLayoutPanelFunctionManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFunctionManagement.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelFunctionManagement.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelFunctionManagement.Name = "flowLayoutPanelFunctionManagement";
            this.flowLayoutPanelFunctionManagement.Size = new System.Drawing.Size(219, 46);
            this.flowLayoutPanelFunctionManagement.TabIndex = 2;
            // 
            // checkBoxFunctionsAdd
            // 
            this.checkBoxFunctionsAdd.AutoSize = true;
            this.checkBoxFunctionsAdd.Location = new System.Drawing.Point(3, 3);
            this.checkBoxFunctionsAdd.Name = "checkBoxFunctionsAdd";
            this.checkBoxFunctionsAdd.Size = new System.Drawing.Size(91, 17);
            this.checkBoxFunctionsAdd.TabIndex = 1;
            this.checkBoxFunctionsAdd.Text = "Add functions";
            this.checkBoxFunctionsAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxFunctionsEdit
            // 
            this.checkBoxFunctionsEdit.AutoSize = true;
            this.checkBoxFunctionsEdit.Location = new System.Drawing.Point(3, 26);
            this.checkBoxFunctionsEdit.Name = "checkBoxFunctionsEdit";
            this.checkBoxFunctionsEdit.Size = new System.Drawing.Size(90, 17);
            this.checkBoxFunctionsEdit.TabIndex = 0;
            this.checkBoxFunctionsEdit.Text = "Edit functions";
            this.checkBoxFunctionsEdit.UseVisualStyleBackColor = true;
            // 
            // groupBoxScheduling
            // 
            this.groupBoxScheduling.AutoSize = true;
            this.groupBoxScheduling.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxScheduling.Controls.Add(this.flowLayoutPanelScheduling);
            this.groupBoxScheduling.Location = new System.Drawing.Point(465, 166);
            this.groupBoxScheduling.MinimumSize = new System.Drawing.Size(225, 0);
            this.groupBoxScheduling.Name = "groupBoxScheduling";
            this.groupBoxScheduling.Size = new System.Drawing.Size(225, 88);
            this.groupBoxScheduling.TabIndex = 4;
            this.groupBoxScheduling.TabStop = false;
            this.groupBoxScheduling.Text = "Scheduling";
            // 
            // flowLayoutPanelScheduling
            // 
            this.flowLayoutPanelScheduling.AutoSize = true;
            this.flowLayoutPanelScheduling.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelScheduling.Controls.Add(this.checkBoxSchedulingScheduleEmployees);
            this.flowLayoutPanelScheduling.Controls.Add(this.checkBoxSchedulingUnscheduleEmployees);
            this.flowLayoutPanelScheduling.Controls.Add(this.checkBoxSchedulingShiftCapacity);
            this.flowLayoutPanelScheduling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelScheduling.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelScheduling.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelScheduling.Name = "flowLayoutPanelScheduling";
            this.flowLayoutPanelScheduling.Size = new System.Drawing.Size(219, 69);
            this.flowLayoutPanelScheduling.TabIndex = 3;
            // 
            // checkBoxSchedulingScheduleEmployees
            // 
            this.checkBoxSchedulingScheduleEmployees.AutoSize = true;
            this.checkBoxSchedulingScheduleEmployees.Location = new System.Drawing.Point(3, 3);
            this.checkBoxSchedulingScheduleEmployees.Name = "checkBoxSchedulingScheduleEmployees";
            this.checkBoxSchedulingScheduleEmployees.Size = new System.Drawing.Size(124, 17);
            this.checkBoxSchedulingScheduleEmployees.TabIndex = 1;
            this.checkBoxSchedulingScheduleEmployees.Text = "Schedule employees";
            this.checkBoxSchedulingScheduleEmployees.UseVisualStyleBackColor = true;
            // 
            // checkBoxSchedulingUnscheduleEmployees
            // 
            this.checkBoxSchedulingUnscheduleEmployees.AutoSize = true;
            this.checkBoxSchedulingUnscheduleEmployees.Location = new System.Drawing.Point(3, 26);
            this.checkBoxSchedulingUnscheduleEmployees.Name = "checkBoxSchedulingUnscheduleEmployees";
            this.checkBoxSchedulingUnscheduleEmployees.Size = new System.Drawing.Size(136, 17);
            this.checkBoxSchedulingUnscheduleEmployees.TabIndex = 2;
            this.checkBoxSchedulingUnscheduleEmployees.Text = "Unschedule employees";
            this.checkBoxSchedulingUnscheduleEmployees.UseVisualStyleBackColor = true;
            // 
            // checkBoxSchedulingShiftCapacity
            // 
            this.checkBoxSchedulingShiftCapacity.AutoSize = true;
            this.checkBoxSchedulingShiftCapacity.Location = new System.Drawing.Point(3, 49);
            this.checkBoxSchedulingShiftCapacity.Name = "checkBoxSchedulingShiftCapacity";
            this.checkBoxSchedulingShiftCapacity.Size = new System.Drawing.Size(107, 17);
            this.checkBoxSchedulingShiftCapacity.TabIndex = 0;
            this.checkBoxSchedulingShiftCapacity.Text = "Set shift capacity";
            this.checkBoxSchedulingShiftCapacity.UseVisualStyleBackColor = true;
            // 
            // groupBoxSwapping
            // 
            this.groupBoxSwapping.AutoSize = true;
            this.groupBoxSwapping.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSwapping.Controls.Add(this.flowLayoutPanelSwapping);
            this.groupBoxSwapping.Location = new System.Drawing.Point(3, 283);
            this.groupBoxSwapping.MinimumSize = new System.Drawing.Size(225, 0);
            this.groupBoxSwapping.Name = "groupBoxSwapping";
            this.groupBoxSwapping.Size = new System.Drawing.Size(225, 88);
            this.groupBoxSwapping.TabIndex = 4;
            this.groupBoxSwapping.TabStop = false;
            this.groupBoxSwapping.Text = "Swapping";
            // 
            // flowLayoutPanelSwapping
            // 
            this.flowLayoutPanelSwapping.AutoSize = true;
            this.flowLayoutPanelSwapping.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelSwapping.Controls.Add(this.checkBoxSwappingAccept);
            this.flowLayoutPanelSwapping.Controls.Add(this.checkBoxSwappingRequest);
            this.flowLayoutPanelSwapping.Controls.Add(this.checkBoxSwappingApprove);
            this.flowLayoutPanelSwapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSwapping.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelSwapping.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelSwapping.Name = "flowLayoutPanelSwapping";
            this.flowLayoutPanelSwapping.Size = new System.Drawing.Size(219, 69);
            this.flowLayoutPanelSwapping.TabIndex = 3;
            // 
            // checkBoxSwappingAccept
            // 
            this.checkBoxSwappingAccept.AutoSize = true;
            this.checkBoxSwappingAccept.Location = new System.Drawing.Point(3, 3);
            this.checkBoxSwappingAccept.Name = "checkBoxSwappingAccept";
            this.checkBoxSwappingAccept.Size = new System.Drawing.Size(110, 17);
            this.checkBoxSwappingAccept.TabIndex = 1;
            this.checkBoxSwappingAccept.Text = "Accept shift swap";
            this.checkBoxSwappingAccept.UseVisualStyleBackColor = true;
            // 
            // checkBoxSwappingRequest
            // 
            this.checkBoxSwappingRequest.AutoSize = true;
            this.checkBoxSwappingRequest.Location = new System.Drawing.Point(3, 26);
            this.checkBoxSwappingRequest.Name = "checkBoxSwappingRequest";
            this.checkBoxSwappingRequest.Size = new System.Drawing.Size(116, 17);
            this.checkBoxSwappingRequest.TabIndex = 0;
            this.checkBoxSwappingRequest.Text = "Request shift swap";
            this.checkBoxSwappingRequest.UseVisualStyleBackColor = true;
            // 
            // checkBoxSwappingApprove
            // 
            this.checkBoxSwappingApprove.AutoSize = true;
            this.checkBoxSwappingApprove.Location = new System.Drawing.Point(3, 49);
            this.checkBoxSwappingApprove.Name = "checkBoxSwappingApprove";
            this.checkBoxSwappingApprove.Size = new System.Drawing.Size(116, 17);
            this.checkBoxSwappingApprove.TabIndex = 2;
            this.checkBoxSwappingApprove.Text = "Approve shift swap";
            this.checkBoxSwappingApprove.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.AutoSize = true;
            this.groupBoxStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxStatistics.Controls.Add(this.flowLayoutPanelStatistics);
            this.groupBoxStatistics.Location = new System.Drawing.Point(234, 283);
            this.groupBoxStatistics.MinimumSize = new System.Drawing.Size(225, 0);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(225, 42);
            this.groupBoxStatistics.TabIndex = 3;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistics";
            // 
            // flowLayoutPanelStatistics
            // 
            this.flowLayoutPanelStatistics.AutoSize = true;
            this.flowLayoutPanelStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelStatistics.Controls.Add(this.checkBoxStatisticsView);
            this.flowLayoutPanelStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelStatistics.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelStatistics.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelStatistics.Name = "flowLayoutPanelStatistics";
            this.flowLayoutPanelStatistics.Size = new System.Drawing.Size(219, 23);
            this.flowLayoutPanelStatistics.TabIndex = 1;
            // 
            // checkBoxStatisticsView
            // 
            this.checkBoxStatisticsView.AutoSize = true;
            this.checkBoxStatisticsView.Location = new System.Drawing.Point(3, 3);
            this.checkBoxStatisticsView.Name = "checkBoxStatisticsView";
            this.checkBoxStatisticsView.Size = new System.Drawing.Size(92, 17);
            this.checkBoxStatisticsView.TabIndex = 0;
            this.checkBoxStatisticsView.Text = "View statistics";
            this.checkBoxStatisticsView.UseVisualStyleBackColor = true;
            // 
            // comboBoxCurrentFunction
            // 
            this.comboBoxCurrentFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentFunction.FormattingEnabled = true;
            this.comboBoxCurrentFunction.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxCurrentFunction.Location = new System.Drawing.Point(100, 6);
            this.comboBoxCurrentFunction.Name = "comboBoxCurrentFunction";
            this.comboBoxCurrentFunction.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCurrentFunction.TabIndex = 4;
            this.comboBoxCurrentFunction.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrentFunction_SelectedIndexChanged);
            // 
            // PermissionSelectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 489);
            this.Controls.Add(this.comboBoxCurrentFunction);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(288, 300);
            this.Name = "PermissionSelectionWindow";
            this.Text = "PermissionSelectionWindow";
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            this.flowLayoutPanelGeneral.ResumeLayout(false);
            this.flowLayoutPanelGeneral.PerformLayout();
            this.groupBoxEmployeeManagement.ResumeLayout(false);
            this.groupBoxEmployeeManagement.PerformLayout();
            this.flowLayoutPanelEmployeeManagement.ResumeLayout(false);
            this.flowLayoutPanelEmployeeManagement.PerformLayout();
            this.groupBoxStockManagement.ResumeLayout(false);
            this.groupBoxStockManagement.PerformLayout();
            this.flowLayoutPanelStockManagement.ResumeLayout(false);
            this.flowLayoutPanelStockManagement.PerformLayout();
            this.groupBoxDepartmentManagement.ResumeLayout(false);
            this.groupBoxDepartmentManagement.PerformLayout();
            this.flowLayoutPanelDepartmentManagement.ResumeLayout(false);
            this.flowLayoutPanelDepartmentManagement.PerformLayout();
            this.groupBoxFunctionManagement.ResumeLayout(false);
            this.groupBoxFunctionManagement.PerformLayout();
            this.flowLayoutPanelFunctionManagement.ResumeLayout(false);
            this.flowLayoutPanelFunctionManagement.PerformLayout();
            this.groupBoxScheduling.ResumeLayout(false);
            this.groupBoxScheduling.PerformLayout();
            this.flowLayoutPanelScheduling.ResumeLayout(false);
            this.flowLayoutPanelScheduling.PerformLayout();
            this.groupBoxSwapping.ResumeLayout(false);
            this.groupBoxSwapping.PerformLayout();
            this.flowLayoutPanelSwapping.ResumeLayout(false);
            this.flowLayoutPanelSwapping.PerformLayout();
            this.groupBoxStatistics.ResumeLayout(false);
            this.groupBoxStatistics.PerformLayout();
            this.flowLayoutPanelStatistics.ResumeLayout(false);
            this.flowLayoutPanelStatistics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ComboBox comboBoxCurrentFunction;
        private System.Windows.Forms.GroupBox groupBoxGeneral;
        private System.Windows.Forms.CheckBox checkBoxEmployeesView;
        private System.Windows.Forms.CheckBox checkBoxGeneralLoginWebsite;
        private System.Windows.Forms.CheckBox checkBoxGeneralLoginApplication;
        private System.Windows.Forms.GroupBox groupBoxEmployeeManagement;
        private System.Windows.Forms.GroupBox groupBoxStockManagement;
        private System.Windows.Forms.GroupBox groupBoxScheduling;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.CheckBox checkBoxEmployeesAdd;
        private System.Windows.Forms.CheckBox checkBoxEmployeesEdit;
        private System.Windows.Forms.GroupBox groupBoxDepartmentManagement;
        private System.Windows.Forms.GroupBox groupBoxFunctionManagement;
        private System.Windows.Forms.CheckBox checkBoxGeneralClockInOut;
        private System.Windows.Forms.CheckBox checkBoxEmployeesActive;
        private System.Windows.Forms.CheckBox checkBoxStatisticsView;
        private System.Windows.Forms.CheckBox checkBoxProductsRestockAccept;
        private System.Windows.Forms.CheckBox checkBoxProductsRestockFile;
        private System.Windows.Forms.CheckBox checkBoxProductsActive;
        private System.Windows.Forms.CheckBox checkBoxProductsAdd;
        private System.Windows.Forms.CheckBox checkBoxProductsView;
        private System.Windows.Forms.CheckBox checkBoxProductsEdit;
        private System.Windows.Forms.CheckBox checkBoxDepartmentsEdit;
        private System.Windows.Forms.CheckBox checkBoxDepartmentsView;
        private System.Windows.Forms.CheckBox checkBoxFunctionsAdd;
        private System.Windows.Forms.CheckBox checkBoxFunctionsEdit;
        private System.Windows.Forms.CheckBox checkBoxSchedulingUnscheduleEmployees;
        private System.Windows.Forms.CheckBox checkBoxSchedulingScheduleEmployees;
        private System.Windows.Forms.CheckBox checkBoxSchedulingShiftCapacity;
        private System.Windows.Forms.GroupBox groupBoxSwapping;
        private System.Windows.Forms.CheckBox checkBoxSwappingApprove;
        private System.Windows.Forms.CheckBox checkBoxSwappingAccept;
        private System.Windows.Forms.CheckBox checkBoxSwappingRequest;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGeneral;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEmployeeManagement;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStockManagement;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDepartmentManagement;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunctionManagement;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelScheduling;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSwapping;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStatistics;
        private System.Windows.Forms.CheckBox checkBoxDepartmentsAdd;
        private System.Windows.Forms.CheckBox checkBoxDepartmentsChangeActive;
    }
}