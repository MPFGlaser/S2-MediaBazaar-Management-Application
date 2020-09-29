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
    // If editing a product, the fields should be pre-filled and the title should indicate editing mode.
    // if adding a new product, the fields should be empty (maybe not the ID, if that's shown at all) and the title should indicate the user is adding a product.
    public partial class ProductDetailsWindow : Form
    {
        public ProductDetailsWindow()
        {
            InitializeComponent();
        }
    }
}
