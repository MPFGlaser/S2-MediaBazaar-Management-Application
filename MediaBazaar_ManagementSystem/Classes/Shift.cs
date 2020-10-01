using MediaBazaar_ManagementSystem.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.Classes
{
    class Shift
    {
        private int id;
        private List<Employee> employees;
        private DateTime startTime, endTime;

        public Shift(int id, DateTime startTime, DateTime endTime)
        {
            this.id = id;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public List<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }
}
