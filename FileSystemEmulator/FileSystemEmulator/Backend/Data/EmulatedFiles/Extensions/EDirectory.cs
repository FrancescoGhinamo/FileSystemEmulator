using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions
{
    /// <summary>
    /// Extension of class <see cref="EFile"/>, this file is a standard directory
    /// </summary>
    [Serializable]
    public class EDirectory : EFile
    {
        #region Constructor

        /// <summary>
        /// Basic constructor to define a general directory
        /// </summary>
        /// <param name="path">Location in the file system</param>
        public EDirectory(string path) : base(path, true)
        {

        }
        #endregion Constructor

        #region InterfaceMethods

        public new string ToString()
        {
            string res = "";
            res += "> ";
            res += base.ToString();
            return res;
        }
        #endregion InterfaceMethods

        #region MaintenanceMethods

        /// <summary>
        /// Creates a copy of the current <see cref="EDirectory"/>
        /// </summary>
        /// <returns>Returs a proper copy of the current <see cref="EDirectory"/></returns
        public override EFile GetCopy()
        {
            EDirectory res = new EDirectory(this.Path);
            return res;
        }
        #endregion MaintenanceMethods
    }
}
