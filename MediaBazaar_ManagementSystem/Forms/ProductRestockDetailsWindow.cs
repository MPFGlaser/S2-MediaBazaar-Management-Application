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
    public partial class ProductRestockDetailsWindow : Form
    {
        private bool editing = false;
        private int editId;
        private int quantity;
        private int userid;
        IItemStorage itemStorage;

        public ProductRestockDetailsWindow()
        {
            InitializeComponent();
            itemStorage = new ItemMySQL();
        }

        public void AddItemData(Item item, int userId)
        {
            // Sets the form title to indicate which item is being edited
            this.Text = "Viewing/editing " + item.Brand + " " + item.Name;

            // Sets some editing-specific variables to the right values
            editing = true;
            editId = item.Id;
            quantity = Convert.ToInt32(nudqRestockQuantity.Value);
            userid = userId;

            // Fills all the controls with the right values
            lblID.Text = item.Id.ToString();
            tbCurrentStock.Text = item.Quantity.ToString();
            lblProductName.Text = item.Name;
            lblProductCategory.Text = item.Category;
            lblProductCode.Text = item.Code.ToString();
        }

        private void btnSendrequest_Click(object sender, EventArgs e)
        {
            quantity = Convert.ToInt32(nudqRestockQuantity.Value);
            itemStorage.SendStockRequest(userid, editId, quantity);
            this.Close();
        }
    }
}
