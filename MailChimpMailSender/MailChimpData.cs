﻿// -----------------------------------------------------------------------
//  <copyright file="MailChimpData.cs" company="DevCore.NET">
//      Author: Milena Farfułowska (m.farfulowskai@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using MailSender;

    /// <summary>
    /// Dane o liście spełniającej warunki podanych filtrów
    /// </summary>
    [DataContract]
    public class MailChimpData
    {
        /// <summary>
        /// Pobiera lub ustawia id listy
        /// </summary>
        /// <value>The email.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Pobiera lub ustawia id listy w aplikacji MailChimp
        /// </summary>
        /// <value>The webid.</value>
        [DataMember(Name = "web_id", EmitDefaultValue = false)]
        public int Webid { get; set; }

        /// <summary>
        /// Pobiera lub ustawia nazwę listy subskrybentów
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Pobiera lub ustawia datę utworzenia listy subskrybentów
        /// </summary>
        [DataMember(Name = "date_created", EmitDefaultValue = false)]
        public string Datecreated { get; set; }
    }
}
