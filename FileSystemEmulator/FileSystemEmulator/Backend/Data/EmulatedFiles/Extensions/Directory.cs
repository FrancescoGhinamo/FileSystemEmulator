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
        public Directory(string path) : base(path, true)
        {

        }
        #endregion Constructor
    }
}
