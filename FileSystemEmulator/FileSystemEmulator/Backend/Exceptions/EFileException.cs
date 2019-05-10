using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooser.FileSystemEmulator.Backend.Exceptions
{
    /// <summary>
    /// General class for <see cref="EFileSystem"/> exception
    /// </summary>
    public abstract class EFileException : Exception
    {
        /// <summary>
        /// Constructor with from given message
        /// </summary>
        /// <param name="msg">Exception message</param>
        public EFileException(string msg) : base(msg) { }
    }
}
