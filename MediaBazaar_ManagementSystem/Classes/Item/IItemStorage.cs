using MediaBazaar_ManagementSystem.Classes.Item;
using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    interface IItemStorage
    {
        bool Create(Item item);

        bool Update(Item item);

        Item Get(int id);

        List<Item> GetAll(bool activeOnly);

        int ReadRequest(int id);

        List<Stock> ReadStock();

        void SendStockRequest(int userid, int productId, int quantity);

        void AddToStock(int productId, int quantity);
    }
}
