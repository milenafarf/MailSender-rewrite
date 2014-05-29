// -----------------------------------------------------------------------
//  <copyright file="MailChimpResponse.cs" company="DevCore.NET">
//      Author: Milena Farfułowska (m.farfulowskai@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Klasa odpowiadająca danym otrzymywanym jako odpowiedź z serwisu MailChimp
    /// </summary>
    [DataContract]
    public class MailChimpResponse
    {
        /// <summary>
        /// Pobiera lub ustawia liczbę kampanii spełniających kryteria zapytania.
        /// </summary>
        /// <value>Status wiadomości</value>
        [DataMember(Name = "total")]
        public string Total { get; set; }

        /// <summary>
        /// Pobiera lub ustawia zawartość html kampanii.
        /// </summary>
        /// <value>The HTML content used for the campaign with merge tags intact</value>
        [DataMember(Name = "html")]
        public string Html { get; set; }

        /// <summary>
        /// Pobiera lub ustawia tekst.
        /// </summary>
        /// <value>The Text content used for the campaign with merge tags intact</value>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Pobiera lub ustawia wiadomość zwrotną, czy udało się nawiązać połącznie.
        /// </summary>
        /// <value>Wiadomość zwrotna, czy udało się nawiązać połączenie z serwisem MailChimp</value>
        [DataMember(Name = "msg")]
        public string Msg { get; set; }

        /// <summary>
        /// Pobiera lub ustawia status wiadomości.
        /// </summary>
        /// <value>Status wiadomości</value>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Pobiera lub ustawia kod zwracanego błędu.
        /// </summary>
        /// <value>Kod błędu</value>
        [DataMember(Name = "code")]
        public int Code { get; set; }

        /// <summary>
        /// Pobiera lub ustawia nazwę zwracanego błędu.
        /// </summary>
        /// <value>Nazwa błędu</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Pobiera lub ustawia zwracaną wiadomość.
        /// </summary>
        /// <value>Wiadomość zwracana przez serwer</value>
        [DataMember(Name = "error")]
        public string Error { get; set; }

        /// <summary>
        /// Pobiera lub ustawia dane o listach subskrybentów pasujących do przekazanych w zapytaniu filtrów
        /// </summary>
        [DataMember(Name = "data")]
        public List<MailChimpData> Data { get; set; }

        /// <summary>
        /// Pobiera lub ustawia powiadamia czy zostało wykonane zadanie związane z zatrzymaniem, bądź ponownym wystartowaniem kampanii.
        /// </summary>
        [DataMember(Name = "complete")]
        public string Complete { get; set; }

        /// <summary>
        /// Pobiera lub ustawia adres email dodany do listy subskrybentów
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Pobiera lub ustawia id adresu email dodany do listy subskrybentów
        /// </summary>
        [DataMember(Name = "euid")]
        public string Euid { get; set; }

        /// <summary>
        /// Pobiera lub ustawia id adres email jako członka listy do której został dodany
        /// </summary>
        [DataMember(Name = "leid")]
        public string Leid { get; set; }
    }
}
