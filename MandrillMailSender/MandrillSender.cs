// -----------------------------------------------------------------------
//  <copyright file="MandrillSender.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using MailSender;

    /// <summary>
    /// Klasa pozwalająca na komunikację z serwisem Mandrill
    /// </summary>
    public class MandrillSender : ITransactionalSender
    {
        /// <summary>
        /// Adres url 
        /// </summary>
        private readonly string apiUrl = "https://mandrillapp.com/api/1.0";

        /// <summary>
        /// Typ danych przesyłanych do serwera.
        /// </summary>
        private readonly string contentType = "application/json; charset=UTF-8";

        /// <summary>
        /// Pole przechowujące klucz identyfikujący użytkownika usługi Mandrill.
        /// </summary>
        private readonly string apiKey;

        /// <summary>
        /// Pole przechowujące adres nadawcy.
        /// </summary>
        private readonly string fromMail;

        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="MandrillMailSender.MandrillSender"/>.
        /// </summary>
        /// <param name="apikey">Klucz identyfikujący u żytkownika usługi Mandrill</param>
        /// <param name="frommail">Adres który przekazywany jest jako wysyłający wiadomość.</param>
        public MandrillSender(string apikey, string frommail)
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
            var r = new MandrillRequest();
            r.ApiKey = this.apiKey;
            MandrillResponse response = this.SendRequest(r, "/users/ping2.json");
            if (response.Ping.Equals("PONG!"))
            {
                return new Response(Response.ResponseCode.Ok, "PONG!");
            }

            return new Response(Response.ResponseCode.UnknownError);
        }

        /// <summary>
        /// Metoda wysyłająca wiadomość.
        /// </summary>
        /// <returns>Odowiedź otrzymana od serwera/</returns>
        /// <param name="mail">Wiadomość którą chcemy wysłać.</param>
        /// <param name="receiver">Odbiorca wiadomości do którego chcemy ją wysłać</param>
        public Response SendMail(Mail mail, Receiver receiver)
        {
            var r = new MandrillRequest();
            r.ApiKey = this.apiKey;
            r.Message = new MandrillMessage(mail);
            r.Message.To = new List<MandrillTo>();
            r.Message.FromEmail = fromMail;
            r.Message.FromName = fromMail;
            MandrillTo rec = new MandrillTo(receiver);
            r.Message.To.Add(rec);
            r.Message.FromEmail = this.fromMail;

            MandrillResponse response = this.SendRequest(r, "/messages/send.json");

            return new Response(Response.ResponseCode.UnknownError);
        }

        /// <summary>
        /// Wysyła zapytanie typu MandrillRequest do serwera, zwracając jego odpowiedź
        /// w formie MandrillResponse
        /// </summary>
        /// <returns>Odpowiedź otrzymana od serwera</returns>
        /// <param name="requestContent">Zapytanie w formacie MandrillRequest</param>
        /// <param name="url">Adres url </param>
        private MandrillResponse SendRequest(MandrillRequest requestContent, string url)
        {
            MandrillResponse response;
            var requestSerializer = new DataContractJsonSerializer(typeof(MandrillRequest));
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
                    var responseSerializer = new DataContractJsonSerializer(typeof(MandrillResponse));
                    response = (MandrillResponse)responseSerializer.ReadObject(responseMemoryStream);
                }
            }

            return response;
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

        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <returns>The mail.</returns>
        /// <param name="mail">Mail.</param>
        /// <param name="recipient">Recipient.</param>
        public Response SendMail(Mail mail, List<Receiver> recipient)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the recpients.
        /// </summary>
        /// <returns>The recpients.</returns>
        public List<Receiver> GetRecpients()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the receiver.
        /// </summary>
        /// <returns><c>true</c>, if receiver was added, <c>false</c> otherwise.</returns>
        /// <param name="receiver">Receiver.</param>
        public bool AddReceiver(Receiver receiver)
        {
            throw new NotImplementedException();
        }
    }
}
