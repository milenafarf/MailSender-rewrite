// -----------------------------------------------------------------------
//  <copyright file="MandrillSender.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System.Collections.Generic;
    using MailSender;
    using MailSenderHelpers;

    /// <summary>
    /// Klasa pozwalająca na komunikację z serwisem Mandrill
    /// </summary>
    public class MandrillSender : ITransactionalSender
    {
        private readonly HttpIO connector;
        private readonly JsonSerializer<MandrillRequest> requestSerializer;
        private readonly JsonDeserializer<MandrillResponse> responseDeserializer;

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
            this.connector = new HttpIO(this.apiUrl, this.contentType);
            this.requestSerializer = new JsonSerializer<MandrillRequest>();
            this.responseDeserializer = new JsonDeserializer<MandrillResponse>();
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
            return response.Ping.Equals("PONG!") ?
                new Response(Response.ResponseCode.Ok, "PONG!") :
                new Response(Response.ResponseCode.UnknownError);
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
            r.Message.FromEmail = this.fromMail;
            r.Message.FromName = this.fromMail;
            var rec = new MandrillTo(receiver);
            r.Message.To.Add(rec);
            MandrillResponse response = this.SendRequestHack(r, "/messages/send.json");
            if (response.Responses[0].Status == "sent")
            {
                return new Response(Response.ResponseCode.Ok, "sent");
            }

            return new Response(Response.ResponseCode.UnknownError, response.Responses[0].Status);
        }

        /// <summary>
        /// Metoda wysyłająca wiadomość.
        /// </summary>
        /// <returns>Odowiedź otrzymana od serwera.</returns>
        /// <param name="mail">Wiadomość którą chcemy wysłać.</param>
        /// <param name="receivers">Odbiorca wiadomości.</param>
        public Response SendMail(Mail mail, List<Receiver> receivers)
        {
            var r = new MandrillRequest();
            r.ApiKey = this.apiKey;
            r.Message = new MandrillMessage(mail);
            r.Message.FromEmail = this.fromMail;
            r.Message.FromName = this.fromMail;
            r.Message.To = new List<MandrillTo>();
            foreach (var rec in receivers)
            {
                r.Message.To.Add(new MandrillTo(rec));
            }

            MandrillResponse response = this.SendRequest(r, "/messages/send.json");
            foreach(var a in response.Responses)
            {
                if(a.Status != "sent")
                {
                    return new Response(Response.ResponseCode.UnknownError, a.Status);
                }
            }
            return new Response(Response.ResponseCode.Ok, "sent");
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
            var requestJson = this.requestSerializer.Serialize(requestContent);
            var responseJson = this.connector.ProcessRequest(url, requestJson);
            response = this.responseDeserializer.Deserialize(responseJson);
            return response;
        }

        /// <summary>
        /// Wysyła zapytanie typu MandrillRequest do serwera, zwracając jego odpowiedź
        /// w formie MandrillResponse.
        /// Metoda ta jest używana w przypadku zwracania przez serwer listy jako elemntu root JSONA.
        /// Parser nie potrafi sparsować takiego obiektu, dlatego przypisujemy wartość listu do dodatkowego obiektu
        /// "hack" który możemy odczytać.
        /// </summary>
        /// <returns>Odpowiedź otrzymana od serwera</returns>
        /// <param name="requestContent">Zapytanie w formacie MandrillRequest</param>
        /// <param name="url">Adres url </param>
        private MandrillResponse SendRequestHack(MandrillRequest requestContent, string url)
        {
            MandrillResponse response;
            var requestJson = this.requestSerializer.Serialize(requestContent);
            var responseJson = this.connector.ProcessRequest(url, requestJson);
            response = this.responseDeserializer.Deserialize("{ \"hack\" : " + responseJson + " }");
            return response;
        }
    }
}
