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

namespace MediaBazaar_ManagementSystem
{
    public partial class CalendarDayControl : UserControl
    {
        SchedulingWindow schedule;
        private DateTime date;

        public CalendarDayControl()
        {
            InitializeComponent();
        }

        public void DisplayCorrectDate(DateTime date, string weekday)
        {
            this.date = date;
            textBoxCalendarDay.Text = weekday;
            textBoxCalendarDate.Text = date.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")) + " " + date.Day;
        }

        private void buttonMorning_Click(object sender, EventArgs e)
        {
            schedule = new SchedulingWindow(textBoxCalendarDate.Text, textBoxCalendarDay.Text, 1, date);
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("It happended");
            }
        }
    }
}
