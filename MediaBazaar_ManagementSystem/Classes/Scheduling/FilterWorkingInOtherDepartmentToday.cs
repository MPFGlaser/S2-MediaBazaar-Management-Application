using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaBazaar_ManagementSystem
{
    public class FilterWorkingInOtherDepartmentToday : IFilter
    {
        public List<Employee> Filter(Shift shift, int departmentId, List<Shift> weekShifts, List<WorkingEmployee> workingEmployees, List<Employee> employees)
        {
            List<Employee> output = new List<Employee>();
            List<Shift> shiftsToday = new List<Shift>();

            foreach (Shift shiftInWeek in weekShifts)
            {
                if (shiftInWeek.Date == shift.Date)
                {
                    shiftsToday.Add(shiftInWeek);
                }
            }

            // Removes all entries from workingEmployees that don't relate to today.
            workingEmployees.RemoveAll(workingEmployee => 
            workingEmployee.ShiftId != shiftsToday[0].Id &&
            workingEmployee.ShiftId != shiftsToday[1].Id &&
            workingEmployee.ShiftId != shiftsToday[2].Id);


            // Loops through every employee.
            foreach (Employee employee in employees)
            {
                bool scheduledInOtherDepartment = false;

                // Goes through each workingEmployee entry.
                foreach(WorkingEmployee workingEmployee in workingEmployees)
                {
                    // Looks for workingEmployee entry with the same employeeId as the employee.
                    if(workingEmployee.EmployeeId == employee.Id)
                    {
                        // Checks if a departmentId shows up that's different from the one supplied to the filter.
                        if(workingEmployee.DepartmentId != departmentId)
                        {
                            scheduledInOtherDepartment = true;
                        }
                    }
                }

                // If the employee is not scheduled in another department, then add them to the output list.
                if (!scheduledInOtherDepartment)
                {
                    output.Add(employee);
                }
            }

            return output;
        }
    }
}