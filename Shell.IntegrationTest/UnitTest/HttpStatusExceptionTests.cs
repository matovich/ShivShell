using NUnit.Framework;
using Shell.DomainLayer.Exceptions;
using System.Net;


namespace Shell.IntegrationTest.UnitTest
{
    [TestFixture]
    internal class HttpStatusExceptionTests
    {
        private class TestableHttpStatusException : HttpStatusException
        {
            public TestableHttpStatusException(HttpStatusCode statusCode) : base(statusCode)
            {
            }

            public TestableHttpStatusException(HttpStatusCode statusCode, string message) : base(statusCode, message)
            {
            }
        }

        [Test]
        public void HttpStatusException_HasDefaultTitle()
        {
            var testException = new TestableHttpStatusException(HttpStatusCode.BadRequest);

            Assert.AreEqual("An error occurred", testException.ErrorTitle);
        }

        [Test]
        public void HttpStatusException_HandlesEmptyMessage()
        {
            var expectedMessageEnd = "(no message).";
            var testException = new TestableHttpStatusException(HttpStatusCode.BadRequest);

            var result = testException.ToString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.EndsWith(expectedMessageEnd), $"""Error message should have ended with "{expectedMessageEnd}" but was: {result}""");
        }

        [Test]
        public void HttpStatusException_HandlesNullMessage()
        {
            var expectedMessageEnd = "(no message).";
            var testException = new TestableHttpStatusException(HttpStatusCode.BadRequest, null);

            var result = testException.ToString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.EndsWith(expectedMessageEnd), $"""Error message should have ended with "{expectedMessageEnd}" but was: {result}""");
        }

        [Test]
        public void HttpStatusException_HandlesMessage()
        {
            var expectedMessageEnd = "Bummer.";
            var testException = new TestableHttpStatusException(HttpStatusCode.BadRequest, "Bummer");

            var result = testException.ToString();

            Assert.IsTrue(result.EndsWith(expectedMessageEnd), $"""Error message should have ended with "{expectedMessageEnd}" but was: {result}""");
        }

        [Test]
        public void HttpStatusException_HandlesInvalidHttpStatusCode()
        {
            var invalidStatusCodeNumber = 24562;
            var testException = new TestableHttpStatusException((HttpStatusCode)invalidStatusCodeNumber);

            var result = testException.ToString();

            Assert.IsTrue(result.Contains($"[{invalidStatusCodeNumber}]"), $"The status code number [{invalidStatusCodeNumber}] should have been in the result but was: {result}");
        }
    }
}
