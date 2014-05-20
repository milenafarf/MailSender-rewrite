// -----------------------------------------------------------------------
//  <copyright file="MailChimpSender.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using System.Collections.Generic;
    using MailSender;

    /// <summary>
    /// Klasa pozwalająca na komunikację z serwisem MailChimp
    /// </summary>
    public class MailChimpSender : ISender
    {
        private readonly string apiUrl = "https://uk1.api.mailchimp.com/2.0/";

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
            throw new NotImplementedException();
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
    }
}
