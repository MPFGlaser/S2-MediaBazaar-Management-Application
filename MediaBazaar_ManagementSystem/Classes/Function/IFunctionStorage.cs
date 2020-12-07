using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IFunctionStorage
    {
        bool Create(string name);

        bool Update();

        Dictionary<int, string> GetFunctions();

        List<string> GetPermissions(int function);
    }
}
