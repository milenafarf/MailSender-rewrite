// -----------------------------------------------------------------------
//  <copyright file="TestJsonObject.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderUnitTests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TestJsonObject
    {
        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }
    }
}

