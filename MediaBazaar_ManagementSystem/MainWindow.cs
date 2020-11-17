using MediaBazaar_ManagementSystem.classes;
using MediaBazaar_ManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using Microsoft.VisualBasic;

namespace MediaBazaar_ManagementSystem
{
    public partial class MainWindow : Form
    {
        DatabaseHandler dbhandler;
        EmployeeDetailsWindow edw;
        List<DateTime> weekDays = new List<DateTime>();
        ProductDetailsWindow pdw;
        Employee loggedInUser;

        public MainWindow(Employee loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            InitializeComponent();
            DisplayInformation();
            InitializeNumericUpDown();
            LoadAllDepartments();
            labelWelcomeText.Text = "Welcome, " + loggedInUser.FirstName;
        }

        #region Logic
        #region Preparation
        /// <summary>
        /// Function to make sure all data is loaded into the user interface and all is ready to go for the user to start doing their work.
        /// </summary>
        private void DisplayInformation()
        {
            dbhandler = new Classes.DatabaseHandler();
            PopulateEmployeesTable();
            numericUpDownSchedulingWeek.Value = GetWeekOfYear(DateTime.Now);
            SetupCorrectWeekData();
            toolTipReloadDb.SetToolTip(buttonReloadDatabaseEntries, "Reload Database Entries");
        }

