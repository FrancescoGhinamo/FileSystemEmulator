namespace FileChooser.FileSystemEmulator.Frontend.GUI.FileDialogs
{
    partial class MoveFileDialog
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
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mainPan = new System.Windows.Forms.TableLayoutPanel();
            this.pathPan = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDest = new System.Windows.Forms.Label();
            this.txtDestPath = new System.Windows.Forms.TextBox();
            this.flowButtons.SuspendLayout();
            this.mainPan.SuspendLayout();
            this.pathPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowButtons
            // 
            this.flowButtons.Controls.Add(this.btnMove);
            this.flowButtons.Controls.Add(this.btnCancel);
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowButtons.Location = new System.Drawing.Point(0, 93);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Size = new System.Drawing.Size(976, 51);
            this.flowButtons.TabIndex = 4;
            // 
            // btnMove
            // 
            this.btnMove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMove.Location = new System.Drawing.Point(851, 3);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(122, 39);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(723, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 39);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mainPan
            // 
            this.mainPan.ColumnCount = 2;
            this.mainPan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.59836F));
            this.mainPan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.40164F));
            this.mainPan.Controls.Add(this.pathPan, 1, 0);
            this.mainPan.Controls.Add(this.lblSource, 0, 0);
            this.mainPan.Controls.Add(this.lblDest, 0, 1);
            this.mainPan.Controls.Add(this.txtDestPath, 1, 1);
            this.mainPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPan.Location = new System.Drawing.Point(0, 0);
            this.mainPan.Name = "mainPan";
            this.mainPan.RowCount = 2;
            this.mainPan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.90196F));
            this.mainPan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.09804F));
            this.mainPan.Size = new System.Drawing.Size(976, 144);
            this.mainPan.TabIndex = 3;
            // 
            // pathPan
            // 
            this.pathPan.Controls.Add(this.txtSourcePath);
            this.pathPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathPan.Location = new System.Drawing.Point(164, 3);
            this.pathPan.Name = "pathPan";
            this.pathPan.Size = new System.Drawing.Size(809, 37);
            this.pathPan.TabIndex = 3;
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSourcePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSourcePath.Location = new System.Drawing.Point(3, 3);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(806, 24);
            this.txtSourcePath.TabIndex = 4;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSource.Location = new System.Drawing.Point(3, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(155, 43);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source EFile";
            // 
            // lblDest
            // 
            this.lblDest.AutoSize = true;
            this.lblDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDest.Location = new System.Drawing.Point(3, 43);
            this.lblDest.Name = "lblDest";
            this.lblDest.Size = new System.Drawing.Size(155, 101);
            this.lblDest.TabIndex = 1;
            this.lblDest.Text = "Destination EFile";
            // 
            // txtDestPath
            // 
            this.txtDestPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDestPath.Location = new System.Drawing.Point(164, 46);
            this.txtDestPath.Name = "txtDestPath";
            this.txtDestPath.Size = new System.Drawing.Size(809, 24);
            this.txtDestPath.TabIndex = 3;
            // 
            // MoveFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 144);
            this.Controls.Add(this.flowButtons);
            this.Controls.Add(this.mainPan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MoveFileDialog";
            this.Text = "Move EFile";
            this.flowButtons.ResumeLayout(false);
            this.mainPan.ResumeLayout(false);
            this.mainPan.PerformLayout();
            this.pathPan.ResumeLayout(false);
            this.pathPan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel mainPan;
        private System.Windows.Forms.FlowLayoutPanel pathPan;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.TextBox txtDestPath;
    }
}