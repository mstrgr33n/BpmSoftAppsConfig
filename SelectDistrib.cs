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
    public partial class SelectDistrib : Form
    {
        public Settings.Settings settings;

        private GetCreatioDistr service;
        List<KeyValuePair<string, string>> versionList = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> bundleList;

        public SelectDistrib()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectDistrib_Load(object sender, EventArgs e)
        {
            VersionListBox.SelectedIndexChanged -= VersionChanged;
            service = new GetCreatioDistr(settings.BaseUrl);
            service.BaseUri = settings.InstallFilesUrl;
            var items = service.GetNodes();
            if (items.Count == 0) return;
            for (int i = 1; i < items.Count; i++)
            {
                versionList.Add(new KeyValuePair<string, string>(items[i].InnerText, items[i].Attributes[0].Value));
            }
            VersionListBox.Items.AddRange(versionList.OrderByDescending(x => x.Key).Select(x => x.Key).ToArray());
            VersionListBox.SelectedIndexChanged += VersionChanged;
        }

        private void VersionChanged(object sender, EventArgs e)
        {
            var version = VersionListBox.SelectedItem.ToString();
            bundleList = new List<KeyValuePair<string, string>>();
            BundleListBox.Items.Clear();
            var uri = versionList.Where(x => x.Key == version)?.First().Value;
            service.BaseUri = uri;
            var items = service.GetNodes();
            if (items.Count == 0) return;
            for (int i = 1; i < items.Count; i++)
            {
                if (items[i].InnerText.EndsWith(".txt")) continue;
                bundleList.Add(new KeyValuePair<string, string>(items[i].InnerText, items[i].Attributes[0].Value));
            }
            BundleListBox.Items.AddRange(bundleList.Select(x => x.Key).ToArray());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            StartDownload(true);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            StartDownload(false);
        }

        private void StartDownload(bool downloadOnly)
        {
            var bundle = BundleListBox.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(bundle))
            {
                MessageBox.Show("Please, select some distro...");
                return;
            }
            var uri = bundleList.Where(x => x.Key == bundle).First().Value;
            service.BaseUri = uri;
            var file = service.BaseUri;
            var form = new DownloadAndCreate();
            form.settings = settings;
            form.FileUri = file;
            form.FileName = bundle;
            form.DownloadOnly = downloadOnly;
            form.ShowDialog();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bundleList = new List<KeyValuePair<string, string>>();
            BundleListBox.Items.Clear();
            service = new GetCreatioDistr(settings.BaseUrl);
            service.BaseUri = settings.InstallDemoFilesUrl;
            var items = service.GetNodes();
            if (items.Count == 0) return;
            for (int i = 1; i < items.Count; i++)
            {
                bundleList.Add(new KeyValuePair<string, string>(items[i].InnerText, items[i].Attributes[0].Value));
            }
            BundleListBox.Items.AddRange(bundleList.OrderByDescending(x => x.Key).Select(x => x.Key).ToArray());
        }
    }
}
