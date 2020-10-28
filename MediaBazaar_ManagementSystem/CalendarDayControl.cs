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

        public void DisplayCorrectDate(DateTime date, string weekday)
        {
            this.date = date;
            textBoxCalendarDay.Text = weekday;
            textBoxCalendarDate.Text = date.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")) + " " + date.Day;
            SetShiftOccupation();
        }

        private void SetShiftOccupation()
        {
            dbhandler = new DatabaseHandler();

            int shiftMorningId = dbhandler.ShiftExist(date, ShiftTime.Morning);
            int shiftAfternoonId = dbhandler.ShiftExist(date, ShiftTime.Afternoon);
            int shiftEveningId = dbhandler.ShiftExist(date, ShiftTime.Evening);

            if (shiftMorningId != 0)
            {
                textBoxCapacityMorning.Text = dbhandler.ShiftOccupation(shiftMorningId).ToString();
            }
            else
            {
                textBoxCapacityMorning.Text = "N/A";
            }

            if (shiftAfternoonId != 0)
            {
                textBoxCapacityAfternoon.Text = dbhandler.ShiftOccupation(shiftAfternoonId).ToString();
            }
            else
            {
                textBoxCapacityAfternoon.Text = "N/A";
            }

            if (shiftEveningId != 0)
            {
                textBoxCapacityEvening.Text = dbhandler.ShiftOccupation(shiftEveningId).ToString();
            }
            else
            {
                textBoxCapacityEvening.Text = "N/A";
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
                //dbhandler.ClearShift(newShift.Id);
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Morning, date, shiftEmployees, true, newShift.Id);
            }
            else
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Morning, date, shiftEmployees, false, 0);
            }

            
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("It happended");
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
                //dbhandler.ClearShift(newShift.Id);
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Afternoon, date, shiftEmployees, true, newShift.Id);
            }
            else
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Afternoon, date, shiftEmployees, false, 0);
            }
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("It happended");
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
                //dbhandler.ClearShift(newShift.Id);
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Evening, date, shiftEmployees, true, newShift.Id);
            }
            else
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Evening, date, shiftEmployees, false, 0);
            }
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("It happended");
            }
        }
    }
}
