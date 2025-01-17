using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace CreatioManagmentTools
{
    internal class WorkWithIIS
    {
        public void CreateSite(string projectName, string port, string path, string sitename = "", bool isCoreVersion = false)
        {
            string ProjectName = projectName, Port = port, Path = path;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Import-Module WebAdministration");
            sb.AppendLine($"New-WebAppPool -Name \"{ProjectName}\" -Force");
            var websiteString = $"New-Website -Name \"{ProjectName}\" -Port {port} -ApplicationPool \"{ProjectName}\" -PhysicalPath \"{Path}\" -Force";
            if (!string.IsNullOrEmpty(sitename))
            {
                websiteString += $" -HostHeader \"{sitename}\"";
            }
            sb.AppendLine(websiteString);

            string targetFolder = "";

            if (isCoreVersion)
            {
                sb.AppendLine("Remove-WebConfigurationLock -Filter \"system.webServer/security/authentication/windowsAuthentication\" -PSPath \"MACHINE/WEBROOT/APPHOST\"");
                sb.AppendLine("& $env:SystemRoot\\system32\\inetsrv\\appcmd.exe unlock config /section:system.webServer/security/authentication/windowsAuthentication");
                sb.AppendLine($"Set-WebConfigurationProperty -filter \"/system.webServer/security/authentication/windowsAuthentication\" -name \"enabled\" -value \"True\" -PSPath \"IIS:\\Sites\\{projectName}\"");
                targetFolder = Path;

            } else 
            {
                var pathWebApp = System.IO.Path.Combine(Path, "Terrasoft.WebApp");
                if (System.IO.Directory.Exists(pathWebApp))
                {
                    sb.AppendLine($"New-WebApplication -Site \"{ProjectName}\" -Name \"0\" -PhysicalPath \"{Path}\\Terrasoft.WebApp\" -ApplicationPool \"{ProjectName}\" -Force");
                     // targetFolder = System.IO.Path.Combine(Path, "Terrasoft.WebApp");
                }
                else
                {
                    sb.AppendLine($"New-WebApplication -Site \"{ProjectName}\" -Name \"0\" -PhysicalPath \"{Path}\\BPMSoft.WebApp\" -ApplicationPool \"{ProjectName}\" -Force");
                    // targetFolder = System.IO.Path.Combine(Path, "BPMSoft.WebApp");
                }
                sb.AppendLine($"Set-ItemProperty \"IIS:\\Sites\\{ProjectName}\\0\" -Name preloadEnabled -Value True");
            }

            GrantAccessToPath(targetFolder, sb);

            var script = sb.ToString();

            var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            var pipeline = runspace.CreatePipeline();

            using (PowerShell PowerShellInst = PowerShell.Create())
            {
                var initial = InitialSessionState.CreateDefault();
                initial.ImportPSModule(new[] { "ServerManager" });
                PowerShellInst.Runspace = runspace;
                PowerShellInst.AddScript("Set-ExecutionPolicy RemoteSigned");
                PowerShellInst.AddScript("Get-ExecutionPolicy");
                PowerShellInst.Invoke();

                pipeline.Commands.AddScript(script);
                pipeline.Invoke();
                pipeline.Dispose();
                runspace.Dispose();
            }
        }

        private void GrantAccessToPath(string path, StringBuilder sb)
        {
            sb.AppendLine("$Rights = \"FullControl, Read, ReadAndExecute, ListDirectory, Write, Modify\"");
            sb.AppendLine("$InheritSettings = \"Containerinherit, ObjectInherit\"");
            sb.AppendLine("$PropogationSettings = \"None\"");
            sb.AppendLine("$RuleType = \"Allow\"");
            sb.AppendLine($"$acl= Get-Acl -Path \"{path}\"");
            sb.AppendLine("$permission = \"BUILTIN\\IIS_IUSRS\", $Rights, $InheritSettings, $PropogationSettings, $RuleType");
            sb.AppendLine("$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule $permission");
            sb.AppendLine("$acl.SetAccessRule($accessRule)");
            sb.AppendLine($"Set-Acl -Path \"{path}\"  -AclObject $acl");
        }
    }
}
