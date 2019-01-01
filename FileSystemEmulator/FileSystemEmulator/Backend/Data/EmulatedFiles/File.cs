using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileList;
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
        public string Path { get; set; }

        /// <summary>
        /// Name assigned to the file, should be the same written at the end of the path
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
            this.Path = path;
            this.Directory = isDir;
            this.Name = Path.Substring(Path.LastIndexOf('\\') + 1);
            this.SubFiles = new FileList();

        }
        #endregion Constructor
    }
}
