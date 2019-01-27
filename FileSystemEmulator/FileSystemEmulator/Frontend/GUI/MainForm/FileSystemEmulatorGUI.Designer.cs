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
            this.listDirectory = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listDirectory
            // 
            this.listDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDirectory.GridLines = true;
            this.listDirectory.Location = new System.Drawing.Point(0, 0);
            this.listDirectory.Name = "listDirectory";
            this.listDirectory.Size = new System.Drawing.Size(800, 450);
            this.listDirectory.TabIndex = 0;
            this.listDirectory.UseCompatibleStateImageBehavior = false;
            this.listDirectory.SelectedIndexChanged += new System.EventHandler(this.listDirectory_SelectedIndexChanged);
            // 
            // FileSystemEmulatorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listDirectory);
            this.Name = "FileSystemEmulatorGUI";
            this.Text = "FileSystemEmulator";
            this.Load += new System.EventHandler(this.FileSystemEmulatorGUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listDirectory;
    }
}

