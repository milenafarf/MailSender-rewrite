// -----------------------------------------------------------------------
//  <copyright file="MainClass.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace TestApp
{
    using MailSender;
    using MandrillMailSender;

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
            ISender mandrill = new MandrillSender("", "");
            mandrill.TestSender();
        }
    }
}
