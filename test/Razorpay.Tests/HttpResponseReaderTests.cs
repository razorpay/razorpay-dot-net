using System.IO;
using System.Text;
using NUnit.Framework;
using Razorpay.Api.Http;

namespace Razorpay.Tests
{
    public class HttpResponseReaderTests
    {
        private static HttpResult Read(string raw)
        {
            return HttpResponseReader.Read(new MemoryStream(Encoding.UTF8.GetBytes(raw)));
        }

        [Test]
        public void ReadsContentLengthBody()
        {
            var result = Read("HTTP/1.1 200 OK\r\nContent-Length: 11\r\nContent-Type: application/json\r\n\r\n{\"id\":\"o1\"}");

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("{\"id\":\"o1\"}", result.Body);
        }

        [Test]
        public void ReadsChunkedBodyWithExtensionsAndTrailers()
        {
            var result = Read("HTTP/1.1 200 OK\r\nTransfer-Encoding: chunked\r\n\r\n" +
                              "5;ext=1\r\nhello\r\n6\r\n world\r\n0\r\nX-Trailer: t\r\n\r\n");

            Assert.AreEqual("hello world", result.Body);
        }

        [Test]
        public void SkipsInterimContinueResponse()
        {
            var result = Read("HTTP/1.1 100 Continue\r\n\r\nHTTP/1.1 201 Created\r\nContent-Length: 2\r\n\r\nok");

            Assert.AreEqual(201, result.StatusCode);
            Assert.AreEqual("ok", result.Body);
        }

        [Test]
        public void ReadsToEndWithoutLengthOrChunking()
        {
            var result = Read("HTTP/1.1 401 Unauthorized\r\nConnection: close\r\n\r\n{\"error\":{}}");

            Assert.AreEqual(401, result.StatusCode);
            Assert.AreEqual("{\"error\":{}}", result.Body);
        }

        [Test]
        public void DecodesMultiByteUtf8Body()
        {
            var body = "{\"name\":\"₹ café\"}";
            var raw = "HTTP/1.1 200 OK\r\nContent-Length: " + Encoding.UTF8.GetByteCount(body) + "\r\n\r\n" + body;

            Assert.AreEqual(body, Read(raw).Body);
        }

        [TestCase("")]
        [TestCase("garbage\r\n\r\n")]
        [TestCase("HTTP/1.1 abc OK\r\n\r\n")]
        [TestCase("HTTP/1.1 200 OK\r\nContent-Length: 10\r\n\r\nshort")]
        public void RejectsMalformedResponses(string raw)
        {
            Assert.Throws<IOException>(() => Read(raw));
        }
    }
}
