using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.ByteFileEditor.Backend.Service
{
    /// <summary>
    /// General service for writing bytes on disk
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Writes the specified bytes on the fixed disk
        /// </summary>
        /// <param name="what">bytes to write</param>
        /// <param name="path">destination file</param>
        void WriteBytes(byte[] what, string path);
    }
}
