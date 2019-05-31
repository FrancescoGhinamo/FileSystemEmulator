

namespace FileChooserDialog
{
    partial class FileChooser
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
            this.butPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).BeginInit();
            this.splitContMain.Panel1.SuspendLayout();
            this.splitContMain.Panel2.SuspendLayout();
            this.splitContMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanel)).BeginInit();
            this.navigationPanel.Panel1.SuspendLayout();
            this.navigationPanel.Panel2.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.butPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.listDirectory.Size = new System.Drawing.Size(643, 391);
            this.listDirectory.TabIndex = 0;
            this.listDirectory.DoubleClick += new System.EventHandler(this.listDirectory_DoubleClick);
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
            this.navigationPanel.SplitterDistance = 152;
            this.navigationPanel.SplitterWidth = 5;
            this.navigationPanel.TabIndex = 1;
            // 
            // treeExplorer
            // 
            this.treeExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeExplorer.Location = new System.Drawing.Point(0, 0);
            this.treeExplorer.Margin = new System.Windows.Forms.Padding(4);
            this.treeExplorer.Name = "treeExplorer";
            this.treeExplorer.Size = new System.Drawing.Size(152, 391);
            this.treeExplorer.TabIndex = 0;
            this.treeExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeExplorer_AfterSelect);
            // 
            // butPanel
            // 
            this.butPanel.Controls.Add(this.btnOK);
            this.butPanel.Controls.Add(this.btnCancel);
            this.butPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butPanel.Location = new System.Drawing.Point(0, 409);
            this.butPanel.Name = "butPanel";
            this.butPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.butPanel.Size = new System.Drawing.Size(800, 41);
            this.butPanel.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(686, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(111, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(569, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eFileToolStripMenuItem
            // 
            this.eFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDirectoryToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.eFileToolStripMenuItem.Name = "eFileToolStripMenuItem";
            this.eFileToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.eFileToolStripMenuItem.Text = "EFile";
            // 
            // newDirectoryToolStripMenuItem
            // 
            this.newDirectoryToolStripMenuItem.Name = "newDirectoryToolStripMenuItem";
            this.newDirectoryToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.newDirectoryToolStripMenuItem.Text = "New directory";
            this.newDirectoryToolStripMenuItem.Click += new System.EventHandler(this.NewDirectoryToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.MoveToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // FileChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butPanel);
            this.Controls.Add(this.splitContMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FileChooser";
            this.Text = "File chooser";
            this.Load += new System.EventHandler(this.FileSystemEmulator_Load);
            this.splitContMain.Panel1.ResumeLayout(false);
            this.splitContMain.Panel1.PerformLayout();
            this.splitContMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).EndInit();
            this.splitContMain.ResumeLayout(false);
            this.navigationPanel.Panel1.ResumeLayout(false);
            this.navigationPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanel)).EndInit();
            this.navigationPanel.ResumeLayout(false);
            this.butPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel butPanel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

