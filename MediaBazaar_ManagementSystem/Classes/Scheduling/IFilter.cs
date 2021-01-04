using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IFilter
    {
        List<Employee> Filter(List<WorkingEmployee> workingEmployees, List<Employee> employees);
    }
}