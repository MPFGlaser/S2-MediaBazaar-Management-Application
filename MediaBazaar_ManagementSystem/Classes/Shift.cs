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
        private List<Employee> employees;
        private DateTime date;

        //Perhaps change starttime and endtime to date and shifttype (morning, afternoon, evening)
        public Shift(int id, DateTime date, int shiftType)
        {
            this.id = id;
            this.date = date;
            this.shiftType = shiftType;
        }

        public List<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
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
