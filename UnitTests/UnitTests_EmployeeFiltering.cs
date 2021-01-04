using MediaBazaar_ManagementSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTests_EmployeeFiltering
    {
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

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
