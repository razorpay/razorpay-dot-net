using System;
using System.Collections.Generic;

namespace Razorpay.Api.Http
{
    internal interface IHttpTransport
    {
        HttpResult Send(HttpRequestData request);
    }

    internal sealed class HttpRequestData
    {
        public const int DefaultTimeoutMilliseconds = 100000;

        public HttpRequestData(string method, Uri uri, IDictionary<string, string> headers, string contentType, string userAgent, byte[] body)
        {
            Method = method;
            Uri = uri;
            Headers = headers;
            ContentType = contentType;
            UserAgent = userAgent;
            Body = body;
        }

        public string Method { get; private set; }
        public Uri Uri { get; private set; }
        public IDictionary<string, string> Headers { get; private set; }
        public string ContentType { get; private set; }
        public string UserAgent { get; private set; }
        public byte[] Body { get; private set; }

        public int TimeoutMilliseconds
        {
            get { return DefaultTimeoutMilliseconds; }
        }
    }

    internal sealed class HttpResult
    {
        public HttpResult(int statusCode, string body)
        {
            StatusCode = statusCode;
            Body = body;
        }

        public int StatusCode { get; private set; }
        public string Body { get; private set; }
    }
}
