using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooserDialog.FileSystemEmulator.Backend.Exceptions
{
    /// <summary>
    /// Exception thrown if an <see cref="EFile"/> is beeing added to a directory that already contains a fie with the same name
    /// </summary>
    public class EFileNameAlreadyExistingException : EFileException
    {
        public EFileNameAlreadyExistingException() : base("A file with the same name already exists") { }
    }
}
