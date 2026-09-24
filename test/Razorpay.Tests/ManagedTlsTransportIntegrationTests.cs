using System;
using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using Razorpay.Api.Http;

namespace Razorpay.Tests
{
    // Live network tests. Run with: dotnet test --filter Category=Integration
    [Category("Integration")]
    public class ManagedTlsTransportIntegrationTests
    {
        private static HttpRequestData Get(string url)
        {
            return new HttpRequestData("GET", new Uri(url), new Dictionary<string, string>(), "application/json", "razorpay-dot-net/test", null);
        }

        [Test]
        public void ConnectsToRazorpayApi()
        {
            // No credentials: a completed TLS handshake + HTTP exchange yields 401.
            var result = new ManagedTlsTransport().Send(Get("https://api.razorpay.com/v1/orders"));

            Assert.AreEqual(401, result.StatusCode);
        }

        [TestCase("https://expired.badssl.com/")]
        [TestCase("https://wrong.host.badssl.com/")]
        [TestCase("https://self-signed.badssl.com/")]
        [TestCase("https://untrusted-root.badssl.com/")]
        public void RejectsInvalidCertificates(string url)
        {
            var ex = Assert.Throws<WebException>(() => new ManagedTlsTransport().Send(Get(url)));
            Assert.AreEqual(WebExceptionStatus.SecureChannelFailure, ex.Status);
        }

        [Test]
        public void RefusesPlainHttp()
        {
            Assert.Throws<ArgumentException>(() => new ManagedTlsTransport().Send(Get("http://api.razorpay.com/v1/orders")));
        }
    }
}
