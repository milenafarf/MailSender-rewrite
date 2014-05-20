using System;

namespace MailChimpMailSender
{
    using MailSender;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

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
        ///Pobiera lub ustawia typ kampani, jeden z "regular", "plaintext", "absplit", "rss", "auto".
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
    }

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

