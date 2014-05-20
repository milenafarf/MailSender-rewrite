// -----------------------------------------------------------------------
//  <copyright file="MailChimpSender.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using MailSender;

    /// <summary>
    /// Klasa pozwalająca na komunikację z serwisem MailChimp
    /// </summary>
    public class MailChimpSender : ISender
    {
        private readonly string apiUrl = "https://<dc>.api.mailchimp.com/2.0/";

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

        public MailChimpSender(string apikey)
        {
            this.apiKey = apikey;
        }

        #region ISender implementation

        public Response TestSender()
        {
            throw new NotImplementedException();
        }

        public Response SendMail(Mail mail)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
