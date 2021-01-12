using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IDepartmentStorage
    {
        void Create(string name);

        void Remove(int id);

        List<Department> GetAll();

        List<(int shiftId, int departmentId, int capacity)> GetCapacityForAllDepartments();

        List<(int shiftId, int departmentId, int capacity)> GetCapacityForDepartmentsInCertainShifts(List<int> shiftIds);

        void UpdateCapacityForDepartmentList(List<(int shiftId, int departmentId, int capacity)> toUpdate);
    }
}
