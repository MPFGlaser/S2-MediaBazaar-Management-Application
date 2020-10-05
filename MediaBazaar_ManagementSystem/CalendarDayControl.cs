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

namespace MediaBazaar_ManagementSystem
{
    public partial class CalendarDayControl : UserControl
    {
        SchedulingWindow schedule;
        private DateTime date;
        DatabaseHandler dbhandler;

        public CalendarDayControl()
        {
            InitializeComponent();
            dbhandler = new DatabaseHandler();
        }

        public void DisplayCorrectDate(DateTime date, string weekday)
        {
            this.date = date;
            textBoxCalendarDay.Text = weekday;
            textBoxCalendarDate.Text = date.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")) + " " + date.Day;
        }

        private void buttonMorning_Click(object sender, EventArgs e)
        {
            if(dbhandler.GetShift(date, ShiftTime.Morning) == null)
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Morning, date);
                if (schedule.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("It happended");
                }
            }                        
        }

        private void buttonAfternoon_Click(object sender, EventArgs e)
        {
            if (dbhandler.GetShift(date, ShiftTime.Afternoon) == null)
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Afternoon, date);
                if (schedule.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("It happended");
                }
            }
        }

        private void buttonEvening_Click(object sender, EventArgs e)
        {
            if (dbhandler.GetShift(date, ShiftTime.Evening) == null)
            {
                schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, ShiftTime.Evening, date);
                if (schedule.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("It happended");
                }
            }
        }
    }
}
