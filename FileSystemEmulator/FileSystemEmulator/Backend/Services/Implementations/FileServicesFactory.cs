using FileChooserDialog.FileSystemEmulator.Backend.Services.Implementations;
using FileChooserDialog.FileSystemEmulator.Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooserDialog.FileSystemEmulator.Backend.Services.Implementations
{
    /// <summary>
    /// Factory class to provide file <see cref="IFileServices"/> functionalities
    /// </summary>
    public class FileServicesFactory
    {
        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Implementation of <see cref="IFileServices"/></returns>
        public static IFileServices GetFileServices()
        {
            return (IFileServices)new FileServicesImpl();
        }
    }
}
