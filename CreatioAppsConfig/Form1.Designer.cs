
namespace CreatioAppsConfig
{
    partial class AppsConfigs
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppsConfigs));
            this.PathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.PathButton = new System.Windows.Forms.Button();
            this.PathText = new System.Windows.Forms.TextBox();
            this.ConfigFileGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.IISSiteGridView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.APPPOOLGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.WorkingSiteGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigFileGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IISSiteGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.APPPOOLGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkingSiteGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PathButton
            // 
            this.PathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PathButton.Location = new System.Drawing.Point(1027, 12);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(75, 23);
            this.PathButton.TabIndex = 0;
            this.PathButton.Text = "Path";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // PathText
            // 
            this.PathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathText.Enabled = false;
            this.PathText.Location = new System.Drawing.Point(12, 12);
            this.PathText.Name = "PathText";
            this.PathText.Size = new System.Drawing.Size(1009, 23);
            this.PathText.TabIndex = 1;
            // 
            // ConfigFileGridView
            // 
            this.ConfigFileGridView.AllowUserToAddRows = false;
            this.ConfigFileGridView.AllowUserToDeleteRows = false;
            this.ConfigFileGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ConfigFileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConfigFileGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigFileGridView.Location = new System.Drawing.Point(3, 3);
            this.ConfigFileGridView.Name = "ConfigFileGridView";
            this.ConfigFileGridView.ReadOnly = true;
            this.ConfigFileGridView.RowTemplate.Height = 25;
            this.ConfigFileGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConfigFileGridView.Size = new System.Drawing.Size(1076, 692);
            this.ConfigFileGridView.TabIndex = 3;
            this.ConfigFileGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1090, 726);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ConfigFileGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1082, 698);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config Files Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.IISSiteGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1082, 698);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "IIS Site Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // IISSiteGridView
            // 
            this.IISSiteGridView.AllowUserToAddRows = false;
            this.IISSiteGridView.AllowUserToDeleteRows = false;
            this.IISSiteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IISSiteGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IISSiteGridView.Location = new System.Drawing.Point(3, 3);
            this.IISSiteGridView.Name = "IISSiteGridView";
            this.IISSiteGridView.ReadOnly = true;
            this.IISSiteGridView.RowTemplate.Height = 25;
            this.IISSiteGridView.Size = new System.Drawing.Size(1076, 692);
            this.IISSiteGridView.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.APPPOOLGridView);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1082, 698);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "IIS Pool";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // APPPOOLGridView
            // 
            this.APPPOOLGridView.AllowUserToAddRows = false;
            this.APPPOOLGridView.AllowUserToDeleteRows = false;
            this.APPPOOLGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.APPPOOLGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.APPPOOLGridView.Location = new System.Drawing.Point(3, 3);
            this.APPPOOLGridView.Name = "APPPOOLGridView";
            this.APPPOOLGridView.ReadOnly = true;
            this.APPPOOLGridView.RowTemplate.Height = 25;
            this.APPPOOLGridView.Size = new System.Drawing.Size(1076, 692);
            this.APPPOOLGridView.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.WorkingSiteGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1082, 698);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Working Site";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // WorkingSiteGridView
            // 
            this.WorkingSiteGridView.AllowUserToAddRows = false;
            this.WorkingSiteGridView.AllowUserToDeleteRows = false;
            this.WorkingSiteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkingSiteGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingSiteGridView.Location = new System.Drawing.Point(3, 3);
            this.WorkingSiteGridView.Name = "WorkingSiteGridView";
            this.WorkingSiteGridView.ReadOnly = true;
            this.WorkingSiteGridView.RowTemplate.Height = 25;
            this.WorkingSiteGridView.Size = new System.Drawing.Size(1076, 692);
            this.WorkingSiteGridView.TabIndex = 0;
            // 
            // AppsConfigs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 769);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.PathText);
            this.Controls.Add(this.PathButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppsConfigs";
            this.Text = "Creatio Apps Config";
            this.Load += new System.EventHandler(this.AppsConfigs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigFileGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IISSiteGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.APPPOOLGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkingSiteGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog PathDialog;
        private System.Windows.Forms.Button PathButton;
        private System.Windows.Forms.TextBox PathText;
        private System.Windows.Forms.DataGridView ConfigFileGridView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView IISSiteGridView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView WorkingSiteGridView;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView APPPOOLGridView;
    }
}

