namespace PDFRipperWinFormApp
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.lblStep1Title = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.pStep1 = new System.Windows.Forms.Panel();
            this.btnNextStep2 = new System.Windows.Forms.Button();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pProgress = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbProgressShow = new System.Windows.Forms.PictureBox();
            this.pProgressInner = new System.Windows.Forms.Panel();
            this.lvProgress = new System.Windows.Forms.ListView();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lvTemplates = new System.Windows.Forms.ListView();
            this.lblStep2Title = new System.Windows.Forms.Label();
            this.btnRemoveTemplate = new System.Windows.Forms.Button();
            this.btnAddTemplate = new System.Windows.Forms.Button();
            this.btnNextStep3 = new System.Windows.Forms.Button();
            this.pStep2 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.pStep1.SuspendLayout();
            this.pProgress.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgressShow)).BeginInit();
            this.pProgressInner.SuspendLayout();
            this.pStep2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddFile
            // 
            this.btnAddFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(209)))), ((int)(((byte)(153)))));
            this.btnAddFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddFile.Location = new System.Drawing.Point(3, 164);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(88, 30);
            this.btnAddFile.TabIndex = 0;
            this.btnAddFile.Text = "Add";
            this.btnAddFile.UseVisualStyleBackColor = false;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(172)))), ((int)(((byte)(189)))));
            this.btnRemoveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRemoveFile.Location = new System.Drawing.Point(97, 164);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(88, 30);
            this.btnRemoveFile.TabIndex = 2;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.UseVisualStyleBackColor = false;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // lvFiles
            // 
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(3, 61);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(182, 97);
            this.lvFiles.TabIndex = 3;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.List;
            // 
            // lblStep1Title
            // 
            this.lblStep1Title.AutoSize = true;
            this.lblStep1Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1Title.Location = new System.Drawing.Point(-1, 38);
            this.lblStep1Title.Name = "lblStep1Title";
            this.lblStep1Title.Size = new System.Drawing.Size(63, 20);
            this.lblStep1Title.TabIndex = 4;
            this.lblStep1Title.Text = "File List";
            // 
            // btnSplit
            // 
            this.btnSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(163)))));
            this.btnSplit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSplit.Location = new System.Drawing.Point(97, 211);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(88, 30);
            this.btnSplit.TabIndex = 6;
            this.btnSplit.Text = "Split!";
            this.btnSplit.UseVisualStyleBackColor = false;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // pStep1
            // 
            this.pStep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(176)))));
            this.pStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pStep1.Controls.Add(this.btnNextStep2);
            this.pStep1.Controls.Add(this.lblStep1);
            this.pStep1.Controls.Add(this.lblStep1Title);
            this.pStep1.Controls.Add(this.btnAddFile);
            this.pStep1.Controls.Add(this.btnRemoveFile);
            this.pStep1.Controls.Add(this.lvFiles);
            this.pStep1.Location = new System.Drawing.Point(7, 12);
            this.pStep1.Name = "pStep1";
            this.pStep1.Size = new System.Drawing.Size(190, 246);
            this.pStep1.TabIndex = 7;
            // 
            // btnNextStep2
            // 
            this.btnNextStep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(163)))));
            this.btnNextStep2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNextStep2.Location = new System.Drawing.Point(4, 211);
            this.btnNextStep2.Name = "btnNextStep2";
            this.btnNextStep2.Size = new System.Drawing.Size(88, 30);
            this.btnNextStep2.TabIndex = 8;
            this.btnNextStep2.Text = "Next";
            this.btnNextStep2.UseVisualStyleBackColor = false;
            this.btnNextStep2.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // lblStep1
            // 
            this.lblStep1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1.Location = new System.Drawing.Point(0, 0);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(188, 27);
            this.lblStep1.TabIndex = 7;
            this.lblStep1.Text = "Step 1";
            this.lblStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep1.Click += new System.EventHandler(this.lblStep_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Progress...";
            // 
            // pProgress
            // 
            this.pProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(176)))));
            this.pProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pProgress.Controls.Add(this.panel1);
            this.pProgress.Controls.Add(this.pProgressInner);
            this.pProgress.Controls.Add(this.label2);
            this.pProgress.Location = new System.Drawing.Point(-1, 403);
            this.pProgress.Name = "pProgress";
            this.pProgress.Size = new System.Drawing.Size(838, 98);
            this.pProgress.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbProgressShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(799, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(37, 26);
            this.panel1.TabIndex = 10;
            // 
            // pbProgressShow
            // 
            this.pbProgressShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProgressShow.Image = ((System.Drawing.Image)(resources.GetObject("pbProgressShow.Image")));
            this.pbProgressShow.Location = new System.Drawing.Point(0, 0);
            this.pbProgressShow.Name = "pbProgressShow";
            this.pbProgressShow.Size = new System.Drawing.Size(37, 26);
            this.pbProgressShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProgressShow.TabIndex = 0;
            this.pbProgressShow.TabStop = false;
            this.pbProgressShow.Click += new System.EventHandler(this.pbProgressShow_Click);
            // 
            // pProgressInner
            // 
            this.pProgressInner.BackColor = System.Drawing.Color.Gray;
            this.pProgressInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pProgressInner.Controls.Add(this.lvProgress);
            this.pProgressInner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pProgressInner.Location = new System.Drawing.Point(0, 26);
            this.pProgressInner.Name = "pProgressInner";
            this.pProgressInner.Size = new System.Drawing.Size(836, 70);
            this.pProgressInner.TabIndex = 9;
            // 
            // lvProgress
            // 
            this.lvProgress.BackColor = System.Drawing.Color.LightGray;
            this.lvProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProgress.HideSelection = false;
            this.lvProgress.Location = new System.Drawing.Point(0, 0);
            this.lvProgress.Name = "lvProgress";
            this.lvProgress.Size = new System.Drawing.Size(834, 68);
            this.lvProgress.TabIndex = 3;
            this.lvProgress.UseCompatibleStateImageBehavior = false;
            this.lvProgress.View = System.Windows.Forms.View.List;
            // 
            // lblStep2
            // 
            this.lblStep2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2.Location = new System.Drawing.Point(0, 0);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(188, 27);
            this.lblStep2.TabIndex = 7;
            this.lblStep2.Text = "Step 2";
            this.lblStep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep2.Click += new System.EventHandler(this.lblStep_Click);
            // 
            // lvTemplates
            // 
            this.lvTemplates.HideSelection = false;
            this.lvTemplates.Location = new System.Drawing.Point(4, 61);
            this.lvTemplates.Name = "lvTemplates";
            this.lvTemplates.Size = new System.Drawing.Size(182, 97);
            this.lvTemplates.TabIndex = 8;
            this.lvTemplates.UseCompatibleStateImageBehavior = false;
            this.lvTemplates.View = System.Windows.Forms.View.List;
            // 
            // lblStep2Title
            // 
            this.lblStep2Title.AutoSize = true;
            this.lblStep2Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2Title.Location = new System.Drawing.Point(0, 38);
            this.lblStep2Title.Name = "lblStep2Title";
            this.lblStep2Title.Size = new System.Drawing.Size(104, 20);
            this.lblStep2Title.TabIndex = 9;
            this.lblStep2Title.Text = "Template List";
            // 
            // btnRemoveTemplate
            // 
            this.btnRemoveTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(172)))), ((int)(((byte)(189)))));
            this.btnRemoveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRemoveTemplate.Location = new System.Drawing.Point(98, 164);
            this.btnRemoveTemplate.Name = "btnRemoveTemplate";
            this.btnRemoveTemplate.Size = new System.Drawing.Size(88, 30);
            this.btnRemoveTemplate.TabIndex = 10;
            this.btnRemoveTemplate.Text = "Remove File";
            this.btnRemoveTemplate.UseVisualStyleBackColor = false;
            // 
            // btnAddTemplate
            // 
            this.btnAddTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(209)))), ((int)(((byte)(153)))));
            this.btnAddTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddTemplate.Location = new System.Drawing.Point(4, 164);
            this.btnAddTemplate.Name = "btnAddTemplate";
            this.btnAddTemplate.Size = new System.Drawing.Size(88, 30);
            this.btnAddTemplate.TabIndex = 9;
            this.btnAddTemplate.Text = "Add";
            this.btnAddTemplate.UseVisualStyleBackColor = false;
            // 
            // btnNextStep3
            // 
            this.btnNextStep3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(163)))));
            this.btnNextStep3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStep3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNextStep3.Location = new System.Drawing.Point(98, 211);
            this.btnNextStep3.Name = "btnNextStep3";
            this.btnNextStep3.Size = new System.Drawing.Size(88, 30);
            this.btnNextStep3.TabIndex = 9;
            this.btnNextStep3.Text = "Next";
            this.btnNextStep3.UseVisualStyleBackColor = false;
            this.btnNextStep3.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // pStep2
            // 
            this.pStep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(182)))), ((int)(((byte)(216)))));
            this.pStep2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pStep2.Controls.Add(this.btnNextStep3);
            this.pStep2.Controls.Add(this.btnAddTemplate);
            this.pStep2.Controls.Add(this.btnRemoveTemplate);
            this.pStep2.Controls.Add(this.lblStep2Title);
            this.pStep2.Controls.Add(this.lvTemplates);
            this.pStep2.Controls.Add(this.lblStep2);
            this.pStep2.Location = new System.Drawing.Point(203, 12);
            this.pStep2.Name = "pStep2";
            this.pStep2.Size = new System.Drawing.Size(190, 246);
            this.pStep2.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(209)))), ((int)(((byte)(153)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblStep3);
            this.panel2.Controls.Add(this.btnSplit);
            this.panel2.Location = new System.Drawing.Point(399, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 246);
            this.panel2.TabIndex = 11;
            // 
            // lblStep3
            // 
            this.lblStep3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStep3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep3.Location = new System.Drawing.Point(0, 0);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(188, 27);
            this.lblStep3.TabIndex = 7;
            this.lblStep3.Text = "Step 3";
            this.lblStep3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep3.Click += new System.EventHandler(this.lblStep_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 429);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pStep2);
            this.Controls.Add(this.pProgress);
            this.Controls.Add(this.pStep1);
            this.Name = "Main";
            this.Text = "Imager";
            this.Load += new System.EventHandler(this.Main_Load);
            this.pStep1.ResumeLayout(false);
            this.pStep1.PerformLayout();
            this.pProgress.ResumeLayout(false);
            this.pProgress.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProgressShow)).EndInit();
            this.pProgressInner.ResumeLayout(false);
            this.pStep2.ResumeLayout(false);
            this.pStep2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.Label lblStep1Title;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Panel pStep1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pProgress;
        private System.Windows.Forms.Panel pProgressInner;
        private System.Windows.Forms.ListView lvProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbProgressShow;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Button btnNextStep2;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.ListView lvTemplates;
        private System.Windows.Forms.Label lblStep2Title;
        private System.Windows.Forms.Button btnRemoveTemplate;
        private System.Windows.Forms.Button btnAddTemplate;
        private System.Windows.Forms.Button btnNextStep3;
        private System.Windows.Forms.Panel pStep2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStep3;
    }
}

