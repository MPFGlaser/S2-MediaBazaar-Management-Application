﻿using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public class FilterContractHoursViolation : IFilter
    {
        public List<Employee> Filter(int shiftId, int departmentId, List<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Filter(List<WorkingEmployee> workingEmployees, List<Employee> employees)
        {
            throw new NotImplementedException();
        }
    }
}