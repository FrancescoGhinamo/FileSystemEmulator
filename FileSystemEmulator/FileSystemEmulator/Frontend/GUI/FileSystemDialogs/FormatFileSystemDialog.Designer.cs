namespace FileSystemEmulator.FileSystemEmulator.Frontend.GUI.FileSystemDialogs
{
    partial class FormatFileSystemDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormatFileSystemDialog));
            this.contPan = new System.Windows.Forms.SplitContainer();
            this.lblInfo = new System.Windows.Forms.Label();
            this.chkCopy = new System.Windows.Forms.CheckBox();
            this.btnFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFormat = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.contPan)).BeginInit();
            this.contPan.Panel1.SuspendLayout();
            this.contPan.Panel2.SuspendLayout();
            this.contPan.SuspendLayout();
            this.btnFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // contPan
            // 
            this.contPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contPan.Location = new System.Drawing.Point(0, 0);
            this.contPan.Name = "contPan";
            this.contPan.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // contPan.Panel1
            // 
            this.contPan.Panel1.Controls.Add(this.lblInfo);
            // 
            // contPan.Panel2
            // 
            this.contPan.Panel2.Controls.Add(this.chkCopy);
            this.contPan.Size = new System.Drawing.Size(774, 259);
            this.contPan.SplitterDistance = 110;
            this.contPan.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(576, 54);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // chkCopy
            // 
            this.chkCopy.AutoSize = true;
            this.chkCopy.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkCopy.Location = new System.Drawing.Point(0, 0);
            this.chkCopy.Name = "chkCopy";
            this.chkCopy.Size = new System.Drawing.Size(774, 21);
            this.chkCopy.TabIndex = 1;
            this.chkCopy.Text = "Keep temporary copy";
            this.chkCopy.UseVisualStyleBackColor = true;
            // 
            // btnFlow
            // 
            this.btnFlow.Controls.Add(this.btnFormat);
            this.btnFlow.Controls.Add(this.btnCancel);
            this.btnFlow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFlow.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.btnFlow.Location = new System.Drawing.Point(0, 198);
            this.btnFlow.Name = "btnFlow";
            this.btnFlow.Size = new System.Drawing.Size(774, 61);
            this.btnFlow.TabIndex = 1;
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(626, 3);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(145, 43);
            this.btnFormat.TabIndex = 2;
            this.btnFormat.Text = "Format";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(475, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 43);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormatFileSystemDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 259);
            this.Controls.Add(this.btnFlow);
            this.Controls.Add(this.contPan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormatFileSystemDialog";
            this.Text = "Format FS";
            this.contPan.Panel1.ResumeLayout(false);
            this.contPan.Panel1.PerformLayout();
            this.contPan.Panel2.ResumeLayout(false);
            this.contPan.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contPan)).EndInit();
            this.contPan.ResumeLayout(false);
            this.btnFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer contPan;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.CheckBox chkCopy;
        private System.Windows.Forms.FlowLayoutPanel btnFlow;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Button btnCancel;
    }
}