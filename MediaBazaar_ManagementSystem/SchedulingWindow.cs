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
    public partial class SchedulingWindow : Form
    {
        DatabaseHandler dbhandler;
        private Shift currentShift = new Shift(1, DateTime.Now, 1);

        public SchedulingWindow(string dateAndMonth, string weekDay, int shifTime)
        {
            InitializeComponent();
            InitializeComboBoxShiftTime();
            LoadEmployees();
            textBoxWeekDay.Text = weekDay;
            textBoxCalendarDate.Text = dateAndMonth;
            comboBoxShiftTime.SelectedIndex = shifTime - 1;
        }

        private void LoadEmployees()
        {
            dbhandler = new DatabaseHandler();
            List<Employee> allActiveEmployees = dbhandler.GetActiveEmployeesFromDB();
            foreach(Employee e in allActiveEmployees)
            {
                comboBoxSelectEmployees.DisplayMember = "Text";
                comboBoxSelectEmployees.ValueMember = "Employee";
                comboBoxSelectEmployees.Items.Add(new { Text = e.FirstName + " " + e.SurName, Employee = e });
            }
        }

        private void InitializeComboBoxShiftTime()
        {
            this.comboBoxShiftTime.SelectedIndexChanged += new System.EventHandler(comboBoxShiftTime_SelectedIndexChanged);
        }

        private void comboBoxShiftTime_SelectedIndexChanged(Object sender, EventArgs e)
        {
            //Load different shift
        }

        private void buttonAddEmployeeToShift_Click(object sender, EventArgs e)
        {
            if(comboBoxSelectEmployees.SelectedIndex != -1)
            {
                Employee selected = (comboBoxSelectEmployees.SelectedItem as dynamic).Employee;
                listBoxCurrentEmployees.DisplayMember = "Text";
                listBoxCurrentEmployees.ValueMember = "Employee";
                listBoxCurrentEmployees.Items.Add(new { Text = selected.FirstName + " " + selected.SurName, Employee = selected });

                foreach(Item i in comboBoxSelectEmployees.Items)
                {
                    if((i as dynamic).Employee == (comboBoxSelectEmployees.SelectedItem as dynamic).Employee)
                    {
                        comboBoxSelectEmployees.Items.Remove(comboBoxSelectEmployees.SelectedItem);
                    }
                }
                comboBoxSelectEmployees.SelectedIndex = -1;
            }
        }

        private void buttonRemoveEmployeeFromShift_Click(object sender, EventArgs e)
        {
            Employee selected = (listBoxCurrentEmployees.SelectedItem as dynamic).Employee;
            comboBoxSelectEmployees.DisplayMember = "Text";
            comboBoxSelectEmployees.ValueMember = "Employee";
            comboBoxSelectEmployees.Items.Add(new { Text = selected.FirstName + " " + selected.SurName, Employee = selected });

            listBoxCurrentEmployees.Items.Remove(selected);
        }
    }
}
