using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public class FilterSickOrDayOff : IFilter
    {
        public List<Employee> Filter(Shift shift, int departmentId, List<Shift> weekShifts, List<WorkingEmployee> workingEmployees, List<Employee> employees)
        {
            List<Employee> output = new List<Employee>();

            foreach(Employee employee in employees)
            {
                if (!employee.NotWorkingDays.Contains(shift.Date))
                {
                    output.Add(employee);
                }
            }

            return output;
        }
    }
}