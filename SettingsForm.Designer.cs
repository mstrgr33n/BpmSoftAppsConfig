namespace CreatioManagmentTools
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.SelectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RedisPort = new System.Windows.Forms.NumericUpDown();
            this.RedisHostTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ConStrTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DefaultPortNumeric = new System.Windows.Forms.NumericUpDown();
            this.BaseSiteNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.InstallFilesUrlTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BaseUrlTextBox = new System.Windows.Forms.TextBox();
            this.TempPathTextBox = new System.Windows.Forms.TextBox();
            this.AppsPathTextBox = new System.Windows.Forms.TextBox();
            this.AppPathBtn = new System.Windows.Forms.Button();
            this.TempPathBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.UseWindowsAuth = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.InitialCatalogTextBox = new System.Windows.Forms.Label();
            this.DataSourceTextBox = new System.Windows.Forms.Label();
            this.MSSQLPasswordTextBox = new System.Windows.Forms.TextBox();
            this.MSSQLUserIDTextBox = new System.Windows.Forms.TextBox();
            this.IntegratedSecurityTextBox = new System.Windows.Forms.TextBox();
            this.MSSQLInitialCatalogTextBox = new System.Windows.Forms.TextBox();
            this.MSSQLDataSourceTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SqlPathBtn = new System.Windows.Forms.Button();
            this.SQLConnStrTextBox = new System.Windows.Forms.TextBox();
            this.SqlPathTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PSQLPathBtn = new System.Windows.Forms.Button();
            this.PSQLPathTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.PSQLPortNumeric = new System.Windows.Forms.NumericUpDown();
            this.PSQLPasswordTextBox = new System.Windows.Forms.TextBox();
            this.PSQLUserIDTextBox = new System.Windows.Forms.TextBox();
            this.PSQLServerTextBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.PSQLConnectionSctringTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CancelTSBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SaveTSBtn = new System.Windows.Forms.ToolStripButton();
            this.label21 = new System.Windows.Forms.Label();
            this.InstallDemoFilesUrlTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedisPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultPortNumeric)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PSQLPortNumeric)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(811, 291);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.InstallDemoFilesUrlTextBox);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.RedisPort);
            this.tabPage1.Controls.Add(this.RedisHostTextBox);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.ConStrTextBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.DefaultPortNumeric);
            this.tabPage1.Controls.Add(this.BaseSiteNameTextBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.InstallFilesUrlTextBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.BaseUrlTextBox);
            this.tabPage1.Controls.Add(this.TempPathTextBox);
            this.tabPage1.Controls.Add(this.AppsPathTextBox);
            this.tabPage1.Controls.Add(this.AppPathBtn);
            this.tabPage1.Controls.Add(this.TempPathBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(803, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RedisPort
            // 
            this.RedisPort.Location = new System.Drawing.Point(104, 211);
            this.RedisPort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.RedisPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RedisPort.Name = "RedisPort";
            this.RedisPort.Size = new System.Drawing.Size(120, 20);
            this.RedisPort.TabIndex = 44;
            this.RedisPort.Value = new decimal(new int[] {
            6379,
            0,
            0,
            0});
            // 
            // RedisHostTextBox
            // 
            this.RedisHostTextBox.Location = new System.Drawing.Point(349, 210);
            this.RedisHostTextBox.Name = "RedisHostTextBox";
            this.RedisHostTextBox.Size = new System.Drawing.Size(230, 20);
            this.RedisHostTextBox.TabIndex = 43;
            this.RedisHostTextBox.Text = "localhost";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(283, 217);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Redis Host";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 213);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "Redis Port";
            // 
            // ConStrTextBox
            // 
            this.ConStrTextBox.Location = new System.Drawing.Point(348, 171);
            this.ConStrTextBox.Name = "ConStrTextBox";
            this.ConStrTextBox.Size = new System.Drawing.Size(230, 20);
            this.ConStrTextBox.TabIndex = 40;
            this.ConStrTextBox.Text = "ConnectionStrings.config";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(246, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 26);
            this.label7.TabIndex = 39;
            this.label7.Text = "ConnectionStrings \r\nFile Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DefaultPortNumeric
            // 
            this.DefaultPortNumeric.Location = new System.Drawing.Point(104, 171);
            this.DefaultPortNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.DefaultPortNumeric.Minimum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.DefaultPortNumeric.Name = "DefaultPortNumeric";
            this.DefaultPortNumeric.Size = new System.Drawing.Size(120, 20);
            this.DefaultPortNumeric.TabIndex = 30;
            this.DefaultPortNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // BaseSiteNameTextBox
            // 
            this.BaseSiteNameTextBox.Location = new System.Drawing.Point(104, 134);
            this.BaseSiteNameTextBox.Name = "BaseSiteNameTextBox";
            this.BaseSiteNameTextBox.Size = new System.Drawing.Size(600, 20);
            this.BaseSiteNameTextBox.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Base Site Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Base Site Name";
            // 
            // InstallFilesUrlTextBox
            // 
            this.InstallFilesUrlTextBox.Location = new System.Drawing.Point(104, 102);
            this.InstallFilesUrlTextBox.Name = "InstallFilesUrlTextBox";
            this.InstallFilesUrlTextBox.Size = new System.Drawing.Size(238, 20);
            this.InstallFilesUrlTextBox.TabIndex = 27;
            this.InstallFilesUrlTextBox.Text = "/Release/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Install Files Url";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Base Url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Temp Path";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Creatio Apps Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BaseUrlTextBox
            // 
            this.BaseUrlTextBox.Location = new System.Drawing.Point(104, 70);
            this.BaseUrlTextBox.Name = "BaseUrlTextBox";
            this.BaseUrlTextBox.Size = new System.Drawing.Size(600, 20);
            this.BaseUrlTextBox.TabIndex = 26;
            this.BaseUrlTextBox.Text = "https://ftp.bpmonline.com";
            // 
            // TempPathTextBox
            // 
            this.TempPathTextBox.Location = new System.Drawing.Point(104, 38);
            this.TempPathTextBox.Name = "TempPathTextBox";
            this.TempPathTextBox.Size = new System.Drawing.Size(600, 20);
            this.TempPathTextBox.TabIndex = 25;
            // 
            // AppsPathTextBox
            // 
            this.AppsPathTextBox.Location = new System.Drawing.Point(104, 6);
            this.AppsPathTextBox.Name = "AppsPathTextBox";
            this.AppsPathTextBox.Size = new System.Drawing.Size(600, 20);
            this.AppsPathTextBox.TabIndex = 23;
            // 
            // AppPathBtn
            // 
            this.AppPathBtn.Location = new System.Drawing.Point(710, 5);
            this.AppPathBtn.Name = "AppPathBtn";
            this.AppPathBtn.Size = new System.Drawing.Size(75, 23);
            this.AppPathBtn.TabIndex = 28;
            this.AppPathBtn.Text = "Select Path";
            this.AppPathBtn.UseVisualStyleBackColor = true;
            this.AppPathBtn.Click += new System.EventHandler(this.AppPathBtn_Click);
            // 
            // TempPathBtn
            // 
            this.TempPathBtn.Location = new System.Drawing.Point(710, 37);
            this.TempPathBtn.Name = "TempPathBtn";
            this.TempPathBtn.Size = new System.Drawing.Size(75, 23);
            this.TempPathBtn.TabIndex = 24;
            this.TempPathBtn.Text = "Select Path";
            this.TempPathBtn.UseVisualStyleBackColor = true;
            this.TempPathBtn.Click += new System.EventHandler(this.TempPathBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.UseWindowsAuth);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.InitialCatalogTextBox);
            this.tabPage2.Controls.Add(this.DataSourceTextBox);
            this.tabPage2.Controls.Add(this.MSSQLPasswordTextBox);
            this.tabPage2.Controls.Add(this.MSSQLUserIDTextBox);
            this.tabPage2.Controls.Add(this.IntegratedSecurityTextBox);
            this.tabPage2.Controls.Add(this.MSSQLInitialCatalogTextBox);
            this.tabPage2.Controls.Add(this.MSSQLDataSourceTextBox);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.SqlPathBtn);
            this.tabPage2.Controls.Add(this.SQLConnStrTextBox);
            this.tabPage2.Controls.Add(this.SqlPathTextBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(803, 265);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MS SQL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UseWindowsAuth
            // 
            this.UseWindowsAuth.AutoSize = true;
            this.UseWindowsAuth.Checked = true;
            this.UseWindowsAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseWindowsAuth.Location = new System.Drawing.Point(412, 186);
            this.UseWindowsAuth.Name = "UseWindowsAuth";
            this.UseWindowsAuth.Size = new System.Drawing.Size(116, 17);
            this.UseWindowsAuth.TabIndex = 61;
            this.UseWindowsAuth.Text = "Use Windows auth";
            this.UseWindowsAuth.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 60;
            this.label12.Text = "Windows auth";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(353, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "User ID";
            // 
            // InitialCatalogTextBox
            // 
            this.InitialCatalogTextBox.AutoSize = true;
            this.InitialCatalogTextBox.Location = new System.Drawing.Point(32, 114);
            this.InitialCatalogTextBox.Name = "InitialCatalogTextBox";
            this.InitialCatalogTextBox.Size = new System.Drawing.Size(70, 13);
            this.InitialCatalogTextBox.TabIndex = 57;
            this.InitialCatalogTextBox.Text = "Initial Catalog";
            // 
            // DataSourceTextBox
            // 
            this.DataSourceTextBox.AutoSize = true;
            this.DataSourceTextBox.Location = new System.Drawing.Point(32, 78);
            this.DataSourceTextBox.Name = "DataSourceTextBox";
            this.DataSourceTextBox.Size = new System.Drawing.Size(67, 13);
            this.DataSourceTextBox.TabIndex = 56;
            this.DataSourceTextBox.Text = "Data Source";
            // 
            // MSSQLPasswordTextBox
            // 
            this.MSSQLPasswordTextBox.Location = new System.Drawing.Point(412, 146);
            this.MSSQLPasswordTextBox.Name = "MSSQLPasswordTextBox";
            this.MSSQLPasswordTextBox.Size = new System.Drawing.Size(233, 20);
            this.MSSQLPasswordTextBox.TabIndex = 55;
            // 
            // MSSQLUserIDTextBox
            // 
            this.MSSQLUserIDTextBox.Location = new System.Drawing.Point(105, 146);
            this.MSSQLUserIDTextBox.Name = "MSSQLUserIDTextBox";
            this.MSSQLUserIDTextBox.Size = new System.Drawing.Size(205, 20);
            this.MSSQLUserIDTextBox.TabIndex = 54;
            // 
            // IntegratedSecurityTextBox
            // 
            this.IntegratedSecurityTextBox.Location = new System.Drawing.Point(105, 184);
            this.IntegratedSecurityTextBox.Name = "IntegratedSecurityTextBox";
            this.IntegratedSecurityTextBox.Size = new System.Drawing.Size(280, 20);
            this.IntegratedSecurityTextBox.TabIndex = 53;
            this.IntegratedSecurityTextBox.Text = "Integrated Security=SSPI";
            // 
            // MSSQLInitialCatalogTextBox
            // 
            this.MSSQLInitialCatalogTextBox.Location = new System.Drawing.Point(105, 111);
            this.MSSQLInitialCatalogTextBox.Name = "MSSQLInitialCatalogTextBox";
            this.MSSQLInitialCatalogTextBox.Size = new System.Drawing.Size(600, 20);
            this.MSSQLInitialCatalogTextBox.TabIndex = 52;
            this.MSSQLInitialCatalogTextBox.Text = "master";
            // 
            // MSSQLDataSourceTextBox
            // 
            this.MSSQLDataSourceTextBox.Location = new System.Drawing.Point(105, 75);
            this.MSSQLDataSourceTextBox.Name = "MSSQLDataSourceTextBox";
            this.MSSQLDataSourceTextBox.Size = new System.Drawing.Size(600, 20);
            this.MSSQLDataSourceTextBox.TabIndex = 51;
            this.MSSQLDataSourceTextBox.Text = "localhost";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 26);
            this.label9.TabIndex = 50;
            this.label9.Text = "MSSQL \r\nconnection string";
            // 
            // SqlPathBtn
            // 
            this.SqlPathBtn.Location = new System.Drawing.Point(711, 5);
            this.SqlPathBtn.Name = "SqlPathBtn";
            this.SqlPathBtn.Size = new System.Drawing.Size(75, 23);
            this.SqlPathBtn.TabIndex = 49;
            this.SqlPathBtn.Text = "Select Path";
            this.SqlPathBtn.UseVisualStyleBackColor = true;
            this.SqlPathBtn.Click += new System.EventHandler(this.SqlPathBtn_Click);
            // 
            // SQLConnStrTextBox
            // 
            this.SQLConnStrTextBox.Location = new System.Drawing.Point(105, 38);
            this.SQLConnStrTextBox.Name = "SQLConnStrTextBox";
            this.SQLConnStrTextBox.Size = new System.Drawing.Size(600, 20);
            this.SQLConnStrTextBox.TabIndex = 48;
            this.SQLConnStrTextBox.Text = "Data Source={0};Initial Catalog={1};{2};MultipleActiveResultSets=True;Pooling=tru" +
    "e;Max Pool Size=100";
            // 
            // SqlPathTextBox
            // 
            this.SqlPathTextBox.Location = new System.Drawing.Point(105, 6);
            this.SqlPathTextBox.Name = "SqlPathTextBox";
            this.SqlPathTextBox.Size = new System.Drawing.Size(600, 20);
            this.SqlPathTextBox.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Sql DB Path";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.PSQLPathBtn);
            this.tabPage3.Controls.Add(this.PSQLPathTextBox);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.PSQLPortNumeric);
            this.tabPage3.Controls.Add(this.PSQLPasswordTextBox);
            this.tabPage3.Controls.Add(this.PSQLUserIDTextBox);
            this.tabPage3.Controls.Add(this.PSQLServerTextBox);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.PSQLConnectionSctringTextBox);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(803, 265);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PostgreSQL";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // PSQLPathBtn
            // 
            this.PSQLPathBtn.Location = new System.Drawing.Point(680, 182);
            this.PSQLPathBtn.Name = "PSQLPathBtn";
            this.PSQLPathBtn.Size = new System.Drawing.Size(75, 23);
            this.PSQLPathBtn.TabIndex = 15;
            this.PSQLPathBtn.Text = "Select path";
            this.PSQLPathBtn.UseVisualStyleBackColor = true;
            this.PSQLPathBtn.Click += new System.EventHandler(this.PSQLPathBtn_Click);
            // 
            // PSQLPathTextBox
            // 
            this.PSQLPathTextBox.Location = new System.Drawing.Point(143, 183);
            this.PSQLPathTextBox.Name = "PSQLPathTextBox";
            this.PSQLPathTextBox.Size = new System.Drawing.Size(512, 20);
            this.PSQLPathTextBox.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 187);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "PostgreSQL Path";
            // 
            // PSQLPortNumeric
            // 
            this.PSQLPortNumeric.Location = new System.Drawing.Point(143, 79);
            this.PSQLPortNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.PSQLPortNumeric.Name = "PSQLPortNumeric";
            this.PSQLPortNumeric.Size = new System.Drawing.Size(120, 20);
            this.PSQLPortNumeric.TabIndex = 12;
            this.PSQLPortNumeric.Value = new decimal(new int[] {
            5432,
            0,
            0,
            0});
            // 
            // PSQLPasswordTextBox
            // 
            this.PSQLPasswordTextBox.Location = new System.Drawing.Point(143, 147);
            this.PSQLPasswordTextBox.Name = "PSQLPasswordTextBox";
            this.PSQLPasswordTextBox.Size = new System.Drawing.Size(239, 20);
            this.PSQLPasswordTextBox.TabIndex = 10;
            // 
            // PSQLUserIDTextBox
            // 
            this.PSQLUserIDTextBox.Location = new System.Drawing.Point(143, 113);
            this.PSQLUserIDTextBox.Name = "PSQLUserIDTextBox";
            this.PSQLUserIDTextBox.Size = new System.Drawing.Size(239, 20);
            this.PSQLUserIDTextBox.TabIndex = 9;
            // 
            // PSQLServerTextBox
            // 
            this.PSQLServerTextBox.Location = new System.Drawing.Point(143, 45);
            this.PSQLServerTextBox.Name = "PSQLServerTextBox";
            this.PSQLServerTextBox.Size = new System.Drawing.Size(239, 20);
            this.PSQLServerTextBox.TabIndex = 7;
            this.PSQLServerTextBox.Text = "localhost";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(53, 151);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Password";
            // 
            // PSQLConnectionSctringTextBox
            // 
            this.PSQLConnectionSctringTextBox.Location = new System.Drawing.Point(143, 11);
            this.PSQLConnectionSctringTextBox.Name = "PSQLConnectionSctringTextBox";
            this.PSQLConnectionSctringTextBox.Size = new System.Drawing.Size(612, 20);
            this.PSQLConnectionSctringTextBox.TabIndex = 5;
            this.PSQLConnectionSctringTextBox.Text = "Server={0};Port={1};Database={2};User ID={3};password={4};Timeout=500; CommandTim" +
    "eout=400;MaxPoolSize=1024;";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(63, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "User ID";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(80, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Port";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(68, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Server";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 26);
            this.label15.TabIndex = 0;
            this.label15.Text = "PostgreSQL\r\nconnection string";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelTSBtn,
            this.toolStripLabel1,
            this.SaveTSBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 266);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(811, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CancelTSBtn
            // 
            this.CancelTSBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CancelTSBtn.Image = ((System.Drawing.Image)(resources.GetObject("CancelTSBtn.Image")));
            this.CancelTSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelTSBtn.Name = "CancelTSBtn";
            this.CancelTSBtn.Size = new System.Drawing.Size(63, 22);
            this.CancelTSBtn.Text = "Cancel";
            this.CancelTSBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(19, 22);
            this.toolStripLabel1.Text = "    ";
            // 
            // SaveTSBtn
            // 
            this.SaveTSBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SaveTSBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveTSBtn.Image")));
            this.SaveTSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveTSBtn.Name = "SaveTSBtn";
            this.SaveTSBtn.Size = new System.Drawing.Size(51, 22);
            this.SaveTSBtn.Text = "Save";
            this.SaveTSBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(355, 106);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 13);
            this.label21.TabIndex = 45;
            this.label21.Text = "Install Demo Files Url";
            // 
            // InstallDemoFilesUrlTextBox
            // 
            this.InstallDemoFilesUrlTextBox.Location = new System.Drawing.Point(466, 102);
            this.InstallDemoFilesUrlTextBox.Name = "InstallDemoFilesUrlTextBox";
            this.InstallDemoFilesUrlTextBox.Size = new System.Drawing.Size(238, 20);
            this.InstallDemoFilesUrlTextBox.TabIndex = 46;
            this.InstallDemoFilesUrlTextBox.Text = "/ReleaseDemo/";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 291);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedisPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultPortNumeric)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PSQLPortNumeric)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog SelectFolderDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox ConStrTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown DefaultPortNumeric;
        private System.Windows.Forms.TextBox BaseSiteNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox InstallFilesUrlTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BaseUrlTextBox;
        private System.Windows.Forms.TextBox TempPathTextBox;
        private System.Windows.Forms.TextBox AppsPathTextBox;
        private System.Windows.Forms.Button AppPathBtn;
        private System.Windows.Forms.Button TempPathBtn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button SqlPathBtn;
        private System.Windows.Forms.TextBox SQLConnStrTextBox;
        private System.Windows.Forms.TextBox SqlPathTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton CancelTSBtn;
        private System.Windows.Forms.ToolStripButton SaveTSBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox MSSQLPasswordTextBox;
        private System.Windows.Forms.TextBox MSSQLUserIDTextBox;
        private System.Windows.Forms.TextBox IntegratedSecurityTextBox;
        private System.Windows.Forms.TextBox MSSQLInitialCatalogTextBox;
        private System.Windows.Forms.TextBox MSSQLDataSourceTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label InitialCatalogTextBox;
        private System.Windows.Forms.Label DataSourceTextBox;
        private System.Windows.Forms.CheckBox UseWindowsAuth;
        private System.Windows.Forms.NumericUpDown RedisPort;
        private System.Windows.Forms.TextBox RedisHostTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown PSQLPortNumeric;
        private System.Windows.Forms.TextBox PSQLPasswordTextBox;
        private System.Windows.Forms.TextBox PSQLUserIDTextBox;
        private System.Windows.Forms.TextBox PSQLServerTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox PSQLConnectionSctringTextBox;
        private System.Windows.Forms.Button PSQLPathBtn;
        private System.Windows.Forms.TextBox PSQLPathTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox InstallDemoFilesUrlTextBox;
        private System.Windows.Forms.Label label21;
    }
}