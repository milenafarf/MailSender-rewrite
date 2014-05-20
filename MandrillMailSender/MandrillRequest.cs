// -----------------------------------------------------------------------
//  <copyright file="MandrillRequest.cs" company="DevCore.NET">
//      Author: Mateusz Dobrzyñski (m.dobrzynski@outlook.com),
//             Chrystian Kis³o
//             Milena Farfu³owska (m.farfulowska@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System.Runtime.Serialization;
    using System.Collections.Generic;

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
        [DataMember(Name = "html", EmitDefaultValue = false)]
        public string Html { get; set; }

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
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }
    }
}
