using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions
{
    /// <summary>
    /// Extension of class <see cref="EFile"/>
    /// Implementation of a general text document
    /// </summary>
    [Serializable]
    public class ETextDocument : EFile
    {
        #region PublicFields
        /// <summary>
        /// Text content of the document
        /// </summary>
        public string Text { get; set; }
        #endregion PublicFields


        #region PrivateFields

        /// <summary>
        /// Buffer for characters that will be written to the file
        /// </summary>
        private string _buffer { get; set; }
        #endregion PrivateFields

        #region Constructor

        /// <summary>
        /// Creates an instance of a TextDocument
        /// </summary>
        /// <param name="path">Location of the file</param>
        public ETextDocument(string path) : base(path, false)
        {
            Text = "";
            _buffer = "";
        }
        #endregion Constructor

        #region AccessMethods

        /// <summary>
        /// Resets the content of the buffer
        /// </summary>
        public void ResetBuffer()
        {
            _buffer = "";
        }

        /// <summary>
        /// Loads the content of the file to the buffer
        /// </summary>
        public void Load()
        {
            _buffer = Text;
        }

        /// <summary>
        /// Returns the content of the file and loads the buffer
        /// </summary>
        /// <returns>Content of the file</returns>
        public string GetContent()
        {
            Load();
            return Text;
        }

        /// <summary>
        /// Wrtites a string to the buffer
        /// </summary>
        /// <param name="content">String to write</param>
        /// <param name="append">True if the string has to be appended to the existing buffer, false to substituteit</param>
        public void WriteToBuffer(string content, bool append)
        {
            if (append)
            {
                _buffer += content;
            }
            else
            {
                _buffer = content;
            }
        }

        /// <summary>
        /// Flushes the content of the buffer to the file
        /// </summary>
        /// <param name="append">True if the content of the buffer has to be appended to the file, false to substitute it</param>
        public void Flush(bool append)
        {
            if (append)
            {
                Text += _buffer;
            }
            else
            {
                Text = _buffer;
            }
            ResetBuffer();
        }
        #endregion AccessMethods


        #region MaintenanceMethods

        /// <summary>
        /// Creates a copy of the current <see cref="ETextDocument/>
        /// </summary>
        /// <returns>Returs a proper copy of the current <see cref="ETextDocument"/></returns
        public override EFile GetCopy()
        {
            ETextDocument res = new ETextDocument(this.Path);
            res.Text = this.Text;
            res._buffer = this._buffer;
            return res;
        }
        #endregion MaintenanceMethods
    }
}
