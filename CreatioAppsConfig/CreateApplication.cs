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
    }
}
