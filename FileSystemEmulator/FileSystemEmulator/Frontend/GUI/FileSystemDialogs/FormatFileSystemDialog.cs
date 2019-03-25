using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemEmulator.FileSystemEmulator.Frontend.GUI.FileSystemDialogs
{
    /// <summary>
    /// GUI implementation for the format funcion of <see cref="IFileSystem"/>
    /// </summary>
    public partial class FormatFileSystemDialog : Form
    {
        public bool KeepCopy { get; set; }

        public FormatFileSystemDialog()
        {
            InitializeComponent();
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            KeepCopy = chkCopy.Checked;
            DialogResult = DialogResult.OK;
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }
    }
}
