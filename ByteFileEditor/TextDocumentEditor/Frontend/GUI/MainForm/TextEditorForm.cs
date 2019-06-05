using FileChooserDialog;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooserDialog.FileSystemEmulator.Backend.Data.Interfaces;
using FileChooserDialog.FileSystemEmulator.Backend.Exceptions;
using FileChooserDialog.FileSystemEmulator.Frontend.GUI.FileDialogs;
using FileSystemEmulator.TextDocumentEditor.Backend.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TextDocumentEditor.Frontend.GUI.MainForm
{
    /// <summary>
    /// Main form of the TextEditor
    /// </summary>
    public partial class TextEditorForm : Form
    {
        #region Fields
        /// <summary>
        /// Current <see cref="ETextDocument"/> the program is working on
        /// </summary>
        private ETextDocument CurrentFile;

        /// <summary>
        /// Reference to the <see cref="IFileSystem"/> instance
        /// </summary>
        /// <exception cref="TypeMismatchException">Thorwn if the program is attempting to open a file of a wrong type</exception>
        private IFileSystem LocFileSystem;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args">Parameters passed to the staring program: file that has to be opened</param>
        public TextEditorForm(string[] args)
        {
            InitializeComponent();
            LocFileSystem = FileSystemFactory.GetFileSystem();
            if(args != null)
            {
                EFile fetched = LocFileSystem.GetFile(args[0]);

                if (fetched.Extension.Equals(ETextDocument.EXTENSION))
                {
                    CurrentFile = (ETextDocument)fetched;
                    ShowFile();
                }
                else
                {
                    MessageBox.Show(this, "The selected file is not of the correct file type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        #endregion Constructor


        #region EventHandlers

        public static void Main()
        {

        }
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformNewFile();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion EventHandlers



        #region FunctionMethods

        /// <summary>
        /// Prompts operations to create a new file
        /// </summary>
        public void PerformNewFile()
        {
            DialogResult res = DialogResult.Yes;
            if(CurrentFile != null)
            {
                res = MessageBox.Show(this, "A file is already open, do you wish to create a new one?", "New File", MessageBoxButtons.YesNo);
            }

            if(res.Equals(DialogResult.Yes))
            {
                CurrentFile = null;
                txtText.Text = "";
            }
        }

        /// <summary>
        /// Opens a file
        /// </summary>
        public void PerformOpen()
        {
            FileChooser fc = new FileChooser(LocFileSystem.GetCurrentLocation());
            if(fc.ShowDialog(this) == DialogResult.OK)
            {
                EFile got = fc.SelectedFile;
                if(got.Extension.Equals(ETextDocument.EXTENSION))
                {

                }
                else
                {
                    MessageBox.Show(this, "The selected file is of wrong type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        #endregion FunctionMethods

        #region DisplayMethods

        /// <summary>
        /// Shows the <see cref="CurrentFile"/> on the form
        /// </summary>
        public void ShowFile()
        {
            txtText.Text = CurrentFile.Text;
        }





        #endregion DisplayMethods

        
    }
}
