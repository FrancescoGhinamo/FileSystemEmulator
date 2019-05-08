using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteFileEditor.ByteFileEditor.Backend.Exceptions
{
    /// <summary>
    /// Exception thrown if the type of a file doesnt match the one the program can open
    /// </summary>
    public class TypeMismatchException : Exception
    {
        /// <summary>
        /// Construcotr with default message
        /// </summary>
        public TypeMismatchException() : base("File type mismatch") {}
    }
}
