namespace CreatioManagmentTools
{
    partial class DownloadAndCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadAndCreate));
            ProcessLogBox = new System.Windows.Forms.ListBox();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ProjectTextBox = new System.Windows.Forms.TextBox();
            SiteNameTextBox = new System.Windows.Forms.TextBox();
            PortBox = new System.Windows.Forms.NumericUpDown();
            label4 = new System.Windows.Forms.Label();
            RedisDBNum = new System.Windows.Forms.NumericUpDown();
            DBPassTB = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            RegisterDomain = new System.Windows.Forms.CheckBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PortBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RedisDBNum).BeginInit();
            SuspendLayout();
            // 
            // ProcessLogBox
            // 
            ProcessLogBox.Enabled = false;
            ProcessLogBox.FormattingEnabled = true;
            ProcessLogBox.ItemHeight = 15;
            ProcessLogBox.Location = new System.Drawing.Point(0, 198);
            ProcessLogBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ProcessLogBox.Name = "ProcessLogBox";
            ProcessLogBox.Size = new System.Drawing.Size(600, 214);
            ProcessLogBox.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButton1, toolStripLabel1, toolStripButton2, toolStripProgressBar1, toolStripLabel2 });
            toolStrip1.Location = new System.Drawing.Point(0, 417);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(601, 28);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(56, 25);
            toolStripButton1.Text = "Close";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(19, 25);
            toolStripLabel1.Text = "    ";
            // 
            // toolStripButton2
            // 
            toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripButton2.Image = (System.Drawing.Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new System.Drawing.Size(51, 25);
            toolStripButton2.Text = "Start";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new System.Drawing.Size(117, 25);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new System.Drawing.Size(0, 25);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 10);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(79, 15);
            label1.TabIndex = 2;
            label1.Text = "Project Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(31, 51);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 15);
            label2.TabIndex = 3;
            label2.Text = "Site Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(66, 91);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(29, 15);
            label3.TabIndex = 4;
            label3.Text = "Port";
            // 
            // ProjectTextBox
            // 
            ProjectTextBox.Location = new System.Drawing.Point(113, 6);
            ProjectTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ProjectTextBox.Name = "ProjectTextBox";
            ProjectTextBox.Size = new System.Drawing.Size(308, 23);
            ProjectTextBox.TabIndex = 5;
            ProjectTextBox.TextChanged += ProjectTextBox_TextChanged;
            // 
            // SiteNameTextBox
            // 
            SiteNameTextBox.Location = new System.Drawing.Point(113, 46);
            SiteNameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SiteNameTextBox.Name = "SiteNameTextBox";
            SiteNameTextBox.Size = new System.Drawing.Size(308, 23);
            SiteNameTextBox.TabIndex = 6;
            // 
            // PortBox
            // 
            PortBox.Location = new System.Drawing.Point(113, 91);
            PortBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PortBox.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            PortBox.Minimum = new decimal(new int[] { 80, 0, 0, 0 });
            PortBox.Name = "PortBox";
            PortBox.Size = new System.Drawing.Size(140, 23);
            PortBox.TabIndex = 7;
            PortBox.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(300, 96);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(53, 15);
            label4.TabIndex = 8;
            label4.Text = "Redis DB";
            // 
            // RedisDBNum
            // 
            RedisDBNum.Location = new System.Drawing.Point(386, 91);
            RedisDBNum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RedisDBNum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            RedisDBNum.Name = "RedisDBNum";
            RedisDBNum.Size = new System.Drawing.Size(88, 23);
            RedisDBNum.TabIndex = 9;
            // 
            // DBPassTB
            // 
            DBPassTB.Location = new System.Drawing.Point(113, 136);
            DBPassTB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DBPassTB.Name = "DBPassTB";
            DBPassTB.Size = new System.Drawing.Size(160, 23);
            DBPassTB.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(41, 140);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(48, 15);
            label6.TabIndex = 13;
            label6.Text = "PG Pass";
            // 
            // RegisterDomain
            // 
            RegisterDomain.AutoSize = true;
            RegisterDomain.Location = new System.Drawing.Point(444, 48);
            RegisterDomain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RegisterDomain.Name = "RegisterDomain";
            RegisterDomain.Size = new System.Drawing.Size(131, 19);
            RegisterDomain.TabIndex = 62;
            RegisterDomain.Text = "Register subdomain";
            RegisterDomain.UseVisualStyleBackColor = true;
            // 
            // DownloadAndCreate
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(601, 445);
            Controls.Add(RegisterDomain);
            Controls.Add(label6);
            Controls.Add(DBPassTB);
            Controls.Add(RedisDBNum);
            Controls.Add(label4);
            Controls.Add(PortBox);
            Controls.Add(SiteNameTextBox);
            Controls.Add(ProjectTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Controls.Add(ProcessLogBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DownloadAndCreate";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Work...";
            Load += DownloadAndCreate_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PortBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)RedisDBNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox ProcessLogBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProjectTextBox;
        private System.Windows.Forms.TextBox SiteNameTextBox;
        private System.Windows.Forms.NumericUpDown PortBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RedisDBNum;
        private System.Windows.Forms.TextBox DBPassTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox RegisterDomain;
    }
}