using Razorpay.Api;
using NUnit.Framework;

namespace RazorpayClientTest
{
    class CardTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void FetchCardByIdTest()
        {
            Card card = Helper.TestFetchCardById();

            Assert.AreNotSame(null, card);
        }
    }
}