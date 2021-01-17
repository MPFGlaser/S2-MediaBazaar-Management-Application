using System;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IRequestStorage
    {
        List<Request> GetAll();

        bool TurnDown(int selectedIndex);
        bool Permit(int selectedIndex);
    }
}
