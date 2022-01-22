using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatioAppsConfig
{
    public partial class CreateApplication : Form
    {
        private GetCreatioDistr service = new();

        List<KeyValuePair<string, string>> versionList = new List<KeyValuePair<string, string>>();

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
            foreach (var item in items)
            {
                VersionBox.Items.Add(new KeyValuePair<string, string> (item.InnerText, item.Attributes[0].Value));
            }
        }
    }
}
