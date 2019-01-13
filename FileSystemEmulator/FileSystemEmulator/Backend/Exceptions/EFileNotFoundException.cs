using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Exceptions
{
    public class EFileNotFoundException : Exception
    {
        public EFileNotFoundException() : base("File not found")
        {

        }
    }
}
