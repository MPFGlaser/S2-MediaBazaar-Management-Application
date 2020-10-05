using MediaBazaar_ManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    // If editing a product, the fields should be pre-filled and the title should indicate editing mode.
    // if adding a new product, the fields should be empty (maybe not the ID, if that's shown at all) and the title should indicate the user is adding a product.
    public partial class ProductDetailsWindow : Form
    {
        private Item item;
        private bool editing = false;
        private int editId;

        public ProductDetailsWindow()
        {
            InitializeComponent();
        }

        public Item Item
        {
            get { return this.Item; }
        }

        private void CreateItem(string name, string brand, int code, string category, int quantity, double price, bool active, string description)
        {
            item = new Item(0, name, brand, code, category, quantity, price, active, description);
        }

        private void UpdateItem(int id, string name, string brand, int code, string category, int quantity, double price, bool active, string description)
        {
            item = new Item(id, name, brand, code, category, quantity, price, active, description);
        }

        public void AddItemData(Item item)
        {
            this.Text = "Viewing/editing " + item.Brand + " " + item.Name;
            editing = true;
            editId = item.Id;

            numericUpDownPrice.Value = Convert.ToDecimal(item.Price);
            numericUpDownQuantity.Value = item.Quantity;
            textBoxName.Text = item.Name;
            textBoxBrand.Text = item.Brand;
            textBoxCode.Text = item.Code.ToString();
            textBoxCategory.Text = item.Category;
            richTextBoxDescription.Text = item.Description;
        }

        private void buttonPDWConfirm_Click(object sender, EventArgs e)
        {
            ResetBoxColors();

            double price = Convert.ToDouble(numericUpDownPrice);
            int quantity = Convert.ToInt32(numericUpDownQuantity.Value);
            bool active = checkBoxActive.Checked;
            string name = textBoxName.Text;
            string brand = textBoxBrand.Text;
            int code = Convert.ToInt32(textBoxCode);
            string category = textBoxCategory.Text;
            string description = richTextBoxDescription.Text;

            if (name != "")
            {
                textBoxName.BackColor = Color.LightCoral;
            }
            else if (brand != "")
            {
                textBoxBrand.BackColor = Color.LightCoral;
            }
            else if (code.ToString() != "")
            {
                textBoxCode.BackColor = Color.LightCoral;
            }
            else if (category != "")
            {
                textBoxCategory.BackColor = Color.LightCoral;
            }
            else
            {
                if (editing)
                {
                    UpdateItem(editId, name, brand, code, category, quantity, price, active, description);
                }
                else
                {
                    CreateItem(name, brand, code, category, quantity, price, active, description);
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void ResetBoxColors()
        {
            textBoxName.BackColor = Color.FromName("Window");
            textBoxBrand.BackColor = Color.FromName("Window");
            textBoxCode.BackColor = Color.FromName("Window");
            textBoxCategory.BackColor = Color.FromName("Window");
            numericUpDownPrice.BackColor = Color.FromName("Window");
            numericUpDownQuantity.BackColor = Color.FromName("Window");
        }

        private void buttonPDWCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
