using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions
{
    /// <summary>
    /// Estension of class <see cref="Efile"/>
    /// This is a file made of a sequence of bytes: this can be the copy of file in the Windows file system
    /// </summary>
    [Serializable]
    public class EByteFile : EFile
    {


        #region Constants
        /// <summary>
        /// Default size of a byte array
        /// </summary>
        public const int DEFAULT_SIZE = 1024;

        /// <summary>
        /// Size of a sector
        /// </summary>
        public const int SECTOR_SIZE = 4096;
        #endregion Constants

        #region PublicFields

        /// <summary>
        /// Byte content of the file, copied from a Windows file
        /// </summary>
        public byte[] Content { get; set; }

        #endregion PublicFields

        #region Constructor

        /// <summary>
        /// Creates an instance of a byte file
        /// The array of byte is of a default size of 1024
        /// </summary>
        /// <param name="path">Location of the file</param>
        public EByteFile(string path) : base(path, false)
        {
            Content = new byte[DEFAULT_SIZE];
        }

        /// <summary>
        /// Creates an instance of a byte file from a real source file in the file system
        /// </summary>
        /// <param name="path">Location of the file</param>
        /// <param name="sourceFilePath">Source file in the Windows file system</param>
        public EByteFile(string path, string sourceFilePath) : base(path, false)
        {
            Content = this.RetrieveFileBytes(sourceFilePath);
        }
        #endregion Constructor


        #region RetrievingFileFromWindows

        /// <summary>
        /// Retrieves bytes from a Windows file
        /// </summary>
        /// <param name="sourcePath">Source file in the Windows file system</param>
        /// <returns>Bytes contained in the file</returns>
        /// <exception cref="Exception">Thrown in case an exception occures while accessing the file</exception>
        private byte[] RetrieveFileBytes(string sourcePath)
        {
            byte[] res = null;
            FileStream reader = null;
            MemoryStream bytes = null;
            try
            {
                reader = File.OpenRead(sourcePath);
                bytes = new MemoryStream();

                byte[] buffer = new byte[SECTOR_SIZE];
                int bytesRead = 0;

                while((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bytes.Write(buffer, 0, bytesRead);
                }

                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }

                if(bytes != null)
                {
                    bytes.Close();
                }
            }

            res = bytes.ToArray();

            return res;
        }

        #endregion RetrievingFileFromWindows
    }
}
