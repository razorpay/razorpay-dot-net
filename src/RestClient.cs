using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Razorpay.Api.Errors;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class RestClient
    {
        private List<HttpMethod> JsonifyInput = new List<HttpMethod>()
        {
            HttpMethod.POST, HttpMethod.PUT, HttpMethod.PATCH
        };

        public string MakeRequest(string relativeUrl, HttpMethod method, string data, string host, AuthType authType)
        {
            HttpWebRequest request = createRequest(relativeUrl, method, host, authType);

            if (JsonifyInput.Contains(method) == true) 
            {
                var bytes = Encoding.UTF8.GetBytes(data);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            return createResponse(request, host);
        }

        private HttpWebRequest createRequest(string relativeUrl, HttpMethod method, string host, AuthType authType)
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullUrl);
            request.Method = method.ToString();
            request.ContentLength = 0;
            request.ContentType = "application/json";

            string userAgent = string.Format("{0} {1}", RazorpayClient.Version, getAppDetailsUa());
            request.UserAgent = "razorpay-dot-net/" + userAgent;

            request.Headers["Authorization"] = GetAuthorizationHeader(authType);

            foreach (KeyValuePair<string, string> header in RazorpayClient.Headers)
            {
                request.Headers[header.Key] = header.Value;
            }

            return request;
        }

        private string GetAuthorizationHeader(AuthType authType)
        {
            if (authType == AuthType.Public)
            {
                // For POS and AUTH APIs, use only the key (not key:secret)
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

        private string createResponse(HttpWebRequest request, string host) 
        {
            var responseValue = string.Empty;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                responseValue = ParseResponse(response);
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
                responseValue = ParseResponse(response);
            }
            finally
            {
                if (response.StatusCode < HttpStatusCode.OK || response.StatusCode >= HttpStatusCode.Ambiguous)
                {
                    HandleErrors(response, responseValue, host);
                }
            }

            return responseValue;
        }

        private string ParseResponse(HttpWebResponse response)
        {
            string responseValue = string.Empty;
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseValue = reader.ReadToEnd();
                    }
            }

            return responseValue;
        }

        private void HandleErrors(HttpWebResponse webResponse, string response, string host)
        {
            int statusCode = (int)webResponse.StatusCode;
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