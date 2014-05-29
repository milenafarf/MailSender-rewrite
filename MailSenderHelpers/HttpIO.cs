// -----------------------------------------------------------------------
//  <copyright file="HttpIO.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderHelpers
{
    using System.IO;
    using System.Net;
    using System.Text;

    public class HttpIO
    {
        private readonly string baseUrl;
        private readonly string dataType;

        public HttpIO(string baseUrl, string dataType)
        {
            this.baseUrl = baseUrl;
            this.dataType = dataType;
        }

        public string ProcessRequest(string url, string data)
        {
            var response = string.Empty;
            var httpRequest = WebRequest.Create(this.baseUrl + url) as HttpWebRequest;
            if (httpRequest != null)
            {
                httpRequest.Method = "POST";
                httpRequest.ContentType = this.dataType;
                using (var outpuStream = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    outpuStream.Write(data);
                    outpuStream.Close();
                    var httpResponse = httpRequest.GetResponse();
                    using (var inputStream = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        response = inputStream.ReadToEnd();
                        inputStream.Close();
                    }
                }
            }

            return response;
        }
    }
}
