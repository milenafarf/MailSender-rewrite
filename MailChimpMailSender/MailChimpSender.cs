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
            MandrillResponse response = this.SendRequest(r, "/helper/ping.json");
            return response.Msg.Equals("Everything's Chimpy!") ?
                new Response(Response.ResponseCode.Ok, "Everything's Chimpy!") :
                new Response(Response.ResponseCode.UnknownError);
        }

        /// <summary>
        /// Wysyła zapytanie typu MailChimp
        /// 
        /// 
        /// uest do serwera, zwracając jego odpowiedź
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
            MandrillResponse response = this.SendRequest(r, "/lists/list.json");
            return new Response(Response.ResponseCode.UnknownError);
        }
    }
}
