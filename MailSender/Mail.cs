// -----------------------------------------------------------------------
//  <copyright file="Mail.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Klasa przechowująca wiadomość email.
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="MailSender.Mail"/>.
        /// </summary>
        /// <param name="content">Treść wiadomości</param>
        /// <param name="subject">Temat wiadomości.</param>
        /// <param name="html">If set to <c>true</c> html than message contains html content.</param>
        public Mail(string content, string subject, bool html)
        {
            this.Content = content;
            this.Subject = subject;
            this.Html = html;
        }

        /// <summary>
        /// Pobiera lub ustawia treść wiadomości
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Pobiera lub ustawia temat wiadomości
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Pobiera lub ustawia wartość wskazującą, czy wiadomość zawiera treści html
        /// </summary>
        public bool Html { get; set; }
    }
}
