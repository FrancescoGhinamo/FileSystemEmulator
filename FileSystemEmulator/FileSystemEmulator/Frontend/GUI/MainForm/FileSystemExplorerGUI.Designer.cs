﻿namespace FileSystemEmulator
{
    partial class FileSystemExplorerGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listDirectory = new System.Windows.Forms.ListBox();
            this.splitContMain = new System.Windows.Forms.SplitContainer();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSuperDir = new System.Windows.Forms.Button();
            this.navigationPanel = new System.Windows.Forms.SplitContainer();
            this.treeExplorer = new System.Windows.Forms.TreeView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).BeginInit();
            this.splitContMain.Panel1.SuspendLayout();
            this.splitContMain.Panel2.SuspendLayout();
            this.splitContMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanel)).BeginInit();
            this.navigationPanel.Panel1.SuspendLayout();
            this.navigationPanel.Panel2.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listDirectory
            // 
            this.listDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDirectory.FormattingEnabled = true;
            this.listDirectory.ItemHeight = 22;
            this.listDirectory.Location = new System.Drawing.Point(0, 0);
            this.listDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listDirectory.Name = "listDirectory";
            this.listDirectory.Size = new System.Drawing.Size(641, 391);
            this.listDirectory.TabIndex = 0;
            this.listDirectory.SelectedIndexChanged += new System.EventHandler(this.listDirectory_SelectedIndexChanged);
            // 
            // splitContMain
            // 
            this.splitContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContMain.Location = new System.Drawing.Point(0, 28);
            this.splitContMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContMain.Name = "splitContMain";
            this.splitContMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContMain.Panel1
            // 
            this.splitContMain.Panel1.Controls.Add(this.btnGo);
            this.splitContMain.Panel1.Controls.Add(this.txtPath);
            this.splitContMain.Panel1.Controls.Add(this.btnSuperDir);
            // 
            // splitContMain.Panel2
            // 
            this.splitContMain.Panel2.Controls.Add(this.navigationPanel);
            this.splitContMain.Size = new System.Drawing.Size(800, 422);
            this.splitContMain.SplitterDistance = 27;
            this.splitContMain.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(707, 0);
            this.btnGo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(93, 27);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtPath
            // 
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(75, 0);
            this.txtPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(725, 28);
            this.txtPath.TabIndex = 1;
            // 
            // btnSuperDir
            // 
            this.btnSuperDir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSuperDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuperDir.Location = new System.Drawing.Point(0, 0);
            this.btnSuperDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuperDir.Name = "btnSuperDir";
            this.btnSuperDir.Size = new System.Drawing.Size(75, 27);
            this.btnSuperDir.TabIndex = 0;
            this.btnSuperDir.Text = "<";
            this.btnSuperDir.UseVisualStyleBackColor = true;
            this.btnSuperDir.Click += new System.EventHandler(this.btnSuperDir_Click);
            // 
            // navigationPanel
            // 
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Margin = new System.Windows.Forms.Padding(4);
            this.navigationPanel.Name = "navigationPanel";
            // 
            // navigationPanel.Panel1
            // 
            this.navigationPanel.Panel1.Controls.Add(this.treeExplorer);
            // 
            // navigationPanel.Panel2
            // 
            this.navigationPanel.Panel2.Controls.Add(this.listDirectory);
            this.navigationPanel.Size = new System.Drawing.Size(800, 391);
            this.navigationPanel.SplitterDistance = 154;
            this.navigationPanel.SplitterWidth = 5;
            this.navigationPanel.TabIndex = 1;
            // 
            // treeExplorer
            // 
            this.treeExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeExplorer.Location = new System.Drawing.Point(0, 0);
            this.treeExplorer.Margin = new System.Windows.Forms.Padding(4);
            this.treeExplorer.Name = "treeExplorer";
            this.treeExplorer.Size = new System.Drawing.Size(154, 391);
            this.treeExplorer.TabIndex = 0;
            this.treeExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeExplorer_AfterSelect);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.eFileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(222, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // eFileToolStripMenuItem
            // 
            this.eFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem});
            this.eFileToolStripMenuItem.Name = "eFileToolStripMenuItem";
            this.eFileToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.eFileToolStripMenuItem.Text = "EFile";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDirectoryToolStripMenuItem});
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.folderToolStripMenuItem.Text = "Folder";
            // 
            // eDirectoryToolStripMenuItem
            // 
            this.eDirectoryToolStripMenuItem.Name = "eDirectoryToolStripMenuItem";
            this.eDirectoryToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.eDirectoryToolStripMenuItem.Text = "EDirectory";
            this.eDirectoryToolStripMenuItem.Click += new System.EventHandler(this.eDirectoryToolStripMenuItem_Click);
            // 
            // FileSystemExplorerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContMain);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FileSystemExplorerGUI";
            this.Text = "FileSystemEmulator";
            this.Load += new System.EventHandler(this.FileSystemEmulatorGUI_Load);
            this.splitContMain.Panel1.ResumeLayout(false);
            this.splitContMain.Panel1.PerformLayout();
            this.splitContMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).EndInit();
            this.splitContMain.ResumeLayout(false);
            this.navigationPanel.Panel1.ResumeLayout(false);
            this.navigationPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanel)).EndInit();
            this.navigationPanel.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listDirectory;
        private System.Windows.Forms.SplitContainer splitContMain;
        private System.Windows.Forms.Button btnSuperDir;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.SplitContainer navigationPanel;
        private System.Windows.Forms.TreeView treeExplorer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem eFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDirectoryToolStripMenuItem;
    }
}

