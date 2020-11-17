using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    interface IItemStorage
    {
        bool Create(Item item);

        bool Update(Item item);

        Item Get(int id);

        List<Item> GetAll(bool activeOnly);
    }
}
