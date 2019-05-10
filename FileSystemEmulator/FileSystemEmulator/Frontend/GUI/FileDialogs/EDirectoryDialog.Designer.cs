namespace FileChooser.FileSystemEmulator.Frontend.GUI.FileDialog
{
    partial class EDirectoryDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnsPan = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.contPan = new System.Windows.Forms.SplitContainer();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnsPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contPan)).BeginInit();
            this.contPan.Panel1.SuspendLayout();
            this.contPan.Panel2.SuspendLayout();
            this.contPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(492, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 34);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnsPan
            // 
            this.btnsPan.Controls.Add(this.btnOK);
            this.btnsPan.Controls.Add(this.btnCancel);
            this.btnsPan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnsPan.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.btnsPan.Location = new System.Drawing.Point(0, 103);
            this.btnsPan.Name = "btnsPan";
            this.btnsPan.Size = new System.Drawing.Size(750, 49);
            this.btnsPan.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(623, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 34);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPath
            // 
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Location = new System.Drawing.Point(0, 0);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(750, 22);
            this.txtPath.TabIndex = 2;
            // 
            // contPan
            // 
            this.contPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contPan.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.contPan.Location = new System.Drawing.Point(0, 0);
            this.contPan.Name = "contPan";
            this.contPan.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // contPan.Panel1
            // 
            this.contPan.Panel1.Controls.Add(this.lblPath);
            this.contPan.Panel1.Enabled = false;
            // 
            // contPan.Panel2
            // 
            this.contPan.Panel2.Controls.Add(this.txtPath);
            this.contPan.Size = new System.Drawing.Size(750, 103);
            this.contPan.SplitterDistance = 36;
            this.contPan.TabIndex = 3;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(0, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(130, 24);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Directory path:";
            // 
            // EDirectoryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(750, 152);
            this.Controls.Add(this.contPan);
            this.Controls.Add(this.btnsPan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EDirectoryDialog";
            this.Text = "Create EDirectory";
            this.Load += new System.EventHandler(this.EDirectoryDialog_Load);
            this.btnsPan.ResumeLayout(false);
            this.contPan.Panel1.ResumeLayout(false);
            this.contPan.Panel1.PerformLayout();
            this.contPan.Panel2.ResumeLayout(false);
            this.contPan.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contPan)).EndInit();
            this.contPan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel btnsPan;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.SplitContainer contPan;
        private System.Windows.Forms.Label lblPath;
    }
}