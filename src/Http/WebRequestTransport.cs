using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Razorpay.Api.Http
{
    // Default transport: HttpWebRequest, with TLS negotiated by the operating system.
    internal sealed class WebRequestTransport : IHttpTransport
    {
        internal static readonly WebRequestTransport Instance = new WebRequestTransport();

        public HttpResult Send(HttpRequestData request)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(request.Uri);
            webRequest.Method = request.Method;
            webRequest.ContentLength = 0;
            webRequest.ContentType = request.ContentType;
            webRequest.UserAgent = request.UserAgent;

            foreach (KeyValuePair<string, string> header in request.Headers)
            {
                if (header.Value != null)
                {
                    webRequest.Headers[header.Key] = header.Value;
                }
            }

            if (request.Body != null)
            {
                webRequest.ContentLength = request.Body.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(request.Body, 0, request.Body.Length);
                }
            }

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException ex) when (ex.Response is HttpWebResponse)
            {
                // Non-2xx responses still carry an API error body.
                // Failures without a response (TLS, DNS, timeouts) propagate unchanged.
                response = (HttpWebResponse)ex.Response;
            }

            using (response)
            {
                return new HttpResult((int)response.StatusCode, ReadBody(response));
            }
        }

        private static string ReadBody(HttpWebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                if (responseStream == null)
                {
                    return string.Empty;
                }

                using (StreamReader reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
