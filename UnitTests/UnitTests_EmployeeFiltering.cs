﻿using MediaBazaar_ManagementSystem;
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
            workingEmployees.Add(new WorkingEmployee(1, 1, 3));
            workingEmployees.Add(new WorkingEmployee(1, 15, 3));
            workingEmployees.Add(new WorkingEmployee(2, 1, 3));
            workingEmployees.Add(new WorkingEmployee(3, 2, 3));

            workingEmployees.Add(new WorkingEmployee(4, 27, 3));
            workingEmployees.Add(new WorkingEmployee(5, 27, 3));
            workingEmployees.Add(new WorkingEmployee(6, 27, 3));
            workingEmployees.Add(new WorkingEmployee(7, 27, 3));
            workingEmployees.Add(new WorkingEmployee(8, 27, 3));
            workingEmployees.Add(new WorkingEmployee(9, 27, 3));
            workingEmployees.Add(new WorkingEmployee(10, 27, 3));
            workingEmployees.Add(new WorkingEmployee(11, 27, 3));
            workingEmployees.Add(new WorkingEmployee(12, 27, 3));
            workingEmployees.Add(new WorkingEmployee(13, 27, 3));
            workingEmployees.Add(new WorkingEmployee(14, 27, 3));
            workingEmployees.Add(new WorkingEmployee(15, 27, 3));
            workingEmployees.Add(new WorkingEmployee(16, 27, 3));
            workingEmployees.Add(new WorkingEmployee(17, 27, 3));
            workingEmployees.Add(new WorkingEmployee(18, 27, 3));

            // Employee 9 & 11 is scheduled twice already for Sunday
            workingEmployees.Add(new WorkingEmployee(19, 9, 3));
            workingEmployees.Add(new WorkingEmployee(20, 27, 3));
            workingEmployees.Add(new WorkingEmployee(21, 9, 3));
            workingEmployees.Add(new WorkingEmployee(19, 11, 3));
            workingEmployees.Add(new WorkingEmployee(21, 11, 3));

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
            employees.Add(new Employee(1, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 40));

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

            // Not enough contract hours anymore
            employees.Add(new Employee(21, true, "Test", "Employee", "employee.t", "pw", "em", "p", "a", DateTime.Today, 123456789, "sn", "sp", 3, "pc", "c", "111111111111111111111", "9,5,7,2,6,3,1,8,4", 8));

            return employees;
        }

        [TestMethod]
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

            List<Employee> availableEmployees = preferredHours.Filter(shifts[2], shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod]
        public void PreferredHoursFilterForSaturdayMorningTest()
        {
            IFilter preferredHours = new FilterPreferredHours();
            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 4);
            controlEmployees.RemoveAll(employee => employee.Id == 6);

            List<Employee> availableEmployees = preferredHours.Filter(shifts[15], shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod]
        public void ScheduledTwiceOnMondayEveningTest()
        {
            IFilter scheduledTwiceAlready = new FilterScheduledTwiceAlready();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 1);

            List<Employee> availableEmployees = scheduledTwiceAlready.Filter(shifts[2], shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod]
        public void ScheduledTwiceOnSundayAfternoonTest()
        {
            IFilter scheduledTwiceAlready = new FilterScheduledTwiceAlready();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 9);
            controlEmployees.RemoveAll(employee => employee.Id == 11);

            List<Employee> availableEmployees = scheduledTwiceAlready.Filter(shifts[19], shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }

        [TestMethod]
        public void AlreadyScheduledOnMondayMorningTest()
        {
            IFilter scheduledAlready = new FilterAlreadyScheduled();

            List<Employee> employees = GenerateEmployeeList();
            List<Shift> shifts = GenerateShiftList();
            List<WorkingEmployee> workingEmployees = GenerateWorkingEmployeeList();

            List<Employee> controlEmployees = new List<Employee>(employees);

            controlEmployees.RemoveAll(employee => employee.Id == 1);
            controlEmployees.RemoveAll(employee => employee.Id == 15);

            List<Employee> availableEmployees = scheduledAlready.Filter(shifts[0], shifts, workingEmployees, employees);

            CollectionAssert.AreEquivalent(controlEmployees, availableEmployees);
        }
    }
}
