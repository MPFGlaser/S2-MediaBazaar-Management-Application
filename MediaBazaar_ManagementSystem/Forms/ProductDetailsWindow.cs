using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    /// <summary>
    /// Form in which the details of a product can be edited
    /// <para>The item can then be added to the itemStorage or, if it exists already, be edited.</para>
    /// </summary>
    public partial class ProductDetailsWindow : Form
    {
        IItemStorage itemStorage;
        private Item item;
        private bool editing = false;
        private int editId;

        public ProductDetailsWindow()
        {
            InitializeComponent();
            itemStorage = new ItemMySQL();
        }

        public Item Item
        {
            get { return this.item; }
        }

        #region Logic
        /// <summary>
        /// Creates an Item object with the given parameters ready for being added to the itemStorage
        /// <para>Due to it being for a new item specifically, the id is 0</para>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="brand"></param>
        /// <param name="code"></param>
        /// <param name="category"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="active"></param>
        /// <param name="description"></param>
        private bool CreateItem(string name, string brand, int code, string category, int quantity, double price, bool active, string description)
        {
            item = new Item(0, name, brand, code, category, quantity, price, active, description);
            return itemStorage.Create(item);
        }

        /// <summary>
        /// Creates an Item object with the given parameters ready for updating an existing entry in the databse
        /// <para>Due to it being or updating an existing item, the id is specific to the item in question</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="brand"></param>
        /// <param name="code"></param>
        /// <param name="category"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="active"></param>
        /// <param name="description"></param>
        private bool UpdateItem(int id, string name, string brand, int code, string category, int quantity, double price, bool active, string description)
        {
            item = new Item(id, name, brand, code, category, quantity, price, active, description);
            return itemStorage.Update(item);
        }

        /// <summary>
        /// Pre-fills all the controls with data present in the given Item instance
        /// </summary>
        /// <param name="item"></param>
        public void AddItemData(Item item)
        {
            // Sets the form title to indicate which item is being edited
            this.Text = "Viewing/editing " + item.Brand + " " + item.Name;

            // Sets some editing-specific variables to the right values
            editing = true;
            editId = item.Id;

            // Fills all the controls with the right values
            labelID.Text = item.Id.ToString();
            numericUpDownPrice.Value = Convert.ToDecimal(item.Price);
            numericUpDownQuantity.Value = item.Quantity;
            textBoxName.Text = item.Name;
            textBoxBrand.Text = item.Brand;
            textBoxCode.Text = item.Code.ToString();
            textBoxCategory.Text = item.Category;
            richTextBoxDescription.Text = item.Description;
            checkBoxActive.Checked = item.Active;
        }

        /// <summary>
        /// Function that is run when the confirm button is pressed
        /// <para>Checks the inputs with regex expressions and when there is incorrect data present, it informs the user that that should be fixed before proceeding.</para>
        /// </summary>
        private void Confirm()
        {
            // Resets the warning colour of all input controls
            ResetBoxColors();

            // All the regex expressions used in this form
            Regex checkStandardInput = new Regex(@"^[^\s].*");
            Regex checkCategory = new Regex(@"^[a-zA-Z\s]+$");
            Regex checkCode = new Regex(@"^[0-9]*\d{4,15}$");

            // Assigns the value of each input to its corresponding variable
            double price = Convert.ToDouble(numericUpDownPrice.Value);
            int quantity = Convert.ToInt32(numericUpDownQuantity.Value);
            bool active = checkBoxActive.Checked;
            string name = textBoxName.Text;
            string brand = textBoxBrand.Text;
            string category = textBoxCategory.Text;
            string description = richTextBoxDescription.Text;
            Boolean allCorrect = true;

            // In this wall of if statements all regex expressions are checked
            // When a check fails, the background of that specific input control is changed to red to inform the user something's wrong
            if (!checkStandardInput.IsMatch(name))
            {
                allCorrect = false;
                textBoxName.BackColor = Color.LightCoral;
            }
            if (!checkStandardInput.IsMatch(brand))
            {
                allCorrect = false;
                textBoxBrand.BackColor = Color.LightCoral;
            }
            if (!checkCategory.IsMatch(category))
            {
                allCorrect = false;
                textBoxCategory.BackColor = Color.LightCoral;
            }
            if (!checkCode.IsMatch(textBoxCode.Text))
            {
                allCorrect = false;
                textBoxCode.BackColor = Color.LightCoral;
            }

            // If all regex expressions pass, this is run
            if (allCorrect)
            {
                bool success;

                // Converts the input in the code textbox from a string to an integer. Looks shabby, but since it has been checked with regex it cannot cause any problems (theoretically.)
                int code = Convert.ToInt32(textBoxCode.Text);

                // Checks if the form is in editing mode
                if (editing)
                {
                    // Creates an Item object ready for updating an entry in the itemStorage
                    success = UpdateItem(editId, name, brand, code, category, quantity, price, active, description);
                }
                else
                {
                    // Creates an Item object ready for being added to the itemStorage
                    success = CreateItem(name, brand, code, category, quantity, price, active, description);
                }

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// Resets the background colours of the input boxes as to not wrongfully indicate any invalid input to the user.
        /// </summary>
        private void ResetBoxColors()
        {
            textBoxName.BackColor = Color.FromName("Window");
            textBoxBrand.BackColor = Color.FromName("Window");
            textBoxCode.BackColor = Color.FromName("Window");
            textBoxCategory.BackColor = Color.FromName("Window");
            numericUpDownPrice.BackColor = Color.FromName("Window");
            numericUpDownQuantity.BackColor = Color.FromName("Window");
        }
        #endregion

        #region User control event handlers
        private void buttonPDWConfirm_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void buttonPDWCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
