// -----------------------------------------------------------------------
//  <copyright file="MandrillResponse.cs" company="DevCore.NET">
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
        /// <summary>
        /// Pobiera lub ustawia status wiadomości.
        /// </summary>
        /// <value>Status wiadomości</value>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Pobiera lub ustawia ping.
        /// </summary>
        /// <value>Sprawdzenie połączenia</value>
        [DataMember(Name = "PING")]
        public string Ping { get; set; }

        /// <summary>
        /// Pobiera lub ustawia zwracaną wiadomość.
        /// </summary>
        /// <value>Wiadomość zwracana przez serwer</value>
        [DataMember(Name = "message")]
        public string Messege { get; set; }

        /// <summary>
        /// Pobiera lub ustawia nazwę zwracanego błędu.
        /// </summary>
        /// <value>Nazwa błędu</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Pobiera lub ustawia kod zwracanego błędu.
        /// </summary>
        /// <value>Kod błędu</value>
        [DataMember(Name = "code")]
        public int Code { get; set; }

        /// <summary>
        /// Pobiera lub ustawia kod zwracanego błędu.
        /// </summary>
        /// <value>Lista odpwiedzi z serwera dla wysłanych emaili</value>
        [DataMember(Name = "", EmitDefaultValue = false)]
        public List<MandrillMailStatus> Responses { get; set; }
    }
}
