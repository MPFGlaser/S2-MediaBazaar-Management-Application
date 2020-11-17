using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
