// -----------------------------------------------------------------------
//  <copyright file="JsonSerializerTest.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderUnitTests
{
    using System;
    using MailSenderHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testy serializera obiektów do JSONa.
    /// </summary>
    [TestClass]
    public class JsonSerializerTest
    {
        /// <summary>
        /// Testuje podstawową serializację obiektu do JSON.
        /// </summary>
        [TestMethod]
        public void TestCase()
        {
            var testObj = new TestJsonObject();
            testObj.Number = 1;
            testObj.Text = "testowy string";
            var serializer = new JsonSerializer<TestJsonObject>();
            var testJson = serializer.Serialize(testObj);
            StringAssert.Contains(testJson, "\"text\"");
            StringAssert.Contains(testJson, "\"testowy string\"");
            StringAssert.Contains(testJson, "\"number\"");
            StringAssert.Contains(testJson, "1");
        }

        /// <summary>
        /// Testuje serializacje niepełnego obiektu.
        /// </summary>
        [TestMethod]
        public void TestCase2()
        {
            var testObj = new TestJsonObject();
            testObj.Number = 1;
            var serializer = new JsonSerializer<TestJsonObject>();
            var testJson = serializer.Serialize(testObj);
            StringAssert.Contains(testJson, "\"number\"");
            StringAssert.Contains(testJson, "1");
        }
    }
}
