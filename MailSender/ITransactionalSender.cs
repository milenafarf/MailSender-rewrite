// -----------------------------------------------------------------------
//  <copyright file="ITransactionalSender.cs" company="DevCore.NET">
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
    public interface ITransactionalSender
    {
        /// <summary>
        /// Metoda sprawdzająca czy połączenie z serwisem działa poprawnie.
        /// </summary>
        /// <returns>Odowiedź otrzymana od serwera.</returns>
        Response TestSender();

        /// <summary>
        /// Metoda wysyłająca wiadomość.
        /// </summary>
        /// <returns>Odowiedź otrzymana od serwera.</returns>
        /// <param name="mail">Wiadomość którą chcemy wysłać.</param>
        /// <param name="receiver">Odbiorca wiadomości.</param>
        Response SendMail(Mail mail, Receiver receiver);

        /// <summary>
        /// Metoda wysyłająca wiadomość do wielu odbiorców.
        /// </summary>
        /// <param name="mail">Wiadomość którą chcemy wysłać.</param>
        /// <param name="receivers">Lista zawierająca odbiorców wiadomości.</param>
        /// <returns>Odowiedź otrzymana od serwera.</returns>
        Response SendMail(Mail mail, List<Receiver> receivers);

    }
}
