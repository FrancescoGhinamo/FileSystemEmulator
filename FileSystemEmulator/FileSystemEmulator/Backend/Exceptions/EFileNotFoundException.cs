using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Exceptions
{
    /// <summary>
    /// The looked <see cref="EFile"/> was not found
    /// </summary>
    public class EFileNotFoundException : Exception
    {
        /// <summary>
        /// Constructor, uses a default message for this exception
        /// </summary>
        public EFileNotFoundException() : base("File not found")
        {

        }
    }
}
