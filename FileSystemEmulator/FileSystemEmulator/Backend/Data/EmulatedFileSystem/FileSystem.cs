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
        /// <exception cref="IllegalParameterException">The file the method is attempting to add is not valid</exception>
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
        /// <exception cref="FileNotFoundException">The specified file path points to a file that doesn't exist</exception>
        public File GetFile(string path)
        {
            if(path.Equals("C:"))
            {
                return Root;
            }
            else
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
                catch (FileNotFoundException e)
                {
                    throw e;
                }
            }
            
           
        }

        /// <summary>
        /// Retrieves a file saved in the file system
        /// Invoked by other methods in this class
        /// If the specified file doesn't exist a FileNotFoundException is thrown
        /// </summary>
        /// <param name="rRoot">Relative root</param>
        /// <param name="sT">Segments of the path</param>
        /// <returns>Requested file</returns>
        /// <exception cref="FileNotFoundException">The specified file path points to a file that doesn't exist</exception>
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
                    CurrentLocation = CurrentLocation + DIR_SEPARATOR + token;
                    return GetFile(rRoot.SubFiles.ElementAt(subIndex), sT);
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            
        }
        #endregion RetrievingFileMethods

        #region ManagingFilesMethods

        /// <summary>
        /// Deletes and returns the file specified in the given path
        /// </summary>
        /// <param name="path">Path reference to the file</param>
        /// <returns>Deleted file</returns>
        /// <exception cref="FileNotFoundException">The chosen file doesn't exist</exception>
        public File DeleteFile(string path)
        {
            File _deleted = null;
            try
            {
                //getting the file, I update the location to the parent folder
                _deleted = GetFile(path);
                File parent = GetFile(CurrentLocation);
                //remove the file from the sub files of this parent
                parent.SubFiles.Remove(_deleted);
            }
            catch (FileNotFoundException e)
            {

                throw e;
            }

            return _deleted;
        }



        /// <summary>
        /// Copies a file to another location in the file system
        /// </summary>
        /// <param name="sourcePath">Source file</param>
        /// <param name="destinationPath">Destination location, must contain the file name in the destination</param>
        /// <exception cref="FileNotFoundException">The specified source file doesn't exist</exception>
        public void CopyFile(string sourcePath, string destinationPath)
        {
            try
            {
                File _source = GetFile(sourcePath);
                //update of file path and name
                _source.Path = destinationPath;
                _source.Name = destinationPath.Substring(destinationPath.LastIndexOf("\\") + 1);
                this.Add(_source);
            }
            catch(FileNotFoundException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Moves a file from a location to another
        /// </summary>
        /// <param name="sourcePath">Source file</param>
        /// <param name="destinationPath">Destination location, must contain the file name in the destination</param>
        /// <exception cref="FileNotFoundException">The specified source file doesn't exist</exception>
        public void MoveFile(string sourcePath, string destinationPath)
        {
            try
            {
                File _source = DeleteFile(sourcePath);
                //update of file path and name
                _source.Path = destinationPath;
                _source.Name = destinationPath.Substring(destinationPath.LastIndexOf("\\") + 1);
                this.Add(_source);
            }
            catch(FileNotFoundException e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Renames the specified file
        /// </summary>
        /// <param name="file">Chosen file</param>
        /// <param name="newName">New name to assign to the file</param>
        /// <exception cref="FileNotFoundException">The specified source file doesn't exist</exception>
        public void RenameFile(string file, string newName)
        {
            try
            {
                File _f = DeleteFile(file);
                _f.Name = newName;
                string _path = _f.Path;
                _path = _path.Substring(0, _path.LastIndexOf("\\") + 1) + newName;
                _f.Path = _path;
                Add(_f);
            }
            catch(FileNotFoundException e)
            {
                throw e;
            }
        }
        #endregion ManagingFilesMethods
    }
}
