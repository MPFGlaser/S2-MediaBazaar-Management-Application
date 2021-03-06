﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IEmployeeStorage
    {
        bool Create(Employee employee);

        bool Update(Employee employee);

        Employee Get(int id);

        List<Employee> GetAll(bool activeOnly);

        List<Employee> GetHoursWorked(List<Employee> selectedEmployee, DateTime monday, DateTime sunday);

        List<int> GetShiftIdsInWeek(DateTime monday, DateTime sunday);

        int CheckNrOfShifts(int id, string date);

        List<(int, DateTime)> GetAbsentDays();

        List<string> GetAbsentDaysForEmployee(int employeeid);

        List<WorkingEmployee> GetWorkingEmployees();

        int GetMinutesWorked(DateTime date, int employeeid);

        ArrayList GetEmployeeStatistics(int employeeid);
    }
}