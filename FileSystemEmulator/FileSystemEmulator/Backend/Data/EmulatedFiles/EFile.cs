using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileList;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooserDialog.FileSystemEmulator.Backend.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles
{
    /// <summary>
    /// Abstract file writable in the emulated file system
    /// </summary>
    [Serializable]
    public abstract class EFile
    {
        #region PublicFields
        /// <summary>
        /// True if the file is a directory
        /// </summary>
        public bool Directory { get; }

        /// <summary>
        /// Extension of the file
        /// </summary>
        public string Extension
        {
            get
            {
                return Name.Substring(Name.LastIndexOf(".") + 1);
            }
        }

        /// <summary>
        /// Path of the file: location in the file system
        /// </summary>
        public string Path {
            get
            {
                return ParentPath != null ? ParentPath + FileSystemImpl.DIR_SEPARATOR + Name : Name;
            }
        }

        /// <summary>
        /// Path of the parent file
        /// </summary>
        public string ParentPath { get; set; }

        /// <summary>
        /// Name assigned to the file, contains the extension
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of the paths of all the subfiles
        /// </summary>
        public PathList SubPaths
        {
            get
            {
                PathList _ris = new PathList();
                //if it's not a root
                if(ParentPath != null)
                {
                    _ris.Add(this.Path);
                }
                

                foreach (EFile f in SubFiles)
                {
                    _ris.AddRange(f.SubPaths);
                }
                return _ris;
            }
        }

        /// <summary>
        /// List of the sub files related to this file
        /// </summary>
        public EFileList SubFiles { get; }

        #endregion PublicFields

        #region Constructor
        
        /// <summary>
        /// Constructor for a file
        /// </summary>
        /// <param name="pathAndName">Location in the file system (containing file name and extension</param>
        /// <param name="isDir">True if the file is a directory</param>
        public EFile (string pathAndName, bool isDir)
        {
            int sepI = 0;
            if((sepI = pathAndName.LastIndexOf(FileSystemImpl.DIR_SEPARATOR)) != -1)
            {
                ParentPath = pathAndName.Substring(0, pathAndName.LastIndexOf(FileSystemImpl.DIR_SEPARATOR));
                Name = pathAndName.Substring(pathAndName.LastIndexOf(FileSystemImpl.DIR_SEPARATOR) + 1);
            }
            else
            {
                //it is a root...
                ParentPath = null;
                Name = pathAndName;
            }
            
            this.Directory = isDir;
            this.SubFiles = new EFileList();

        }


        /// <summary>
        /// Constructorf for a File
        /// </summary>
        /// <param name="parent">Parent file path (can be the path of the parent folder), null if the file is a root</param>
        /// <param name="name">File name</param>
        /// <param name="isDir">True if the file is a directory</param>
        public EFile (string parent, string name, bool isDir)
        {
            this.ParentPath = parent;
            this.Directory = isDir;
            this.SubFiles = new EFileList();
        }
        #endregion Constructor

        #region MaintenanceMethods

        /// <summary>
        /// Creates a copy of the current <see cref="EFile"/>
        /// </summary>
        /// <returns>Returs a proper copy of the current <see cref="EFile"/></returns>
        public abstract EFile GetCopy();


        /// <summary>
        /// Updates the path of the sub files to meet the position in file system
        /// Useful after copying, moving or renaming a file
        /// </summary>
        public void UpdateSubFilesPath()
        {
            foreach(EFile f in SubFiles)
            {
                f.ParentPath = this.Path;
            }

            foreach(EFile f in SubFiles)
            {
                f.UpdateSubFilesPath();
            }
        }

        #endregion MaintenanceMethods

        #region InterfaceMethods

        public new string ToString()
        {
            string res = "";
            res = Name;
            return res;
        }


        /// <summary>
        /// Returns nodes for current file and subfiles
        /// </summary>
        /// <returns>Node for graphic rendering</returns>
        public TreeNode GetTreeNodes()
        {
            TreeNode me = new TreeNode(this.Name);
            foreach(EFile f in SubFiles)
            {
                me.Nodes.Add(f.GetTreeNodes());
            }
            return me;
        }

        #endregion InterfaceMethods

    }
}
