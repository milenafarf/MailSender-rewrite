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

    /// <summary>
    /// Klasa pozwalająca na komunikację z serwisem MailChimp
    /// </summary>
    public class MailChimpSender : INewsletterSender
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


        public Response CreateNewReceiversList(List<Receiver> receivers)
        {
            throw new NotImplementedException();
        }
    }
}
