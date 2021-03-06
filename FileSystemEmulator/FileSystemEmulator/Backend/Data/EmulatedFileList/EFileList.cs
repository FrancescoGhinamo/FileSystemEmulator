﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooserDialog.FileSystemEmulator.Backend.Exceptions;

namespace FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileList
{
    /// <summary>
    /// Dynamic list of <see cref="EFile"/>, extension of class <see cref="List{EFile}"/>
    /// </summary>
    [Serializable]
    public class EFileList : List<EFile>
    {
        #region InheritedMethods

        /// <summary>
        /// Adds a file to the current list
        /// </summary>
        /// <param name="item">file to add to the list</param>
        /// <exception cref="IllegalParameterException">The passed argument is not valid (null)</exception>
        public new void Add(EFile item)
        {
            if (item != null)
            {
                base.Add(item);
            }
            else
            {
                throw new IllegalParameterException();
            }
        }
        #endregion InheritedRegions


        #region UtilityMethods

        /// <summary>
        /// Returns the index of the array where is stored a that has the given string ans name
        /// </summary>
        /// <param name="name">String containing the name of the file (extension included)</param>
        /// <returns>Returns the index of the file. If no file is found, -1 is returned</returns>
        public int IndexOfFileName(string name)
        {
            int index = -1;

            for (int _i = 0; _i < this.Count; _i++)
            {
                if (this.ElementAt(_i).Name.Equals(name))
                {
                    index = _i;
                    break;
                }
            }

            return index;
        }
        #endregion UtilityMethods
    }
}
