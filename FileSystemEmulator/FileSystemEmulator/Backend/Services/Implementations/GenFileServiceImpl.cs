using FileSystemEmulator.FileSystemEmulator.Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.FileSystemEmulator.Backend.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IGenFileService"/>
    /// </summary>
    public class GenFileServiceImpl : IGenFileService
    {
        public byte[] ReadBytes(string path)
        {
            byte[] res = null;
            try
            {
                res = File.ReadAllBytes(path);
            }
            catch (Exception) { }
            return res;
        }

        public void WriteBytes(string path, byte[] cont)
        {
            throw new NotImplementedException();
        }
    }
}
