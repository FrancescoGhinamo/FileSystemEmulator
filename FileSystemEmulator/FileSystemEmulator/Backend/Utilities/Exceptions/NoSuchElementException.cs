using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Utilities.Exceptions
{
    /// <summary>
    /// The requested datum was not found
    /// </summary>
    public class NoSuchElementException : Exception
    {
        /// <summary>
        /// Constructor with default message
        /// </summary>
        public NoSuchElementException() : base("The requested datum was not found")
        {

        }

    }
}
