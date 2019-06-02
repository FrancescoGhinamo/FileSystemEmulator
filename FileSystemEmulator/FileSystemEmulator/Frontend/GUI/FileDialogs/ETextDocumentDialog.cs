using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooserDialog.FileSystemEmulator.Backend.Services.Implementations;
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
    /// UI to create <see cref="ETextDocument"/> instances
    /// </summary>
    public partial class ETextDocumentDialog : Form
    {
    

        /// <summary>
        /// <see cref="ETextDocument"/> created by the dialog
        /// </summary>
        public ETextDocument textDocument { get; set; }

        /// <summary>
        /// Constructor for the dialog
        /// </summary>
        /// <param name="currentLocation">Current browsing location</param>
        public ETextDocumentDialog(string currentLocation)
        {
            InitializeComponent();
            txtDest.Text = currentLocation;
        }

        

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openD = new OpenFileDialog()
            {
                DefaultExt = "txt"
            };
            if(openD.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openD.FileName;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(!txtPath.Text.Equals("") && !txtDest.Equals(""))
            {
                textDocument = new ETextDocument(txtDest.Text + "." + ETextDocument.EXTENSION);

                byte[] winFileContent = FileServicesFactory.GetGenFileServices().ReadBytes(txtPath.Text);
                if(winFileContent != null)
                {
                    char[] _t = new char[winFileContent.Length];
                    for(int i = 0; i < _t.Length; i++)
                    {
                        _t[i] = (char)winFileContent[i];
                    }
                    textDocument.WriteToBuffer(new string(_t), false);
                    textDocument.Flush(false);
                }
                
               
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

        private void TxtDest_DoubleClick(object sender, EventArgs e)
        {
            FileChooser chooser = new FileChooser("Choose directory");
            if (chooser.ShowDialog(this) == DialogResult.OK) {
                EFile selected = chooser.SelectedFile;
                if(selected.Directory)
                {
                    txtDest.Text = selected.Path;
                }
                else
                {
                    txtDest.Text = selected.ParentPath;
                }
            }
           
        }

    }
}
