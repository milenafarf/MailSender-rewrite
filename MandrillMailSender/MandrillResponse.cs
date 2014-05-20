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
		/// Pobiera lub ustawia status wiadomości.
		/// </summary>
		/// <value>Status wiadomości</value>
		public string Status { get; set; }

        [DataMember(Name = "PING")]
		/// <summary>
		/// Pobiera lub ustawia ping.
		/// </summary>
		/// <value>Sprawdzenie połączenia</value>
		public string Ping { get; set; }

        [DataMember(Name = "message")]
		/// <summary>
		/// Pobiera lub ustawia zwracaną wiadomość.
		/// </summary>
		/// <value>Wiadomość zwracana przez serwer</value>
		public string Messege { get; set; }

        [DataMember(Name = "name")]
		/// <summary>
		/// Pobiera lub ustawia nazwę zwracanego błędu.
		/// </summary>
		/// <value>Nazwa błędu</value>
		public string Name { get; set; }

        [DataMember(Name = "code")]
		/// <summary>
		/// Pobiera lub ustawia kod zwracanego błędu.
		/// </summary>
		/// <value>Kod błędu</value>
		public int Code { get; set; }
	
        [DataMember(Name = "", EmitDefaultValue = false)]
		/// <summary>
		/// Pobiera lub ustawia kod zwracanego błędu.
		/// </summary>
		/// <value>Lista odpwiedzi z serwera dla wysłanych emaili</value>
		public List<MandrillResponse> Responses { get; set; }
    }
}
