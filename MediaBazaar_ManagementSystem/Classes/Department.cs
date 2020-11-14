using MediaBazaar_ManagementSystem.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem.Classes
{
    /// <summary>
    /// Class for department objects
    /// </summary>
    public class Department
    {
        private int id;
        private string name;
        private List<Employee> employees;
        private List<Item> items;

        public Department(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
