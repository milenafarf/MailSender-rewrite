// -----------------------------------------------------------------------
//  <copyright file="MandrillTo.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using MailSender;

    [DataContract]
    public class MandrillTo
    {
        /// <summary>
        /// Inicjalizuje nową instancję? klasy <see cref="MandrillTo" />.
        /// </summary>
        /// <param name="receiver">Odbiorca wiadomo?ci</param>
        public MandrillTo(Receiver receiver)
        {
            this.Email = receiver.Email;
            this.Name = receiver.Name;
            this.Type = "to";
        }

        /// <summary>
        /// Pobiera lub ustawia adres email odbiorcy.
        /// </summary>
        /// <value>The email.</value>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// Pobiera lub ustawia nazwę odbiorcy emaila
        /// </summary>
        /// <value>Nazwa odbiorcy emaila.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Pobiera lub ustawia typ odbiorcy, jedno z to, cc, bcc
        /// </summary>
        /// <value>Typ odbiorcy, jedno z to, cc, bcc</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }
    }
}
