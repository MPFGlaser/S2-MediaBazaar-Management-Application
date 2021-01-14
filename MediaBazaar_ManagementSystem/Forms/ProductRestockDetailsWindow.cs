using System;
using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem.Forms
{
    public partial class ProductRestockDetailsWindow : Form
    {
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
            Text = "Viewing/editing " + item.Brand + " " + item.Name;

            // Sets some editing-specific variables to the right values
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
            Close();
        }
    }
}
