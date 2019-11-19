namespace PDFRipperWinFormApp
{
    partial class Templates
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
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.pbImage = new Emerson.Cookstown.Controls.ImageBox();
            this.lvPOI = new System.Windows.Forms.ListView();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(172)))), ((int)(((byte)(189)))));
            this.btnRemoveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRemoveFile.Location = new System.Drawing.Point(519, 283);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(88, 30);
            this.btnRemoveFile.TabIndex = 4;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.UseVisualStyleBackColor = false;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(9, 9);
            this.pbImage.Name = "pbImage";
            this.pbImage.SelectionMode = Emerson.Cookstown.Controls.ImageBoxInternal.ImageBoxSelectionMode.Rectangle;
            this.pbImage.Size = new System.Drawing.Size(410, 570);
            this.pbImage.TabIndex = 7;
            this.pbImage.Selected += new System.EventHandler<System.EventArgs>(this.pbImage_Selected);
            // 
            // lvPOI
            // 
            this.lvPOI.HideSelection = false;
            this.lvPOI.Location = new System.Drawing.Point(425, 87);
            this.lvPOI.Name = "lvPOI";
            this.lvPOI.Size = new System.Drawing.Size(182, 190);
            this.lvPOI.TabIndex = 8;
            this.lvPOI.UseCompatibleStateImageBehavior = false;
            this.lvPOI.View = System.Windows.Forms.View.List;
            this.lvPOI.SelectedIndexChanged += new System.EventHandler(this.lvPOI_SelectedIndexChanged);
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtTemplateName.Location = new System.Drawing.Point(425, 52);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(182, 29);
            this.txtTemplateName.TabIndex = 9;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblName.Location = new System.Drawing.Point(425, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 24);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name";
            // 
            // Templates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 591);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.lvPOI);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnRemoveFile);
            this.Name = "Templates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Templater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRemoveFile;
        private Emerson.Cookstown.Controls.ImageBox pbImage;
        private System.Windows.Forms.ListView lvPOI;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.Label lblName;
    }
}

