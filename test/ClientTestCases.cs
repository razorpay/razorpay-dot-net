using Razorpay.Api;
using System;
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
            Helper.Assert(key == RazorpayClient.getKey(), "Not able to get correct key.");
        }

        public static void TestGetSecret(string secret)
        {
            Helper.Assert(secret == RazorpayClient.getSecret(), "Not able to get correct secret.");
        }

        public static void TestAppsDetails()
        {
            string title = "ASP.NET";
            string version = "4.5";

            RazorpayClient.setAppsDetails(title, version);

            List<Dictionary<string, string>> appsDetails = RazorpayClient.getAppsDetails();

            Helper.Assert(appsDetails.Count == 1, "Incorrect number of items set in the list");
            Helper.Assert(appsDetails[0]["title"] == title, "Title not set correctly");
            Helper.Assert(appsDetails[0]["version"] == version, "Version not set correctly");
        }

        public static void TestGetBaseUrl()
        {
            string baseUrl = RazorpayClient.getBaseUrl();

            string actualBaseUrl = "https://api.razorpay.com/v1/";

            Helper.Assert(baseUrl == actualBaseUrl, "Base URL not being returned correctly.");
        }

        public static void TestGetVersion()
        {
            string version = RazorpayClient.getVersion();

            string actualVersion = "1.2.0";

            Helper.Assert(version == actualVersion, "Version not being returned correctly.");
        }
    }
}