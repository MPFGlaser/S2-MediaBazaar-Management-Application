﻿using MediaBazaar_ManagementSystem.classes;
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

namespace MediaBazaar_ManagementSystem
{
    public partial class MainWindow : Form
    {
        DatabaseHandler dbhandler;
        EmployeeDetailsWindow edw;
        List<DateTime> weekDays = new List<DateTime>();
        ProductDetailsWindow pdw;

        public MainWindow()
        {
            InitializeComponent();
            InitializeNumericUpDown();
            dbhandler = new Classes.DatabaseHandler();
            PopulateEmployeesTable();
            numericUpDownSchedulingWeek.Value = GetWeekOfYear(DateTime.Now);
            SetupCorrectWeekData();
        }

        private void InitializeNumericUpDown()
        {
            this.numericUpDownSchedulingWeek.ValueChanged += new System.EventHandler(numericUpDownSchedulingWeek_ValueChanged);

            dbhandler = new Classes.DatabaseHandler();
            PopulateEmployeesTable();
            PopulateItemsTable();
            HideInactiveEmployees(true);
            HideInactiveItems(true);

            // Removes statistics tab until implementation is finished in the future.
            tabControl1.TabPages.Remove(tabPage3);
        }

        private void PopulateEmployeesTable()
        {
            dataGridViewEmployees.Rows.Clear();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting employee info.\n" + ex.ToString());
            }
        }

        private void PopulateItemsTable()
        {
            dataGridViewStock.Rows.Clear();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting employee info.\n" + ex.ToString());
            }
        }

        private void DataButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            Series TestDataPoints = StatisticChart.Series["TestData"];

            TestDataPoints.Points.Clear();

            for (int i = 1; i <= 10; i++) {
                int data = rand.Next(1, 101);
                TestDataPoints.Points.Add(data, i);
            }
        }

        private void buttonEmployeesAdd_Click(object sender, EventArgs e)
        {
            edw = new EmployeeDetailsWindow();
            if(edw.ShowDialog() == DialogResult.OK)
            {
                dbhandler.CreateEmployee(edw.Employee);
                PopulateEmployeesTable();
            }
        }

        private void buttonEmployeeModify_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewEmployees.SelectedCells[0].Value);
            Employee toEdit = dbhandler.GetEmployee(id);
            edw = new EmployeeDetailsWindow();
            edw.AddEmployeeData(toEdit);
            if (edw.ShowDialog() == DialogResult.OK)
            {
                dbhandler.UpdateEmployee(edw.Employee);
                PopulateEmployeesTable();
                HideInactiveEmployees(!checkBoxShowInactive.Checked);
            }
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

        private void buttonStockEditProduct_Click(object sender, EventArgs e)
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

        private void buttonStockAdd_Click(object sender, EventArgs e)
        {
            pdw = new ProductDetailsWindow();
            if (pdw.ShowDialog() == DialogResult.OK)
            {
                dbhandler.CreateItem(pdw.Item);
                PopulateItemsTable();
            }
        }

        private void numericUpDownSchedulingWeek_ValueChanged(Object sender, EventArgs e)
        {
            SetupCorrectWeekData();
        }

        private void SetupCorrectWeekData()
        {
            int weekNumber = Convert.ToInt32(numericUpDownSchedulingWeek.Value);
            weekDays = FirstDateOfWeekISO8601(2020, weekNumber);

            calendarDayControlMonday.DisplayCorrectDate(weekDays[0], "Monday");
            calendarDayControlTuesday.DisplayCorrectDate(weekDays[1], "Tuesday");
            calendarDayControlWednesday.DisplayCorrectDate(weekDays[2], "Wednesday");
            calendarDayControlThursday.DisplayCorrectDate(weekDays[3], "Thursday");
            calendarDayControlFriday.DisplayCorrectDate(weekDays[4], "Friday");
            calendarDayControlSaturday.DisplayCorrectDate(weekDays[5], "Saturday");
            calendarDayControlSunday.DisplayCorrectDate(weekDays[6], "Sunday");
        }

        private void buttonSchedulingPrevious_Click(object sender, EventArgs e)
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

        private void buttonSchedulingNext_Click(object sender, EventArgs e)
        {
            if(numericUpDownSchedulingWeek.Value == 52)
            {
                numericUpDownSchedulingWeek.Value = 1;
            }
            else
            {
                numericUpDownSchedulingWeek.Value += 1;
            }
            SetupCorrectWeekData();
        }

        private int GetWeekOfYear(DateTime currentDate)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            int weekNumber = ci.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNumber;
        }

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
            for(int i = 0; i < 7; i++)
            {
                daysBasedOnWeekNumber.Add(result.AddDays(-3 + i));
            }
            return daysBasedOnWeekNumber;
        }
    }
}
