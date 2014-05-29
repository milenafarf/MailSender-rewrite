// -----------------------------------------------------------------------
//  <copyright file="MailChimpContent.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using MailSender;

    /// <summary>
    /// Zawartość kampanii
    /// </summary>
    [DataContract]
    public class MailChimpContent
    {
        /// <summary>
        /// Pobiera lub ustawia treść html kampanii.
        /// </summary>
        /// <value>The html.</value>
        [DataMember(Name = "html", EmitDefaultValue = false)]
        public string Html { get; set; }

        /// <summary>
        /// Pobiera lub ustawia tekst emaila.
        /// </summary>
        /// <value>Tekst maila.</value>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }
    }
}
