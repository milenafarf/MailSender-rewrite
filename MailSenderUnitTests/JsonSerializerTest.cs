// -----------------------------------------------------------------------
//  <copyright file="JsonSerializerTest.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderUnitTests
{
    using System;
    using MailSenderHelpers;
    using NUnit.Framework;

    [TestFixture]
    /// <summary>
    /// Testy serializera obiektów do JSONa.
    /// </summary>
    public class JsonSerializerTest
    {
        [Test]
        public void TestCase()
        {
            var testObj = new TestJsonObject();
            testObj.Number = 1;

        }
    }
}
