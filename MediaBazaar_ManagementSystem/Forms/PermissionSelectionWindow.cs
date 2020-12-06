using System.Windows.Forms;

namespace MediaBazaar_ManagementSystem
{
    public partial class PermissionSelectionWindow : Form
    {
        public PermissionSelectionWindow()
        {
            InitializeComponent();
            SetUniformHeight();
        }

        // if a manager, function management should all be ticked & greyed out to prevent locking oneself out!

        private void SetUniformHeight()
        {
            int maxHeightFound = 0;          

            foreach (Control c in this.flowLayoutPanel.Controls)
            {
                if (c is GroupBox)
                {
                    if (c.Height > maxHeightFound)
                    {
                        maxHeightFound = c.Height;
                    }
                }
            }

            if (maxHeightFound != 0)
            {
                foreach (Control c in this.flowLayoutPanel.Controls)
                {
                    if (c is GroupBox)
                    {
                        ((GroupBox)c).AutoSize = false;
                        c.Height = maxHeightFound;
                    }
                }
            }
        }

        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            if(this.flowLayoutPanel.Width <= 478)
            {
                foreach (Control c in this.flowLayoutPanel.Controls)
                {
                    if (c is GroupBox)
                    {
                        ((GroupBox)c).AutoSize = true;
                    }
                }
            }
            else
            {
                foreach (Control c in this.flowLayoutPanel.Controls)
                {
                    if (c is GroupBox)
                    {
                        ((GroupBox)c).AutoSize = false;
                    }
                }
                SetUniformHeight();
            }
        }
    }
}
