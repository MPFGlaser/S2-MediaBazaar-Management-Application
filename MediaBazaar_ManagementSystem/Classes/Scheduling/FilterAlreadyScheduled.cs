﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaBazaar_ManagementSystem
{
    public class FilterAlreadyScheduled : IFilter
    {
        public List<Employee> Filter(Shift shift, int departmentId, List<Shift> weekShifts, List<WorkingEmployee> workingEmployees, List<Employee> employees)
        {
            List<Employee> output = new List<Employee>();

            // Removes all irrelevant entries (i.e. anything not related to this shift) from workingEmployees
            List<WorkingEmployee> relevantWorkingEmployees = new List<WorkingEmployee>(workingEmployees);
            relevantWorkingEmployees.RemoveAll(workingEmployee => workingEmployee.ShiftId != shift.Id);

            // Loops through each employee
            foreach (Employee employee in employees)
            {
                // If an employeeId/shiftId combination doesn't exist, add the employee to output.
                if(!relevantWorkingEmployees.Any(WorkingEmployee => WorkingEmployee.EmployeeId == employee.Id))
                {
                    output.Add(employee);
                }
            }

            return output;
        }
    }
}