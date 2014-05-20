// -----------------------------------------------------------------------
//  <copyright file="MailChimpRequest.cs" company="m (m.dobrzynski@outlook.com)">
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
        [DataMember(Name = "html", EmitDefaultValue = false)]
        public string Html { get; set; }

        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }
    }
}
