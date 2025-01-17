using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CreatioManagmentTools
{
    internal class PSQLWorker
    {
        public PSQLWorker(Settings.Settings s)
        {
            this.settings = s;
        }

        public Settings.Settings settings;
        private string fileCS = "";
        private string _redisDb = "0";

        public void RestoreDb(string projectName, decimal redisDb, string dbPassword)
        {
            _redisDb = redisDb.ToString();
            var path = Path.Combine(settings.AppsPath, projectName, "db");
            var di = new DirectoryInfo(path);
            var file = di.GetFiles("*.backup").FirstOrDefault().FullName;

            var template = settings.PSQLConnectionSctring;
            object[] tplParams = new object[]
            {
                settings.PSQLServer, settings.PSQLPort, "template1", settings.PSQLUserID, settings.PSQLPassword
            };
            var cs = string.Format(template, tplParams) ;
            var createUserTextTpl = $"CREATE ROLE {projectName} WITH LOGIN NOSUPERUSER CREATEDB NOCREATEROLE INHERIT NOREPLICATION CONNECTION LIMIT -1 PASSWORD '{dbPassword}';";
            RunCommand(cs, createUserTextTpl);
            var CommandText = $"CREATE DATABASE {projectName} WITH OWNER = {projectName} ENCODING = 'UTF8' CONNECTION LIMIT = -1";
            RunCommand(cs, CommandText);
            PostgreSqlRestore(file, projectName);
            tplParams[2] = projectName;
            cs = string.Format(template, tplParams);
            // fileCS = cs;
            RunCommand(cs, CreateTypeScript());
            var updateText = "update \"SysAdminUnit\" set \"ForceChangePassword\" = false where \"Name\" = 'Supervisor'";
            RunCommand(cs, updateText);
            tplParams[3] = projectName;
            tplParams[4] = dbPassword;
            fileCS = string.Format(template, tplParams);
            UpdateConnectionString(projectName);
        }

        private void RunCommand(string cs, string command)
        {
            using (var con = new NpgsqlConnection(cs))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = command;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                con.Close();
                con.Dispose();
            }
        }

        private void PostgreSqlRestore(string inputFile, string projectName)
        {
            string dumpCommand = $"set PGPASSWORD={settings.PSQLPassword}\n" +
                                 $"\"{settings.PSQLPath}\\pg_restore.exe\" --host {settings.PSQLServer} --port {settings.PSQLPort} --username={settings.PSQLUserID} --dbname={projectName} --no-owner --role={projectName} --no-privileges {inputFile} && exit";

            Execute(dumpCommand, projectName);
        }

        private ProcessStartInfo ProcessInfo(string batFilePath)
        {
            ProcessStartInfo info = new ProcessStartInfo(batFilePath)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    // WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
                    FileName = batFilePath,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
            return info;
        }

        private void Execute(string dumpCommand, string projectName)
        {
            string batFilePath = Path.Combine(settings.AppsPath, projectName, $"restore.bat");
            try
            {
                string batchContent = "";
                batchContent += $"{dumpCommand}";

                File.WriteAllText(batFilePath, batchContent, Encoding.ASCII);

                ProcessStartInfo info = ProcessInfo(batFilePath);

                using (Process proc = Process.Start(info))
                {
                    proc.WaitForExit();
                    string output = proc.StandardOutput.ReadToEnd();
                    string error = proc.StandardError.ReadToEnd();
                    var exit = proc.ExitCode;
                    proc.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
    }

        private string CreateTypeScript()
        {
            var sb = new StringBuilder();
            sb.AppendLine("DROP CAST IF EXISTS (varchar AS integer);");
            sb.AppendLine("CREATE CAST (varchar AS integer) WITH INOUT AS IMPLICIT;");
            sb.AppendLine("DROP CAST IF EXISTS (varchar AS uuid);");
            sb.AppendLine("CREATE CAST (varchar AS uuid) WITH INOUT AS IMPLICIT;");
            sb.AppendLine("DROP CAST IF EXISTS (text AS integer);");
            sb.AppendLine("CREATE CAST (text AS integer) WITH INOUT AS IMPLICIT;");
            sb.AppendLine("DROP CAST IF EXISTS (uuid AS text);");
            sb.AppendLine("CREATE CAST (uuid AS text) WITH INOUT AS IMPLICIT;");
            sb.AppendLine("DROP CAST IF EXISTS (text AS boolean);");
            sb.AppendLine("CREATE CAST (text AS boolean) WITH INOUT AS IMPLICIT;");
            sb.AppendLine("DROP CAST IF EXISTS (text AS numeric);");
            sb.AppendLine("CREATE CAST (text AS numeric) WITH INOUT AS IMPLICIT;");
            sb.AppendLine("DROP CAST IF EXISTS (text AS uuid);");
            sb.AppendLine("CREATE CAST (text AS uuid) WITH INOUT AS IMPLICIT;");
            sb.AppendLine("DROP FUNCTION IF EXISTS public.\"fn_CastTimeToDateTime\" CASCADE;");
            sb.AppendLine("CREATE FUNCTION public.\"fn_CastTimeToDateTime\"(sourceValue TIME WITHOUT TIME ZONE)");
            sb.AppendLine("RETURNS TIMESTAMP WITHOUT TIME ZONE");
            sb.AppendLine("AS $BODY$");
            sb.AppendLine("BEGIN");
            sb.AppendLine("	RETURN (MAKE_DATE(1900, 01, 01) + sourceValue)::TIMESTAMP WITHOUT TIME ZONE;");
            sb.AppendLine("END;");
            sb.AppendLine("$BODY$");
            sb.AppendLine("LANGUAGE PLPGSQL;");
            sb.AppendLine("DROP CAST IF EXISTS (TIME WITHOUT TIME ZONE AS TIMESTAMP WITHOUT TIME ZONE);");
            sb.AppendLine("CREATE CAST (TIME WITHOUT TIME ZONE AS TIMESTAMP WITHOUT TIME ZONE) ");
            sb.AppendLine("	WITH FUNCTION public.\"fn_CastTimeToDateTime\"(TIME WITHOUT TIME ZONE) AS IMPLICIT;");
            return sb.ToString();
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
                }
                else if (item.Name == "redis")
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
                        }
                        else if (config.Trim().StartsWith("port"))
                        {
                            var p = config.Split('=');
                            p[1] = settings.RedisPort.ToString();
                            listconfig.Add(String.Join("=", p));
                        }
                        else if (config.Trim().StartsWith("db"))
                        {
                            var d = config.Split('=');
                            d[1] = _redisDb;
                            listconfig.Add(String.Join("=", d));
                        }
                        else
                        {
                            listconfig.Add(config);
                        }
                    }
                    editabledCS.Add.Add(new ConnectionStrings.Add()
                    {
                        Name = item.Name,
                        ConnectionString = String.Join(";", listconfig)
                    });
                }
                else
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
}
