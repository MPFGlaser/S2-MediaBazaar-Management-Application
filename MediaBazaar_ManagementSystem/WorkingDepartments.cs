using MediaBazaar_ManagementSystem.classes;
using MediaBazaar_ManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class WorkingDepartments : Form
    {
        private string workingDepartments = null;
        public WorkingDepartments()
        {
            InitializeComponent();
        }

        public WorkingDepartments(string input, List<Department> allDepartments)
        {
            InitializeComponent();
            InitializeComboBox(allDepartments);
        }
        #region Logic
        private void InitializeComboBox(List<Department> allDepartments)
        {
            foreach (Department d in allDepartments)
            {
                comboBoxSelectDepartments.DisplayMember = "Text";
                comboBoxSelectDepartments.ValueMember = "Department";
                comboBoxSelectDepartments.Items.Add(new { Text = d.Name, Department = d });
            }
        }

        private void AddDepartmentToWorkable()
        {

        }

        private void RemoveDepartmentFromWorkable()
        {

        }

        #endregion

        #region Button handlers
        private void buttonAddDepartmentToEmployee_Click(object sender, EventArgs e)
        {
            AddDepartmentToWorkable();
        }

        private void buttonRemoveDepartmentFromEmployee_Click(object sender, EventArgs e)
        {
            RemoveDepartmentFromWorkable();
        }
        #endregion
    }
}
