// -----------------------------------------------------------------------
//  <copyright file="MailChimpRequest.cs" company="DevCore.NET">
//      Author: Milena Farfułowska (m.farfulowskai@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using MailSender;

    [DataContract]
    public class MailChimpRequest
    {
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string ApiKey { get; set; }

        /// <summary>
        /// Pobiera lub ustawia id kampanii.
        /// </summary>
        /// <value>Id kampanii</value>
        [DataMember(Name = "cid", EmitDefaultValue = false)]
        public string CId { get; set; }

        /// <summary>
        /// Pobiera lub ustawia typ kampani, jeden z "regular", "plaintext", "absplit", "rss", "auto".
        /// </summary>
        /// <value>Typ kampani</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Pobiera lub ustawia opcje wysyłanej kampanii
        /// </summary>
        /// <value>The options.</value>
        [DataMember(Name = "options", EmitDefaultValue = false)]
        public MailChimpOptions Options { get; set; }
    }
}
