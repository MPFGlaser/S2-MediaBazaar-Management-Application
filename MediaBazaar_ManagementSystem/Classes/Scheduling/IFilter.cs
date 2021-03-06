﻿using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IFilter
    {
        List<Employee> Filter(Shift shift, int departmentId, List<Shift> weekShifts, List<WorkingEmployee> workingEmployees, List<Employee> employees);
    }
}