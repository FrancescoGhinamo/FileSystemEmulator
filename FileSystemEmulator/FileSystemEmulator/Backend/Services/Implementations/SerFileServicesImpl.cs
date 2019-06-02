using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooserDialog.FileSystemEmulator.Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileChooserDialog.FileSystemEmulator.Backend.Services.Implementations
{
    /// <summary>
    /// Implementation of the <see cref="ISerFileServices"/> interface
    /// </summary>
    public class SerFileServicesImpl : ISerFileServices
    {
        internal SerFileServicesImpl()
        {

        }

        /// <summary>
        /// Mathod to retrieve an instance of <see cref="IFileSystemImpl"/> from fixed disk
        /// </summary>
        /// <param name="path">Source path</param>
        /// <returns><see cref="IFileSystemImpl"/> instance retrieved from disk</returns>
        /// /// <exception cref="Exception">A problem occured while accessing the file system</exception>
        public IFileSystemImpl LoadFromDisk(string path)
        {
            Stream openStream = null;
            IFileSystemImpl ris = null;
            try
            {
                openStream = File.OpenRead(path);
                BinaryFormatter formatter = new BinaryFormatter();
                ris = (IFileSystemImpl) formatter.Deserialize(openStream);
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
        /// Method to persist the <see cref="IFileSystemImpl"/> on fixed disk
        /// </summary>
        /// <param name="fs"><see cref="IFileSystemImpl"/> to save on the disk</param>
        /// <param name="path">Destination path of the file</param>
        
        public void SaveOnDisk(IFileSystemImpl fs, string path)
        {
            Stream saveStream = null;
            try
            {
                saveStream = File.Create(path);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(saveStream, fs);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if(saveStream != null)
                {
                    try
                    {
                        saveStream.Flush();
                    }
                    catch (IOException) { }
                    finally
                    {
                        saveStream.Close();
                    }                    
                    
                }
                
            }

            
            
        }
    }
}
