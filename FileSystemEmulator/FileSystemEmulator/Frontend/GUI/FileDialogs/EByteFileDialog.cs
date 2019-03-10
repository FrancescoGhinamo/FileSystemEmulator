﻿using FileSystemEmulator.FileSystemEmulator.Backend.Data.EmulatedFiles.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemEmulator.FileSystemEmulator.Frontend.GUI.FileDialogs
{
    public partial class EByteFileDialog : Form
    {
        /// <summary>
        /// Extension given to the <see cref="EByteFile"/>
        /// </summary>
        private const string EXTENSION = "bf";

        /// <summary>
        /// <see cref="EByteFile"/> created by the dialog
        /// </summary>
        public EByteFile byteFile { get; set; }

        public EByteFileDialog(string currentLocation)
        {
            InitializeComponent();
            txtDest.Text = currentLocation;
        }

        private void EByteFileDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openD = new OpenFileDialog();
            if(openD.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openD.FileName;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(!txtPath.Text.Equals("") && !txtDest.Equals(""))
            {
                byteFile = new EByteFile(txtDest.Text + "." + EXTENSION, txtPath.Text);
                DialogResult = DialogResult.OK;
                Dispose();
            }
            else
            {
                MessageBox.Show(this, "Not all the fields have been filled in", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }
    }
}