using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Razorpay.Tests.Mocks
{
    public class MockHttpHandler : HttpMessageHandler
    {
        private readonly Queue<MockResponse> _responses = new Queue<MockResponse>();
        public List<HttpRequestMessage> CapturedRequests { get; } = new List<HttpRequestMessage>();

        public void QueueResponse(HttpStatusCode statusCode, string content)
        {
            _responses.Enqueue(new MockResponse { StatusCode = statusCode, Content = content });
        }

        public void QueueJsonResponse(string jsonContent)
        {
            QueueResponse(HttpStatusCode.OK, jsonContent);
        }

        public void QueueErrorResponse(HttpStatusCode statusCode, string errorCode, string description)
        {
            string errorJson = $"{{\"error\":{{\"code\":\"{errorCode}\",\"description\":\"{description}\",\"field\":null}}}}";
            QueueResponse(statusCode, errorJson);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            CapturedRequests.Add(request);

            if (_responses.Count == 0)
            {
                throw new InvalidOperationException("No mock responses queued");
            }

            var mockResponse = _responses.Dequeue();
            var response = new HttpResponseMessage(mockResponse.StatusCode)
            {
                Content = new StringContent(mockResponse.Content)
            };

            return Task.FromResult(response);
        }

        private class MockResponse
        {
            public HttpStatusCode StatusCode { get; set; }
            public string Content { get; set; }
        }
    }
}
