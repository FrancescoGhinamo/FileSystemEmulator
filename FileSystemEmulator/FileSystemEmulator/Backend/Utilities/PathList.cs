using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooser.FileSystemEmulator.Backend.Utilities
{
    /// <summary>
    /// Extension of class <see cref="List{string}"/> to deal with paths
    /// </summary>
    [Serializable]
    public class PathList : List<string>
    {
        /// <summary>
        /// Removes all the string containing the specified path
        /// </summary>
        /// <param name="bPath">Base path to remove</param>
        public new void Remove(string bPath)
        {
            /*foreach(string current in this)
            {
                if(current.Contains(bPath))
                {
                    base.Remove(current);
                }

            }*/
            for(int i = 0; i < Count; i++)
            {
                string current = this.ElementAt(i);
                if (current.Contains(bPath))
                {
                    base.Remove(current);
                    i--;
                }
            }
        }
    }
}
