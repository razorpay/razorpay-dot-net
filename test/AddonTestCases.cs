using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    class AddonTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void CreateAddonTest()
        {
            Addon addon = Helper.TestCreateAddon();

            Assert.NotNull(addon);
        }

        public static void FetchAddonTest()
        {
            Addon addon = Helper.TestFetchAddon();

            Assert.NotNull(addon);
        }

        public static void DeleteAddonTest()
        {
            // If no exception is thrown, then it is a successful delete
            Helper.TestDeleteAddon();
        }
    }
}