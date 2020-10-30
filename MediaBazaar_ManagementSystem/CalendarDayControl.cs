using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MediaBazaar_ManagementSystem.Models;
using MediaBazaar_ManagementSystem.Classes;
using MediaBazaar_ManagementSystem.classes;

namespace MediaBazaar_ManagementSystem
{
    public partial class CalendarDayControl : UserControl
    {
        SchedulingWindow schedule;
        private DateTime date;
        DatabaseHandler dbhandler;
        Shift newShift;
        List<Employee> shiftEmployees = new List<Employee>();

        public CalendarDayControl()
        {
            InitializeComponent();
        }

        public void DisplayCorrectDate(DateTime date, string weekday, List<Shift> allWeekShifts)
        {
            this.date = date;
            textBoxCalendarDay.Text = weekday;
            textBoxCalendarDate.Text = date.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")) + " " + date.Day;
            foreach (Shift s in allWeekShifts)
            {
                if(s.Date == date)
                {
                    SetShiftOccupation(s.ShiftTime, s.EmployeeIds);
                }
            }
        }

        private void SetShiftOccupation(ShiftTime shiftTime, List<int> employeeIds)
        {
            switch (shiftTime)
            {
                case ShiftTime.Morning:
                    textBoxCapacityMorning.Text = employeeIds.Count().ToString();
                    break;

                case ShiftTime.Afternoon:
                    textBoxCapacityAfternoon.Text = employeeIds.Count().ToString();
                    break;

                case ShiftTime.Evening:
                    textBoxCapacityEvening.Text = employeeIds.Count().ToString();
                    break;

                default:
                    break;
            }
        }

        private void buttonMorning_Click(object sender, EventArgs e)
        {
            shiftEmployees.Clear();
            dbhandler = new DatabaseHandler();
            newShift = dbhandler.GetShift(date, ShiftTime.Morning);
            if (newShift != null)
            {
                shiftEmployees = dbhandler.GetShiftEmployees(newShift.Id);
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Morning, date, shiftEmployees, true, newShift.Id);
            }
            else
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Morning, date, shiftEmployees, false, 0);
            }
            
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                SetShiftOccupation(ShiftTime.Morning, new List<int>());
            }
        }

        private void buttonAfternoon_Click(object sender, EventArgs e)
        {
            shiftEmployees.Clear();
            dbhandler = new DatabaseHandler();
            newShift = dbhandler.GetShift(date, ShiftTime.Afternoon);
            if (newShift != null)
            {
                shiftEmployees = dbhandler.GetShiftEmployees(newShift.Id);
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Afternoon, date, shiftEmployees, true, newShift.Id);
            }
            else
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Afternoon, date, shiftEmployees, false, 0);
            }

            if (schedule.ShowDialog() == DialogResult.OK)
            {
                SetShiftOccupation(ShiftTime.Afternoon, new List<int>());
            }
        }

        private void buttonEvening_Click(object sender, EventArgs e)
        {
            shiftEmployees.Clear();
            dbhandler = new DatabaseHandler();
            newShift = dbhandler.GetShift(date, ShiftTime.Evening);
            if (newShift != null)
            {
                shiftEmployees = dbhandler.GetShiftEmployees(newShift.Id);
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Evening, date, shiftEmployees, true, newShift.Id);
            }
            else
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Evening, date, shiftEmployees, false, 0);
            }
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                SetShiftOccupation(ShiftTime.Evening, new List<int>());
            }
        }
    }
}
