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

    /// <summary>
    /// Testy serializera obiektów do JSONa.
    /// </summary>
    [TestFixture]
    public class JsonSerializerTest
    {
        /// <summary>
        /// Testuje podstawową serializację obiektu do JSON.
        /// </summary>
        [Test]
        public void TestCase()
        {
            var testObj = new TestJsonObject();
            testObj.Number = 1;
            testObj.Text = "testowy string";
            var serializer = new JsonSerializer<TestJsonObject>();
            var testJson = serializer.Serialize(testObj);
            StringAssert.IsMatch("\"text\"", testJson);
            StringAssert.IsMatch("\"testowy string\"", testJson);
            StringAssert.IsMatch("\"number\"", testJson);
            StringAssert.IsMatch("1", testJson);
        }

        /// <summary>
        /// Testuje serializacje niepełnego obiektu,
        /// w wyjściowym obiekcie JSON nie powinny znaleźć się pola
        /// z atrybutem "EmitDefaultValue = false"
        /// </summary>
        [Test]
        public void TestCase2()
        {
            var testObj = new TestJsonObject();
            testObj.Number = 1;
            var serializer = new JsonSerializer<TestJsonObject>();
            var testJson = serializer.Serialize(testObj);
            StringAssert.IsMatch("\"number\"", testJson);
            StringAssert.IsMatch("1", testJson);
            StringAssert.DoesNotMatch("\"text\"", testJson);
        }
    }
}
