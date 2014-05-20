// -----------------------------------------------------------------------
//  <copyright file="Mail.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    using System;

    /// <summary>
    /// Klasa przechowująca wiadomość email.
    /// </summary>
    public class Mail
    {
        public string to{ get; set; }
        public string content{ get; set; }
    }
}
