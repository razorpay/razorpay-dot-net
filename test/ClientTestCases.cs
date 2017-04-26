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

            RazorpayClient.setAppsDetails(title, version);

            List<Dictionary<string, string>> appsDetails = RazorpayClient.AppsDetails;

            Assert.True(appsDetails.Count == 1);
            Assert.AreSame(title, appsDetails[0]["title"]);
            Assert.AreSame(version, appsDetails[0]["version"]);
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

            string expectedVersion = "1.2.0";

            Assert.AreSame(expectedVersion, version);
        }
    }
}