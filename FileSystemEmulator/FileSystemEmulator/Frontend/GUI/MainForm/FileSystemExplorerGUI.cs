﻿using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.Interfaces;
using FileSystemEmulator.FileSystemEmulator.Backend.Exceptions;
using FileSystemEmulator.FileSystemEmulator.Frontend.GUI.EDirectoryDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemEmulator
{
    /// <summary>
    /// Main form of the application
    /// </summary>
    public partial class FileSystemExplorerGUI : Form
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


        public FileSystemExplorerGUI()
        {
            FileSystemInst = FileSystemFactory.GetFileSystem();
            CurrentLocation = FileSystemInst.GetRoot();
            CurrentFile = "";
            InitializeComponent();
        }

        private void FileSystemEmulatorGUI_Load(object sender, EventArgs e)
        {
            
            UpdateWholeDisplay();
        }

        #region EventHandlers
        private void listDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PerformClickOnList(CurrentLocation.SubFiles.ElementAt(listDirectory.Items.IndexOf(listDirectory.SelectedItems[0])).Path);
            }
            catch(EFileNotFoundException exc)
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
                UpdateWholeDisplay();
            }
            catch(EFileNameAlreadyExistingException exc)
            {
                MessageBox.Show(this, exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        #endregion EventHandlers

        #region BrowsingMethods

        /// <summary>
        /// Enters a specified <see cref="EDirectory"/>
        /// If the selection is not a directory, the file is opened
        /// </summary>
        /// <param name="path"></param>
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
                    //open the file
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
            if(!path.Equals(""))
            {
                //remove extra slashes
                while(path.EndsWith("\\"))
                {
                    path = path.Substring(0, path.LastIndexOf("\\"));
                }

                try
                {
                    EFile fetched = FileSystemInst.GetFile(path);
                    if(fetched != null)
                    {
                        if (fetched.Directory)
                        {
                            CurrentLocation = fetched;
                        }
                        else
                        {
                            //open the file
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
        /// Alloes the user to create an <see cref="EDirectory"/> displaying the relative dialog
        /// </summary>
        /// <exception cref="EFileNameAlreadyExistingException">A dir with the same name already exists</exception>
        public void PerformCreateEDirectory()
        {
            EDirectoryDialog dirD = new EDirectoryDialog(CurrentLocation.Path);
            if(dirD.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileSystemInst.Add(new EDirectory(dirD.GenPath));
                }
                catch(EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
                
            }
        }
        #endregion FileCreationsMethods

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
                CurrentFile = dOpen.FileName;
                try
                {
                    FileSystemInst = FileSystemInst.DeserializeFileSystem(CurrentFile);
                    CurrentLocation = FileSystemInst.GetRoot();
                    UpdateWholeDisplay();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

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

        
    }

}
