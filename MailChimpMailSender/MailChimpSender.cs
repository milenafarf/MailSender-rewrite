// -----------------------------------------------------------------------
//  <copyright file="MailChimpSender.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------
using System.IO;
using System.Text;
using System.Net;

namespace MailChimpMailSender
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Json;
    using MailSender;

    /// <summary>
    /// Klasa pozwalająca na komunikację z serwisem MailChimp
    /// </summary>
    public class MailChimpSender : ISender
    {
        private readonly string apiUrl = "https://uk1.api.mailchimp.com/2.0";

        /// <summary>
        /// Typ danych przesyłanych do serwera.
        /// </summary>
        private readonly string contentType = "application/json; charset=UTF-8";

        /// <summary>
        /// Pole przechowujące klucz identyfikujący użytkownika usługi MailChimp.
        /// </summary>
        private readonly string apiKey;

        /// <summary>
        /// Pole przechowujące adres nadawcy.
        /// </summary>
        private readonly string fromMail;

        public MailChimpSender(string apikey, string frommail)
        {
            this.apiKey = apikey;
            this.fromMail = frommail;
        }

        /// <summary>
        /// Metoda sprawdzająca czy połączenie z serwisem działa poprawnie.
        /// </summary>
        /// <returns>Odowiedź otrzymana od serwera.</returns>
        public Response TestSender()
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            MailChimpResponse response = this.SendRequest(r, "/helper/ping.json");
            if (response.Msg.Equals("Everything's Chimpy!"))
            {
                return new Response(Response.ResponseCode.Ok, "Everything's Chimpy!");
            }

            return new Response(Response.ResponseCode.UnknownError);
        }

        /// <summary>
        /// Metoda wysyłająca wiadomość.
        /// </summary>
        /// <returns>Odowiedź otrzymana od serwera/</returns>
        /// <param name="mail">Wiadomość którą chcemy wysłać.</param>
        public Response SendMail(Mail mail)
        {
            throw new NotImplementedException();
        }

        public Response SendMail(Mail mail, Receiver recipient)
        {
            throw new NotImplementedException();
        }

        public Response SendMail(Mail mail, List<Receiver> recipient)
        {
            throw new NotImplementedException();
        }

        public List<Receiver> GetRecpients()
        {
            throw new NotImplementedException();
        }

        public bool AddReceiver(Receiver receiver)
        {
            throw new NotImplementedException();
        }

        private MailChimpResponse SendRequest(MailChimpRequest requestContent, string url)
        {
            MailChimpResponse response;
            var requestSerializer = new DataContractJsonSerializer(typeof(MailChimpRequest));
            var requestMemoryStream = new MemoryStream();
            requestSerializer.WriteObject(requestMemoryStream, requestContent);
            var requestJson = Encoding.UTF8.GetString(requestMemoryStream.ToArray());
            var httpRequest = WebRequest.Create(this.apiUrl + url) as HttpWebRequest;
            httpRequest.Method = "POST";
            httpRequest.ContentType = this.contentType;
            using (var outpuStream = new StreamWriter(httpRequest.GetRequestStream()))
            {
                outpuStream.Write(requestJson);
                outpuStream.Close();
                var httpResponse = httpRequest.GetResponse();
                using (var inputStream = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseJson = inputStream.ReadToEnd();
                    inputStream.Close();
                    var responseMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(responseJson));
                    var responseSerializer = new DataContractJsonSerializer(typeof(MailChimpResponse));
                    response = (MailChimpResponse)responseSerializer.ReadObject(responseMemoryStream);
                }
            }

            return response;
        }
    }
}
