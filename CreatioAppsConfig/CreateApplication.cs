using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace CreatioAppsConfig
{
    public partial class CreateApplication : Form
    {
        private GetCreatioDistr service = new();
        private WebClient client;
        private string ZipFilePath;

        List<KeyValuePair<string, string>> versionList = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> bundleList;

        public CreateApplication()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            string startUri = @"/support/downloads/!Release/installation_files/";
            service.BaseUri = startUri;
            var items = service.GetNodes();
            if (items.Count == 0) return;
            for (int i = 1; i < items.Count; i++)
            {
                versionList.Add(new KeyValuePair<string, string>(items[i].InnerText, items[i].Attributes[0].Value));
            }
            VersionListBox.Items.AddRange(versionList.OrderByDescending(x => x.Key).Select(x => x.Key).ToArray());
        }

        private void Version_SelectedIndexChanged(object sender, EventArgs e)
        {
            var version = VersionListBox.SelectedItem.ToString();
            bundleList = new();
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (BundleListBox.SelectedItem == null || string.IsNullOrEmpty(TempPathText.Text) || string.IsNullOrEmpty(ProjectNameBox.Text))
            {
                toolStripStatusLabel.Text = "Error! Some fields is empty!";
                return;
            }

            var fileName = BundleListBox.SelectedItem.ToString();
            string path = Path.Combine(TempPathText.Text, fileName);
            ZipFilePath = path;

            if (File.Exists(path))
            {
                ChangeFormEnableStatus();
                ExtractDistr();
                return;
            }

            var uri = bundleList.Where(x => x.Key == fileName)?.First().Value;
            service.BaseUri = uri;

            uri = service.BaseUri;

            if (client != null && client.IsBusy)   return;

            if (client == null)
            {
                ChangeFormEnableStatus();
                ServicePointManager.ServerCertificateValidationCallback = (s, ce, ca, p) => true;

                client = new WebClient();
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                client.DownloadProgressChanged += client_DownloadProgressChanged;

            }

            toolStripStatusLabel.Text = "Distrib downloadind...";
            client.DownloadFileAsync(new Uri(uri), path);
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("File has been downloaded!");
            ExtractDistr();
        }

        private void TempPathButton_Click(object sender, EventArgs e)
        {
            var result = TempPathDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TempPathText.Text = TempPathDialog.SelectedPath;
            }
        }

        private void ExtractDistr()
        {
            toolStripStatusLabel.Text = "Extracting...";
            var extractPath = Path.Combine(TempPathText.Text, ProjectNameBox.Text);
            if (Directory.Exists(extractPath))
            {
                Directory.CreateDirectory(extractPath);
            }
            ZipFile.ExtractToDirectory(ZipFilePath, extractPath);
            toolStripStatusLabel.Text = "Extracted!!!";
            ChangeFormEnableStatus();
        }

        private void ChangeFormEnableStatus()
        {
            VersionListBox.Enabled = !VersionListBox.Enabled;
            BundleListBox.Enabled = !BundleListBox.Enabled;
            CreateButton.Enabled = !CreateButton.Enabled;
            ProjectNameBox.Enabled = !ProjectNameBox.Enabled;
            TempPathButton.Enabled = !TempPathButton.Enabled;
            CancelButton.Enabled = !CancelButton.Enabled;
        }

        private void CreateApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null && client.IsBusy)
            {
                var window = MessageBox.Show(
                    "Close the window?",
                    "Downloading in progress...",
                    MessageBoxButtons.YesNo);

                if (window == DialogResult.No)
                {
                    e.Cancel = true;
                } else
                {
                    client.CancelAsync();
                }
                    

            }
        }
    }
}
