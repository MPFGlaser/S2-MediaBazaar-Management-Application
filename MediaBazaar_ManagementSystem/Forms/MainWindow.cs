using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic;
using MediaBazaar_ManagementSystem.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class MainWindow : Form
    {
        IEmployeeStorage employeeStorage;
        IItemStorage itemStorage;
        IDepartmentStorage departmentStorage;
        IShiftStorage shiftStorage;

        EmployeeDetailsWindow edw;
        List<DateTime> weekDays = new List<DateTime>();
        List<Employee> allEmployees = new List<Employee>();
        List<Shift> allWeekShifts = new List<Shift>();
        ProductDetailsWindow pdw;
        ClockInOutWindow ciow;
        Employee loggedInUser;
        ProductRestockDetailsWindow prdw;
        WeekShiftsCapacityEditor wsce;
        PermissionSelectionWindow psw;
        int year = DateTime.Now.Year, maxWeekCount;

        public MainWindow(Employee loggedInUser)
        {
            maxWeekCount = GetWeeksInYear(year);
            this.loggedInUser = loggedInUser;
            InitializeComponent();
            numericUpDownSchedulingWeek.Value = GetWeekOfYear(DateTime.Now);
            DisplayInformation();
            labelWelcomeText.Text = "Welcome, " + loggedInUser.FirstName;
            toolTipReloadDb.SetToolTip(buttonReloadDatabaseEntries, "Reload Data");

            CheckPermissions();
            HideInactiveEmployees(true);
            HideInactiveItems(true);

            this.numericUpDownSchedulingWeek.ValueChanged += new System.EventHandler(numericUpDownSchedulingWeek_ValueChanged);

            calendarDayControlMonday.ReloadCalendarDayEvent += new CalendarDayControl.ReloadCalendarDayHelper(SetupCorrectWeekData);
            calendarDayControlTuesday.ReloadCalendarDayEvent += new CalendarDayControl.ReloadCalendarDayHelper(SetupCorrectWeekData);
            calendarDayControlWednesday.ReloadCalendarDayEvent += new CalendarDayControl.ReloadCalendarDayHelper(SetupCorrectWeekData);
            calendarDayControlThursday.ReloadCalendarDayEvent += new CalendarDayControl.ReloadCalendarDayHelper(SetupCorrectWeekData);
            calendarDayControlFriday.ReloadCalendarDayEvent += new CalendarDayControl.ReloadCalendarDayHelper(SetupCorrectWeekData);
            calendarDayControlSaturday.ReloadCalendarDayEvent += new CalendarDayControl.ReloadCalendarDayHelper(SetupCorrectWeekData);
            calendarDayControlSunday.ReloadCalendarDayEvent += new CalendarDayControl.ReloadCalendarDayHelper(SetupCorrectWeekData);

            
        }

        #region Access Control        
        /// <summary>
        /// Checks the permissions of the loggedInUser and disables functions accordingly.
        /// </summary>
        private void CheckPermissions()
        {
            // Employee tab
            if (loggedInUser.Permissions.Contains("employee_view"))
            {
                if (!loggedInUser.Permissions.Contains("employee_edit"))
                    buttonEmployeeModify.Enabled = false;

                if (!loggedInUser.Permissions.Contains("employee_add"))
                    buttonEmployeesAdd.Enabled = false;

                if (!loggedInUser.Permissions.Contains("function_edit") || !loggedInUser.Permissions.Contains("function_add"))
                    buttonEditFunctionPermissions.Visible = false;

                if (!loggedInUser.Permissions.Contains("department_view"))
                {
                    foreach (Control c in splitContainerEmployeesSecondary.Panel1.Controls)
                    {
                        c.Enabled = false;
                    }
                }

                if (!loggedInUser.Permissions.Contains("department_add"))
                    buttonEmployeesDepartmentAdd.Enabled = false;

                if (!loggedInUser.Permissions.Contains("department_change_active"))
                {
                    buttonEmployeesDepartmentRemove.Enabled = false;
                }

                // department_edit currently has no corresponding function.
            }
            else
            {
                // Removes the tab as the user doesn't have permission to view employee data.
                tabControl1.TabPages.Remove(tabPage1);
            }

            // Stock tab
            if (loggedInUser.Permissions.Contains("product_view"))
            {
                if (!loggedInUser.Permissions.Contains("product_edit"))
                    buttonStockEditProduct.Enabled = false;

                if (!loggedInUser.Permissions.Contains("product_add"))
                    buttonStockAdd.Enabled = false;

                if (!loggedInUser.Permissions.Contains("product_restock_file"))
                    pnlSalesRepresentative.Visible = false;
                else pnlSalesRepresentative.Visible = true;
                if (!loggedInUser.Permissions.Contains("product_restock_accept"))
                    pnlDepotWorker.Visible = false;
                else pnlDepotWorker.Visible = true;
                // We need something for the categories, still. No permissions for it and the controls are disabled by default.
            }
            else
            {
                // Removes the stock tab as the user has no permission to view product data.
                tabControl1.TabPages.Remove(tabPage2);
            }

            // Statistics tab
            if (loggedInUser.Permissions.Contains("statistics_view"))
            {
                // We need to add more functions/permissions for statistics.
            }
            else
            {
                // Removes the statistics tab as the user has no permission to view statistics.
                tabControl1.TabPages.Remove(tabPage3);
            }

            // Scheduling tab
            if (loggedInUser.Permissions.Contains("schedule_employee_add") ||
                loggedInUser.Permissions.Contains("schedule_employee_remove") ||
                loggedInUser.Permissions.Contains("schedule_capacity_set"))
            {
                if (!loggedInUser.Permissions.Contains("schedule_capacity_set"))
                    buttonSetWeekShiftsCapacity.Enabled = false;
            }
            else
            {
                // Removes the scheduling tab as the user has no access to scheduling functions whatsoever.
                tabControl1.TabPages.Remove(tabPage4);
            }

        }
        #endregion

        #region Logic
        #region Preparation
        /// <summary>
        /// Function to make sure all data is loaded into the user interface and all is ready to go for the user to start doing their work.
        /// </summary>
        private void DisplayInformation()
        {
            employeeStorage = new EmployeeMySQL();
            itemStorage = new ItemMySQL();

            PopulateEmployeesTable();
            PopulateItemsTable();
            LoadAllDepartments();
            SetupCorrectWeekData();
        }

        /// <summary>
        /// Function to load all departments from the departmentStorage and populate the departments combobox with them.
        /// </summary>
        private void LoadAllDepartments()
        {
            // Initialises the departmentStorage and makes a list of all departments it can find
            departmentStorage = new DepartmentMySQL();
            List<Department> allDepartments = departmentStorage.GetAll();

            // Iterates through the list of departments and adds each of them to the combobox
            foreach (Department d in allDepartments)
            {
                comboBoxAllDepartments.DisplayMember = "Text";
                comboBoxAllDepartments.ValueMember = "Department";
                comboBoxAllDepartments.Items.Add(new { Text = d.Name, Department = d });

                comboBoxSchedulingDepartment.DisplayMember = "Text";
                comboBoxSchedulingDepartment.ValueMember = "Department";
                comboBoxSchedulingDepartment.Items.Add(new { Text = d.Name, Department = d });
            }
        }

        /// <summary>
        /// Function to populate the employee table with all employees stored in the employeeStorage.
        /// </summary>
        private void PopulateEmployeesTable()
        {
            // Clears the dataGridView so no orphaned employees remain by accident
            dataGridViewEmployees.Rows.Clear();

            // Gathers all employees from the employeeStorage and adds them to the dataGridView
            try
            {
                foreach (Employee e in employeeStorage.GetAll(false))
                {
                    int rowId = dataGridViewEmployees.Rows.Add();

                    DataGridViewRow row = dataGridViewEmployees.Rows[rowId];

                    row.Cells["id"].Value = e.Id;
                    row.Cells["active"].Value = e.Active ? "✓" : "✕";
                    row.Cells["firstName"].Value = e.FirstName;
                    row.Cells["surName"].Value = e.SurName;
                    row.Cells["username"].Value = e.UserName;
                    row.Cells["phoneNumber"].Value = e.PhoneNumber;
                    row.Cells["emailAddress"].Value = e.Email;
                }

                // Depending on whether the checkbox is checked, it either shows or hides employees marked as inactive
                if (checkBoxShowInactive.Checked)
                {
                    HideInactiveEmployees(false);
                }
                else
                {
                    HideInactiveEmployees(true);
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.RetrieveEmployee(ex);
            }
        }

        /// <summary>
        /// Function to add all items in the itemStorage to the dataGridView
        /// </summary>
        private void PopulateItemsTable()
        {
            // Clears the dataGridView to prevent orphan items from sticking around
            dataGridViewStock.Rows.Clear();

            // Gets all items from the itemStorage and adds them to the dataGridView
            try
            {
                foreach (Item i in itemStorage.GetAll(false))
                {
                    int rowId = dataGridViewStock.Rows.Add();
                    int stockrequest = itemStorage.ReadRequest(i.Id);

                    DataGridViewRow row = dataGridViewStock.Rows[rowId];

                    row.Cells["productId"].Value = i.Id;
                    row.Cells["name"].Value = i.Name;
                    row.Cells["brand"].Value = i.Brand;
                    row.Cells["code"].Value = i.Code;
                    row.Cells["category"].Value = i.Category;
                    row.Cells["quantity"].Value = i.Quantity;
                    row.Cells["Stock_request"].Value = stockrequest;
                    row.Cells["price"].Value = i.Price;
                    row.Cells["productActive"].Value = i.Active;
                    row.Cells["description"].Value = i.Description;
                }

                // Depending on whether the checkbox is checked, it either shows or hides items marked as inactive
                if (checkBoxShowInactiveItems.Checked)
                {
                    HideInactiveItems(false);
                }
                else
                {
                    HideInactiveItems(true);
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.RetrieveEmployee(ex);
            }
        }

        /// <summary>
        /// Function to correctly set the dates of the CalendarDayControl elements on the scheduling page
        /// </summary>
        private void SetupCorrectWeekData()
        {
            shiftStorage = new ShiftMySQL();

            // Gets the week number from the numericUpDown
            int weekNumber = Convert.ToInt32(numericUpDownSchedulingWeek.Value);

            // Gets the first date of the week with the aforementioned week number
            weekDays = FirstDateOfWeekISO8601(year, weekNumber);

            // Gets all shifts from the shiftStorage between the start and end date of the week
            allWeekShifts = shiftStorage.GetWeek(weekDays[0], weekDays[6]);

            // Gets the hours all employees work this specific week
            allEmployees = employeeStorage.GetHoursWorked(employeeStorage.GetAll(true), weekDays[0], weekDays[6]);

            // Sets the correct data on the CalendarDayControl elements
            calendarDayControlMonday.DisplayCorrectDate(weekDays[0], "Monday", allWeekShifts, loggedInUser);
            calendarDayControlTuesday.DisplayCorrectDate(weekDays[1], "Tuesday", allWeekShifts, loggedInUser);
            calendarDayControlWednesday.DisplayCorrectDate(weekDays[2], "Wednesday", allWeekShifts, loggedInUser);
            calendarDayControlThursday.DisplayCorrectDate(weekDays[3], "Thursday", allWeekShifts, loggedInUser);
            calendarDayControlFriday.DisplayCorrectDate(weekDays[4], "Friday", allWeekShifts, loggedInUser);
            calendarDayControlSaturday.DisplayCorrectDate(weekDays[5], "Saturday", allWeekShifts, loggedInUser);
            calendarDayControlSunday.DisplayCorrectDate(weekDays[6], "Sunday", allWeekShifts, loggedInUser);

            SetupCorrectEmployees();
        }

        private void SetupCorrectEmployees()
        {
            calendarDayControlMonday.SetupEmployees(allEmployees);
            calendarDayControlTuesday.SetupEmployees(allEmployees);
            calendarDayControlWednesday.SetupEmployees(allEmployees);
            calendarDayControlThursday.SetupEmployees(allEmployees);
            calendarDayControlFriday.SetupEmployees(allEmployees);
            calendarDayControlSaturday.SetupEmployees(allEmployees);
            calendarDayControlSunday.SetupEmployees(allEmployees);
        }
        #endregion

        #region Visuals
        /// <summary>
        /// Hides inactive employees from the dataGridView
        /// </summary>
        /// <param name="visible"></param>
        private void HideInactiveEmployees(bool visible)
        {
            if (visible)
            {
                foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
                {
                    if (row.Cells["active"].Value == "✕")
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
                {
                    if (row.Cells["active"].Value == "✕")
                    {
                        row.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Hides inactive items from the dataGridView
        /// </summary>
        /// <param name="visible"></param>
        private void HideInactiveItems(bool visible)
        {
            if (visible)
            {
                foreach (DataGridViewRow row in dataGridViewStock.Rows)
                {
                    if (!(bool)row.Cells["productActive"].Value)
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridViewStock.Rows)
                {
                    if (!(bool)row.Cells["productActive"].Value)
                    {
                        row.Visible = true;
                    }
                }
            }
        }
        #endregion

        #region Employees
        /// <summary>
        /// Opens a new EmployeeDetailsWindow so the user can add an employee
        /// </summary>
        private void EmployeeAdd()
        {
            edw = new EmployeeDetailsWindow(loggedInUser);
            if (edw.ShowDialog() == DialogResult.OK)
            {
                PopulateEmployeesTable();
            }
        }

        /// <summary>
        /// Opens a new EmployeeDetailsWindow so the user can modify the employee they have selected
        /// </summary>
        private void EmployeeModify()
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewEmployees.SelectedCells[0].Value);
                Employee toEdit = employeeStorage.Get(id);
                edw = new EmployeeDetailsWindow(loggedInUser);
                edw.AddEmployeeData(toEdit);
                if (edw.ShowDialog() == DialogResult.OK)
                {
                    PopulateEmployeesTable();
                    HideInactiveEmployees(!checkBoxShowInactive.Checked);
                }
            }
        }

        /// <summary>
        /// Opens a new ClockInOutWindow so the user can clock in or out an employee
        /// </summary>
        private void ClockInOutAnEmployee()
        {
            int id = Convert.ToInt32(dataGridViewEmployees.SelectedCells[0].Value);
            ciow = new ClockInOutWindow(id);
            ciow.Show();
            
        }

        /// <summary>
        /// Adds a department to the combobox and departmentStorage
        /// </summary>
        private void EmployeeDepartmentAdd()
        {
            string newDepartmentName = Interaction.InputBox("Department name:", "Create a new department");

            if (newDepartmentName != string.Empty)
            {
                departmentStorage = new DepartmentMySQL();
                departmentStorage.Create(newDepartmentName);
                comboBoxAllDepartments.Items.Add(newDepartmentName);
            }
        }

        /// <summary>
        /// Removes a department from the combobox and departmentStorage
        /// </summary>
        private void EmployeeDepartmentRemove()
        {
            if (comboBoxAllDepartments.SelectedIndex != -1)
            {
                Department departmentToRemove = (comboBoxAllDepartments.SelectedItem as dynamic).Department;
                if (departmentToRemove != null)
                {
                    departmentStorage = new DepartmentMySQL();
                    departmentStorage.Remove(departmentToRemove.Id);
                    comboBoxAllDepartments.Items.Remove(departmentToRemove.Name);
                }
            }
        }
        #endregion

        #region Stock
        /// <summary>
        /// Opens a new ProductDetailsWindow so the user can add a product
        /// </summary>
        private void StockAdd()
        {
            pdw = new ProductDetailsWindow(loggedInUser);
            if (pdw.ShowDialog() == DialogResult.OK)
            {
                PopulateItemsTable();
            }
        }

        /// <summary>
        /// Opens a new ProductDetailsWindow so the user can modify the product they have selected
        /// </summary>
        private void StockModify()
        {
            if (dataGridViewStock.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewStock.SelectedCells[0].Value);
                Item toEdit = itemStorage.Get(id);
                pdw = new ProductDetailsWindow(loggedInUser);
                pdw.AddItemData(toEdit);
                if (pdw.ShowDialog() == DialogResult.OK)
                {
                    PopulateItemsTable();
                    HideInactiveItems(!checkBoxShowInactiveItems.Checked);
                }
            }
        }

        /// <summary>
        /// Opens a new ProductRestockDetailsWindow so the user can modify the quantity for the restock of product they have selected
        /// </summary>
        private void ReStockProduct()
        {
            int id = Convert.ToInt32(dataGridViewStock.SelectedCells[0].Value);
            Item toEdit = itemStorage.Get(id);
            prdw = new ProductRestockDetailsWindow();
            prdw.AddItemData(toEdit, loggedInUser.Id);
            if (prdw.ShowDialog() == DialogResult.OK)
            {
                PopulateItemsTable();
            }
        }
        #endregion

        #region Statistics
        /// <summary>
        /// Function to generate (temporary) random data for the chart in the statistics window
        /// </summary>
        private void StatisticsRandomData()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            Series TestDataPoints = StatisticChart.Series["TestData"];

            TestDataPoints.Points.Clear();

            for (int i = 1; i <= 10; i++)
            {
                int data = rand.Next(1, 101);
                TestDataPoints.Points.Add(data, i);
            }
        }
        #endregion

        #region Scheduling
        /// <summary>
        /// Function to handle the clicking of the "next week" button
        /// </summary>
        private void SchedulingNext()
        {
            if (numericUpDownSchedulingWeek.Value == maxWeekCount)
            {
                numericUpDownSchedulingWeek.Value = 1;
                year += 1;
                maxWeekCount = GetWeeksInYear(year);
            }
            else
            {
                numericUpDownSchedulingWeek.Value += 1;
            }
            SetupCorrectWeekData();
        }

        /// <summary>
        /// Function to handle the clicking of the "previous week" button
        /// </summary>
        private void SchedulingPrevious()
        {
            if (numericUpDownSchedulingWeek.Value == 1)
            {
                year -= 1;
                maxWeekCount = GetWeeksInYear(year);
                numericUpDownSchedulingWeek.Value = maxWeekCount;
            }
            else
            {
                numericUpDownSchedulingWeek.Value -= 1;
            }
            SetupCorrectWeekData();
        }

        /// <summary>
        /// Opens a form where the user can set the desired capacity for a whole week's worth of shifts.
        /// </summary>
        private void SetCapacityWholeWeek()
        {
            int selectedId = -1;
            CreateMissingShifts();

            if (comboBoxSchedulingDepartment.SelectedIndex > -1)
            {
                dynamic selectedDynamic = comboBoxSchedulingDepartment.SelectedItem;
                Department selectedDepartment = selectedDynamic.Department;
                selectedId = selectedDepartment.Id;
            }
            
            wsce = new WeekShiftsCapacityEditor(allWeekShifts, weekDays, selectedId);
            if (wsce.ShowDialog() == DialogResult.OK)
            {
                SetupCorrectWeekData();                
            }
        }

        private void CreateMissingShifts()
        {
            shiftStorage = new ShiftMySQL();
            List<Shift> tempNewShifts = new List<Shift>();

            foreach (DateTime date in weekDays)
            {
                if (allWeekShifts.FirstOrDefault(x => x.Date == date && x.ShiftTime == ShiftTime.Morning) == null)
                {
                    Shift s = new Shift(0, date, ShiftTime.Morning, 0);
                    int newId = shiftStorage.Create(s);
                    Shift s2 = new Shift(newId, date, ShiftTime.Morning, 0);
                    tempNewShifts.Add(s2);
                }

                if (allWeekShifts.FirstOrDefault(x => x.Date == date && x.ShiftTime == ShiftTime.Afternoon) == null)
                {
                    Shift s = new Shift(0, date, ShiftTime.Afternoon, 0);
                    int newId = shiftStorage.Create(s);
                    Shift s2 = new Shift(newId, date, ShiftTime.Afternoon, 0);
                    tempNewShifts.Add(s2);
                }

                if (allWeekShifts.FirstOrDefault(x => x.Date == date && x.ShiftTime == ShiftTime.Evening) == null)
                {
                    Shift s = new Shift(0, date, ShiftTime.Evening, 0);
                    int newId = shiftStorage.Create(s);
                    Shift s2 = new Shift(newId, date, ShiftTime.Evening, 0);
                    tempNewShifts.Add(s2);
                }
            }

            foreach (Shift s in tempNewShifts)
            {
                foreach (dynamic depDynamic in comboBoxSchedulingDepartment.Items)
                {
                    Department dep = depDynamic.Department;

                    shiftStorage.AddCapacityForDepartment(s.Id, dep.Id, 0);
                }
                allWeekShifts.Add(s);
            }
        }

        /// <summary>
        /// Starts the automated scheduling.
        /// </summary>
        private void StartAutomaticScheduling()
        {
            employeeStorage = new EmployeeMySQL();
            List<Employee> allEmployees = employeeStorage.GetAll(true);
            List<(int employeeId, DateTime absentDate)> absentDays = employeeStorage.GetAbsentDays();
            List<WorkingEmployee> currentWorkingEmployees = employeeStorage.GetWorkingEmployees();
            List<int> allShiftIds = shiftStorage.GetAllShiftIds();
            CreateMissingShifts();
            bool isEditing;

            foreach(Employee e in allEmployees)
            {
                foreach((int employeeId, DateTime absentDate) absentList in absentDays)
                {
                    if(e.Id == absentList.employeeId)
                    {
                        e.NotWorkingDays.Add(absentList.absentDate);
                    }
                }
            }

            //List<Employee> availableEmployees = FILTER(allEmployees);
            List<Employee> availableEmployees = allEmployees;

            foreach(Shift s in allWeekShifts)
            {

                if (allShiftIds.Contains(s.Id))
                {
                    isEditing = true;
                }
                else
                {
                    isEditing = false;
                }
                
                Schedule(s, availableEmployees, isEditing, shiftStorage.GetCapacityPerDepartment(s.Id), departmentStorage.GetAll());
            }
        }

        private void Schedule(Shift toSchedule, List<Employee> availableEmployees, bool isEditing, Dictionary<int, int> allDepartmentCapacity, List<Department> allDepartments)
        {
            // Makes sure everything is set up correctly.
            shiftStorage = new ShiftMySQL();
            List<int> workingEmployeeIds = new List<int>();
            int capacityNew = 5; //Temporary hardcoded because lack of data
            int shiftId = 0;
            Shift currentShift;

            // Checks if the shift is in editing mode and chooses whether to edit or create a shift in the shiftStorage
            if (isEditing)
            {
                // Creates a new shift object and sets the list of employeeIds to the one we just created.
                currentShift = new Shift(toSchedule.Id, toSchedule.Date, toSchedule.ShiftTime, capacityNew);
                // Removes all information about the shift in the shiftStorage to prevent duplication of entries
                shiftStorage.Clear(toSchedule.Id);
                shiftId = toSchedule.Id;

                foreach (Department d in allDepartments)
                {
                    if (!allDepartmentCapacity.ContainsKey(d.Id))
                    {
                        shiftStorage.AddCapacityForDepartment(shiftId, d.Id, capacityNew);
                        d.Capacity = capacityNew;
                    }
                }
            }
            else
            {
                // Creates a new shift object and sets the list of employeeIds to the one we just created.
                currentShift = new Shift(0, toSchedule.Date, toSchedule.ShiftTime, capacityNew);
                shiftId = shiftStorage.Create(currentShift);

                foreach (Department d in allDepartments)
                {
                    if (!allDepartmentCapacity.ContainsKey(d.Id))
                    {
                        shiftStorage.AddCapacityForDepartment(shiftId, d.Id, capacityNew);
                        d.Capacity = capacityNew;
                    }
                }
            }

            //Check if is allowed to work in this department
            foreach (Department d in allDepartments)
            {
                foreach(Employee e in availableEmployees)
                {
                    List<int> workingDepartmentsList = e.WorkingDepartments.Split(',').Select(int.Parse).ToList();
                    if (workingDepartmentsList.Contains(d.Id) && d.Employees.Count < d.Capacity)
                    {
                        d.Employees.Add(e);
                    }
                }
            }

            foreach (Department d in allDepartments)
            {
                // Makes a list of all ids of the employees scheduled for that shift
                foreach (Employee emp in d.Employees)
                {
                    shiftStorage.Assign(shiftId, emp.Id, d.Id);
                }
            }
        }
        #endregion

        #region Calendar data
        /// <summary>
        /// Function to get the current week number
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        private int GetWeekOfYear(DateTime currentDate)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            int weekNumber = ci.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNumber;
        }

        private int GetWeeksInYear(int givenYear)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(givenYear, 12, 31);
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

        /// <summary>
        /// Gets the first date of the week with a specified week number.
        /// <para>Uses the ISO 8601 standard</para>
        /// </summary>
        /// <param name="year"></param>
        /// <param name="weekOfYear"></param>
        /// <returns></returns>
        public static List<DateTime> FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            List<DateTime> daysBasedOnWeekNumber = new List<DateTime>();
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            for (int i = 0; i < 7; i++)
            {
                daysBasedOnWeekNumber.Add(result.AddDays(-3 + i));
            }
            return daysBasedOnWeekNumber;
        }
        #endregion

        /// <summary>
        /// Function to log the current user out of the application and show a new login window.
        /// </summary>
        private void Logout()
        {
            Application.Restart();
            Environment.Exit(0);
        }
        #endregion

        #region User control handlers
        private void DataButton_Click(object sender, EventArgs e)
        {
            StatisticsRandomData();
        }

        private void buttonEmployeesAdd_Click(object sender, EventArgs e)
        {
            EmployeeAdd();
        }

        private void buttonEmployeeModify_Click(object sender, EventArgs e)
        {
            EmployeeModify();
        }

        private void buttonEmployeesDepartmentAdd_Click(object sender, EventArgs e)
        {
            EmployeeDepartmentAdd();
        }

        private void buttonEmployeesDepartmentRemove_Click(object sender, EventArgs e)
        {
            EmployeeDepartmentRemove();
        }

        private void checkBoxShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowInactive.Checked)
            {
                HideInactiveEmployees(false);
            }
            else
            {
                HideInactiveEmployees(true);
            }
        }

        private void checkBoxShowInactiveItems_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowInactiveItems.Checked)
            {
                HideInactiveItems(false);
            }
            else
            {
                HideInactiveItems(true);
            }
        }

        private void buttonStockAdd_Click(object sender, EventArgs e)
        {
            StockAdd();
        }

        private void buttonStockEditProduct_Click(object sender, EventArgs e)
        {
            StockModify();
        }

        private void numericUpDownSchedulingWeek_ValueChanged(Object sender, EventArgs e)
        {
            if (numericUpDownSchedulingWeek.Value > maxWeekCount)
                numericUpDownSchedulingWeek.Value = 1;
            SetupCorrectWeekData();
        }

        private void buttonSchedulingNext_Click(object sender, EventArgs e)
        {
            SchedulingNext();
        }

        private void buttonSchedulingPrevious_Click(object sender, EventArgs e)
        {
            SchedulingPrevious();
        }

        private void buttonReloadDatabaseEntries_Click(object sender, EventArgs e)
        {
            DisplayInformation();
            MessageBox.Show("Data Reloaded");
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void btnSendRestockRequest_Click(object sender, EventArgs e)
        {
            ReStockProduct();
            DisplayInformation();
        }

        private void btnAcceptRestockRequest_Click(object sender, EventArgs e)
        {
            int pId = Convert.ToInt32(dataGridViewStock.SelectedCells[0].Value);
            int pQuantity = itemStorage.Get(pId).Quantity;
            if (itemStorage.ReadRequest(pId) > 0)
            {
                itemStorage.AddToStock(pId, pQuantity);
                DisplayInformation();
            }
            else MessageBox.Show("Restock unavailable due to restock request quantity being 0!!!");
        }

        private void buttonSetWeekShiftsCapacity_Click(object sender, EventArgs e)
        {
            SetCapacityWholeWeek();
        }

        private void comboBoxSchedulingDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic depDynamic = comboBoxSchedulingDepartment.SelectedItem;
            Department selected = (depDynamic).Department;

            calendarDayControlMonday.CurrentSelectedDepartment = selected;
            calendarDayControlTuesday.CurrentSelectedDepartment = selected;
            calendarDayControlWednesday.CurrentSelectedDepartment = selected;
            calendarDayControlThursday.CurrentSelectedDepartment = selected;
            calendarDayControlFriday.CurrentSelectedDepartment = selected;
            calendarDayControlSaturday.CurrentSelectedDepartment = selected;
            calendarDayControlSunday.CurrentSelectedDepartment = selected;
        }

        private void btnClockinOut_Click(object sender, EventArgs e)
        {
            ClockInOutAnEmployee();
        }

        private void buttonEditFunctionPermissions_Click(object sender, EventArgs e)
        {
            psw = new PermissionSelectionWindow();
            psw.Show();
        }
    } 
    #endregion
}
