using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileSystemEmulator.FileSystemEmulator.Backend.Exceptions;
using FileSystemEmulator.FileSystemEmulator.Backend.Factories;
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
        /// Location the currently browsing
        /// </summary>
        private EFile CurrentLocation;

        #endregion PrivateFields


        public FileSystemEmulatorGUI()
        {
            InitializeComponent();
        }

        private void FileSystemEmulatorGUI_Load(object sender, EventArgs e)
        {
            CurrentLocation = FileSystemFactory.GetFileSystem().GetRoot();
            UpdateList();
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
                EFile fetched = FileSystemFactory.GetFileSystem().GetFile(path);
                if (fetched.GetType().Equals(typeof(EDirectory)))
                {
                    CurrentLocation = fetched;
                    UpdateList();
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
        #endregion ActionMethods

        #region DisplayMethods

        /// <summary>
        /// Updates the content of the list according to the <see cref="CurrentLocation"/>
        /// </summary>
        public void UpdateList()
        {
            listDirectory.Clear();
            foreach(EFile f in CurrentLocation.SubFiles)
            {
                listDirectory.Items.Add(f.ToString());
            }
        }
        #endregion DisplayMethods


    }

}
