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
            Application.Run(new FileSystemEmulatorGUI());

            
        }
    }
}
