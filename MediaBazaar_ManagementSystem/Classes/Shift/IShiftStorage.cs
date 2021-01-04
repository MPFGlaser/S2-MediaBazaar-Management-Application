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

        List<Shift> GetShiftsByEmployee(int id, string date);

        List<Shift> GetWeek(DateTime monday, DateTime sunday);

        List<Employee> GetEmployees(int shiftId);

        List<Employee> GetDepartmentEmployees(int shiftId, int departmentId);

        bool UpdateCapacityPerDepartment(int shiftId, int departmentId, int capacity);

        bool AddCapacityForDepartment(int shiftId, int departmentId, int capacity);

        Dictionary<int, int> GetCapacityPerDepartment(int shiftId);

        int GetOccupation(int shiftId);

        void CreateAttendance(int employeeId, int shiftId, string clockin);

        int CheckAttendance(int userid, int shiftid);

        void ModifyClockInAttendance(int attid, string clockin);

        void ModifyClockOutAttendance(int attid, string clockout, int minutes);

        string GetClockInAttendance(int id);

        string GetClockOutAttendance(int id);
    }
}
