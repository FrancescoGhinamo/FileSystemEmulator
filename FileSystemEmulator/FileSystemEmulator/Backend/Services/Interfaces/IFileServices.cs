using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Services.Interfaces
{
    /// <summary>
    /// Interface containing methods to make <see cref="EFileSystem"/> and disk interact
    /// </summary>
    public interface IFileServices
    {
        /// <summary>
        /// Method to save the <see cref="EFileSystem"/> on fixed disk
        /// </summary>
        /// <param name="fs"><see cref="EFileSystem"/> to save on the disk</param>
        /// <param name="path">Destination path of the file</param>
        void SaveOnDisk(EFileSystem fs, string path);

        /// <summary>
        /// Mathod to retrieve an instance of <see cref="EFileSystem"/> from fixed disk
        /// </summary>
        /// <param name="path">Source path</param>
        /// <returns><see cref="EFileSystem"/> instance retrieved from disk</returns>
        EFileSystem LoadFromDisk(string path);
    }
}
