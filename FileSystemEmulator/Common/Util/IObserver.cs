using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.Common.Util
{
    /// <summary>
    /// Observer interface for Observer Design Pattern implementation
    /// </summary>
    public interface IObserver
    {

        /// <summary>
        /// Observer method called when a <see cref="Subject"/> changes its internal status
        /// </summary>
        /// <param name="s">Subject that notified the observer</param>
        /// <param name="obj">Object containing changing information</param>
        void Update(Subject s, Object obj);
    }
}
