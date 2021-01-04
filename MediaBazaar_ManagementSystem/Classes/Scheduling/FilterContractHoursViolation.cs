using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaBazaar_ManagementSystem
{
    public class FilterContractHoursViolation : IFilter
    {
        public List<Employee> Filter(Shift shift, int departmentId, List<Shift> weekShifts, List<WorkingEmployee> workingEmployees, List<Employee> employees)
        {
            List<Employee> output = new List<Employee>();

            foreach(Employee employee in employees)
            {
                float hoursWorkedThisWeek = 0;

                foreach(Shift s in weekShifts)
                {
                    if(workingEmployees.Any(workingEmployee =>
                    workingEmployee.ShiftId == s.Id &&
                    workingEmployee.EmployeeId == employee.Id))
                    {
                        hoursWorkedThisWeek += Globals.shiftDuration;
                    }
                }

                if(employee.ContractHours >= (hoursWorkedThisWeek + Globals.shiftDuration))
                {
                    output.Add(employee);
                }
            }

            return output;
        }
    }
}