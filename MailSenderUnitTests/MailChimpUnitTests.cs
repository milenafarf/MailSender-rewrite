// -----------------------------------------------------------------------
//  <copyright file="UnitTestsMailChimp.cs" company="DevCore.NET">
//      Author: m (chrystian.kislo@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderUnitTests
{
    using System;
    using MailChimpMailSender;
    using MailSender;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Przetestowane metody z klasy MailChimpSender:
    /// MailChimpSender.TestSender() : Response 
    /// MailChimpSender.GetSubscribersList(string listName) : Response 
    /// MailChimpSender.AddSubscriberTolistByName(string listName, Reciver subscriber) : Response
    /// MailChimpSender.CreateCampaign(string listId, string subject, string toName) : Response
    /// </summary>
    [TestClass]
    public class MailChimpUnitTests
    {
        /// <summary>
        /// Sender MailChimpa. Główny obiekt do testowania.
        /// </summary>
        private static MailChimpSender sender;
        
        /// <summary>
        /// Odbiorca, który jest dodawany do listy subskrybentów i do którego są wysyłane maile w testach.
        /// </summary>
        private static Receiver subscriber;

        /// <summary>
        /// Nazwa listy, którą testujemy przy dodawaniu do niej subskrybentów i tworzeniu kampanii.
        /// </summary>
        private static string listName;

        /// <summary>
        /// Temat kampanii, jak i również jego nazwa.
        /// </summary>
        private static string campaignSubject;

        /// <summary>
        /// Nazwa subkrybentów, dla których jest tworzona kampaniia.
        /// </summary>
        private static string campaignSubscribers;

        /// <summary>
        /// Inicjalizacja statycznych pól klasy testującej.
        /// Inicjalizowane są tutaj jedynie dane, których poprawność jest sprawdzana w testach, w których metody mają wykonać się poprawnie.
        /// </summary>
        /// <param name="context">context klasy testującej</param>
        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            sender = new MailChimpSender("2e2e7fde6dd70c570ed24de4668df1f5-us8", "testmailsender4@gmail.com");
            
            subscriber = new Receiver("testmailsender4@gmail.com", "testmailsender");
            
            listName = "testlist";

            campaignSubject = "TestCampaign";
            campaignSubscribers = "TestSubscribers";
        }

        /// <summary>
        /// Testowana metoda MailChimpMailSender.TestSender();
        /// W razie powodzenia zwróci odpowiedź potwierdzającą połączenie z serwerem.
        /// </summary>
        [TestMethod]
        public void TestMailChimpApiKey_ReturnOk()
        {
            Response r = sender.TestSender();
            Assert.IsTrue(r.Code == Response.ResponseCode.Ok);
        }

        /// <summary>
        /// Testowana metoda MailChimpMailSender.GetSubscribersList(string);
        /// Potrzebuje poprawki
        /// </summary>
        [TestMethod]
        public void TestMailChimpGetSubscibersList_ReturnOk()
        {
            Response r = sender.GetSubscribersList(listName);
            Assert.IsTrue(r.Code == Response.ResponseCode.Ok);
        }

        /// <summary>
        /// Testowana metoda MailChimpMailSender.AddSubscriberTolistByName(string listName, Reciver subscriber);
        /// W razie powodzenia wyślę maila do Receiver z zapytaniem, czy chce brać udział w subskrybcji.
        /// Dodać przypadek kiedy sub. już jest i usunąć go i znowu dodać.
        /// </summary>
        [TestMethod]
        public void TestMailChimpAddSubscriberToListByName_ReturnOk()
        {
            Response r = sender.AddSubscriberTolistByName(listName, subscriber);
            Assert.IsTrue(r.Code == Response.ResponseCode.Ok);
        }

        /// <summary>
        /// Testowana metoda MailChimpMailSender.CreateCampaign(string listId, string subject, string toName);
        /// dodać usunięcie gdy jest i dodanie znów.
        /// </summary>
        [TestMethod]
        public void TestMailChimpCreateCampaign_ReturnOk()
        {
            Response r = sender.CreateCampaign(sender.getSubscriberIdListByName(listName),campaignSubject,campaignSubscribers);
            Assert.IsTrue(r.Code == Response.ResponseCode.Ok);
        }
    }
}
