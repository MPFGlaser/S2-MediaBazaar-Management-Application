using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public class FilterScheduledTwiceAlready : IFilter
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
            List<WorkingEmployee> relevantWorkingEmployees = new List<WorkingEmployee>(workingEmployees);
            relevantWorkingEmployees.RemoveAll(workingEmployee =>
            workingEmployee.ShiftId != shiftsToday[0].Id &&
            workingEmployee.ShiftId != shiftsToday[1].Id &&
            workingEmployee.ShiftId != shiftsToday[2].Id);


            // Loops through every employee
            foreach (Employee employee in employees)
            {
                int scheduledToday = 0;

                //// Loops through all shifts for today
                //foreach(Shift shiftToday in shiftsToday)
                //{
                //    // Loops through all entries in workingEmployees
                //    foreach(WorkingEmployee workingEmployeeToday in workingEmployees)
                //    {
                //        // Checks if the employeeID and shiftID exist in workingExployees as an entry (i.e. employee is scheduled for that shift)
                //        if(workingEmployeeToday.EmployeeId == employee.Id && workingEmployeeToday.ShiftId == shiftToday.Id)
                //        {
                //            // If they are scheduled, add 1 to the amount of shifts they're scheduled that day
                //            scheduledToday++;
                //        }
                //    }
                //}

                foreach (WorkingEmployee workingEmployee in relevantWorkingEmployees)
                {
                    if (workingEmployee.EmployeeId == employee.Id)
                    {
                        scheduledToday++;
                    }
                }

                // As long as they're scheduled less than twice, they're available to be scheduled again. 
                if (scheduledToday < 2)
                {
                    output.Add(employee);
                }
            }

            return output;
        }
    }
}