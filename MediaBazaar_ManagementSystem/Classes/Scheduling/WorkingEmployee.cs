using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.Classes.Scheduling
{
    /// <summary>
    /// 
    /// </summary>
    class WorkingEmployee
    {
        private int shiftId, employeeId, departmentId;

        public WorkingEmployee(int shiftId, int employeeId, int departmentId)
        {
            this.shiftId = shiftId;
            this.employeeId = employeeId;
            this.departmentId = departmentId;
        }

        #region Properties
        public int ShiftId
        {
            get { return shiftId; }
        }

        public int EmployeeId
        {
            get { return employeeId; }
        }

        public int DepartmentId
        {
            get { return departmentId; }
        }

        #endregion
    }
}
