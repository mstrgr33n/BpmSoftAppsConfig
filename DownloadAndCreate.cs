using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace CreatioManagmentTools
{
    public partial class DownloadAndCreate : Form
    {
        public Settings.Settings settings;
        public bool DownloadOnly;
        public string FileUri;
        public string FileName;
        private string ZipFilePath;
        private WebClient client;
        private string ExtractPath;

        public DownloadAndCreate()
        {
            InitializeComponent();
        }

        private void DownloadAndCreate_Load(object sender, EventArgs e)
        {
            PortBox.Value = settings.DefaultPort;
            SiteNameTextBox.Text = settings.BaseSiteName;
            if (DownloadOnly)
            {
                ProjectTextBox.Enabled = false;
                PortBox.Enabled = false;
                SiteNameTextBox.Enabled = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Start operation...")));
            ZipFilePath = Path.Combine(settings.TempPath, FileName);

            if (File.Exists(ZipFilePath) && DownloadOnly)
            {
                ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add($"File {FileName} is exist!")));
                return;
            } else if (!File.Exists(ZipFilePath) && DownloadOnly) {
                DownloadDistr();
                return;
            } else if (!File.Exists(ZipFilePath))
            {
                DownloadDistr();
            } else
            {
                ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add($"File {FileName} is exist!")));
                ExtractDistr();
            }
            
            
        }

        private void ExtractDistr()
        {
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Extracting distribs...")));
            ExtractPath = Path.Combine(settings.AppsPath, ProjectTextBox.Text);
            if (Directory.Exists(ExtractPath))
            {
                Directory.CreateDirectory(ExtractPath);
            }
            ZipFile.ExtractToDirectory(ZipFilePath, ExtractPath);
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Distribs extracted")));
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Create IIS configs...")));
            new WorkWithIIS().CreateSite(ProjectTextBox.Text, PortBox.Value.ToString(), ExtractPath, SiteNameTextBox.Text);
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("IIS config added")));
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Restore DB...")));
            if (FileName.Contains("MSSQL")) new MsSqlWorker(settings).RestoreDb(ProjectTextBox.Text, RedisDBNum.Value);
            if (FileName.Contains("PostgreSQL")) new PSQLWorker(settings).RestoreDb(ProjectTextBox.Text, RedisDBNum.Value);
            //ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Restore DB completed")));
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Complete!!!")));
        }

        private void DownloadDistr()
        {
            if (client != null && client.IsBusy) return;
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Start download...")));
            if (client == null)
            {
                ServicePointManager.ServerCertificateValidationCallback = (s, ce, ca, p) => true;

                client = new WebClient();
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                if (settings.useProxy)
                {
                    WebProxy myProxy = new WebProxy();

                    int port = settings.proxyPort;
                    string url = settings.proxyUrl;
                    Uri newUri = new Uri(string.Format("{0}:{1}", url, port));
                    myProxy.Address = newUri;
                    if (settings.useProxyAuth)
                    {
                        myProxy.Credentials = new NetworkCredential(settings.proxyUser, settings.proxyPass);
                    }
                    client.Proxy = myProxy;
                }
            }
            client.DownloadFileAsync(new Uri(FileUri), ZipFilePath);
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStrip1.Invoke(new Action(() => { 
                toolStripProgressBar1.Value = e.ProgressPercentage;
                toolStripLabel2.Text = $"Completed: {e.ProgressPercentage}%";
            }));
            
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                client.Dispose();
                File.Delete(ZipFilePath);
                return;
            }
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Download complete")));
            if (!DownloadOnly)
            {
                ExtractDistr();
            }
        }

    }
}
