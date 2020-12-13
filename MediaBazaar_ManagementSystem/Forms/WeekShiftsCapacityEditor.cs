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
        List<int> initialShiftIds = new List<int>();
        int currentDepartmentId;
        bool changesMade = false, autoChanged = false;
        //<shiftId <departmentId, capacity>>
        private Dictionary<int, Dictionary<int, int>> allDepartmentCapacityInWeek = new Dictionary<int, Dictionary<int, int>>(), valuesToSave = new Dictionary<int, Dictionary<int, int>>();

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

        private void LoadAllCapacities(List<Shift> weekShifts)
        {
            shiftStorage = new ShiftMySQL();
            Dictionary<int, Dictionary<int, int>> weekDepartments = new Dictionary<int, Dictionary<int, int>>();

            foreach(Shift s in weekShifts)
            {
                Dictionary<int, int> temp = shiftStorage.GetCapacityPerDepartment(s.Id);
                if(temp.Count() > 0)
                {
                    weekDepartments.Add(s.Id, temp);
                    this.initialShiftIds.Add(s.Id);
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

        private Dictionary<int, Dictionary<int, int>> UpdateCapacities()
        {
            Dictionary<int, Dictionary<int, int>> output = new Dictionary<int, Dictionary<int, int>>();
            Dictionary<int, int> departmentCapacity;

            foreach (Shift s in weekShifts)
            {
                foreach (dynamic depDynamic in comboBoxSelectDepartment.Items)
                {
                    Department dep = depDynamic.Department;
                    if(dep.Id == currentDepartmentId)
                    {
                        departmentCapacity = new Dictionary<int, int>();
                        if (s.Date == weekdays[0])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownMondayMorning.Value));
                                    break;
                                case ShiftTime.Afternoon:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownMondayAfternoon.Value));
                                    break;
                                case ShiftTime.Evening:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownMondayEvening.Value));
                                    break;
                            }
                        }

                        if (s.Date == weekdays[1])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownTuesdayMorning.Value));
                                    break;
                                case ShiftTime.Afternoon:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownTuesdayAfternoon.Value));
                                    break;
                                case ShiftTime.Evening:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownTuesdayEvening.Value));
                                    break;
                            }
                        }

                        if (s.Date == weekdays[2])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownWednesdayMorning.Value));
                                    break;
                                case ShiftTime.Afternoon:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownWednesdayAfternoon.Value));
                                    break;
                                case ShiftTime.Evening:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownWednesdayEvening.Value));
                                    break;
                            }
                        }

                        if (s.Date == weekdays[3])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownThursdayMorning.Value));
                                    break;
                                case ShiftTime.Afternoon:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownThursdayAfternoon.Value));
                                    break;
                                case ShiftTime.Evening:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownThursdayEvening.Value));
                                    break;
                            }
                        }

                        if (s.Date == weekdays[4])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownFridayMorning.Value));
                                    break;
                                case ShiftTime.Afternoon:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownFridayAfternoon.Value));
                                    break;
                                case ShiftTime.Evening:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownFridayEvening.Value));
                                    break;
                            }
                        }

                        if (s.Date == weekdays[5])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownSaturdayMorning.Value));
                                    break;
                                case ShiftTime.Afternoon:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownSaturdayAfternoon.Value));
                                    break;
                                case ShiftTime.Evening:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownSaturdayEvening.Value));
                                    break;
                            }
                        }

                        if (s.Date == weekdays[6])
                        {
                            switch (s.ShiftTime)
                            {
                                case ShiftTime.Morning:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownSundayMorning.Value));
                                    break;
                                case ShiftTime.Afternoon:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownSundayAfternoon.Value));
                                    break;
                                case ShiftTime.Evening:
                                    departmentCapacity.Add(currentDepartmentId, Convert.ToInt32(numericUpDownSundayEvening.Value));
                                    break;
                            }
                        }
                        output.Add(s.Id, departmentCapacity);
                    }
                }
                
            }

            return output;
        }

        private void SaveNewShiftValues()
        {
            foreach (Shift s in weekShifts)
            {
                foreach (dynamic depDynamic in comboBoxSelectDepartment.Items)
                {
                    Department dep = depDynamic.Department;
                    if (dep.Id == currentDepartmentId)
                    {
                        if (valuesToSave.ContainsKey(s.Id))
                        {
                            allDepartmentCapacityInWeek[s.Id][currentDepartmentId] = valuesToSave[s.Id][currentDepartmentId];
                        }
                    }
                }
            }
        }

        #region control handlers
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            shiftStorage = new ShiftMySQL();
            valuesToSave = UpdateCapacities();

            foreach (Shift s in weekShifts)
            {
                Dictionary<int, int> temp = valuesToSave[s.Id];
                int capacity = temp[currentDepartmentId];
                bool shiftUpdateSucceeded = false;
                while (shiftUpdateSucceeded == false)
                {
                    shiftUpdateSucceeded = shiftStorage.UpdateCapacityPerDepartment(s.Id, currentDepartmentId, capacity);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxSelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changesMade)
            {
                valuesToSave = UpdateCapacities();
                SaveNewShiftValues();
                changesMade = false;
            }
            dynamic depDynamic = comboBoxSelectDepartment.SelectedItem;
            Department selectedDepartment = depDynamic.Department;
            currentDepartmentId = selectedDepartment.Id;
            autoChanged = true;
            SetAllUpdownsToZero();
            SetupNumericUpDowns();
            autoChanged = false;
        }
        #endregion

        #region Numeric UpDown Value Handlers
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
                        Dictionary<int, int> dict = new Dictionary<int, int> { { dictKVP.Key, dictKVP.Value } };
                        if (dict.ContainsKey(currentDepartmentId))
                        {
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
        }

        

        /// <summary>
        /// Set all numeric updowns to 0.
        /// </summary>
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

        #region Numeric UpDown Value Change Handlers
        private void numericUpDownMondayMorning_ValueChanged(object sender, EventArgs e)
        {
            if(!autoChanged)
                changesMade = true;
        }

        private void numericUpDownMondayAfternoon_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownMondayEvening_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownTuesdayMorning_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownTuesdayAfternoon_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownTuesdayEvening_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownWednesdayMorning_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownWednesdayAfternoon_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownWednesdayEvening_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownThursdayMorning_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownThursdayAfternoon_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownThursdayEvening_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownFridayMorning_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownFridayAfternoon_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownFridayEvening_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownSaturdayMorning_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownSaturdayAfternoon_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownSaturdayEvening_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownSundayMorning_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownSundayAfternoon_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }

        private void numericUpDownSundayEvening_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
                changesMade = true;
        }
        #endregion
    }
}
