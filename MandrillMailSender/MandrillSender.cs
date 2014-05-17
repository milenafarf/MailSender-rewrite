// -----------------------------------------------------------------------
//  <copyright file="MandrillSender.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System;
    using System.Net;
    using MailSender;

    /// <summary>
    /// Klasa pozwalająca na komunikację z serwisem Mandrill
    /// </summary>
    public class MandrillSender : ISender
    {
        /// <summary>
        /// Klient używany do komunikacji http do serwera.
        /// </summary>
        private HttpWebRequest httpClient;

        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="MandrillMailSender.MandrillSender"/>.
        /// </summary>
        /// <param name="apikey">Klucz identyfikujący u żytkownika usługi Mandrill</param>
        public MandrillSender(string apikey)
        {
        }

        #region ISender implementation

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

        #endregion
    }
}
