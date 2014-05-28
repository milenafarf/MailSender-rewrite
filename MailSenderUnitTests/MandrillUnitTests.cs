// -----------------------------------------------------------------------
//  <copyright file="UnitTestsMandrill.cs" company="DevCore.NET">
//      Author: m (chrystian.kislo@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderUnitTests
{
    using System;
    using MailSender;
    using MandrillMailSender;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Przetestowane metody z klasy MandrillMailSender:
    /// MandrillMailSender.TestSender() : Response 
    /// MandrillMailSender.SendMail(Mail, Reciver): Response 
    /// MandrillMailSender.SendMail(Mail, List"Receiver") : Response 
    /// </summary>
    [TestClass]
    public class MandrillUnitTests
    {
        /// <summary>
        /// Mail używany w testkach, które zwracają poprawną wartość.
        /// </summary>
        private static Mail mail;

        /// <summary>
        /// Główny obiekt testowany w bieżących testach.
        /// </summary>
        private static MandrillSender sender;

        /// <summary>
        /// Testowany odbiorca w testach zwracających poprawne wartości.
        /// </summary>
        private static Receiver recipient;
        
        /// <summary>
        /// Inicjalizacja danych wykorzystywanych w testach.
        /// </summary>
        /// <param name="context">context klasy testującej</param>
        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            mail = new Mail("Test content", "test subject", false);
            sender = new MandrillSender("Yt2RkGJrlFG6LD3BanmsWw", "testmailsender4@gmail.com");
            recipient = new Receiver("testmailsender4@gmail.com", "Good mail");
        }

        /// <summary>
        /// Test metody MandrillMailSender.SendMail(Mail, Reciver): Response 
        /// Odpowiedź zwrócona powinna potwierdzać wysłanie maila
        /// </summary>
        [TestMethod]
        public void SendMandrillMailTestResponseSent()
        {
            Response response = sender.SendMail(mail, recipient);
            Assert.AreEqual("sent", response.Message);
        }

        /// <summary>
        /// Test metody MandrillMailSender.SendMail(Mail, Reciver): Response 
        /// Odpowiedź zwrócona powinna potwierdzać zasygnalizować wpisanie niepoprawnego maila
        /// </summary>
        [TestMethod]
        public void SendMandrillMailTestResponseWrongMail()
        {
            Response response = sender.SendMail(mail, recipient);
            Assert.AreNotEqual("sent", response.Message);
        }

        /// <summary>
        /// Test metody MandrillMailSender.TestSender(): Response 
        /// Odpowiedź zwrócona powinna potwierdzać poprawność key API.
        /// </summary>
        [TestMethod]
        public void TestMandrillApiKeyResponseConnect()
        {
            Response response = sender.TestSender();
            Assert.AreNotEqual("Ping", response.Message);
        }
    }
}
