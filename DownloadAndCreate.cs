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
using System.Text.RegularExpressions;
using RegRuApi.API;
using Newtonsoft.Json;

namespace CreatioManagmentTools
{
    public partial class DownloadAndCreate : Form
    {
        public Settings.Settings settings;
        public bool DownloadOnly;
        public bool IsOffline;
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

            DBPassTB.Enabled = FileName.ToLower().Contains("postgre");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Start operation...")));
            ZipFilePath = Path.Combine(settings.TempPath, FileName);
            if (IsOffline)
            {
                ZipFilePath = FileName;
            }

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
            if (!Directory.Exists(ExtractPath))
            {
                Directory.CreateDirectory(ExtractPath);
            } else
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(ExtractPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            ZipFile.ExtractToDirectory(ZipFilePath, ExtractPath);
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Distribs extracted")));
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Create IIS configs...")));
            var isCoreVersion = FileName.ToLower().Contains("core");
            new WorkWithIIS().CreateSite(ProjectTextBox.Text, PortBox.Value.ToString(), ExtractPath, SiteNameTextBox.Text, isCoreVersion);
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("IIS config added")));
            ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Restore DB...")));
            if (FileName.ToLower().Contains("mssql")) new MsSqlWorker(settings).RestoreDb(ProjectTextBox.Text, RedisDBNum.Value);
            if (FileName.ToLower().Contains("postgresql")) new PSQLWorker(settings).RestoreDb(ProjectTextBox.Text, RedisDBNum.Value, DBPassTB.Text);
            if (RegisterDomain.Checked)
            {
                ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Try add subdomain...")));
                if (AddSubdomain())
                {
                    ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Subdomain added")));
                } else 
                {
                    ProcessLogBox.Invoke(new Action(() => ProcessLogBox.Items.Add("Subdomain not add")));
                }
                
            }
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

        private void ProjectTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("[-_'\"]");
            
            if (FileName.ToLower().Contains("postgre") && reg.IsMatch(ProjectTextBox.Text))
            {
                Regex rgx = new Regex("[^a-zA-Z0-9]");
                ProjectTextBox.Text = rgx.Replace(ProjectTextBox.Text, "");
            }
        }

        private bool AddSubdomain()
        {
            var address = SiteNameTextBox.Text;
            var data = address.Split('.');
            if (data.Length == 0) throw new Exception("Domain address empty!!!");
            var subdomainName = data[0];
            var config = GetRegConfig();
            var paramsObj = new
            {
                domains = new[] {
                new { dname = config.Item3 },
            },
                ipaddr = config.Item4,
                password = config.Item2,
                subdomain = subdomainName,
                username = config.Item1
            };

            var form = new Dictionary<string, string>
            {
                { "input_format", "json" },
                { "output_format", "json" },
                { "io_encoding", "utf8" },
                { "input_data", JsonConvert.SerializeObject(paramsObj) },
                { "show_input_params", "0" },
                { "username", config.Item1 },
                { "password", config.Item2 }
            };

            var regru = new RegRuMethods(@"https://api.reg.ru");
            var task =  Task.Run(() => regru.PostAddAliasAsync(form));
            var result = task.Result;
            return result.result == "success";
        }

        private (string, string, string, string) GetRegConfig()
        {
            string login = Environment.GetEnvironmentVariable("GDLogin");
            string password = Environment.GetEnvironmentVariable("GDPassword");
            string domain = Environment.GetEnvironmentVariable("GDDomain");
            string ipaddress = Environment.GetEnvironmentVariable("GDIpaddress");

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(ipaddress)) 
            {
                throw new Exception("Config data is empty!!!");
            }

            return ( login, password, domain, ipaddress );
        }
    }
}
