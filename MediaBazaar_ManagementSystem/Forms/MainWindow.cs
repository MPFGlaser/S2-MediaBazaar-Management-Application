using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Linq;
using System.Threading;
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

        /// <summary>
        /// Function to log the current user out of the application and show a new login window.
        /// </summary>
        private void Logout()
        {
            Application.Restart();
            Environment.Exit(0);
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
            CreateMissingShifts();
            List<Employee> allEmployees = employeeStorage.GetAll(true);
            List<(int employeeId, DateTime absentDate)> absentDays = employeeStorage.GetAbsentDays();
            List<int> allShiftIds = shiftStorage.GetAllShiftIds();
            List<Department> allDepartments = departmentStorage.GetAll();
            List<WorkingEmployee> currentWorkingEmployees = new List<WorkingEmployee>(employeeStorage.GetWorkingEmployees()), employeesToSchedule = new List<WorkingEmployee>();
            int capacityNew = 0;

            foreach (Employee e in allEmployees)
            {
                foreach((int employeeId, DateTime absentDate) absentList in absentDays)
                {
                    if(e.Id == absentList.employeeId)
                    {
                        e.NotWorkingDays.Add(absentList.absentDate);
                    }
                }
            }

            foreach(Shift s in allWeekShifts)
            {
                List<Employee> randomEmployeeList = ShuffleEmployeeList(allEmployees);
                foreach (Department d in allDepartments)
                {
                    d.Capacity = departmentStorage.GetCapacityForDepartmentInShift(d.Id, s.Id);
                    foreach(WorkingEmployee we in Schedule(s, Filter(s, d.Id, allWeekShifts, currentWorkingEmployees, randomEmployeeList), d, capacityNew))
                    {
                        currentWorkingEmployees.Add(we);
                        employeesToSchedule.Add(we);
                    }
                }
            }

            shiftStorage.ScheduleAllEmployeesInList(employeesToSchedule);
        }

        /// <summary>
        /// Filters out all of the employees not fit for the shift and department which are currently beeing scheduled.
        /// </summary>
        /// <param name="shift"></param>
        /// <param name="departmentId"></param>
        /// <param name="shifts"></param>
        /// <param name="we"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private List<Employee> Filter(Shift shift, int departmentId, List<Shift> shifts, List<WorkingEmployee> we, List<Employee> e)
        {
            List<Employee> filteredEmployees = new List<Employee>(e);
            List<WorkingEmployee> workingEmployees = new List<WorkingEmployee>(we);

            IFilter alreadyScheduled = new FilterAlreadyScheduled();
            IFilter sickOrDayOff = new FilterSickOrDayOff();
            IFilter scheduledTwice = new FilterScheduledTwiceAlready();
            IFilter notAllowedInDepartment = new FilterNotAllowedInDepartment();
            IFilter otherDepartment = new FilterWorkingInOtherDepartmentToday();
            IFilter contractHours = new FilterContractHoursViolation();
            IFilter preferredHours = new FilterPreferredHours();

            filteredEmployees = alreadyScheduled.Filter(shift, departmentId, shifts, workingEmployees, filteredEmployees);
            filteredEmployees = sickOrDayOff.Filter(shift, departmentId, shifts, workingEmployees, filteredEmployees);
            filteredEmployees = scheduledTwice.Filter(shift, departmentId, shifts, workingEmployees, filteredEmployees);
            filteredEmployees = notAllowedInDepartment.Filter(shift, departmentId, shifts, workingEmployees, filteredEmployees);
            filteredEmployees = otherDepartment.Filter(shift, departmentId, shifts, workingEmployees, filteredEmployees);
            filteredEmployees = contractHours.Filter(shift, departmentId, shifts, workingEmployees, filteredEmployees);
            filteredEmployees = preferredHours.Filter(shift, departmentId, shifts, workingEmployees, filteredEmployees);

            return filteredEmployees;
        }

        /// <summary>
        /// Creates the list of employees which are going to be scheduled.
        /// </summary>
        /// <param name="toSchedule"></param>
        /// <param name="availableEmployees"></param>
        /// <param name="currentDepartment"></param>
        /// <param name="capacityNew"></param>
        /// <returns></returns>
        private List<WorkingEmployee> Schedule(Shift toSchedule, List<Employee> availableEmployees, Department currentDepartment, int capacityNew)
        {
            shiftStorage = new ShiftMySQL();
            List<WorkingEmployee> scheduledEmployees= new List<WorkingEmployee>();

            // Removes all information about the employees working this shift & department in the shiftStorage to prevent duplication of entries.
            shiftStorage.ClearDept(toSchedule.Id, currentDepartment.Id);

            // Updates the capacity of departments where no capacity has been set yet (if necessary).
            if (currentDepartment.Capacity <= 0)
            {
                shiftStorage.UpdateCapacityPerDepartment(toSchedule.Id, currentDepartment.Id, capacityNew);
                currentDepartment.Capacity = capacityNew;
            }

            // Adds the selected employees to the list of employees to be scheduled.
            for(int i = 0; (i < currentDepartment.Capacity && i < availableEmployees.Count); i++)
            {
                scheduledEmployees.Add(new WorkingEmployee(toSchedule.Id, availableEmployees[i].Id, currentDepartment.Id));
            }

            return scheduledEmployees;
        }

        /// <summary>
        /// Randomizes the list of employees in order to not always pick the same ones.
        /// </summary>
        /// <param name="toShuffle"></param>
        /// <returns></returns>
        public List<Employee> ShuffleEmployeeList(List<Employee> toShuffle)
        {
            Random rng = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            List<Employee> toReturn = toShuffle;
            int n = toShuffle.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Employee temp = toReturn[k];
                toReturn[k] = toReturn[n];
                toReturn[n] = temp;
            }

            return toReturn;
        }
        #endregion
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

        private void buttonAutomaticScheduling_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                ToggleSchedulingElements(false);
                StartAutomaticScheduling();
                ToggleSchedulingElements(true);
            }).Start();
        }

        private void buttonEditFunctionPermissions_Click(object sender, EventArgs e)
        {
            psw = new PermissionSelectionWindow();
            psw.Show();
        }
        #endregion

        #region element enabling/disabling
        private void ToggleSchedulingElements(bool newValue)
        {
            tabControl1.BeginInvoke((Action)delegate ()
            {
                buttonSchedulingPrevious.Enabled = newValue;
                buttonSchedulingNext.Enabled = newValue;
                buttonSetWeekShiftsCapacity.Enabled = newValue;
                numericUpDownSchedulingWeek.Enabled = newValue;
                comboBoxSchedulingDepartment.Enabled = newValue;
                buttonAutomaticScheduling.Enabled = newValue;

                calendarDayControlMonday.ToggleCalendarDayControlButtons(newValue);
                calendarDayControlTuesday.ToggleCalendarDayControlButtons(newValue);
                calendarDayControlWednesday.ToggleCalendarDayControlButtons(newValue);
                calendarDayControlThursday.ToggleCalendarDayControlButtons(newValue);
                calendarDayControlFriday.ToggleCalendarDayControlButtons(newValue);
                calendarDayControlSaturday.ToggleCalendarDayControlButtons(newValue);
                calendarDayControlSunday.ToggleCalendarDayControlButtons(newValue);

                progressBarSchedulingTime.Visible = !newValue;
            });
        }

        #endregion
    }
}
