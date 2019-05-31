using ByteFileEditor.Frontend.GUI.MainForm;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooserDialog.FileSystemEmulator.Backend.Data.Interfaces;
using FileChooserDialog.FileSystemEmulator.Backend.Exceptions;
using FileChooserDialog.FileSystemEmulator.Frontend.GUI.FileDialog;
using FileChooserDialog.FileSystemEmulator.Frontend.GUI.FileDialogs;
using FileChooserDialog.FileSystemEmulator.Frontend.GUI.FileSystemDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChooserDialog
{
    /// <summary>
    /// Main form of the application
    /// </summary>
    public partial class FileChooser : Form
    {


        #region FileServiceInfo

        /// <summary>
        /// Default extension for the file system emulator 
        /// </summary>
        private const string DEFAULT_EXT = "efs";

        /// <summary>
        /// Current file to which is saved the serialization of the file system
        /// </summary>
        private string CurrentFile { get; set; }

        /// <summary>
        /// Keeps trace whether the file system has been modified (true if)
        /// </summary>
        private bool FSModified { get; set; }

        #endregion FileServiceInfo

        #region PrivateFields





        /// <summary>
        /// Location currently browsing
        /// </summary>
        private EFile CurrentLocation;

        /// <summary>
        /// Local instance of <see cref="IFileSystem"/>
        /// </summary>
        private IFileSystem FileSystemInst;

        #endregion PrivateFields

        /// <summary>
        /// Selected file in the dialog
        /// </summary>
        public EFile SelectedFile;

        /// <summary>
        /// GUI Constructor
        /// </summary>
        /// <param name="title">Title of the window</param>
        public FileChooser(string title)
        {
            this.Text = title;
            FileSystemInst = FileSystemFactory.GetFileSystem();
            CurrentLocation = FileSystemInst.GetRoot();
            CurrentFile = "";
            InitializeComponent();
            this.Text = title;
        }

        private void FileSystemEmulator_Load(object sender, EventArgs e)
        {

            UpdateWholeDisplay();
        }

        #region EventHandlers
        private void listDirectory_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                PerformClickOnList(CurrentLocation.SubFiles.ElementAt(listDirectory.Items.IndexOf(listDirectory.SelectedItems[0])).Path);
            }
            catch (EFileNotFoundException exc)
            {
                MessageBox.Show(this, "Error: " + exc.Message, "Error");
            }
            finally
            {
                UpdateBasicExplorerGraphics();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                PerformGoToDirectory(txtPath.Text);
            }
            catch (EFileNotFoundException)
            {
                MessageBox.Show(this, "The selected directory or file doesn't exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                UpdateBasicExplorerGraphics();
            }

        }

        private void btnSuperDir_Click(object sender, EventArgs e)
        {
            PerformGoToSuperDirecotory();
            UpdateBasicExplorerGraphics();
        }


        private void treeExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                PerformGoToDirectory(e.Node.FullPath);
            }
            catch (EFileNotFoundException)
            {
                MessageBox.Show(this, "The selected directory or file doesn't exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                UpdateBasicExplorerGraphics();
            }
        }


        private void NewDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformCreateEDirectory();
                UpdateWholeDisplay();
            }
            catch (EFileNameAlreadyExistingException exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformCopyFile();
                UpdateWholeDisplay();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformMoveFile();
                UpdateWholeDisplay();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformRenameFile();
                UpdateWholeDisplay();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformDeleteFile();
                UpdateWholeDisplay();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            PerformOK();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            PerformCancel();
        }

        #endregion EventHandlers

        #region BrowsingMethods

        /// <summary>
        /// Enters a specified <see cref="EDirectory"/>
        /// If the selection is not a directory, the file is opened
        /// </summary>
        /// <param name="path">Path of the clicked file</param>
        /// <exception cref="EFileNotFoundException">The requested file was not found</exception>
        public void PerformClickOnList(string path)
        {
            try
            {
                EFile fetched = FileSystemInst.GetFile(path);
                if (fetched.Directory)
                {
                    CurrentLocation = fetched;
                }
                else
                {
                    SelectedFile = fetched;
                }
                
            }
            catch (EFileNotFoundException e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Opens the specified directory
        /// </summary>
        /// <param name="path">Path of the directory</param>
        /// <exception cref="EFileNotFoundException">Thrown if the file doesn't exist</exception>
        public void PerformGoToDirectory(string path)
        {
            if (!path.Equals(""))
            {
                //remove extra slashes
                while (path.EndsWith("\\"))
                {
                    path = path.Substring(0, path.LastIndexOf("\\"));
                }

                try
                {
                    EFile fetched = FileSystemInst.GetFile(path);
                    if (fetched != null)
                    {
                        if (fetched.Directory)
                        {
                            CurrentLocation = fetched;
                        }
                        else
                        {
                            SelectedFile = fetched;
                        }
                    }

                }
                catch (EFileNotFoundException e)
                {
                    throw e;
                }
            }


        }

        
        /// <summary>
        /// Moves to the super directory of the current dir
        /// </summary>
        public void PerformGoToSuperDirecotory()
        {
            //if I'm not in the root yet...
            if (!CurrentLocation.Path.Equals("C:"))
            {
                string superPath = CurrentLocation.ParentPath;
                try
                {
                    PerformGoToDirectory(superPath);
                }
                catch (EFileNotFoundException) { }


            }
        }
        #endregion BrowsingMethods

        #region FileCreationMethods

        /// <summary>
        /// Allows the user to create an <see cref="EDirectory"/> displaying the relative dialog
        /// </summary>
        /// <exception cref="EFileNameAlreadyExistingException">A dir with the same name already exists</exception>
        public void PerformCreateEDirectory()
        {
            EDirectoryDialog dirD = new EDirectoryDialog(CurrentLocation.Path);
            if (dirD.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileSystemInst.Add(dirD.genDir);
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }

            }
        }


        #endregion FileCreationMethods

        #region FileManagingMethods

        /// <summary>
        /// Allows the user to copy an <see cref="EFile"/> in the instance of <see cref="IFileSystem"/>
        /// </summary>
        /// /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        public void PerformCopyFile()
        {
            CopyFileDialog cD = new CopyFileDialog(CurrentLocation.Path);
            if (cD.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileSystemInst.CopyFile(cD.CopyCoords[0], cD.CopyCoords[1]);
                }
                catch (EFileNotFoundException e)
                {
                    throw e;
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Allows the user the move an <see cref="EFile"/>
        /// </summary>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        public void PerformMoveFile()
        {
            MoveFileDialog mD = new MoveFileDialog(CurrentLocation.Path);
            if (mD.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileSystemInst.MoveFile(mD.MoveCoords[0], mD.MoveCoords[1]);
                }
                catch (EFileNotFoundException e)
                {
                    throw e;
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Allows the user the rename an <see cref="EFile"/>
        /// </summary>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        public void PerformRenameFile()
        {
            RenameFileDialog rD = new RenameFileDialog(CurrentLocation.Path);
            if (rD.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileSystemInst.MoveFile(rD.RenameCoords[0], rD.RenameCoords[1]);
                }
                catch (EFileNotFoundException e)
                {
                    throw e;
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Allows the user to delete an instance of <see cref="EFile"/>
        /// </summary>
        /// <exception cref="EFileNotFoundException">Thrown if it's attempting to rename a file that doesn't exist</exception>
        public void PerformDeleteFile()
        {
            DeleteFileDialog dD = new DeleteFileDialog(CurrentLocation.Path);
            if (dD.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileSystemInst.DeleteFile(dD.ToDelFile);
                }
                catch (EFileNotFoundException e)
                {
                    throw e;
                }
            }
        }

        #endregion FileManagingMethods


        #region DisplayMethods

        /// <summary>
        /// Updates the content of the list according to the <see cref="CurrentLocation"/>
        /// </summary>
        public void UpdateList()
        {
            listDirectory.Items.Clear();
            foreach (EFile f in CurrentLocation.SubFiles)
            {
                listDirectory.Items.Add(f.ToString());
            }
        }

        /// <summary>
        /// Updates the path text area referencing to the current location
        /// </summary>
        public void UpdatePathTextArea()
        {
            txtPath.Text = CurrentLocation.Path;
        }

        /// <summary>
        /// Updates the tree to the current situation of the file system
        /// </summary>
        public void UpdateTreeExplorer()
        {
            treeExplorer.BeginUpdate();
            treeExplorer.Nodes.Clear();
            treeExplorer.Nodes.Add(FileSystemInst.GetTreeNodes());
            treeExplorer.EndUpdate();
        }

        /// <summary>
        /// Updates the basic explorer graphics: list and path area
        /// </summary>
        public void UpdateBasicExplorerGraphics()
        {
            UpdateList();
            UpdatePathTextArea();
        }

        /// <summary>
        /// Updates the whole graphic info about current location
        /// </summary>
        public void UpdateWholeDisplay()
        {
            UpdateList();
            UpdatePathTextArea();
            UpdateTreeExplorer();
        }









        #endregion DisplayMethods

        #region DialogMethods

        /// <summary>
        /// Responds to the OK butto pressure, prepare the results for the owner form
        /// </summary>
        public void PerformOK()
        {
            try
            {
                SelectedFile = CurrentLocation.SubFiles.ElementAt(listDirectory.Items.IndexOf(listDirectory.SelectedItems[0]));
            }
            catch (IndexOutOfRangeException)
            {
                SelectedFile = null;
            }
            
            if (SelectedFile != null)
            {
                
                this.DialogResult = DialogResult.OK;
                Dispose();
            }
            else
            {
                MessageBox.Show(this, "No file selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Responds to the Cancel butto pressure, prepare the results for the owner form
        /// </summary>
        public void PerformCancel()
        {
            this.DialogResult = DialogResult.Cancel;
            Dispose();
        }

        #endregion DialogMethods

        
    }


}
