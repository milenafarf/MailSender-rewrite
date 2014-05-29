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

        public string Content { get; set; }

        public string Subject { get; set; }

        public bool Html { get; set; }
    }
}
