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
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "number", EmitDefaultValue = false)]
        public int Number { get; set; }
    }
}

