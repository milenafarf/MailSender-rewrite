// -----------------------------------------------------------------------
//  <copyright file="MandrillRequest.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
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
}
