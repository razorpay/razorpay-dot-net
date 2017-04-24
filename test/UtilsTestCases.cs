using Razorpay.Api;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    public class UtilsTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void VerifyPaymentSignatureTest()
        {
            Helper.TestVerifyPaymentSignature();
        }
    }
}