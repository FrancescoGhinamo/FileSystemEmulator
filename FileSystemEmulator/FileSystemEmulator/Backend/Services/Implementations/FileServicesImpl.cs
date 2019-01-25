using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileSystemEmulator.FileSystemEmulator.Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Services.Implementations
{
    /// <summary>
    /// Implementation of the <see cref="IFileServices"/> interface
    /// </summary>
    public class FileServicesImpl : IFileServices
    {
        /// <summary>
        /// Mathod to retrieve an instance of <see cref="EFileSystem"/> from fixed disk
        /// </summary>
        /// <param name="path">Source path</param>
        /// <returns><see cref="EFileSystem"/> instance retrieved from disk</returns>
        /// /// <exception cref="Exception">A problem occured while accessing the file system</exception>
        public EFileSystem LoadFromDisk(string path)
        {
            Stream openStream = null;
            EFileSystem ris = null;
            try
            {
                openStream = File.OpenRead(path);
                BinaryFormatter formatter = new BinaryFormatter();
                ris = (EFileSystem) formatter.Deserialize(openStream);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if(openStream != null)
                {
                    openStream.Close();
                }
            }
            return ris;

        }

        /// <summary>
        /// Method to persist the <see cref="EFileSystem"/> on fixed disk
        /// </summary>
        /// <param name="fs"><see cref="EFileSystem"/> to save on the disk</param>
        /// <param name="path">Destination path of the file</param>
        
        public void SaveOnDisk(EFileSystem fs, string path)
        {
            Stream saveStream = null;
            try
            {
                saveStream = File.Create(path);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(saveStream, path);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if(saveStream != null)
                {
                    saveStream.Close();
                }
                
            }

            
            
        }
    }
}
