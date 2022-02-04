using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatioManagmentTools
{
    public partial class MainWindow : Form
    {
        private Settings.Settings _settings;
        private Services _services;

        public MainWindow()
        {
            _services = new Services();
            _services.UpdateMainGridData += _services_UpdateGridData;
            _services.UpdateSiteGridData += _services_UpdateSiteGridData;
            _services.UpdatePoolGridData += _services_UpdatePoolGridData;
            _services.UpdateWPGridData += _services_UpdateWPGridData;
            _settings = _services.GetSettings();
            InitializeComponent();
            if ( _settings == null ) { OpenSettings(); }
        }

        private void _services_UpdateWPGridData(object sender, EventArgs e)
        {
            _services.AppCmdTool(" list WP /xml", AddProcessData).Wait();
        }

        private void _services_UpdatePoolGridData(object sender, EventArgs e)
        {
            _services.AppCmdTool(" list apppool /xml", AddPoolData).Wait();
        }

        private void _services_UpdateSiteGridData(object sender, EventArgs e)
        {
            _services.AppCmdTool(" list SITE /xml", AddSiteData).Wait();
        }

        private void _services_UpdateGridData(object sender, EventArgs e)
        {
            _services.GetMainData(MainDataGridView, _settings.AppsPath, _settings.ConStrFileName).Wait();
        }

        private bool IsAdmin()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
             .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void propertiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenSettings()
        {
            var sf = _settings == null ? new SettingsForm() : new SettingsForm(_settings);
            sf.services = _services;
            sf.FormClosing += Sf_FormClosing;
            sf.ShowDialog();
        }

        private void Sf_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = (SettingsForm)sender;
            if (_settings != result.settings)
            {
                _settings = result.settings;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (!this.IsAdmin())
            {
                MessageBox.Show("Please, run app as Admin!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            LoadGridDatasAsync().Wait();
        }

        private async Task LoadGridDatasAsync()
        {
            await _services.AppCmdTool(" list SITE /xml", AddSiteData);
            await _services.AppCmdTool(" list apppool /xml", AddPoolData);
            await _services.AppCmdTool(" list WP /xml", AddProcessData);
            await _services.GetMainData(MainDataGridView, _settings.AppsPath, _settings.ConStrFileName);
        }

        private object AddSiteData(string data)
        {
            var sites = _services.DeserializeXML<SiteData.Appcmd>(data);
            if (sites.SITE.Count == 0) return null;
            var gridData = sites.SITE.OrderBy(x => x.Id).ToList();
            _services.FillGrid(gridData, SiteGridView);
            return null;
        }

        private object AddPoolData(string data)
        {
            var pool = _services.DeserializeXML<APPPOOL.Appcmd>(data);
            if (pool.APPPOOL.Count == 0) return null;
            var gridData = pool.APPPOOL.OrderBy(x => x.Name).ToList();
            _services.FillGrid(gridData, PoolGridView);
            return null;
        }

        private object AddProcessData(string data)
        {
            var wp = _services.DeserializeXML<WorkingProcess.Appcmd>(data);
            if (wp.WP.Count == 0) return null;
            var gridData = wp.WP.OrderBy(x => x.ProcessId).ToList();
            _services.FillGrid(gridData, WorkProcessGridView);
            return null;
        }

        private void addProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sd = new SelectDistrib();
            sd.settings = _settings;
            sd.FormClosed += Sd_FormClosed;
            sd.ShowDialog();
        }

        private void Sd_FormClosed(object sender, FormClosedEventArgs e)
        {
            _services.AppCmdTool(" list SITE /xml", AddSiteData).Wait();
            _services.AppCmdTool(" list apppool /xml", AddPoolData).Wait();
            _services.AppCmdTool(" list WP /xml", AddProcessData).Wait();
            _services.GetMainData(MainDataGridView, _settings.AppsPath, _settings.ConStrFileName).Wait();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab = new AboutBox();
            ab.ShowDialog();
        }
    }
}
