using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.Interfaces;
using FileSystemEmulator.FileSystemEmulator.Backend.Exceptions;
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
    public partial class FileSystemEmulatorGUI : Form
    {

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


        public FileSystemEmulatorGUI()
        {
            FileSystemInst = FileSystemFactory.GetFileSystem();
            CurrentLocation = FileSystemInst.GetRoot();
            InitializeComponent();
        }

        private void FileSystemEmulatorGUI_Load(object sender, EventArgs e)
        {
            
            UpdateDisplay();
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
                UpdateDisplay();
            }
            
        }

        private void btnSuperDir_Click(object sender, EventArgs e)
        {
            PerformGoToSuperDirecotory();
        }

        #endregion EventHandlers

        #region ActionMethods

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
                    UpdateDisplay();
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
                try
                {
                    EFile fetched = FileSystemInst.GetFile(path);
                    if (fetched.Directory)
                    {
                        CurrentLocation = fetched;
                        UpdateDisplay();
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
        #endregion ActionMethods

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
        /// Updates graphic info about current location
        /// </summary>
        public void UpdateDisplay()
        {
            UpdateList();
            UpdatePathTextArea();
        }




        #endregion DisplayMethods

      
    }

}
