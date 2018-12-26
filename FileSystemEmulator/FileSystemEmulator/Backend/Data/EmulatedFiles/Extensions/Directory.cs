using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions
{
    /// <summary>
    /// Extension of class File, this file is a standard directory
    /// </summary>
    public class Directory : File
    {
        #region Constructor

        /// <summary>
        /// Basic constructor to define a general directory
        /// </summary>
        /// <param name="path">Location in the file system</param>
        /// <param name="name">Name of the directory</param>
        public Directory(string path, string name) : base(path, true, name)
        {

        }
        #endregion Constructor
    }
}
