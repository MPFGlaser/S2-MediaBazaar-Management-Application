using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IEmployeeStorage
    {
        bool Create(Employee employee);

        bool Update(Employee employee);

        Employee Get(int id);

        List<Employee> GetAll(bool activeOnly);

        Dictionary<int, string> GetFunctions();

        void CheckFunctions();

        List<Employee> GetHoursWorked(List<Employee> selectedEmployee, DateTime monday, DateTime sunday);

        List<int> GetShiftIdsInWeek(DateTime monday, DateTime sunday);
    }
}
