using FileChooser.FileSystemEmulator.Backend.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChooser.FileSystemEmulator.Backend.Utilities
{
    /// <summary>
    /// Provides a division in tokens of the string
    /// </summary>
    public class StringTokenizer
    {
        #region DataFields

        /// <summary>
        /// source string
        /// </summary>
        public string SourceString { get; }

        /// <summary>
        /// Separator to determine tokens
        /// </summary>
        public char Separator { get; }
        #endregion DataFields

        #region FunctionFields

        /// <summary>
        /// Tokens contained in the stirng
        /// </summary>
        private string[] Tokens { get; set; }

        /// <summary>
        /// Index from which I get a token
        /// </summary>
        private int Index { get; set; }
        #endregion FunctionFields


        #region Constructor

        public StringTokenizer(string source, char separator)
        {
            SourceString = source;
            Separator = separator;
            Tokens = SourceString.Split(Separator);
            Index = 0;
        }
        #endregion Constructor


        #region ProvidingMethods

        /// <summary>
        /// Returns the next token of the string
        /// </summary>
        /// <returns>Next token</returns>
        public string NextToken()
        {
            if(Index < Tokens.Length)
            {
                string t = Tokens[Index];
                Index++;
                return t;
            }
            else
            {
                throw new NoSuchElementException();
            }
            
        }
        #endregion ProvidingMethods


        #region StateMethods

        /// <summary>
        /// Tells if the tokenizer has other tokens
        /// </summary>
        /// <returns>True if other tokens are available</returns>
        public bool HasMoreTokens()
        {
            if(Index >= Tokens.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion StateMethods
    }
}
