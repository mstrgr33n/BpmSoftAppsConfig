using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CreatioManagmentTools
{
    public partial class EditConnectionSrtings : Form
    {
        private BindingSource _bs;
        public BindingSource bindingSource
        {
            get
            {
                if (_bs == null) _bs = new BindingSource();
                return _bs;
            }
            set { _bs = value; }
        }

        public string FileName { get; set; }

        public EditConnectionSrtings()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists($"{FileName}.bkp"))
                {
                    File.Delete($"{FileName}.bkp");
                }
                File.Move(FileName, $"{FileName}.bkp");
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

        private void SerializeObject(string filename)
        {

            XmlSerializer serializer =
            new XmlSerializer(typeof(ConnectionStrings.ConnectionStrings));
            ConnectionStrings.ConnectionStrings cs = new ConnectionStrings.ConnectionStrings()
            {
                Add = new List<ConnectionStrings.Add>()
            };
            for (int i = 0; i < EditDataGrid.Rows.Count; i++)
            {
                ConnectionStrings.Add add = new ConnectionStrings.Add();
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

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditConnectionSrtings_Load(object sender, EventArgs e)
        {
            EditDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EditDataGrid.DataSource = bindingSource;
        }
    }
}
