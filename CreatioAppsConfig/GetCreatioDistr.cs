using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatioAppsConfig
{
    internal class GetCreatioDistr
    {
        HttpClient client = new HttpClient();
        private readonly string _defaultURI = @"https://ftp.bpmonline.com/support/downloads/!Release/installation_files/";
        private string _uri = "";

        public GetCreatioDistr(string uri)
        {
            _uri = uri;
        }

        public string BaseUri { get { return string.IsNullOrEmpty(_uri) ? _defaultURI : _uri; } }

        public void SenRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(BaseUri);
            request.Method = "GET";
            request.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using var webResponse =  request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            MessageBox.Show(data);
        }

        

    }
}
