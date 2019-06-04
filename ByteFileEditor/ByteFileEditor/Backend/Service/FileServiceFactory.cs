using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.ByteFileEditor.Backend.Service
{
    /// <summary>
    /// Container for <see cref="IFileService"/> factory methods
    /// </summary>
    public class FileServiceFactory
    {
        /// <summary>
        /// Returns the <see cref="IFileService"/>
        /// </summary>
        /// <returns><see cref="IFileService"/> instance</returns>
        public static IFileService getFileService()
        {
            return (IFileService)new FileServiceImpl();
        }
    }
}
