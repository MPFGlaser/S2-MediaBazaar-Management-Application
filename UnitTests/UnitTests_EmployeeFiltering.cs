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

            // Employee 1 is scheduled twice already for Monday
            workingEmployees.Add(new WorkingEmployee(1, 1, 1));
            workingEmployees.Add(new WorkingEmployee(1, 15, 1));
            workingEmployees.Add(new WorkingEmployee(2, 1, 1));
            workingEmployees.Add(new WorkingEmployee(3, 2, 1));

            // Employees 21, 1, and 9 are scheduled in different departments throughout the day (except the evening)
            workingEmployees.Add(new WorkingEmployee(4, 21, 4));
            workingEmployees.Add(new WorkingEmployee(5, 21, 4));
            workingEmployees.Add(new WorkingEmployee(4, 1, 3));
            workingEmployees.Add(new WorkingEmployee(5, 1, 3));
            workingEmployees.Add(new WorkingEmployee(4, 9, 6));
            workingEmployees.Add(new WorkingEmployee(5, 9, 6));

            workingEmployees.Add(new WorkingEmployee(7, 9, 1));
            workingEmployees.Add(new WorkingEmployee(8, 2, 1));
            workingEmployees.Add(new WorkingEmployee(8, 5, 1));
            workingEmployees.Add(new WorkingEmployee(8, 8, 1));
            workingEmployees.Add(new WorkingEmployee(8, 17, 1));
            workingEmployees.Add(new WorkingEmployee(8, 20, 1));
            workingEmployees.Add(new WorkingEmployee(9, 27, 1));

            // Employee 13 is already scheduled in department 1 on Thursday morning (shift 10)
            workingEmployees.Add(new WorkingEmployee(10, 13, 1));
            workingEmployees.Add(new WorkingEmployee(11, 8, 1));

            // Employee 20 & 21 are scheduled two times, making for 8 work hours in total
            workingEmployees.Add(new WorkingEmployee(11, 20, 1));
            workingEmployees.Add(new WorkingEmployee(11, 21, 1));
            workingEmployees.Add(new WorkingEmployee(12, 20, 1));
            workingEmployees.Add(new WorkingEmployee(12, 21, 1));

            workingEmployees.Add(new WorkingEmployee(14, 5, 1));
            workingEmployees.Add(new WorkingEmployee(15, 5, 1));
            workingEmployees.Add(new WorkingEmployee(16, 5, 1));
            workingEmployees.Add(new WorkingEmployee(17, 5, 1));
            workingEmployees.Add(new WorkingEmployee(18, 5, 1));

            // Employee 9 & 11 is scheduled twice already for Sunday
            workingEmployees.Add(new WorkingEmployee(19, 9, 1));
            workingEmployees.Add(new WorkingEmployee(20, 8, 1));
            workingEmployees.Add(new WorkingEmployee(21, 9, 1));
            workingEmployees.Add(new WorkingEmployee(19, 11, 1));
            workingEmployees.Add(new WorkingEmployee(21, 11, 1));

            return workingEmployees;
        }

        /// <summary>
        /// Generates the employee list.
        /// </summary>
        /// <returns></returns>
        private List<Employee> GenerateEmployeeList()
        {
            List<Employee> employees = new List<Employee>();

            // All days preferred
            employees.Add(new Employee(1, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 16));

            // Only wants to work on Tuesdays, Thursdays, and Saturdays.
            employees.Add(new Employee(2, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "000111000111000111000", "9,5,7,2,6,3,1,8,4", 40));

            // Can't work evenings
            employees.Add(new Employee(3, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "110110110110110110110", "9,5,7,2,6,3,1,8,4", 40));

            // Only works afternoons
            employees.Add(new Employee(4, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "010010010010010010010", "9,5,7,2,6,3,1,8,4", 40));

            // Only works mornings
            employees.Add(new Employee(5, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "100100100100100100100", "9,5,7,2,6,3,1,8,4", 40));

            // Can work all days except for Mondays & Saturdays
            employees.Add(new Employee(6, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "000111111111111000111", "9,5,7,2,6,3,1,8,4", 40));

            // May not work in department 7 & 9
            employees.Add(new Employee(7, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "5,2,6,3,1,8,4", 40));
            employees.Add(new Employee(8, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(9, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(10, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(11, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(12, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(13, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(14, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(15, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(16, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees[15].NotWorkingDays.Add(DateTime.Parse("06/01/2021"));

            // May not work in department 9. Employee 19 is also sick on Sunday
            employees.Add(new Employee(17, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(18, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees.Add(new Employee(19, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));
            employees[18].NotWorkingDays.Add(DateTime.Parse("10/01/2021"));


            // Not enough contract hours anymore (20 has 4 more left)
            employees.Add(new Employee(20, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 12));
            employees.Add(new Employee(21, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 8));

            return employees;
        }

        [TestMethod, TestCategory("Preferred Hours")]
        public void PreferredHoursFilterForMondayEveningTest()
        {
            IFilter preferredHours = new FilterPreferredHours();
            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 2);
            controlEmployees.RemoveAll(employee => employee.Id == 3);
            controlEmployees.RemoveAll(employee => employee.Id == 4);
            controlEmployees.RemoveAll(employee => employee.Id == 5);
            controlEmployees.RemoveAll(employee => employee.Id == 6);

            List<Employee> availableEmployees = preferredHours.Filter(shifts[2], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Preferred Hours")]
        public void PreferredHoursFilterForSaturdayMorningTest()
        {
            IFilter preferredHours = new FilterPreferredHours();
            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 4);
            controlEmployees.RemoveAll(employee => employee.Id == 6);

            List<Employee> availableEmployees = preferredHours.Filter(shifts[15], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Scheduled Twice")]
        public void ScheduledTwiceOnMondayEveningTest()
        {
            IFilter scheduledTwiceAlready = new FilterScheduledTwiceAlready();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 1);

            List<Employee> availableEmployees = scheduledTwiceAlready.Filter(shifts[2], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Scheduled Twice")]
        public void ScheduledTwiceOnSundayAfternoonTest()
        {
            IFilter scheduledTwiceAlready = new FilterScheduledTwiceAlready();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 9);
            controlEmployees.RemoveAll(employee => employee.Id == 11);

            List<Employee> availableEmployees = scheduledTwiceAlready.Filter(shifts[19], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Already scheduled")]
        public void AlreadyScheduledOnMondayMorningTest()
        {
            IFilter scheduledAlready = new FilterAlreadyScheduled();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 1);
            controlEmployees.RemoveAll(employee => employee.Id == 15);

            List<Employee> availableEmployees = scheduledAlready.Filter(shifts[0], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Already scheduled")]
        public void AlreadyScheduledOnWednesdayAfternoonTest()
        {
            IFilter scheduledAlready = new FilterAlreadyScheduled();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 2);
            controlEmployees.RemoveAll(employee => employee.Id == 5);
            controlEmployees.RemoveAll(employee => employee.Id == 8);
            controlEmployees.RemoveAll(employee => employee.Id == 17);
            controlEmployees.RemoveAll(employee => employee.Id == 20);

            List<Employee> availableEmployees = scheduledAlready.Filter(shifts[7], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Already scheduled in other department")]
        public void AlreadyScheduledInOtherDepartmentOnThursdayAfternoonTest()
        {
            IFilter scheduledInOtherDepartment = new FilterWorkingInOtherDepartmentToday();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 8);
            controlEmployees.RemoveAll(employee => employee.Id == 13);
            controlEmployees.RemoveAll(employee => employee.Id == 20);
            controlEmployees.RemoveAll(employee => employee.Id == 21);

            List<Employee> availableEmployees = scheduledInOtherDepartment.Filter(shifts[10], 3, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Already scheduled in other department")]
        public void AlreadyScheduledInOtherDepartmentOnTuesdayEveningTest()
        {
            IFilter scheduledInOtherDepartment = new FilterWorkingInOtherDepartmentToday();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 21);
            controlEmployees.RemoveAll(employee => employee.Id == 1);
            controlEmployees.RemoveAll(employee => employee.Id == 9);


            List<Employee> availableEmployees = scheduledInOtherDepartment.Filter(shifts[5], 5, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Sick or day off")]
        public void SickOnWednesdayTest()
        {
            IFilter sickOrDayOff = new FilterSickOrDayOff();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 16);

            List<Employee> availableEmployees = sickOrDayOff.Filter(shifts[7], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Sick or day off")]
        public void SickOnSundayTest()
        {
            IFilter sickOrDayOff = new FilterSickOrDayOff();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 19);

            List<Employee> availableEmployees = sickOrDayOff.Filter(shifts[19], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Exceeded contract hours")]
        public void ExceededContractHoursOnFridayTest()
        {
            IFilter contractHoursViolation = new FilterContractHoursViolation();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 1);
            controlEmployees.RemoveAll(employee => employee.Id == 20);
            controlEmployees.RemoveAll(employee => employee.Id == 21);


            List<Employee> availableEmployees = contractHoursViolation.Filter(shifts[12], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Exceeded contract hours")]
        public void ExceededContractHoursOnWednesdayTest()
        {
            IFilter contractHoursViolation = new FilterContractHoursViolation();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 1);
            controlEmployees.RemoveAll(employee => employee.Id == 20);
            controlEmployees.RemoveAll(employee => employee.Id == 21);

            List<Employee> availableEmployees = contractHoursViolation.Filter(shifts[7], 1, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Not allowed in department")]
        public void NotAllowedInDepartmentSingleTest()
        {
            IFilter notAllowedInDepartment = new FilterNotAllowedInDepartment();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 7);

            List<Employee> availableEmployees = notAllowedInDepartment.Filter(shifts[7], 7, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod, TestCategory("Not allowed in department")]
        public void NotAllowedInDepartmentMultipleTest()
        {
            IFilter notAllowedInDepartment = new FilterNotAllowedInDepartment();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 7);
            controlEmployees.RemoveAll(employee => employee.Id == 17);

            List<Employee> availableEmployees = notAllowedInDepartment.Filter(shifts[7], 9, shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }
    }
}
