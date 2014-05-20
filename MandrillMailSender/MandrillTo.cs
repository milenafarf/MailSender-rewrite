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
