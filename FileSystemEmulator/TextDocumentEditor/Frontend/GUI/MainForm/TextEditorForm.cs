using FileChooserDialog;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooserDialog.FileSystemEmulator.Backend.Data.Interfaces;
using FileChooserDialog.FileSystemEmulator.Backend.Exceptions;
using FileChooserDialog.FileSystemEmulator.Frontend.GUI.FileDialogs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextDocumentEditor.Backend.Service;

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

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformNewFile();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformOpen();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformSave();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformSaveAs();
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformImport();
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformExport();
        }


        private void TxtText_TextChanged(object sender, EventArgs e)
        {
            if(CurrentFile != null)
            {
                CurrentFile.WriteToBuffer(txtText.Text, false);
            }
        }

        #endregion EventHandlers



        #region FunctionMethods

        /// <summary>
        /// Initializes the file chooser to open a file
        /// </summary>
        /// <returns></returns>
        public OpenFileDialog InitOpenFileDialog()
        {
            OpenFileDialog res = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = ETextDocument.EXTENSION,
                Filter = "Text files (*.txt)|*." + ETextDocument.EXTENSION

            };
            return res;
        }

        /// <summary>
        /// Initializes the file chooser to save a file
        /// </summary>
        /// <returns></returns>
        public SaveFileDialog InitSaveFileDialog()
        {
            SaveFileDialog res = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = ETextDocument.EXTENSION,
                Filter = "Text files (*.txt)|*." + ETextDocument.EXTENSION

            };
            return res;
        }

        /// <summary>
        /// Prompts operations to create a new file
        /// </summary>
        public void PerformNewFile()
        {
            DialogResult res = DialogResult.Yes;
            if(CurrentFile != null && txtText.Text.Equals(""))
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
                    CurrentFile = (ETextDocument)got;
                    ShowFile();
                }
                else
                {
                    MessageBox.Show(this, "The selected file is of wrong type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        /// <summary>
        /// Saves the content of the file to the file
        /// </summary>
        public void PerformSave()
        {
            if(CurrentFile != null)
            {
                CurrentFile.Flush(true);
            }
            else
            {
                PerformSaveAs();
            }
        }

        /// <summary>
        /// Saves the displayed content with a name
        /// </summary>
        public void PerformSaveAs()
        {
            FileChooser fc = new FileChooser(LocFileSystem.GetCurrentLocation());
            if (fc.ShowDialog(this) == DialogResult.OK)
            {
                string dirPath = fc.SelectedFile.Path;
                string name = Interaction.InputBox("File name", "New file");
                if(!name.EndsWith(ETextDocument.EXTENSION))
                {
                    name += "." + ETextDocument.EXTENSION;
                }

                CurrentFile = new ETextDocument(dirPath + "\\" + name);
                LocFileSystem.Add(CurrentFile);
                CurrentFile.WriteToBuffer(txtText.Text, false);
                CurrentFile.Flush(false);
            }
        }

        /// <summary>
        /// Lets the user import a txt document from the Windows file system
        /// </summary>
        public void PerformImport()
        {
            OpenFileDialog fd = InitOpenFileDialog();

            if(fd.ShowDialog(this) == DialogResult.OK)
            {
                IFileService fs = FileServiceFactory.getFileService();
                string cont = fs.ReadContent(fd.FileName);
                txtText.Text = cont;
            }
        }


        /// <summary>
        /// Exports the <see cref="ETextDocument"/> to a Windows txt file
        /// </summary>
        public void PerformExport()
        {
            PerformSave();
            SaveFileDialog fd = InitSaveFileDialog();

            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                IFileService fs = FileServiceFactory.getFileService();
                fs.WriteString(CurrentFile.Text, fd.FileName);
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
