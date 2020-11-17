using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem
{
    public interface IEmployeeStorage
    {
        bool CreateEmployee(Employee employee);

        bool UpdateEmployee(Employee employee);

        Employee GetEmployee(int id);

        List<Employee> GetEmployees(bool activeOnly);
    }
}
