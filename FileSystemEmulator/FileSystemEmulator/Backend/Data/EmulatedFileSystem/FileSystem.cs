using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
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
                SingletonFileSystem = new FileSystem();
            }
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
            CurrentLocation = "C:";
            StringTokenizer sT = new StringTokenizer(f.Path, DIR_SEPARATOR);
            sT.NextToken();
            Add(f, Root, sT);
        }

        /// <summary>
        /// Adds the file to the file system
        /// </summary>
        /// <param name="f">File to add</param>
        /// <param name="sRoot">Relative root</param>
        /// <param name="sT">Segment of the path</param>
        private void Add(File f, File sRoot, StringTokenizer sT)
        {
            string token = sT.NextToken();
            if (token.Equals(f.Name))
            {
                sRoot.SubFiles.Add(f);
            }
            else
            {
                int subDir;
                if((subDir = sRoot.SubFiles.IndexOfFileName(token)) == -1)
                {
                    sRoot.SubFiles.Add(new Directory(CurrentLocation + DIR_SEPARATOR + token));
                }
                CurrentLocation = CurrentLocation + DIR_SEPARATOR + token;
                Add(f, sRoot.SubFiles.ElementAt(sRoot.SubFiles.IndexOfFileName(token)), sT);
            }

        }
        #endregion AddingFileMethods


        #region RetrievingFileMethods

        /// <summary>
        /// Retrieves a file saved in the file system
        /// </summary>
        /// <param name="path">Path to look for</param>
        /// <returns>File indentified by the path</returns>
        public File getFile(string path)
        {
            throw new Exception();
        }
        #endregion RetrievingFileMethods
    }
}
