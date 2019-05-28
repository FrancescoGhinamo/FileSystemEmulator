using ByteFileEditor.Frontend.GUI.MainForm;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooser.FileSystemEmulator.Backend.Data.Interfaces;
using FileChooser.FileSystemEmulator.Backend.Exceptions;
using FileChooser.FileSystemEmulator.Frontend.GUI.FileDialog;
using FileChooser.FileSystemEmulator.Frontend.GUI.FileDialogs;
using FileChooser.FileSystemEmulator.Frontend.GUI.FileSystemDialogs;
using FileSystemEmulator.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChooser
{
    /// <summary>
    /// Main form of the application
    /// </summary>
    public partial class FileSystemExplorerGUI : Form, IObserver
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


        #region Construnctor
        /// <summary>
        /// GUI Constructor
        /// </summary>
        /// <param name="args">Launching parameters (file to open)</param>
        public FileSystemExplorerGUI(string[] args)
        {
            FileSystemInst = FileSystemFactory.GetFileSystem();
            FileSystemInst.AddObserver(this);
            //FileSystemInst.AddObserver(this);
            CurrentLocation = FileSystemInst.GetRoot();
            CurrentFile = "";
            InitializeComponent();
            if(args != null && args.Length > 0)
            {
                OpenFile(args[0]);
            }
        }

        private void FileSystemEmulatorGUI_Load(object sender, EventArgs e)
        {

            UpdateWholeDisplay();
        }

        #endregion Constructor

        #region EventHandlers
        private void listDirectory_SelectedIndexChanged(object sender, EventArgs e)
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




        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformOpen();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformSave();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformSaveAs();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformExit();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void eDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformCreateEDirectory();
                //UpdateWholeDisplay();
            }
            catch (EFileNameAlreadyExistingException exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void byteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformCreateEByteFile();
                //UpdateWholeDisplay();
            }
            catch (EFileNameAlreadyExistingException exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformCopyFile();
                //UpdateWholeDisplay();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformMoveFile();
                //UpdateWholeDisplay();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformRenameFile();
                //UpdateWholeDisplay();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformDeleteFile();
                //UpdateWholeDisplay();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformFormat();
            //UpdateWholeDisplay();
        }

        private void attemptRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PerformAttemptRecovery();
                //UpdateWholeDisplay();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void EByteFileEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchEByteFileEditor();
            //UpdateWholeDisplay();
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
                    OpenEFile(fetched);
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
                            OpenEFile(fetched);
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
        /// Provides functionality to open an <see cref="EFile"/> with the specifies program
        /// </summary>
        /// <param name="fetched">Requested file</param>
        public void OpenEFile(EFile fetched)
        {
            switch (fetched.Extension)
            {
                case EByteFileDialog.EXTENSION:
                    string[] param = new string[1];
                    param[0] = fetched.Path;
                    new ByteFileEditorForm(param).Show(this);
                    break;

                //add other cases for the other types of file

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

        /// <summary>
        /// Allows the user to create an <see cref="EByteFile"/> displaying the relative dialog
        /// </summary>
        /// <exception cref="EFileNameAlreadyExistingException">A file with the same name already exists</exception>
        public void PerformCreateEByteFile()
        {
            EByteFileDialog fD = new EByteFileDialog(CurrentLocation.Path);
            if (fD.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileSystemInst.Add(fD.byteFile);
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

        #region FileSystemManagingMethods

        /// <summary>
        /// Formats the current file system
        /// </summary>
        public void PerformFormat()
        {
            FormatFileSystemDialog fD = new FormatFileSystemDialog();
            if(fD.ShowDialog(this) == DialogResult.OK)
            {
                FileSystemInst.Format(fD.KeepCopy);
            }
        }

        /// <summary>
        /// Attempts to recover the file system after the format from a saved temporary copy, if available
        /// </summary>
        /// <exception cref="NoFilesException">Thrown if there are no files in the recovery data</exception>
        public void PerformAttemptRecovery()
        {

            DialogResult res = MessageBox.Show(this, "Overwright the current file sytem?", "File system recovery", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            bool overwright = false;
            switch (res)
            {
                case DialogResult.Yes:
                    overwright = true;
                    break;

                case DialogResult.No:
                    overwright = false;
                    break;

                case DialogResult.Cancel:
                    return;
            }
            try
            {
                FileSystemInst.AttemptRecovery(overwright);
            }
            catch(NoFilesException e)
            {
                throw e;
            }
            
        }

        #endregion FileSystemManagingMethods

        #region DisplayMethods

        /// <summary>
        /// Updates the content of the list according to the <see cref="CurrentLocation"/>
        /// </summary>
        public void UpdateList()
        {
            listDirectory.Items.Clear();
            foreach(EFile f in CurrentLocation.SubFiles)
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

        #region Observer

        /// <summary>
        /// <see cref="IObserver"/>
        /// </summary>
        /// <param name="s"><see cref="IObserver"/></param>
        /// <param name="obj"><see cref="IObserver"/></param>
        public void Update(Subject s, object obj)
        {
            if(s.Equals(FileSystemInst))
            {
                string msg = (string)obj;
                msg = msg.ToLower();
                if (msg.Contains("whole"))
                {
                    UpdateWholeDisplay();
                }

                if (msg.Contains("basic"))
                {
                    UpdateBasicExplorerGraphics();
                }
            }

        }
        #endregion Observer

        #region FileService

        /// <summary>
        /// Initializes the file chooser to open a file
        /// </summary>
        /// <returns></returns>
        public OpenFileDialog InitOpenFileDialog()
        {
            OpenFileDialog res = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = DEFAULT_EXT,
                Filter = "Emulated File System file (*.efs)|*." + DEFAULT_EXT
                
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
                DefaultExt = DEFAULT_EXT,
                Filter = "Emulated File System file (*.efs)|*." + DEFAULT_EXT

            };
            return res;
        }

        /// <summary>
        /// Open a serialization of a file system object
        /// </summary>
        /// <exception cref="Exception">Thrown in case of file errors</exception>
        public void PerformOpen()
        {
            if (FSModified)
            {
                DialogResult ans = MessageBox.Show(this, "File System has changed\nSave changes?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (ans)
                {
                    case DialogResult.Yes:
                        try
                        {
                            PerformSave();
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        return;
                }
            }

            OpenFileDialog dOpen = InitOpenFileDialog();
            if (dOpen.ShowDialog().Equals(DialogResult.OK))
            {
                OpenFile(dOpen.FileName);
                /*CurrentFile = dOpen.FileName;
                try
                {
                    FileSystemInst = FileSystemInst.DeserializeFileSystem(CurrentFile);
                    CurrentLocation = FileSystemInst.GetRoot();
                    UpdateWholeDisplay();
                }
                catch (Exception e)
                {
                    throw e;
                }*/
            }

        }

        /// <summary>
        /// Opens the specified file and loads the correspondant file system
        /// </summary>
        /// <param name="fileName">File to open</param>
        private void OpenFile(string fileName)
        {
            CurrentFile = fileName;
            try
            {
                FileSystemInst = FileSystemInst.DeserializeFileSystem(CurrentFile);
                CurrentLocation = FileSystemInst.GetRoot();
                UpdateWholeDisplay();
            }
            catch (Exception) { }
            
        }

        /// <summary>
        /// Saves the current instance on the disk, if the file hasn't been chosen yet, the <see cref="PerformSaveAs"/> method is called
        /// </summary>
        /// <exception cref="Exception">Exception thrown in case of an error during persistation</exception>
        public void PerformSave()
        {
            if(CurrentFile.Equals(""))
            {
                try
                {
                    PerformSaveAs();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            try
            {
                FileSystemInst.SerializeFileSystem(CurrentFile);
                FSModified = false;
            }
            catch (Exception e)
            {
                throw e;
            }
            

        }

        /// <summary>
        /// Saves the current instance on the disk, choosing the file destination
        /// </summary>
        /// <exception cref="Exception">Exception thrown in case of an error during persistation</exception>
        public void PerformSaveAs()
        {
            SaveFileDialog dSave = InitSaveFileDialog();
            if(dSave.ShowDialog().Equals(DialogResult.OK))
            {
                CurrentFile = dSave.FileName;
                try
                {
                    PerformSave();
                    FSModified = false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            

        }

        /// <summary>
        /// Exits the program, checking for file changes
        /// </summary>
        /// <exception cref="Exception">Thrown in case of file problem</exception>
        public void PerformExit()
        {
            if (FSModified)
            {
                DialogResult ans = MessageBox.Show(this, "File System has changed\nSave changes?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (ans)
                {
                    case DialogResult.Yes:
                        try
                        {
                            PerformSave();
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        return;
                }
            }
            Environment.Exit(0);
        }











        #endregion FileService

        #region ExtPrograms

        /// <summary>
        /// Launches an instance of <see cref="ByteFileEditorForm"/>
        /// </summary>
        public void LaunchEByteFileEditor()
        {
            new ByteFileEditorForm(null).Show(this);
            UpdateWholeDisplay();      
            
        }

        
        #endregion ExtPrograms


    }

}