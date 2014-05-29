// -----------------------------------------------------------------------
//  <copyright file="MailChimpOptions.cs" company="DevCore.NET">
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
    /// Opcje Kampanii
    /// </summary>
    [DataContract]
    public class MailChimpOptions
    {
        /// <summary>
        /// Pobiera lub ustawia id listy odbiorców kampanii.
        /// </summary>
        /// <value>Identyfikator listy odbiorców kampanii</value>
        [DataMember(Name = "list_id", EmitDefaultValue = false)]
        public string ListId { get; set; }

        [DataMember(Name = "subject", EmitDefaultValue = false)]
        public string Subject { get; set; }

        [DataMember(Name = "from_email", EmitDefaultValue = false)]
        public string FromEmail { get; set; }

        [DataMember(Name = "from_name", EmitDefaultValue = false)]
        public string FromName { get; set; }

        /// <summary>
        /// Pobiera lub ustawia nazwa odbiorcy (nie adres email)
        /// </summary>
        /// <value>Nazwa odbiorcy</value>
        [DataMember(Name = "to_name", EmitDefaultValue = false)]
        public string ToName { get; set; }

        /// <summary>
        /// Pobiera lub ustawia tytuł kampanii. W razie niepodania kampania przyjmuje nazwę tematu.
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }
    }
}
