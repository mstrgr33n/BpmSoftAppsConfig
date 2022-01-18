using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;

namespace CreatioAppsConfig
{
    public partial class AppsConfigs : Form
    {
        private string GetConfigPath
        {
            get
            {
                return Application.StartupPath;
            }
        }

        Encoding enc8 = Encoding.UTF8;

        public AppsConfigs()
        {
            InitializeComponent();
        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            var result = PathDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                WriteConfig();
                PathText.Text = PathDialog.SelectedPath;
                ReadDirectory(PathDialog.SelectedPath);
            }
        }

        public void ReadDirectory(string path)
        {
            var folders = Directory.GetDirectories(path);
            if (folders.Any() && folders.Length > 0)
            {
                var data = new List<ConnectionStrings>();
                foreach (var item in folders)
                {
                    var filePath = $"{item}\\ConnectionStrings.config";
                    if (File.Exists(filePath))
                    {
                        data.Add(GetDataFrommFile(filePath));
                    }
                }

                if (data.Any())
                {
                    FillGrid(OperateData(data));
                }
            }
        }

        private ConnectionStrings GetDataFrommFile(string filePath)
        {
            Console.WriteLine("Reading with Stream");
            XmlSerializer serializer =
            new XmlSerializer(typeof(ConnectionStrings));
            ConnectionStrings cs;
            using (Stream reader = new FileStream(filePath, FileMode.Open))
            {
                cs = (ConnectionStrings)serializer.Deserialize(reader);
            }
            cs.Path = filePath;
            return cs;
        }

        private List<ConfigData> OperateData(List<ConnectionStrings> data)
        {
            var names = new string[] { "redis", "db" };
            var lstCfg = new List<ConfigData>();
            foreach (var item in data)
            {
                var configData = new ConfigData();
                configData.Path = item.Path;
                var itemData = item.Add.Where(x => names.Contains(x.Name));
                foreach (var config in itemData)
                {
                    switch (config.Name)
                    {
                        case "db":
                            var dbArray = config.ConnectionString.Split(';');
                            foreach (var dbData in dbArray)
                            {
                                var cfg = dbData.Split('=');
                                if (cfg.Length == 2)
                                {
                                    if (cfg[0].Contains("Data Source") || cfg[0].Contains("Server"))
                                    {
                                        configData.DBHost = cfg[1];
                                    }
                                    if (cfg[0].Contains("Initial Catalog") || cfg[0].Contains("Database"))
                                    {
                                        configData.DBName = cfg[1];
                                    }
                                }
                            }
                            break;
                        case "redis":
                            var redisArray = config.ConnectionString.Split(';');
                            foreach (var redisData in redisArray)
                            {
                                var cfg = redisData.Split('=');
                                if (cfg.Length == 2)
                                {
                                    if (cfg[0].Contains("host"))
                                    {
                                        configData.RedisHost = cfg[1];
                                    }
                                    if (cfg[0].Contains("port"))
                                    {
                                        configData.RedisPort = cfg[1];
                                    }
                                    if (cfg[0].Contains("db"))
                                    {
                                        configData.RedisDB = cfg[1];
                                    }
                                }
                            }
                            break;
                    }
                }
                lstCfg.Add(configData);
            }
            return lstCfg.OrderBy(x => int.Parse(x.RedisDB)).ToList(); 
        }

        private void FillGrid(List<ConfigData> data)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            dataGridView2.Columns.Add("DBHost", "DBHost");
            dataGridView2.Columns.Add("DBName", "DB Name");
            dataGridView2.Columns.Add("RedisHost", "Redis Host");
            dataGridView2.Columns.Add("RedisPort", "Redis Port");
            dataGridView2.Columns.Add("RedisDB", "Redis DB");
            dataGridView2.Columns.Add("Path", "Path");

            foreach (var item in data)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView2);
                row.Cells[0].Value = item.DBHost;
                row.Cells[1].Value = item.DBName;
                row.Cells[2].Value = item.RedisHost;
                row.Cells[3].Value = item.RedisPort;
                row.Cells[4].Value = item.RedisDB;
                row.Cells[5].Value = item.Path;
                dataGridView2.Rows.Add(row);

            }

            
        }

        private void AppsConfigs_Load(object sender, EventArgs e)
        {
            ReadConfig();
            LoadIISData();
        }

        private void ReadConfig()
        {
            var filePath = GetConfigPath + "config.json";
            if (File.Exists(filePath))
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    var json = r.ReadToEnd();
                    var config = JsonConvert.DeserializeObject<ConfigProram>(json);
                    if (!string.IsNullOrEmpty(config.Path))
                    {
                        if (Directory.Exists(config.Path))
                        {
                            PathText.Text = config.Path;
                            ReadDirectory(config.Path);
                        }
                        
                    }
                    
                }
            }
        }

        private void WriteConfig()
        {
            var filePath = GetConfigPath + "\\config.json";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            var appsPath = new ConfigProram() { Path = PathDialog.SelectedPath };
            using (FileStream fs = File.Create(filePath))
            {
                Byte[] text = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(appsPath));
                fs.Write(text, 0, text.Length);
            }

        }

        private void LoadIISData()
        {
            var path = "";
            var windir = Environment.GetEnvironmentVariable("windir");
            var path32 = $@"{windir}\system32\inetsrv\appcmd.exe";
            var path64 = $@"{windir}\syswow64\inetsrv\appcmd.exe";

            if (File.Exists(path32))
            {
                path = path32;
            }
            if (File.Exists(path64))
            {
                path = path64;
            }

            if (!string.IsNullOrEmpty(path))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                Process p = Process.Start(path, " list site");
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage);
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;

                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                
                string error = p.StandardError.ReadToEnd();

                p.WaitForExit();

                if (string.IsNullOrEmpty(error) && !string.IsNullOrEmpty(output))
                {
                    AddSiteData(output);
                } else
                {
                    string message = error;
                    string caption = "Error Detected";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            
        }

        private void AddSiteData(string data)
        {
            dataGridView1.Columns.Add("SiteName", "Site Name");
            dataGridView1.Columns.Add("SiteBindings", "Site Bindings");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int i = 0;
            foreach (var siteRow in data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    var arrayData = siteRow.Split(' ');
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = arrayData[1];
                    row.Cells[1].Value = arrayData[2];
                    dataGridView1.Rows.Insert(i++, row);
                }
                catch (IndexOutOfRangeException)
                {
                    string message = "Please run programm as admin";
                    string caption = "Error Detected";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                        
                    }
                    break;
                }
                
            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var file = (string)dataGridView2.Rows[e.RowIndex].Cells["Path"].Value;
            Form2 editForm = new Form2();
            editForm.Text = file;
            editForm.FileName = file;
            var data = GetDataFrommFile(file);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data.Add;

            editForm.bindingSource = bindingSource;
            DialogResult result = editForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                ReadConfig();
            }
        }
    }
}
