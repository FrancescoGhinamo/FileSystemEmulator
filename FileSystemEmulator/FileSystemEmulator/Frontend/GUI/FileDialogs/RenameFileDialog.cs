using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemEmulator.FileSystemEmulator.Frontend.GUI.FileDialogs
{
    /// <summary>
    /// UI to rename a <see cref="Efile"/>
    /// </summary>
    public partial class RenameFileDialog : Form
    {
        /// <summary>
        /// Rename coordinates, in [0] is stored source file, in [1] is stored destination file
        /// </summary>
        public string[] RenameCoords { get; set; }

        /// <summary>
        /// Path of the file will be renamed
        /// </summary>
        private string FilePath;

        /// <summary>
        /// Constructor for the dialog
        /// </summary>
        /// <param name="currentLocation">Current browsing location</param>
        public RenameFileDialog(string currentLocation)
        {
            InitializeComponent();
            FilePath = currentLocation;
            RenameCoords = new string[2];
        }



        private void CopyFileDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (!txtDestPath.Text.Equals("") && !txtSourcePath.Text.Equals(""))
            {
                RenameCoords[0] = FilePath + "\\" + txtSourcePath.Text;
                RenameCoords[1] = FilePath + "\\" + txtDestPath.Text;
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