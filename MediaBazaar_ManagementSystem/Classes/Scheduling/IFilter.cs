using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IFilter
    {
        List<Employee> Filter(int shiftId, int departmentId, List<Employee> employees);
    }
}