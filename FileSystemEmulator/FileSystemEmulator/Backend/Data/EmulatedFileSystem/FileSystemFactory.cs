using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem
{
    /// <summary>
    /// Factory class for the File System
    /// </summary>
    public class FileSystemFactory
    {
        /// <summary>
        /// File system factory getter
        /// </summary>
        /// <returns>Instance of <see cref="FileSystemImpl"/> casted to <see cref="IFileSystem"/></returns>
        public static IFileSystem GetFileSystem()
        {
            return (IFileSystem) FileSystemImpl.GetInstance();
        }
    }
}
