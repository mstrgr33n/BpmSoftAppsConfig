using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace CreatioManagmentTools
{
    internal class Services
    {
        #region Events
        public event EventHandler UpdateMainGridData;
        public event EventHandler UpdateSiteGridData;
        public event EventHandler UpdatePoolGridData;
        public event EventHandler UpdateWPGridData;
        #endregion

        protected string GetConfigPath
        {
            get
            {
                return Path.Combine(Application.StartupPath, "Settings.json");
            }
        }

        public Settings.Settings GetSettings()
        {
            Settings.Settings settings = null;
            var filePath = GetConfigPath;
            if (File.Exists(filePath))
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    var json = r.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<Settings.Settings>(json);
                }
            }
            return settings;
        }

        public void SaveSettings(Settings.Settings settings)
        {
            var filePath = GetConfigPath;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            using (FileStream fs = File.Create(filePath))
            {
                Byte[] text = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(settings, Formatting.Indented));
                fs.Write(text, 0, text.Length);
            }
        }

        internal T DeserializeXML<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T result;
            using (TextReader reader = new StringReader(xml))
            {
                result = (T)serializer.Deserialize(reader);
            }
            return result;
        }

        internal Task AppCmdTool(string command, Func<string, object> method)
        {
            var path = "";
            var windir = Environment.GetEnvironmentVariable("windir");
            var path32 = $"{windir}\\system32\\inetsrv\\appcmd.exe";
            var path64 = $"{windir}\\syswow64\\inetsrv\\appcmd.exe";

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
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    FileName = path,
                    Arguments = command,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage)
                };

                Process p = Process.Start(psi);
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();

                if (string.IsNullOrEmpty(error) && !string.IsNullOrEmpty(output))
                {
                    method(output);
                }
                else
                {
                    string message = error;
                    string caption = "Error Detected";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }
            }

            return Task.CompletedTask;
        }

        internal void FillGrid<T>(List<T> data, DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            var type = data.FirstOrDefault();
            var someType = type.GetType();

            foreach (var item in someType.GetProperties())
            {
                dataGridView.Columns.Add(item.Name, item.Name);
            }

            foreach (var item in data)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView);
                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    row.Cells[col.Index].Value = someType.GetProperty(col.Name).GetValue(item, null);

                }
                dataGridView.Rows.Add(row);
            }

            AddColumnsInGrid(dataGridView);
        }

        private void AddColumnsInGrid(DataGridView dataGridView)
        {
            var methodName = $"{dataGridView.Name}AddButtons";
            var SomeType = this.GetType();
            MethodInfo m = SomeType.GetMethod(methodName);
            m?.Invoke(this, new object[] { dataGridView });
        }

        public void SiteGridViewAddButtons(DataGridView dataGridView)
        {
            dataGridView.CellContentClick -= SitePoolGridBtnClick;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn()
            {
                HeaderText = " ",
                Text = "START SITE",
                Name = "StartSiteButton",
                UseColumnTextForButtonValue = true,
            };
            dataGridView.Columns.Add(btn);
            btn = new DataGridViewButtonColumn()
            {
                HeaderText = " ",
                Text = "STOP SITE",
                Name = "StopSiteButton",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(btn);
            dataGridView.CellContentClick += SitePoolGridBtnClick;
        }

        public void PoolGridViewAddButtons(DataGridView dataGridView)
        {
            dataGridView.CellContentClick -= SitePoolGridBtnClick;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn()
            {
                HeaderText = " ",
                Text = "START APPPOOL",
                Name = "StartAPPPOOLButton",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(btn);
            btn = new DataGridViewButtonColumn()
            {
                HeaderText = " ",
                Text = "STOP APPPOOL",
                Name = "StopAPPPOOLButton",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(btn);
            dataGridView.CellContentClick += SitePoolGridBtnClick;
        }

        private void SitePoolGridBtnClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex].GetType().Name != "DataGridViewButtonColumn" || e.RowIndex < 0) return;
            var instruction = (string)senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            var poolName = (string)senderGrid.Rows[e.RowIndex].Cells["Name"].Value;
            var command = $" {instruction} \"{poolName}\"";
            AppCmdTool(command, ShowResult).Wait();
            if (senderGrid.Name.StartsWith("Site"))
            {
                UpdateSiteGridData?.Invoke(this, EventArgs.Empty);
            } else
            {
                UpdatePoolGridData?.Invoke(this, EventArgs.Empty);
            }
            
        }

        private object ShowResult(string result)
        {
            MessageBox.Show(result);
            return 0;
        }

        public void MainDataGridViewAddButtons(DataGridView dataGridView)
        {
            dataGridView.CellContentClick -= EditConfigFile;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn()
            {
                HeaderText = " ",
                Text = "Edit",
                Name = "EditFile",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(btn);
            dataGridView.CellContentClick += EditConfigFile;
        }

        private void EditConfigFile(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex].GetType().Name != "DataGridViewButtonColumn" || e.RowIndex < 0) return;
            var file = (string)senderGrid.Rows[e.RowIndex].Cells["Path"].Value;
            EditConnectionSrtings editForm = new EditConnectionSrtings();
            editForm.FormClosing += EditForm_FormClosing;
            editForm.Text = file;
            editForm.FileName = file;
            var data = GetDataFromFile(file);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data.Add;

            editForm.bindingSource = bindingSource;
            editForm.ShowDialog();
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateMainGridData?.Invoke(this, EventArgs.Empty);
        }

        internal Task GetMainData(DataGridView dataGridView, string path, string fileName)
        {
            var data = AppsPathRead(path, fileName);
            var result = OperateData(data);
            FillGrid(result, dataGridView);
            return Task.CompletedTask;
        }

        internal List<ConnectionStrings.ConnectionStrings> AppsPathRead(string path, string fileName)
        {
            var folders = Directory.GetDirectories(path);
            var data = new List<ConnectionStrings.ConnectionStrings>();
            foreach (var folder in folders)
            {
                var file = Path.Combine(folder, fileName);
                if (File.Exists(file))
                {
                    data.Add(GetDataFromFile(file));
                }
            }
            return data;
        }

        private ConnectionStrings.ConnectionStrings GetDataFromFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConnectionStrings.ConnectionStrings));
            ConnectionStrings.ConnectionStrings cs;
            using (Stream reader = new FileStream(filePath, FileMode.Open))
            {
                cs = (ConnectionStrings.ConnectionStrings)serializer.Deserialize(reader);
            }
            cs.Path = filePath;
            return cs;
        }

        private List<Settings.MainGridData> OperateData(List<ConnectionStrings.ConnectionStrings> data)
        {
            var configLst = new List<Settings.MainGridData>();
            var names = new string[] { "redis", "db" };
            foreach (var dataItem in data)
            {
                var cfg = new Settings.MainGridData();
                cfg.Path = dataItem.Path;
                var dataPart = dataItem.Add.Where(x => names.Contains(x.Name));
                foreach (var dataPartItem in dataPart)
                {
                    var dictRaw = dataPartItem.ConnectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(part => part.Split('='));

                    try
                    {
                        var dict = dictRaw.ToDictionary(split => split[0].Trim(), split => split[1]);
                        if (dataPartItem.Name == "redis")
                        {
                            AddRedisData(dict, cfg);
                        }
                        else
                        {
                            AddDBData(dict, cfg);
                        }
                    }
                    catch (Exception e)
                    {

                        throw new Exception($"Error string {dataPartItem.Name}:\n{dataPartItem.ConnectionString}\nin file:\n{dataItem.Path}");
                    }
                }
                configLst.Add(cfg);
            }
            return configLst;
        }

        private void AddRedisData(Dictionary<string, string> dict, Settings.MainGridData data)
        {
            string RedisPort, RedisHost, RedisDB;
            dict.TryGetValue("port", out RedisPort);
            dict.TryGetValue("host", out RedisHost);
            dict.TryGetValue("db", out RedisDB);
            data.RedisDB = RedisDB;
            data.RedisHost = RedisHost;
            data.RedisPort = RedisPort;
        }

        private void AddDBData(Dictionary<string, string> dict, Settings.MainGridData data)
        {
            string DBHost, DBName;
            if (dict.ContainsKey("Data Source")) dict.TryGetValue("Data Source", out DBHost);
            else dict.TryGetValue("Server", out DBHost);
            if (dict.ContainsKey("Initial Catalog"))  dict.TryGetValue("Initial Catalog", out DBName);
            else dict.TryGetValue("Database", out DBName);
            data.DBHost = DBHost;
            data.DBName = DBName;
        }
    }
}
