using MediaBazaar_ManagementSystem.classes;
using MediaBazaar_ManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazaar_ManagementSystem.Models;

namespace MediaBazaar_ManagementSystem
{
    public partial class SchedulingWindow : Form
    {
        DatabaseHandler dbhandler;
        private Shift currentShift;
        private DateTime date;
        private ShiftTime shiftTime;
        List<int> workingEmployeeIds = new List<int>();

        public SchedulingWindow(string dateAndMonth, string weekDay, ShiftTime shiftTime, DateTime date, List<Employee> working)
        {
            InitializeComponent();
            InitializeComboBoxShiftTime();
            PopulateComboBoxShiftTime();
            LoadEmployees(working);
            this.date = date;
            this.shiftTime = shiftTime;
            this.comboBoxShiftTime.SelectedItem = shiftTime;
            textBoxWeekDay.Text = weekDay;
            textBoxCalendarDate.Text = dateAndMonth;

            AddEmployeeListToShift(working);
        }

        private void LoadEmployees(List<Employee> working)
        {
            dbhandler = new DatabaseHandler();
            List<Employee> allActiveEmployees = dbhandler.GetActiveEmployeesFromDB();

            foreach(Employee e in working)
            {
                workingEmployeeIds.Add(e.Id);
            }

            foreach(Employee e in allActiveEmployees)
            {
                if (!workingEmployeeIds.Contains(e.Id))
                {
                    comboBoxSelectEmployees.DisplayMember = "Text";
                    comboBoxSelectEmployees.ValueMember = "Employee";
                    comboBoxSelectEmployees.Items.Add(new { Text = e.FirstName + " " + e.SurName, Employee = e });
                }
            }
        }

        private void InitializeComboBoxShiftTime()
        {
            this.comboBoxShiftTime.SelectedIndexChanged += new System.EventHandler(comboBoxShiftTime_SelectedIndexChanged);
        }

        private void PopulateComboBoxShiftTime()
        {
            this.comboBoxShiftTime.DataSource = Enum.GetValues(typeof(ShiftTime));
        }

        private void comboBoxShiftTime_SelectedIndexChanged(Object sender, EventArgs e)
        {
            this.shiftTime = (ShiftTime)comboBoxShiftTime.SelectedItem;
        }

        private void AddEmployeeListToShift(List<Employee> toAddToShift)
        {
            foreach(Employee e in toAddToShift)
            {
                listBoxCurrentEmployees.DisplayMember = "Text";
                listBoxCurrentEmployees.ValueMember = "Employee";
                listBoxCurrentEmployees.Items.Add(new { Text = e.FirstName + " " + e.SurName, Employee = e });
            }
        }

        private void buttonAddEmployeeToShift_Click(object sender, EventArgs e)
        {
            if(comboBoxSelectEmployees.SelectedIndex != -1)
            {
                Employee selected = (comboBoxSelectEmployees.SelectedItem as dynamic).Employee;
                listBoxCurrentEmployees.DisplayMember = "Text";
                listBoxCurrentEmployees.ValueMember = "Employee";
                listBoxCurrentEmployees.Items.Add(new { Text = selected.FirstName + " " + selected.SurName, Employee = selected });

                comboBoxSelectEmployees.Items.Remove(comboBoxSelectEmployees.SelectedItem);
                comboBoxSelectEmployees.SelectedIndex = -1;
            }
        }

        private void buttonRemoveEmployeeFromShift_Click(object sender, EventArgs e)
        {
            Employee selected = (listBoxCurrentEmployees.SelectedItem as dynamic).Employee;
            comboBoxSelectEmployees.DisplayMember = "Text";
            comboBoxSelectEmployees.ValueMember = "Employee";
            comboBoxSelectEmployees.Items.Add(new { Text = selected.FirstName + " " + selected.SurName, Employee = selected });

            listBoxCurrentEmployees.Items.Remove(listBoxCurrentEmployees.SelectedItem);
        }

        private void buttonScheduleConfirm_Click(object sender, EventArgs e)
        {
            dbhandler = new DatabaseHandler();
            foreach (dynamic emp in listBoxCurrentEmployees.Items)
            {
                workingEmployeeIds.Add((emp).Employee.Id);
            }

            currentShift = new Shift(0, date, shiftTime);
            currentShift.EmployeeIds = workingEmployeeIds;

            dbhandler.AddShiftToDb(currentShift);

            this.DialogResult = DialogResult.OK;
        }

        private void buttonScheduleCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
