using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CreatioManagmentTools
{
    internal class MsSqlWorker
    {
        public MsSqlWorker(Settings.Settings s)
        {
            this.settings = s;
        }

        public Settings.Settings settings;
        private string connectionString = "";
        private string fileCS = "";
        private string _redisDb = "0";

        public void RestoreDb(string projectName, decimal redisDb)
        {
            _redisDb = redisDb.ToString();
            var path = Path.Combine(settings.AppsPath, projectName, "db");
            var di = new DirectoryInfo(path);
            var file = di.GetFiles("*.bak").FirstOrDefault().FullName;
            
            var template = settings.MSSQLConnectionString;
            var scriptList = new List<string>();
            
            if (settings.MSSQLWindowsAuth)
            {
                connectionString = String.Format(template, settings.MSSQLDataSource, settings.MSSQLInitialCatalog, settings.MSSQLIntegratedSecurity);
                fileCS = String.Format(template, settings.MSSQLDataSource, projectName, settings.MSSQLIntegratedSecurity);
                var sqlLogin = @"USE [master]; CREATE LOGIN [IIS APPPOOL\{0}] FROM WINDOWS";
                var sqlData = @"USE [{0}]; CREATE USER [IIS APPPOOL\{0}] FOR LOGIN [IIS APPPOOL\{0}]; ALTER ROLE db_owner ADD MEMBER [IIS APPPOOL\{0}]";
                scriptList.Add(string.Format(sqlLogin, projectName));
                scriptList.Add(string.Format(sqlData, projectName));

            } else
            {
                var security = $"User ID={settings.MSSQLUserID}; Password={settings.MSSQLPassword}";
                connectionString = String.Format(template, settings.MSSQLDataSource, settings.MSSQLInitialCatalog, security);
                fileCS = String.Format(template, settings.MSSQLDataSource, projectName, security);
                var sqlData = @"USE [{0}]; CREATE USER [{1}] FOR LOGIN [{1}]; ALTER ROLE db_owner ADD MEMBER [{1}]";
                scriptList.Add(string.Format(sqlData, projectName, settings.MSSQLUserID));
            }

            var bdFile = GetDatabaseFileList(file);
            var sqlRestore = @"USE [master]; RESTORE  Database [{0}] FROM DISK = '{1}' WITH RECOVERY, MOVE '{2}' to '{4}\{0}.mdf', MOVE '{3}' to '{4}\{0}.ldf', NOUNLOAD,  REPLACE,  STATS = 5";
            var dbPath = Path.Combine(settings.MSSQLDBPath, projectName);
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }
            scriptList.Insert(0, string.Format(sqlRestore, projectName, file, bdFile.DataName, bdFile.LogName, dbPath));
            var updateText = @$"USE [{projectName}]; update ""SysAdminUnit"" set ""ForceChangePassword"" = 0 where ""Name"" = 'Supervisor';";
            scriptList.Add(updateText);

            try
            {
                foreach (var script in scriptList)
                {
                    RunScript(script);
                }
            }
            catch (Exception)
            {
                throw;
            }
            UpdateConnectionString(projectName);
        }

        private DatabaseFileList GetDatabaseFileList(string localDatabasePath)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = @"RESTORE FILELISTONLY FROM DISK = @localDatabasePath";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@localDatabasePath", localDatabasePath);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var fileList = new DatabaseFileList();
                        while (reader.Read())
                        {
                            string type = reader["Type"].ToString();
                            switch (type)
                            {
                                case "D":
                                    fileList.DataName = reader["LogicalName"].ToString();
                                    break;
                                case "L":
                                    fileList.LogName = reader["LogicalName"].ToString();
                                    break;
                            }
                        }
                        return fileList;
                    }
                }
            }
        }

        private void RunScript(string script)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(script, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 7200;
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateConnectionString(string projectName)
        {
            var filePath = Path.Combine(settings.AppsPath, projectName, settings.ConStrFileName);
            XmlSerializer serializer = new XmlSerializer(typeof(ConnectionStrings.ConnectionStrings));
            ConnectionStrings.ConnectionStrings cs;
            using (Stream reader = new FileStream(filePath, FileMode.Open))
            {
                cs = (ConnectionStrings.ConnectionStrings)serializer.Deserialize(reader);
            }
            cs.Path = filePath;
            cs = ConnectionString(cs);
            WriteConnectionString(filePath, cs);
        }

        private ConnectionStrings.ConnectionStrings ConnectionString(ConnectionStrings.ConnectionStrings cs)
        {
            var editabledCS = new ConnectionStrings.ConnectionStrings()
            {
                Add = new List<ConnectionStrings.Add>()
            };
            foreach (var item in cs.Add)
            {
                if (item.Name == "db")
                {
                    editabledCS.Add.Add(new ConnectionStrings.Add()
                    {
                        Name = item.Name,
                        ConnectionString = fileCS
                    });
                } else if (item.Name == "redis")
                {
                    var listconfig = new List<string>();
                    var configs = item.ConnectionString.Split(';');
                    foreach (var config in configs)
                    {
                        if (config.Trim().StartsWith("host"))
                        {
                            var h = config.Split('=');
                            h[1] = settings.RedisHost;
                            listconfig.Add(String.Join("=", h));
                        } else if (config.Trim().StartsWith("port"))
                        {
                            var p = config.Split('=');
                            p[1] = settings.RedisPort.ToString();
                            listconfig.Add(String.Join("=", p));
                        } else if (config.Trim().StartsWith("db"))
                        {
                            var d = config.Split('=');
                            d[1] = _redisDb;
                            listconfig.Add(String.Join("=", d));
                        } else
                        {
                            listconfig.Add(config);
                        }
                    }
                    editabledCS.Add.Add(new ConnectionStrings.Add()
                    {
                        Name = item.Name,
                        ConnectionString = String.Join(";", listconfig)
                    });
                } else
                {
                    editabledCS.Add.Add(item);
                }
            }
            return editabledCS;
        }

        private void WriteConnectionString(string file, ConnectionStrings.ConnectionStrings cs)
        {
            try
            {
                if (File.Exists($"{file}.bkp"))
                {
                    File.Delete($"{file}.bkp");
                }
                File.Move(file, $"{file}.bkp");
               
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error Detected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ConnectionStrings.ConnectionStrings));
            using (Stream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                using (XmlTextWriter writer = new XmlTextWriter(fs, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    serializer.Serialize(writer, cs, ns);
                    writer.Close();
                }
            }
        }

    }

    public class DatabaseFileList
    {
        public string DataName { get; set; }
        public string LogName { get; set; }
    }
}
