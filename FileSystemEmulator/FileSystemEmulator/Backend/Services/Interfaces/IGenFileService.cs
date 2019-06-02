using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Services.Interfaces
{

    /// <summary>
    /// Provides general file service functionalities
    /// </summary>
    public interface IGenFileService
    {
        /// <summary>
        /// Reads the whole content of a file
        /// </summary>
        /// <param name="path">File to read</param>
        /// <returns>Content of the file as a byte[]</returns>
        byte[] ReadBytes(string path);

        /// <summary>
        /// Writes bytes to the specified file
        /// </summary>
        /// <param name="path">File to write on</param>
        /// <param name="cont">Bytes to write on the file</param>
        void WriteBytes(string path, byte[] cont);
    }
}
