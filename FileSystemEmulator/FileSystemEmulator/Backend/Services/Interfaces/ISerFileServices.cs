using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooserDialog.FileSystemEmulator.Backend.Services.Interfaces
{
    /// <summary>
    /// Interface containing methods to make <see cref="IFileSystemImpl"/> and disk interact
    /// </summary>
    public interface ISerFileServices
    {
        /// <summary>
        /// Method to save the <see cref="IFileSystemImpl"/> on fixed disk
        /// </summary>
        /// <param name="fs"><see cref="IFileSystemImpl"/> to save on the disk</param>
        /// <param name="path">Destination path of the file</param>
        void SaveOnDisk(IFileSystemImpl fs, string path);

        /// <summary>
        /// Mathod to retrieve an instance of <see cref="IFileSystemImpl"/> from fixed disk
        /// </summary>
        /// <param name="path">Source path</param>
        /// <returns><see cref="IFileSystemImpl"/> instance retrieved from disk</returns>
        IFileSystemImpl LoadFromDisk(string path);
    }
}
