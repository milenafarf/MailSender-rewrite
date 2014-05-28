// -----------------------------------------------------------------------
//  <copyright file="HttpIOUnitTests.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderUnitTests
{
    using MailSenderHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HttpIOUnitTests
    {
        [TestMethod]
        public void TestHttpIO()
        {
            var connector = new HttpIO(
                "http://httpbin.org/",
                "text/plain");
            var request = "test polaczenia";
            var response = connector.ProcessRequest(
                "post",
                request);
            StringAssert.Contains(response, request);
        }
    }
}

