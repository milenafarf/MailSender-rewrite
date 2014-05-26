// -----------------------------------------------------------------------
//  <copyright file="MailChimpRequest.cs" company="DevCore.NET">
//      Author: Milena Farfułowska (m.farfulowskai@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using System.Runtime.Serialization;
    using System.Collections.Generic;

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
        /// Pobiera lub ustawia wiadomosc zwrotną, czy udało sie nawiazac połącznie.
        /// </summary>
        /// <value>The message.</value>
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
    }
}
