using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IDepartmentStorage
    {
        void Create(string name);

        void Remove(int id);

        List<Department> GetAll();

        int GetCapacityForDepartmentInShift(int departmentId, int shiftId);
    }
}
