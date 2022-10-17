using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    class ClientTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void TestGetKey(string key)
        {
            Assert.AreSame(key, RazorpayClient.Key);
        }

        public static void TestGetSecret(string secret)
        {
            Assert.AreSame(secret, RazorpayClient.Secret);
        }

        public static void TestAppsDetails()
        {
            string title = "ASP.NET";
            string version = "4.5";

            Helper.client.setAppsDetails(title, version);

            List<Dictionary<string, string>> appsDetails = RazorpayClient.AppsDetails;

            Assert.True(appsDetails.Count == 1);
            Assert.AreSame(title, appsDetails[0]["title"]);
            Assert.AreSame(version, appsDetails[0]["version"]);
        }

        public static void TestHeaders()
        {
            string headerKey = "X-RZP-TEST";
            string headerValue = "success";

            Helper.client.addHeader(headerKey, headerValue);

            Dictionary<string, string> headers = RazorpayClient.Headers;

            Assert.True(headers.Count == 1);

            string value;
            headers.TryGetValue(headerKey, out value);

            Assert.AreSame(value, headerValue);
        }


        public static void TestGetBaseUrl()
        {
            string baseUrl = RazorpayClient.BaseUrl;

            string expectedBaseUrl = "https://api.razorpay.com/v1/";

            Assert.AreSame(expectedBaseUrl, baseUrl);
        }

        public static void TestGetVersion()
        {
            string version = RazorpayClient.Version;

            string expectedVersion = "3.0.2";

            Assert.AreSame(expectedVersion, version);
        }
    }
}