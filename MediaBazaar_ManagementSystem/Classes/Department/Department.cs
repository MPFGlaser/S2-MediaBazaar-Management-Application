using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    /// <summary>
    /// Class for department objects
    /// </summary>
    public class Department
    {
        private int id, occupation, capacity;
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

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Occupation
        {
            get { return occupation; }
            set { occupation = value; }
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
