// -----------------------------------------------------------------------
//  <copyright file="MandrillRequest.cs" company="DevCore.NET">
//      Author: Mateusz Dobrzy?ski (m.dobrzynski@outlook.com),
//             Chrystian Kis?o
//             Milena Farfu?owska (m.farfulowska@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using MailSender;

/// <summary>
    /// Mandrill request.
    /// </summary>
    [DataContract]
    public class MandrillRequest
    {
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string ApiKey { get; set; }

        [DataMember(Name = "message", EmitDefaultValue = false)]
        public MandrillMessage Message { get; set; }
    }

    /// <summary>
    /// Mandrill message.
    /// </summary>
    [DataContract]
    public class MandrillMessage
    {
        public MandrillMessage(Mail mail)
        {
            if (mail.Html)
            {
                this.Html = mail.Content;
            }
            else 
            {
                this.Text = mail.Content;
            }

            this.Subject = mail.Subject;
            this.FromEmail = "testmailsender4@gmail.com";
            this.FromName = "testmailsender4@gmail.com";
        }

        [DataMember(Name = "html", EmitDefaultValue = false)]
        public string Html { get; set; }

        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }

        [DataMember(Name = "subject", EmitDefaultValue = false)]
        public string Subject { get; set; }

        [DataMember(Name = "from_email", EmitDefaultValue = false)]
        public string FromEmail { get; set; }

        [DataMember(Name = "from_name", EmitDefaultValue = false)]
        public string FromName { get; set; }

        [DataMember(Name = "to", EmitDefaultValue = false)]
        public List<MandrillTo> To { get; set; }
    }

    [DataContract]
    public class MandrillTo
    {
        /// <summary>
        /// Inicjalizuje now? instancj? klasy <see cref="MandrillTo" />.
        /// </summary>
        /// <param name="receiver">Odbiorca wiadomo?ci</param>
        public MandrillTo(Receiver receiver)
        {
            this.Email = receiver.Email;
            this.Name = receiver.Name;
            this.Type = "to";
        }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }
    }
}
