using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFileList;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooser.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FileChooser.FileSystemEmulator.Backend.Data.Interfaces
{
    /// <summary>
    /// Decalration functionalities for a file system
    /// </summary>
    public interface IFileSystem
    {

        /// <summary>
        /// Formats the file system: all the references to the files are lost
        /// A temporary copy can be preserved to retrieve the files in case of an error.
        /// The copy cannot be serialized so once the object is finalized the temporary copy is lost
        /// </summary>
        /// <param name="copy">True if a temporary copy has to be preserved</param>
        void Format(bool copy);

        /// <summary>
        /// Attempts to recovery deleted files after a format
        /// The file system can be overwritten by recovered files or the recovered files can be only added to the existing ones
        /// </summary>
        /// <param name="overwrite">True to overwrite the file system</param>
        /// <exception cref="NoFilesException">Thrown if no files can be recovered</exception>
        void AttemptRecovery(bool overwrite);


        /// <summary>
        /// Gets the root of the file system
        /// </summary>
        /// <returns>Root of the file system</returns>
        EDirectory GetRoot();

        /// <summary>
        /// Location the methods are accessing
        /// </summary>
        /// <returns>Location the methods are accessing</returns>
        string GetCurrentLocation();


        /// <summary>
        /// Adds the specified <see cref="EFile"/> to the file system
        /// </summary>
        /// <param name="f">File to add</param>
        /// <exception cref="EFileNameAlreadyExistingException">The method is attempting to add a file that has the same of a file alread in directory</exception>
        void Add(EFile f);

        /// <summary>
        /// Retrieves an <see cref="EFile"/> saved in the file system
        /// If the specified file doesn't exist a FileNotFoundException is thrown
        /// </summary>
        /// <param name="path">Path to look for</param>
        /// <returns>File indentified by the path</returns>
        /// <exception cref="EFileNotFoundException">The specified file path points to a file that doesn't exist</exception>
        EFile GetFile(string path);


        /// <summary>
        /// Deletes and returns the <see cref="EFile"/> specified in the given path
        /// </summary>
        /// <param name="path">Path reference to the file</param>
        /// <returns>Deleted file</returns>
        /// <exception cref="EFileNotFoundException">The chosen file doesn't exist</exception>
        EFile DeleteFile(string path);


        /// <summary>
        /// Copies an <see cref="EFile"/> to another location in the file system
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationFile">Destination location, must contain the file name in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        void CopyFile(string sourceFile, string destinationFile);

        /// <summary>
        /// Copies an <see cref="EFile"/> to another location in the file system
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationPath">New parent of the file (should be a Directory)</param>
        /// <param name="destinationName">Name of the file in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        void CopyFile(string sourceFile, string destinationPath, string destinationName);

        /// <summary>
        /// Moves an <see cref="EFile"/> from a location to another
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationFile">Destination location, must contain the file name in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        void MoveFile(string sourceFile, string destinationFile);

        /// <summary>
        /// Moves an <see cref="EFile"/> from a location to another
        /// </summary>
        /// <param name="sourceFile">Source file</param>
        /// <param name="destinationPath">New parent of the file (should be a Directory)</param>
        /// <param name="destinationName">Name of the file in the destination</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The destination directory already contains an <see cref="EFile"/> with the same name</exception>
        void MoveFile(string sourceFile, string destinationPath, string destinationName);

        /// <summary>
        /// Renames the specified <see cref="EFile"/>
        /// </summary>
        /// <param name="file">Chosen file</param>
        /// <param name="newName">New name to assign to the file</param>
        /// <exception cref="EFileNotFoundException">The specified source file doesn't exist</exception>
        /// <exception cref="EFileNameAlreadyExistingException">The <see cref="EFile"/> name already exists</exception>
        void RenameFile(string file, string newName);

        /// <summary>
        /// Serializes the instance of EFileSystem to disk
        /// </summary>
        /// <param name="filePath">File path where to store the instance of FileSystem</param>
        /// <exception cref="Exception">An exception occured</exception>
        void SerializeFileSystem(string filePath);

        /// <summary>
        /// Deserializes an instance of EFileSystem from disk
        /// </summary>
        /// <param name="filePath">Path from which retrieve the instance</param>
        /// <returns>Instance of EFileSystem</returns>
        /// <exception cref="Exception">An exception occured</exception>
        FileSystemImpl DeserializeFileSystem(string filePath);

        /// <summary>
        /// Returns an <see cref="EFileList"/> containing all the <see cref="EFile"/> and directories of the EFileSystem
        /// </summary>
        /// <returns></returns>
        EFileList GetFileList();

        /// <summary>
        /// Loads all the <see cref="EFile"/> contained in a <see cref="EFileList"/> in the current <see cref="FileSystemImpl"/>
        /// </summary>
        /// <param name="fileList">List of files to add</param>
        /// <param name="format">True if the file system must be formatted before adding the files </param>
        void LoadFromFileList(EFileList fileList, bool format);

        /// <summary>
        /// Returns a <see cref="TreeNode"/> containing the tree representation of the FileSystem
        /// </summary>
        /// <returns>Nodes</returns>
        TreeNode GetTreeNodes();

    }
}
