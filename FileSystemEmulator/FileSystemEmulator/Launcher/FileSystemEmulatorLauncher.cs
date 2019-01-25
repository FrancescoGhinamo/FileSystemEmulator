using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileList;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileSystemEmulator.FileSystemEmulator.Backend.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemEmulator.Launcher
{
    static class FileSystemEmulatorLauncher
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //remove this: written for tests
                EFileSystem fs = EFileSystem.GetInstance();
                string path = fs.Root.Path;
                fs.Add(new EDirectory("C:\\Users\\Francesco"));
                fs.Add(new EDirectory("C:\\Users\\Test"));
                fs.Add(new EDirectory("C:\\System"));
                fs.DeleteFile("C:\\Users\\Test");
                fs.Add(new EDirectory("C:\\Users\\Test"));
                EFile f = fs.GetFile("C:\\Users");
                EFileList list = fs.GetFileList();

                fs.MoveFile("C:\\Users", "C:\\System\\Copy\\Users");
                fs.RenameFile("C:\\System\\Copy", "Test");
                fs.SerializeFileSystem(@"C:\Users\franc\OneDrive\Desktop\Test.t");

                EFileSystem ef = EFileSystem.DeserializeFileSystem(@"C:\Users\franc\OneDrive\Desktop\Test.t");
                ef.Format(true);
                ef.Add(new EDirectory("C:\\Windows"));
                ef.AttemptRecovery(false);
                ef.LoadFromFileList(list, true);
            }
            catch (EFileException) { }

            Application.Run(new FileSystemEmulatorGUI());

            
        }
    }
}
