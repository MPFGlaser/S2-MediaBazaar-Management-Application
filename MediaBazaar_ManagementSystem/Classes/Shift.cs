using MediaBazaar_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem
{
    /// <summary>
    /// Class for everything related to aa shift, as it appears in the database.
    /// </summary>
    public class Shift
    {
        private int id;
        private List<int> employeeIds;
        private DateTime date;
        private ShiftTime shiftTime;

        public Shift(int id, DateTime date, ShiftTime shiftTime)
        {
            this.id = id;
            this.date = date;
            this.shiftTime = shiftTime;
        }

        public int Id
        {
            get { return id; }
        }

        public List<int> EmployeeIds
        {
            get { return employeeIds; }
            set { employeeIds = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public ShiftTime ShiftTime
        {
            get { return shiftTime; }
            set { shiftTime = value; }
        }
    }
}
