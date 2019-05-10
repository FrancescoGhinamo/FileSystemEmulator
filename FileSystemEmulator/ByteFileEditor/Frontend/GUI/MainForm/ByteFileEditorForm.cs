using FileChooser;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooser.FileSystemEmulator.Backend.Data.Interfaces;
using FileChooser.FileSystemEmulator.Frontend.GUI.FileDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ByteFileEditor.Frontend.GUI.MainForm
{
    /// <summary>
    /// Main form of the ByteFileEditor
    /// </summary>
    public partial class ByteFileEditorForm : Form
    {
        #region Fields
        /// <summary>
        /// Current <see cref="EByteFile"/> the program is working on
        /// </summary>
        private EByteFile CurrentFile;

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
        public ByteFileEditorForm(string[] args)
        {
            InitializeComponent();
            LocFileSystem = FileSystemFactory.GetFileSystem();
            if(args != null)
            {
                EFile fetched = LocFileSystem.GetFile(args[0]);

                if (fetched.Extension.Equals(EByteFileDialog.EXTENSION))
                {
                    CurrentFile = (EByteFile)fetched;
                    DisplayCurrentFile();
                }
                else
                {
                    MessageBox.Show(this, "The selected file is not of the correct file type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        #endregion Constructor


        #region EventHandlers

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        #endregion EventHandlers


        #region FunctionMethods

        /// <summary>
        /// Allows the user to open an <see cref="EByteFile"/>
        /// </summary>
        public void OpenFile()
        {
            FileChooser.FileChooser exp = new FileChooser.FileChooser();
            if(exp.ShowDialog(this) == DialogResult.OK)
            {
                EFile f = exp.SelectedFile;
                if(f.Extension.Equals(EByteFileDialog.EXTENSION))
                {
                    CurrentFile = (EByteFile)exp.SelectedFile;
                    DisplayCurrentFile();
                }
                else
                {
                    MessageBox.Show(this, "The selected file is not of the correct file type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        #endregion FunctionMethods


        #region DisplayMethods

        /// <summary>
        /// Displays the content of the current <seealso cref="EByteFile"/>
        /// </summary>
        public void DisplayCurrentFile()
        {
            if(CurrentFile != null)
            {
                char[] chars = new char[CurrentFile.Content.Length];
                for(int i = 0; i < chars.Length; i++)
                {
                    chars[i] = (char)CurrentFile.Content[i];
                }
                txtFileContent.Text = new string(chars);
            }
        }

        #endregion DisplayMethods



    }
}
