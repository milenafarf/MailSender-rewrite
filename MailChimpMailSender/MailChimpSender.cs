//-----------------------------------------------------------------------
// <copyright file="MailChimpSender.cs" company="DevCore.NET">
//     Author: m (m.dobrzynski@outlook.com).
// </copyright>
//-----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Json;
    using MailSender;
    using MailSenderHelpers;

    /// <summary>
    /// Klasa pozwalająca na komunikację z serwisem MailChimp
    /// </summary>
    public class MailChimpSender : INewsletterSender
    {
        private readonly HttpIO connector;
        private readonly JsonSerializer<MailChimpRequest> requestSerializer;
        private readonly JsonDeserializer<MailChimpResponse> responseDeserializer;

        private readonly string apiUrl;

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

        /// <summary>
        /// Konstruktor MailChimpSender. W przypadku podania błędnego apikeya metody klasy będą zwracać response z wiadomością o błędnym apikey'u.
        /// </summary>
        /// <param name="apikey">Apikey należy pobrać z strony mailchimp.com</param>
        /// <param name="frommail">Ten mail będzie widoczny jedynie jako adresat wiadomości.</param>
        /// albo na końcu apikey'a. Przykładowe datacentr to "us1","uk1"</param>
        public MailChimpSender(string apikey, string frommail)
        {
            this.apiKey = apikey.Substring(0,apikey.Length-4);
            this.fromMail = frommail;

            string datacenter = apikey.Substring(apikey.Length-3,3);
            this.apiUrl = "https://"+datacenter+".api.mailchimp.com/2.0";

            this.connector = new HttpIO(apiUrl, contentType);
            this.requestSerializer = new JsonSerializer<MailChimpRequest>();
            this.responseDeserializer = new JsonDeserializer<MailChimpResponse>();
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
            return response.Msg.Equals("Everything's Chimpy!") ?
                new Response(Response.ResponseCode.Ok, "Everything's Chimpy!") :
                new Response(Response.ResponseCode.UnknownError);
        }

        /// <summary>
        /// Wysyła zapytanie typu MailChimp
        ///request do serwera, zwracając jego odpowiedź
        /// w formie MailChimpResponse
        /// </summary>
        /// <returns>Odpowiedź otrzymana od serwera</returns>
        /// <param name="requestContent">Zapytanie w formacie MailChimpRequest</param>
        /// <param name="url">Adres url </param>
        private MailChimpResponse SendRequest(MailChimpRequest requestContent, string url)
        {
            MailChimpResponse response;
            var requestJson = this.requestSerializer.Serialize(requestContent);
            var responseJson = this.connector.ProcessRequest(url, requestJson);
            response = this.responseDeserializer.Deserialize(responseJson);
            return response;
        }

        public Response CreateNewReceiversList(List<Receiver> receivers)
        {
            throw new NotImplementedException();
        }

        public Response GetReceiversList(string name)
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            r.Filters = new MailChimpFilters();
            r.Filters.ListName = name;
            MailChimpResponse response = this.SendRequest(r, "/lists/list.json");
            return new Response(Response.ResponseCode.UnknownError);
        }

        public Response AddReciver(Receiver receiver, string list_name)
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            //r.Id = uzyskac z GetReceiversList(list_name)
            r.Email.Email = receiver.Email;
            MailChimpResponse response = this.SendRequest(r, "/lists/subscribe.json");
            return new Response(Response.ResponseCode.UnknownError);
        }
    }
}
