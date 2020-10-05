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
using System.Windows.Forms.DataVisualization.Charting;

namespace MediaBazaar_ManagementSystem
{
    public partial class MainWindow : Form
    {
        private EmployeeManager employeeManager;
        DatabaseHandler dbhandler;
        EmployeeDetailsWindow edw;

        public MainWindow()
        {
            InitializeComponent();
            employeeManager = new EmployeeManager();
            dbhandler = new Classes.DatabaseHandler();
            PopulateEmployeesTable();
            HideInactiveEmployees(true);

            // Removes statistics tab until implementation is finished in the future.
            tabControl1.TabPages.Remove(tabPage3);
        }

        private void PopulateEmployeesTable()
        {
            dataGridViewEmployees.Rows.Clear();

            try
            {
                foreach (Employee e in dbhandler.GetEmployeesFromDB())
                {
                    int rowId = dataGridViewEmployees.Rows.Add();

                    DataGridViewRow row = dataGridViewEmployees.Rows[rowId];

                    row.Cells["id"].Value = e.Id;
                    row.Cells["active"].Value = e.Active;
                    row.Cells["firstName"].Value = e.FirstName;
                    row.Cells["surName"].Value = e.SurName;
                    row.Cells["username"].Value = e.UserName;
                    row.Cells["phoneNumber"].Value = e.PhoneNumber;
                    row.Cells["emailAddress"].Value = e.Email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting employee info.\n" + ex.ToString());
            }
        }

        private void DataButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            Series TestDataPoints = StatisticChart.Series["TestData"];

            TestDataPoints.Points.Clear();

            for (int i = 1; i <= 10; i++) {
                int data = rand.Next(1, 101);
                TestDataPoints.Points.Add(data, i);
            }
        }

        private void buttonEmployeesAdd_Click(object sender, EventArgs e)
        {
            edw = new EmployeeDetailsWindow();
            if(edw.ShowDialog() == DialogResult.OK)
            {
                dbhandler.CreateEmployee(edw.Employee);
                PopulateEmployeesTable();
            }
        }

        private void buttonEmployeeModify_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewEmployees.SelectedCells[0].Value);
            //int id = Convert.ToInt32(dataGridViewEmployees.SelectedRows);
            Employee toEdit = dbhandler.GetEmployee(id);
            edw = new EmployeeDetailsWindow();
            edw.AddEmployeeData(toEdit);
            if (edw.ShowDialog() == DialogResult.OK)
            {
                dbhandler.UpdateEmployee(edw.Employee);
                PopulateEmployeesTable();
            }
        }

        private void checkBoxShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowInactive.Checked)
            {
                HideInactiveEmployees(false);
            }
            else
            {
                HideInactiveEmployees(true);
            }
        }

        private void HideInactiveEmployees(bool visible)
        {
            if (visible)
            {
                foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
                {
                    if (!(bool)row.Cells["active"].Value)
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
                {
                    if (!(bool)row.Cells["active"].Value)
                    {
                        row.Visible = true;
                    }
                }
            }
        }
    }
}
