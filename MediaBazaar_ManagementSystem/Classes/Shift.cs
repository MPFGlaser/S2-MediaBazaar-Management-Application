using MediaBazaar_ManagementSystem.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.Classes
{
    public class Shift
    {
        private int id, shiftType;
        private List<int> employeeIds;
        private DateTime date;

        public Shift(int id, DateTime date, int shiftType)
        {
            this.id = id;
            this.date = date;
            this.shiftType = shiftType;
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

        public int ShiftType
        {
            get { return shiftType; }
            set { shiftType = value; }
        }
    }
}
