// -----------------------------------------------------------------------
//  <copyright file="MandrillMailStatus.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;    

    [DataContract]
    public class MandrillMailStatus
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "reject_reason")]
        public string RejectReason { get; set; }

        [DataMember(Name = "_id")]
        public string ID { get; set; }
    }
}
