// -----------------------------------------------------------------------
//  <copyright file="HttpIOUnitTests.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderUnitTests
{
    using NUnit.Framework;
    using MailSenderHelpers;

    [TestFixture]
    public class HttpIOUnitTests
    {
        [Test]
        public void TestCase()
        {
            var connector = new HttpIO(
                "http://httpbin.org/",
                "text/plain");
            var request = "test polaczenia";
            var response = connector.ProcessRequest(
                "post",
                request);
            StringAssert.Contains(request, response);
        }
    }
}

