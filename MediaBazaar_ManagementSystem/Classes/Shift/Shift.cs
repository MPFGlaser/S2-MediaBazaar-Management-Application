using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    /// <summary>
    /// Class for everything related to aa shift, as it appears in the shiftStorage.
    /// </summary>
    public class Shift
    {
        private int id, capacity;
        private List<int> employeeIds;
        private DateTime date;
        private ShiftTime shiftTime;

        public Shift(int id, DateTime date, ShiftTime shiftTime, int capacity)
        {
            this.id = id;
            this.date = date;
            this.shiftTime = shiftTime;
            this.capacity = capacity;
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

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
    }
}
