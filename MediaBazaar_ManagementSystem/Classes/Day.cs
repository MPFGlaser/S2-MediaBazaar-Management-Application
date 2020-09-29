using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.Classes
{
    class Day
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
