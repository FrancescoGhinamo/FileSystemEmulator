using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.TextDocumentEditor.Backend.Service
{
    /// <summary>
    /// Standard implementation of IFileService
    /// </summary>
    public class FileServiceImpl : IFileService
    {
        internal FileServiceImpl()
        {

        }

        public string ReadContent(string path)
        {
            StringBuilder cont = new StringBuilder();

            StreamReader reader = null;
            try
            {
                reader = new StreamReader(File.OpenRead(path));
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    cont.Append(line);
                    cont.AppendLine();
                }
            }
            catch (Exception) { }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }

            return cont.ToString();
        }

        public void WriteString(string what, string path)
        {
            StreamWriter writer = null;

            try
            {
                writer.Write(what);
                writer.Flush();
            }
            catch (Exception) { }
            finally
            {
                if(writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
