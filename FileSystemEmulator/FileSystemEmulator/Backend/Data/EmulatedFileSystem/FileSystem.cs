using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileSystemEmulator.FileSystemEmulator.Backend.Exceptions;
using FileSystemEmulator.FileSystemEmulator.Backend.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem
{
    /// <summary>
    /// File system emulation, with methods to access the file system
    /// Singleton class, only the same instance of this object can be used in the program
    /// </summary>
    public class FileSystem
    {

        #region Singleton
        private static FileSystem SingletonFileSystem;

        public static FileSystem GetInstance()
        {
            if(SingletonFileSystem == null)
            {
                //if this objecy hasn't been instances yet, I instance it here
                SingletonFileSystem = new FileSystem();
            }
            //return the instance
            return SingletonFileSystem;
        }

        #endregion Singleton


        #region Constants
        /// <summary>
        /// Directory separator
        /// </summary>
        public const char DIR_SEPARATOR = '\\';
        #endregion Constants

        #region PublicFields
        /// <summary>
        /// Root dir of the file system
        /// </summary>
        public Directory Root { get; }

        #endregion PublicFields

        #region PrivateFields
        /// <summary>
        /// Location the methods are accessing
        /// </summary>
        private string CurrentLocation { get; set; }


        #endregion PrivateFields

        #region Constructor

        /// <summary>
        /// Default constructor, the root dir is C:
        /// </summary>
        private FileSystem()
        { 
            Root = new Directory("C:");
        }
        #endregion Constructor

        #region AddingFileMethods

        /// <summary>
        /// Adds the specified file to the file system
        /// </summary>
        /// <param name="f">File to add</param>
        public void Add(File f)
        {
            //I begin adding file from C: directory
            CurrentLocation = "C:";
            StringTokenizer sT = new StringTokenizer(f.Path, DIR_SEPARATOR);
            //to exclude the C: token
            sT.NextToken();

            Add(f, Root, sT);
        }

        /// <summary>
        /// Adds the file to the file system
        /// IllegalParatemeterException can be thrown if the file f is null
        /// </summary>
        /// <param name="f">File to add</param>
        /// <param name="rRoot">Relative root</param>
        /// <param name="sT">Segments of the path</param>
        private void Add(File f, File rRoot, StringTokenizer sT)
        {
            //tokens and position in the file system proceed the same way
            string token = sT.NextToken();
            if (token.Equals(f.Name))
            {
                //if the I reached the position I add the file
                try
                {
                    rRoot.SubFiles.Add(f);
                }
                catch(IllegalParameterException e)
                {
                    throw e;
                }
                
            }
            else
            {
                int subDir;
                if((subDir = rRoot.SubFiles.IndexOfFileName(token)) == -1)
                {
                    //if the nestled dir doesn't exist, I creae it
                    rRoot.SubFiles.Add(new Directory(CurrentLocation + DIR_SEPARATOR + token));
                }
                //update the current location
                CurrentLocation = CurrentLocation + DIR_SEPARATOR + token;
                //I add the file in the nestled folder, recoursively
                Add(f, rRoot.SubFiles.ElementAt(rRoot.SubFiles.IndexOfFileName(token)), sT);
            }

        }
        #endregion AddingFileMethods


        #region RetrievingFileMethods

        /// <summary>
        /// Retrieves a file saved in the file system
        /// If the specified file doesn't exist a FileNotFoundException is thrown
        /// </summary>
        /// <param name="path">Path to look for</param>
        /// <returns>File indentified by the path</returns>
        public File GetFile(string path)
        {
            StringTokenizer sT = new StringTokenizer(path, DIR_SEPARATOR);
            //exclude the first token (C:)
            sT.NextToken();
            //I begin from dir C:
            CurrentLocation = "C:";
            try
            {
                return GetFile(Root, sT);
            }
            catch(FileNotFoundException e)
            {
                throw e;
            }
           
        }

        /// <summary>
        /// Retrieves a file saved in the file system
        /// Invoked by other methods in this class
        /// If the specified file doesn't exist a FileNotFoundException is thrown
        /// </summary>
        /// <param name="rRoot">Relative root</param>
        /// <param name="sT">Segments of the path</param>
        /// <returns></returns>
        private File GetFile(File rRoot, StringTokenizer sT)
        {
            string token = sT.NextToken();
            int subIndex = 0;
            if((subIndex = rRoot.SubFiles.IndexOfFileName(token)) != -1)
            {
                //if the sub file exists
                if(!sT.HasMoreTokens())
                {
                    //if I reaced the last file name
                    return rRoot.SubFiles.ElementAt(subIndex);
                }
                else
                {
                    //I explore the next subfolder
                    //update the current location
                    CurrentLocation += token;
                    return GetFile(rRoot.SubFiles.ElementAt(subIndex), sT);
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            
        }
        #endregion RetrievingFileMethods
    }
}
