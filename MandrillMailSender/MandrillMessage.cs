// -----------------------------------------------------------------------
//  <copyright file="MandrillMessage.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using MailSender;

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

}