        /// <summary>
        /// Initialises the numericUpDown control on the scheduling page
        /// </summary>
        private void InitializeNumericUpDown()
        {
            this.numericUpDownSchedulingWeek.ValueChanged += new System.EventHandler(numericUpDownSchedulingWeek_ValueChanged);

            // I have no clue why this is all here, it should be in a separate function. Please fix.
            dbhandler = new Classes.DatabaseHandler();
            PopulateEmployeesTable();
            PopulateItemsTable();
            HideInactiveEmployees(true);
            HideInactiveItems(true);

            // Removes statistics tab until implementation is finished in the future.
            tabControl1.TabPages.Remove(tabPage3);

            // Removes certain tabs for the user in case they have a function that may not access those features.
            if (loggedInUser.Function == 1)
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage4);
            }
        }

        /// <summary>
        /// Function to load all departments from the database and populate the departments combobox with them.
        /// </summary>
        private void LoadAllDepartments()
        {
            // Initialises the dbhandler and makes a list of all departments it can find
            dbhandler = new Classes.DatabaseHandler();
            List<Department> allDepartments = dbhandler.GetAllDepartments();

            // Iterates through the list of departments and adds each of them to the combobox
            foreach (Department d in allDepartments)
            {
                comboBoxAllDepartments.DisplayMember = "Text";
                comboBoxAllDepartments.ValueMember = "Department";
                comboBoxAllDepartments.Items.Add(new { Text = d.Name, Department = d });
            }
        }

        /// <summary>
        /// Function to populate the employee table with all employees stored in the database.
        /// </summary>
        private void PopulateEmployeesTable()
        {
            // Clears the dataGridView so no orphaned employees remain by accident
            dataGridViewEmployees.Rows.Clear();

            // Gathers all employees from the database and adds them to the dataGridView
            try
            {
                foreach (Employee e in dbhandler.GetEmployeesFromDB())
                {
                    int rowId = dataGridViewEmployees.Rows.Add();

                    DataGridViewRow row = dataGridViewEmployees.Rows[rowId];

                    row.Cells["id"].Value = e.Id;
                    row.Cells["active"].Value = e.Active;
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
                MessageBox.Show("Error getting employee info.\n" + ex.ToString());
            }
        }

        /// <summary>
        /// Function to add all items in the database to the dataGridView
        /// </summary>
        private void PopulateItemsTable()
        {
            // Clears the dataGridView to prevent orphan items from sticking around
            dataGridViewStock.Rows.Clear();

            // Gets all items from the database and adds them to the dataGridView
            try
            {
                foreach (Item i in dbhandler.GetItemsFromDB())
                {
                    int rowId = dataGridViewStock.Rows.Add();

                    DataGridViewRow row = dataGridViewStock.Rows[rowId];

                    row.Cells["productId"].Value = i.Id;
                    row.Cells["name"].Value = i.Name;
                    row.Cells["brand"].Value = i.Brand;
                    row.Cells["code"].Value = i.Code;
                    row.Cells["category"].Value = i.Category;
                    row.Cells["quantity"].Value = i.Quantity;
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
                MessageBox.Show("Error getting employee info.\n" + ex.ToString());
            }
        }

        /// <summary>
        /// Function to correctly set the dates of the CalendarDayControl elements on the scheduling page
        /// </summary>
        private void SetupCorrectWeekData()
        {
            // Gets the week number from the numericUpDown
            int weekNumber = Convert.ToInt32(numericUpDownSchedulingWeek.Value);

            // Gets the first date of the week with the aforementioned week number
            weekDays = FirstDateOfWeekISO8601(2020, weekNumber);

            // Gets all shifts from the database between the start and end date of the week
            List<Shift> allWeekShifts = dbhandler.getWeekData(weekDays[0], weekDays[6]);

            // Sets the correct data on the CalendarDayControl elements
            calendarDayControlMonday.DisplayCorrectDate(weekDays[0], "Monday", allWeekShifts);
            calendarDayControlTuesday.DisplayCorrectDate(weekDays[1], "Tuesday", allWeekShifts);
            calendarDayControlWednesday.DisplayCorrectDate(weekDays[2], "Wednesday", allWeekShifts);
            calendarDayControlThursday.DisplayCorrectDate(weekDays[3], "Thursday", allWeekShifts);
            calendarDayControlFriday.DisplayCorrectDate(weekDays[4], "Friday", allWeekShifts);
            calendarDayControlSaturday.DisplayCorrectDate(weekDays[5], "Saturday", allWeekShifts);
            calendarDayControlSunday.DisplayCorrectDate(weekDays[6], "Sunday", allWeekShifts);
        }

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
                    if (!(bool)row.Cells["active"].Value)
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
                {
                    if (!(bool)row.Cells["active"].Value)
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
            edw = new EmployeeDetailsWindow();
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
            int id = Convert.ToInt32(dataGridViewEmployees.SelectedCells[0].Value);
            Employee toEdit = dbhandler.GetEmployee(id);
            edw = new EmployeeDetailsWindow();
            edw.AddEmployeeData(toEdit);
            if (edw.ShowDialog() == DialogResult.OK)
            {
                PopulateEmployeesTable();
                HideInactiveEmployees(!checkBoxShowInactive.Checked);
            }
        }

        /// <summary>
        /// Adds a department to the combobox and database
        /// </summary>
        private void EmployeeDepartmentAdd()
        {
            string newDepartmentName = Interaction.InputBox("Department name:", "Create a new department");

            if (newDepartmentName != string.Empty)
            {
                dbhandler = new Classes.DatabaseHandler();
                dbhandler.CreateNewDepartment(newDepartmentName);
                comboBoxAllDepartments.Items.Add(newDepartmentName);
            }
        }

        /// <summary>
        /// Removes a department from the combobox and database
        /// </summary>
        private void EmployeeDepartmentRemove()
        {
            if (comboBoxAllDepartments.SelectedIndex != -1)
            {
                Department departmentToRemove = (comboBoxAllDepartments.SelectedItem as dynamic).Department;
                if (departmentToRemove != null)
                {
                    dbhandler = new Classes.DatabaseHandler();
                    dbhandler.RemoveDepartment(departmentToRemove.Id);
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
            pdw = new ProductDetailsWindow();
            if (pdw.ShowDialog() == DialogResult.OK)
            {
                dbhandler.CreateItem(pdw.Item);
                PopulateItemsTable();
            }
        }

        /// <summary>
        /// Opens a new ProductDetailsWindow so the user can modify the product they have selected
        /// </summary>
        private void StockModify()
        {
            int id = Convert.ToInt32(dataGridViewStock.SelectedCells[0].Value);
            Item toEdit = dbhandler.GetItem(id);
            pdw = new ProductDetailsWindow();
            pdw.AddItemData(toEdit);
            if (pdw.ShowDialog() == DialogResult.OK)
            {
                dbhandler.UpdateItem(pdw.Item);
                PopulateItemsTable();
                HideInactiveItems(!checkBoxShowInactiveItems.Checked);
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
            if (numericUpDownSchedulingWeek.Value == 52)
            {
                numericUpDownSchedulingWeek.Value = 1;
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
                numericUpDownSchedulingWeek.Value = 52;
            }
            else
            {
                numericUpDownSchedulingWeek.Value -= 1;
            }
            SetupCorrectWeekData();
        }
        #endregion

        /// <summary>
        /// Function to reload all data from the database
        /// </summary>
        private void ReloadData()
        {
            PopulateEmployeesTable();
            PopulateItemsTable();
            SetupCorrectWeekData();
            LoadAllDepartments();
            MessageBox.Show("Database Reloaded");
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
            ReloadData();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Logout();
        }
    } 
    #endregion
}
