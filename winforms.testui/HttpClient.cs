using System.IO;
using System.Net;
using JalapenoCloud.Common.Helpers;

namespace TestUI
{
    public class HttpClient
    {
        private WebClient _webClient;

        public HttpClient()
        {
            _webClient = new WebClient();
        }

        public string Get(string uri)
        {
            string response = _webClient.DownloadString(uri);
            return response;
        }

        public string Post(string uri, string data)
        {
            byte[] bytes = StringHelper.GetBytes(data);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = bytes.Length;
            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
            string response = streamReader.ReadToEnd();
            streamReader.Close();
            webResponse.Close();

            return response;
        }
    }
}