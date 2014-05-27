// -----------------------------------------------------------------------
//  <copyright file="MainClass.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace TestApp
{
    using System;
    using MailSender;
    using MandrillMailSender;
    using MailChimpMailSender;

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
            //ITransactionalSender mandrill = new MandrillSender ("apikey", "frommail");
            //mandrill.TestSender();
            INewsletterSender mailchimp = new MailChimpSender("apikey-us8", "from@from.from");
            mailchimp.TestSender ();
            //mailchimp.ToString ();
        }
    }
}
