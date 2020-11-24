using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem.Forms
{
    public partial class WeekShiftsCapacityEditor : Form
    {
        IShiftStorage shiftStorage;
        List<DateTime> weekdays;
        List<Shift> weekShifts;

        public WeekShiftsCapacityEditor(List<Shift> weekShifts, List<DateTime> weekdays)
        {
            InitializeComponent();
            this.weekShifts = weekShifts;
            this.weekdays = weekdays;
            SetupGroupboxTitles();
            SetupNumericUpDowns();
        }

        private void SetupNumericUpDowns()
        {
            foreach (Shift s in weekShifts)
            {
                if (s.Date == weekdays[0])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownMondayMorning.Value = s.Capacity;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownMondayAfternoon.Value = s.Capacity;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownMondayEvening.Value = s.Capacity;
                            break;
                    }
                }

                if (s.Date == weekdays[1])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownTuesdayMorning.Value = s.Capacity;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownTuesdayAfternoon.Value = s.Capacity;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownTuesdayEvening.Value = s.Capacity;
                            break;
                    }
                }

                if (s.Date == weekdays[2])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownWednesdayMorning.Value = s.Capacity;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownWednesdayAfternoon.Value = s.Capacity;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownWednesdayEvening.Value = s.Capacity;
                            break;
                    }
                }

                if (s.Date == weekdays[3])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownThursdayMorning.Value = s.Capacity;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownThursdayAfternoon.Value = s.Capacity;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownThursdayEvening.Value = s.Capacity;
                            break;
                    }
                }

                if (s.Date == weekdays[4])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownFridayMorning.Value = s.Capacity;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownFridayAfternoon.Value = s.Capacity;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownFridayEvening.Value = s.Capacity;
                            break;
                    }
                }

                if (s.Date == weekdays[5])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownSaturdayMorning.Value = s.Capacity;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownSaturdayAfternoon.Value = s.Capacity;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownSaturdayEvening.Value = s.Capacity;
                            break;
                    }
                }

                if (s.Date == weekdays[6])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownSundayMorning.Value = s.Capacity;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownSundayAfternoon.Value = s.Capacity;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownSundayEvening.Value = s.Capacity;
                            break;
                    }
                }
            }
        }

        private void SetupGroupboxTitles()
        {
            groupBoxMonday.Text = "Monday " + weekdays[0].ToString("dd/MM/yyyy");
            groupBoxTuesday.Text = "Tuesday " + weekdays[1].ToString("dd/MM/yyyy");
            groupBoxWednesday.Text = "Wednesday " + weekdays[2].ToString("dd/MM/yyyy");
            groupBoxThursday.Text = "Thursday " + weekdays[3].ToString("dd/MM/yyyy");
            groupBoxFriday.Text = "Friday " + weekdays[4].ToString("dd/MM/yyyy");
            groupBoxSaturday.Text = "Saturday " + weekdays[5].ToString("dd/MM/yyyy");
            groupBoxSunday.Text = "Sunday " + weekdays[6].ToString("dd/MM/yyyy");
        }

        #region control handlers
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            shiftStorage = new ShiftMySQL();
            bool success = false;


            if (success)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}
