// -----------------------------------------------------------------------
//  <copyright file="MainClass.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace TestApp
{
    using MailSender;
    using MandrillMailSender;
    using MailChimpMailSender;
    using System.Collections.Generic;

    /// <summary>
    /// Klasa programu testującego działanie klas MandrillMailSender
    /// oraz MailChimpMailSender
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Metoda główna programu.
        /// </summary>
        /// <param name="args">Parametry przekazane do programu.</param>
        public static void Main(string[] args)
        {
            ITransactionalSender mandrill = new MandrillSender("", "");
            mandrill.TestSender();

            INewsletterSender mailchimp = new MailChimpSender("", "frommail@from.mail");
            List<SubscribersList> lists = mailchimp.GetAllLists();
            mailchimp.TestSender();
        }
    }
}
