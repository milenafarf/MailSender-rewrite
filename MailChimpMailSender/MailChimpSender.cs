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
    /// Klasa pozwalająca na komunikację z serwisem MailChimp.
    /// Wersja użytego api mailchampa to 2.0.
    /// http://apidocs.mailchimp.com/api/2.0/
    /// </summary>
    public class MailChimpSender : INewsletterSender
    {
        private readonly HttpIO connector;
        private readonly JsonSerializer<MailChimpRequest> requestSerializer;
        private readonly JsonDeserializer<MailChimpResponse> responseDeserializer;

        // url chyba trzeba samemu ustawić, a nie dać jakiś stały, ponieważ tutaj jest napisane http://apidocs.mailchimp.com/api/2.0/
        // że link wygląda tak https://<dc>.api.mailchimp.com/2.0/ gdzie <dc> to np. uk1 albo jak u mnie us8.
        // Można zrobić tak, że te dc jest wstawiane na podstawie apikeya
        // private readonly string apiUrl = "https://uk1.api.mailchimp.com/2.0";
        
        /// <summary>
        /// Link za pośrednictwem, którego będą wysyłąne zapytania do serwera. Zawiera datacenter i wersję api.
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

        public Response AddSubscriberTolistByName(string listName, Receiver receiver)
        {
            string listId;
            try
            {
                listId = this.getSubscriberIdListByName(listName);
            }
            catch
            {
                return new Response(Response.ResponseCode.UnknownError);
            }
            return AddSubscriberTolistById(listId, receiver);
        }

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
        /// Metoda pomocnicza zwracająca id listy subskrybentów ze względu na name. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string getSubscriberIdListByName(string name)
        {
            Response response;
            response = this.GetSubscribersList(name);
            if (response.Code == Response.ResponseCode.Ok)
                return response.Message;
            throw new Exception();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignName"></param>
        /// <returns></returns>
        public Response CreateCampaign(string listId,string subject, string toName, string title, string fromName, string fromMail)
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
        /// 
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="subject"></param>
        /// <param name="toName"></param>
        /// <param name="title"></param>
        /// <param name="fromName"></param>
        /// <returns></returns>
        public Response CreateCampaign(string listId, string subject, string toName, string title, string fromName){
            return this.CreateCampaign(listId, subject, toName, title, fromName, this.fromMail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="subject"></param>
        /// <param name="toName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public Response CreateCampaign(string listId, string subject, string toName, string title){
            return this.CreateCampaign(listId, subject, toName, title, this.fromMail.Substring(0, this.fromMail.IndexOf('@')));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="subject"></param>
        /// <param name="toName"></param>
        /// <returns></returns>
        public Response CreateCampaign(string listId, string subject, string toName)
        {
            return this.CreateCampaign(listId, subject, toName, subject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignName"></param>
        /// <returns></returns>
        public Response PauseCampaign(string campaignName)
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            r.CId = campaignName;
            MailChimpResponse response = this.SendRequest(r, "/campaigns/pause.json");
            
            return response.Complete != null ? (response.Complete == "True" ? 
                new Response(Response.ResponseCode.Ok) : new Response(Response.ResponseCode.UnknownError)):
                new Response(Response.ResponseCode.UnknownError,response.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignName"></param>
        /// <returns></returns>
        public Response ResumeCampaign(string campaignName)
        {
            var r = new MailChimpRequest();
            r.ApiKey = this.apiKey;
            r.CId = campaignName;
            MailChimpResponse response = this.SendRequest(r, "/campaigns/resume.json");
            
            return response.Complete != null ? (response.Complete == "True" ?
                new Response(Response.ResponseCode.Ok) : new Response(Response.ResponseCode.UnknownError)):
                new Response(Response.ResponseCode.UnknownError, response.Error);
        }

    }
}
