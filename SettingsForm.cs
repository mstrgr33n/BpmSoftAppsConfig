using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatioManagmentTools
{
    public partial class SettingsForm : Form
    {
        internal Services services { get; set; }


        private Settings.Settings _settings;
        internal Settings.Settings settings
        { 
            get
            {
                return _settings ??  new Settings.Settings();
            }
            set 
            { 
                _settings = value; 
            }
        }

        public SettingsForm()
        {
            InitializeComponent();
            ConfigTooltip();
            AppsPathTextBox.Select();
        }

        public SettingsForm(Settings.Settings settings)
        {
            _settings = settings;
            InitializeComponent();
            ConfigTooltip();
            FillFormField();
        }

        private void FillFormField()
        {
            if (_settings != null)
            {
                AppsPathTextBox.Text = _settings.AppsPath;
                TempPathTextBox.Text = _settings.TempPath;
                BaseUrlTextBox.Text = _settings.BaseUrl;
                InstallFilesUrlTextBox.Text = _settings.InstallFilesUrl;
                BaseSiteNameTextBox.Text = _settings.BaseSiteName;
                DefaultPortNumeric.Value = _settings.DefaultPort;
                ConStrTextBox.Text = _settings.ConStrFileName;
                SqlPathTextBox.Text = _settings.MSSQLDBPath;
                SQLConnStrTextBox.Text = _settings.MSSQLConnectionString;
                MSSQLDataSourceTextBox.Text = _settings.MSSQLDataSource;
                MSSQLInitialCatalogTextBox.Text = _settings.MSSQLInitialCatalog;
                MSSQLUserIDTextBox.Text = _settings.MSSQLUserID;
                MSSQLPasswordTextBox.Text = _settings.MSSQLPassword;
                IntegratedSecurityTextBox.Text = _settings.MSSQLIntegratedSecurity;
                UseWindowsAuth.Checked = _settings.MSSQLWindowsAuth;
                RedisHostTextBox.Text = _settings.RedisHost;
                RedisPort.Value = _settings.RedisPort;
                PSQLConnectionSctringTextBox.Text = _settings.PSQLConnectionSctring;
                PSQLServerTextBox.Text = _settings.PSQLServer;
                PSQLPortNumeric.Value = _settings.PSQLPort;
                PSQLUserIDTextBox.Text = _settings.PSQLUserID;
                PSQLPasswordTextBox.Text = _settings.PSQLPassword;
                PSQLPathTextBox.Text = _settings.PSQLPath;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveSetting();
            this.Close();
        }

        private void SaveSetting()
        {
            var s = settings;
            s.AppsPath = AppsPathTextBox.Text;
            s.TempPath = TempPathTextBox.Text;
            s.BaseUrl = BaseUrlTextBox.Text;
            s.InstallFilesUrl = InstallFilesUrlTextBox.Text;
            s.BaseSiteName = BaseSiteNameTextBox.Text;
            s.DefaultPort = (int)DefaultPortNumeric.Value;
            s.ConStrFileName = ConStrTextBox.Text;
            s.MSSQLDBPath = SqlPathTextBox.Text;
            s.MSSQLConnectionString = SQLConnStrTextBox.Text;
            s.MSSQLDataSource = MSSQLDataSourceTextBox.Text;
            s.MSSQLInitialCatalog = MSSQLInitialCatalogTextBox.Text;
            s.MSSQLUserID = MSSQLUserIDTextBox.Text;
            s.MSSQLPassword = MSSQLPasswordTextBox.Text;
            s.MSSQLIntegratedSecurity = IntegratedSecurityTextBox.Text;
            s.MSSQLWindowsAuth = UseWindowsAuth.Checked;
            s.RedisHost = RedisHostTextBox.Text;
            s.RedisPort = (int)RedisPort.Value;
            s.PSQLConnectionSctring = PSQLConnectionSctringTextBox.Text;
            s.PSQLServer = PSQLServerTextBox.Text;
            s.PSQLPort = (int)PSQLPortNumeric.Value;
            s.PSQLUserID = PSQLUserIDTextBox.Text;
            s.PSQLPassword = PSQLPasswordTextBox.Text;
            s.PSQLPath = PSQLPathTextBox.Text;
            settings = s;
            services.SaveSettings(s);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AppPathBtn_Click(object sender, EventArgs e)
        {
            SelectPath(AppsPathTextBox);
        }

        private void TempPathBtn_Click(object sender, EventArgs e)
        {
            SelectPath(TempPathTextBox);
        }

        private void SelectPath(TextBox tb)
        {
            var result = SelectFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tb.Text = SelectFolderDialog.SelectedPath;
            }
        }

        private void ConfigTooltip()
        {
            toolTip1.Active = true;
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 300;
            toolTip1.IsBalloon = false;
            toolTip1.ToolTipIcon = ToolTipIcon.None;
            toolTip1.SetToolTip(AppsPathTextBox, "Root folder with Creatio apps");
            toolTip1.SetToolTip(TempPathTextBox, "Temp folder for download Creatio distributive");
            toolTip1.SetToolTip(BaseUrlTextBox, @"Url such as 'https://ftp.bpmonline.com'");
            toolTip1.SetToolTip(InstallFilesUrlTextBox, @"Suffix for base url such as '/support/downloads/!Release/installation_files/'");
            toolTip1.SetToolTip(BaseSiteNameTextBox, "Local site suffix such as '*.localhost' (may be empty)");
            toolTip1.SetToolTip(DefaultPortNumeric, "Minimal integer port value from 80 to 100000");
            toolTip1.SetToolTip(ConStrTextBox, "File name such as ConnectionStrings.config");
            toolTip1.SetToolTip(SqlPathTextBox, "Folder with MSSQL Server DB files");
        }

        private void SqlPathBtn_Click(object sender, EventArgs e)
        {
            SelectPath(SqlPathTextBox);
        }

        private void PSQLPathBtn_Click(object sender, EventArgs e)
        {
            SelectPath(PSQLPathTextBox);
        }
    }
}
