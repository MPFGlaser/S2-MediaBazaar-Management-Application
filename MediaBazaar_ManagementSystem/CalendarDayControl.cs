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

        /// <summary>
        /// A user control that provides the user with 3 shifts for a pre-determined day of the year.
        /// <para>Has counters to indicate the occupancy of the shift.</para>
        /// </summary>
        public CalendarDayControl()
        {
            InitializeComponent();
        }

        #region Logic
        /// <summary>
        /// Displays the given date, weekday, and selection of shifts in the user control.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="weekday"></param>
        /// <param name="allWeekShifts"></param>
        public void DisplayCorrectDate(DateTime date, string weekday, List<Shift> allWeekShifts)
        {
            this.date = date;
            textBoxCalendarDay.Text = weekday;
            textBoxCalendarDate.Text = date.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")) + " " + date.Day;
            foreach (Shift s in allWeekShifts)
            {
                if (s.Date == date)
                {
                    SetShiftOccupation(s.ShiftTime, s.EmployeeIds);
                }
            }
        }

        /// <summary>
        /// Sets the occupation counter of each shift to the correct amount as determined by the amount of employeeIds present for that shift.
        /// </summary>
        /// <param name="shiftTime"></param>
        /// <param name="employeeIds"></param>
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
        #endregion

        #region Button-related functions
        private void buttonMorning_Click(object sender, EventArgs e)
        {
            // Refreshes the shift data from the database
            shiftEmployees.Clear();
            dbhandler = new DatabaseHandler();
            newShift = dbhandler.GetShift(date, ShiftTime.Morning);

            // If a shift exists, show it. Else create a new one
            if (newShift != null)
            {
                shiftEmployees = dbhandler.GetShiftEmployees(newShift.Id);
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Morning, date, shiftEmployees, true, newShift.Id);
            }
            else
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Morning, date, shiftEmployees, false, 0);
            }

            // Show a dialog for the shift
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                SetShiftOccupation(ShiftTime.Morning, schedule.WorkingEmployeeIds);
            }
        }

        private void buttonAfternoon_Click(object sender, EventArgs e)
        {
            // Refreshes the shift data from the database
            shiftEmployees.Clear();
            dbhandler = new DatabaseHandler();
            newShift = dbhandler.GetShift(date, ShiftTime.Afternoon);

            // If a shift exists, show it. Else create a new one
            if (newShift != null)
            {
                shiftEmployees = dbhandler.GetShiftEmployees(newShift.Id);
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Afternoon, date, shiftEmployees, true, newShift.Id);
            }
            else
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Afternoon, date, shiftEmployees, false, 0);
            }

            // Show a dialog for the shift
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                SetShiftOccupation(ShiftTime.Afternoon, schedule.WorkingEmployeeIds);
            }
        }

        private void buttonEvening_Click(object sender, EventArgs e)
        {
            // Refreshes the shift data from the database
            shiftEmployees.Clear();
            dbhandler = new DatabaseHandler();
            newShift = dbhandler.GetShift(date, ShiftTime.Evening);

            // If a shift exists, show it. Else create a new one
            if (newShift != null)
            {
                shiftEmployees = dbhandler.GetShiftEmployees(newShift.Id);
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Evening, date, shiftEmployees, true, newShift.Id);
            }
            else
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Evening, date, shiftEmployees, false, 0);
            }

            // Show a dialog for the shift
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                SetShiftOccupation(ShiftTime.Evening, schedule.WorkingEmployeeIds);
            }
        }
        #endregion
    }
}
