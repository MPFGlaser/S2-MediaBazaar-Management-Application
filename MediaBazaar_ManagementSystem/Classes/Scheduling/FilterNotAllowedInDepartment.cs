using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem
{
    public class FilterNotAllowedInDepartment : IFilter
    {
        public List<Employee> Filter(Shift shift, int departmentId, List<Shift> weekShifts, List<WorkingEmployee> workingEmployees, List<Employee> employees)
        {
            List<Employee> output = new List<Employee>();

            foreach(Employee employee in employees)
            {
                string[] workingDepartments = employee.WorkingDepartments.Split(',');

                if (workingDepartments.Contains(departmentId.ToString()))
                {
                    output.Add(employee);
                }
            }

            return output;
        }
    }
}
