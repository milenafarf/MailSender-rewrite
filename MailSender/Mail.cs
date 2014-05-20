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
		/// <summary>
		/// Initializes a new instance of the <see cref="MailSender.Mail"/> class.
		/// </summary>
		/// <param name="content">Message content</param>
		/// <param name="subject">Subject.</param>
		/// <param name="html">If set to <c>true</c> html than message contains html content.</param>
		public Mail(string content, string subject, bool html)
		{			
			Content = content;
			Subject = subject;
			Html = html;
		}
		public string Content { get; set; }
		public string Subject { get; set; }
		public bool Html { get; set; }
	}
}
