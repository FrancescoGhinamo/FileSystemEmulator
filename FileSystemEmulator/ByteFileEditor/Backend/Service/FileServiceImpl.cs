using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteFileEditor.Backend.Service
{
    /// <summary>
    /// Standard implementation of IFileService
    /// </summary>
    public class FileServiceImpl : IFileService
    {
        internal FileServiceImpl()
        {

        }

        public void WriteBytes(byte[] what, string path)
        {
            Stream inStream = null;
            try
            {
                inStream = File.Create(path);
                inStream.Write(what, 0, what.Length);
            }
            catch (Exception) { }
            finally
            {
                if(inStream != null)
                {
                    try
                    {
                        inStream.Flush();
                    }
                    catch (Exception) { }
                    finally
                    {
                        inStream.Close();
                    }
                    
                }
            }
        }
    }
}
