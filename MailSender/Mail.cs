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
		public Mail(string content)
		{
			Content = content;
		}

		public string Content{ get; set; }
    }
}
