using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException() : base("File not found")
        {

        }
    }
}
