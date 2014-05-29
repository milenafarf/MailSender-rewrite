// -----------------------------------------------------------------------
//  <copyright file="MailChimpFilters.cs" company="DevCore.NET">
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
    /// Filtry do uzyskiwania list odbiorców kampanii
    /// </summary>
    [DataContract]
    public class MailChimpFilters
    {
        /// <summary>
        /// Pobiera lub ustawia id listy odbiorców kampanii
        /// </summary>
        /// <value>Identyfikator listy odbiorców kampanii</value>
        [DataMember(Name = "list_id", EmitDefaultValue = false)]
        public string ListId { get; set; }

        /// <summary>
        /// Pobiera lub ustawia nazwę listy odbiorców kampanii
        /// </summary>
        /// <value>Filtr nazwy listy odbiorców kampanii</value>
        [DataMember(Name = "list_name", EmitDefaultValue = false)]
        public string ListName { get; set; }

        /// <summary>
        /// Pobiera lub ustawia filtr daty utworzenia listy subskrybentów.
        /// </summary>
        /// <value>Filtr zwróci listę list subskrybentów utworzonych przed wskazaną datą, format daty 24-godzinny, np. "2013-12-30 20:30:00".</value>
        [DataMember(Name = "created_before", EmitDefaultValue = false)]
        public string CreatedBefore { get; set; }

        /// <summary>
        /// Pobiera lub ustawia filtr daty utworzenia listy subskrybentów.
        /// </summary>
        /// <value>Filtr zwróci listę list subskrybentów utworzonych po wskazanej dacie, format daty 24-godzinny, np. "2013-12-30 20:30:00".</value>
        [DataMember(Name = "created_after", EmitDefaultValue = false)]
        public string CreatedAfter { get; set; }
    }
}
