using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooserDialog.FileSystemEmulator.Backend.Services.Interfaces
{
    /// <summary>
    /// Interface containing methods to make <see cref="FileSystemImpl"/> and disk interact
    /// </summary>
    public interface ISerFileServices
    {
        /// <summary>
        /// Method to save the <see cref="FileSystemImpl"/> on fixed disk
        /// </summary>
        /// <param name="fs"><see cref="FileSystemImpl"/> to save on the disk</param>
        /// <param name="path">Destination path of the file</param>
        void SaveOnDisk(FileSystemImpl fs, string path);

        /// <summary>
        /// Mathod to retrieve an instance of <see cref="FileSystemImpl"/> from fixed disk
        /// </summary>
        /// <param name="path">Source path</param>
        /// <returns><see cref="FileSystemImpl"/> instance retrieved from disk</returns>
        FileSystemImpl LoadFromDisk(string path);
    }
}
