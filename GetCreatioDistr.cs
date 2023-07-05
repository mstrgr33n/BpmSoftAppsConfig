using System;
using System.IO;
using System.Net;

namespace CreatioManagmentTools
{
    internal class GetCreatioDistr
    {
        private readonly string _defaultURI;
        private string _uri;
        private Settings.Settings _settings;

        public GetCreatioDistr(string baseUri, Settings.Settings settings = null)
        {
            _defaultURI = baseUri;
            _settings = settings;
        }

        
        public string BaseUri
        {
            get { return string.IsNullOrEmpty(_uri) ? _defaultURI : _uri; }
            set { _uri = $"{_defaultURI}{value}"; }
        }

        public HtmlAgilityPack.HtmlNodeCollection GetNodes()
        {
            var request = (HttpWebRequest)WebRequest.Create(BaseUri);
            request.Method = "GET";
            request.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
           
            if (_settings.useProxy)
            {
                WebProxy myProxy = new WebProxy();

                int port = _settings.proxyPort;
                string url = _settings.proxyUrl;
                Uri newUri = new Uri(string.Format("{0}:{1}", url, port));
                myProxy.Address = newUri;
                if (_settings.useProxyAuth)
                {
                    myProxy.Credentials = new NetworkCredential(_settings.proxyUser, _settings.proxyPass);
                }
                request.Proxy = myProxy;
            }

            using (var webResponse = request.GetResponse())
            {
                using (var webStream = webResponse.GetResponseStream())
                {
                    using (var reader = new StreamReader(webStream))
                    {
                        var data = reader.ReadToEnd();

                        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        htmlDoc.LoadHtml(data);
                        var items = htmlDoc.DocumentNode.SelectNodes("//pre/a");
                        return items;
                    }
                }
            }
          
        }
    }
}
