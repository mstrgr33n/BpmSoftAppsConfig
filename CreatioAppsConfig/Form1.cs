﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
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
                    FillGrid(OperateData(data), dataGridView2);
                }
            }
        }

        private ConnectionStrings GetDataFrommFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConnectionStrings));
            ConnectionStrings cs;
            using (Stream reader = new FileStream(filePath, FileMode.Open))
            {
                cs = (ConnectionStrings)serializer.Deserialize(reader);
            }
            cs.Path = filePath;
            return cs;
        }

        private T DeserializeXML<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T result;
            using (TextReader reader = new StringReader(xml))
            {
                result = (T)serializer.Deserialize(reader);
            }
            return result;
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
                                        configData.RedisPort = int.Parse(cfg[1]);
                                    }
                                    if (cfg[0].Contains("db"))
                                    {
                                        configData.RedisDB = int.Parse(cfg[1]);
                                    }
                                }
                            }
                            break;
                    }
                }
                lstCfg.Add(configData);
            }
            return lstCfg.OrderBy(x => x.RedisDB).ToList(); 
        }

        private void FillGrid<T>(List<T> data, DataGridView dataGridView)
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
        }

        private void AppsConfigs_Load(object sender, EventArgs e)
        {
            ReadConfig();
            LoadIISData(" list SITE /xml", AddSiteData);
            LoadIISData(" list WP /xml", AddProcessData);
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

        private void LoadIISData(string command, Func<string, object> method)
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
                Process p = Process.Start(path, command);
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
                    method(output);
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

        private object AddSiteData(string data)
        {
            try
            {
                var sites = DeserializeXML<SiteData.Appcmd>(data);
                var gridData = sites.SITE.OrderBy(x => x.Id).ToList();
                FillGrid(gridData, dataGridView1);
            }
            catch (Exception)
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
            }
            return null;
        }

        private object AddProcessData(string data)
        {
            try
            {
                var sites = DeserializeXML<WorkingProcess.Appcmd>(data);
                var gridData = sites.WP.OrderBy(x => x.ProcessId).ToList();
                FillGrid(gridData, dataGridView3);
            }
            catch (Exception)
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
            }
            return null;
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var file = (string)dataGridView2.Rows[e.RowIndex].Cells["Path"].Value;
            Form2 editForm = new Form2();
            editForm.FormClosing += EditForm_FormClosing;
            editForm.Text = file;
            editForm.FileName = file;
            var data = GetDataFrommFile(file);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data.Add;

            editForm.bindingSource = bindingSource;
            editForm.ShowDialog();
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ReadConfig();
        }
    }
}
