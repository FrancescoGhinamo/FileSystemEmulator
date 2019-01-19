﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Exceptions
{
    /// <summary>
    /// Exception thrown when there are no files available in the current process
    /// </summary>
    public class NoFilesException : Exception
    {
        /// <summary>
        /// Constructor with default message
        /// </summary>
        public NoFilesException() : base("No files available") { }
    }
}
