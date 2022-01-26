using System.IO;
using System.Net;


namespace CreatioAppsConfig
{
    internal class GetCreatioDistr
    {
        private readonly string _defaultURI = @"https://ftp.bpmonline.com";
        private string _uri;

        public string BaseUri { 
            get { return string.IsNullOrEmpty(_uri) ? _defaultURI : _uri; }
            set { _uri = $"{_defaultURI}{value}"; }
        }

        public HtmlAgilityPack.HtmlNodeCollection GetNodes()
        {
            var request = (HttpWebRequest)WebRequest.Create(BaseUri);
            request.Method = "GET";
            request.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using var webResponse =  request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(data);
            var items = htmlDoc.DocumentNode.SelectNodes("//pre/a");
            return items;
        }
    }
}
