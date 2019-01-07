using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFileSystem;
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

            //remove this: written for tests
            FileSystem fs = FileSystem.GetInstance();
            string path = fs.Root.Path;
            fs.Add(new Directory("C:\\Users\\Francesco"));
            fs.Add(new Directory("C:\\System"));
            File f = fs.GetFile("C:\\Users");
       
            fs.MoveFile("C:\\Users", "C:\\System\\Copy\\Users");
            fs.RenameFile("C:\\System\\Copy", "Test");


            Application.Run(new FileSystemEmulatorGUI());

            
        }
    }
}
