// -----------------------------------------------------------------------
//  <copyright file="MandrillResponse.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MandrillMailSender
{
	using System.Collections.Generic;
    using System.Runtime.Serialization;    

    [DataContract]
    public class MandrillResponse
    {

        [DataMember(Name = "status")]
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public string Status { get; set; }

        [DataMember(Name = "PING")]
		/// <summary>
		/// Gets or sets the ping.
		/// </summary>
		/// <value>The ping.</value>
		public string Ping { get; set; }

        [DataMember(Name = "message")]
		/// <summary>
		/// Gets or sets the messege.
		/// </summary>
		/// <value>The messege.</value>
		public string Messege { get; set; }

        [DataMember(Name = "name")]
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

        [DataMember(Name = "code")]
		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>The code.</value>
		public int Code { get; set; }
	
        [DataMember(Name = "", EmitDefaultValue = false)]
		/// <summary>
		/// Gets or sets the responses.
		/// </summary>
		/// <value>The responses.</value>
		public List<MandrillResponse> Responses { get; set; }
    }
}
