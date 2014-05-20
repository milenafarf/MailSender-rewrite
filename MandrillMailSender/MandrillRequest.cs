// -----------------------------------------------------------------------
//  <copyright file="MandrillRequest.cs" company="DevCore.NET">
//      Author: Mateusz Dobrzy駍ki (m.dobrzynski@outlook.com),
//             Chrystian Kis硂
//             Milena Farfu硂wska (m.farfulowska@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
	using MailSender;
	using System.Collections.Generic;
    using System.Runtime.Serialization;

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

    [DataContract]
    public class MandrillMessage
    {
		MandrillMessage(Mail mail)
		{
			if (mail.Html)
				this.Html = mail.Content;
			else
				this.Text = mail.Content;
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
		/// Inicjalizuje nową instancę klasy <see cref="MandrillMailSender.MandrillTo"/>.
		/// </summary>
		/// <param name="receiver">Odbiorca emaila..</param>
        MandrillTo(Receiver receiver)
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
