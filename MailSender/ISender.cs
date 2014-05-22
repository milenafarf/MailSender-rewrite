// -----------------------------------------------------------------------
//  <copyright file="ISender.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interfejs definiujący metody implementowane przez klasy
    /// komunikujące się z serwisami wysyłającymi wiadomoścu email. 
    /// </summary>
    public interface ISender
    {
        /// <summary>
        /// Metoda sprawdzająca czy połączenie z serwisem działa poprawnie.
        /// </summary>
        /// <returns>Odowiedź otrzymana od serwera.</returns>
        Response TestSender();

        /// <summary>
        /// Metoda wysyłająca wiadomość.
        /// </summary>
        /// <returns>Odowiedź otrzymana od serwera/</returns>
        /// <param name="mail">Wiadomość którą chcemy wysłać.</param>
        Response SendMail(Mail mail);

        Response SendMail(Mail mail, Receiver recipient);

        Response SendMail(Mail mail, List<Receiver> recipient);

        List<Receiver> GetRecpients();

        bool AddReceiver(Receiver receiver);
    }
}
