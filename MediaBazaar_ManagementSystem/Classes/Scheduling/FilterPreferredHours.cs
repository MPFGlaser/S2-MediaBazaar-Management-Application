using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public class FilterPreferredHours : IFilter
    {
        public List<Employee> Filter(Shift shift, List<Shift> weekShifts, List<WorkingEmployee> workingEmployees, List<Employee> employees)
        {
            List<Employee> output = new List<Employee>();
            DayOfWeek day = shift.Date.DayOfWeek;
            ShiftTime shiftTime = shift.ShiftTime;

            foreach(Employee employee in employees)
            {
                List<String> employeePreferredHours = SplitPreferredHours(employee.PreferredHours);
                if(WantsToWorkShift(day, shiftTime, employeePreferredHours))
                {
                    output.Add(employee);
                }
            }

            return output;
        }

        /// <summary>
        /// Splits the preferred hours into strings of 3 characters, for a total of 7 strings.
        /// </summary>
        /// <param name="preferredHours">The preferred hours.</param>
        /// <returns>A list of all 7 strings</returns>
        private List<string> SplitPreferredHours(string preferredHours)
        {
            List<string> output = new List<string>();
            int chunkSize = 3;
            int stringLength = preferredHours.Length;

            for (int i = 0; i < stringLength; i += chunkSize)
            {
                if (i + chunkSize > stringLength) chunkSize = stringLength - i;
                output.Add(preferredHours.Substring(i, chunkSize));
            }

            return output;
        }

        /// <summary>
        /// Checks if an employee wants to work a certain shift (time + day) according to their preferred hours
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="shiftTime">The shift time.</param>
        /// <param name="preferredHours">The preferred hours.</param>
        /// <returns></returns>
        private bool WantsToWorkShift(DayOfWeek day, ShiftTime shiftTime, List<string> preferredHours)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return WantsToWorkShiftTime(shiftTime, preferredHours[0]);
                case DayOfWeek.Tuesday:
                    return WantsToWorkShiftTime(shiftTime, preferredHours[1]);
                case DayOfWeek.Wednesday:
                    return WantsToWorkShiftTime(shiftTime, preferredHours[2]);
                case DayOfWeek.Thursday:
                    return WantsToWorkShiftTime(shiftTime, preferredHours[3]);
                case DayOfWeek.Friday:
                    return WantsToWorkShiftTime(shiftTime, preferredHours[4]);
                case DayOfWeek.Saturday:
                    return WantsToWorkShiftTime(shiftTime, preferredHours[5]);
                case DayOfWeek.Sunday:
                    return WantsToWorkShiftTime(shiftTime, preferredHours[6]);
            }
            return false;
        }

        /// <summary>
        /// Checks if a 3-character string of preferred hours matches the shifttime of the shift.
        /// Decides based on that whether the employee wants to work during that time and day.
        /// </summary>
        /// <param name="shiftTime">The shift time.</param>
        /// <param name="preferredHours">The preferred hours.</param>
        /// <returns></returns>
        private bool WantsToWorkShiftTime(ShiftTime shiftTime, string preferredHours)
        {
            switch (shiftTime)
            {
                case ShiftTime.Morning:
                    if(preferredHours[0].ToString() == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ShiftTime.Afternoon:
                    if (preferredHours[1].ToString() == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ShiftTime.Evening:
                    if (preferredHours[2].ToString() == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }
    }
}