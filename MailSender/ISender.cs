// -----------------------------------------------------------------------
//  <copyright file="ISender.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    using System;

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
    }
}
