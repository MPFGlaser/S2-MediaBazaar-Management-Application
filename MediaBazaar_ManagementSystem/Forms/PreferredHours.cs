﻿using System;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    /// <summary>
    /// A form to indicate which shifts an employee prefers to work on certain days.
    /// <para>Returns a 21-bit string of shifts in chronological order.</para>
    /// <para>The first 3 bits are Monday morning, afternoon, and evening, then Tuesday, etc.</para>
    /// </summary>
    public partial class PreferredHours : Form
    {
        // Makes sure no preferred hours string was left by accident
        private string preferredHours = null;

        public PreferredHours()
        {
            InitializeComponent();
        }

        public PreferredHours(string input)
        {
            InitializeComponent();
            PrefillCheckboxes(input);
        }

        public string PreferredHoursString
        {
            get { return this.preferredHours; }
        }

        #region Logic
        /// <summary>
        /// Assembles the 21-bit string based on the checkboxes checked by the user.
        /// <para>If one is checked, a 1 is added to the string. If it isn't, a 0 will be added. </para>
        /// <para>Iterates through every checkbox in chronological order.</para>
        /// </summary>
        private void AssemblePreferredHours()
        {
            // Monday
            preferredHours = checkBoxMondayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxMondayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxMondayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            // Tuesday
            preferredHours = checkBoxTuesdayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxTuesdayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxTuesdayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            // Wednesday
            preferredHours = checkBoxWednesdayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxWednesdayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxWednesdayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            // Thursday
            preferredHours = checkBoxThursdayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxThursdayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxThursdayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            // Friday
            preferredHours = checkBoxFridayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxFridayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxFridayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            // Saturday
            preferredHours = checkBoxSaturdayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxSaturdayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxSaturdayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            // Sunday
            preferredHours = checkBoxSundayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxSundayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxSundayEvening.Checked ? preferredHours += "1" : preferredHours += "0";
        }

        /// <summary>
        /// Pre-fills the checkboxes based on the given string
        /// <para>In chronological order</para>
        /// </summary>
        /// <param name="input"></param>
        private void PrefillCheckboxes(string input)
        {
            // Monday
            checkBoxMondayMorning.Checked = input[0] == '1' ? true : false;
            checkBoxMondayAfternoon.Checked = input[1] == '1' ? true : false;
            checkBoxMondayEvening.Checked = input[2] == '1' ? true : false;

            // Tuesday
            checkBoxTuesdayMorning.Checked = input[3] == '1' ? true : false;
            checkBoxTuesdayAfternoon.Checked = input[4] == '1' ? true : false;
            checkBoxTuesdayEvening.Checked = input[5] == '1' ? true : false;

            // Wednesday
            checkBoxWednesdayMorning.Checked = input[6] == '1' ? true : false;
            checkBoxWednesdayAfternoon.Checked = input[7] == '1' ? true : false;
            checkBoxWednesdayEvening.Checked = input[8] == '1' ? true : false;

            // Thursday
            checkBoxThursdayMorning.Checked = input[9] == '1' ? true : false;
            checkBoxThursdayAfternoon.Checked = input[10] == '1' ? true : false;
            checkBoxThursdayEvening.Checked = input[11] == '1' ? true : false;

            // Friday
            checkBoxFridayMorning.Checked = input[12] == '1' ? true : false;
            checkBoxFridayAfternoon.Checked = input[13] == '1' ? true : false;
            checkBoxFridayEvening.Checked = input[14] == '1' ? true : false;

            // Saturday
            checkBoxSaturdayMorning.Checked = input[15] == '1' ? true : false;
            checkBoxSaturdayAfternoon.Checked = input[16] == '1' ? true : false;
            checkBoxSaturdayEvening.Checked = input[17] == '1' ? true : false;
            
            // Sunday
            checkBoxSundayMorning.Checked = input[18] == '1' ? true : false;
            checkBoxSundayAfternoon.Checked = input[19] == '1' ? true : false;
            checkBoxSundayEvening.Checked = input[20] == '1' ? true : false;

        } 
        #endregion

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            AssemblePreferredHours();
            DialogResult = DialogResult.OK;
        }
    }
}
