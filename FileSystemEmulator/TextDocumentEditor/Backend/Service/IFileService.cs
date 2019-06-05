using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDocumentEditor.Backend.Service
{
    /// <summary>
    /// General service for writing bytes on disk
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Writes the specified string on the fixed disk
        /// </summary>
        /// <param name="what">string to write</param>
        /// <param name="path">destination file</param>
        void WriteString(string what, string path);

        /// <summary>
        /// Reads the content of a file as a string
        /// </summary>
        /// <param name="path">File to read</param>
        /// <returns>String contained in the file</returns>
        string ReadContent(string path);
    }
}
