using FileChooserDialog.FileSystemEmulator.Backend.Services.Implementations;
using FileChooserDialog.FileSystemEmulator.Backend.Services.Interfaces;
using FileSystemEmulator.FileSystemEmulator.Backend.Services.Implementations;
using FileSystemEmulator.FileSystemEmulator.Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooserDialog.FileSystemEmulator.Backend.Services.Implementations
{
    /// <summary>
    /// Factory class to provide file service functionalities
    /// </summary>
    public class FileServicesFactory
    {
        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Implementation of <see cref="ISerFileServices"/></returns>
        public static ISerFileServices GetSerFileServices()
        {
            return (ISerFileServices)new SerFileServicesImpl();
        }

        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Implementation of <see cref="IGenFileService"/></returns>
        public static IGenFileService GetGenFileServices()
        {
            return (IGenFileService)new GenFileServiceImpl();
        }
    }
}
