using System.Net;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Api.Errors;
using Razorpay.Api.Http;

namespace Razorpay.Tests
{
    public class RestClientTransportTests
    {
        private class FakeTransport : IHttpTransport
        {
            public HttpRequestData LastRequest;
            public HttpResult Result;
            public WebException Throw;

            public HttpResult Send(HttpRequestData request)
            {
                LastRequest = request;
                if (Throw != null) throw Throw;
                return Result;
            }
        }

        [SetUp]
        public void SetUp()
        {
            new RazorpayClient("rzp_test_key", "secret");
        }

        [Test]
        public void SendsJsonBodyAndAuthForPost()
        {
            var transport = new FakeTransport { Result = new HttpResult(200, "{\"id\":\"order_1\"}") };

            var body = new RestClient(transport).MakeRequest("v1/orders", HttpMethod.POST, "{\"amount\":100}", "API", AuthType.Private);

            Assert.AreEqual("{\"id\":\"order_1\"}", body);
            Assert.AreEqual("POST", transport.LastRequest.Method);
            Assert.AreEqual("https://api.razorpay.com/v1/orders", transport.LastRequest.Uri.ToString());
            Assert.AreEqual("{\"amount\":100}", System.Text.Encoding.UTF8.GetString(transport.LastRequest.Body));
            StringAssert.StartsWith("Basic ", transport.LastRequest.Headers["Authorization"]);
            StringAssert.StartsWith("razorpay-dot-net/", transport.LastRequest.UserAgent);
        }

        [Test]
        public void SendsNoBodyForGet()
        {
            var transport = new FakeTransport { Result = new HttpResult(200, "{}") };

            new RestClient(transport).MakeRequest("v1/orders/order_1", HttpMethod.GET, null, "API", AuthType.Private);

            Assert.IsNull(transport.LastRequest.Body);
        }

        [Test]
        public void MapsApiErrorResponse()
        {
            var transport = new FakeTransport
            {
                Result = new HttpResult(400, "{\"error\":{\"code\":\"BAD_REQUEST_ERROR\",\"description\":\"bad amount\",\"field\":\"amount\"}}")
            };

            var ex = Assert.Throws<BadRequestError>(() =>
                new RestClient(transport).MakeRequest("v1/orders", HttpMethod.POST, "{}", "API", AuthType.Private));
            Assert.AreEqual("bad amount", ex.Message);
        }

        [Test]
        public void MapsNonJsonErrorToServerError()
        {
            var transport = new FakeTransport { Result = new HttpResult(502, "<html>bad gateway</html>") };

            Assert.Throws<ServerError>(() =>
                new RestClient(transport).MakeRequest("v1/orders", HttpMethod.GET, null, "API", AuthType.Private));
        }

        [Test]
        public void SurfacesTransportFailureInsteadOfNullReference()
        {
            var failure = new WebException("Could not create SSL/TLS secure channel", WebExceptionStatus.SecureChannelFailure);
            var transport = new FakeTransport { Throw = failure };

            var ex = Assert.Throws<WebException>(() =>
                new RestClient(transport).MakeRequest("v1/orders", HttpMethod.GET, null, "API", AuthType.Private));
            Assert.AreEqual(WebExceptionStatus.SecureChannelFailure, ex.Status);
        }

        [Test]
        public void SelectsTransportFromClientSetting()
        {
            try
            {
                RazorpayClient.UseManagedTls = true;
                Assert.IsInstanceOf<ManagedTlsTransport>(RestClient.DefaultTransport());

                RazorpayClient.UseManagedTls = false;
                Assert.IsInstanceOf<WebRequestTransport>(RestClient.DefaultTransport());
            }
            finally
            {
                RazorpayClient.UseManagedTls = false;
            }
        }
    }
}
