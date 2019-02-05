namespace FileSystemEmulator
{
    partial class FileSystemEmulatorGUI
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
            this.btnSuperDir = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).BeginInit();
            this.splitContMain.Panel1.SuspendLayout();
            this.splitContMain.Panel2.SuspendLayout();
            this.splitContMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listDirectory
            // 
            this.listDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDirectory.FormattingEnabled = true;
            this.listDirectory.ItemHeight = 22;
            this.listDirectory.Location = new System.Drawing.Point(0, 0);
            this.listDirectory.Name = "listDirectory";
            this.listDirectory.Size = new System.Drawing.Size(800, 417);
            this.listDirectory.TabIndex = 0;
            this.listDirectory.SelectedIndexChanged += new System.EventHandler(this.listDirectory_SelectedIndexChanged);
            // 
            // splitContMain
            // 
            this.splitContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContMain.Location = new System.Drawing.Point(0, 0);
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
            this.splitContMain.Panel2.Controls.Add(this.listDirectory);
            this.splitContMain.Size = new System.Drawing.Size(800, 450);
            this.splitContMain.SplitterDistance = 29;
            this.splitContMain.TabIndex = 1;
            // 
            // btnSuperDir
            // 
            this.btnSuperDir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSuperDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuperDir.Location = new System.Drawing.Point(0, 0);
            this.btnSuperDir.Name = "btnSuperDir";
            this.btnSuperDir.Size = new System.Drawing.Size(75, 29);
            this.btnSuperDir.TabIndex = 0;
            this.btnSuperDir.Text = "<";
            this.btnSuperDir.UseVisualStyleBackColor = true;
            this.btnSuperDir.Click += new System.EventHandler(this.btnSuperDir_Click);
            // 
            // txtPath
            // 
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(75, 0);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(725, 28);
            this.txtPath.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(706, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(94, 29);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // FileSystemEmulatorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContMain);
            this.Name = "FileSystemEmulatorGUI";
            this.Text = "FileSystemEmulator";
            this.Load += new System.EventHandler(this.FileSystemEmulatorGUI_Load);
            this.splitContMain.Panel1.ResumeLayout(false);
            this.splitContMain.Panel1.PerformLayout();
            this.splitContMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).EndInit();
            this.splitContMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listDirectory;
        private System.Windows.Forms.SplitContainer splitContMain;
        private System.Windows.Forms.Button btnSuperDir;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnGo;
    }
}

