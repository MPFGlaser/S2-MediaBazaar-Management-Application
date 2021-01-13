using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem.Forms
{
    public partial class ClockInOutWindow : Form
    {

        private int userid;
        IEmployeeStorage employeeStorage;
        IShiftStorage shiftStorage;
        IDepartmentStorage departmentStorage;

        public ClockInOutWindow(int id)
        {
            InitializeComponent();
            lblDepartment.Visible = false;
            cmbxDepartment.Visible = false;
            dtpClockIn.Value = DateTime.Now;
            dtpClockOut.Value = DateTime.Now;
            userid = id;
            employeeStorage = new EmployeeMySQL();
            shiftStorage = new ShiftMySQL();
            departmentStorage = new DepartmentMySQL();
            ComboboxItem ci = null;
            foreach (Employee e in employeeStorage.GetAll(true))
            {
                ci = new ComboboxItem();
                ci.Text = e.Id.ToString() + " - " + e.FirstName + " " + e.SurName;
                ci.Value = e.Id;
                cmbxEmployee.Items.Add(ci);
                if (e.Id == id) cmbxEmployee.SelectedItem = ci;
            }
        }

        private void cmbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            userid = Convert.ToInt32((cmbxEmployee.SelectedItem as ComboboxItem).Value.ToString());
            refresh_shift();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            dtpClockIn.Value = dtpDate.Value;
            dtpClockOut.Value = dtpDate.Value;
            refresh_shift();
        }

        private void refresh_shift()
        {
            cmbShift.SelectedIndex = -1;
            cmbShift.Items.Clear();
            string date = dtpDate.Value.Date.ToString("yyyy-MM-dd");
            foreach (Shift s in shiftStorage.GetShiftsByEmployee(userid, date))
            {
                ComboboxItem ci = new ComboboxItem();
                ci.Text = s.Id.ToString() + " - " + s.ShiftTime.ToString();
                ci.Value = s.Id;
                cmbShift.Items.Add(ci);
            }
            chbxForceShift.Checked = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            if (cmbShift.SelectedIndex == -1) return;
            if (chbxForceShift.Checked)
            {
                DateTime date = dtpDate.Value.Date;
                int shifttype = (cmbShift.SelectedItem as ComboboxItem).Value;
                ShiftTime shifttime = new ShiftTime();
                switch (shifttype)
                {
                    case 0:
                        shifttime = ShiftTime.Morning;
                        break;
                    case 1:
                        shifttime = ShiftTime.Afternoon;
                        break;
                    case 2:
                        shifttime = ShiftTime.Evening;
                        break;
                }

                Shift shift = shiftStorage.Get(date, shifttime);

                if (shift == null)
                {
                    // shift does not exist
                    shift = new Shift(0, date, shifttime, 1);
                    shiftStorage.Create(shift);
                    shift = shiftStorage.Get(date, shifttime);
                }
                // check if a department is selected
                if (cmbxDepartment.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a department!");
                    return;
                }
                int depid = (cmbxDepartment.SelectedItem as ComboboxItem).Value;
                shiftStorage.Assign(shift.Id, userid, depid);
                string dateclockin = dtpClockIn.Value.ToString("yyyy-MM-dd hh:mm:ss");
                shiftStorage.CreateAttendance(userid, shift.Id, dateclockin);
                MessageBox.Show("Succesfully clocked in! Tip: in order to have minutes worked you have to clock out");
            }
            else
            {
                // modify an existing shift
                int shiftid = (cmbShift.SelectedItem as ComboboxItem).Value;
                string dateclockin = dtpClockIn.Value.ToString("yyyy-MM-dd hh:mm:ss");
                int attendenceid = shiftStorage.CheckAttendance(userid, shiftid);

                if (attendenceid != 0) shiftStorage.ModifyClockInAttendance(attendenceid, dateclockin);
                else shiftStorage.CreateAttendance(userid, shiftid, dateclockin);
                MessageBox.Show("Succesfully clocked in! Tip: in order to have minutes worked you have to clock out");
            }

            cmbxDepartment.Items.Clear();
            lblDepartment.Visible = false;
            cmbxDepartment.Visible = false;
            chbxForceShift.Checked = false;
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            if (cmbShift.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a shift!");
                return;
            }
            int shiftid = (cmbShift.SelectedItem as ComboboxItem).Value;
            if (chbxForceShift.Checked)
            {
                MessageBox.Show("Cannot force a shift on clock out!");
                return;
            }
            string dateclockout = dtpClockOut.Value.ToString("yyyy-MM-dd hh:mm:ss");
            int attendenceid = shiftStorage.CheckAttendance(userid, shiftid);
            if (attendenceid != 0)
            {
                string clockintime = shiftStorage.GetClockInAttendance(attendenceid);
                DateTime clockin = DateTime.Parse(clockintime);
                DateTime clockout = DateTime.Parse(dateclockout);
                TimeSpan ts = clockout - clockin;
                int minutes = Convert.ToInt32(ts.TotalMinutes);

                if (minutes < 0)
                {
                    MessageBox.Show("Can not clockout before clock in! Please check date and time!!");
                    return;
                }
                shiftStorage.ModifyClockOutAttendance(attendenceid, dateclockout, minutes);
                MessageBox.Show("Succesfully clocked out!");
            }
            else MessageBox.Show("Must clock in, in order to clock out!");
        }

        private void chbxForceShift_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxForceShift.Checked)
            {
                cmbxDepartment.Items.Clear();
                lblDepartment.Visible = true;
                cmbxDepartment.Visible = true;

                Employee employee = employeeStorage.Get(userid);
                List<int> selectedDepartments = new List<int>();
                if (employee.WorkingDepartments != String.Empty)
                    selectedDepartments = employee.WorkingDepartments.Split(',').Select(int.Parse).ToList();

                List<Department> departments = new List<Department>();
                departments = departmentStorage.GetAll();
                foreach (Department d in departments)
                {
                    if (selectedDepartments.Contains(d.Id))
                    {
                        ComboboxItem ci = new ComboboxItem();
                        ci.Text = d.Id.ToString() + " - " + d.Name;
                        ci.Value = d.Id;
                        cmbxDepartment.Items.Add(ci);
                    }
                }

                string date = dtpDate.Value.Date.ToString("yyyy-MM-dd");
                List<Shift> shifts = shiftStorage.GetShiftsByEmployee(userid, date);
                List<int> shifttypes = new List<int>();
                foreach (Shift s in shifts)
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            shifttypes.Add(0);
                            break;
                        case ShiftTime.Afternoon:
                            shifttypes.Add(1);
                            break;
                        case ShiftTime.Evening:
                            shifttypes.Add(2);
                            break;
                    }
                }
                cmbShift.SelectedIndex = -1;
                cmbShift.Items.Clear();
                for (int i = 0; i <= 2; i++)
                {
                    if (!shifttypes.Contains(i))
                    {
                        ComboboxItem ci = new ComboboxItem();
                        switch (i)
                        {
                            case 0:
                                ci.Text = "Morning";
                                break;
                            case 1:
                                ci.Text = "Afternoon";
                                break;
                            case 2:
                                ci.Text = "Evening";
                                break;
                        }
                        ci.Value = i;
                        cmbShift.Items.Add(ci);
                    }
                }
            }
            else
            {
                refresh_shift();
                lblDepartment.Visible = false;
                cmbxDepartment.Visible = false;
            }
        }

        private void cmbShift_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbShift.SelectedIndex == -1) return;
            int shiftid = (cmbShift.SelectedItem as ComboboxItem).Value;
            if (shiftid >= 0)
            {
                string dateclockin = "";
                string dateclockout = "";
                int attendenceid = shiftStorage.CheckAttendance(userid, shiftid);
                if (attendenceid == 0) dateclockin = dtpDate.Value.ToString("yyyy-MM-dd hh:mm:ss");
                else
                {
                    dateclockin = shiftStorage.GetClockInAttendance(attendenceid);
                    dateclockout = shiftStorage.GetClockOutAttendance(attendenceid);
                }
                dtpClockIn.Value = DateTime.Parse(dateclockin);
                if (!String.IsNullOrEmpty(dateclockout)) dtpClockOut.Value = DateTime.Parse(dateclockout);
            }
        }
    }
}
