using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileList;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileChooserDialog.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
using FileChooserDialog.FileSystemEmulator.Backend.Data.Interfaces;
using FileChooserDialog.FileSystemEmulator.Backend.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChooserDialog.Launcher
{
    static class FileSystemEmulatorLauncher
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Launching parameters</param>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*try
            {
                //remove this: written for tests
                IFileSystem fs = FileSystemFactory.GetFileSystem();
                fs.Add(new EDirectory("C:\\Users\\Francesco"));
                fs.Add(new EDirectory("C:\\Users\\Test"));
                fs.Add(new EDirectory("C:\\System"));
                fs.Add(new EDirectory("C:\\System\\Pippo"));
                FileSystemFactory.GetFileSystem().DeleteFile("C:\\Users\\Test");
                fs.Add(new EDirectory("C:\\Users\\Test"));
                EFile f = fs.GetFile("C:\\Users");
                EFileList list = fs.GetFileList();
                EByteFile bytes = new EByteFile("Pippo", @"C:\Users\franc\OneDrive\Desktop\Voti.jar");

                fs.MoveFile("C:\\Users", "C:\\System\\Copy\\Users");
                fs.RenameFile("C:\\System\\Copy", "Test");
                fs.SerializeFileSystem(@"C:\Users\franc\OneDrive\Desktop\Test.t");

                
                
            }
            catch (EFileException) { } */

            Application.Run(new FileSystemExplorerGUI(args));

            
        }
    }
}
