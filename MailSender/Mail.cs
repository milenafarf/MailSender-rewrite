// -----------------------------------------------------------------------
//  <copyright file="Mail.cs" company="m (m.dobrzynski@outlook.com)">
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
        public List<To> to { get; set; }
        public string content{ get; set; }
    }

    public class To
    {
        public string emai { get; set; }
        public string name{ get; set; }
    }
}
