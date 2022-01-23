namespace CreatioAppsConfig
{
    partial class CreateApplication
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
            this.VersionListBox = new System.Windows.Forms.ListBox();
            this.BundleListBox = new System.Windows.Forms.ListBox();
            this.TempPathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.TempPathText = new System.Windows.Forms.TextBox();
            this.TempPathButton = new System.Windows.Forms.Button();
            this.ProjectNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VersionListBox
            // 
            this.VersionListBox.FormattingEnabled = true;
            this.VersionListBox.ItemHeight = 15;
            this.VersionListBox.Location = new System.Drawing.Point(12, 42);
            this.VersionListBox.Name = "VersionListBox";
            this.VersionListBox.Size = new System.Drawing.Size(168, 394);
            this.VersionListBox.TabIndex = 1;
            this.VersionListBox.SelectedIndexChanged += new System.EventHandler(this.Version_SelectedIndexChanged);
            // 
            // BundleListBox
            // 
            this.BundleListBox.FormattingEnabled = true;
            this.BundleListBox.ItemHeight = 15;
            this.BundleListBox.Location = new System.Drawing.Point(198, 42);
            this.BundleListBox.Name = "BundleListBox";
            this.BundleListBox.Size = new System.Drawing.Size(590, 394);
            this.BundleListBox.TabIndex = 2;
            // 
            // TempPathText
            // 
            this.TempPathText.Enabled = false;
            this.TempPathText.Location = new System.Drawing.Point(13, 13);
            this.TempPathText.Name = "TempPathText";
            this.TempPathText.Size = new System.Drawing.Size(661, 23);
            this.TempPathText.TabIndex = 3;
            // 
            // TempPathButton
            // 
            this.TempPathButton.Location = new System.Drawing.Point(681, 13);
            this.TempPathButton.Name = "TempPathButton";
            this.TempPathButton.Size = new System.Drawing.Size(107, 23);
            this.TempPathButton.TabIndex = 4;
            this.TempPathButton.Text = "Temp path";
            this.TempPathButton.UseVisualStyleBackColor = true;
            this.TempPathButton.Click += new System.EventHandler(this.TempPathButton_Click);
            // 
            // ProjectNameBox
            // 
            this.ProjectNameBox.Location = new System.Drawing.Point(95, 446);
            this.ProjectNameBox.Name = "ProjectNameBox";
            this.ProjectNameBox.Size = new System.Drawing.Size(358, 23);
            this.ProjectNameBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Project name";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(608, 451);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 7;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(713, 451);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // CreateApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProjectNameBox);
            this.Controls.Add(this.TempPathButton);
            this.Controls.Add(this.TempPathText);
            this.Controls.Add(this.BundleListBox);
            this.Controls.Add(this.VersionListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateApplication";
            this.Text = "CreateApplication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateApplication_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox VersionListBox;
        private System.Windows.Forms.ListBox BundleListBox;
        private System.Windows.Forms.FolderBrowserDialog TempPathDialog;
        private System.Windows.Forms.TextBox TempPathText;
        private System.Windows.Forms.Button TempPathButton;
        private System.Windows.Forms.TextBox ProjectNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}