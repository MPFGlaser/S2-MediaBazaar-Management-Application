namespace MediaBazaar_ManagementSystem
{
    class EmployeeShift
    {
        private int shiftId, employeeId;

        public EmployeeShift(int shiftId, int employeeId)
        {
            this.shiftId = shiftId;
            this.employeeId = employeeId;
        }

        public int ShiftId { get { return shiftId; } }

        public int EmployeeId { get { return employeeId; } }
    }
}
