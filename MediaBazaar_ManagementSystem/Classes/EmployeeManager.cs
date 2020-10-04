using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.classes
{
    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeeManager() { }

        public void AddEmployee(bool active, string firstName, string surName, string userName, string password, string email, int phoneNumber, string address, DateTime dateOfBirth, int bsn, string spouseName, int spousePhone)
        {
            employees.Add(new Employee(0, active, firstName, surName, userName, password, email, phoneNumber, address, dateOfBirth, bsn, spouseName, spousePhone));
        }

        public void RemoveEmployee(int id)
        {
            //Remove employee from list
        }

        public void EditEmployee(int id)
        {
            //Show employee details based off id
        }

        public Employee GetEmployee(int id)
        {
            return new Employee(0 ,true, "Placeholder", "Placeholder", "Placeholder", "Placeholder", "Placeholder", 1, "Placeholder", new DateTime(2011, 6, 10), 1, "Placeholder", 1);
        }

        public void Schedule(int id, int shiftId)
        {
            //Schedule employee with id to shift with shiftId
        }

        public void Unschedule(int id, int shiftId)
        {
            //Unschedule employee with id from shift with shiftId
        }

        public void GetEmployeeSchedule(int employeeId)
        {
            //Display employee schedule
        }

        public void GetShiftSchedule(int shiftId)
        {
            //Display shift schedule
        }

        public void AddDepartment(int id, string name)
        {
            //Add department with id and name
        }

        public void RemoveDepartment(int id)
        {
            //Remove department with id
        }

        public float[] ViewStatistics(int[] id)
        {
            //Show statistics of the integers
            return new float[0];
        }
    }
}
