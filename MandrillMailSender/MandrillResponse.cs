// -----------------------------------------------------------------------
//  <copyright file="MandrillResponse.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System.Runtime.Serialization;
    //cokolwiek
    [DataContract]
    public class MandrillResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "PING")]
        public string Ping { get; set; }

        [DataMember(Name = "message")]
        public string Messege { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "code")]
        public int Code { get; set; }
    }
}
