using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;

namespace MediaBazaar_ManagementSystem
{
    public partial class CalendarDayControl : UserControl
    {
        SchedulingWindow schedule;
        IShiftStorage shiftStorage;
        private DateTime date;
        Shift newShift;
        List<Employee> shiftEmployees = new List<Employee>(), allEmployees;
        private Department currentSelectedDepartment = null;
        private Employee loggedInUser = null;

        public delegate void ReloadCalendarDayHelper();
        public event ReloadCalendarDayHelper ReloadCalendarDayEvent;

        public delegate void ReloadEmployeeHoursHelper();
        public event ReloadEmployeeHoursHelper ReloadEmployeeHoursEvent;

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
        public void DisplayCorrectDate(DateTime date, string weekday, List<Shift> allWeekShifts, Employee loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            this.date = date;

            labelCalendarDay.Text = weekday;
            labelCalendarDate.Text = date.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")) + " " + date.Day;

            labelCapacityMorning.Text = "N/A";
            labelCapacityAfternoon.Text = "N/A";
            labelCapacityEvening.Text = "N/A";

            labelCapacityMorning.BackColor = Color.Red;
            labelCapacityAfternoon.BackColor = Color.Red;
            labelCapacityEvening.BackColor = Color.Red;


            foreach (Shift s in allWeekShifts)
            {
                if (s.Date == date)
                {
                    int numberScheduled = s.EmployeeIds.Count();
                    SetShiftOccupation(s.ShiftTime, numberScheduled, s.Capacity);
                }
            }
        }

        public void SetupEmployees(List<Employee> allEmployees)
        {
            this.allEmployees = allEmployees;
        }

        /// <summary>
        /// Sets the occupation counter of each shift to the correct amount as determined by the amount of employeeIds present for that shift.
        /// </summary>
        /// <param name="shiftTime"></param>
        /// <param name="employeeIds"></param>
        private void SetShiftOccupation(ShiftTime shiftTime, int numberScheduled, int capacity)
        {
            switch (shiftTime)
            {
                case ShiftTime.Morning:
                    labelCapacityMorning.Text = $"{numberScheduled}/{capacity}";
                    labelCapacityMorning.BackColor = IndicatorColor(numberScheduled, capacity);
                    break;

                case ShiftTime.Afternoon:
                    labelCapacityAfternoon.Text = $"{numberScheduled}/{capacity}";
                    labelCapacityAfternoon.BackColor = IndicatorColor(numberScheduled, capacity);
                    break;

                case ShiftTime.Evening:
                    labelCapacityEvening.Text = $"{numberScheduled}/{capacity}";
                    labelCapacityEvening.BackColor = IndicatorColor(numberScheduled, capacity);
                    break;

                default:
                    break;
            }
        }

        private Color IndicatorColor(int numberScheduled, int capacity)
        {
            Color output = Color.Transparent;

            if(numberScheduled < capacity)
            {
                output = Color.Red;
            }

            if(numberScheduled == capacity)
            {
                output = Color.Lime;
            }

            if(numberScheduled > capacity)
            {
                output = Color.DarkOrange;
            }

            if(numberScheduled == 0 || capacity == 0)
            {
                output = Color.Red;
            }

            return output;
        }

        /// <summary>
        /// Shows the correct shift upon execution.
        /// </summary>
        /// <param name="time"></param>
        private void ShowShift(ShiftTime time)
        {
            // Refreshes the shift data from the shiftStorage
            shiftEmployees.Clear();
            shiftStorage = new ShiftMySQL();
            newShift = shiftStorage.Get(date, time);

            //Department currentSelectedDepartment = currentSelectedDepartment();

            // If a shift exists, show it. Else create a new one
            if (newShift != null)
            {
                shiftEmployees = shiftStorage.GetEmployees(newShift.Id);
                schedule = new SchedulingWindow(labelCalendarDate.Text, labelCalendarDay.Text, time, date, shiftEmployees, true, newShift.Id, newShift.Capacity, allEmployees, currentSelectedDepartment, loggedInUser);
            }
            else
            {
                schedule = new SchedulingWindow(labelCalendarDate.Text, labelCalendarDay.Text, time, date, shiftEmployees, false, 0, 0, allEmployees, currentSelectedDepartment, loggedInUser);
            }

            // Show a dialog for the shift
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                ReloadCalendarDayEvent?.Invoke();
                ReloadEmployeeHoursEvent?.Invoke();
            }
        }
        #endregion

        #region Button-related functions
        public Department CurrentSelectedDepartment
        {
            set { this.currentSelectedDepartment = value; }
        }

        private void buttonMorning_Click(object sender, EventArgs e)
        {
            ShowShift(ShiftTime.Morning);
        }

        private void buttonAfternoon_Click(object sender, EventArgs e)
        {
            ShowShift(ShiftTime.Afternoon);
        }

        private void buttonEvening_Click(object sender, EventArgs e)
        {
            ShowShift(ShiftTime.Evening);
        }
        #endregion

        #region element enabling/disabling
        public void ToggleCalendarDayControlButtons(bool newValue)
        {
            buttonMorning.Enabled = newValue;
            buttonAfternoon.Enabled = newValue;
            buttonEvening.Enabled = newValue;
        }
        #endregion
    }
}
