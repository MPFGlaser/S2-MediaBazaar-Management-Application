using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.Classes
{
    class Item
    {
        private int id, quatity;
        private string name, manufacturer, description;
        private float price;

        public Item(int id, string name, string manufacturer, float price)
        {
            this.id = id;
            this.name = name;
            this.manufacturer = manufacturer;
            this.price = price;
        }

        public int Id
        {
            get { return id; }
        }

        public int Quatity
        {
            get { return quatity; }
            set { quatity = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
