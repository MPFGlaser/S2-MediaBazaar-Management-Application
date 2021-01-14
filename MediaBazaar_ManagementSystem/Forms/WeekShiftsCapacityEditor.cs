using System;
using System.Collections.Generic;
using System.Linq;
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
        List<Department> allDepartments = new List<Department>();
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

            Text = $"Changing capacity of shifts in the week of Monday { weekdays[1].ToString("d") }";
        }

        /// <summary>
        /// Loads all of the capacities per department from the database.
        /// </summary>
        /// <param name="weekShifts">A list of all of the shifts in this week</param>
        private void LoadAllCapacities(List<Shift> weekShifts)
        {
            shiftStorage = new ShiftMySQL();
            Dictionary<int, Dictionary<int, int>> weekDepartments = new Dictionary<int, Dictionary<int, int>>();

            foreach (Shift s in weekShifts)
            {
                Dictionary<int, int> temp = shiftStorage.GetCapacityPerDepartment(s.Id);
                if (temp.Any())
                {
                    weekDepartments.Add(s.Id, temp);
                    initialShiftIds.Add(s.Id);
                }
            }

            allDepartmentCapacityInWeek = weekDepartments;
        }

        /// <summary>
        /// Loads all of the departments from the database.
        /// </summary>
        /// <param name="departmentId">ID of the currently selected department</param>
        private void LoadAllDepartments(int departmentId)
        {
            departmentStorage = new DepartmentMySQL();
            allDepartments = departmentStorage.GetAll();

            foreach (Department d in allDepartments)
            {
                comboBoxSelectDepartment.DisplayMember = "Text";
                comboBoxSelectDepartment.ValueMember = "Department";
                comboBoxSelectDepartment.Items.Add(new { Text = d.Name, Department = d });
            }

            foreach (dynamic dynamicDep in comboBoxSelectDepartment.Items)
            {
                Department dep = dynamicDep.Department;
                if (dep.Id == departmentId)
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
        /// Updates the current capacities to have the newly set values.
        /// </summary>
        private void SaveNewShiftValues()
        {
            foreach (Shift s in weekShifts)
            {
                foreach (dynamic depDynamic in comboBoxSelectDepartment.Items)
                {
                    Department dep = depDynamic.Department;
                    if (dep.Id == currentDepartmentId)
                    {
                        if (allDepartmentCapacityInWeek.ContainsKey(currentDepartmentId))
                        {
                            if (valuesToSave.ContainsKey(s.Id))
                            {
                                allDepartmentCapacityInWeek[s.Id][currentDepartmentId] = valuesToSave[s.Id][currentDepartmentId];
                            }
                        }
                        else
                        {
                            if (valuesToSave.ContainsKey(s.Id))
                            {
                                Dictionary<int, int> temp = new Dictionary<int, int>();
                                temp.Add(currentDepartmentId, valuesToSave[s.Id][currentDepartmentId]);
                                allDepartmentCapacityInWeek.Add(s.Id, temp);
                            }

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the new values for the capacities in a dictionary.
        /// </summary>
        private Dictionary<int, Dictionary<int, int>> UpdateCapacities()
        {
            Dictionary<int, Dictionary<int, int>> output = new Dictionary<int, Dictionary<int, int>>();
            Dictionary<int, int> departmentCapacity;

            foreach (Shift s in weekShifts)
            {
                foreach (dynamic depDynamic in comboBoxSelectDepartment.Items)
                {
                    Department dep = depDynamic.Department;
                    if (dep.Id == currentDepartmentId)
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

        private List<(int shiftId, int departmentId, int capacity)> CreateInheritedCapacitiesList(List<Shift> shiftsPreviousWeek, List<(int shiftId, int departmentId, int capacity)> departmentInfoPreviousWeek)
        {
            List<(int shiftId, int departmentId, int capacity)> output = new List<(int shiftId, int departmentId, int capacity)>();
            int previousShiftId = 0;

            foreach (Shift s in weekShifts)
            {
                foreach (Shift sp in shiftsPreviousWeek)
                {
                    if (sp.Date == s.Date.AddDays(-7) && sp.ShiftTime == s.ShiftTime)
                    {
                        previousShiftId = sp.Id;
                    }
                }

                foreach ((int shiftId, int departmentId, int capacity) data in departmentInfoPreviousWeek)
                {
                    if (data.shiftId == previousShiftId)
                    {
                        output.Add((s.Id, data.departmentId, data.capacity));
                    }
                }
            }


            return output;
        }

        #region control handlers
        /// <summary>
        /// Saves the set number of capacity in the database.
        /// </summary>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            shiftStorage = new ShiftMySQL();
            valuesToSave = UpdateCapacities();

            foreach (Shift s in weekShifts)
            {
                foreach (dynamic depDynamic in comboBoxSelectDepartment.Items)
                {
                    Department dep = depDynamic.Department;
                    if (allDepartmentCapacityInWeek.ContainsKey(s.Id))
                    {
                        Dictionary<int, int> temp = allDepartmentCapacityInWeek[s.Id];
                        if (temp.ContainsKey(dep.Id))
                        {
                            int capacity = temp[dep.Id];
                            bool shiftUpdateSucceeded = false;
                            while (!shiftUpdateSucceeded)
                            {
                                shiftUpdateSucceeded = shiftStorage.UpdateCapacityPerDepartment(s.Id, dep.Id, capacity);
                            }
                        }
                    }
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Saves the changes when a new department is selected.
        /// </summary>
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

        private void buttonInheritCapacity_Click(object sender, EventArgs e)
        {
            List<(int shiftId, int departmentId, int capacity)> inheritedShifts;

            List<Shift> shiftsPreviousWeek = shiftStorage.GetWeek(weekdays[0].AddDays(-7), weekdays[6].AddDays(-7));

            List<int> shiftIdsPreviousWeek = new List<int>();

            foreach (Shift s in shiftsPreviousWeek)
            {
                shiftIdsPreviousWeek.Add(s.Id);
            }

            List<(int shiftId, int departmentId, int capacity)> departmentInfo = departmentStorage.GetCapacityForDepartmentsInCertainShifts(shiftIdsPreviousWeek);

            if (departmentInfo.Count == (21 * allDepartments.Count))
            {
                inheritedShifts = CreateInheritedCapacitiesList(shiftsPreviousWeek, departmentInfo);

                departmentStorage.UpdateCapacityForDepartmentList(inheritedShifts);
                MessageBox.Show("The capacities of the previous week have been set for this week");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Not all capacities were set, therefore none are set now");
            }
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
        /// <summary>
        /// Adds an eventhandler to each of the numericUpDowns which makes it so that changes are only saved once a manual change is made by the user.
        /// </summary>
        private void numericUpDownMondayMorning_ValueChanged(object sender, EventArgs e)
        {
            if (!autoChanged)
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
