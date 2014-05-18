// -----------------------------------------------------------------------
//  <copyright file="MandrillRequest.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Mandrill request.
    /// </summary>
    [DataContract]
    public class MandrillRequest
    {
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string ApiKey { get; set; }
    }
}
