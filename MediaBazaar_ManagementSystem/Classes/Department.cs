using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar_ManagementSystem
{
    /// <summary>
    /// Class for department objects
    /// </summary>
    public class Department
    {
        private int id;
        private string name;
        private List<Employee> employees = new List<Employee>();
        private List<Item> items = new List<Item>();

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
