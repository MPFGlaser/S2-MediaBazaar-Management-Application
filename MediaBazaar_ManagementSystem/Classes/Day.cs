using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem.Classes
{
    /// <summary>
    /// Class for Day objects.
    /// </summary>
    public class Day
    {
        private DateTime date;
        private List<Shift> shifts;

        Day(DateTime date)
        {
            this.date = date;
        }

        public DateTime Date
        {
            get { return date; }
        }

        public List<Shift> Shifts
        {
            get { return shifts; }
            set { shifts = value; }
        }
    }
}
