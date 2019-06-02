namespace FileChooserDialog.FileSystemEmulator.Frontend.GUI.FileDialogs
{
    partial class ETextDocumentDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETextDocumentDialog));
            this.mainPan = new System.Windows.Forms.TableLayoutPanel();
            this.pathPan = new System.Windows.Forms.FlowLayoutPanel();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDest = new System.Windows.Forms.Label();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mainPan.SuspendLayout();
            this.pathPan.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPan
            // 
            resources.ApplyResources(this.mainPan, "mainPan");
            this.mainPan.Controls.Add(this.pathPan, 1, 0);
            this.mainPan.Controls.Add(this.lblSource, 0, 0);
            this.mainPan.Controls.Add(this.lblDest, 0, 1);
            this.mainPan.Controls.Add(this.txtDest, 1, 1);
            this.mainPan.Name = "mainPan";
            // 
            // pathPan
            // 
            this.pathPan.Controls.Add(this.txtPath);
            this.pathPan.Controls.Add(this.btnChoose);
            resources.ApplyResources(this.pathPan, "pathPan");
            this.pathPan.Name = "pathPan";
            // 
            // txtPath
            // 
            resources.ApplyResources(this.txtPath, "txtPath");
            this.txtPath.Name = "txtPath";
            // 
            // btnChoose
            // 
            resources.ApplyResources(this.btnChoose, "btnChoose");
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // lblSource
            // 
            resources.ApplyResources(this.lblSource, "lblSource");
            this.lblSource.Name = "lblSource";
            // 
            // lblDest
            // 
            resources.ApplyResources(this.lblDest, "lblDest");
            this.lblDest.Name = "lblDest";
            // 
            // txtDest
            // 
            resources.ApplyResources(this.txtDest, "txtDest");
            this.txtDest.Name = "txtDest";
            this.txtDest.DoubleClick += new System.EventHandler(this.TxtDest_DoubleClick);
            // 
            // flowButtons
            // 
            this.flowButtons.Controls.Add(this.btnCreate);
            this.flowButtons.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.flowButtons, "flowButtons");
            this.flowButtons.Name = "flowButtons";
            // 
            // btnCreate
            // 
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ETextDocumentDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowButtons);
            this.Controls.Add(this.mainPan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ETextDocumentDialog";
            this.mainPan.ResumeLayout(false);
            this.mainPan.PerformLayout();
            this.pathPan.ResumeLayout(false);
            this.pathPan.PerformLayout();
            this.flowButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPan;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.FlowLayoutPanel pathPan;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
    }
}