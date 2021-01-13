using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class AddNewFunctionWindow : Form
    {
        IFunctionStorage functionStorage;
        Dictionary<int, string> currentFunctions;
        public AddNewFunctionWindow()
        {
            InitializeComponent();
            functionStorage = new FunctionMySQL();
            currentFunctions = functionStorage.GetFunctions();
        }

        public string Title;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxFunctionTitle.TextLength > 0)
            {
                bool valid = true;
                Title = textBoxFunctionTitle.Text;

                // Checks if the function title already exists in the database. If it does, it won't be added again.
                // Does a conversion to lowercase, so capitalisation doesn't matter.
                foreach (KeyValuePair<int, string> i in currentFunctions)
                {
                    if (i.Value.ToLower() == Title.ToLower())
                    {
                        valid = false;
                        ErrorMessages.InformationInvalid();
                    }
                }

                if (valid == true)
                {
                    if (functionStorage.Create(Title))
                    {
                        Close();
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            else
            {
                ErrorMessages.InformationInvalid();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
