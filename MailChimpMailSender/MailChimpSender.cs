//-----------------------------------------------------------------------
// <copyright file="MailChimpSender.cs" company="DevCore.NET">
//     Author: m (m.dobrzynski@outlook.com),
//             Milena Farfułowska (m.farfulowskai@gmail.com),
//             Chrystian Kisło ()
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
    /// Klasa pozwalająca na komunikację z serwisem MailChimp.
    /// Wersja użytego api mailchampa to 2.0.
    /// http://apidocs.mailchimp.com/api/2.0/
    /// </summary>
    public class MailChimpSender : INewsletterSender
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly HttpIO connector;

        /// <summary>
        /// Serializer obiektu MailpChimpRequest
        /// </summary>
        private readonly JsonSerializer<MailChimpRequest> requestSerializer;

        /// <summary>
        /// Serializer obiektu MailpChimpResponse
        /// </summary>
        private readonly JsonDeserializer<MailChimpResponse> responseDeserializer;

        /// <summary>
        /// Link za pośrednictwem, którego będą wysyłane zapytania do serwera. Zawiera datacenter i wersję api.
        /// </summary>
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
        /// Inicjalizuje nową instancję klasy <see cref="MailChimpSender" />
        /// W przypadku podania błędnego apikeya metody klasy będą zwracać response z wiadomością o błędnym apikey'u.
        /// </summary>
        /// <param name="apikey">Apikey należy pobrać z strony mailchimp.com</param>
        /// <param name="frommail">Ten mail będzie widoczny jedynie jako adresat wiadomości.
        /// albo na końcu apikey'a. Przykładowe datacentr to "us1","uk1"</param>
        public MailChimpSender(string apikey, string frommail)
        {
            this.apiKey = apikey.Substring(0, apikey.Length - 4);
            this.fromMail = frommail;
            string datacenter = apikey.Substring(apikey.Length - 3, 3);
            this.apiUrl = "https://" + datacenter + ".api.mailchimp.com/2.0";
            this.connector = new HttpIO(this.apiUrl, this.contentType);
            this.requestSerializer = new JsonSerializer<MailChimpRequest>();
            this.responseDeserializer = new JsonDeserializer<MailChimpResponse>();
        }

        /// <summary>
        /// Metoda sprawdzająca czy połączenie z serwisem działa poprawnie.
        /// </summary>
        /// <returns>Odpowiedź otrzymana od serwera.</returns>
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
        /// Metoda zwraca listę wszystkich list subskrybentów 
        /// (ich id i nazwy przechowywane w obiekcie klasy SubscribersList)
        /// </summary>
        /// <returns>Lista z danymi o wszystkich listach subskrybentów</returns>
        public List<SubscribersList> GetAllLists()
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            MailChimpResponse response = this.SendRequest(r, "/lists/list.json");
            List<SubscribersList> lists = new List<SubscribersList>();
            foreach (var data in response.Data)
            {
                SubscribersList sl = new SubscribersList();
                sl.Id = data.Id;
                sl.Name = data.Name;
                lists.Add(sl);
            }

            return lists;
        }

        /// <summary>
        /// Metoda dodaje subskrybentów do listy po Id Listy
        /// </summary>
        /// <param name="listId">Id listy subskrybentów</param>
        /// <param name="receiver">Odbiorca maila</param>
        /// <returns>Odpowiedź od serwera</returns>
        public Response AddSubscriberTolistById(string listId, Receiver receiver)
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            r.Id = listId;
            r.Email = new MailChimpEmail();
            r.Email.Email = receiver.Email;
            MailChimpResponse response = this.SendRequest(r, "/lists/subscribe.json");
            return response.Error == null ? new Response(Response.ResponseCode.Ok) :
                new Response(Response.ResponseCode.UnknownError);
        }

        /// <summary>
        /// Metoda dodaje subskrybenta do listy po nazwie listy
        /// </summary>
        /// <param name="listName">Nazwa listy subskrybentów</param>
        /// <param name="receiver">Odbiorca maila</param>
        /// <returns>Odpowiedź od serwera</returns>
        public Response AddSubscriberTolistByName(string listName, Receiver receiver)
        {
            string listId;
            try
            {
                listId = this.GetSubscriberIdListByName(listName);
            }
            catch
            {
                return new Response(Response.ResponseCode.UnknownError);
            }

            return this.AddSubscriberTolistById(listId, receiver);
        }

        /// <summary>
        /// Metoda zwraca jedną listę subskrybentów o nazwie podanej jako argument
        /// </summary>
        /// <param name="name">Odpowiedź otrzymana od serwera</param>
        /// <returns>Odpowiedź otrzymana od serwera</returns>
        public Response GetSubscribersList(string name)
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            r.Filters = new MailChimpFilters();
            r.Filters.ListName = name;
            MailChimpResponse response = this.SendRequest(r, "/lists/list.json");
            return response.Error == null ? new Response(Response.ResponseCode.Ok, response.Data[0].Id) :
                new Response(Response.ResponseCode.UnknownError);
        }

        /// <summary>
        /// Metoda pomocnicza zwracająca id listy subskrybentów ze względu na nazwę listy subskrybentów. 
        /// </summary>
        /// <param name="name">Nazwa listy subskrybentów</param>
        /// <returns>Odpowiedź otrzymana od serwera.</returns>
        public string GetSubscriberIdListByName(string name)
        {
            Response response;
            response = this.GetSubscribersList(name);
            if (response.Code == Response.ResponseCode.Ok)
            {
                return response.Message;
            }

            throw new Exception();
        }

        /// <summary>
        /// Metoda tworząca nową kampanię mailową
        /// </summary>
        /// <param name="campaignName">Nawa kampanii</param>
        /// <returns>odpowiedź od serwera</returns>
        public Response CreateCampaign(string listId, string subject, string toName, string title, string fromName, string fromMail)
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            r.Type = "regular";
            r.Options = new MailChimpOptions();
            r.Options.ListId = listId;
            r.Options.Subject = subject;
            r.Options.Title = title;
            r.Options.FromEmail = fromMail;
            r.Options.FromName = fromName;

            r.Content = new MailChimpContent();
            r.Content.Html = "Example html";
            r.Content.Text = "Example text";

            MailChimpResponse response = this.SendRequest(r, "/campaigns/create.json");

            return response.Error == null ? new Response(Response.ResponseCode.Ok) :
                new Response(Response.ResponseCode.UnknownError, response.Error);
        }

        /// <summary>
        /// Metoda tworząca nową kampanię
        /// </summary>
        /// <param name="listId">Id listy subskrybentów</param>
        /// <param name="subject">Temat emaili wysyłanych w kampanii</param>
        /// <param name="toName">Nazwa adresata maila w kampanii (nie adres email)</param>
        /// <param name="title">Nazwa kampani</param>
        /// <param name="fromName">Nazwa nadawcy emaila</param>
        /// <returns>Odpowiedź od serwera</returns>
        public Response CreateCampaign(string listId, string subject, string toName, string title, string fromName)
        {
            return this.CreateCampaign(listId, subject, toName, title, fromName, this.fromMail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listId">Id listy subskrybentów</param>
        /// <param name="subject">Temat każdego emaila w kampanii</param>
        /// <param name="toName">Nazwa adresata maila w kampanii (nie adres email)</param>
        /// <param name="title">Nazwa kampani</param>
        /// <returns>Odpowiedź od serwera</returns>
        public Response CreateCampaign(string listId, string subject, string toName, string title)
        {
            return this.CreateCampaign(listId, subject, toName, title, this.fromMail.Substring(0, this.fromMail.IndexOf('@')));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listId">Id listy subskrybentów</param>
        /// <param name="subject">Temat każdego emaila w kampanii</param>
        /// <param name="toName">Nazwa adresata maila w kampanii (nie adres email)</param>
        /// <returns>Odpowiedź od serwera</returns>
        public Response CreateCampaign(string listId, string subject, string toName)
        {
            return this.CreateCampaign(listId, subject, toName, subject);
        }

        /// <summary>
        /// Zatrzymuje wysyłanie wiadomości w kampaniach AutoResponder lub  RSS 
        /// </summary>
        /// <param name="campaignName">Nazwa kampanii</param>
        /// <returns>Odpowiedź od serwera</returns>
        public Response PauseCampaign(string campaignName)
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            r.CId = campaignName;
            MailChimpResponse response = this.SendRequest(r, "/campaigns/pause.json");

            return response.Complete != null ? (response.Complete == "True" ?
                new Response(Response.ResponseCode.Ok) : new Response(Response.ResponseCode.UnknownError)) :
                new Response(Response.ResponseCode.UnknownError, response.Error);
        }

        /// <summary>
        /// Wznawia wysyłanie wiadomości w kampaniach AutoResponder lub  RSS 
        /// </summary>
        /// <param name="campaignName">Nazwa kampanii</param>
        /// <returns>Odpowiedź otrzymana od serwera.</returns>
        public Response ResumeCampaign(string campaignName)
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            r.CId = campaignName;
            MailChimpResponse response = this.SendRequest(r, "/campaigns/resume.json");

            return response.Complete != null ? (response.Complete == "True" ?
                new Response(Response.ResponseCode.Ok) :
                new Response(Response.ResponseCode.UnknownError)) :
                new Response(Response.ResponseCode.UnknownError, response.Error);
        }

        /// <summary>
        /// Wysyła zapytanie typu MailChimp
        /// Request do serwera, zwracając jego odpowiedź
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
    }
}
