using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IShiftStorage
    {
        int Create(Shift input);

        bool Update(Shift input);

        bool Clear(int shiftId);

        bool Assign(int shiftId, int employeeId, int departmentId);

        int Exists(DateTime date, ShiftTime time);

        Shift Get(DateTime date, ShiftTime time);

        List<Shift> GetWeek(DateTime monday, DateTime sunday);

        List<Employee> GetEmployees(int shiftId);

        List<Employee> GetDepartmentEmployees(int shiftId, int departmentId);

        int GetOccupation(int shiftId);
    }
}
