// -----------------------------------------------------------------------
//  <copyright file="JsonDeserializerTest.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderUnitTests
{
    using MailSenderHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testy serializera obiektów do JSONa.
    /// </summary>
    [TestClass]
    public class JsonDeserializerTest
    {
        /// <summary>
        /// Testuje podstawową deserializację niepełnego obiektu
        /// </summary>
        [TestMethod]
        public void TestJsonDeserializer()
        {
            string testJson = "{ \"text\" : \"testowy string\" }";
            var a = new JsonDeserializer<TestJsonObject>();
            TestJsonObject testObject = a.Deserialize(testJson);
            StringAssert.Contains(
                "testowy string",
                testObject.Text);
            Assert.AreEqual(0, testObject.Number);
        }

        /// <summary>
        /// Testuje rozróźnianie małych oraz wielkich liter w nazwach pól
        /// oraz przekazywanie pól w złej kolejności wewnątrz obiektu JSON.
        /// </summary>
        [TestMethod]
        public void TestJsonDeserializer2()
        {
            string testJson = "{ \"NuMbEr\" : 1, \"text\" : \"testowy string\" }";
            var a = new JsonDeserializer<TestJsonObject>();
            TestJsonObject testObject = a.Deserialize(testJson);
            Assert.AreNotEqual(testObject.Number, 1);
            StringAssert.Contains(
                "testowy string",
                testObject.Text);
        }
    }
}
