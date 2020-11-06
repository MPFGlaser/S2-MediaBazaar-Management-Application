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
    public partial class PreferredHours : Form
    {
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

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            AssemblePreferredHours();
            DialogResult = DialogResult.OK;
        }

        private void AssemblePreferredHours()
        {
            preferredHours = checkBoxMondayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxMondayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxMondayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            preferredHours = checkBoxTuesdayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxTuesdayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxTuesdayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            preferredHours = checkBoxWednesdayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxWednesdayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxWednesdayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            preferredHours = checkBoxThursdayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxThursdayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxThursdayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            preferredHours = checkBoxFridayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxFridayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxFridayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            preferredHours = checkBoxSaturdayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxSaturdayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxSaturdayEvening.Checked ? preferredHours += "1" : preferredHours += "0";

            preferredHours = checkBoxSundayMorning.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxSundayAfternoon.Checked ? preferredHours += "1" : preferredHours += "0";
            preferredHours = checkBoxSundayEvening.Checked ? preferredHours += "1" : preferredHours += "0";
        }

        private void PrefillCheckboxes(string input)
        {
            checkBoxMondayMorning.Checked = input[0] == '1' ? true : false;
            checkBoxMondayAfternoon.Checked = input[1] == '1' ? true : false;
            checkBoxMondayEvening.Checked = input[2] == '1' ? true : false;

            checkBoxTuesdayMorning.Checked = input[3] == '1' ? true : false;
            checkBoxTuesdayAfternoon.Checked = input[4] == '1' ? true : false;
            checkBoxTuesdayEvening.Checked = input[5] == '1' ? true : false;

            checkBoxWednesdayMorning.Checked = input[6] == '1' ? true : false;
            checkBoxWednesdayAfternoon.Checked = input[7] == '1' ? true : false;
            checkBoxWednesdayEvening.Checked = input[8] == '1' ? true : false;

            checkBoxThursdayMorning.Checked = input[9] == '1' ? true : false;
            checkBoxThursdayAfternoon.Checked = input[10] == '1' ? true : false;
            checkBoxThursdayEvening.Checked = input[11] == '1' ? true : false;

            checkBoxFridayMorning.Checked = input[12] == '1' ? true : false;
            checkBoxFridayAfternoon.Checked = input[13] == '1' ? true : false;
            checkBoxFridayEvening.Checked = input[14] == '1' ? true : false;

            checkBoxSaturdayMorning.Checked = input[15] == '1' ? true : false;
            checkBoxSaturdayAfternoon.Checked = input[16] == '1' ? true : false;
            checkBoxSaturdayEvening.Checked = input[17] == '1' ? true : false;

            checkBoxSundayMorning.Checked = input[18] == '1' ? true : false;
            checkBoxSundayAfternoon.Checked = input[19] == '1'? true : false;
            checkBoxSundayEvening.Checked = input[20] == '1' ? true : false;

        }
    }
}
