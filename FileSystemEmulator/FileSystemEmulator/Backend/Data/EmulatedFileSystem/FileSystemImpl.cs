using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileList;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooserDialog.FileSystemEmulator.Backend.Data.Interfaces;
using FileChooserDialog.FileSystemEmulator.Backend.Exceptions;
using FileChooserDialog.FileSystemEmulator.Backend.Services.Implementations;
using FileChooserDialog.FileSystemEmulator.Backend.Services.Interfaces;
using FileChooserDialog.FileSystemEmulator.Backend.Utilities;
using FileSystemEmulator.Common.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileSystem
{
    /// <summary>
    /// File system emulation, with methods to access the file system
    /// Singleton class, only the same instance of this object can be used in the program
    /// </summary>
    [Serializable]
    public class FileSystemImpl : Subject, IFileSystem
    {

        #region Singleton
        private static FileSystemImpl me;

        /// <summary>
        /// Internal instance getter
        /// </summary>
        /// <returns>Instance of <see cref="FileSystemImpl"/></returns>
        internal static FileSystemImpl GetInstance()
        {
            if (me == null)
            {
                //if this objecy hasn't been instances yet, I instance it here
                me = new FileSystemImpl();
                me.SetChanged();
                me.NotifyObserves("whole");
            }
            //return the instance
            return me;
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

        /// <summary>
        /// Temporary copy for files after format
        /// </summary>
        private EFileList _temporaryCopy { get; set; }

       


        #endregion PrivateFields

        #region Constructor

        /// <summary>
        /// Default constructor, the root dir is C:
        /// </summary>
        private FileSystemImpl()
        { 
            Root = new EDirectory("C:");
            CurrentLocation = Root.Path;
            _temporaryCopy = new EFileList();
        }

        /// <summary>
        /// Gets the root of the file system
        /// </summary>
        /// <returns>Root of the file system</returns>
        public EDirectory GetRoot()
        {
            return Root;
        }

        #endregion Constructor


        #region FileSystemManagement

        /// <summary>
        /// Formats the file system: all the references to the files are lost
        /// A temporary copy can be preserved to retrieve the files in case of an error.
        /// The copy cannot be serialized so once the object is finalized the temporary copy is lost
        /// </summary>
        /// <param name="copy">True if a temporary copy has to be preserved</param>
        public void Format(bool copy)
        {
            if (copy)
            {
                _temporaryCopy.Clear();
                foreach(EFile f in Root.SubFiles)
                {
                    _temporaryCopy.Add(f);
                }
            }
            Root.SubFiles.Clear();
            SetChanged();
            NotifyObserves("whole");
        }

        /// <summary>
        /// Attempts to recovery deleted files after a format
        /// The file system can be overwritten by recovered files or the recovered files can be only added to the existing ones
        /// </summary>
        /// <param name="overwrite">True to overwrite the file system</param>
        /// <exception cref="NoFilesException">Thrown if no files can be recovered</exception>
        public void AttemptRecovery(bool overwrite)
        {
            if(_temporaryCopy.Count > 0)
            {
                if (overwrite)
                {
                    Root.SubFiles.Clear();
                }

                foreach(EFile f in _temporaryCopy)
                {
                    this.Add(f);
                }
            }
            else
            {
                throw new NoFilesException();
            }
            

            
        }


        #endregion FileSystemManagement

        #region AddingFileMethods

        /// <summary>
        /// Adds the specified <see cref="EFile"/> to the file system
        /// </summary>
        /// <param name="f">File to add</param>
        /// <exception cref="EFileNameAlreadyExistingException">The method is attempting to add a file that has the same of a file alread in directory</exception>
        public void Add(EFile f)
        {
            //copy to restore the current location after the process
            string _loc = CurrentLocation;
            //I begin adding file from C: directory
            CurrentLocation = "C:";
            StringTokenizer sT = new StringTokenizer(f.Path, DIR_SEPARATOR);
            //to exclude the C: token
            sT.NextToken();
            try
            {
                Add(f, Root, sT);
            }
            catch (IllegalParameterException) { }
            catch (EFileNameAlreadyExistingException e)
            {
                throw e;
            }
            finally
            {
                CurrentLocation = _loc;
                SetChanged();
                NotifyObserves("whole");
            }

            
        }

        /// <summary>
        /// Adds the file to the file system
        /// IllegalParatemeterException can be thrown if the file f is null
        /// </summary>
        /// <param name="f">File to add</param>
        /// <param name="rRoot">Relative root</param>
        /// <param name="sT">Segments of the path</param>
        /// <exception cref="IllegalParameterException">The file the method is attempting to add is not valid</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The method is attempting to add a file that has the same of a file alread in directory</exception>
        private void Add(EFile f, EFile rRoot, StringTokenizer sT)
        {
            //tokens and position in the file system proceed the same way
            string token = sT.NextToken();
            if (token.Equals(f.Name))
            {
                //if the I reached the position I add the file
                try
                {
                    //if the file doesn't exist yet
                    if (rRoot.SubFiles.IndexOfFileName(f.Name) == -1)
                    {
                        //I add the fine
                        rRoot.SubFiles.Add(f);
                    }
                    else
                    {
                        //I throw an exception
                        throw new EFileNameAlreadyExistingException();
                    }
                    
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
                try
                {
                    Add(f, rRoot.SubFiles.ElementAt(rRoot.SubFiles.IndexOfFileName(token)), sT);
                }
                catch (IllegalParameterException e)
                {
                    throw e;
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
                
            }

        }
        #endregion AddingFileMethods
        
        #region RetrievingFileMethods

        /// <summary>
        /// Retrieves an <see cref="EFile"/> saved in the file system
        /// If the specified file doesn't exist a FileNotFoundException is thrown
        /// </summary>
        /// <param name="path">Path to look for</param>
        /// <returns>File indentified by the path</returns>
        /// <exception cref="EFileNotFoundException">The specified file path points to a file that doesn't exist</exception>
        public EFile GetFile(string path)
        {
            EFile res = null;
            if (path.Equals("C:"))
            {
                res = Root;
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
                    res = GetFile(Root, sT);
                }
                catch (EFileNotFoundException e)
                {
                    throw e;
                }
            }

            SetChanged();
            NotifyObserves("basic");

            return res;
           
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
            EFile res = null;

            if(sT.HasMoreTokens())
            {
                string token = sT.NextToken();
                int subIndex = 0;
                if ((subIndex = rRoot.SubFiles.IndexOfFileName(token)) != -1)
                {
                    //if the sub file exists
                    if (!sT.HasMoreTokens())
                    {
                        //if I reaced the last file name
                        res = rRoot.SubFiles.ElementAt(subIndex);
                    }
                    else
                    {
                        //I explore the next subfolder
                        //update the current location
                        CurrentLocation = CurrentLocation + DIR_SEPARATOR + token;
                        try
                        {
                            res = GetFile(rRoot.SubFiles.ElementAt(subIndex), sT);
                        }
                        catch (EFileNotFoundException e)
                        {
                            throw e;
                        }

                    }
                }
                else
                {
                    throw new EFileNotFoundException();
                }
            }
            

            return res;
            
        }
        #endregion RetrievingFileMethods

        #region ManagingFilesMethods

        /// <summary>
        /// Deletes and returns the <see cref="EFile"/> specified in the given path
        /// </summary>
        /// <param name="path">Path reference to the file</param>
        /// <returns>Deleted file</returns>
        /// <exception cref="EFileNotFoundException">The chosen file doesn't exist</exception>
        public EFile DeleteFile(string path)
        {
            EFile _deleted = null;
            try
            {
                
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
                finally
                {
                    SetChanged();
                    NotifyObserves("whole");
                }

            }
            catch (EFileNotFoundException e)
            {

                throw e;
            }
            finally
            {
                SetChanged();
                NotifyObserves("whole");
            }

            return _deleted;
        }


        
        /// <summary>
        /// Copies an <see cref="EFile"/> to another location in the file system
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationFile">Destination location, must contain the file name in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        public void CopyFile(string sourceFile, string destinationFile)
        {
            try
            {
                EFile _source = GetFile(sourceFile);
                EFile newFile = _source.GetCopy();
                //update of file path and name
                newFile.ParentPath = destinationFile.Substring(0, destinationFile.LastIndexOf(DIR_SEPARATOR));
                newFile.Name = destinationFile.Substring(destinationFile.LastIndexOf(DIR_SEPARATOR) + 1);
                newFile.UpdateSubFilesPath();
                try
                {
                    this.Add(newFile);
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
                finally
                {
                    SetChanged();
                    NotifyObserves("whole");
                }

            }
            catch (EFileNotFoundException e)
            {
                throw e;
            }
            finally
            {
                SetChanged();
                NotifyObserves("whole");
            }
        }


        /// <summary>
        /// Copies an <see cref="EFile"/> to another location in the file system
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationPath">New parent of the file (should be a Directory)</param>
        /// <param name="destinationName">Name of the file in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        public void CopyFile(string sourceFile, string destinationPath, string destinationName)
        {
            try
            {
                EFile _source = GetFile(sourceFile);
                //update of file path and name
                _source.ParentPath = destinationPath;
                _source.Name = destinationName;
                _source.UpdateSubFilesPath();
                try
                {
                    this.Add(_source);
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
                finally
                {
                    SetChanged();
                    NotifyObserves("whole");
                }
            }
            catch (EFileNotFoundException e)
            {
                throw e;
            }
            finally
            {
                SetChanged();
                NotifyObserves("whole");
            }
        }

        /// <summary>
        /// Moves an <see cref="EFile"/> from a location to another
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationFile">Destination location, must contain the file name in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        public void MoveFile(string sourceFile, string destinationFile)
        {
            try
            {
                EFile _source = DeleteFile(sourceFile);
                //update of file path and name
                _source.ParentPath = destinationFile.Substring(0, destinationFile.LastIndexOf(DIR_SEPARATOR));
                _source.Name = destinationFile.Substring(destinationFile.LastIndexOf(DIR_SEPARATOR) + 1);
                _source.UpdateSubFilesPath();
                try
                {
                    this.Add(_source);
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
                finally
                {
                    SetChanged();
                    NotifyObserves("whole");
                }
            }
            catch (EFileNotFoundException e)
            {
                throw e;
            }
            finally
            {
                SetChanged();
                NotifyObserves("whole");
            }

        }

        /// <summary>
        /// Moves an <see cref="EFile"/> from a location to another
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationPath">New parent of the file (should be a Directory)</param>
        /// <param name="destinationName">Name of the file in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        public void MoveFile(string sourceFile, string destinationPath, string destinationName)
        {
            try
            {
                EFile _source = DeleteFile(sourceFile);
                //update of file path and name
                _source.ParentPath = destinationPath;
                _source.Name = destinationName;
                _source.UpdateSubFilesPath();
                try
                {
                    this.Add(_source);
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
                finally
                {
                    SetChanged();
                    NotifyObserves("whole");
                }
            }
            catch (EFileNotFoundException e)
            {
                throw e;
            }
            finally
            {
                SetChanged();
                NotifyObserves("whole");
            }
        }


        /// <summary>
        /// Renames the specified <see cref="EFile"/>
        /// </summary>
        /// <param name="file">Chosen file</param>
        /// <param name="newName">New name to assign to the file</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The <see cref="EFile"/> name already exists</exception>
        public void RenameFile(string file, string newName)
        {
            try
            {
                EFile _f = DeleteFile(file);
                _f.Name = newName;
                _f.UpdateSubFilesPath();
                try
                {
                    this.Add(_f);
                }
                catch (EFileNameAlreadyExistingException e)
                {
                    throw e;
                }
                finally
                {
                    SetChanged();
                    NotifyObserves("whole");
                }
            }
            catch(EFileNotFoundException e)
            {
                throw e;
            }
            finally
            {
                SetChanged();
                NotifyObserves("whole");
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
            IFileServices fS = FileServicesFactory.GetFileServices();
            try
            {
                fS.SaveOnDisk(this, filePath);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Deserializes an instance of EFileSystem from disk
        /// </summary>
        /// <param name="filePath">Path from which retrieve the instance</param>
        /// <returns>Instance of EFileSystem</returns>
        /// <exception cref="Exception">An exception occured</exception>
        public FileSystemImpl DeserializeFileSystem(string filePath)
        {
            FileSystemImpl ris = null;
            IFileServices fS = FileServicesFactory.GetFileServices();
            try
            {
                ris = fS.LoadFromDisk(filePath);
            }
            catch (Exception e)
            {
                throw e;
            }
            me = ris;
            return GetInstance();
        }
        #endregion Serialization


        #region InterfaceMethods

        /// <summary>
        /// Returns an <see cref="EFileList"/> containing all the <see cref="EFile"/> and directories of the EFileSystem
        /// </summary>
        /// <returns></returns>
        public EFileList GetFileList()
        {
            EFileList ris = new EFileList();
            foreach(string path in PathsList)
            {
                try
                {
                    ris.Add(GetFile(path));
                }
                catch (EFileNotFoundException) { }
                
            }
            return ris;
        }

        /// <summary>
        /// Loads all the <see cref="EFile"/> contained in a <see cref="EFileList"/> in the current <see cref="FileSystemImpl"/>
        /// </summary>
        /// <param name="fileList">List of files to add</param>
        /// <param name="format">True if the file system must be formatted before adding the files </param>
        public void LoadFromFileList(EFileList fileList, bool format)
        {
            if (format)
            {
                this.Format(true);
            }

            foreach(EFile f in fileList)
            {
                try
                {
                    this.Add(f);
                }
                catch (EFileNameAlreadyExistingException) { }
                
            }
        }

        /// <summary>
        /// Location the methods are accessing
        /// </summary>
        /// <returns>Location the methods are accessing</returns>
        public string GetCurrentLocation()
        {
            return CurrentLocation;
        }


        /// <summary>
        /// Returns a <see cref="TreeNode"/> containing the tree representation of the FileSystem
        /// </summary>
        /// <returns>Nodes</returns>
        public TreeNode GetTreeNodes()
        {
            return Root.GetTreeNodes();
        }

        #endregion InterfaceMethods

    }
}