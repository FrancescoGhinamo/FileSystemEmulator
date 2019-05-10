using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooser.FileSystemEmulator.Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileChooser.FileSystemEmulator.Backend.Services.Implementations
{
    /// <summary>
    /// Implementation of the <see cref="IFileServices"/> interface
    /// </summary>
    public class FileServicesImpl : IFileServices
    {
        internal FileServicesImpl()
        {

        }

        /// <summary>
        /// Mathod to retrieve an instance of <see cref="FileSystemImpl"/> from fixed disk
        /// </summary>
        /// <param name="path">Source path</param>
        /// <returns><see cref="FileSystemImpl"/> instance retrieved from disk</returns>
        /// /// <exception cref="Exception">A problem occured while accessing the file system</exception>
        public FileSystemImpl LoadFromDisk(string path)
        {
            Stream openStream = null;
            FileSystemImpl ris = null;
            try
            {
                openStream = File.OpenRead(path);
                BinaryFormatter formatter = new BinaryFormatter();
                ris = (FileSystemImpl) formatter.Deserialize(openStream);
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
        /// Method to persist the <see cref="FileSystemImpl"/> on fixed disk
        /// </summary>
        /// <param name="fs"><see cref="FileSystemImpl"/> to save on the disk</param>
        /// <param name="path">Destination path of the file</param>
        
        public void SaveOnDisk(FileSystemImpl fs, string path)
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
