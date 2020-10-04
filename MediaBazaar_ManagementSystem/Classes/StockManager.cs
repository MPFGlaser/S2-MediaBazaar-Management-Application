using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem.Classes
{
    public class StockManager
    {
        List<Item> items = new List<Item>();

        StockManager() { }

        public void AddItem(int id, string name, string manufacturer, float price)
        {
            items.Add(new Item(id, name, manufacturer, price));
        }

        public void RemoveItem(int id)
        {
            //Remove item based on id
        }

        public void EditItem(int id)
        {
            //Display all item information
        }

        public Item GetItem(int id)
        {
            //Return item with the given id
            return new Item(1, "Placeholder", "Placeholder", 0);
        }

        public float[] ViewStatistics(int[] id)
        {
            //Show statistics of the integers
            return new float[0];
        }

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
