// -----------------------------------------------------------------------
//  <copyright file="MailChimpSender.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using MailSender;

    /// <summary>
    /// Mail chimp sender.
    /// </summary>
    public class MailChimpSender : ISender
    {
        public MailChimpSender(string apikey)
        {
        }

        #region ISender implementation

        public Response TestSender ()
        {
            throw new NotImplementedException ();
        }

        public Response SendMail (Mail mail)
        {
            throw new NotImplementedException ();
        }

        #endregion
    }
}

