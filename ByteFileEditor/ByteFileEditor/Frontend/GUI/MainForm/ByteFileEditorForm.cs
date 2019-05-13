using ByteFileEditor.ByteFileEditor.Backend.Exceptions;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooser.FileSystemEmulator.Backend.Data.Interfaces;
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
            EFile fetched = LocFileSystem.GetFile(args[0]);

            /*
             * test wether the fetched variable is of EByteFile type
             */
            if(true)
            {
                CurrentFile = (EByteFile) fetched;
                DisplayCurrentFile();
            }
            else
            {
                throw new TypeMismatchException();
            }
        }

        #endregion Constructor


        #region EvetnHandlers
        private void ByteFileEditor_Load(object sender, EventArgs e)
        {

        }


        #endregion EventHandlers


        #region FunctionMethods



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