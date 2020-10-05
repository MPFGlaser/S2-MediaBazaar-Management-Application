using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.Classes
{
    public class Item
    {
        private int id, code, quantity;
        private string name, brand, category, description;
        private bool active;
        private double price;

        public Item(int id, string name, string brand, int code, string category, int quantity, double price, bool active, string description)
        {
            this.id = id;
            this.name = name;
            this.brand = brand;
            this.code = code;
            this.category = category;
            this.quantity = quantity;
            this.price = price;
            this.active = active;
            this.description = description;
        }

        public int Id
        {
            get { return id; }
        }

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
