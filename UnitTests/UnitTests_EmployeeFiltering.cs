using MediaBazaar_ManagementSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTests_EmployeeFiltering
    {
        /// <summary>
        /// Generates the shift list (based on the week of January 4th, 2021.
        /// </summary>
        /// <returns>The list of shifts</returns>
        private List<Shift> GenerateShiftList()
        {
            List<Shift> shifts = new List<Shift>();

            shifts.Add(new Shift(1, DateTime.Parse("04/01/2021"), ShiftTime.Morning, 20));
            shifts.Add(new Shift(2, DateTime.Parse("04/01/2021"), ShiftTime.Afternoon, 20));
            shifts.Add(new Shift(3, DateTime.Parse("04/01/2021"), ShiftTime.Evening, 20));

            shifts.Add(new Shift(4, DateTime.Parse("05/01/2021"), ShiftTime.Morning, 20));
            shifts.Add(new Shift(5, DateTime.Parse("05/01/2021"), ShiftTime.Afternoon, 20));
            shifts.Add(new Shift(6, DateTime.Parse("05/01/2021"), ShiftTime.Evening, 20));

            shifts.Add(new Shift(7, DateTime.Parse("06/01/2021"), ShiftTime.Morning, 20));
            shifts.Add(new Shift(8, DateTime.Parse("06/01/2021"), ShiftTime.Afternoon, 20));
            shifts.Add(new Shift(9, DateTime.Parse("06/01/2021"), ShiftTime.Evening, 20));

            shifts.Add(new Shift(10, DateTime.Parse("07/01/2021"), ShiftTime.Morning, 20));
            shifts.Add(new Shift(11, DateTime.Parse("07/01/2021"), ShiftTime.Afternoon, 20));
            shifts.Add(new Shift(12, DateTime.Parse("07/01/2021"), ShiftTime.Evening, 20));

            shifts.Add(new Shift(13, DateTime.Parse("08/01/2021"), ShiftTime.Morning, 20));
            shifts.Add(new Shift(14, DateTime.Parse("08/01/2021"), ShiftTime.Afternoon, 20));
            shifts.Add(new Shift(15, DateTime.Parse("08/01/2021"), ShiftTime.Evening, 20));

            shifts.Add(new Shift(16, DateTime.Parse("09/01/2021"), ShiftTime.Morning, 20));
            shifts.Add(new Shift(17, DateTime.Parse("09/01/2021"), ShiftTime.Afternoon, 20));
            shifts.Add(new Shift(18, DateTime.Parse("09/01/2021"), ShiftTime.Evening, 20));

            shifts.Add(new Shift(19, DateTime.Parse("10/01/2021"), ShiftTime.Morning, 20));
            shifts.Add(new Shift(20, DateTime.Parse("10/01/2021"), ShiftTime.Afternoon, 20));
            shifts.Add(new Shift(21, DateTime.Parse("10/01/2021"), ShiftTime.Evening, 20));

            return shifts;
        }

        /// <summary>
        /// Generates the working employee list.
        /// </summary>
        /// <returns></returns>
        private List<WorkingEmployee> GenerateWorkingEmployeeList()
        {
            // Data based on that found in the production database as of 2020/01/04 11:15
            List<WorkingEmployee> workingEmployees = new List<WorkingEmployee>();

            workingEmployees.Add(new WorkingEmployee(22, 7, 9));
            workingEmployees.Add(new WorkingEmployee(8, 7, 9));
            workingEmployees.Add(new WorkingEmployee(8, 7, 9));
            workingEmployees.Add(new WorkingEmployee(44, 7, 9));
            workingEmployees.Add(new WorkingEmployee(46, 18, 9));
            workingEmployees.Add(new WorkingEmployee(43, 18, 9));
            workingEmployees.Add(new WorkingEmployee(69, 27, 0));
            workingEmployees.Add(new WorkingEmployee(70, 27, 3));
            workingEmployees.Add(new WorkingEmployee(71, 27, 3));
            workingEmployees.Add(new WorkingEmployee(72, 27, 3));
            workingEmployees.Add(new WorkingEmployee(73, 27, 3));
            workingEmployees.Add(new WorkingEmployee(74, 27, 3));
            workingEmployees.Add(new WorkingEmployee(75, 27, 3));


            return workingEmployees;
        }

        /// <summary>
        /// Generates the employee list.
        /// </summary>
        /// <returns></returns>
        private List<Employee> GenerateEmployeeList()
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee(1, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(2, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(3, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(4, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(5, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(6, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(7, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(8, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(9, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(10, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(11, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(12, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(13, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(14, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(15, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(16, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(17, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(18, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(19, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(20, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(21, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));

            return employees;
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
