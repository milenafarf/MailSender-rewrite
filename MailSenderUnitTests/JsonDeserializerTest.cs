// -----------------------------------------------------------------------
//  <copyright file="JsonDeserializerTest.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderUnitTests
{
    using MailSenderHelpers;
    using NUnit.Framework;

    /// <summary>
    /// Testy serializera obiektów do JSONa.
    /// </summary>
    [TestFixture]
    public class JsonDeserializerTest
    {
        /// <summary>
        /// Testuje podstawową deserializację niepełnego obiektu
        /// </summary>
        [Test]
        public void TestCase()
        {
            string testJson = "{ \"text\" : \"testowy string\" }";
            var a = new JsonDeserializer<TestJsonObject>();
            TestJsonObject testObject = a.Deserialize(testJson);
            StringAssert.AreEqualIgnoringCase(
                "testowy string", testObject.Text);
            Assert.AreEqual(0, testObject.Number);
        }

        /// <summary>
        /// Testuje rozróźnianie małych oraz wielkich liter w nazwach pól
        /// oraz przekazywanie pól w złej kolejności wewnątrz obiektu JSON.
        /// </summary>
        [Test]
        public void TestCase2()
        {
            string testJson = "{ \"NuMbEr\" : 1, \"text\" : \"testowy string\" }";
            var a = new JsonDeserializer<TestJsonObject>();
            TestJsonObject testObject = a.Deserialize(testJson);
            Assert.AreNotEqual(testObject.Number, 1);
            StringAssert.AreEqualIgnoringCase(
                "testowy string", testObject.Text);
        }
    }
}
