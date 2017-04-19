using Razorpay.Api;

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
    }
}