using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace CreatioAppsConfig
{
    public partial class EditConnectionSrtings : Form
    {
        private BindingSource _bs;
        public BindingSource bindingSource { 
            get { 
                if (_bs == null) _bs = new BindingSource();
                return _bs; }
            set { _bs = value; }
        }

        public string FileName { get; set; }

        public EditConnectionSrtings()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                File.Move(FileName, $"{FileName}.bkp", true);
                SerializeObject(FileName);
                this.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error Detected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            EditDataGrid.DataSource = bindingSource;
        }

        private void SerializeObject(string filename)
        {

            XmlSerializer serializer =
            new XmlSerializer(typeof(ConnectionStrings));
            ConnectionStrings cs = new()
            {
                Add = new List<Add> ()
            };
            for (int i = 0; i < EditDataGrid.Rows.Count ; i++)
            {
                Add add = new Add();
                var someObjectType = add.GetType();
                for (int j = 0; j < EditDataGrid.Columns.Count; j++)
                {
                    someObjectType.GetProperty(EditDataGrid.Columns[j].HeaderText)
                        .SetValue(add, EditDataGrid.Rows[i].Cells[j].Value, null);
                }
                cs.Add.Add(add);
            }
            Stream fs = new FileStream(filename, FileMode.Create);
            XmlTextWriter writer =
            new XmlTextWriter(fs, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(writer, cs, ns);
            writer.Close();
        }
    }
}
