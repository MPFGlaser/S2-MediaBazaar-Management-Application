﻿using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public class FilterSickOrDayOff : IFilter
    {
        public List<Employee> Filter(Shift shift, List<Shift> weekShifts, List<WorkingEmployee> workingEmployees, List<Employee> employees)
        {
            throw new NotImplementedException();
        }
    }
}