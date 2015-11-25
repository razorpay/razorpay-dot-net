using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Razorpay.Api.Errors;
using Newtonsoft.Json;

namespace Razorpay.Api
{
    public class RestClient
    {
        public string MakeRequest(string relativeUrl, HttpMethod method, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(RazorpayClient.BaseUrl + relativeUrl);
            request.Method = method.ToString();
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.UserAgent = "razorpay-dot-net/" + RazorpayClient.Version;

            string authString = string.Format("{0}:{1}", RazorpayClient.Key, RazorpayClient.Secret);
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(
                Encoding.UTF8.GetBytes(authString));

            if (method == HttpMethod.Post)
            {
                var bytes = Encoding.UTF8.GetBytes(data);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

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
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    HandleErrors(response, responseValue);
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

        private void HandleErrors(HttpWebResponse webResponse, string response)
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