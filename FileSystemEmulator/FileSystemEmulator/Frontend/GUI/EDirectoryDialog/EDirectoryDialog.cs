using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemEmulator.FileSystemEmulator.Frontend.GUI.EDirectoryDialog
{
    /// <summary>
    /// Dialog to guide the creation of a directory
    /// </summary>
    public partial class EDirectoryDialog : Form
    {

        /// <summary>
        /// Path of the new directory
        /// </summary>
        public string GenPath
        {
            get
            {
                return txtPath.Text;
            }
        }

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
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
