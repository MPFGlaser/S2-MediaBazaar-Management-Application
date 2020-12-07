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

        /// <summary>
        /// Sets the height of the groupboxes uniform to be the same as the greatest height found amongst all of them.
        /// <para>This is so it looks nice when tiled in more than 1 column.</para>
        /// </summary>
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

        /// <summary>
        /// Every time the size of the flowLayoutPanel is updated, it checks if the width is smaller than necessary for it to tile two controls next to each other.
        /// <para>When that's the case, the extra blank space in some controls is removed.</para>
        /// <para>When it's wide enough again to also tile horizontally, the blank space is added again.</para>
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
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
