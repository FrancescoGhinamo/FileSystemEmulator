using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChooser.FileSystemEmulator.Frontend.GUI.FileDialog
{
    /// <summary>
    /// Dialog to guide the creation of a directory
    /// </summary>
    public partial class EDirectoryDialog : Form
    {

        /// <summary>
        /// New <see cref="EDirectory"/>
        /// </summary>
        public EDirectory genDir { get; set; }

        /// <summary>
        /// Constructor for the dialog
        /// </summary>
        /// <param name="currentLocation">Current browsing location</param>
        public EDirectoryDialog(string currentLocation)
        {
            InitializeComponent();
            txtPath.Text = currentLocation;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!txtPath.Text.Equals(""))
            {
                this.genDir = new EDirectory(txtPath.Text);
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                MessageBox.Show(this, "Not all the fields have been filled in", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void EDirectoryDialog_Load(object sender, EventArgs e)
        {

        }

        
    }
}
