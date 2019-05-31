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
    /// GUI implementation of the delete function of the <see cref="IFileSystem"/>
    /// </summary>
    public partial class DeleteFileDialog : Form
    {
        /// <summary>
        /// File that will be deleted
        /// </summary>
        public string ToDelFile { get; set; }

        public DeleteFileDialog(string currentLocation)
        {
            InitializeComponent();
            txtFileName.Text = currentLocation;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!txtFileName.Text.Equals(""))
            {
                ToDelFile = txtFileName.Text;
                DialogResult = DialogResult.OK;
                Dispose();
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
