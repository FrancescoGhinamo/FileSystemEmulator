using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Exceptions
{
    /// <summary>
    /// Exception indicating the parameter passed to a method is not valid
    /// </summary>
    public class IllegalParameterException : Exception
    {

       
        /// <summary>
        /// Constructor, uses a default message for this exception
        /// </summary>
        public IllegalParameterException() : base("One or more parameters passed to the method are invalid")
        {

        }
    }
}
