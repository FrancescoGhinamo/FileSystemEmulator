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
            Application.Run(new FileSystemExplorerGUI(args));

            
        }
    }
}
