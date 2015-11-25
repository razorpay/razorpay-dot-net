using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

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
			using (var response = (HttpWebResponse)request.GetResponse())
			{
				if (response.StatusCode != HttpStatusCode.OK)
				{
				  var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
				  throw new ApplicationException(message);
				}

				using (var responseStream = response.GetResponseStream())
				{
				  if (responseStream != null)
				    using (var reader = new StreamReader(responseStream))
				    {
				      responseValue = reader.ReadToEnd();
				    }
				}
			}

	        return responseValue;
		}
	}
}