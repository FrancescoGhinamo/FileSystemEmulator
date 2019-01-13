using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileList;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles
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
                return ParentPath != null ? ParentPath + EFileSystem.DIR_SEPARATOR + Name : Name;
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
            if((sepI = pathAndName.LastIndexOf(EFileSystem.DIR_SEPARATOR)) != -1)
            {
                ParentPath = pathAndName.Substring(0, pathAndName.LastIndexOf(EFileSystem.DIR_SEPARATOR));
                Name = pathAndName.Substring(pathAndName.LastIndexOf(EFileSystem.DIR_SEPARATOR) + 1);
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
    }
}
