using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChooserDialog.FileSystemEmulator.Frontend.GUI.FileDialogs
{
    /// <summary>
    /// UI to move <see cref="EFile"/> instances
    /// </summary>
    public partial class MoveFileDialog : Form
    {
        /// <summary>
        /// Move coordinates, in [0] is stored source file, in [1] is stored destination file
        /// </summary>
        public string[] MoveCoords { get; set; }

        /// <summary>
        /// Constructor for the dialog
        /// </summary>
        /// <param name="currentLocation">Current browsing location</param>
        public MoveFileDialog(string currentLocation)
        {
            InitializeComponent();
            txtSourcePath.Text = currentLocation;
            txtDestPath.Text = currentLocation;
            MoveCoords = new string[2];
        }



        private void CopyFileDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (!txtDestPath.Text.Equals("") && !txtSourcePath.Text.Equals(""))
            {
                MoveCoords[0] = txtSourcePath.Text;
                MoveCoords[1] = txtDestPath.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, "Not all the fields have been filled in", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

    }
}
