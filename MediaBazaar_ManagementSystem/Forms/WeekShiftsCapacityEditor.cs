using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem.Forms
{
    public partial class WeekShiftsCapacityEditor : Form
    {
        IShiftStorage shiftStorage;
        IDepartmentStorage departmentStorage;
        List<DateTime> weekdays;
        List<Shift> weekShifts;
        int currentDepartmentId;
        private Dictionary<int, Dictionary<int, int>> allDepartmentCapacityInWeek = new Dictionary<int, Dictionary<int, int>>();
        //private List<Dictionary<int, int>> allDepartmentsInWeek = new List<Dictionary<int, int>>();

        public WeekShiftsCapacityEditor(List<Shift> weekShifts, List<DateTime> weekdays, int currentDepartmentId)
        {
            
            InitializeComponent();
            this.weekShifts = weekShifts;
            this.weekdays = weekdays;
            this.currentDepartmentId = currentDepartmentId;
            LoadAllCapacities(weekShifts);
            LoadAllDepartments(currentDepartmentId);
            SetupGroupboxTitles();
            SetupNumericUpDowns();
            CreateMissingShifts();
        }

        //private Dictionary<int, Dictionary<int, int>> LoadAllCapacities(List<Shift> weekShifts)
        private void LoadAllCapacities(List<Shift> weekShifts)
        {
            shiftStorage = new ShiftMySQL();
            Dictionary<int, Dictionary<int, int>> weekDepartments = new Dictionary<int, Dictionary<int, int>>();
            //List <Dictionary<int, int>> weekDepartments = new List<Dictionary<int, int>>();
            //int count = 0;

            foreach(Shift s in weekShifts)
            {
                Dictionary<int, int> temp = shiftStorage.GetCapacityPerDepartment(s.Id);
                if(temp.Count() > 0)
                {
                    weekDepartments.Add(s.Id, temp);
                }
            }

            this.allDepartmentCapacityInWeek = weekDepartments;
        }

        private void LoadAllDepartments(int departmentId)
        {
            departmentStorage = new DepartmentMySQL();
            List<Department> allDepartments = departmentStorage.GetAll();

            foreach(Department d in allDepartments)
            {
                comboBoxSelectDepartment.DisplayMember = "Text";
                comboBoxSelectDepartment.ValueMember = "Department";
                comboBoxSelectDepartment.Items.Add(new { Text = d.Name, Department = d });
            }

            foreach(dynamic dynamicDep in comboBoxSelectDepartment.Items)
            {
                Department dep = dynamicDep.Department;
                if(dep.Id == departmentId)
                {
                    comboBoxSelectDepartment.SelectedItem = dynamicDep;
                }
            }
        }

        /// <summary>
        /// Setups the numeric up downs.
        /// </summary>
        private void SetupNumericUpDowns()
        {
            foreach (Shift s in weekShifts)
            {
                if (allDepartmentCapacityInWeek.ContainsKey(s.Id))
                {
                    foreach (KeyValuePair<int, int> dictKVP in allDepartmentCapacityInWeek[s.Id])
                    {
                        Dictionary<int, int> dict = new Dictionary<int, int>{ { dictKVP.Key, dictKVP.Value} };
                        if (s.Date == weekdays[0])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownMondayMorning.Value = dict[currentDepartmentId];
                                    }
                                break;
                                case ShiftTime.Afternoon:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownMondayAfternoon.Value = dict[currentDepartmentId];
                                    }
                                break;
                                case ShiftTime.Evening:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownMondayEvening.Value = dict[currentDepartmentId];
                                    }
                                break;
                            }
                        }

                        if (s.Date == weekdays[1])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownTuesdayMorning.Value = dict[currentDepartmentId];
                                    }
                                break;
                                case ShiftTime.Afternoon:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownTuesdayAfternoon.Value = dict[currentDepartmentId];
                                    }
                                break;
                                case ShiftTime.Evening:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownTuesdayEvening.Value = dict[currentDepartmentId];
                                    }
                                break;
                            }
                        }

                        if (s.Date == weekdays[2])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownWednesdayMorning.Value = dict[currentDepartmentId];
                                    }
                                    break;
                                case ShiftTime.Afternoon:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownWednesdayAfternoon.Value = dict[currentDepartmentId];
}
                                    break;
                                case ShiftTime.Evening:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownWednesdayEvening.Value = dict[currentDepartmentId];
}
                                    break;
                            }
                        }

                        if (s.Date == weekdays[3])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownThursdayMorning.Value = dict[currentDepartmentId];
                                    }
                                break;
                                case ShiftTime.Afternoon:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownThursdayAfternoon.Value = dict[currentDepartmentId];
                                    }
                                break;
                                case ShiftTime.Evening:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownThursdayEvening.Value = dict[currentDepartmentId];
                                    }
                                break;
                            }
                        }

                        if (s.Date == weekdays[4])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownFridayMorning.Value = dict[currentDepartmentId];
                                    }
                                    break;
                                case ShiftTime.Afternoon:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownFridayAfternoon.Value = dict[currentDepartmentId];
                                    }
                                    break;
                                case ShiftTime.Evening:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownFridayEvening.Value = dict[currentDepartmentId];
                                    }
                                    break;
                            }
                        }

                        if (s.Date == weekdays[5])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownSaturdayMorning.Value = dict[currentDepartmentId];
                                    }
                                    break;
                                case ShiftTime.Afternoon:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownSaturdayAfternoon.Value = dict[currentDepartmentId];
                                    }
                                    break;
                                case ShiftTime.Evening:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownSaturdayEvening.Value = dict[currentDepartmentId];
                                    }
                                    break;
                            }
                        }

                        if (s.Date == weekdays[6])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownSundayMorning.Value = dict[currentDepartmentId];
                                    }
                                break;
                                case ShiftTime.Afternoon:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownSundayAfternoon.Value = dict[currentDepartmentId];
                                    }
                                    break;
                                case ShiftTime.Evening:
                                    if (dict.ContainsKey(currentDepartmentId))
                                    {
                                        numericUpDownSundayEvening.Value = dict[currentDepartmentId];
                                    }
                                    break;
                            }
                        }
                    }
                    
                }
            }
        }

        /// <summary>
        /// Setups the groupbox titles.
        /// </summary>
        private void SetupGroupboxTitles()
        {
            groupBoxMonday.Text = "Monday " + weekdays[0].ToString("dd/MM/yyyy");
            groupBoxTuesday.Text = "Tuesday " + weekdays[1].ToString("dd/MM/yyyy");
            groupBoxWednesday.Text = "Wednesday " + weekdays[2].ToString("dd/MM/yyyy");
            groupBoxThursday.Text = "Thursday " + weekdays[3].ToString("dd/MM/yyyy");
            groupBoxFriday.Text = "Friday " + weekdays[4].ToString("dd/MM/yyyy");
            groupBoxSaturday.Text = "Saturday " + weekdays[5].ToString("dd/MM/yyyy");
            groupBoxSunday.Text = "Sunday " + weekdays[6].ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Creates the missing shifts.
        /// </summary>
        private void CreateMissingShifts()
        {
            shiftStorage = new ShiftMySQL();

            foreach(DateTime date in weekdays)
            {
                if(weekShifts.FirstOrDefault(x => x.Date == date && x.ShiftTime == ShiftTime.Morning) == null)
                {
                    Shift s = new Shift(0, date, ShiftTime.Morning, 0);
                    int newId = shiftStorage.Create(s);
                    Shift s2 = new Shift(newId, date, ShiftTime.Morning, 0);
                    weekShifts.Add(s2);
                }

                if (weekShifts.FirstOrDefault(x => x.Date == date && x.ShiftTime == ShiftTime.Afternoon) == null)
                {
                    Shift s = new Shift(0, date, ShiftTime.Afternoon, 0);
                    int newId = shiftStorage.Create(s);
                    Shift s2 = new Shift(newId, date, ShiftTime.Afternoon, 0);
                    weekShifts.Add(s2);
                }

                if (weekShifts.FirstOrDefault(x => x.Date == date && x.ShiftTime == ShiftTime.Evening) == null)
                {
                    Shift s = new Shift(0, date, ShiftTime.Evening, 0);
                    int newId = shiftStorage.Create(s);
                    Shift s2 = new Shift(newId, date, ShiftTime.Evening, 0);
                    weekShifts.Add(s2);
                }
            }
        }

        private List<Shift> ShiftsToUpdate()
        {
            List<Shift> output = new List<Shift>();

            foreach (Shift s in weekShifts)
            {
                if (s.Date == weekdays[0])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            if (numericUpDownMondayMorning.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownMondayMorning.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Afternoon:
                            if (numericUpDownMondayAfternoon.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownMondayAfternoon.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Evening:
                            if (numericUpDownMondayEvening.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownMondayEvening.Value);
                                output.Add(s);
                            }
                            break;
                    }
                }

                if (s.Date == weekdays[1])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            if (numericUpDownTuesdayMorning.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownTuesdayMorning.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Afternoon:
                            if (numericUpDownTuesdayAfternoon.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownTuesdayAfternoon.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Evening:
                            if (numericUpDownTuesdayEvening.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownTuesdayEvening.Value);
                                output.Add(s);
                            }
                            break;
                    }
                }

                if (s.Date == weekdays[2])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            if (numericUpDownWednesdayMorning.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownWednesdayMorning.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Afternoon:
                            if (numericUpDownWednesdayAfternoon.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownWednesdayAfternoon.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Evening:
                            if (numericUpDownWednesdayEvening.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownWednesdayEvening.Value);
                                output.Add(s);
                            }
                            break;
                    }
                }

                if (s.Date == weekdays[3])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            if (numericUpDownThursdayMorning.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownThursdayMorning.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Afternoon:
                            if (numericUpDownThursdayAfternoon.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownThursdayAfternoon.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Evening:
                            if (numericUpDownThursdayEvening.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownThursdayEvening.Value);
                                output.Add(s);
                            }
                            break;
                    }
                }

                if (s.Date == weekdays[4])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            if (numericUpDownFridayMorning.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownFridayMorning.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Afternoon:
                            if (numericUpDownFridayAfternoon.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownFridayAfternoon.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Evening:
                            if (numericUpDownFridayEvening.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownFridayEvening.Value);
                                output.Add(s);
                            }
                            break;
                    }
                }

                if (s.Date == weekdays[5])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            if (numericUpDownSaturdayMorning.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownSaturdayMorning.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Afternoon:
                            if (numericUpDownSaturdayAfternoon.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownSaturdayAfternoon.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Evening:
                            if (numericUpDownSaturdayEvening.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownSaturdayEvening.Value);
                                output.Add(s);
                            }
                            break;
                    }
                }

                if (s.Date == weekdays[6])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            if (numericUpDownSundayMorning.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownSundayMorning.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Afternoon:
                            if (numericUpDownSundayAfternoon.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownSundayAfternoon.Value);
                                output.Add(s);
                            }
                            break;
                        case ShiftTime.Evening:
                            if (numericUpDownSundayEvening.Value != s.Capacity)
                            {
                                s.Capacity = Convert.ToInt32(numericUpDownSundayEvening.Value);
                                output.Add(s);
                            }
                            break;
                    }
                }
            }

            return output;
        }

        #region control handlers
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            shiftStorage = new ShiftMySQL();
            List<Shift> updateMe = ShiftsToUpdate();

            foreach (Shift s in updateMe)
            {
                bool shiftUpdateSucceeded = false;
                while (shiftUpdateSucceeded == false)
                {
                    shiftUpdateSucceeded = shiftStorage.Update(s);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Numeric UpDown Value Displays

        private void SetAllUpdownsToZero()
        {
            foreach (Shift s in weekShifts)
            {
                if (s.Date == weekdays[0])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownMondayMorning.Value = 0;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownMondayAfternoon.Value = 0;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownMondayEvening.Value = 0;
                            break;
                    }
                }

                if (s.Date == weekdays[1])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownTuesdayMorning.Value = 0;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownTuesdayAfternoon.Value = 0;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownTuesdayEvening.Value = 0;
                            break;
                    }
                }

                if (s.Date == weekdays[2])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownWednesdayMorning.Value = 0;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownWednesdayAfternoon.Value = 0;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownWednesdayEvening.Value = 0;
                            break;
                    }
                }

                if (s.Date == weekdays[3])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownThursdayMorning.Value = 0;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownThursdayAfternoon.Value = 0;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownThursdayEvening.Value = 0;
                            break;
                    }
                }

                if (s.Date == weekdays[4])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownFridayMorning.Value = 0;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownFridayAfternoon.Value = 0;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownFridayEvening.Value = 0;
                            break;
                    }
                }

                if (s.Date == weekdays[5])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownSaturdayMorning.Value = 0;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownSaturdayAfternoon.Value = 0;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownSaturdayEvening.Value = 0;
                            break;
                    }
                }

                if (s.Date == weekdays[6])
                {
                    switch (s.ShiftTime)
                    {
                        case ShiftTime.Morning:
                            numericUpDownSundayMorning.Value = 0;
                            break;
                        case ShiftTime.Afternoon:
                            numericUpDownSundayAfternoon.Value = 0;
                            break;
                        case ShiftTime.Evening:
                            numericUpDownSundayEvening.Value = 0;
                            break;
                    }
                }
            }
        }

        #endregion

        private void comboBoxSelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic depDynamic = comboBoxSelectDepartment.SelectedItem;
            Department selectedDepartment = depDynamic.Department;
            this.currentDepartmentId = selectedDepartment.Id;
            SetAllUpdownsToZero();
            SetupNumericUpDowns();
        }
    }
}
