using System;
using System.Text;
using Newtonsoft.Json;
using Razorpay.Api.Errors;
using Razorpay.Api.Http;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class RestClient
    {
        private List<HttpMethod> JsonifyInput = new List<HttpMethod>()
        {
            HttpMethod.POST, HttpMethod.PUT, HttpMethod.PATCH
        };

        private readonly IHttpTransport transport;

        public RestClient()
            : this(DefaultTransport())
        {
        }

        internal RestClient(IHttpTransport transport)
        {
            this.transport = transport;
        }

        internal static IHttpTransport DefaultTransport()
        {
            if (RazorpayClient.UseManagedTls)
            {
                return ManagedTlsTransport.Instance;
            }
            return WebRequestTransport.Instance;
        }

        public string MakeRequest(string relativeUrl, HttpMethod method, string data, string host, AuthType authType)
        {
            return MakeRequest(relativeUrl, method, data, host, authType, (DeviceMode?)null);
        }

        public string MakeRequest(string relativeUrl, HttpMethod method, string data, string host, AuthType authType, DeviceMode? mode)
        {
            HttpRequestData request = createRequest(relativeUrl, method, data, host, authType, mode);
            HttpResult response = transport.Send(request);

            if (response.StatusCode < 200 || response.StatusCode >= 300)
            {
                HandleErrors(response.StatusCode, response.Body, host);
            }

            return response.Body;
        }

        private HttpRequestData createRequest(string relativeUrl, HttpMethod method, string data, string host, AuthType authType, DeviceMode? mode)
        {
            string baseUrl;

            switch (host)
            {
                case "API":
                    baseUrl = RazorpayClient.BaseUrl;
                    break;
                case "AUTH":
                    baseUrl = RazorpayClient.DefaultAuthUrl;
                    break;
                default:
                    baseUrl = RazorpayClient.BaseUrl;
                    break;
            }

            // Ensure proper URL construction with path separator
            string fullUrl = baseUrl.TrimEnd('/') + "/" + relativeUrl.TrimStart('/');

            string userAgent = string.Format("{0} {1}", RazorpayClient.Version, getAppDetailsUa());

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers["Authorization"] = GetAuthorizationHeader(authType);

            foreach (KeyValuePair<string, string> header in RazorpayClient.Headers)
            {
                headers[header.Key] = header.Value;
            }

            // Automatically add X-Razorpay-Device-Mode header for DeviceActivity APIs (AuthType.Public with mode)
            if (authType == AuthType.Public && mode.HasValue)
            {
                headers["X-Razorpay-Device-Mode"] = mode.Value.ToString().ToLower();
            }

            byte[] body = null;
            if (JsonifyInput.Contains(method) == true)
            {
                body = Encoding.UTF8.GetBytes(data ?? string.Empty);
            }

            return new HttpRequestData(method.ToString(), new Uri(fullUrl), headers, "application/json", "razorpay-dot-net/" + userAgent, body);
        }

        private string GetAuthorizationHeader(AuthType authType)
        {
            if (authType == AuthType.Public)
            {
                if (RazorpayClient.Key != null)
                {
                    return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(RazorpayClient.Key));
                }
            }
            else
            {
                // For other APIs, use the standard key:secret format
                if (RazorpayClient.Key != null && RazorpayClient.Secret != null)
                {
                    string authString = string.Format("{0}:{1}", RazorpayClient.Key, RazorpayClient.Secret);
                    return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(authString));
                }
                else if (RazorpayClient.AccessToken != null)
                {
                    return "Bearer " + RazorpayClient.AccessToken;
                }
            }
            return null;
        }

        private static string getAppDetailsUa()
        {
            List<Dictionary<string, string>> appsDetails = RazorpayClient.AppsDetails;

            string appsDetailsUa = string.Empty;

            foreach(Dictionary<string, string> appsDetail in appsDetails)
            {
                string appUa = string.Empty;

                if (appsDetail.ContainsKey("title"))
                {
                    appUa = appsDetail["title"];

                    if (appsDetail.ContainsKey("version"))
                    {
                        appUa += appsDetail["version"];
                    }
                }

                appsDetailsUa += appUa;
            }

            return appsDetailsUa;
        }

        private void HandleErrors(int statusCode, string response, string host)
        {
            dynamic data = null;
            string errorCode = string.Empty;
            string field = string.Empty;
            string description = string.Empty;

            try
            {
                data = JsonConvert.DeserializeObject(response);
                errorCode = data["error"]["code"];
                if (host.Equals("AUTH"))
                {
                    if (statusCode >= 400 && statusCode < 500)
                    {
                        errorCode = ErrorCodes.BAD_REQUEST_ERROR.ToString();
                    }
                    else if (statusCode >= 500)
                    {
                        errorCode = ErrorCodes.SERVER_ERROR.ToString();
                    }
                }

                Enum.Parse(typeof(ErrorCodes), errorCode);
                description = data["error"]["description"];
                field = data["error"]["field"];
            }
            catch (Exception)
            {
                ThrowServerError(statusCode);
            }

            throw ErrorCodeHelper.Get(description, errorCode, statusCode, field);
        }

        public void ThrowServerError(int statusCode)
        {
            string description = "The server did not send back a well-formed response.";
            throw new ServerError(description, ErrorCodes.SERVER_ERROR.ToString(), statusCode);
        }
    }
}
