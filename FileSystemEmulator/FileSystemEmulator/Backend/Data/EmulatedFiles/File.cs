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
    public abstract class File
    {
        #region PublicFields
        /// <summary>
        /// True if the file is a directory
        /// </summary>
        public bool Directory { get; }

        /// <summary>
        /// Path of the file: location in the file system
        /// </summary>
        public string Path {
            get
            {
                return ParentPath != null ? ParentPath + FileSystem.DIR_SEPARATOR + Name : Name;
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
        public FileList SubFiles { get; }

        #endregion PublicFields

        #region Constructor
        
        /// <summary>
        /// Constructor for a file
        /// </summary>
        /// <param name="path">Location in the file system</param>
        /// <param name="isDir">True if the file is a directory</param>
        public File (string path, bool isDir)
        {
            int sepI = 0;
            if((sepI = path.LastIndexOf(FileSystem.DIR_SEPARATOR)) != -1)
            {
                ParentPath = path.Substring(0, path.LastIndexOf(FileSystem.DIR_SEPARATOR));
                Name = path.Substring(path.LastIndexOf(FileSystem.DIR_SEPARATOR) + 1);
            }
            else
            {
                //it is a root...
                ParentPath = null;
                Name = path;
            }
            
            this.Directory = isDir;
            this.SubFiles = new FileList();

        }
        #endregion Constructor
    }
}
