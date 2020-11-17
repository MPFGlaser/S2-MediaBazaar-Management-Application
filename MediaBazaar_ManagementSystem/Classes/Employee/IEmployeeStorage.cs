using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem
{
    public interface IEmployeeStorage
    {
        bool Create(Employee employee);

        bool Update(Employee employee);

        Employee Get(int id);

        List<Employee> GetAll(bool activeOnly);
    }
}
