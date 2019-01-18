using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileList;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileSystemEmulator.FileSystemEmulator.Backend.Exceptions;
using FileSystemEmulator.FileSystemEmulator.Backend.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem
{
    /// <summary>
    /// File system emulation, with methods to access the file system
    /// Singleton class, only the same instance of this object can be used in the program
    /// </summary>
    [Serializable]
    public class EFileSystem
    {

        #region Singleton
        private static EFileSystem SingletonFileSystem;

        public static EFileSystem GetInstance()
        {
            if (SingletonFileSystem == null)
            {
                //if this objecy hasn't been instances yet, I instance it here
                SingletonFileSystem = new EFileSystem();
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
        public EDirectory Root { get; }

        /// <summary>
        /// Used path in the file system
        /// </summary>
        public PathList PathsList
        {
            get
            {
                return Root.SubPaths;
            }
        }

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
        private EFileSystem()
        { 
            Root = new EDirectory("C:");
        }
        #endregion Constructor

        #region AddingFileMethods

        /// <summary>
        /// Adds the specified file to the file system
        /// </summary>
        /// <param name="f">File to add</param>
        public void Add(EFile f)
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
        private void Add(EFile f, EFile rRoot, StringTokenizer sT)
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
                catch (IllegalParameterException e)
                {
                    throw e;
                }
                
            }
            else
            {
                int subDir;
                if ((subDir = rRoot.SubFiles.IndexOfFileName(token)) == -1)
                {
                    //if the nestled dir doesn't exist, I creae it
                    EDirectory dir = new EDirectory(CurrentLocation + DIR_SEPARATOR + token);
                    rRoot.SubFiles.Add(dir);
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
        /// <exception cref="EFileNotFoundException">The specified file path points to a file that doesn't exist</exception>
        public EFile GetFile(string path)
        {
            if (path.Equals("C:"))
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
                catch (EFileNotFoundException e)
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
        /// <exception cref="EFileNotFoundException">The specified file path points to a file that doesn't exist</exception>
        private EFile GetFile(EFile rRoot, StringTokenizer sT)
        {
            string token = sT.NextToken();
            int subIndex = 0;
            if ((subIndex = rRoot.SubFiles.IndexOfFileName(token)) != -1)
            {
                //if the sub file exists
                if (!sT.HasMoreTokens())
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
                throw new EFileNotFoundException();
            }
            
        }
        #endregion RetrievingFileMethods

        #region ManagingFilesMethods

        /// <summary>
        /// Deletes and returns the file specified in the given path
        /// </summary>
        /// <param name="path">Path reference to the file</param>
        /// <returns>Deleted file</returns>
        /// <exception cref="EFileNotFoundException">The chosen file doesn't exist</exception>
        public EFile DeleteFile(string path)
        {
            EFile _deleted = null;
            try
            {
                //getting the file, I update the location to the parent folder
                _deleted = GetFile(path);
                EFile parent = GetFile(CurrentLocation);
                //remove the file from the sub files of this parent
                parent.SubFiles.Remove(_deleted);
            }
            catch (EFileNotFoundException e)
            {

                throw e;
            }

            return _deleted;
        }


        
        /// <summary>
        /// Copies a file to another location in the file system
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationFile">Destination location, must contain the file name in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        public void CopyFile(string sourceFile, string destinationFile)
        {
            try
            {
                EFile _source = GetFile(sourceFile);
                //update of file path and name
                _source.ParentPath = destinationFile.Substring(0, destinationFile.LastIndexOf(DIR_SEPARATOR) + 1);
                _source.Name = destinationFile.Substring(destinationFile.LastIndexOf(DIR_SEPARATOR) + 1);
                this.Add(_source);
            }
            catch(EFileNotFoundException e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Copies a file to another location in the file system
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationPath">New parent of the file (should be a Directory)</param>
        /// <param name="destinationName">Name of the file in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        public void CopyFile(string sourceFile, string destinationPath, string destinationName)
        {
            try
            {
                EFile _source = GetFile(sourceFile);
                //update of file path and name
                _source.ParentPath = destinationPath;
                _source.Name = destinationName;
                this.Add(_source);
            }
            catch (EFileNotFoundException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Moves a file from a location to another
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationFile">Destination location, must contain the file name in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        public void MoveFile(string sourceFile, string destinationFile)
        {
            try
            {
                EFile _source = DeleteFile(sourceFile);
                //update of file path and name
                _source.ParentPath = destinationFile.Substring(0, destinationFile.LastIndexOf(DIR_SEPARATOR));
                _source.Name = destinationFile.Substring(destinationFile.LastIndexOf(DIR_SEPARATOR) + 1);
                this.Add(_source);
            }
            catch(EFileNotFoundException e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Moves a file from a location to another
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationPath">New parent of the file (should be a Directory)</param>
        /// <param name="destinationName">Name of the file in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        public void MoveFile(string sourceFile, string destinationPath, string destinationName)
        {
            try
            {
                EFile _source = DeleteFile(sourceFile);
                //update of file path and name
                _source.ParentPath = destinationPath;
                _source.Name = destinationName;
                this.Add(_source);
            }
            catch (EFileNotFoundException e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Renames the specified file
        /// </summary>
        /// <param name="file">Chosen file</param>
        /// <param name="newName">New name to assign to the file</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        public void RenameFile(string file, string newName)
        {
            try
            {
                EFile _f = DeleteFile(file);
                _f.Name = newName;
                Add(_f);
            }
            catch(EFileNotFoundException e)
            {
                throw e;
            }
        }


        #endregion ManagingFilesMethods

        #region Serialization


        /// <summary>
        /// Serializes the instance of EFileSystem to disk
        /// </summary>
        /// <param name="filePath">File path where to store the instance of FileSystem</param>
        /// <exception cref="Exception">An exception occured</exception>
        public void SerializeFileSystem(string filePath)
        {
            Stream saveFileStream = null;
            try
            {
                saveFileStream = File.Create(filePath);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(saveFileStream, this);
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if(saveFileStream != null)
                {
                    saveFileStream.Close();
                }
            }
           
            
        }

        /// <summary>
        /// Deserializes an instance of EFileSystem from disk
        /// </summary>
        /// <param name="filePath">Path from which retrieve the instance</param>
        /// <returns>Instance of EFileSystem</returns>
        /// <exception cref="Exception">An exception occured</exception>
        public static EFileSystem DeserializeFileSystem(string filePath)
        {
            Stream openFileStream = null;
            EFileSystem ris = null;
            try
            {
                openFileStream = File.OpenRead(filePath);
                BinaryFormatter deserializer = new BinaryFormatter();
                ris = (EFileSystem)deserializer.Deserialize(openFileStream);
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if(openFileStream != null)
                {
                    openFileStream.Close();
                }                
            }

            return ris;
        }
        #endregion Serialization


        #region InterfaceMethods

        /// <summary>
        /// Returns a list containing all the files and directories of the EFileSystem
        /// </summary>
        /// <returns></returns>
        public EFileList GetFileList()
        {
            EFileList ris = new EFileList();
            foreach(string path in PathsList)
            {
                ris.Add(GetFile(path));
            }
            return ris;
        }
        #endregion InterfaceMethods

    }
}